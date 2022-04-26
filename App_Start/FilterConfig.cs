using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq;
using WorldServiceOrganization.Models;
using System.Collections.Generic;

namespace WorldServiceOrganization
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAction1FilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            Controller controller = filterContext.Controller as Controller;

            if (controller != null)
            {
                if (session["User"] == null)
                {
                    filterContext.Result = new RedirectToRouteResult(new
                                         RouteValueDictionary(new { controller = "Account", action = "Login" }));
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class NoDirectAccessAttribute : ActionFilterAttribute
    {

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    HttpSessionStateBase session = filterContext.HttpContext.Session;
        //    List<tblAccessLevel> Access = (List<tblAccessLevel>)session["Access"];
        //    var ActionNames = Access.Select(s => s.tblMenu.ActionName).ToList();
        //    string ActionName = filterContext.ActionDescriptor.ActionName;
        //    string ControlerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;



        //    if (ActionNames.Contains(ActionName)|| (ActionNames.Contains("Persons")&&(ActionName== "CreatePerson")||(ActionName== "OneRecord")||(ActionName== "RoutingSlip")||(ActionName== "PassportLabel")||(ActionName== "AlphaLabel")||(ActionName== "AddressLabel"))|| (ActionNames.Contains("Users")&& ActionName== "CreateUser") || (ControlerName=="Home"&& ActionName=="Index"))
        //    {

        //    }
        //    else
        //    {
        //        filterContext.Result = new RedirectToRouteResult(new
        //                                  RouteValueDictionary(new { controller = "Account", action = "Index" }));
        //    }
        //}

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if(filterContext.HttpContext.Request.UrlReferrer!=null)
            //{

            //    String previousUrl = filterContext.HttpContext.Request.UrlReferrer.AbsolutePath;
            //}
            //var url = filterContext.RouteData.Values;

            if (filterContext.HttpContext.Request.UrlReferrer == null ||
     filterContext.HttpContext.Request.Url.Host != filterContext.HttpContext.Request.UrlReferrer.Host)
            {
                filterContext.Result = new RedirectToRouteResult(new
                                          RouteValueDictionary(new { controller = "Account", action = "Index" }));
            }
        }
    }
}
