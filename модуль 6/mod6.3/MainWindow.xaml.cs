using System;
using System.IO;
using System.Windows;

namespace mod6_3
{
    public partial class MainWindow : Window
    {
        private string filePath = "library_data.txt";

        public MainWindow()
        {
            InitializeComponent();
            InitDefaultData();
            LoadData();
        }

        private void InitDefaultData()
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = new StreamWriter(filePath, false))
                {
                    sw.WriteLine("Война и мир|Л.Н. Толстой|Доступна");
                    sw.WriteLine("Преступление и наказание|Ф.М. Достоевский|Доступна");
                    sw.WriteLine("Мастер и Маргарита|М.А. Булгаков|Арендована");
                }
            }
        }

        private void LoadData(string filter = "")
        {
            dgBooks.Items.Clear();
            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadAllLines(filePath))
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        string title = parts[0];
                        string author = parts[1];
                        string status = parts[2];

                        if (string.IsNullOrEmpty(filter) ||
                            title.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            author.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            dgBooks.Items.Add(new BookItem { Title = title, Author = author, Status = status });
                        }
                    }
                }
            }
        }

        private void SaveAllData()
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (var item in dgBooks.Items)
                {
                    if (item is BookItem book)
                    {
                        sw.WriteLine($"{book.Title}|{book.Author}|{book.Status}");
                    }
                }
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e) => LoadData(txtSearch.Text);

        private void BtnRent_Click(object sender, RoutedEventArgs e)
        {
            if (dgBooks.SelectedItem is BookItem book)
            {
                if (book.Status == "Доступна")
                {
                    book.Status = "Арендована";
                    dgBooks.Items.Refresh();
                    SaveAllData();
                    LoadData(txtSearch.Text);
                }
                else MessageBox.Show("Эта книга уже арендована!");
            }
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            if (dgBooks.SelectedItem is BookItem book)
            {
                book.Status = "Доступна";
                dgBooks.Items.Refresh();
                SaveAllData();
                LoadData(txtSearch.Text);
            }
        }
    }

    public class BookItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
    }
}