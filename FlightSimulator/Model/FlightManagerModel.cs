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
        bool isConnectedToCommand;


        #region Singleton
        private FlightManagerModel()
        {
            this.clientHandler = new ClientHandlerFilghtParser();
            this.shouldStop = false;
            this.client = new Client();
            this.isConnectedToCommand = false;
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
        /**
         *  all notifies will be sent to the ViewModel beacuase the view model is the observer so it can check which property changed
         *  and find 
         */ 
        private double lat;
        public double Lat
        {
            get { return lat; }
            set            {
                if (lat!= value)                {
                    lat = value;
                    NotifyPropertyChanged("Lat");
                }             
            }
        }
        private double lon;
        public double Lon
        {
            get { return lon; }
            set {
                
                if (lon != value) {
                    lon = value;
                    NotifyPropertyChanged("Lon");
                }
            }
        }
       
        private double elevator;
        public double Elevator
        {
            get { return elevator; }
            set  {
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

        
        #endregion

        public void connect(string ip, int port)
        {
            isConnectedToCommand = client.connect(ip, port); ;
        }

        public void disconnectClient()
        {
            client.disconnect();       
        }

        public void stopListening()
        {
            if (shouldStop == true)
            {
                shouldStop = false;
                tcpClient.Close();
                listener.Stop();
                disconnectClient();
                isConnectedToCommand = false;
            }
        }

        public void start(string ip, int port)
        {
            iPEndPoin = new IPEndPoint(IPAddress.Parse(ip), port);
            listener = new TcpListener(iPEndPoin);
            listener.Start();
            //Console.WriteLine("waiting for connection...");
            tcpClient = listener.AcceptTcpClient();
            shouldStop = true;
            //Console.WriteLine("Connected");
            //new thread to get the values of each property needed. uses the client handler.
            Thread thread = new Thread(() =>
            {
                using (NetworkStream stream = tcpClient.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    //NEED SLEEP HERE?
                    //Thread.Sleep(30000);
                    while (shouldStop)
                    {
                        try
                        {
                            string commandLine = reader.ReadLine();
                            //Console.WriteLine(commandLine);
                            Lat = clientHandler.handleClient(commandLine, Constants.LAT_INDEX);
                            Lon = clientHandler.handleClient(commandLine, Constants.LON_INDEX);
                            //Throttle = clientHandler.handleClient(commandLine, Constants.THROTTLE_INDEX);
                            Elevator = clientHandler.handleClient(commandLine, Constants.ELEVATOR_INDEX);
                            Aileron = clientHandler.handleClient(commandLine, Constants.AILERON_INDEX);
                            //Rudder = clientHandler.handleClient(commandLine, Constants.RUDDER_INDEX);
                            //DO NOT WRITE SLEEP;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Connection error: check Filght Gear connection");
                            stopListening();
                        }

                    }
                }
            });
            thread.Start();
        }

        //writing to FS through the client class.
        public void write(string command)
        {
            if (isConnectedToCommand)
            {
                client.write(command);
            }
            else
            {
                Console.WriteLine("Connection error:  check Filght Gear connection");
            }

        }
         ~FlightManagerModel()
        {
            stopListening();
        }
    }

}

