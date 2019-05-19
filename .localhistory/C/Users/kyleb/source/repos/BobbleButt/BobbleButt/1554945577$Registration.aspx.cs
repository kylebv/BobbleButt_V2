using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((RegularExpressionValidator)FindControl("regexState")).ValidationExpression = new Regex(@"(NSW|ACT|QLD|SA|WA|VIC|TAS|NT)", RegexOptions.IgnoreCase).ToString();

        }
    }
}