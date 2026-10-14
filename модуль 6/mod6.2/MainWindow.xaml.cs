using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace mod6_2 
{
    public partial class MainWindow : Window
    {
        private string filePath = "tasks_data.txt";
        private int selectedIndex = -1;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgTasks.Items.Clear();
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        dgTasks.Items.Add(new TaskItem { Title = parts[0], Description = parts[1], Status = parts[2] });
                    }
                }
            }
        }

        private void SaveData()
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (var item in dgTasks.Items)
                {
                    if (item is TaskItem task)
                    {
                        sw.WriteLine($"{task.Title}|{task.Description}|{task.Status}");
                    }
                }
            }
        }

        private void ClearFields()
        {
            txtTitle.Clear();
            txtDescription.Clear();
            cbStatus.SelectedIndex = 0;
            selectedIndex = -1;
            dgTasks.UnselectAll();
        }

        private void DgTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgTasks.SelectedItem is TaskItem task)
            {
                selectedIndex = dgTasks.SelectedIndex;
                txtTitle.Text = task.Title;
                txtDescription.Text = task.Description;
                cbStatus.Text = task.Status;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                string status = (cbStatus.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "К выполнению";
                dgTasks.Items.Add(new TaskItem { Title = txtTitle.Text, Description = txtDescription.Text, Status = status });
                SaveData();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Введите название задачи!");
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (selectedIndex >= 0 && selectedIndex < dgTasks.Items.Count)
            {
                string status = (cbStatus.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "К выполнению";
                dgTasks.Items[selectedIndex] = new TaskItem { Title = txtTitle.Text, Description = txtDescription.Text, Status = status };
                SaveData();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Выберите задачу для обновления!");
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedIndex >= 0 && selectedIndex < dgTasks.Items.Count)
            {
                dgTasks.Items.RemoveAt(selectedIndex);
                SaveData();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Выберите задачу для удаления!");
            }
        }
    }

    public class TaskItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}