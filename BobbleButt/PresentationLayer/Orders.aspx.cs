using BobbleButt.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class Orders : System.Web.UI.Page
    {
        protected string mode;
        protected string order;
        protected string user;
        protected List<Order> orders;
        protected void Page_Load(object sender, EventArgs e)
        {
            mode = Request.QueryString["mode"];
            order = Request.QueryString["order"];
            user = Request.QueryString["user"];
            int i = 0;
            try { Convert.ToInt32(order); }
            catch { }
            if(mode==null&&order!=null)
            {
                orders = new List<Order>();
                orders.Add(QueryClass.GetOrder(i));
            }
            //if these are true, the user shouldnt be here
            if(user==null&&order==null)
            {
                Response.Redirect("Main");
            }
            orders = QueryClass.GetOrdersByUser(user);
            if (mode != null && order != null)
            {
                if (mode.Equals("toggleSent"))
                {
                    try{ Convert.ToInt32(order); }
                    catch { }
                    //Change status of order if admin changes the status
                    QueryClass.OrderToggleSent(i);
                }
                if(Request.QueryString["flagSingle"]==null)
                {
                    orders = QueryClass.GetOrdersByUser(user);
                }
                else
                {

                    orders = new List<Order>();
                    orders.Add(QueryClass.GetOrder(i));
                }
            }
        }
    }
}