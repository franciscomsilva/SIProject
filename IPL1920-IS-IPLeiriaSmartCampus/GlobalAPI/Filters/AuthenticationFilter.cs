using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net;
using System.Net.Http;
using GlobalAPI.Models;

namespace GlobalAPI.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            IEnumerable<string> values = new List<string>();
            actionContext.Request.Headers.TryGetValues("token", out values);

            // If no API token was provided, return error 401 Unauthorized
            if (values == null)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }

            // Get the token
            string token = values.First();

            // Verify the token
            AuthUser user = AuthUser.GetByToken(token);
            if (user == null)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }

            // Save the user
            actionContext.Request.Properties.Add("user", user);

            // Execute the request
            base.OnActionExecuting(actionContext);
        }
    }
}