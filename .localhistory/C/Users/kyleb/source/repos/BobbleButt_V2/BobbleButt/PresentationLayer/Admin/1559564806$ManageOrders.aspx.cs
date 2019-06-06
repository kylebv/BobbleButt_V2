using BobbleButt.DataAccessLayer;
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

            if (mode != null && order != null)
            {
                if (mode.Equals("toggleSent"))
                {
                    if (GlobalData.Orders[Convert.ToInt32(order)].Status.Equals("Processing"))
                    {
                        GlobalData.Orders[Convert.ToInt32(order)].Status = "Sent";
                    }
                    else if (GlobalData.Orders[Convert.ToInt32(order)].Status.Equals("Sent"))
                    {
                        GlobalData.Orders[Convert.ToInt32(order)].Status = "Processing";
                    }
                }
            }
        }
    }
}