using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testingParam : System.Web.UI.Page
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
        
       
        
    }
    protected void btnDone_Click(object sender, EventArgs e)
    {
        Label1.Text = "";

        int count=0;
        foreach (ListItem item in CheckBoxList1.Items)
        {
            if (item.Selected)
            {
                count++;
            }
        }
        string[] f= new string[count];
        int i = 0;
        // Loop through each item.
        foreach (ListItem item in CheckBoxList1.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                f[i]=item.Value;
                i++;
            }
        }

        Session["features"] = null;
        Session["features"]= f;

        // show confirmation message
        Label1.Text = "Features are recorded check the test cases tab to view the generated test cases";
    }
}