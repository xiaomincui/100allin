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

public partial class admin_record_record : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";
        sql += "select TB_FREIGHT_VIEWRECORD.freight_code,TB_FREIGHT_VIEWRECORD.freight_code1,TB_FREIGHT_VIEWRECORD.NowTime, ";
        sql += "tb_user.username,tb_user.useremail,tb_user.realname,tb_user.companyname,tb_user.phone,tb_user.movephone,tb_user.address ";
        sql += "from TB_FREIGHT_VIEWRECORD,tb_user ";
        sql += "where TB_FREIGHT_VIEWRECORD.userid = tb_user.userid and ";
        sql += "yuserid = 1199 ";
        sql += "and nowtime >= '2010-7-12' ";
        sql += "and TB_FREIGHT_VIEWRECORD.userid <> 0 ";
        sql += "order by tb_user.userid ";

        ds = cn.mdb_ds(sql, "record");
        Repeater1.DataSource = ds.Tables["record"].DefaultView;
        Repeater1.DataBind();

    }

    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }
}
