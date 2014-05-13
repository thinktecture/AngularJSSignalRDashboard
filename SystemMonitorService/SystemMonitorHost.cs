using System;
using Microsoft.Owin.Hosting;

namespace SystemMonitorService
{
    public class SystemMonitorHost
    {
        private static IDisposable server;

        public void OnStart()
        {
            server = WebApp.Start<Startup>("http://localhost:7777");
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
