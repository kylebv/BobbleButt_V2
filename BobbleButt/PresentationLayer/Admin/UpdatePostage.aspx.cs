﻿using System;
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
                pricePostage.Text = Convert.ToString(GlobalData.postageList[index].Price);
                namePostage.Text = GlobalData.postageList[index].Name;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Add new postage option
            if(postage==null)
            {
                GlobalData.postageList.Add(new PostageOptions(namePostage.Text, Convert.ToInt64(pricePostage.Text)));
            }
            else
            {
            //Update Postage 
                GlobalData.postageList[Convert.ToInt32(postage)].Name = namePostage.Text;
                GlobalData.postageList[Convert.ToInt32(postage)].Price = Convert.ToInt64(pricePostage.Text);
                string s1, s2;
                s2 = namePostage.Text;
                s1 = GlobalData.postageList[Convert.ToInt32(postage)].Name;
            }
            Response.Redirect("PostageOptions.aspx");
        }
    }
}