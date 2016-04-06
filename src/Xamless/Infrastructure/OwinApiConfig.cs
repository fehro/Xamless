using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using System.Web.Http;
using Microsoft.Owin;

namespace Xamless.Infrastructure
{
    public class OwinApiConfig
    {
        public void Configuration(IAppBuilder app)
        {
            //Configure the static files.
            const string rootFolder = "./wwwroot";
            var fileSystem = new PhysicalFileSystem(rootFolder);
            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = fileSystem
            };
            app.UseFileServer(options);

            //Configure Web API. 
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApi", 
                "api/{controller}/{id}", 
                new { id = RouteParameter.Optional }
            );
            app.UseWebApi(config);
        }
    }
}
