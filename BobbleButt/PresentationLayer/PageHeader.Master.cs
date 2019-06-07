using BobbleButt.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class PageHeader : System.Web.UI.MasterPage
    {
        protected List<Product> cart;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Session.Add("cart", GlobalData.productList);
            cart = (List<Product>)Session["cart"];

            //Session["user_id"] = 1;
            //Session.Add("user", GlobalData.userMap["adminuser@bobblebutt.com"]);
            //if (HttpContext.Current.Session == null)
            //{
            //Response.Redirect("Main?sessionTimeout=true");
            //}
            //if (Session[""]==null)
            //{
            //Session.Add("new session pls", "hooray");
            //Response.Redirect("Main?sessionTimeout=true");
            //}

            //if (Session.Contents.Count == 0)
            //{
            //Session.Add("new session pls", "hooray");
            //Response.Redirect("Main?sessionTimeout=true");           
            //}

            /*if (HttpContext.Current.Session != null)
                {
                    if (HttpContext.Current.Session.IsNewSession)
                    {
                        string CookieHeaders = HttpContext.Current.Request.Headers["Cookie"];

                        if ((null != CookieHeaders) && (CookieHeaders.IndexOf("ASP.NET_SessionId") >= 0))
                        {
                            // IsNewSession is true, but session cookie exists,
                            // so, ASP.NET session is expired
                            Response.Redirect("Main?sessionTimeout=true");
                        }
                    }
                }*/

            //if (Session.IsNewSession)
            //{
            //  Response.Redirect("Main?sessionTimeout=true");
            //}
            
            /*if (Context.Session != null)
            {
                if (Session.IsNewSession)
                {
                    string szCookieHeader = Request.Headers["Cookie"];
                    if ((null != szCookieHeader) && (szCookieHeader.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        Response.Redirect("Main?sessionTimeout=true");
                    }
                }
            }*/
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products?search=" + searchBar.Text);
        }
    }
}