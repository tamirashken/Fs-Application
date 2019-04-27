
using System.Windows;
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
            vm = new SettingsWindowViewModel(ApplicationSettingsModel.Instance);
            this.DataContext = vm;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}
