
Partial Class admin_sendemail2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SendEmail("paradini", "822822", "paradini@msn.com", "UTF")
    End Sub

    Public Sub SendEmail(ByVal name As String, ByVal password As String, ByVal email As String, ByVal type As String)
        Dim code As String = ""
        Select Case type
            Case "GB"
                code = "gb2312"
            Case "UTF"
                code = "utf-8"
        End Select
        Dim JMail As New jmail.Message
        JMail.Charset = code
        JMail.Logging = True
        JMail.ContentType = "text/html"
        JMail.AddHeader("Originating-IP", Request.ServerVariables("REMOTE_ADDR"))
        JMail.MailServerUserName = "adv@100allin.com.cn"
        JMail.MailServerPassWord = "takeeasy822822"
        JMail.From = "adv@100allin.com.cn"
        JMail.FromName = "傲赢网"
        JMail.Subject = "您已成功注册傲赢网会员"
        JMail.Body = "<body> " & _
        "<table border=0 cellspacing=3 cellpadding=0 width=540 bgcolor=#F0690F align=center> " & _
          "<tbody> " & _
            "<tr> " & _
              "<td bgcolor=#ffffff> " & _
           "<table width=90% height=80 border=0 align=center cellpadding=0 cellspacing=0> " & _
                "<tbody> " & _
                  "<tr> " & _
                    "<td> " & _
            "<a href=http://www.100allin.com target=_blank><img border=0 src=http://www.100allin.com/images/logo.gif width=149 height=47 /></a> " & _
            "<strong> " & _
             "<font size=3 color=#29728D>专业</font><font size=3 color=#FF6600>运价</font><font size=3 color=#29728D>搜索查询和发布</font> " & _
            "</strong> " & _
           "</td> " & _
                  "</tr> " & _
                "</tbody> " & _
              "</table> " & _
                  "<table border=0 cellspacing=0 cellpadding=13 width=90% bgcolor=#fffdcf align=center> " & _
                    "<tbody> " & _
                      "<tr> " & _
                        "<td><font size=2><strong>尊敬的用户，您好！</strong> " & _
                            "<p>感谢您注册傲赢网，以下是您注册的详细信息：</p></font> " & _
                            "<table border=0 cellspacing=0 cellpadding=0 width=100% bgcolor=#fffdcf align=center> " & _
                              "<tbody> " & _
                                "<tr> " & _
                                  "<td width=51%><font size=2><p>您的用户名是：<strong>" & name & "</strong> </p> " & _
                                    "<p>您的密码是:<strong>" & password & "</strong></p></td> " & _
                                  "<td width=49%><a href=http://www.100allin.com></a></font></td> " & _
                                "</tr> " & _
                              "</tbody> " & _
                          "</table></td> " & _
                      "</tr> " & _
                    "</tbody> " & _
                  "</table> " & _
                "<br /> " & _
                  "<table width=90% height=25 border=0 align=center cellpadding=0 cellspacing=0 bgcolor=#F0690F> " & _
                    "<tbody> " & _
                      "<tr> " & _
                        "<td width=13>&nbsp;</td> " & _
                        "<td width=468><font size=2>注册成功后，您可以享受傲赢网提供的多项优质免费服务：</font></td> " & _
                      "</tr> " & _
                    "</tbody> " & _
                "</table> " & _
                  "<table border=0 cellspacing=1 cellpadding=5 width=90% align=center> " & _
                    "<tbody> " & _
                      "<tr> " & _
                        "<td width=50 height=60 bgcolor=#e9e9e9><img src=http://www.100allin.com/images/email/up.gif width=48 height=48 /></td> " & _
                        "<td width=408 bgcolor=#e9e9e9><font size=2><strong>免费 发布海空运价信息</strong><br /> " & _
                        "发布运价完全免费,批量上传功能让你更快更多的发布运价</font></td> " & _
                      "</tr> " & _
                      "<tr> " & _
                        "<td height=60 bgcolor=#e9e9e9><img src=http://www.100allin.com/images/email/search.gif width=48 height=48 /></td> " & _
                        "<td bgcolor=#e9e9e9><font size=2><strong>免费 搜索发布货盘信息</strong><br /> " & _
        "几千外贸客户资源,更多更好货盘等你来拿</font></td> " & _
                      "</tr> " & _
                      "<tr> " & _
                        "<td height=60 bgcolor=#e9e9e9><img src=http://www.100allin.com/images/email/chat.gif width=48 height=48 /></td> " & _
                        "<td bgcolor=#e9e9e9><font size=2><strong>即时 与您的商友沟通</strong><br /> " & _
        "聊天工具免下载免安装,随时随地与用户进行沟通</font></td> " & _
                      "</tr> " & _
                    "</tbody> " & _
                  "</table> " & _
                  "<br /> " & _
                "<br /> " & _
                  "<table border=0 cellspacing=0 cellpadding=0 width=90% align=center> " & _
                    "<tbody> " & _
                      "<tr> " & _
                        "<td><font size=2><p>您在使用过程中，如有任何问题或建议，请随时联系傲赢网客户服务人员，我们将热忱为您服务。 <br /> " & _
                        "</p></font></td> " & _
                      "</tr> " & _
                    "</tbody> " & _
                  "</table> " & _
            "<br /> " & _
                "<table border=0 cellspacing=0 cellpadding=0 width=90% align=center> " & _
                    "<tbody> " & _
                      "<tr> " & _
                        "<td align=center><font size=2>【温馨提示】<br /> " & _
                            "<font size=2 color=#CC0000><strong>为保证您正常接收邮件，傲赢网建议您将此邮件地址加入到地址簿中。</strong></font><br /> " & _
                        "</div></td> " & _
                      "</tr> " & _
                    "</tbody> " & _
                "</table></td> " & _
            "</tr> " & _
            "<tr> " & _
              "<td bgcolor=#FF6600 height=50 align=center><font size=2>傲赢网(<a href=http://www.100allin.com>http://www.100allin.com</a>)<br /> " & _
                "客服电话/传真：021-51086987/021-63509508　邮箱：allin@100allin.com</font></td> " & _
            "</tr> " & _
          "</tbody>  " & _
        "</table>  " & _
        "</body> "

        JMail.AddRecipient(email)
        JMail.Priority = 3
        JMail.Send("mail.100allin.com.cn")
        JMail.Close()
        JMail = Nothing

    End Sub
End Class
