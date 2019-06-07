using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace BobbleButt
{
    public class Global : HttpApplication
    {
      
   

        
        //int count = 0;
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
        protected void Session_Start(object sender, EventArgs e)
        {
          
        }
        protected void Session_End(object sender, EventArgs e)
        {
            
        }
        

        
    }
}