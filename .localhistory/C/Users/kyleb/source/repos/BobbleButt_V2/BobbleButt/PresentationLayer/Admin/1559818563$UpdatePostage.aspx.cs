using BobbleButt.DataAccessLayer;
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
            if(postage!=null &&!IsPostBack)
            {
                PostageOptions o = QueryClass.GetPostageOptionByName(postage);
                pricePostage.Text = o.Price.ToString("F");
                namePostage.Text = o.Name;
                descriptionPostage.Text = o.Description;
                etaPostage.Text = o.ETA.ToString();
                hiddenID.Text = o.ID.ToString();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            PostageOptions o = new PostageOptions();
            o.Price = Convert.ToDouble(pricePostage.Text);
            o.Description = descriptionPostage.Text;
            o.Name = namePostage.Text;
            o.ETA = Convert.ToInt32(etaPostage.Text);
            // Add new postage option
            if(hiddenID.Text.Equals(""))
            {
                QueryClass.AddPostageOption(o);
            }
            else
            {
                //Update Postage 
                QueryClass.UpdatePostageOption(o);
            }
            Response.Redirect("ManagePostage.aspx");
        }
    }
}