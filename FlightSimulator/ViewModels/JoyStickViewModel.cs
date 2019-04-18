using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
                        //VM_Throttle = flightManagerModel.Throttle;
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
                       //VM_Rudder = flightManagerModel.Rudder;
                    }
                };
        }

        private void setMapOfPaths()        {
            this.varToPath.Add("Throttle", "/controls/engines/current-engine/throttle ");
            this.varToPath.Add("Rudder", "/controls/flight/rudder ");
        }

        private string commandGenerator(string nameOfVar, double value)        {
            string set = "set " + this.varToPath[nameOfVar];
            set += value.ToString("0.##");
            set += "\r\n";
            return set;
        }

        #region Properties
        private double throttle;
        public double VM_Throttle
        {
            //get { return (this.flightManagerModel.Throttle); }
            set
            {
                /*if (throttle != value)
                {
                    throttle = value;
                    NotifyPropertyChanged("VM_Throttle");
                    Console.WriteLine("in set throttle");
                }*/
                throttle = value;
                this.flightManagerModel.write(commandGenerator("Throttle",throttle));

            }

        }

        private double rudder;
        public double VM_Rudder
        {
            //get { return this.flightManagerModel.Rudder; }
            set
            {
                /*if (rudder != value)
                {
                    
                    NotifyPropertyChanged("VM_Rudder");
                }*/

                rudder = value;
                this.flightManagerModel.write(commandGenerator("Rudder", rudder));
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
        #endregion

        private string text;
        public string VM_Text
        {
            get { return text; }
            set
            {
                Console.WriteLine("text is: " + value);
                text = value;
            }
        }



        #region Commands
        #region ClickCommand
        private ICommand _OkCommand;
        public ICommand OKCommand
        {
            get
            {
                return _OkCommand ?? (_OkCommand = new CommandHandler(() => OnOk()));
            }
        }
        private void OnOk()
        {
            //get the text. split it by enters
            //change the BackGround to White
            //this.autoPilotTextBox.Background = Brushes.White;

            //ok button sends line after line every 2 seconds, 
            //we dont want to freeze the screen, so i think we should open a new thread that will be resposible on sending commands to the simulator
        }
        #endregion

        #region ClearCommand
        private ICommand _ClearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return _ClearCommand ?? (_ClearCommand = new CommandHandler(() => OnClear()));
            }
        }
        private void OnClear()
        {
            
        }
        #endregion
        #endregion
    }
}

