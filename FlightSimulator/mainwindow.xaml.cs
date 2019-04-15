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
using FlightSimulator.Views.Windows;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for mainwindow.xaml
    /// </summary>
    public partial class mainwindow : Window
    {
        public mainwindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

        }

        private void Joystick_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {

            //connect and do something

        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings settingWin = new Settings();
            settingWin.ShowDialog();
        }

    }
}
