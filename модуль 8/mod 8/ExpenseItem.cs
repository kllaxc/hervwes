using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace mod_8
{
    public class ExpenseItem : INotifyPropertyChanged
    {
        private string _title = string.Empty;
        private decimal _amount;
        private string _category = "Прочее";
        private DateTime _date = DateTime.Today;
        private string _type = "Расход"; // "Доход" или "Расход"
        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(); }
        }
        public decimal Amount
        {
            get => _amount;
            set { _amount = value; OnPropertyChanged(); }
        }
        public string Category
        {
            get => _category;
            set { _category = value; OnPropertyChanged(); }
        }
        public DateTime Date
        {
            get => _date;
            set { _date = value; OnPropertyChanged(); }
        }

        public string Type
        {
            get => _type;
            set { _type = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}