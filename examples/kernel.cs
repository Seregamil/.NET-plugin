using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace c_sharp
{
    public class kernel
    {
        public static cpp.dotnetMethod[] METHOD_ID = {
                                        createSocketServer,
                                        sendData
                                     };

        public static TcpListener _server;
        public static TcpClient[] clients = new TcpClient[macro.MAX_PLAYERS];
        public static bool _isEnabled = false;

        public static bool createSocketServer(params object[] args)
        {
            for (int j = 0; j != macro.MAX_PLAYERS; j ++ ) clients[j] = null; // clear data

            int MAX_CONNECTIONS = Convert.ToInt32(args[0]);
            int port = Convert.ToInt32(args[1]);

            new Thread(Server).Start(port); //create new thread for server           
            return true;
        }

        public static void Server(object port) // initializate new server
        {
            _server = new TcpListener(IPAddress.Any, Convert.ToInt32(port)); // create tcplistener in localhost
            _server.Start(); // start listening

            _isEnabled = true;

            new Thread(loopClients).Start(); // create new thread for loop users
        }

        public static void loopClients()
        {
            while (true)
            {
                if (_isEnabled)
                {
                    TcpClient newClient = _server.AcceptTcpClient();

                    Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                    t.Start(newClient);
                }
            }
        }

        public static void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;

            int clientNumber = 0;

            for (; clientNumber != macro.MAX_PLAYERS; clientNumber++)
            {
                if (clients[clientNumber] == null)
                    break;
            }

            clients[clientNumber] = client;

            int id = Convert.ToInt32(clientNumber.ToString());
            cpp.callRemoteCallback("onSocketRemoteConnect", id);
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.GetEncoding("windows-1251"));
            try
            {
                while (true)
                {
                    if (!client.Connected) break;
                    cpp.callRemoteCallback("onSocketReceiveData", id, sReader.ReadLine());
                }
            }
            catch
            {
                clients[clientNumber] = null;
                cpp.callRemoteCallback("onSocketRemoteDisconnect", id);
            }
        }

        public static bool sendData(params object[] args)
        {
            TcpClient client = clients[Convert.ToInt32(args[0])]; //(TcpClient)args[0];
            string data = args[1].ToString();

            if (client.Connected == false)
                return true;

            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.GetEncoding("windows-1251"));
            sWriter.WriteLine(data);
            return true;
        }
    }
}