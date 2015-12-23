using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace c_sharp
{
    public class regex
    {
        public static object Match(params object[] args)
        {
            string str = args[0].ToString();
            string pattern = args[1].ToString();
            return new Regex(pattern).Match(str).Index;
        }

        public static object Replace(params object[] args)
        {
            string original = args[0].ToString();
            string pattern = args[1].ToString();
            string replacement = args[2].ToString();
            return new Regex(pattern).Replace(original, replacement);
        }
    }
}
