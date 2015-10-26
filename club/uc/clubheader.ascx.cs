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

public partial class club_uc_clubheader : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        check check1 = new check();
        GetRequest GetRequest1 = new GetRequest();

        string u = "";
        u = check1.CheckNumber(GetRequest1.GetRequestCookies("user_id", "0"));

        if (u == "0")
        {
            PlaceHolder1.Visible = false;
            PlaceHolder2.Visible = true;
        }
        else
        {
            PlaceHolder1.Visible = true;
            PlaceHolder2.Visible = false;

                    string[] udetail;
        AllinUser AllinUser1 = new AllinUser();
        udetail = AllinUser1.GetUserDetail(u);

        string uhomeid = udetail[10];

        string name = udetail[3];

        Literal1.Text = "<A class=login_thumb href=\"/home/space.php?uid=" + udetail[10] + "\"><IMG height=20 alt=" + udetail[3] + " src=\"/uc/avatar.php?uid=" + udetail[10] + "&size=small&type=virtual\" width=20></A> <A class=loginName href=\"/home/space.php?uid=" + udetail[10] + "\">" + udetail[3] + "</A>";
        }



    }
}
