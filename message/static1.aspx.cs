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
        
        
        


        string tempsearch_string;
        if (Request.Cookies["tempsearch"] != null)
        {
            tempsearch_string = Request.Cookies["tempsearch"].Value;
        }
        else
        {
            tempsearch_string = "";
        }
        Label23.Text = Server.UrlDecode(tempsearch_string).Replace("|", "");

        //读取最近浏览过的运价列表
        string tempfreight_string;
        if (Request.Cookies["tempfreight"] != null)
        {
            tempsearch_string = Request.Cookies["tempfreight"].Value;
        }
        else
        {
            tempsearch_string = "";
        }
        Label22.Text = Server.UrlDecode(tempsearch_string).Replace("|", "");
    }

   
}
