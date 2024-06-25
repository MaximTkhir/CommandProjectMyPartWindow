using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Newtonsoft.Json;

namespace CommandProjectMyPartWindow
{
    public partial class DoctorWindow : Window
    {
        private const string DataFolder = "Data";
        private const string DoctorFilePath = "Data/doctors.json";
        private const string AdminFilePath = "Data/admins.json";

        public DoctorWindow()
        {
            InitializeComponent();
            EnsureDataDirectoryExists();
            IsAdminCheckBox.Checked += IsAdminCheckBox_Checked;
            IsAdminCheckBox.Unchecked += IsAdminCheckBox_Unchecked;
        }

        private void EnsureDataDirectoryExists()
        {
            if (!Directory.Exists(DataFolder))
            {
                Directory.CreateDirectory(DataFolder);
            }
        }

        private void IsAdminCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AdminCodeLabel.Visibility = Visibility.Visible;
            AdminCodeTextBox.Visibility = Visibility.Visible;
        }

        private void IsAdminCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            AdminCodeLabel.Visibility = Visibility.Hidden;
            AdminCodeTextBox.Visibility = Visibility.Hidden;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string employeeNumber = EmployeeNumberTextBox.Text;
            string password = PasswordBox.Password;

            if (IsAdminCheckBox.IsChecked == true)
            {
                string adminCode = AdminCodeTextBox.Text;
                if (ValidateAdminCredentials(employeeNumber, password, adminCode))
                {
                    SaveAdminData(employeeNumber, password, adminCode);
                    MessageBox.Show("Успешный вход администратора");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неправильные данные администратора");
                }
            }
            else
            {
                if (ValidateDoctorCredentials(employeeNumber, password))
                {
                    SaveDoctorData(employeeNumber, password);
                    MessageBox.Show("Успешный вход врача");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неправильные данные врача");
                }
            }
        }

        private bool ValidateDoctorCredentials(string employeeNumber, string password)
        {
            // Idk, но можем придумать логику для проверки заполненния. Но мы так то не успеваем xD
            return true;
        }

        private bool ValidateAdminCredentials(string employeeNumber, string password, string adminCode)
        {
            // Тут тоже самое и для админа можно придумать.
            return adminCode == "1234"; // вот как раз наш код для админа 
        }

        private void SaveDoctorData(string employeeNumber, string password)
        {
            var doctorData = new { EmployeeNumber = employeeNumber, Password = password };
            File.WriteAllText(DoctorFilePath, JsonConvert.SerializeObject(doctorData, Formatting.Indented));
        }

        private void SaveAdminData(string employeeNumber, string password, string adminCode)
        {
            var adminData = new { EmployeeNumber = employeeNumber, Password = password, AdminCode = adminCode };
            File.WriteAllText(AdminFilePath, JsonConvert.SerializeObject(adminData, Formatting.Indented));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}