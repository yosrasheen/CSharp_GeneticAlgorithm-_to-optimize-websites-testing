using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Modeling
/// </summary>
public class Modeling
{

    public static string createModel(String[] array)
    {
        if (array.Length > 0)
        {
            System.Drawing.Bitmap bm = new System.Drawing.Bitmap(400, array.Length * 90);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bm);
            g.Clear(System.Drawing.Color.White);
            int x = 100;
            int y = 10;
            System.Drawing.StringFormat f = new System.Drawing.StringFormat();
            f.Alignment = System.Drawing.StringAlignment.Center;
            f.LineAlignment = System.Drawing.StringAlignment.Center;
            System.Drawing.Font font;
            System.Drawing.Drawing2D.LinearGradientBrush b = new System.Drawing.Drawing2D.LinearGradientBrush(new System.Drawing.Point(0, 40), new System.Drawing.Point(30, 130), System.Drawing.Color.GreenYellow, System.Drawing.Color.LemonChiffon);
            for (int i = 0; i < array.Length; i++)
            {
                font = new System.Drawing.Font("Arial Unicode MS", 10, System.Drawing.FontStyle.Regular);
                g.DrawImageUnscaled(System.Drawing.Image.FromFile(HttpContext.Current.Request.MapPath("tskOval.png")), x, y);
                g.DrawString(array[i].Substring(0, (array[i].Length > 52 ? 52 : array[i].Length)), font, System.Drawing.Brushes.Black, new System.Drawing.Rectangle(x + 30, y + 6, 172, 40), f);
                y += 85;

            }

            x = 100;
            y = 10;
            int y1, y2;
            for (int i = 1; i < array.Length; i++)
            {
                System.Drawing.Pen p = new System.Drawing.Pen(System.Drawing.Color.Black);
                p.Width = 1.5F;
                y1 = (((i) * 50) + y + ((i - 1) * 35));
                y2 = (((i) * 50) + y + ((i) * 35));
                g.DrawLine(p, 200, y1 + 2, 200, y2);
                System.Drawing.Point[] pns = new System.Drawing.Point[4];
                pns[0] = new System.Drawing.Point(195, y2 - 5);
                pns[1] = new System.Drawing.Point(200, y2);
                pns[2] = new System.Drawing.Point(205, y2 - 5);
                pns[3] = new System.Drawing.Point(195, y2 - 5);
                g.FillPolygon(System.Drawing.Brushes.Black, pns);

                // g.DrawString(((Node)SessionClass.Flow[i-1]).decision.Equals("True")?"Yes":"No", new System.Drawing.Font("Arial Unicode MS", 9, System.Drawing.FontStyle.Regular), System.Drawing.Brushes.Black, new System.Drawing.Point(205, y1 +6));
            }
            string res = HttpContext.Current.Server.MapPath("Results") + "\\User" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".png";
            bm.Save(res, System.Drawing.Imaging.ImageFormat.Png);
            return "Results/" + res.Replace(HttpContext.Current.Server.MapPath("Results") + "\\", "");

        }
        else
        {
            return "";
        }
    }
}