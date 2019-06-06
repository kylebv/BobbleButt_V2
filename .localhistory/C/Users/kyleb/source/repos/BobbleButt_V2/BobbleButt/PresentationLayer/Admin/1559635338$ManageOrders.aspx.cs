using BobbleButt.DataAccessLayer;
using BobbleButt.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class ManageOrders : System.Web.UI.Page
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
            orders = QueryClass.GetOrders();
            int orderID = 0;
            try
            {
                orderID = Convert.ToInt32(order);
            }
            catch { }
            //toggles sent if mode is toggleSent and order exists in url
            if (mode != null && order != null)
            {
                if (mode.Equals("toggleSent"))
                {
                    //query for toggling sent

                    QueryClass.OrderToggleSent(orderID);
                    orders = QueryClass.GetOrders();

                }
            }
            //populates a single order if order exists in url
            if(order!=null && mode==null)
            {
                orders = new List<Order>();
                orders.Add(QueryClass.GetOrder(orderID));
            }
            //populates by user if there is a user url param
            if(user!=null)
            {
                orders = QueryClass.GetOrdersByUser(user);
            }
        }
    }
}