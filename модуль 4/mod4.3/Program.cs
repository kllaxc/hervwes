using System;
//созданный интерфейс студента
interface IUniversityStudent
{
    string GetFullName();
    double GetAverageGrade();
    string GetCourseInfo();
}
class JuniorStudent : IUniversityStudent
{
    private string fullName;
    private int course;
    private double averageGrade;
    public JuniorStudent(string name, int course, double grade) { fullName = name; this.course = course; averageGrade = grade; }
    public string GetFullName() => fullName;
    public double GetAverageGrade() => averageGrade;
    public string GetCourseInfo() => $"{course} курс";
}
class Program
{
    static void Main()
    {
        IUniversityStudent student = new JuniorStudent("Кухальская Милана", 3, 8.2);
        Console.WriteLine($"Студент: {student.GetFullName()}, {student.GetCourseInfo()}, Ср. балл: {student.GetAverageGrade()}");
    }
}