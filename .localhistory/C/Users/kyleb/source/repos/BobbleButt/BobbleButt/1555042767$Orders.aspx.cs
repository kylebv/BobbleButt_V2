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
        protected void Page_Load(object sender, EventArgs e)
        {
            string mode = Request.QueryString["mode"];
            string order = Request.QueryString["order"];
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