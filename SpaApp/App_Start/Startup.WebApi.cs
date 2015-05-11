using System.Web.Http;
using Owin;

namespace SpaApp
{
    public partial class Startup
    {
        public static void ConfigureWebApi(IAppBuilder app, HttpConfiguration config)
        {
            // Configure Web API Routes:
            // - Enable Attribute Mapping
            // - Enable Default routes at /api.
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}