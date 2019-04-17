using System;
using System.Collections.Generic;
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
        }

        private double aileron;
        public double VM_Aileron
        {
            get { return aileron; }
            set
            {
                VM_Aileron = value;
                NotifyPropertyChanged("VM_Aileron");
                /*if (aileron != value)
                {
                    aileron = value;
                    
                }*/
                
                //this.flightManagerModel.write();
            }
        }

        private double throttle;
        public double VM_Throttle
        {
            get { return throttle; }
            set
            {
                VM_Throttle = value;
                NotifyPropertyChanged("VM_Throttle");
                //this.flightManagerModel.write();
            }

        }

        private double rudder;
        public double VM_Rudder
        {
            get { return rudder; }
            set
            {
                VM_Rudder = value;
                NotifyPropertyChanged("VM_Rudder");
                //this.flightManagerModel.write();
            }
        }

        private double elevator;

        public double VM_Elevator
        {
            get { return elevator; }
            set
            {
                VM_Elevator = value;
                NotifyPropertyChanged("VM_Elevator");
                //this.flightManagerModel.write();
            }
        }
    }
}
