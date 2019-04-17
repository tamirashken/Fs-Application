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
                    if (e.PropertyName == "Lon")
                    {
                        //Lon = flightManagerModel.Throttle;
                        Console.WriteLine("Flight board vm " + e.PropertyName);
                    }

                    else if (e.PropertyName == "Lat")
                    {
                        Console.WriteLine("Flight board vm " + e.PropertyName);
                        //Lat = flightManagerModel.Aileron;

                    }
                };

        }

        public double Lon
        {
            get;
        }

        public double Lat
        {
            get;
        }

    }
}
