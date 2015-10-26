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

public partial class intro_Orc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label28.Text = "亲爱的用户，由于系统升级，您所查看的页面已转移至以下地址：<br/>";
        Label28.Text = Label28.Text + "<a href=\"http://www.100allin.com/orc/\">http://www.100allin.com/orc/</a><br/>";
        Label28.Text = Label28.Text + "<br/>";
        Label28.Text = Label28.Text + "点击以下链接，查看最新附加费：<br/>";
        Label28.Text = Label28.Text + "<a href=\"http://www.100allin.com/baf/\">最新BAF附加费</a> ";
        Label28.Text = Label28.Text + "<a href=\"http://www.100allin.com/caf/\">最新CAF附加费</a> ";
        Label28.Text = Label28.Text + "<a href=\"http://www.100allin.com/thc/\">最新THC附加费</a> ";
        Label28.Text = Label28.Text + "<a href=\"http://www.100allin.com/orc/\">最新ORC附加费</a> ";
    }
}
