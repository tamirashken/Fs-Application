
namespace FlightSimulator.Model
{
    //interface to handle variety of clients
    interface ClientHandler
    {
        double handleClient(string data, int index);
    }
}
