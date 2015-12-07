using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace c_sharp
{
    public class cpp
    {
        public interface plugin
        {
            bool Initializate();
            bool callDotnetMethod(int methodID, string arguments);
        };

        public struct SERVER_CONFIG
        { // data from server.cfg
            public static int MAX_PLAYERS;
            public static int PORT;
            public static string HOSTNAME;
            public static string WEBURL;
        }

        public class pluginClass : plugin
        {
            public bool Initializate()
            {
                server.loadConfiguration("server.cfg"); // load configuration
                server.logwrite(string.Format("\n    C#:\n    dotnet library was initializated.\n\tMAX_PLAYERS: {0}\n\tHOSTNAME: {1}\n\tPORT: {2}\n\tWEBURL: {3}\n\n\t\t(c) Seregamil\n", SERVER_CONFIG.MAX_PLAYERS, SERVER_CONFIG.HOSTNAME, SERVER_CONFIG.PORT, SERVER_CONFIG.WEBURL));
                return true ;
            }

            public bool callDotnetMethod(int methodID, string arguments)
            {
                return callback.callDotnetMethod(methodID, help.getArgsFromString(arguments, '\n'));
            }
        }
    }
}