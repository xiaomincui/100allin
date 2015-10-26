Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail

Public Class EmailSend


    Sub send1(ByVal email As String, ByVal body As String)
        Dim mail As New MailMessage
        mail.From = New MailAddress("100allin@163.vip.com")
        mail.To.Add(New MailAddress("a65127389@hotmail.com"))
        mail.Subject = "主题"
        mail.Body = "asdfasdfasdf"
        Dim client As New SmtpClient
        client.Host = "smtp.vip.163.com"
        client.Port = 25
        client.Credentials = New NetworkCredential("100allin", "53853033")
        client.Send(mail)
    End Sub
    '输入Email地址，发送邮件函数
    Sub send(ByVal email As String, ByVal body As String)
        Dim JMail As New jmail.Message
        JMail.Charset = "gb2312"
        JMail.Logging = True
        JMail.ContentType = "text/html"

        JMail.AddHeader("Originating-IP", System.Web.HttpContext.Current.Request.ServerVariables("REMOTE_ADDR"))
        'JMail.MailServerUserName = "cus@100allin.com"
        'JMail.MailServerPassWord = "888888"
        'JMail.From = "cus@100allin.com" '

        JMail.MailServerUserName = "adv@100allin.com.cn"
        JMail.MailServerPassWord = "takeeasy822822"
        JMail.From = "adv@100allin.com.cn"
        JMail.FromName = "傲赢网"
        JMail.Subject = "傲赢网全体员工向你致敬"
        JMail.Body = body
        'JMail.AddRecipient(email)
        JMail.AddRecipient("hess@100allin.com")
        JMail.Priority = 3
        JMail.Send("mail.100allin.com.cn")
        'JMail.Send("mail.100allin.com")
        JMail.Close()
        JMail = Nothing

        'SendMail("smtp.gmail.com", 465, "100allin@gmail.com", "65127389", "100allin", "100allin@gmail.com", "收信人", "a65127389@hotmail.com", "测试", body, True)

        'SendMail("smtp.vip.163.com", 25, "100allin@163.vip.com", "53853033", "paradini", "100allin@163.vip.com", "收信人", "a65127389@hotmail.com", "测试", body, True)


    End Sub

    Sub SendMail(ByVal sHost As String, ByVal nPort As Integer, ByVal sUserName As String, ByVal sPassword As String, ByVal sFromName As String, ByVal sFromEmail As String, ByVal sToName As String, ByVal sToEmail As String, ByVal sHeader As String, ByVal sMessage As String, ByVal fSSL As Boolean)

        Try
            If sToName.Length = 0 Then
                sToName = sToEmail
            End If
            If (sFromName.Length = 0) Then
                sFromName = sFromEmail
            End If
            Dim Mail As New System.Web.Mail.MailMessage
            Mail.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserver") = sHost
            Mail.Fields("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2

            Mail.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = nPort.ToString()
            If (fSSL) Then
                Mail.Fields("http://schemas.microsoft.com/cdo/configuration/smtpusessl") = "true"
            End If



            If sUserName.Length = 0 Then

                'Ingen auth 

            Else

                Mail.Fields("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1
                Mail.Fields("http://schemas.microsoft.com/cdo/configuration/sendusername") = sUserName
                Mail.Fields("http://schemas.microsoft.com/cdo/configuration/sendpassword") = sPassword
            End If

            Mail.To = sToEmail
            Mail.From = sFromEmail
            Mail.Subject = sHeader
            Mail.Body = sMessage
            Mail.BodyFormat = System.Web.Mail.MailFormat.Html

            System.Web.Mail.SmtpMail.SmtpServer = sHost
            System.Web.Mail.SmtpMail.Send(Mail)
        Catch ex As Exception

        End Try

    End Sub



    '输入SQL语句，对搜索出来User发Email
    Function search(ByVal sql As String, ByVal bodys As String)
        Dim cn As New data_conn
        Dim ds As Data.DataSet
        ds = cn.mdb_ds(sql, "table")

        Dim i As Integer
        Dim body As String
        For i = 0 To ds.Tables("table").Rows.Count - 1
            bodys = bodys.Replace("UserID", ds.Tables("table").Rows(i)("UserID"))
            bodys = bodys.Replace("RealName", ds.Tables("table").Rows(i)("RealName"))
            Dim password As String = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(ds.Tables("table").Rows(i)("UserPassword"), "MD5")
            bodys = bodys.Replace("UserPassword", password)
            body = bodys
            If ds.Tables("table").Rows(i)("IsMail") = True Then
                send(ds.Tables("table").Rows(i)("UserEmail"), body)
            End If
        Next


        Return 0
    End Function




End Class
