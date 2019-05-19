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
        protected string orderer;
        protected void Page_Load(object sender, EventArgs e)
        {
            orderer = Request.QueryString["orderEmail"];
            if (orderer != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
        }
    }
}