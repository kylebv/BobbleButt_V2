using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class PostageOptions1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string delete = Request.QueryString["delete"];
            if(delete!=null)
            {
                int index = Convert.ToInt32(delete);
                GlobalData.postageList.RemoveAt(index);
            }
        }
    }
}