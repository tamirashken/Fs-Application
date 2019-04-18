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
                    Console.WriteLine("viewModel: " + e.PropertyName);
                    if (e.PropertyName == "Throttle")
                    {
                        VM_Throttle = flightManagerModel.Throttle;
                        
                    }
                   
                    else if (e.PropertyName == "Aileron")
                    {
                      
                       VM_Aileron = flightManagerModel.Aileron;

                    }
                    else if (e.PropertyName == "Rudder")
                    {
                        
                        VM_Rudder = flightManagerModel.Rudder;

                    }
                    else if (e.PropertyName == "Elevator")
                    {
                        
                        VM_Elevator = flightManagerModel.Elevator;
                    }
                    
                    
                    //NotifyPropertyChanged("VM_" + e.PropertyName);
                };
        }

        private void setMapOfPaths()
        {
            this.varToPath.Add("Throttle", "/controls/engines/current-engine/throttle ");
        }

        private string commandGenerator(string nameOfVar, double value)
        {
            string set = "set " + this.varToPath[nameOfVar];
            set += value.ToString("0.##");
            set += "\r\n";
            return set;
        }

        private double aileron;
        public double VM_Aileron
        {
            get
            {
                Console.WriteLine("in vm: " + this.flightManagerModel.Aileron);
                return this.flightManagerModel.Aileron;
            }
            set
            {
                Console.WriteLine("set in vm aileron: " + value);
                aileron = value;
                //this.flightManagerModel.write();

                if (aileron != value)
                {
                    
                    //NotifyPropertyChanged("VM_Aileron");
                }

                //
            }
        }

        private double elevator;
        public double VM_Elevator
        {
            get
            {
                Console.WriteLine("in vm get the elevator: " + this.flightManagerModel.Elevator);
                return this.flightManagerModel.Elevator; }
            set
            {
                Console.WriteLine("set in vm elevator: " + value);
                elevator = value;
                /*if (elevator != value)
                {
                    elevator = value;
                    NotifyPropertyChanged("VM_Elevator");
                }*/
                //this.flightManagerModel.write();
            }
        }

        private double throttle;
        public double VM_Throttle
        {
            get { return (this.flightManagerModel.Throttle); }
            set
            {

                //NotifyPropertyChanged("VM_Throttle");
                if (throttle != value)
                {
                    throttle = value;
                    //this.flightManagerModel.write(commandGenerator("Throttle", value));
                   
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
                    //NotifyPropertyChanged("VM_Rudder");
                }
                //this.flightManagerModel.write();
            }
        }

        
    }
}
