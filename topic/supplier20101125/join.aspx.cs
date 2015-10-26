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

public partial class topic_supplier20101125_join : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Literal1.Text = "<strong><img style=\"margin:0 6px -6px 0;\" src=\"/images/mail/6464_034.png\" width=\"32\" height=\"32\" />您的申请已提交，感谢您的支持！</strong>";
        GetRequest GetRequest1 = new GetRequest();
        SymmetricMethod ss = new SymmetricMethod();
        check ck = new check();

        string uid = "0";

        try
        {
            uid = ck.CheckNumber(ss.Decrypto(GetRequest1.GetRequestQueryString("uid", "")));

            if (uid == "0")
            {
                Literal1.Text = "<strong><img style=\"margin:0 6px -6px 0;\" src=\"/images/mail/wr.gif\" width=\"32\" height=\"32\" />抱歉，您需在相关邮件或登录后在相关页面中点击申请链接！</strong>";
            }
            else
            {
                data_conn cn = new data_conn();
                DataSet ds = new DataSet();
                string sql = "";
                sql = "SELECT userid FROM TB_TOPIC_SUPPLIER WHERE userid = " + uid + "";

                ds = cn.mdb_ds(sql, "user");

                if (ds.Tables["user"].Rows.Count > 0)
                {
                    Literal1.Text = "<strong><img style=\"margin:0 6px -6px 0;\" src=\"/images/mail/wr.gif\" width=\"32\" height=\"32\" />您已经提交过申请！</strong>";
                }
                else
                {
                    sql = "INSERT INTO TB_TOPIC_SUPPLIER (userid) VALUES (" + uid + ")";
                    cn.mdb_exe(sql);
                    Literal1.Text = "<strong><img style=\"margin:0 6px -6px 0;\" src=\"/images/mail/6464_034.png\" width=\"32\" height=\"32\" />您的申请已提交，感谢您的支持！</strong>";
                }
            }



        }
        catch
        {
            Literal1.Text = "<strong><img style=\"margin:0 6px -6px 0;\" src=\"/images/mail/wr.gif\" width=\"32\" height=\"32\" />抱歉，您需在相关邮件或登录后在相关页面中点击申请链接！</strong>";
        }

    }
}
