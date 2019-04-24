using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ClientHandlerFilghtParser : ClientHandler
    {
        public double handleClient(string data, int index)
        {
          
                string[] dataArray = data.Split(',');
                return Double.Parse(dataArray[index]);
        }
    }
}
