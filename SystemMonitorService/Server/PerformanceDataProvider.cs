using System.Diagnostics;
using System.Globalization;
using System.Threading;
using Microsoft.AspNet.SignalR;

namespace SystemMonitorService
{
    public class PerformanceDataProvider
    {
        private readonly PerformanceCounter processorCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private readonly PerformanceCounter partitionCFreeSpaceCounter = new PerformanceCounter("LogicalDisk", "% Free Space", "C:");

        private Timer taskTimer;
        private IHubContext hub;

        public PerformanceDataProvider()
        {
            hub = GlobalHost.ConnectionManager.GetHubContext<PerformanceDataHub>();
            taskTimer = new Timer(OnTimerElapsed, null, 1000, 1000);
        }

        private void OnTimerElapsed(object sender)
        {
            var cpuValue = processorCounter.NextValue().ToString("0.0", CultureInfo.CreateSpecificCulture("en-US"));
            hub.Clients.All.newCpuValue(new { value = cpuValue });

            var diskValue = partitionCFreeSpaceCounter.NextValue().ToString("0.0", CultureInfo.CreateSpecificCulture("en-US"));
            hub.Clients.All.newDiskValue(new { value = diskValue });
        }

        public void Stop()
        {
            taskTimer.Dispose();
        }
    }
}
