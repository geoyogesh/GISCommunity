using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

namespace GISCommunity
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }

        //Disabling Http
        /*Working but Url is not changing*/
        /*
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsSecureConnection.Equals(false) && HttpContext.Current.Request.IsLocal.Equals(false))
            {
                Response.Redirect("https://" + Request.ServerVariables["HTTP_HOST"]
            + HttpContext.Current.Request.RawUrl);
            }
        }
         
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
          switch (Request.Url.Scheme)
          {
            case "https":
              Response.AddHeader("Strict-Transport-Security", "max-age=300");
              break;
            case "http":
              var path = "https://" + Request.Url.Host + Request.Url.PathAndQuery;
              Response.Status = "301 Moved Permanently";
              Response.AddHeader("Location", path);
              break;
          }
        }
         * */
    }
}