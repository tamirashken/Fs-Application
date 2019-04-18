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
        private Dictionary<string, string> varToPath = new Dictionary<string, string>();
        public JoyStickViewModel(FlightManagerModel fmd)
        {
            this.setMapOfPaths();
            this.flightManagerModel = fmd;
            flightManagerModel.PropertyChanged +=
                delegate (object sender, PropertyChangedEventArgs e) 
                {
                    //Console.WriteLine("viewModel: " + e.PropertyName);
                    if (e.PropertyName == "Throttle")
                    {
                        VM_Throttle = flightManagerModel.Throttle;
                    }
                   
                    else if (e.PropertyName == "Aileron")
                    {
                        //Console.WriteLine("viewModel: " + e.PropertyName);
                        VM_Aileron = flightManagerModel.Aileron;

                    }
                    else if (e.PropertyName == "Elevator")
                    {
                        VM_Elevator = flightManagerModel.Elevator;
                    }
                    else if (e.PropertyName == "Rudder")
                    {
                        VM_Rudder = flightManagerModel.Rudder;
                    }
                };
        }

        private void setMapOfPaths()        {
            this.varToPath.Add("Throttle", "/controls/engines/current-engine/throttle ");
        }

        private string commandGenerator(string nameOfVar, double value)        {
            string set = "set " + this.varToPath[nameOfVar];
            set += value.ToString("0.##");
            set += "\r\n";
            return set;
        }

        private double throttle;
        public double VM_Throttle
        {
            get { return (this.flightManagerModel.Throttle); }
            set
            {
                if (throttle != value)
                {
                    throttle = value;
                    NotifyPropertyChanged("VM_Throttle");
                }
            }

        }

        private double rudder;
        public double VM_Rudder
        {
            get { return this.flightManagerModel.Rudder; }
            set
            {
                if (rudder != value)
                {
                    rudder = value;
                    NotifyPropertyChanged("VM_Rudder");
                }
                //this.flightManagerModel.write();
            }
        }

        private double aileron;
        public double VM_Aileron {
            get            {
                return this.flightManagerModel.Aileron;
            }
            set {
                if (aileron != value) {
                    aileron = value;
                    NotifyPropertyChanged("VM_Aileron");
                }
            }
        }

        private double elevator;
        public double VM_Elevator        {
            get            {
                return this.flightManagerModel.Elevator;
            }
            set            {
                if (elevator != value)                { 
                    elevator = value;
                    NotifyPropertyChanged("VM_Elevator");
                }
            }
        }

        

        
    }
}
