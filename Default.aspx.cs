using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
    int maximum;

    protected void Button1_Click(object sender, EventArgs e)
    {
        // validation
        if ((CheckBox1.Checked== true) && (TextBox3.Text==""))
        {
            Label1.Text = "Enter a valid number for the maximum number of cases";
            return;
        }
        
        if (TextBox1.Text.Equals(""))
        {
            Label1.Text = "Use Case Statements are Mandatory";
            return;
        }

        if (TextBox2.Text.Equals(""))
        {
            Label1.Text = "Users are mandatory";
            return;
        }

        // start to pass data to other pages
        Label1.Text = "";
        String casesS = TextBox1.Text;
        String[] cases = casesS.Split('\n');
        for (int i = 0; i < cases.Length; i++ )
        {
            if ((cases[i].IndexOf("\r")) != -1)
            {
                cases[i] = cases[i].Substring(0, cases[i].Length-1);
            }

        }

        String usersS = TextBox2.Text;
        String[] users = usersS.Split('\n');
        for (int i = 0; i < users.Length; i++)
        {
            if ((users[i].IndexOf("\r")) != -1)
            {
                users[i] = users[i].Substring(0, users[i].Length - 1);
            }

        }

        if (TextBox3.Text != "")
            Session.Add("max", TextBox3.Text);

        Session.Add("users", users);
        Session.Add("cases", cases);
        
        Label1.Text = "Your Model is created Succesfully";
        Label1.ForeColor = System.Drawing.Color.DimGray;
           
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked == true)
        {
            TextBox3.Visible = true;
        }
        else
        {
            TextBox3.Visible = false;
            TextBox3.Text = "";
        }
    }




    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            if (Session["Error"] != null)
            {
                Label1.Text = "Use Case Statements are Mandatory";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
         }
    }
}
