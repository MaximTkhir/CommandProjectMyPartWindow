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
    public partial class PatientWindow : Window
    {
        private const string DataFolder = "Data";
        private const string PatientFilePath = "Data/patients.json";

        public PatientWindow()
        {
            InitializeComponent();
            EnsureDataDirectoryExists();
        }

        private void EnsureDataDirectoryExists()
        {
            if (!Directory.Exists(DataFolder))
            {
                Directory.CreateDirectory(DataFolder);
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string policyNumber = PolicyNumberTextBox.Text;
            if (policyNumber.Length == 16 && long.TryParse(policyNumber, out _))
            {
                SavePatientData(policyNumber);
                MessageBox.Show("Успешный вход пациента");
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный номер полиса");
            }
        }

        private void SavePatientData(string policyNumber)
        {
            var patientData = new { PolicyNumber = policyNumber };
            File.WriteAllText(PatientFilePath, JsonConvert.SerializeObject(patientData, Formatting.Indented));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}