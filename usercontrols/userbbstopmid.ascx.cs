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

public partial class usercontrols_userbbstopmid : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetRequest GetRequest1 = new GetRequest();
        string uvid = "0";
        if (GetRequest1.GetRequestCookies("uvid", "0") == "0")
        {
            data_conn cn = new data_conn();
            DataSet ds = new DataSet();
            string sql = "INSERT INTO TB_UV_LIST (uvtime) values (getdate());select @@identity";
            ds = cn.mdb_ds(sql, "uvid");
            uvid = ds.Tables["uvid"].Rows[0][0].ToString();

            Response.Cookies["uvid"].Value = uvid;
            Response.Cookies["uvid"].Expires = DateTime.Now.AddDays(365);
        }
        else
        {
            uvid = GetRequest1.GetRequestCookies("uvid", "0");
        }



        string srvlink = "";
        srvlink += "<a title=\"欢迎使用在线客服\" id=\"service_link\" href=\"http://im.cn.alisoft.com/webim/webim/webclient!open.jspa?lang=zh_cn&img=0&memberid=";
        srvlink += "e" + uvid;
        srvlink += "&targetid=cnalichna910254766&siteId=4035516&initiative=1&domain=probe.alisoft.com&siteFlag=enet&colorStyle=orange&msg=&ct=\" target=\"_blank\">在线客服</a>";
        Literal3.Text = srvlink;
    }
}
