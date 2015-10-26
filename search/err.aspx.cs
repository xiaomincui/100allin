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

public partial class search_err : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["user_id"] != null)
        {
            if (Request.Cookies["user_id"].Value.ToString() != "")
            {
                if (Request.Cookies["realname"] == null)
                {
                    data_conn cn = new data_conn();
                    DataSet ds = new DataSet();

                    string sql = "";
                    sql = sql + "SELECT ";
                    sql = sql + "Realname ";
                    sql = sql + "FROM ";
                    sql = sql + "TB_User ";
                    sql = sql + "WHERE ";
                    sql = sql + "UserID = '" + this.Request.Cookies["user_id"].Value.ToString() + "' ";


                    ds = cn.mdb_ds(sql, "user");

                    if (ds.Tables["user"].Rows.Count > 0)
                    {
                        Response.Cookies["realname"].Value = ds.Tables["user"].Rows[0][0].ToString();
                        Response.Cookies["realname"].Expires = Response.Cookies["user_id"].Expires;
                    }

                }

                Label8.Text = "<span style=\"color:#000000;\">欢迎您！" + Server.UrlDecode(Request.Cookies["realname"].Value.ToString()) + "</span> " + "<a href=\"/accounts/logout.aspx\">[退出登录]</a><script src='/home/newlogin.php'></script>"; ;
            }
            else
            {
                Label8.Text = "欢迎您！<a href=\"/accounts/login.aspx\">[登录]</a><script src='/home/newlogout.php'></script>"; ;
            }
        }
        else
        {
            Label8.Text = "欢迎您！<a href=\"/accounts/login.aspx\">[登录]</a><script src='/home/newlogout.php'></script>";
        }

        txtStartport.Attributes.Add("onfocus", "focus_input('txtStartport','');auto_init(event,this);");
        txtStartport.Attributes.Add("onblur", "blur_input('txtStartport','起运港');");
        txtDestport.Attributes.Add("onfocus", "focus_input('txtDestport','');auto_init(event,this);");
        txtDestport.Attributes.Add("onblur", "blur_input('txtDestport','目的港');");
        txtCarrier.Attributes.Add("onfocus", "focus_input('txtCarrier','');auto_init(event,this);");
        txtCarrier.Attributes.Add("onblur", "blur_input('txtCarrier','船公司');");


        txtStartport2.Attributes.Add("onfocus", "focus_input('txtStartport2','');auto_init(event,this);");
        txtStartport2.Attributes.Add("onblur", "blur_input('txtStartport2','起运港');");
        txtDestport2.Attributes.Add("onfocus", "focus_input('txtDestport2','');auto_init(event,this);");
        txtDestport2.Attributes.Add("onblur", "blur_input('txtDestport2','目的港');");
        txtCarrier2.Attributes.Add("onfocus", "focus_input('txtCarrier2','');auto_init(event,this);");
        txtCarrier2.Attributes.Add("onblur", "blur_input('txtCarrier2','船公司');");
        //txtStartport2.Attributes.Add("onkeydown", "KeyDown(event);");
        //txtDestport2.Attributes.Add("onkeydown", "KeyDown(event);");
        //txtCarrier2.Attributes.Add("onkeydown", "KeyDown(event);");

        txtStartport3.Attributes.Add("onfocus", "focus_input('txtStartport3','');auto_init(event,this);");
        txtStartport3.Attributes.Add("onblur", "blur_input('txtStartport3','起运地');");
        txtDestport3.Attributes.Add("onfocus", "focus_input('txtDestport3','');auto_init(event,this);");
        txtDestport3.Attributes.Add("onblur", "blur_input('txtDestport3','目的地');");
        //txtStartport3.Attributes.Add("onkeydown", "KeyDown(event);");
        //txtDestport3.Attributes.Add("onkeydown", "KeyDown(event);");


        txtCompanyName.Attributes.Add("onfocus", "focus_input('txtCompanyName','');");
        txtCompanyName.Attributes.Add("onblur", "blur_input('txtCompanyName','公司名称');");
    }
}
