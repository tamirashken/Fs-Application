
using FlightSimulator.Model;
using System.ComponentModel;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private FlightManagerModel flightManagerModel;

        public FlightBoardViewModel(FlightManagerModel fmd)
        {
            this.flightManagerModel = fmd;
            flightManagerModel.PropertyChanged +=
                delegate (object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged(e.PropertyName);
                };

        }

        public double Lon
        {
            get { return flightManagerModel.Lon; }
        }

        public double Lat
        {
            get { return flightManagerModel.Lat; }
        }

    }
}
