/// Represents one gene of the chromosome
/// a gene has value that can be presented as string and as a number

using System;
using System.Collections;
using System.Text;

public class Gene //: IGene
{
    /// <Local Variables>
    string type;
    int max, val;
    int MIN = 0;
    static Random rnd = new Random();

    /// Alleles
    /// <Arrays to hold type of gene and values for features>
    /// Arrays indeces and values are used for <value encoding>
    /// Types of genes 
    string[] Types = { "Browser", "Javascript", "Screen_Resolution", "Cookies", "Accessibility", "Right_to_left_support", "Using_CSS", "Dynamic_Navigation", "Server_Side_Scripting", "Use_Case", "User" };
    
    /// values of features 48965
    static string[] User;
    static string[] Use_Case;
    string[] Browser ={"InternetExplorer", "Firefox", "Opera", "Chrome", "Avant" , "Maxthon", "GreenBrowser" , "Safari", "Flock" , "uZard"};
    string[] Javascript = { "Form Validation", "DOM", "Alert Messages", "Animation", "Cursor Customization", "Cookies", "Self Executing Functions", "Throwing Exceptions", "Using Try/catch Block", "Using Arrays" };
    string[] Screen_Resolution = { "800*600", "1024*768", "1280*800", "1366*768", "1360*768", "1280*768", "1280*720", "1280*600" };
    string[] Cookies = { "Encrypted Cookies", "PHP Cookies", "Javascript Cookies" , "ASP.NET Cookies", "Shared Domain Cookies" , "Shared Application Cookies", "Password Managing Cookies", "User Prefrences Cookies"};
    string[] Accessibility = { "Optimization for Blindness", "Optimization for Visual Display", "Alternative Input", "Optimization for Reading and Typing" , "Narrator Support" , "High Contrast Support" , "On Screen Keyboard" , "Altervative Sound Support" };
    string[] Right_to_left_support = {"Right_to_Left_Support", "No_Right_to_Left_Support" };
    string[] Using_CSS = { "Inline_CSS", "Embedded_CSS", "External_CSS", "OnClick Animation", "onMouseOver Animation " };
    string[] Dynamic_Navigation ={ "Dynamic_Navigation_enabled", "Dynamic_Navigation_disabled"};
    string[] Server_Side_Scripting = { "ASP", "JSP", "Servlet", "PHP", "EJB" };
    /// </Local Variables>
    
    /// <Properties>
    public int gMin { get { return MIN; } } // read only
    public int gMax { get { return max; } } // read only
    public string gType { get { return type; } } // read only
    public int gValue { get { return val; } set { val = value; } } // read only
    /// </properties>
    
    /// Constructor
    public Gene(string t)
    {
        // loop through all features
        foreach (string s in Types)
        {
            // check for existance
            if (t==s)
            {
                type = t; // set type to the selected feature
                Generate(type); // set max and value
            }
        }
    }

    public Gene(string t, string[] c, string[] u )
    {
        User = new string[u.Length];
        Use_Case = new string[c.Length];

        for (int i = 0; i < u.Length; i++)
        {
            User[i] = u[i];
        }
        for (int i = 0; i < c.Length; i++)
        {
            Use_Case[i] = c[i];
        }
       
            // loop through all features
            foreach (string s in Types)
            {
                // check for existance
                if (t == s)
                {
                    type = t; // set type to the selected feature
                    Generate(type); // set max and value
                }
            }
    }
    /// Creates new gene with specified type
    public void Generate(string type)
    {
        
        switch (type)
        {// set max
            case "Browser": max = Browser.Length; break;
            case "Javascript": max = Javascript.Length; break;
            case "Screen_Resolution": max = Screen_Resolution.Length; break;
            case "Cookies": max = Cookies.Length; break;
            case "Accessibility": max = Accessibility.Length; break;
            case "Right_to_left_support": max = Right_to_left_support.Length; break;
            case "Using_CSS": max = Using_CSS.Length; break;
            case "Dynamic_Navigation": max = Dynamic_Navigation.Length; break;
            case "Server_Side_Scripting": max = Server_Side_Scripting.Length; break;
            case "Use_Case": max = Use_Case.Length; break;
            case "User": max = User.Length; break;
        }
        val = rnd.Next(rnd.Next(max + 1)); // set value
    }

    /// Get string representation of the gene
    public override string ToString()
    {
        string s = "";
        switch (type)
        {
            case "Use_Case": s = Use_Case[val]; break;
            case "User": s = User[val]; break;
            case "Browser": s = Browser[val]; break;
            case "Javascript": s = Javascript[val]; break;
            case "Screen_Resolution": s = Screen_Resolution[val]; break;
            case "Cookies": s = Cookies[val]; break;
            case "Accessibility": s = Accessibility[val]; break;
            case "Right_to_left_support": s = Right_to_left_support[val]; break;
            case "Using_CSS": s = Using_CSS[val]; break;
            case "Dynamic_Navigation": s = Dynamic_Navigation[val]; break;
            case "Server_Side_Scripting": s = Server_Side_Scripting[val]; break;
            

        }
        return type + " : " + s;
    }

    
}

