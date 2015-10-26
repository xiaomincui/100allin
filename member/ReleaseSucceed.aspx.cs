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

public partial class test_releasesucceed : System.Web.UI.Page
{
    AllinUser AllinUser1 = new AllinUser();
    GetRequest GetRequest1 = new GetRequest();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string userid = GetRequest1.GetRequestCookies("user_id", "");

        string[] udetail;
        udetail = AllinUser1.GetUserDetail(userid);

        //if (udetail[11] == "0")
        //{
            //PlaceHolder1.Visible = true;
        ///}
        //else
        //{
        //    PlaceHolder1.Visible = false;
        //}


        Page.Title = "环球运费网";
        if (Convert.ToInt32(this.Request["type"]) == 1)
        {
            Literal1.Text = "<a href=\"Release.aspx\" title=\"点击此处继续发布整箱海运运价\"><img src=\"/member/images/srbnt01.gif\" border=\"0\" /></a>";
            Literal2.Text = "<a href=\"../fcl/" + key(this.Request["id"].ToString()) + "_0.html\" title=\"点击此处查看我刚才发布的运价\" target=\"_blank\"><img src=\"/member/images/srbnt02.gif\" border=\"0\" style=\"margin-left:20px\"  /></a>";
            Literal3.Text = "<a href=\"http://www.100allin.com/products/buy.aspx?type=1\" title=\"申请购买精准营销\"><img src=\"/member/images/srbnt03.gif\" border=\"0\" style=\"margin-left:20px\"  /></a>";
        }
        else if (Convert.ToInt32(this.Request["type"]) == 2)
        {
            Literal1.Text = "<a href=\"SpellRelease.aspx\" title=\"点击此处继续发布拼箱海运运价\"><img src=\"/member/images/srbnt01.gif\" border=\"0\" /></a>";
            Literal2.Text = "<a href=\"../lcl/" + key(this.Request["id"].ToString()) + "_0.html\" title=\"点击此处查看我刚才发布的运价\" target=\"_blank\"><img src=\"/member/images/srbnt02.gif\" border=\"0\" style=\"margin-left:20px\"  /></a>";
            Literal3.Text = "<a href=\"http://www.100allin.com/products/buy.aspx?type=1\" title=\"申请购买精准营销\"><img src=\"/member/images/srbnt03.gif\" border=\"0\" style=\"margin-left:20px\"  /></a>";
        }
        else if (Convert.ToInt32(this.Request["type"]) == 3)
        {
            Literal1.Text = "<a href=\"AirRelease.aspx\" title=\"点击此处继续发布空运运价\"><img src=\"/member/images/srbnt01.gif\" border=\"0\" /></a>";
            Literal2.Text = "<a href=\"../air/" + key(this.Request["id"].ToString()) + "_0.html\" title=\"点击此处查看我刚才发布的运价\" target=\"_blank\"><img src=\"/member/images/srbnt02.gif\" border=\"0\" style=\"margin-left:20px\"  /></a>";
            Literal3.Text = "<a href=\"http://www.100allin.com/products/buy.aspx?type=1\" title=\"申请购买精准营销\"><img src=\"/member/images/srbnt03.gif\" border=\"0\" style=\"margin-left:20px\"  /></a>";
        }
        else
        {
            throw new Exception();
        }
    }

    public string key(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }
}
