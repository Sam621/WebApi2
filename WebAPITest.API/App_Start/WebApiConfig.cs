using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using WebApiContrib.Filters;
using System.Configuration;
using System.Web.Http.Dispatcher;
using WebApiContrib.Formatting.Jsonp;
using CacheCow.Server.EntityTagStore.SqlServer;
using CacheCow.Server;
using WebAPITest.API.Services;
using WebAPITest.API.Converters;

namespace WebAPITest.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
            name: "Student",
            routeTemplate: "api/school/Student/{id}",
            defaults: new { controller = "Student", id = RouteParameter.Optional }
            );

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.Converters.Add(new LinkModelConverter());
            CreateMediaTypes(jsonFormatter);


            // support jsonp
            var formatter = new JsonpMediaTypeFormatter(jsonFormatter, "cb");
            config.Formatters.Insert(0, formatter);

            // Replace the Controller Configuration
            config.Services.Replace(typeof(IHttpControllerSelector),
              new SchoolControllerSelector(config));

            // Configure Caching support etag           
            var cacheHandler = new CachingHandler(config);
            config.MessageHandlers.Add(cacheHandler);

            // Add support CORS
           // var attr = new EnableCorsAttribute("*", "*", "GET");
           // config.EnableCors(attr);

        }


        static void CreateMediaTypes(JsonMediaTypeFormatter jsonFormatter)
        {
            var mediaTypes = new string[]
            {
                "application/vnd.countingks.food.v1+json",
                "application/vnd.countingks.measure.v1+json",
                "application/vnd.countingks.measure.v2+json",
                "application/vnd.countingks.diary.v1+json",
                "application/vnd.countingks.diaryEntry.v1+json",
            };

            foreach (var mediaType in mediaTypes)
            {
                jsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue(mediaType));
            }

        }
    }
}

