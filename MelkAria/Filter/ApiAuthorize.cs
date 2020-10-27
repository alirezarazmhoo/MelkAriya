using MelkAria.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MelkAria.Filter
{
    public class ApiAuthorize : ActionFilterAttribute
    {
        DataBaseContext db = new DataBaseContext();
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var token = System.Web.HttpContext.Current.Request.Form["apiToken"];
            var data = db.Users.Where(p => p.apiToken == token).FirstOrDefault();
            if(data==null)
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.Unauthorized, // use whatever http status code is appropriate
                    RequestMessage = actionContext.ControllerContext.Request
                };


            }
        }

        
    }
}