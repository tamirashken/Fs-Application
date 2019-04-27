
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
