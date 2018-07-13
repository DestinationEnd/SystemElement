using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SystemElement.Models
{
    public class UrlConstraint : IRouteConstraint
    {
        private IElementRepository elementRepository;

        public UrlConstraint()
        {
            elementRepository = DependencyResolver.Current.GetService<IElementRepository>();
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values[parameterName] != null)
            {
                string permalink = values[parameterName].ToString();
                permalink = @"\" + permalink;
                if (elementRepository.findParentElementByPermalink(permalink) != null)
                {
                    return true;
                }

            }
            return false;
            //throw new HttpException(404, "NotFound");
        }
    }
}