using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class Admin_Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            string mode = Request.QueryString["mode"];
            string email = Request.QueryString["userEmail"];
            if (mode!=null)
            {
                if (mode.Equals("toggleSuspend") && !((User)Session["user"]).Email.Equals(email))
                {
                    GlobalData.userMap[email].IsSuspended = !GlobalData.userMap[email].IsSuspended;
                }
                if(mode.Equals("delete")&&!((User)Session["user"]).Email.Equals(email))
                {
                    GlobalData.userMap.Remove(email);
                }
            }
        }
    }
}