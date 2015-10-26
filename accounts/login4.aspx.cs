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

public partial class login4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrName.Text = Server.UrlDecode(Request.Cookies["user_name"].Value);

        Literal1.Text = "<a href=\"" + Request.Cookies["redirect_url"].Value + "\">点此回到注册前页面</a>";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        string sql = "update TB_User set ";
        sql += "Offtake_fcl=" + FalseToNum(CheckBox4.Checked) + ",";
        sql += "Offtake_lcl=" + FalseToNum(CheckBox3.Checked) + ",";
        sql += "Offtake_air=" + FalseToNum(CheckBox2.Checked) + ",";
        sql += "Offtake_other=" + FalseToNum(CheckBox1.Checked) + ",";
        sql += "Offtake_name='" + text1.Value + "',";
        sql += "GoodType_Normal=" + FalseToNum(CheckBox5.Checked) + ",";
        sql += "GoodType_Danger=" + FalseToNum(CheckBox6.Checked) + ",";
        sql += "GoodType_Cold=" + FalseToNum(CheckBox7.Checked) + ",";
        sql += "GoodType_Big=" + FalseToNum(CheckBox8.Checked) + ",";
        sql += "GoodType_Other=" + FalseToNum(CheckBox9.Checked) + ",";
        sql += "Offtake_Port='" + text2.Value + "',";
        sql += "OfftakeLink_fcl_Europe=" + FalseToNum(CheckBox26.Checked) + ",";
        sql += "OfftakeLink_fcl_SOUTH_AMERICA=" + FalseToNum(CheckBox10.Checked) + ",";
        sql += "OfftakeLink_fcl_Australia=" + FalseToNum(CheckBox11.Checked) + ",";
        sql += "OfftakeLink_fcl_Caribbean=" + FalseToNum(CheckBox12.Checked) + ",";
        sql += "OfftakeLink_fcl_Red_Sea=" + FalseToNum(CheckBox13.Checked) + ",";
        sql += "OfftakeLink_fcl_Japan_Korea=" + FalseToNum(CheckBox14.Checked) + ",";
        sql += "OfftakeLink_fcl_CIMEX=" + FalseToNum(CheckBox15.Checked) + ",";
        sql += "OfftakeLink_fcl_Africa=" + FalseToNum(CheckBox16.Checked) + ",";
        sql += "OfftakeLink_fcl_offing=" + FalseToNum(CheckBox17.Checked) + ",";
        sql += "OfftakeLink_air_North_America=" + FalseToNum(CheckBox18.Checked) + ",";
        sql += "OfftakeLink_air_Europe=" + FalseToNum(CheckBox19.Checked) + ",";
        sql += "OfftakeLink_air_Asia=" + FalseToNum(CheckBox20.Checked) + ",";
        sql += "OfftakeLink_air_Africa=" + FalseToNum(CheckBox23.Checked) + ",";
        sql += "OfftakeLink_air_SOUTH_AMERICA=" + FalseToNum(CheckBox21.Checked) + ",";
        sql += "OfftakeLink_air_Australia=" + FalseToNum(CheckBox22.Checked) + ",";
        sql += "OfftakeLink_air_internal=" + FalseToNum(CheckBox24.Checked) + " ";
        sql += "where UserID=" + Request.Cookies["user_id"].Value.ToString();


        cn.mdb_exe(sql);
        Response.Redirect("/accounts/regsuccess.aspx");
    }

    public string FalseToNum(bool a)
    {
        if (a)
        {
            return "1";
        }
        else
        {
            return "0";
        }
    }
}

