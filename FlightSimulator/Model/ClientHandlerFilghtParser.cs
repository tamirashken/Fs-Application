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
            double value;
            try
            {
                string[] dataArray = data.Split(',');
                value = Double.Parse(dataArray[index]);
            }
            catch (Exception)
            {
             
                return 0;
            }
            return 0;
        }
    }
}
