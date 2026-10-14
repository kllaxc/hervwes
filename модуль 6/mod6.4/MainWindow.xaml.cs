using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace mod6_4
{
    public partial class MainWindow : Window
    {
        private string filePath = "finance_data.txt";

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgFinance.Items.Clear();
            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadAllLines(filePath))
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 5 && decimal.TryParse(parts[2], out decimal amt))
                    {
                        dgFinance.Items.Add(new FinanceItem { Type = parts[0], Category = parts[1], Amount = amt, Description = parts[3], Date = parts[4] });
                    }
                }
            }
            CalculateBalance();
        }

        private void SaveData()
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (var item in dgFinance.Items)
                {
                    if (item is FinanceItem fin)
                    {
                        sw.WriteLine($"{fin.Type}|{fin.Category}|{fin.Amount}|{fin.Description}|{fin.Date}");
                    }
                }
            }
        }

        private void CalculateBalance()
        {
            decimal balance = 0;
            foreach (var item in dgFinance.Items)
            {
                if (item is FinanceItem fin)
                {
                    if (fin.Type == "Доход") balance += fin.Amount;
                    else balance -= fin.Amount;
                }
            }
            lblBalance.Text = $"Итоговый баланс: {balance} руб.";
            lblBalance.Foreground = balance >= 0 ? Brushes.Green : Brushes.Red;
        }

        private void ClearFields()
        {
            txtCategory.Clear();
            txtAmount.Clear();
            txtDescription.Clear();
            cbType.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCategory.Text) && decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                string type = (cbType.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "Доход";
                string date = DateTime.Now.ToShortDateString();

                dgFinance.Items.Add(new FinanceItem { Type = type, Category = txtCategory.Text, Amount = amount, Description = txtDescription.Text, Date = date });
                SaveData();
                CalculateBalance();
                ClearFields();
            }
            else MessageBox.Show("Введите корректные данные!");
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgFinance.SelectedItem is FinanceItem)
            {
                dgFinance.Items.Remove(dgFinance.SelectedItem);
                SaveData();
                CalculateBalance();
            }
        }
    }

    public class FinanceItem
    {
        public string Type { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
    }
}