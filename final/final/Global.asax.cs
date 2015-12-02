using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Parse;
using System.IO;

namespace final
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //Parse initialization
            ParseClient.Initialize("GqwWATRcgsMvZxDSlkoOqadSKJoCWgOS3jna63qd", "zje7QWmHHA4lLaVFYll64mBxD7KxXiW6n5cRbqui");
            ParseFacebookUtils.Initialize("1513033632350091");

            //log4net init
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));

        }
    }
}
