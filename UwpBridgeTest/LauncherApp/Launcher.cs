using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace LauncherApp
{
    class Launcher
    {
        static void Main(string[] args)
        {
            var receiver = new AppService();
            try
            {
                if (args.Length != 0)
                {
                    string relativeExePath = args[2];
                    string path = Assembly.GetExecutingAssembly().Location;
                    string directory = Path.GetDirectoryName(path);

                    string upperDirectory = directory.Substring(0, directory.LastIndexOf(@"\"));
                    string launchPath = upperDirectory + "\\" + relativeExePath;

                    //for (;;)
                    //{
                    //    if (receiver.ReceivedStr != null) 
                    //        break;
                    //}
                    var argumentBuilder = new ArgumentBuilder(relativeExePath, receiver.ReceivedStr);
                    string arguments = argumentBuilder.StrParamaters;
                    Process.Start(launchPath, arguments);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

        }
    }
}