using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MixedModeWebApplication {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (User.Identity.IsAuthenticated) {
                Response.Write("Authenticated as " + User.Identity.Name);
            } else {
                Response.Write("Not authenticated.");
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e) {
            string strUsername = "TestUser";
            FormsAuthentication.SetAuthCookie(strUsername, false);
        }

        protected void ButtonLogout_Click(object sender, EventArgs e) {
            FormsAuthentication.SignOut();
        }
    }
}