using BLL.AuthService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SwiftSaleEcommerce.Auth
{
    public class AdminAccess: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization;
            if (token == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { mgs = "No Token Supplied" });
            }
            else if (!AuthService.IsTokenValid(token.ToString()))
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { mgs = "Supplied token is invalid or expired" });
            }
            else if (!AuthService.AdminAccess(token.ToString()))
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { mgs = "You are not authorized to access this resource" });
            }
            else
            {
                base.OnAuthorization(actionContext);
            }
        }
    }
}