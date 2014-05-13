using System;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace SystemMonitorService
{
    public class SystemMonitorHost
    {
        private static IDisposable server;

        public void OnStart()
        {
            server = WebApp.Start<Startup>("http://*:7777");

            // TODO: Exception handling
            Task.Factory.StartNew(() => new PerformanceDataProvider());
        }

        public void OnStop()
        {
            if (server != null)
            {
                server.Dispose();
            }
        }
    }
}
