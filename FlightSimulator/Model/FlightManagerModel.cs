using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using FlightSimulator.ViewModels;

static class Constants
{
    public const int LON_INDEX = 0;
    public const int LAT_INDEX = 1;
    public const int THROTTLE_INDEX = 23;
    public const int AILERON_INDEX = 19;
    public const int ELEVATOR_INDEX = 20;
    public const int RUDDER_INDEX = 21;
}

namespace FlightSimulator.Model
{
   
    //should be singletone
    public class FlightManagerModel : BaseNotify
    {
        ClientHandler clientHandler;
        TcpListener listener;
        TcpClient tcpClient;
        IPEndPoint iPEndPoin;
        bool shouldStop;
        Client client;


        #region Singleton
        private FlightManagerModel()
        {
            this.clientHandler = new ClientHandlerFilghtParser();
            this.shouldStop = true;
            this.client = new Client();  
        }
        private static FlightManagerModel m_Instance = null;

        public static FlightManagerModel Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new FlightManagerModel();
                }
                return m_Instance;
            }
        }
        #endregion
        #region Properties
        private double lat;
        public double Lat
        {
            get { return lat; }
            set
            {
                if (lat != value)
                {
                    lat = value;
                    NotifyPropertyChanged("Lat");
                }
                
                
            }
        }
        private double lon;
        public double Lon
        {
            get { return lon; }
            set
            {
                if (lon != value)
                {
                    lon = value;
                    NotifyPropertyChanged("Lon");
                }
                
            }
        }
        private double throttle;
        public double Throttle
        {
            get { return throttle; }
            set
            {
                if (throttle != value)
                {
                    throttle = value;
                    NotifyPropertyChanged("Throttle");
                }
               
            }
        }
        private double elevator;
        public double Elevator
        {
            get { return elevator; }
            set
            {
                if (elevator != value)
                {
                    elevator = value;
                    NotifyPropertyChanged("Elevator");
                }
                    
            }
        }
        private double aileron;
        public double Aileron
        {
            get { return aileron; }
            set
            {
                if (aileron != value)
                {
                    aileron = value;
                    NotifyPropertyChanged("Aileron");
                }
                    
            }
        }

        private double rudder;
        public double Rudder
        {
            get { return rudder; }
            set
            {
                if (rudder != value)
                {
                    rudder = value;
                    NotifyPropertyChanged("Rudder");
                }
                    
            }
        }
        #endregion

        public void connect(string ip, int port)
        {
            client.connect(ip, port);
        }

        public void disconnectClient()
        {
            client.disconnect();
        }

        public void stopListening()
        {
            shouldStop = false;
            tcpClient.Close();
            listener.Stop();
        }

        public void start(string ip, int port)
        {
            iPEndPoin = new IPEndPoint(IPAddress.Parse(ip), port);
            listener = new TcpListener(iPEndPoin);
            listener.Start();
            Console.WriteLine("waiting for connection...");
            tcpClient = listener.AcceptTcpClient();
            Console.WriteLine("Connected");
            Thread thread = new Thread(() =>
            {
                using (NetworkStream stream = tcpClient.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    Thread.Sleep(30000);
                    while (shouldStop)
                    {
                        var data = reader.ReadLine();
                        Lat = clientHandler.handleClient(data, Constants.LAT_INDEX);
                        Lon = clientHandler.handleClient(data, Constants.LON_INDEX);
                        Throttle = clientHandler.handleClient(data, Constants.THROTTLE_INDEX);
                        Elevator = clientHandler.handleClient(data, Constants.ELEVATOR_INDEX);
                        Aileron = clientHandler.handleClient(data, Constants.AILERON_INDEX);
                        Rudder = clientHandler.handleClient(data, Constants.RUDDER_INDEX);
                    }
                }
            });
            thread.Start();
        }

        public void write()
        {

        }
    }
    

}

