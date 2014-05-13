using System;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace SystemMonitorService
{
    public class SystemMonitorHost
    {
        private static IDisposable server;
        private PerformanceDataProvider provider;

        public void OnStart()
        {
            server = WebApp.Start<Startup>("https://+:7778");

            // TODO: Exception handling
            Task.Factory.StartNew(() => provider = new PerformanceDataProvider());
        }

        public void OnStop()
        {
            if (provider != null)
            {
                provider.Stop();
            }
            if (server != null)
            {
                server.Dispose();
            }
        }
    }
}
