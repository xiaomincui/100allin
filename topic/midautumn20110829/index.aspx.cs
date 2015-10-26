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
using System.Net.Mail;

public partial class topic_nuclear20110415_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Attributes.Add("onkeyup", "set_mid_from();");
        TextBox2.Attributes.Add("onkeyup", "set_mid_to();");
        DropDownList1.Attributes.Add("onchange", "set_mid_main();");


        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql;
        //
        sql = "select * from TB_Message,tb_user where TB_Message.userid = tb_user.userid and bbsid = 57116 order by postdate desc";
        ds = cn.mdb_ds(sql, "yunjia");
        Rptfcl.DataSource = ds.Tables["yunjia"].DefaultView;
        Rptfcl.DataBind();
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

        if (isCut)
            return sb.ToString() + "..";
        else
            return sb.ToString();
    }



    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (TextBox1.Text == "")
        {
            MessageBox("error", "请填写您的姓名");
        }
        else
        {
            if (TextBox2.Text == "")
            {
                MessageBox("error", "请填写收件人姓名");
            }
            else
            {
                if (TextBox3.Text == "")
                {
                    MessageBox("error", "请填写收件人Email");
                }
                else
                {
                    sendemail();
                }
            }
        }
    }

    protected void sendemail()
    {

        // 创建 SmtpClient 以发送 Email
        SmtpClient client = new SmtpClient();

        MailMessage message = new MailMessage();

        // 设置发信人的EMAIL地址
        message.From = new MailAddress("service@100allin.cn", "环球运费网", System.Text.Encoding.UTF8);

        // 设置收信人的EMAIL地址
        message.To.Add(TextBox3.Text);
        // 设置回复的EMAIL地址
        message.ReplyTo = new MailAddress("service@100allin.cn");

        // 设置抄送的EMAIL地址
        // message.CC.Add(ccAddress);
        // message.Bcc.Add(bccAddress);

        // 设置发信主题及内容
        message.Subject = TextBox1.Text + "给您的中秋祝福";

        message.Body = "<body> " +

        "<table width=\"505\" height=\"216\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" background=\"http://www.100allin.com/topic/midautumn20110829/images/midautumn.jpg\">" +
            "<tr>" +
            "<td width=\"187\" height=\"60\"></td>" +
            "<td colspan=\"2\"></td>" +
            "</tr>" +
            "<tr>" +
              "<td height=\"46\"></td>" +
              "<td colspan=\"2\"><span id=\"mid_to\">" + TextBox2.Text + "</span>:</td>" +
              "</tr>" +
            "<tr>" +
              "<td height=\"65\"></td>" +
              "<td width=\"292\" valign=\"top\"><span id=\"mid_main\">" + DropDownList1.SelectedItem.Text + "</span></td>" +
              "<td width=\"26\"></td>" +
            "</tr>" +
            "<tr height=\"45\">" +
              "<td></td>" +
              "<td colspan=\"2\"><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\">" +
                "<tr>" +
                  "<td width=\"120\" height=\"45\">&nbsp;</td>" +
                  "<td width=\"153\"><span id=\"mid_from\">" + TextBox1.Text + "</span></td>" +
                "</tr>" +
              "</table>	" +
              "</td>" +
              "</tr>	" +
            "</table>" +
        "</body> ";

        message.IsBodyHtml = true;
        // 设置SMTP host及端口
        client.Host = "mail.100allin.cn";
        client.Port = 25;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("service@100allin.cn", "a65127389");
        client.Send(message);

        MessageBox("opsuccess", "邮件发送完毕");
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
