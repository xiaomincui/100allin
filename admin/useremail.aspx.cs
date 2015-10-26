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
using System.Net.Mail;

public partial class admin_useremail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["cus_email_address"] != null)
            {
                DropDownList1.SelectedValue = Request.Cookies["cus_email_address"].Value.ToString();
            }


            data_conn cn = new data_conn();
            DataSet ds = new DataSet();

            string sql = "";
            sql = sql + "SELECT * ";
            sql = sql + "FROM ";
            sql = sql + "TB_User ";
            sql = sql + "WHERE ";
            sql = sql + "userid = " + Request.QueryString["id"].ToString();
            ds = cn.mdb_ds(sql, "user");



            UserName.Value = ds.Tables["user"].Rows[0]["UserName"].ToString();
            UserEmail.Value = ds.Tables["user"].Rows[0]["UserEmail"].ToString();
            Subject.Value = "傲赢网客户服务特函-www.100allin.com";
        }

    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Cookies["cus_email_address"].Value = DropDownList1.SelectedValue.ToString();
        Response.Cookies["cus_email_address"].Expires = DateTime.Now.AddDays(365);
    }




    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        // 创建 SmtpClient 以发送 Email
        SmtpClient client = new SmtpClient();

        MailMessage message = new MailMessage();

        // 设置发信人的EMAIL地址
        message.From = new MailAddress(DropDownList1.SelectedValue, "傲赢网", System.Text.Encoding.UTF8);

        // 设置收信人的EMAIL地址
        message.To.Add(UserEmail.Value);
        // 设置回复的EMAIL地址
        message.ReplyTo = new MailAddress(DropDownList1.SelectedValue);

        // 设置抄送的EMAIL地址
        // message.CC.Add(ccAddress);
        // message.Bcc.Add(bccAddress);

        // 设置发信主题及内容
        message.Subject = Subject.Value.ToString();

        message.Body = "<body> " +
        "<table border=0 cellspacing=3 cellpadding=0 width=540 bgcolor=#F0690F align=center> " +
          "<tbody> " +
            "<tr> " +
              "<td bgcolor=#ffffff> " +
           "<table width=90% height=80 border=0 align=center cellpadding=0 cellspacing=0> " +
                "<tbody> " +
                  "<tr> " +
                    "<td> " +
            "<a href=http://www.100allin.com target=_blank><img border=0 src=http://www.100allin.com/images/logo.gif width=149 height=47 /></a> " +
            "<strong> " +
             "<font size=3 color=#29728D>专业</font><font size=3 color=#FF6600>运价</font><font size=3 color=#29728D>搜索查询和发布</font> " +
            "</strong> " +
           "</td> " +
                  "</tr> " +
                "</tbody> " +
              "</table> " +
                  "<table border=0 cellspacing=0 cellpadding=13 width=90% bgcolor=#fffdcf align=center> " +
                    "<tbody> " +
                      "<tr> " +
                        "<td><font size=2><strong>尊敬的用户" + UserName.Value + "，您好！</strong></font> " +
                            "<br /> " +
                            "<br /> " +
                            "<table border=0 cellspacing=0 cellpadding=0 width=100% bgcolor=#fffdcf align=center> " +
                              "<tbody> " +
                                "<tr> " +
                                  "<td width=51%><p><font size=2>" + Encode(txtmemo.Value.ToString()) + " </font></p> " +
                                  "<td width=49%></td> " +
                                "</tr> " +
                              "</tbody> " +
                          "</table></td> " +
                      "</tr> " +
                    "</tbody> " +
                  "</table> " +
                "<br /> " +
                  "<table width=90% height=25 border=0 align=center cellpadding=0 cellspacing=0 bgcolor=#F0690F> " +
                    "<tbody> " +
                      "<tr> " +
                        "<td width=13>&nbsp;</td> " +
                        "<td width=468><font size=2>傲赢网为您提供多项优质免费服务：</font></td> " +
                      "</tr> " +
                    "</tbody> " +
                "</table> " +
                  "<table border=0 cellspacing=1 cellpadding=5 width=90% align=center> " +
                    "<tbody> " +
                      "<tr> " +
                        "<td width=50 height=60 bgcolor=#e9e9e9><img src=http://www.100allin.com/images/email/up.gif width=48 height=48 /></td> " +
                        "<td width=408 bgcolor=#e9e9e9><font size=2><strong>免费 搜索发布海空运价信息</strong><br /> " +
                        "发布运价完全免费,批量上传功能让你更快更多的发布运价<br /> " +
                        "免费查看海空运运价,为您提供各航线超精品运价查询 </font></td> " +
                      "</tr> " +
                      "<tr> " +
                        "<td height=60 bgcolor=#e9e9e9><img src=http://www.100allin.com/images/email/search.gif width=48 height=48 /></td> " +
                        "<td bgcolor=#e9e9e9><font size=2><strong>免费 搜索发布货盘信息</strong><br /> " +
        "几千外贸客户资源,更多更好货盘等你来拿</font></td> " +
                      "</tr> " +
                      "<tr> " +
                        "<td height=60 bgcolor=#e9e9e9><img src=http://www.100allin.com/images/email/chat.gif width=48 height=48 /></td> " +
                        "<td bgcolor=#e9e9e9><font size=2><strong>即时 与您的商友沟通</strong><br /> " +
        "聊天工具免下载免安装,随时随地与用户进行沟通</font></td> " +
                      "</tr> " +
                    "</tbody> " +
                  "</table> " +
                  "<br /> " +
                "<br /> " +
                  "<table border=0 cellspacing=0 cellpadding=0 width=90% align=center> " +
                    "<tbody> " +
                      "<tr> " +
                        "<td><font size=2><p>您在使用过程中，如有任何问题或建议，请随时联系傲赢网客户服务人员，我们将热忱为您服务。 <br /> " +
                        "</p></font></td> " +
                      "</tr> " +
                    "</tbody> " +
                  "</table> " +
            "<br /> " +
                "<table border=0 cellspacing=0 cellpadding=0 width=90% align=center> " +
                    "<tbody> " +
                      "<tr> " +
                        "<td align=center><font size=2>【温馨提示】<br /> " +
                            "<font size=2 color=#CC0000><strong>为保证您正常接收邮件，傲赢网建议您将此邮件地址加入到地址簿中。</strong></font><br /> " +
                        "</div></td> " +
                      "</tr> " +
                    "</tbody> " +
                "</table></td> " +
            "</tr> " +
            "<tr> " +
              "<td bgcolor=#FF6600 height=50 align=center><font size=2>傲赢网(<a href=http://www.100allin.com>http://www.100allin.com</a>)<br /> " +
                "客服电话/传真：021-51086987/021-63509508　邮箱：allin@100allin.com</font></td> " +
            "</tr> " +
          "</tbody>  " +
        "</table>  " +
        "</body> ";

        message.IsBodyHtml = true;
        // 设置SMTP host及端口
        client.Host = "mail.100allin.cn";
        client.Port = 25;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential(DropDownList1.SelectedValue, "a65127389");
        client.Send(message);

        MessageBox("opsuccess", "邮件发送完毕");
    }


    public string Encode(string str)
    {
        str = str.Replace("&", "&amp;");
        str = str.Replace("'", "''");
        str = str.Replace("\"", "&quot;");
        str = str.Replace("   ", "&nbsp;");
        str = str.Replace("<", "&lt;");
        str = str.Replace(">", "&gt;");
        str = str.Replace("\n", "<br>");
        return str;
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
