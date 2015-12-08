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
                                        onDotnetLoaded,
                                        onPlayerConnect,
                                        onPlayerDisconnect
                                     };
        public static bool onDotnetLoaded(object[] args)
        {
            return true;
        }

        public static bool onPlayerConnect(object[] args)
        {
            return true;
        }

        public static bool onPlayerDisconnect(object[] args)
        {
            return true;
        }
    }
}