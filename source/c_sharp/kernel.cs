﻿//using Mono;

namespace c_sharp
{
    public class kernel
    {
        public static object onDotnetLoaded(params object[] args)
        {
            cpp.logwrite("dotnet-> onDotnetLoaded was called. ARGS:");
            foreach (object arg in args)
            {
                cpp.logwrite(arg.ToString());
            }

            cpp.callRemoteCallback("onDotnetWasLoaded", "Hello! =)");
            return true;
        }

        public static object testINT(params object[] args)
        {
            cpp.logwrite("dotnet-> testINT was called");

			int a = (int)args[0];
			int b = (int)args[1];
            return a + b ;
        }

        public static object testBOOL(params object[] args)
        {
            cpp.logwrite("dotnet-> testBOOL was called.");
            return false;
        }

        public static object testSTRING(params object[] args)
        {
            cpp.logwrite("dotnet-> testSTRING was called." );

            foreach (object arg in args)
            {
                cpp.logwrite(string.Format("{0}: {1}",arg.GetType(), arg.ToString()));
            }

            return "blackJack prod.";
        }

        public static object testFLOAT(params object[] args)
        {
            cpp.logwrite("dotnet-> testFLOAT was called. ARGS:");
            float result = 13.228f;
            return result;
        }
    }
}