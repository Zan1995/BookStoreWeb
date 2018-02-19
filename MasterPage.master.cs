using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using System.Web.Security;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        linkupdate.Visible = false;
        if(Page.User.Identity.Name=="" || Page.User.Identity.Name == null)
        {
            linklogin.Visible = true;
            linklogout.Visible = false;
            Label1.Text = "Guest";
        }
        else 
        {
            linklogin.Visible = false;
            linklogout.Visible = true;
            Label1.Text = Page.User.Identity.Name.ToString();
            if (Page.User.IsInRole("admin"))
            {
                linkupdate.Visible = true;
            }
        }

        
    }


}
