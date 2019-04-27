
using System.Windows.Controls;
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
        }
    }

}
