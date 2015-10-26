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
using System.Text.RegularExpressions;
using System.Text;

public partial class en_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Request.Cookies["user_id"] == null || Request.Cookies["user_id"].Value == "")
        {
            PlaceHolder2.Visible = false;
            PlaceHolder1.Visible = true;
            //Response.Write("没有登录");
        }
        else
        {
            PlaceHolder2.Visible = true;
            PlaceHolder1.Visible = false;
            //Response.Write("已经登录");
        }


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql;
        //
        sql = "select ";
        sql = sql + "* ";
        sql = sql + "FROM  ";
        sql = sql + "V_最新_整箱运价_EN ";
        ds = cn.mdb_ds(sql, "bbs");
        Rptfcl.DataSource = ds.Tables["bbs"].DefaultView;
        Rptfcl.DataBind();


        sql = "select ";
        sql = sql + "* ";
        sql = sql + "FROM  ";
        sql = sql + "V_最新_拼箱运价_EN ";
        ds = cn.mdb_ds(sql, "bbs");
        Rptlcl.DataSource = ds.Tables["bbs"].DefaultView;
        Rptlcl.DataBind();

        sql = "select ";
        sql = sql + "* ";
        sql = sql + "FROM  ";
        sql = sql + "V_最新_空运运价_EN ";
        ds = cn.mdb_ds(sql, "bbs");
        Rptair.DataSource = ds.Tables["bbs"].DefaultView;
        Rptair.DataBind();
    }


    public static string GetFirstString(string stringToSub, int length)
    {
        //\u4e00-\u9fa5 中文区
        //\uff00-\uffef 逗号区
        //\u3000-\u303f 句号区
        //\u2000-\u206f 引号区
        //\u25a0-\u25ff 几何图形区
        Regex regex = new Regex("[\u4e00-\u9fa5\uff00-\uffef\u3000-\u303f\u2000-\u206f\u25a0-\u25ff]+", RegexOptions.Compiled);
        char[] stringChar = stringToSub.ToCharArray();
        StringBuilder sb = new StringBuilder();
        int nLength = 0;
        bool isCut = false;
        for (int i = 0; i < stringChar.Length; i++)
        {
            if (regex.IsMatch((stringChar[i]).ToString()))
            {
                sb.Append(stringChar[i]);
                nLength += 2;
            }
            else
            {
                sb.Append(stringChar[i]);
                nLength = nLength + 1;
            }

            if (nLength >= length)
            {
                isCut = true;
                break;
            }
        }

        if (sb.ToString() == "") 
        {
            return " - ";
        }

        if (isCut)
            return sb.ToString() + "..";
        else
            return sb.ToString();
    }

    public static bool IsOdd(int n)
    {
        return Convert.ToBoolean(n % 2);
    }

    public string setkey(string es)
    {
        SymmetricMethod s = new SymmetricMethod();
        return s.Encrypto(es);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Cookies["user_id"].Value = "";
        Response.Cookies["user_name"].Value = "";
        Response.Cookies["user_password"].Value = "";
        Response.Cookies["realname"].Value = "";
        Response.Cookies["companyname"].Value = "";
        Response.Cookies["phone"].Value = "";
        Response.Cookies["useremail"].Value = "";
        Response.Redirect("/en/");
    }

}
