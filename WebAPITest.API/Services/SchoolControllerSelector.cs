using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace WebAPITest.API.Services
{
    public class SchoolControllerSelector: DefaultHttpControllerSelector
    {
        private HttpConfiguration _config;
        public SchoolControllerSelector(HttpConfiguration config)
      : base(config)
        { 
            _config = config;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var controllers = GetControllerMapping();

            var routeData = request.GetRouteData();

            var controllerName = (string)routeData.Values["controller"];

            HttpControllerDescriptor descriptor;

            if (string.IsNullOrWhiteSpace(controllerName))
            {
                return base.SelectController(request);
            }
            else if (controllers.TryGetValue(controllerName, out descriptor))
            {
                             
                var version = GetVersionFromAcceptHeaderVersion(request);

                var newName = string.Concat(controllerName, "V", version);

                HttpControllerDescriptor versionedDescriptor;

                if (controllers.TryGetValue(newName, out versionedDescriptor))
                {
                    return versionedDescriptor;
                }

                return descriptor;
            }

            return null;
        }

      
        private string GetVersionFromAcceptHeaderVersion(HttpRequestMessage request)
        {
            var accept = request.Headers.Accept;

            foreach (var mime in accept)
            {
                if (mime.MediaType == "application/json")
                {
                    var value = mime.Parameters
                                    .Where(v => v.Name.Equals("version", StringComparison.OrdinalIgnoreCase))
                                    .FirstOrDefault();

                    return value.Value;
                }
            }

            return "1";
        }
    }
}