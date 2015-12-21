using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;

namespace c_sharp
{
    public class cpp
    {
        public interface plugin
        {
            object callDotnetMethod(string methodName, string arguments);
        };

        public class pluginClass : plugin
        {
            public object callDotnetMethod(string methodName, string arguments)
            {
                Type type1 = typeof(kernel);

                if (methodName.IndexOf(".") != -1)
                {
                    string[] temp = methodName.Split('.');
                    type1 = Type.GetType("c_sharp." + temp[0]);
                    methodName = temp[1];
                }

                object[] args = getArgsFromString(arguments, '\n'); // get all arguments
                object obj = Activator.CreateInstance(type1);
                return (object)type1.InvokeMember(methodName, BindingFlags.InvokeMethod, null, obj, args);
            }
        }

        [DllImport("S:\\gta-o\\plugins\\dotnet.dll")]
        public static extern void logwrite(string message);

        [DllImport("S:\\gta-o\\plugins\\dotnet.dll", CallingConvention = CallingConvention.StdCall)]
        static extern void __callRemoteCallback(string functionName, string[] args, int length);

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
