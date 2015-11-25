using System;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;

namespace TeleimotBg.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "UserRoute",
                routeTemplate: "api/users/{username}",
                defaults: new { controller = "users", method = "GET", action = "GetByUsername", username = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "CustomRouteApi",
                routeTemplate: "api/comments/ByUser/{username}",
                defaults: new {controller = "comments", method = "GET", action = "GetByUsername", username = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}