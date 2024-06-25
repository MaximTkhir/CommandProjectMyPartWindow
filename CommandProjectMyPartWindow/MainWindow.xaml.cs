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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommandProjectMyPartWindow
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PatientButton_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow patientWindow = new PatientWindow();
            patientWindow.Show();
            this.Close();
        }

        private void DoctorButton_Click(object sender, RoutedEventArgs e)
        {
            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.Show();
            this.Close();
        }
    }
}