using System;
using System.Web.Security;

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
            FormsAuthentication.RedirectFromLoginPage(strUsername, false);
        }

        protected void ButtonWinLogin_Click(object sender, EventArgs e) {
            Response.Redirect("LoginWin.aspx");
        }
    }
}