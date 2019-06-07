using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BobbleButt.BusinessLayer 

{
    public class basePageSessionExpire : System.Web.UI.MasterPage
    {
        public basePageSessionExpire()
        {
        }


        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (Context.Session != null)
            {
                //Tested and the IsNewSession is more advanced then simply checking if 
                // a cookie is present, it does take into account a session timeout, because 
                // I tested a timeout and it did show as a new session
                if (Session.IsNewSession)
                {
                    // If it says it is a new session, but an existing cookie exists, then it must 
                    // have timed out (can't use the cookie collection because even on first 
                    // request it already contains the cookie (request and response
                    // seem to share the collection)
                    string szCookieHeader = Request.Headers["Cookie"];
                    if ((null != szCookieHeader) && (szCookieHeader.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        Response.Redirect("Main?sessionTimeout=true");
                    }
                }
            }
        }
    }
}