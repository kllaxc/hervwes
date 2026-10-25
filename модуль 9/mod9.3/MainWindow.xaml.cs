using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace TaskManagerWPF
{
    public enum TaskPriority { Низкий, Средний, Высокий }

    public class TaskItem
    {
        public string Title { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }

    public partial class MainWindow : Window
    {
        public ObservableCollection<TaskItem> Tasks { get; set; } = new ObservableCollection<TaskItem>();

        public MainWindow()
        {
            InitializeComponent();
            CmbPriority.ItemsSource = Enum.GetValues(typeof(TaskPriority));
            CmbPriority.SelectedIndex = 1;
            DpDueDate.SelectedDate = DateTime.Now.AddDays(1);
            DgTasks.ItemsSource = Tasks;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtTitle.Text))
            {
                MessageBox.Show("Введите название задачи!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Tasks.Add(new TaskItem
            {
                Title = TxtTitle.Text,
                Priority = (TaskPriority)CmbPriority.SelectedItem,
                DueDate = DpDueDate.SelectedDate ?? DateTime.Now,
                IsCompleted = false
            });

            TxtTitle.Clear();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DgTasks.SelectedItem is TaskItem selectedTask)
            {
                Tasks.Remove(selectedTask);
            }
        }

        // Проверка надвигающихся сроков выполнения (уведомления)
        private void BtnCheckNotifications_Click(object sender, RoutedEventArgs e)
        {
            var upcomingTasks = Tasks.Where(t => !t.IsCompleted && (t.DueDate - DateTime.Now).TotalDays <= 1).ToList();

            if (upcomingTasks.Any())
            {
                string message = "Внимание! Срок следующих задач истекает в течение 24 часов:\n\n" +
                                 string.Join("\n", upcomingTasks.Select(t => $"• {t.Title} (до {t.DueDate:dd.MM.yyyy})"));
                MessageBox.Show(message, "Уведомление о дедлайнах", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("Срочных задач нет.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}