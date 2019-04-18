using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using System.Windows.Input;
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
