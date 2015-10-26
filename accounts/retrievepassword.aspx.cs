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

public partial class accounts_password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["Identify"].ToString() == Text3.Value)
        {
            data_conn cn = new data_conn();
            DataSet ds = cn.mdb_ds("select * from TB_User where username='" + Text1.Value + "'", "user");
            if (ds.Tables["user"].Rows.Count == 1)
            {
                if (ds.Tables["user"].Rows[0]["UserEmail"].ToString() == Text2.Value)
                {
                    
                    SendEmail(ds.Tables["user"].Rows[0]["UserID"].ToString(), ds.Tables["user"].Rows[0]["UserName"].ToString(), ds.Tables["user"].Rows[0]["UserPassword"].ToString(), ds.Tables["user"].Rows[0]["UserEmail"].ToString(), "UTF");

                }
                else
                {
                    MessageBox("opsuccess", "邮箱输入错误");
                }
            }
            else
            {
                MessageBox("opsuccess", "没有这个用户");
            }
        }
        else
        {
            MessageBox("opsuccess", "验证码错误");
        }
    }



    public void SendEmail(string userid, string name, string password, string email, string type)
    {
        string code = "";
        switch (type)
        {
            case "GB":
                code = "gb2312";
                break;
            case "UTF":
                code = "utf-8";
                break;
            default:
                code = "gb2312";
                break;
        }
        jmail.Message JMail = new jmail.Message();
        JMail.Charset = code;
        JMail.Logging = true;
        JMail.ContentType = "text/html";
        JMail.AddHeader("Originating-IP", Request.ServerVariables["REMOTE_ADDR"]);
        JMail.MailServerUserName = "service@100allin.com";
        JMail.MailServerPassWord = "100allin";
        JMail.From = "service@100allin.com";
        JMail.FromName = "环球运费网";
        JMail.Subject = "忘记密码提示";


        JMail.Body += name + "，您好！<br /><br />";

        JMail.Body += "您在环球运费网（http://www.100allin.com/）点击了“忘记密码”按钮，系统自动为你发送了这封邮件。您可以点击以下链接修改您的密码(当天有效)：<br /><br />";

        JMail.Body += "<a href='http://www.100allin.com/accounts/resetpassword.aspx?p=" + MD5(MD5(password + DateTime.Today.ToString())) + "&u=" + name + "'>http://www.100allin.com/accounts/resetpassword.aspx?p=" + MD5(MD5(password + DateTime.Today.ToString())) + "&u=" + name + "</a><br /><br />";
        //JMail.Body += "<a href='http://www.100allin.com/accounts/resetpassword.aspx?p=" + MD5(MD5(password + DateTime.Today.ToString())) + "&u=" + name + "'>http://www.100allin.com/accounts/resetpassword.aspx?p=" + password + DateTime.Today.ToString() + "&u=" + name + "</a><br /><br />";


        JMail.Body += "如果您不需要修改密码，或者您从未点击过“忘记密码”按钮，请忽略本邮件。<br /><br />";

        JMail.Body += "任何疑问，请打免费电话咨询：400-888-9256。谢谢您的支持！";





        JMail.AddRecipient(email, name, "");
        JMail.Priority = 3;
        JMail.Send("smtp.exmail.qq.com", false);
        JMail.Close();
        JMail = null;
        Response.Redirect("sendmailpassword.aspx");

    }

    protected void MessageBox(string strKey, string strInfo)
    {

        if (!this.Page.ClientScript.IsClientScriptBlockRegistered(strKey))
        {
            string strjs = "alert('" + strInfo + "');";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), strKey, strjs, true);
        }
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


}
