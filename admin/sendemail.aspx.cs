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

public partial class admin_sendemail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        data_conn cn = new data_conn();
        DataSet ds = new DataSet();
        string sql = "";

       
        sql = sql + "SELECT top 1 * ";
        sql = sql + "FROM ";
        sql = sql + "TB_User ";
        sql = sql + "WHERE ";
        sql = sql + "(importtype = 1) AND (advemailsuccess IS NULL or advemailsuccess = '') and (useremail is not null) AND (importtime = '2008-3-13') ORDER BY UserID ";
        ds = cn.mdb_ds(sql, "user");


        if (ds.Tables["user"].Rows.Count > 0)
        {
            try
            {
                // 创建 SmtpClient 以发送 Email
                SmtpClient client = new SmtpClient();

                MailMessage message = new MailMessage();

                // 设置发信人的EMAIL地址
                message.From = new MailAddress("100allincus@gmail.com", "傲赢网", System.Text.Encoding.UTF8);

                // 设置收信人的EMAIL地址
                message.To.Add(ds.Tables["user"].Rows[0]["UserEmail"].ToString());

                // 设置回复的EMAIL地址
                message.ReplyTo = new MailAddress("100allincus@gmail.com");

                // 设置抄送的EMAIL地址
                // message.CC.Add(ccAddress);
                // message.Bcc.Add(bccAddress);

                // 设置发信主题及内容
                message.Subject = "您已成功注册傲赢网会员-免费搜索运价，发布货盘，尽在傲赢网(www.100allin.com)";

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
                          "<table border=0 cellspacing=0 cellpadding=13 width=90% bgcolor=#fffdcf align=center> " +
                            "<tbody> " +
                              "<tr> " +
                                "<td><font size=2><strong>尊敬的用户，您好！</strong> " +
                                    "<p>您已成功注册傲赢网会员，以下是您注册的详细信息：</p></font> " +
                                    "<table border=0 cellspacing=0 cellpadding=0 width=100% bgcolor=#fffdcf align=center> " +
                                      "<tbody> " +
                                        "<tr> " +
                                          "<td><font size=2><p>您的用户名是：<strong>" + ds.Tables["user"].Rows[0]["UserName"].ToString() + "</strong> </p> " +
                                            "<p>您的密码是:<strong>" + ds.Tables["user"].Rows[0]["UserPassword"].ToString() + "</strong></p><p>使用您的用户名、密码，登陆<a href=http://www.100allin.com>傲赢网www.100allin.com</a>，体验以下各类服务</p></font></td> " +
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
                                "<td width=408 bgcolor=#e9e9e9><font size=2><strong>免费 查看海空运价信息</strong><br /> " +
                                "免费查看海空运运价,为您提供各航线超精品运价查询 </font></td> " +
                              "</tr> " +
                              "<tr> " +
                                "<td height=60 bgcolor=#e9e9e9><img src=http://www.100allin.com/images/email/search.gif width=48 height=48 /></td> " +
                                "<td bgcolor=#e9e9e9><font size=2><strong>免费 搜索发布货盘信息</strong><br /> " +
                "免费发布货盘信息,帮您及时找到最理想的运价</font></td> " +
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
                client.Host = "smtp.gmail.com";
                client.Port = 25;
                client.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("100allincus@gmail.com", "takeeasy");
                client.Credentials = basicAuthenticationInfo;
                client.EnableSsl = true;
                client.Send(message);

                sql = "update tb_user set advemailsuccess = '成功' where userid = " + ds.Tables["user"].Rows[0]["userid"].ToString();
                cn.mdb_exe(sql);


            }
            catch
            {
                sql = "update tb_user set advemailsuccess = '失败' where userid = " + ds.Tables["user"].Rows[0]["userid"].ToString();
                cn.mdb_exe(sql);

            }

        
        }


        Response.Redirect("sendemailsuccess.aspx");
    }

}
