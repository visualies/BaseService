using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Globalization;

namespace BattlepassService.Api.Routing.Constraints
{
    public class UlongRouteConstraint : IRouteConstraint
    {
        //https://stackoverflow.com/questions/62211646/ready-to-use-uint-route-constraint

        public static readonly string Name = "ulong";
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (routeKey == null)
                throw new ArgumentNullException(nameof(routeKey));

            if (values == null)
                throw new ArgumentNullException(nameof(values));

            if (values.TryGetValue(routeKey, out object routeValue) && routeValue != null)
            {
                if (routeValue is ulong)
                    return true;

                string valueString = Convert.ToString(routeValue, CultureInfo.InvariantCulture);

                return ulong.TryParse(valueString, out ulong _);
            }

            return false;
        }
    }
}
