using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Extensions;
using Owin;
using SpaApp;

[assembly: OwinStartup(typeof(Startup))]
namespace SpaApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            
            ConfigureWebApi(app, config);
            ConfigureSignalR(app);
            ConfigureFileServer(app);

            ConfigureContainer(app, config);

            app.UseWebApi(config);

            app.UseStageMarker(PipelineStage.MapHandler);
        }
    }
}
