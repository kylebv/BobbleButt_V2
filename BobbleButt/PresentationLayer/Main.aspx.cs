using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class Main : System.Web.UI.Page
    {
        protected string orderer, forgotEmailPopUp, adminEmailPopUp;
        protected void Page_Load(object sender, EventArgs e)
        {
            adminEmailPopUp = Request.QueryString["confirmAdmin"];
            forgotEmailPopUp = Request.QueryString["forgotEmail"];
            orderer = Request.QueryString["orderEmail"];
            //Display pop up message on main page
            if (orderer != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
            if (forgotEmailPopUp != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalForgot();", true);
            }
            if (adminEmailPopUp != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalAdmin();", true);
            }
        }
    }
}