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



        if (Text1.Value != Text2.Value)
        {
            MessageBox("opfail", "两遍输入的密码不相同");
            return;
        }
        if (Text1.Value.Length < 6 || Text1.Value.Length > 15)
        {
            MessageBox("opfail", "密码长度错误");
            return;
        }

        string sql = "";
        sql += "update TB_User set UserPassword='" + Text1.Value + "' where UserID=" + Request.Cookies["user_id"].Value.ToString();


        Response.Redirect("/en/member/office.aspx");


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

    public string insert(string username, string password, string email, string myid, string myidkey, string regip, string regdate, string lastloginip, string lastlogintime, string salt)
    {
        string sql = "";
        //try
        //{
        MySqlConnection connection1 = new MySqlConnection("Database=allin;Data Source = localhost;User Id = sasa;Password = takeeasy822822");
        mysqldata_conn mysqlcn = new mysqldata_conn();

        MySqlCommand command1 = new MySqlCommand();
        connection1.Open();
        MySqlDataAdapter da1 = new MySqlDataAdapter();
        DataSet ds = new DataSet();
        sql = "insert into uc_members (username,password,email,myid,myidkey,regip,regdate,lastloginip,lastlogintime,salt) values ('" + username + "','" + password + "','" + email + "','" + myid + "','" + myidkey + "','" + regip + "'," + regdate + "," + lastloginip + "," + lastlogintime + ",'" + salt + "')";

        command1 = new MySqlCommand(sql, connection1);
        command1.ExecuteNonQuery();
        command1 = new MySqlCommand("SELECT LAST_INSERT_ID()", connection1);
        da1.SelectCommand = command1;


        da1.Fill(ds, "aa");
        connection1.Close();
        return ds.Tables["aa"].Rows[0][0].ToString();
        //}
        //catch (Exception ex)
        //{
        //    this.Response.Write(sql);
        //    return "";
        //}
    }
}
