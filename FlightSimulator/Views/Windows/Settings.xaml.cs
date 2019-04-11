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
using FlightSimulator.ViewModels.Windows;
using FlightSimulator.Model;

namespace FlightSimulator.Views.Windows
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private SettingsWindowViewModel vm;

        public Settings()
        {
            InitializeComponent();
            vm = new SettingsWindowViewModel(new ApplicationSettingsModel());
            this.DataContext = vm;
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            vm.SaveSettings();
            mainwindow win = (mainwindow)Application.Current.MainWindow;
            win.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            mainwindow win = (mainwindow)Application.Current.MainWindow;
            win.Show();
            this.Close();
        }
    }
}
