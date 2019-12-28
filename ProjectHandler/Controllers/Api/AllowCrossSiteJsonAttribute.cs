using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace ProjectHandler.Controllers.Api
{
    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
            {
                actionExecutedContext.Request.Headers.Add("Access-Control-Allow-Headers", "*");
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            }
                


            if (actionExecutedContext.Request != null)
            {
                actionExecutedContext.Request.Headers.Add("Access-Control-Allow-Origin", "http://localhost:4200");
                actionExecutedContext.Request.Headers.Add("Access-Control-Allow-Headers", "*");
                actionExecutedContext.Request.Headers.Add("Access-Control-Allow-Credentials", "true");
            }
            

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}