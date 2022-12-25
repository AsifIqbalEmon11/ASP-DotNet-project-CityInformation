using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using BLL.Service;

namespace CityInformation.Auth
{
    public class ManagerLogged : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authheader = actionContext.Request.Headers.Authorization;
            if(authheader == null)
                if (authheader == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "No token found");
                }
                else
                {
                    if (ManagerAuthService.IsAuthenticated(authheader.ToString()))
                    {
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "The token is expired");
                    }
                }
            base.OnAuthorization(actionContext);
        }

    }
}