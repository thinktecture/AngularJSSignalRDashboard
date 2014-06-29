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
            var appOptions = new FileServerOptions
            {
                RequestPath = new PathString(""),
                FileSystem = new PhysicalFileSystem(""),
                EnableDefaultFiles = true
            };
            appOptions.DefaultFilesOptions.DefaultFileNames.Add("index.html");
            appOptions.StaticFileOptions.ServeUnknownFileTypes = true;

            app.UseFileServer(appOptions);

            var libsOptions = new FileServerOptions
            {
                RequestPath = new PathString("/libs"),
                FileSystem = new PhysicalFileSystem("libs")
            };
            libsOptions.StaticFileOptions.ServeUnknownFileTypes = true;

            app.UseFileServer(libsOptions);

            app.UseErrorPage();
            app.MapSignalR();
        }
    }
}