using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    //interface to handle variety of clients
    interface ClientHandler
    {
        double handleClient(string data, int index);
    }
}
