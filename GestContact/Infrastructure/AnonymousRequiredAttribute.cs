﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GestContact.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AnonymousRequiredAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return SessionManager.User is null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {            
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Index", controller = "Contact" }));
        }
    }
}