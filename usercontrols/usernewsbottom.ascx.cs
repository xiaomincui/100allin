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

public partial class usercontrols_usernewsbottom : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "";
        DataSet ds = new DataSet();
        data_conn cn = new data_conn();
        sql = "select top 6 ";
        sql = sql + "id,RTRIM(title) as title,postdate ";
        sql = sql + "FROM TB_BBS WHERE (types = 5) ORDER BY id DESC ";
        //sql = sql + "TB_YunJia WHERE (enddate >= { fn NOW() }) and LINE='国内航线' ORDER BY hits DESC, id DESC";
        ds = cn.mdb_ds(sql, "bbs");
        RptaHangYunDongTai.DataSource = ds.Tables["bbs"].DefaultView;
        RptaHangYunDongTai.DataBind();


    }
}
