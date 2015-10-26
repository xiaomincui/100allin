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

public partial class topic_order20100402_Default : System.Web.UI.Page
{
    check check1 = new check();
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Button1_Click1(object sender, EventArgs e)
    {
        if (TEXTAREA1.Value.Length == 0 || TEXTAREA2.Value.Length == 0 || TEXTAREA3.Value.Length == 0)
        {
            MessageBox("", "请完整输入案例信息");
        }
        else
        {

            if (TEXTAREA1.Value.Length > 1000 || TEXTAREA2.Value.Length > 1000 || TEXTAREA3.Value.Length > 1000)
            {
                MessageBox("", "每个输入框不能超过1000个字符");
            }
            else
            {
                data_conn cn = new data_conn();
                cn.mdb_exe("insert into TB_Customer_Case (copartner,account,Contact) values ('" + check1.CheckInput(TEXTAREA1.Value) + "','" + check1.CheckInput(TEXTAREA2.Value) + "','" + check1.CheckInput(TEXTAREA3.Value) + "')");
                MessageBox("", "提交成功");
                //Server.Transfer("Default.aspx");
            }
        }
    }

    protected void MessageBox(string strKey, string strInfo)
    {

        if (!this.Page.ClientScript.IsClientScriptBlockRegistered(strKey))
        {
            string strjs = "alert('" + strInfo + "');";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
    }
}
