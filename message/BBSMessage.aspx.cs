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

public partial class message_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Request.QueryString["id"] != null)
        {
            Label28.Text = "亲爱的用户，由于系统升级，您所查看的帖子已转移至以下地址：<br/>";
            Label28.Text = Label28.Text + "<a href=\"http://www.100allin.com/bbs/thread-" + (Request.QueryString["id"].ToString()) + "-1.html\">http://www.100allin.com/bbs/thread-" + (Request.QueryString["id"].ToString()) + "-1.html</a>";
        }
        else
        {
            Label28.Text = "环球运费网论坛已升级，论坛已转移至以下地址：<br/>";
            Label28.Text = Label28.Text + "<a href=\"http://www.100allin.com/bbs/\">http://www.100allin.com/bbs/";
        }
               
    }

}
