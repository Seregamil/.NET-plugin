using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace c_sharp
{
    class server
    {
        [DllImport("S:\\gta-o\\plugins\\dotnet.dll")]
        public static extern void logwrite(string message);

        [DllImport("S:\\gta-o\\plugins\\dotnet.dll", CallingConvention = CallingConvention.StdCall)]
        static extern void __callRemoteCallback(string functionName, String[] args, int length);        

        public static void callRemoteCallback(string callback, params object[] args)
        {
            List<string> array = new List<string>();
            for (int j = 0; j != args.Length; j++)
            {
                switch (Type.GetTypeCode(args[j].GetType()))
                {
                    case TypeCode.Int32:
                        {
                            array.Add("i" + args[j].ToString());
                            break;
                        }
                    case TypeCode.String:
                        {
                            array.Add("s" + args[j]);
                            break;
                        }
                    case TypeCode.Boolean:
                        {
                            array.Add("b" + args[j].ToString());
                            break;
                        }
                    case TypeCode.Char:
                        {
                            array.Add("c" + args[j].ToString());
                            break;
                        }
                    case TypeCode.Double:
                        {
                            string temp = args[j].ToString();
                            array.Add("f" + temp.Replace(',', '.'));
                            break;
                        }
                    default:
                        {
                            array.Add("u" + args[j].ToString());
                            break;
                        }
                }
            }
            __callRemoteCallback(callback, array.ToArray(), array.Count);
        }
        public static void loadConfiguration(string configFile)
        {
            string[] lines = File.ReadAllLines(configFile, Encoding.GetEncoding("windows-1251")); // load from file
            for (int j = 1; j != lines.Length; j++)
            {
                if (lines[j].IndexOf("maxplayers") != -1)
                    cpp.SERVER_CONFIG.MAX_PLAYERS = Convert.ToInt32(lines[j].Remove(0, 11));

                if (lines[j].IndexOf("port") != -1)
                    cpp.SERVER_CONFIG.PORT = Convert.ToInt32(lines[j].Remove(0, 5));

                if (lines[j].IndexOf("hostname") != -1)
                    cpp.SERVER_CONFIG.HOSTNAME = lines[j].Remove(0, 9);

                if (lines[j].IndexOf("weburl") != -1)
                    cpp.SERVER_CONFIG.WEBURL = lines[j].Remove(0, 7);
            }
        }
    }
}
