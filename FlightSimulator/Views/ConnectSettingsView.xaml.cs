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
using FlightSimulator.ViewModels;
using FlightSimulator.Model;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for ConnectSettingsView.xaml
    /// </summary>
    public partial class ConnectSettingsView : UserControl
    {
        ConnectionViewModel vm;

        public ConnectSettingsView()
        {
            InitializeComponent();
            vm = new ConnectionViewModel(FlightManagerModel.Instance);
            this.DataContext = vm;
            if (vm.OpenAction == null)
            {
                vm.OpenAction = new Action(() =>
                {
                    Settings settingWin = new Settings();
                    settingWin.ShowDialog();
                });
            }
        }
    }

    /*private void btnConnect_Click(object sender, RoutedEventArgs e)
    {

        //connect and do something

    }

    private void btnSettings_Click(object sender, RoutedEventArgs e)
    {
        Settings settingWin = new Settings();
        settingWin.ShowDialog();
    }*/
}
