﻿using System;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;

namespace SimpleForum.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "MyRoute",
                routeTemplate: "api/threads/{id}/posts",
                defaults: new { controller = "posts", method = "GET", action = "GetByThreadId", id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}