﻿using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Reflection;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace TeleBreadService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
#if DEBUG
            Service1 myService = new Service1();
            myService.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }
#else
            if (Environment.UserInteractive)
            {
                string parameter = String.Concat(args);
                switch (parameter)
                {
                    case "--install":
                        ManagedInstallerClass.InstallHelper(new[] {Assembly.GetExecutingAssembly().Location});
                        break;
                    case "--uninstall":
                        ManagedInstallerClass.InstallHelper(new[] {Assembly.GetExecutingAssembly().Location});
                        break;
                }
            }
            else
            {

                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new Service1()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
#endif
    }
}
