using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        lblError.Text = string.Empty;

        if (Membership.ValidateUser(ctrlLogin.UserName, ctrlLogin.Password))
        {
            Response.Redirect("default.aspx");
            
        }
        else
        {
           
            //Login oLogin = new Login();
            
            //ctrlLogin.FailureAction = LoginFailureAction.RedirectToLoginPage;
            //ctrlLogin.FailureText = "LogIn failed...";
            lblError.Text = "LogIn failed...";
            
        }
    }
}
