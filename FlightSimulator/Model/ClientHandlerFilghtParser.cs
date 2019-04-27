using System;

namespace FlightSimulator.Model
{
    /*
     * this class will parse the data of the flight simulator by ',' and returns an array of values. 
     */
    class ClientHandlerFilghtParser : ClientHandler
    {
        public double handleClient(string data, int index)
        {
          
                string[] dataArray = data.Split(',');
                return Double.Parse(dataArray[index]);
        }
    }
}
