using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp
{
    class callback
    {
        delegate bool dotnetMethod(params object[] args);
        static dotnetMethod[] METHOD_ID = {
                                        onPlayerConnect, // 0
                                        onPlayerDisconnect // 1 etc
                                     };

        public static bool callDotnetMethod(int methodIndex, params object[] args)
        {
            return METHOD_ID[methodIndex](args);
        }

        public static bool onPlayerConnect(params object[] args)
        {
            server.logwrite("C#-> onPlayerConnect was called. Params: ");
            for (int j = 0; j != args.Length; j++)
            {
                server.logwrite(args[j].ToString());
            }
            return true;
        }

        public static bool onPlayerDisconnect(params object[] args)
        {
            server.logwrite("C#-> onPlayerDisconnect was called.");
            return true;
        }
    }
}