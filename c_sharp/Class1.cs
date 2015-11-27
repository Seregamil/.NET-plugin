using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace c_sharp
{
    public class Class1
    {
        [DllImport("S:\\gta-o\\plugins\\dotnet.dll")]
        static extern void logwrite(string message);

        [DllImport("S:\\gta-o\\plugins\\dotnet.dll", CallingConvention = CallingConvention.StdCall)]
        static extern void callPublic(string functionName, String[] args, int length);

        public interface plugin
        {
            void Initializate();
        };

        public class pluginClass : plugin
        {
            public void Initializate()
            {
                callFunction("onDotnetLoaded", 10, 15, 76.53, true, 3.53, "kekyshka"); // playerid, cost, message
                callFunction("dotnet_test", 42, 75, 5454);
                callFunction("OnPlayerConnect", 15);
            }

            public void callFunction(string callback, params object[] args )
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
                callPublic(callback, array.ToArray(), array.Count);   
            }
        }
    }
}