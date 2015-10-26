using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class usercontrols_userbbsmenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetHighlight();
    }

    protected void SetHighlight()
    {
        if (System.IO.Path.GetFileName(Request.PhysicalPath) == "Default.aspx")
        {
            Literal1.Text = "<li><img src=\"/images/bbs/nav_ico1.GIF\" /><a href=\"/bbs/\" style=\"color:#ff6600;\">论坛首页</a></li>";
        }
        else
        {
            Literal1.Text = "<li><img src=\"/images/bbs/nav_ico1.GIF\" /><a href=\"/bbs/\">论坛首页</a></li>";
        }

        Literal2.Text = "<li><img src=\"/images/bbs/nav_ico2.GIF\" /><a href=\"/bbs/forum-5-1.html\">航运动态</a></li>";
        Literal3.Text = "<li><img src=\"/images/bbs/nav_ico3.GIF\" /><a href=\"/bbs/forum-1-1.html\">货主天地</a></li>";
        Literal4.Text = "<li><img src=\"/images/bbs/nav_ico4.GIF\" /><a href=\"/bbs/forum-2-1.html\">货代之家</a></li>";
        Literal5.Text = "<li><img src=\"/images/bbs/nav_ico5.GIF\" /><a href=\"/bbs/forum-3-1.html\">谈天说地</a></li>";
        Literal6.Text = "<li><img src=\"/images/bbs/nav_ico6.GIF\" /><a href=\"/bbs/forum-6-1.html\">紧急询价</a></li>";
        Literal7.Text = "<li style='width:120px;'><img src=\"/images/bbs/nav_ico7.GIF\" /><a href=\"/bbs/forum-7-1.html\">公司优势展示</a></li>";

        if (Request.QueryString["types"] != null)
        {
            switch (Request.QueryString["types"].ToString())
            {
                case "1":
                    Literal3.Text = "<li><img src=\"/images/bbs/nav_ico3.GIF\" /><a href=\"/bbs/forum-1-1.html\" style=\"color:#ff6600;\">货主天地</a></li>";
                    break;
                case "2":
                    Literal4.Text = "<li><img src=\"/images/bbs/nav_ico4.GIF\" /><a href=\"/bbs/forum-2-1.html\" style=\"color:#ff6600;\">货代之家</a></li>";
                    break;
                case "3":
                    Literal5.Text = "<li><img src=\"/images/bbs/nav_ico5.GIF\" /><a href=\"/bbs/forum-3-1.html\" style=\"color:#ff6600;\">谈天说地</a></li>";
                    break;
                case "4":
                    Literal7.Text = "<li><img src=\"/images/bbs/nav_ico1.GIF\" /><a href=\"/bbs/forum-4-1.html\" style=\"color:#ff6600;\">公告栏</a></li>";
                    break;
                case "5":
                    Literal2.Text = "<li><img src=\"/images/bbs/nav_ico2.GIF\" /><a href=\"/bbs/forum-5-1.html\" style=\"color:#ff6600;\">航运动态</a></li>";
                    break;
                case "6":
                    Literal6.Text = "<li><img src=\"/images/bbs/nav_ico6.GIF\" /><a href=\"/bbs/forum-6-1.html\" style=\"color:#ff6600;\">紧急询价</a></li>";
                    break;
                case "7":
                    Literal7.Text = "<li style='width:120px;'><img src=\"/images/bbs/nav_ico7.GIF\" /><a href=\"/bbs/forum-7-1.html\" style=\"color:#ff6600;\">公司优势展示</a></li>";
                    break;
            }
        }
    }
}
