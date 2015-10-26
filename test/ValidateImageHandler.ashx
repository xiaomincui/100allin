<%@ WebHandler Language="C#" Class="ValidateImageHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

/**//// <summary>
/// ValidateImageHandler 生成网站验证码功能
/// </summary>
public class ValidateImageHandler : IHttpHandler, IRequiresSessionState
{
    int intLength = 5;               //长度
    string strIdentify = "Identify"; //随机字串存储键值，以便存储到Session中
    public ValidateImageHandler()
    {        
    }

    /**//// <summary>
    /// 生成验证图片核心代码
    /// </summary>
    /// <param name="hc"></param>
    public void ProcessRequest(HttpContext hc)
    {
        //设置输出流图片格式
        hc.Response.ContentType = "image/gif";
        
        Bitmap b = new Bitmap(100, 30);
        Graphics g = Graphics.FromImage(b);
        g.FillRectangle(new SolidBrush(Color.YellowGreen), 0, 0, 100, 30);
        Font font = new Font(FontFamily.GenericSerif, 24, FontStyle.Bold, GraphicsUnit.Pixel);
        Random r = new Random();

        //合法随机显示字符列表
        //string strLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        string strLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        StringBuilder s = new StringBuilder();
        
        //将随机生成的字符串绘制到图片上
        for (int i = 0; i < intLength; i++)
        {
            s.Append(strLetters.Substring(r.Next(0, strLetters.Length - 1), 1));
            g.DrawString(s[s.Length - 1].ToString(), font, new SolidBrush(Color.Blue), i * 19, r.Next(0, 7));
        }

        //生成干扰线条
        Pen pen = new Pen(new SolidBrush(Color.Blue), 1);
        for (int i = 0; i < 10; i++)
        {
            g.DrawLine(pen, new Point(r.Next(0, 99), r.Next(0, 29)), new Point(r.Next(0, 99), r.Next(0, 29)));
        }
        b.Save(hc.Response.OutputStream, ImageFormat.Gif);
        hc.Session[strIdentify] = s.ToString(); //先保存在Session中，验证与用户输入是否一致
        hc.Response.Write("Hello World");
        hc.Response.End();
        
   
    }
    
    /**//// <summary>
    /// 表示此类实例是否可以被多个请求共用(重用可以提高性能)
    /// </summary>
    public bool IsReusable
    {
        get
        {
            return true;
        }
    }
}
