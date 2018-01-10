using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;

public partial class TestCases : System.Web.UI.Page
{
    string s = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        string max = (string)Session["max"];
        string[] users = (string[])Session["users"];
        string[] useCases = (string[])Session["cases"];
        string[] features= (string[])Session["features"];

        if (useCases == null)
        {
            Session["Error"] = "Use Case Statements are Mandatory";
            Response.Redirect("default.aspx");
            return;
        }
        if (features == null)
        {
            Session["Error"] = "features are Mandatory";
            Response.Redirect("testingParam.aspx");
            return;
        }
        
            if (max != null)
            {
                int i = Int32.Parse(max);
                Population p = new Population(i, features, useCases, users);
                TextBox1.Rows = p.Size;
                TextBox1.Text = p.ToString();
                s = p.ToString();
            }
            else
            {
                Population p = new Population(features, useCases, users);
                TextBox1.Rows = p.Size;
                TextBox1.Text = p.ToString();
                s = p.ToString();
            }
            


    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        // ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "window.print()", true); 

        String[] cases = s.Split('\n');
        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder();
        sbHtml.Append("<html>");
        sbHtml.Append("<body>");
        sbHtml.Append("<p>testCases.aspx - " + DateTime.Now.ToString("ddMMyyyy") + "</p><br/>");
        sbHtml.Append("<h1> Optimized Web Application Testing Framework </h1><br/>");
        sbHtml.Append("<h3> Generated Test Cases </h3>");
        sbHtml.Append("<br />");
        foreach (string o in cases)
            sbHtml.Append("<h3>" + o + "</h3>");
        sbHtml.Append("</body>");
        sbHtml.Append("</html>");

        try
        {
            //Set page size as A4
            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
            PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);



            //Open PDF Document to write data
            pdfDoc.Open();

            //Assign Html content in a string to write in PDF
            string contents = sbHtml.ToString();

            //Read string contents using stream reader and convert html to parsed conent 
            var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(contents), null);

            //Get each array values from parsed elements and add to the PDF document
            foreach (var htmlElement in parsedHtmlElements)
                pdfDoc.Add(htmlElement as IElement);

            //Close your PDF
            pdfDoc.Close();

            Response.ContentType = "application/pdf";

            //Set default file Name as current datetime
            Response.AddHeader("content-disposition", "attachment; filename=" + DateTime.Now.ToString("yyyyMMdd") + ".pdf");
            System.Web.HttpContext.Current.Response.Write(pdfDoc);

            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
     
}