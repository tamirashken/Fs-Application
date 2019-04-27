
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using FlightSimulator.Model;
using FlightSimulator.ViewModels;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;


namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for FlightBoard.xaml
    /// </summary>
    public partial class FlightBoard : UserControl
    {
        ObservableDataSource<Point> planeLocations = null;
        FlightBoardViewModel vm;
        private bool isFirst;
        public FlightBoard()
        {
            InitializeComponent();
            vm = new FlightBoardViewModel(FlightManagerModel.Instance);
            this.DataContext = vm;
            isFirst = true;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            planeLocations = new ObservableDataSource<Point>();
            // Set identity mapping of point in collection to point on plot
            planeLocations.SetXYMapping(p => p);

            plotter.AddLineGraph(planeLocations, 2, "Route");

            vm.PropertyChanged += Vm_PropertyChanged;
        }

        private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (isFirst)
            {
                isFirst = false;
            }
            else{
                if(e.PropertyName.Equals("Lat") || e.PropertyName.Equals("Lon"))
                {
                    Point p1 = new Point(vm.Lat, vm.Lon);
                    planeLocations.AppendAsync(Dispatcher, p1);
                    isFirst = true;
                }
            }
        }
    }

}

