using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SECRET1_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.IsInRole("admin"))
        {
            Response.Redirect("Default3.aspx");
        }
        else 
        {
            Response.Redirect("Default2.aspx");
        }
    }
}