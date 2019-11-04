using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;
class Launcher
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length != 0)
            {
                string relativeExePath = args[2];
                string path = Assembly.GetExecutingAssembly().Location;
                string directory = Path.GetDirectoryName(path);
                string upperDirectory = directory.Substring(0, directory.LastIndexOf(@"\"));
                string launchPath = upperDirectory + "\\" + relativeExePath;
                Process.Start(launchPath);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }

    }
}