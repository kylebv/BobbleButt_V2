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
        protected string postage;
        protected void Page_Load(object sender, EventArgs e)
        {
            postage = Request.QueryString["postage"];
            int index = Convert.ToInt32(postage);
            if(postage!=null)
            {
                pricePostage.Text = Convert.ToString(GlobalData.postageList[index].Price);
                namePostage.Text = GlobalData.postageList[index].Name;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(postage==null)
            {
                GlobalData.postageList.Add(new PostageOptions(namePostage.Text, Convert.ToInt64(pricePostage.Text)));
            }
            else
            {
                GlobalData.postageList[Convert.ToInt32(postage)] = new PostageOptions(namePostage.Text, Convert.ToInt64(pricePostage.Text));
            }
            Response.Redirect("PostageOptions.aspx");
        }
    }
}