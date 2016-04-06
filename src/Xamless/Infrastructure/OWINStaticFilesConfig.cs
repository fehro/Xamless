using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace Xamless.Infrastructure
{
    public class OwinStaticFilesConfig
    {
        public void Configuration(IAppBuilder app)
        {
            const string rootFolder = "./wwwroot";
            var fileSystem = new PhysicalFileSystem(rootFolder);
            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = fileSystem
            };

            app.UseFileServer(options);
        }
    }
}
