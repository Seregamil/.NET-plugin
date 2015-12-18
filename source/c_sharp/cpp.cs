using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace c_sharp
{
    public class cpp
    {
        public delegate object dotnetMethod(params object[] args);
        public interface plugin
        {
            object callDotnetMethod(int methodID, string arguments);
        };

        public class pluginClass : plugin
        { 
            public object callDotnetMethod(int methodID, string arguments)
            {
                return kernel.METHOD_ID[methodID](getArgsFromString(arguments, '\n'));
            }
        }

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

        public static object[] getArgsFromString(string dest, char split = '\n')
        {
            string[] values = dest.Split(split);
            object[] args = new object[values.Length];

            for (int j = 0; j != values.Length; j++)
            {
                char key = values[j][0]; // get char
                values[j] = values[j].Remove(0, 1); // delete
                switch (key)
                {
                    case 'i':
                        {
                            int i = Convert.ToInt32(values[j]);
                            args[j] = i;
                            break;
                        }
                    case 'c':
                        {
                            char[] c = values[j].ToCharArray();
                            args[j] = c[0];
                            break;
                        }
                    case 's':
                        {
                            args[j] = values[j];
                            break;
                        }
                    case 'f':
                        {
                            float f = Convert.ToSingle(values[j].Replace('.', ','));
                            args[j] = f;
                            break;
                        }
                }
            }
            return args;
        }
    }
}
