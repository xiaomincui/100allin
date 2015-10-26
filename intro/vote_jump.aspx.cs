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

public partial class intro_vote_jump : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string votestring = "http://www.100allin.com/home/userapp.php?id=1006424&my_suffix=Lw%3D%3D";
        if (Request.Cookies["user_id"] != null)
        {
            if (Request.Cookies["user_id"].Value.ToString() != "")
            {
                Response.Redirect(votestring);
            }
            else
            {
                Response.Redirect("/accounts/login.aspx?redirect_url=" + Server.UrlEncode(votestring));
            }

        }
        else
        {
            Response.Redirect("/accounts/login.aspx?redirect_url=" + Server.UrlEncode(votestring));
        }
    }
}
