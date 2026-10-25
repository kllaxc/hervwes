using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace StudentManagementSystem
{
    // Класс, представляющий модель студента
    public class Student
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Faculty { get; set; }
        public double AverageScore { get; set; }

        public override string ToString()
        {
            return $"ID: {Id.ToString().Substring(0, 8)} | {LastName} {FirstName} | Возраст: {Age} | Факультет: {Faculty} | Ср. балл: {AverageScore:F2}";
        }
    }

    // Менеджер для управления студентами и работы с файлом
    public class StudentManager
    {
        private List<Student> _students = new List<Student>();
        private readonly string _filePath;

        public StudentManager(string filePath = "students.json")
        {
            _filePath = filePath;
            LoadFromFile();
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
            SaveToFile();
        }

        public bool RemoveStudent(Guid id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _students.Remove(student);
                SaveToFile();
                return true;
            }
            return false;
        }

        public bool EditStudent(Guid id, string firstName, string lastName, int age, string faculty, double score)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;
                student.Faculty = faculty;
                student.AverageScore = score;
                SaveToFile();
                return true;
            }
            return false;
        }

        public List<Student> GetAll() => _students;

        public List<Student> Search(string query)
        {
            query = query.ToLower();
            return _students.Where(s => s.FirstName.ToLower().Contains(query) ||
                                        s.LastName.ToLower().Contains(query) ||
                                        s.Faculty.ToLower().Contains(query)).ToList();
        }

        public List<Student> SortByLastName() => _students.OrderBy(s => s.LastName).ToList();

        public List<Student> SortByAverageScore() => _students.OrderByDescending(s => s.AverageScore).ToList();

        public void SaveToFile()
        {
            string json = JsonSerializer.Serialize(_students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public void LoadFromFile()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                _students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Управление списком студентов");
                Console.WriteLine("1. Вывести всех студентов");
                Console.WriteLine("2. Добавить студента");
                Console.WriteLine("3. Редактировать студента");
                Console.WriteLine("4. Удалить студента");
                Console.WriteLine("5. Поиск студентов");
                Console.WriteLine("6. Сортировка по фамилии");
                Console.WriteLine("7. Сортировка по среднему баллу");
                Console.WriteLine("0. Выход");
                Console.Write("\nВыберите действие: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ShowList(manager.GetAll());
                        break;
                    case "2":
                        Console.Write("Имя: "); string fn = Console.ReadLine();
                        Console.Write("Фамилия: "); string ln = Console.ReadLine();
                        Console.Write("Возраст: "); int age = int.Parse(Console.ReadLine());
                        Console.Write("Факультет: "); string fac = Console.ReadLine();
                        Console.Write("Средний балл: "); double score = double.Parse(Console.ReadLine());
                        manager.AddStudent(new Student { FirstName = fn, LastName = ln, Age = age, Faculty = fac, AverageScore = score });
                        Console.WriteLine("Студент успешно добавлен!");
                        break;
                    case "3":
                        ShowList(manager.GetAll());
                        Console.Write("Введите первые 8 символов ID для редактирования: ");
                        string editIdStr = Console.ReadLine();
                        var targetEdit = manager.GetAll().FirstOrDefault(s => s.Id.ToString().StartsWith(editIdStr));
                        if (targetEdit != null)
                        {
                            Console.Write("Новое имя: "); string eFn = Console.ReadLine();
                            Console.Write("Новая фамилия: "); string eLn = Console.ReadLine();
                            Console.Write("Новый возраст: "); int eAge = int.Parse(Console.ReadLine());
                            Console.Write("Новый факультет: "); string eFac = Console.ReadLine();
                            Console.Write("Новый средний балл: "); double eScore = double.Parse(Console.ReadLine());
                            manager.EditStudent(targetEdit.Id, eFn, eLn, eAge, eFac, eScore);
                            Console.WriteLine("Данные обновлены!");
                        }
                        else Console.WriteLine("Студент не найден!");
                        break;
                    case "4":
                        ShowList(manager.GetAll());
                        Console.Write("Введите первые 8 символов ID для удаления: ");
                        string delIdStr = Console.ReadLine();
                        var targetDel = manager.GetAll().FirstOrDefault(s => s.Id.ToString().StartsWith(delIdStr));
                        if (targetDel != null && manager.RemoveStudent(targetDel.Id))
                            Console.WriteLine("Студент удален!");
                        else
                            Console.WriteLine("Студент не найден!");
                        break;
                    case "5":
                        Console.Write("Введите запрос для поиска: ");
                        string q = Console.ReadLine();
                        ShowList(manager.Search(q));
                        break;
                    case "6":
                        ShowList(manager.SortByLastName());
                        break;
                    case "7":
                        ShowList(manager.SortByAverageScore());
                        break;
                    case "0":
                        return;
                }
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        static void ShowList(List<Student> list)
        {
            Console.WriteLine("\n--- Список студентов ---");
            if (list.Count == 0) Console.WriteLine("Записи не найдены.");
            else list.ForEach(s => Console.WriteLine(s));
        }
    }
}