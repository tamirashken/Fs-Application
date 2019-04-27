using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    public class AutoPilotViewModel : BaseNotify
    {
        FlightManagerModel flightManagerModel;
        public AutoPilotViewModel(FlightManagerModel flightManagerModel)
        {
            this.flightManagerModel = flightManagerModel;
        }
        //properties
        public bool IsTextBoxEmpty
        {
            get;
            
        }
    }
}
