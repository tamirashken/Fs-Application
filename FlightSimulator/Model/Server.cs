using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace FlightSimulator.Model
{
    class Server
    {
        //IPAddress ipAddress;
        IPEndPoint iPEndPoint;
        bool shouldStop;
        //int port;
        ClientHandler clientHandler;
        TcpListener listener;
        TcpClient tcpClient;
        IPEndPoint iPEndPoin;
        //TcpClient clientTcp;
        public Server(ClientHandler clientHandler)
        {
            this.clientHandler = clientHandler;
            this.shouldStop = true;
        }
        public void startListening(string ip, int port)
        {
            this.iPEndPoin = new IPEndPoint(IPAddress.Parse(ip), port);
            this.listener = new TcpListener(iPEndPoint);
            listener.Start();
            Console.WriteLine("waiting for connection...");
            tcpClient = listener.AcceptTcpClient();
            Console.WriteLine("Connected");
            Thread thread = new Thread(() =>
            {
                using (NetworkStream stream = tcpClient.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (shouldStop)
                    {
                        var commandLine = reader.ReadLine();
                        if (!clientHandler.handleClient(commandLine))
                            shouldStop = false;
                    }
                }
            });
            thread.Start();
        }

        public void stopListening()
        {
            shouldStop = false;
            tcpClient.Close();
            listener.Stop();
        }
    }
}
