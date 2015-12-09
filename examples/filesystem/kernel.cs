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
	                                        createFile,
	                                        deleteFile,
	                                        renameFile,
	                                        existFile,
	
	                                        createDir,
	                                        deleteDir,
	                                        renameDir,
	                                        existDir
                                     };
        public static bool createFile(object[] args)
        {
            try
            {
                File.Create(args[0].ToString());
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool deleteFile(object[] args)
        {
            try
            {
                File.Delete(args[0].ToString());
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool renameFile(object[] args)
        {
            try
            {
                File.Move(args[0].ToString(), args[1].ToString());
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool existFile(object[] args)
        {
            return File.Exists(args[0].ToString());
        }

        public static bool createDir(object[] args)
        {
            try
            {
                Directory.CreateDirectory(args[0].ToString());
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool deleteDir(object[] args)
        {
            try
            {
                Directory.Delete(args[0].ToString());
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool renameDir(object[] args)
        {
            try
            {
                Directory.Move(args[0].ToString(), args[1].ToString());
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool existDir(object[] args)
        {
            return Directory.Exists(args[0].ToString());
        }
    }
}