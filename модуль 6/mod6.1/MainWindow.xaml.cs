using System;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Windows;
using System.Windows.Controls;

namespace mod6_1
{
    public partial class MainWindow : Window
    {
        private string dbConnection = "Data Source=employees.db";
        private int selectedId = -1;

        public MainWindow()
        {
            InitializeComponent();
            InitDatabase();
            LoadData();
        }

        private void InitDatabase()
        {
            using (SqliteConnection conn = new SqliteConnection(dbConnection))
            {
                conn.Open();
                string query = "CREATE TABLE IF NOT EXISTS Employees (Id INTEGER PRIMARY KEY AUTOINCREMENT, FullName TEXT, Position TEXT, Department TEXT, Salary REAL)";
                using (SqliteCommand cmd = new SqliteCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void LoadData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("FullName", typeof(string));
            dt.Columns.Add("Position", typeof(string));
            dt.Columns.Add("Department", typeof(string));
            dt.Columns.Add("Salary", typeof(decimal));

            using (SqliteConnection conn = new SqliteConnection(dbConnection))
            {
                conn.Open();
                string query = "SELECT * FROM Employees";
                using (SqliteCommand cmd = new SqliteCommand(query, conn))
                {
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetDecimal(4)
                            );
                        }
                    }
                }
            }
            dgEmployees.ItemsSource = dt.DefaultView;
        }

        private void ClearFields()
        {
            txtFullName.Clear();
            txtPosition.Clear();
            txtDepartment.Clear();
            txtSalary.Clear();
            selectedId = -1;
            dgEmployees.UnselectAll();
        }

        private void DgEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgEmployees.SelectedItem is DataRowView row)
            {
                selectedId = Convert.ToInt32(row["Id"]);
                txtFullName.Text = row["FullName"].ToString();
                txtPosition.Text = row["Position"].ToString();
                txtDepartment.Text = row["Department"].ToString();
                txtSalary.Text = row["Salary"].ToString();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFullName.Text) && decimal.TryParse(txtSalary.Text, out decimal salary))
            {
                using (SqliteConnection conn = new SqliteConnection(dbConnection))
                {
                    conn.Open();
                    string query = "INSERT INTO Employees (FullName, Position, Department, Salary) VALUES (@name, @pos, @dept, @sal)";
                    using (SqliteCommand cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@pos", txtPosition.Text);
                        cmd.Parameters.AddWithValue("@dept", txtDepartment.Text);
                        cmd.Parameters.AddWithValue("@sal", salary);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedId != -1 && decimal.TryParse(txtSalary.Text, out decimal salary))
            {
                using (SqliteConnection conn = new SqliteConnection(dbConnection))
                {
                    conn.Open();
                    string query = "UPDATE Employees SET FullName=@name, Position=@pos, Department=@dept, Salary=@sal WHERE Id=@id";
                    using (SqliteCommand cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@pos", txtPosition.Text);
                        cmd.Parameters.AddWithValue("@dept", txtDepartment.Text);
                        cmd.Parameters.AddWithValue("@sal", salary);
                        cmd.Parameters.AddWithValue("@id", selectedId);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
                ClearFields();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedId != -1)
            {
                using (SqliteConnection conn = new SqliteConnection(dbConnection))
                {
                    conn.Open();
                    string query = "DELETE FROM Employees WHERE Id=@id";
                    using (SqliteCommand cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedId);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
                ClearFields();
            }
        }
    }
}