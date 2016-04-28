using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Write("您現在是已登入狀態。" + User.Identity.Name);
            }
            else
            {
                Response.Write("未登入。" );
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strUsername = "RM";
            FormsAuthentication.SetAuthCookie(strUsername, false);
        }
    }
}