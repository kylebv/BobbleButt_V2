using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class ProductPostage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string postage = Request.QueryString["postage"];
            int index = Convert.ToInt32(postage);
            if(postage!=null)
            {
                pricePostage.Text = Convert.ToString(GlobalData.postageList[index].Price);
                namePostage.Text = GlobalData.postageList[index].Name;
            }
        }
    }
}