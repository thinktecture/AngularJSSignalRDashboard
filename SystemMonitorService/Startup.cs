using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace SystemMonitorService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var clientOptions = new FileServerOptions
            {
                RequestPath = new PathString(""),
                FileSystem = new PhysicalFileSystem("app"),
                EnableDefaultFiles = true
            };
            clientOptions.DefaultFilesOptions.DefaultFileNames.Add("index.html");
            clientOptions.StaticFileOptions.ServeUnknownFileTypes = true;

            app.UseFileServer(clientOptions);

            app.MapSignalR();
        }
    }
}