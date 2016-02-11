using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace c_sharp
{
    public class regex
    {
        //regex.Match( string, pattern ) 
        public static object Match(params object[] args)
        {
            string str = args[0].ToString();
            string pattern = args[1].ToString();
            return new Regex(pattern).Match(str).Index;
        }

        //regex.IsMatch( string, pattern )
        public static object IsMatch(params object[] args)
        {
            string str = args[0].ToString();
            string pattern = args[1].ToString();

            return new Regex(pattern).IsMatch(str);
        }

        //regex.Replace( string, replacement, pattern )
        public static object Replace(params object[] args)
        {
            string str = args[0].ToString();
            string replacement = args[1].ToString();
            string pattern = args[2].ToString();

            return new Regex(pattern).Replace(str, replacement);
        }
    }
}
