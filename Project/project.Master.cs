using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class project : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            // Abandon the session
            Session.Abandon();

            Response.Redirect("login.aspx");
        }
    }
}