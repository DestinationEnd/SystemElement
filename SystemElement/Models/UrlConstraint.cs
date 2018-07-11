using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace SystemElement.Models
{
    public class UrlConstraint : IRouteConstraint
    {
        private IElementRepository elementRepository;
        public UrlConstraint(IElementRepository repository)
        {
            elementRepository = repository;
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values[parameterName] != null)
            {
                var permalink = values[parameterName].ToString();
                if (elementRepository.findParentElementByPermalink(permalink) != null)
                {
                    return true;
                }
                else
                {
                    if (permalink.IndexOf('/') != -1)
                    {
                        string[] arrayParams = permalink.Split('/');
                        int counterTrueElements = 0;
                        foreach (string param in arrayParams)
                        {
                            if (elementRepository.findParentElementByPermalink(permalink) != null)
                            {
                                counterTrueElements++;
                            }
                        }
                        return counterTrueElements == arrayParams.Length;
                    }
                }
            }
            return false;
        }
    }
}