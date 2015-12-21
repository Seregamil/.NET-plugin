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
        public static object createFile(object[] args)
        {
            try
            {
                File.Create(args[0].ToString());
            }
            catch
            {
                return (object)false;
            }
            return (object)true;
        }

        public static object deleteFile(object[] args)
        {
            try
            {
                File.Delete(args[0].ToString());
            }
            catch
            {
                return (object)false;
            }
            return (object)true;
        }

        public static object renameFile(object[] args)
        {
            try
            {
                File.Move(args[0].ToString(), args[1].ToString());
            }
            catch
            {
                return (object)false;
            }
            return (object)true;
        }

        public static object existFile(object[] args)
        {
            return (object)File.Exists(args[0].ToString());
        }

        public static object createDir(object[] args)
        {
            try
            {
                Directory.CreateDirectory(args[0].ToString());
            }
            catch
            {
                return (object)false;
            }
            return (object)true;
        }

        public static object deleteDir(object[] args)
        {
            try
            {
                Directory.Delete(args[0].ToString());
            }
            catch
            {
                return (object)false;
            }
            return (object)true;
        }

        public static object renameDir(object[] args)
        {
            try
            {
                Directory.Move(args[0].ToString(), args[1].ToString());
            }
            catch
            {
                return (object)false;
            }
            return (object)true;
        }

        public static object existDir(object[] args)
        {
            return (object)Directory.Exists(args[0].ToString());
        }
    }
}