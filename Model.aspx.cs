using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Model : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String[] cases = (string[])Session["cases"];
        if (cases == null)
        {
            Session["Error"] = "Use Case Statements are Mandatory";
            Response.Redirect("default.aspx");
            return;
        }
        else
        {
            Label1.Text = "";
            Image1.ImageUrl = Modeling.createModel(cases);
        }
    }
}