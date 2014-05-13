using System;
using System.Diagnostics;
using Topshelf;

namespace SystemMonitorService
{
    class Program
    {
        private static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<SystemMonitorHost>(s =>
                {
                    s.ConstructUsing(name => new SystemMonitorHost());
                    s.WhenStarted(tc => tc.OnStart());
                    s.WhenStopped(tc => tc.OnStop());
                });
                x.RunAsNetworkService();
                
                x.SetDescription("Thinktecture System Monitoring Server");
                x.SetDisplayName("System Monitoring Server");
                x.SetServiceName("SystemMonitoringServer");

                Process.Start("https://localhost:7778/app");
            });
        }
    }
}
