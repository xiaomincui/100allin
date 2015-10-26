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

public partial class usercontrols_userservice : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //AddStyleSheet(this.Page, "/js/fancy/jquery.fancybox/jquery.fancybox.css");
        //AddStyleSheet(this.Page, "/css/login.css");


        ImageButton1.Attributes.Add("onclick", "hiddenkfk();return false;");


        if (Request.Cookies["realname"] != null & Request.Cookies["companyname"] != null & Request.Cookies["phone"] != null & Request.Cookies["useremail"] != null)
        {
            if (Request.Cookies["realname"].Value != "")
            {
                TextBox1.Text = Server.UrlDecode(Request.Cookies["realname"].Value.ToString());
                TextBox2.Text = Server.UrlDecode(Request.Cookies["companyname"].Value.ToString());
                TextBox3.Text = Server.UrlDecode(Request.Cookies["phone"].Value.ToString());
                TextBox4.Text = Server.UrlDecode(Request.Cookies["useremail"].Value.ToString());
            }
        }

    }

    public void AddStyleSheet(Page page, string cssPath)
    {
        HtmlLink link = new HtmlLink();
        link.Href = cssPath;
        link.Attributes["rel"] = "stylesheet";
        link.Attributes["type"] = "text/css";
        link.Attributes["media"] = "screen";
        page.Header.Controls.Add(link);
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }
}    
