using System;
using System.Dynamic;
using System.Collections.Generic;

namespace AWSNetCore
{

    public static class SillyRouteMap
    {
        private static List<SillyRoute> Routes = new List<SillyRoute>();

        public static int RouteCount()
        {
            return(Routes.Count);
        }

        public static bool MapRoute(string name, string urlPattern, SillyRouteDetails settings, out string reason)
        {
            reason = string.Empty;

            if (String.IsNullOrEmpty(urlPattern) || !SillyRoute.IsValidUrlPattern(urlPattern))
            {
                reason = "URL pattern is invalid, cannot create route";

                return(false);
            }

            if (String.IsNullOrEmpty(name))
            {
                reason = "Using 'default' for route's name";
                
                name = "default";
            }

            SillyRoute route = new SillyRoute(name, urlPattern);

            Routes.Add(route);

            return(true);
        }        
    }
}