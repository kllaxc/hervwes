using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace mod_8
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<ExpenseItem> _transactions;
        private ICollectionView _transactionView;

        public MainWindow()
        {
            InitializeComponent();

            // Пример начальных данных в белорусских рублях (BYN)
            _transactions = new ObservableCollection<ExpenseItem>
            {
                new ExpenseItem { Type = "Доход", Title = "Стипендия", Amount = 150.00m, Category = "Зарплата", Date = DateTime.Today.AddDays(-5) },
                new ExpenseItem { Type = "Расход", Title = "Продукты", Amount = 70.55m, Category = "Продукты", Date = DateTime.Today.AddDays(-2) },
                new ExpenseItem { Type = "Расход", Title = "Поездка домой", Amount = 100.0m, Category = "Транспорт", Date = DateTime.Today }
            };

            _transactionView = CollectionViewSource.GetDefaultView(_transactions);
            _transactionView.Filter = FilterTransactions;

            LvTransactions.ItemsSource = _transactionView;
            DpDate.SelectedDate = DateTime.Today;

            UpdateBalance();
        }

        private bool FilterTransactions(object item)
        {
            if (!(item is ExpenseItem transaction)) return false;

            if (CbFilter.SelectedItem is ComboBoxItem filterItem)
            {
                string filterText = filterItem.Content.ToString();
                if (filterText == "Расходы" && transaction.Type != "Расход") return false;
                if (filterText == "Доходы" && transaction.Type != "Доход") return false;
            }

            return true;
        }

        private void UpdateBalance()
        {
            decimal balance = 0;
            foreach (var item in _transactions)
            {
                if (item.Type == "Доход")
                    balance += item.Amount;
                else
                    balance -= item.Amount;
            }
            TxtBalance.Text = $"{balance:N2} BYN";
        }
                private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtTitle.Text))
            {
                MessageBox.Show("Введите название операции!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(TxtAmount.Text.Replace('.', ','), out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Введите корректную сумму большую нуля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string type = (CbType.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "Расход";
            string category = (CbCategory.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "Прочее";

            var newItem = new ExpenseItem
            {
                Type = type,
                Title = TxtTitle.Text.Trim(),
                Amount = amount,
                Category = category,
                Date = DpDate.SelectedDate ?? DateTime.Today
            };

            _transactions.Add(newItem);
            UpdateBalance();

            // Очистка полей
            TxtTitle.Clear();
            TxtAmount.Clear();
            DpDate.SelectedDate = DateTime.Today;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            ExpenseItem selected = LvTransactions.SelectedItem as ExpenseItem;
            if (selected != null)
            {
                _transactions.Remove(selected);
                UpdateBalance();
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_transactionView != null)
            {
                _transactionView.Refresh();
            }
        }
    }
}