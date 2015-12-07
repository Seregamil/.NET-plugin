using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp
{
    class help
    {
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
