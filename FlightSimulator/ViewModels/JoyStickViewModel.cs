using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class JoyStickViewModel : BaseNotify
    {
        private FlightManagerModel flightManagerModel;

        public JoyStickViewModel(FlightManagerModel fmd)
        {
            this.flightManagerModel = fmd;
            flightManagerModel.PropertyChanged +=
                delegate (object sender, PropertyChangedEventArgs e) 
                { NotifyPropertyChanged("VM_" + e.PropertyName);
                };
        }

        private double aileron;
        public double VM_Aileron
        {
            get { return aileron; }
            set
            {
                aileron = value;
                //this.flightManagerModel.write();
                //NotifyPropertyChanged("VM_Aileron");
                /*if (aileron != value)
                {
                    aileron = value;
                    
                }*/

                //
            }
        }

        private double throttle;
        public double VM_Throttle
        {
            get { return throttle; }
            set
            {
                throttle = value;
                //NotifyPropertyChanged("VM_Throttle");
                //this.flightManagerModel.write();
            }

        }

        private double rudder;
        public double VM_Rudder
        {
            get { return rudder; }
            set
            {
                rudder = value;
                //NotifyPropertyChanged("VM_Rudder");
                //this.flightManagerModel.write();
            }
        }

        private double elevator;

        public double VM_Elevator
        {
            get { return elevator; }
            set
            {
                elevator = value;
                //NotifyPropertyChanged("VM_Elevator");
                //this.flightManagerModel.write();
            }
        }
    }
}
