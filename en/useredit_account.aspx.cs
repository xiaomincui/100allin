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
using MySql.Data.MySqlClient;

public partial class en_login_1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetUserInfo();
        }
    }

    public void GetUserInfo()
    {
        data_conn cn = new data_conn();
        DataSet ds = cn.mdb_ds("select * from TB_User where Userid=" + Request.Cookies["user_id"].Value.ToString(), "user");

        Text3.Value = ds.Tables["user"].Rows[0]["First_Name"].ToString();
        Text4.Value = ds.Tables["user"].Rows[0]["Last_Name"].ToString();
        Text5.Value = ds.Tables["user"].Rows[0]["EN_CompanyName"].ToString();
        DropDownList1.SelectedValue = ds.Tables["user"].Rows[0]["CompanyType"].ToString();
        Text6.Value = ds.Tables["user"].Rows[0]["Phone"].ToString();
        Text7.Value = ds.Tables["user"].Rows[0]["Fax"].ToString();
        Text8.Value = ds.Tables["user"].Rows[0]["UserEmail"].ToString();
        Text9.Value = ds.Tables["user"].Rows[0]["Usermsn"].ToString();
        Text10.Value = ds.Tables["user"].Rows[0]["Website"].ToString();
        Text11.Value = ds.Tables["user"].Rows[0]["EN_Country"].ToString();
        Text12.Value = ds.Tables["user"].Rows[0]["EN_City"].ToString();
        Text13.Value = ds.Tables["user"].Rows[0]["EN_Address"].ToString();
        Text14.Value = ds.Tables["user"].Rows[0]["PostNumber"].ToString();
        TEXTAREA1.Value = ds.Tables["user"].Rows[0]["EN_Company_profile"].ToString();

        if (ds.Tables["user"].Rows[0]["ifEn"].ToString() == "0")
        {
            Literal1.Text = "你还不是英文站的用户，还不能发布英文价格";
        }

    }

    public void MessageBox(string strKey, string strInfo)
    {
        if (!ClientScript.IsClientScriptBlockRegistered(strKey))
        {
            string strjs = "alert('" + strInfo + "');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        check ck = new check();
        data_conn cn = new data_conn();
        string sql = "";



        if (WordsIScn(Text3.Value) && WordsIScn(Text4.Value) && WordsIScn(Text5.Value) && WordsIScn(Text6.Value) && WordsIScn(Text7.Value) && WordsIScn(Text8.Value) && WordsIScn(Text9.Value) && WordsIScn(Text10.Value) && WordsIScn(Text11.Value) && WordsIScn(Text12.Value) && WordsIScn(Text13.Value) && WordsIScn(Text14.Value) && WordsIScn(TEXTAREA1.Value))
        {

        }
        else
        {
            MessageBox("opfail", "不能出现中文字符");
            return;
        }



        if (Text3.Value == "" || Text5.Value == "" || DropDownList1.SelectedValue == "" || Text6.Value == "" || Text8.Value == "" || Text11.Value == "" || Text12.Value == "")
        {
            MessageBox("opfail", "*号为必填项");
            return;
        }

        sql = sql + "UPDATE ";
        sql = sql + "TB_User ";
        sql = sql + "SET ";

        sql += "RealName='" + ck.CheckInput(Text3.Value.ToString()) + " " + ck.CheckInput(Text4.Value.ToString()) + "', ";
        sql += "First_Name='" + Text3.Value + "', ";
        sql += "Last_Name='" + Text4.Value + "', ";
        sql += "EN_CompanyName='" + Text5.Value + "', ";
        sql += "CompanyType=" + DropDownList1.SelectedValue + ", ";//int  
        sql += "Phone='" + Text6.Value + "', ";
        sql += "Fax='" + Text7.Value + "', ";
        sql += "UserEmail='" + Text8.Value + "', ";
        sql += "Usermsn='" + Text9.Value + "', ";
        sql += "Website='" + Text10.Value + "', ";
        sql += "EN_Country='" + Text11.Value + "', ";
        sql += "EN_City='" + Text12.Value + "', ";
        sql += "EN_Address='" + Text13.Value + "', ";
        sql += "PostNumber='" + Text14.Value + "', ";
        sql += "EN_Company_profile='" + TEXTAREA1.Value + "', ";
        sql += "ifEn=1 ";
        sql = sql + "WHERE UserID = " + Request.Cookies["user_id"].Value.ToString();
        cn.mdb_exe(sql);






        MessageBox("", "修改成功");



    }

    public string MD5(string str)
    {
        Byte[] b = System.Text.Encoding.Default.GetBytes(str);
        b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
        string ret = "";
        for (int i = 0; i < b.Length; i++)
        {
            ret += b[i].ToString("x").PadLeft(2, '0');
        }
        return ret;

    }

    public string UnixTimestamp()
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        DateTime dtNow = DateTime.Parse(DateTime.Now.ToString());
        TimeSpan toNow = dtNow.Subtract(dtStart);
        string timeStamp = toNow.Ticks.ToString();
        return timeStamp.Substring(0, timeStamp.Length - 7);
    }

    public bool WordsIScn(string words)
    {
        if (words == "")
        {
            return true;
        }
        string TmmP;
        for (int i = 0; i < words.Length; i++)
        {
            TmmP = words.Substring(i, 1);
            byte[] sarr = System.Text.Encoding.GetEncoding("gb2312").GetBytes(TmmP);
            if (sarr.Length == 2)
            {
                return false;
            }
        }
        return true;
    }


}
