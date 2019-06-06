using BobbleButt.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected List<User> users;
        protected List<Order> orders;
        protected void Page_Load(object sender, EventArgs e)

        {
            string mode = Request.QueryString["mode"];
            string email = Request.QueryString["user"];
            users = QueryClass.GetUsers();
            orders = QueryClass.GetOrders();
            if (mode!=null)
            {
                //Suspend a user
                if (mode.Equals("toggleSuspend") && !((User)Session["user"]).Email.Equals(email))
                {
                    QueryClass.ToggleSuspendUser(email);
                }
                //Delete a user
                if(mode.Equals("delete")&&!((User)Session["user"]).Email.Equals(email))
                {
                    QueryClass.ToggleDeleteUser(email);
                }
            }
        }
    }
}