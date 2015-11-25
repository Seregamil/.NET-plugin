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

        [DllImport("S:\\gta-o\\plugins\\dotnet.dll")]
        static extern bool callCallback(string functionName, params object[] args);

        public interface plugin
        {
            void Initializate();
        };

        public class pluginClass : plugin
        {
            public void Initializate()
            {
                logwrite("\n\nСашка лалка\n\n");
            }
        }
    }
}

/*[DllImport("S:\\gta-o\\plugins\\dotnet.dll")]
public static extern StringBuilder EI_GetName();*/
/*public interface fileManager
{
    bool fileCreate( string path ) ;
    bool existFile( string path ) ;
    bool removeFile( string path );
    bool renameFile( string old_path , string new_path );

    bool directoryCreate( string path );
    bool existDirectory( string path );
    bool removeDirectory( string path );
    bool renameDirectory( string old_path, string new_path );
};
*/
/*public class ManagedClass : fileManager
{
    public bool fileCreate(string path)
    {
        if (File.Exists(path)) return false;
        try
        {
            File.Create(path + EI_GetName());
        }
        catch
        {
            return false;
        }
        return true ;
    }

    public bool existFile(string path)
    {
        return File.Exists(path);
    }

    public bool removeFile(string path)
    {
        if (!File.Exists(path)) return false;
        try
        {
            File.Delete(path);
        }
        catch
        {
            return false;
        }
        return true;
    }

    public bool renameFile(string old_path, string new_path)
    {
        if (!File.Exists(old_path)) return false;
        if (File.Exists(new_path)) return false;
        try
        {
            File.Move(old_path, new_path);            
        }
        catch
        {
            return false;
        }
        return true;
    }

    public bool directoryCreate(string path)
    {
        if (Directory.Exists(path)) return false;
        try
        {
            Directory.CreateDirectory(path);
        }
        catch
        {
            return false;
        }
        return true;
    }

    public bool existDirectory(string path)
    {
        return Directory.Exists(path);
    }

    public bool removeDirectory(string path)
    {
        if (!Directory.Exists(path)) return false;
        try
        {
            Directory.Delete(path);
        }
        catch
        {
            return false;
        }
        return true;
    }

    public bool renameDirectory(string old_path, string new_path)
    {
        if (!Directory.Exists(old_path)) return false;
        if (Directory.Exists(new_path)) return false;
        try
        {
            Directory.Move(old_path, new_path);
        }
        catch
        {
            return false;
        }
        return true;
    }
}*/