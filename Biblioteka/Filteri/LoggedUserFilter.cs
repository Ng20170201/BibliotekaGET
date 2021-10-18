using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Filteri
{
    public class LoggedUserFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Controller controller = context.Controller as Controller;
            if (context.HttpContext.Session.GetInt32("tipKorisnika") != null)
                controller.ViewBag.TipKorisnika = context.HttpContext.Session.GetInt32("tipKorisnika");
           
        }
    }
}
