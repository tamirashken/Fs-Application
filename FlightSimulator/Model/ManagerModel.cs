using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlightSimulator.ViewModels

namespace FlightSimulator.Model
{
    interface ManagerModel : Base
    {
   
        void connect(string ip, int port);
        void disconnectClient();
        void stopListening();
        void start(string ip, int port);

        double Lat { set; get; }
        double Lon { set; get; }
        double Throttle { set; get; }
        double Elevator { set; get; }
        double Aileron { set; get; }
        double Rudder { set; get; }
    }
}
