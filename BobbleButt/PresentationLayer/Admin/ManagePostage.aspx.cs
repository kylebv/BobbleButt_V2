using BobbleButt.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class ManagePostage : System.Web.UI.Page
    {
        protected List<PostageOptions> options;
        protected void Page_Load(object sender, EventArgs e)
        {
            string delete = Request.QueryString["delete"];
            options = QueryClass.GetPostageOptions();
            if(delete!=null)
            {
                //Delete a specific postage option
                int index = Convert.ToInt32(delete);
                GlobalData.postageList.RemoveAt(index);
            }
        }
    }
}