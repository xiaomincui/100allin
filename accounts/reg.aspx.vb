Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.Xml

Partial Class accounts_reg
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim returnValue As String

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim cn As New data_conn
        Dim ds As DataSet = cn.mdb_ds("select * from TB_Code", "Code")

        If Not Page.IsPostBack Then
            If Request.ServerVariables("HTTP_REFERER") <> Nothing Then
                Response.Cookies("redirect_url").Value = Request.ServerVariables("HTTP_REFERER").ToString()
            End If
        End If


        Response.Redirect("regnew.aspx?code=" + ds.Tables("Code").Rows(0)(0).ToString())

        If Me.Request("recommendUserID") Is Nothing Then

        Else

            Me.Response.Cookies("recommendUserID").Value = Me.Request("recommendUserID")
            Response.Cookies("recommendUserID").Expires = DateTime.Now.AddDays(365)
        End If


        If Me.Request("UID") Is Nothing Then

        Else

            Me.Response.Cookies("UID").Value = Me.Request("UID")
            Response.Cookies("UID").Expires = DateTime.Now.AddDays(365)
        End If

        If Me.Request("g") Is Nothing Then

        Else

            Me.Response.Cookies("g").Value = Me.Request("g")
            Response.Cookies("g").Expires = DateTime.Now.AddDays(365)
        End If


        '第一次载入页面，显示所有记录
        If Not Page.IsPostBack Then
            '这里开始验证图片的程序
            Response.Cookies.Add(New HttpCookie("CheckCode", ""))

            LoadList1()
            LoadList2(0)
        End If

        '取保存在Cookies中的用户编号id
        Dim id As String = ""


        '定义所有输入框按回车跳到下一格
        Button1.Attributes.Add("onclick", "checkAll();return false;")

        '定义所有输入框按回车跳到下一格
        UserName.Attributes.Add("onkeydown", "KeyDown(event);")
        UserPassword.Attributes.Add("onkeydown", "KeyDown(event);")
        UserPassword2.Attributes.Add("onkeydown", "KeyDown(event);")
        RealName.Attributes.Add("onkeydown", "KeyDown(event);")
        CompanyName.Attributes.Add("onkeydown", "KeyDown(event);")
        CompanyType.Attributes.Add("onkeydown", "KeyDown(event);")
        UserEmail.Attributes.Add("onkeydown", "KeyDown(event);")
        Phone.Attributes.Add("onkeydown", "KeyDown(event);")
        Fax.Attributes.Add("onkeydown", "KeyDown(event);")
        MovePhone.Attributes.Add("onkeydown", "KeyDown(event);")
        Usermsn.Attributes.Add("onkeydown", "KeyDown(event);")
        Userqq.Attributes.Add("onkeydown", "KeyDown(event);")
        Address.Attributes.Add("onkeydown", "KeyDown(event);")
        PostNumber.Attributes.Add("onkeydown", "KeyDown(event);")
        PasswordQuestion.Attributes.Add("onkeydown", "KeyDown(event);")
        PasswordAnswer.Attributes.Add("onkeydown", "KeyDown(event);")


        ddlcity1.Attributes.Add("onclick", "showTip('tipLocusNormal','tipLocusTrue','tipLocusFalse')")
        'ddlcity1.Attributes.Add("onchange", "checkLocus('tipLocusNormal','tipLocusTrue','tipLocusFalse',0)")

        ddlcity2.Attributes.Add("onclick", "showTip('tipLocusNormal','tipLocusTrue','tipLocusFalse')")
        'ddlcity2.Attributes.Add("onchange", "checkLocus('tipLocusNormal','tipLocusTrue','tipLocusFalse',0)")
        'VerifyCode.Attributes.Add("onkeydown", "KeyDown(event);")
    End Sub

    'alert弹窗
    Sub MessageBox(ByVal strKey As String, ByVal strInfo As String)
        If (Not ClientScript.IsClientScriptBlockRegistered(strKey)) Then
            Dim strjs As String = "alert('" + strInfo + "');"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), strKey, strjs, True)
        End If
    End Sub


    '这个函数负责把字符串输出给客户端的javascript函数
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Try
            '等待0.1秒显示结果，给予服务器缓冲时间，并增强浏览效果
            System.Threading.Thread.Sleep(300)

            Dim p() As String = returnValue.Split("|")
            If p(0) = "username" Then
                '取表单上的用户名
                Dim ck As New check
                Dim name As String
                name = p(1)

                '检查用户名是否被注册过
                Dim cn As New data_conn3
                Dim sql As String = ""
                sql = sql + "select * "
                sql = sql + "from TB_User "
                sql = sql + "where UserName = '" & ck.CheckInput(name) & "'"
                Dim ds As New Data.DataSet
                ds = cn.mdb_ds(sql, "T_User")

                If ds.Tables("T_User").Rows.Count > 0 Then
                    Return "failed"
                Else
                    Return "success"
                End If
            ElseIf p(0) = "verifycode" Then
                If String.Compare(p(1).ToString().Trim(), p(2).ToString().Trim(), True) <> 0 Then
                    Return "failed"
                Else
                    Return "success"
                End If

            End If

        Catch ex As Exception
            Return ex.ToString
        End Try

    End Function

    '这个函数读取从客户端callback来的字符串，读取后在服务器端放置在容器eventArgument内
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        returnValue = eventArgument
    End Sub

    Protected Sub Button1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.ServerClick
        'If Request.Cookies("CheckCode") Is Nothing Then
        '    Label1.Text = "您的浏览器设置已被禁用 Cookies，您必须设置浏览器允许使用 Cookies 选项后才能使用本系统。"
        '    Return
        'End If
        'If String.Compare(Request.Cookies("CheckCode").Value, VerifyCode.Value.ToString().Trim(), True) <> 0 Then
        '    Label1.Text = "<font color=red>对不起，验证码错误！</font>"
        '    Return
        'Else
        '    Label1.Text = "<font color=green>恭喜，验证码输入正确！</font>"
        'End If
        Response.Redirect("/")
    End Sub

    Protected Sub Button2_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.ServerClick
        Response.Redirect("/")
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        If UserName.Value.ToString <> "" And UserPassword.Value.ToString <> "" And UserEmail.Value.ToString <> "" And RealName.Value.ToString <> "" And CompanyName.Value.ToString <> "" And CompanyType.Value.ToString <> "" And Phone.Value.ToString <> "" And ddlcity1.SelectedItem.Text <> "请选择" And ddlcity2.SelectedItem.Text <> "请选择" Then



            '头像上传
            Dim HeadURL As String = " 0 "
            Dim recommendUserID As String
            If Me.Request.Cookies("recommendUserID") Is Nothing Then
                recommendUserID = "0"
            Else
                If Request.Cookies("recommendUserID").Value = "" Then
                    recommendUserID = "0"
                Else
                    recommendUserID = Request.Cookies("recommendUserID").Value

                End If
            End If






            If Me.Request.Cookies("UID") Is Nothing Then

            Else
                If Request.Cookies("UID").Value = "" Then

                Else

                    'Dim Uidcn As New data_conn

                    'Dim Uidds As DataSet = Uidcn.mdb_ds("select UserID from TB_User where UCenterHomeUid=" + Request.Cookies("UID").Value, "uid")
                    'recommendUserID = Uidds.Tables("uid").Rows(0)(0).ToString
                    Dim Uidcn As New data_conn

                    Dim Uidds As DataSet = Uidcn.mdb_ds("select UserID from TB_User where UCenterHomeUid=" + Request.Cookies("UID").Value, "uid")
                    If Uidds.Tables("uid").Rows.Count = "1" Then
                        recommendUserID = Uidds.Tables("uid").Rows(0)(0).ToString

                        Dim mycn As New mysqldata_conn
                        mycn.mdb_exe("update uchome_space set credit=credit+10 where uid=" + Request.Cookies("UID").Value)
                    End If

                End If
            End If








            Dim nowlong As String = ""
            nowlong = Year(Now()) & "-" & Right("0" & Month(Now()), 2) & "-" & Right("0" & Day(Now()), 2) & "&nbsp;&nbsp;" & Right("0" & Hour(Now()), 2) & ":" & Right("0" & Minute(Now()), 2) & ":" & Right("0" & Second(Now()), 2)

            Dim ck As New check

            Dim cn As New data_conn
            Dim sql As String = ""
            sql = sql & "INSERT INTO "
            sql = sql & "TB_User "
            sql = sql & "("
            sql = sql & "UserName, "
            sql = sql & "UserPassword, "
            sql = sql & "UserEmail, "
            sql = sql & "UserPoint, "
            sql = sql & "RealName, "
            sql = sql & "CompanyName, "
            sql = sql & "CompanyType, "

            sql = sql & "Address, "
            sql = sql & "PostNumber, "
            sql = sql & "Phone, "
            sql = sql & "Phone2, "

            sql = sql & "Fax, "
            sql = sql & "MovePhone, "
            sql = sql & "Usermsn, "
            sql = sql & "Userqq, "
            sql = sql & "Regtime, "
            sql = sql & "pquestion, "
            sql = sql & "panswer, "
            'sql = sql & "CurrentLogin, "
            sql = sql & "IfPass, "
            sql = sql & "ifvip, "
            sql = sql & "ifmanage, "
            sql = sql & "HeadURL, "
            sql = sql & "recommendUserID, "
            sql = sql & "sign, "
            sql = sql & "introduction, "
            sql = sql & "Login2_Locus1, "
            sql = sql & "Login2_Locus2, "
            sql = sql & "User_Level "
            sql = sql & ")"
            sql = sql & "VALUES "
            sql = sql & "("
            sql = sql & "'" & ck.CheckInput(UserName.Value.ToString) & "', "
            sql = sql & "'" & ck.CheckInput(UserPassword.Value.ToString) & "', "
            sql = sql & "'" & ck.CheckInput(UserEmail.Value.ToString) & "', "
            sql = sql & "0, "
            sql = sql & "'" & ck.CheckInput(RealName.Value.ToString) & "', "
            sql = sql & "'" & ck.CheckInput(CompanyName.Value.ToString) & "', "
            sql = sql & ck.CheckInput(CompanyType.Value.ToString) & ", "

            sql = sql & "'" & ck.CheckInput(Address.Value.ToString) & "', "
            sql = sql & "'" & ck.CheckInput(PostNumber.Value.ToString) & "', "

            sql = sql & "'" & ck.CheckInput(Phone.Value.ToString) & "', "

            sql = sql & "'" & ck.CheckInput(Phone2.Value.ToString) & "', "





            sql = sql & "'" & ck.CheckInput(Fax.Value.ToString) & "', "
            sql = sql & "'" & ck.CheckInput(MovePhone.Value.ToString) & "', "
            sql = sql & "'" & ck.CheckInput(Usermsn.Value.ToString) & "', "
            sql = sql & "'" & ck.CheckInput(Userqq.Value.ToString) & "', "
            sql = sql & "'" & ck.CheckInput(Now.ToString) & "', "
            sql = sql & "'" & ck.CheckInput(PasswordQuestion.Value.ToString) & "', "
            sql = sql & "'" & ck.CheckInput(PasswordAnswer.Value.ToString) & "', "
            'sql = sql & "'" & nowlong & "', "
            sql = sql & "0, "
            sql = sql & "1, "
            sql = sql & "0, "
            sql = sql & HeadURL & ", "
            sql = sql & recommendUserID & ", "
            sql = sql & "'" + ck.CheckInput(Me.txtsign.Value) + "',"
            sql = sql & "'" + ck.CheckInput(txtintroduction.Value) + "',"
            sql = sql & "'" + ck.CheckInput(Me.ddlcity1.SelectedItem.Text) + "',"
            sql = sql & "'" + ck.CheckInput(Me.ddlcity2.SelectedItem.Text) + "',"
            sql = sql & "1"
            sql = sql & ")"

            cn.mdb_exe(sql)

            sql = "SELECT * FROM TB_User WHERE UserName = '" & ck.CheckInput(UserName.Value.ToString) & "'"
            Dim ds As New DataSet
            ds = cn.mdb_ds(sql, "user")

            If ds.Tables("user").Rows.Count <> 0 Then


                Try
                    Dim p As New points
                    p.AddNewPoints(ds.Tables("user").Rows(0)("UserID").ToString)
                Catch ex As Exception

                End Try

                Dim userid As String = ds.Tables("user").Rows(0)("UserID").ToString
                Dim usernm As String = ds.Tables("user").Rows(0)("UserName").ToString
                Dim ifvip As String = ds.Tables("user").Rows(0)("ifvip").ToString
                Dim ifmanage As String = ds.Tables("user").Rows(0)("ifmanage").ToString

                Response.Cookies("user_id").Value = userid
                Response.Cookies("user_name").Value = Server.UrlEncode(usernm)
                Response.Cookies("ifvip").Value = ifvip
                Response.Cookies("ifmanage").Value = ifmanage

                Response.Cookies("user_id").Expires = DateTime.Now.AddDays(365)
                Response.Cookies("user_name").Expires = DateTime.Now.AddDays(365)
                Response.Cookies("ifvip").Expires = DateTime.Now.AddDays(365)
                Response.Cookies("ifmanage").Expires = DateTime.Now.AddDays(365)


                If recommendUserID <> "0" Then
                    cn.mdb_exe("insert into T_FRIEND (UID,FID) values (" + userid + "," + recommendUserID + ")")
                    cn.mdb_exe("insert into T_FRIEND (UID,FID) values (" + recommendUserID + "," + userid + ")")
                    Dim mark As New Mark
                    mark.MarkOperate(recommendUserID, 10, "推荐会员", userid)
                    'Dim dsmark As DataSet = cn.mdb_ds("select marks from TB_User where UserID=" + recommendUserID, "mark")
                    'cn.mdb_exe("update TB_User set marks=" + (CInt(dsmark.Tables("mark").Rows(0)("marks")) + 10).ToString + " where UserId=" + recommendUserID)
                End If


                If (Me.FileUpload1.FileName.ToString() <> "") Then
                    Dim filepath As String
                    filepath = Server.MapPath("/member/Head/") + userid + "(old).jpg"
                    FileUpload1.SaveAs(filepath)
                    Dim thumbnailimage As New ThumbnailImage
                    thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("/member/Head/") + userid + ".jpg", 70, 70)
                    'Me.Response.Write("update TB_User set HeadURL=1 where UserId=" + userid)
                    cn.mdb_exe("update TB_User set HeadURL=1 where UserId=" + userid)
                End If





                'mysql注册
                Dim mysqlcn As New mysqldata_conn
                Dim dscount As DataSet = mysqlcn.mdb_ds("select * from uc_members where username='" + usernm + "'", "ucenter")

                If dscount.Tables("ucenter").Rows.Count = 0 Then
                    Dim r As New Random
                    Dim salt As String = r.Next().ToString().Substring(0, 6)
                    Dim username As String = usernm
                    Dim password As String = MD5(MD5(ds.Tables("user").Rows(0)("UserPassword").ToString) + salt)
                    Dim email As String = ds.Tables("user").Rows(0)("UserEmail").ToString
                    Dim myid As String = ""
                    Dim myidkey As String = ""
                    Dim regip As String = Page.Request.UserHostAddress
                    Dim regdate As String = UnixTimestamp()
                    Dim lastloginip As String = "0"
                    Dim lastlogintime As String = "0"



                    Dim id As String = Me.insert(username, "8fc24ae194289b94e36272a5f9882611", email, myid, myidkey, regip, regdate, lastloginip, lastlogintime, "594882")

                    If id <> "" Then
                        mysqlcn.mdb_exe("insert into uchome_member (uid,username,password) values (" + id + ",'','" + MD5(id + "|" + UnixTimestamp()) + "')")
                        mysqlcn.mdb_exe("insert into uc_memberfields (uid,blacklist) values (" + id + ",'')")

                        Dim myemail As String
                        Dim qq As String
                        Dim msn As String
                        If ds.Tables("user").Rows(0)("UserEmail").ToString <> "" Then
                            myemail = ds.Tables("user").Rows(0)("UserEmail").ToString
                        Else
                            myemail = ""
                        End If
                        If ds.Tables("user").Rows(0)("Userqq").ToString <> "" Then
                            qq = ds.Tables("user").Rows(0)("Userqq").ToString
                        Else
                            qq = ""
                        End If
                        If ds.Tables("user").Rows(0)("Usermsn").ToString <> "" Then
                            msn = ds.Tables("user").Rows(0)("Usermsn").ToString
                        Else
                            msn = ""
                        End If

                        mysqlcn.mdb_exe("insert into uchome_spacefield (uid,email,qq,msn,blood,birthprovince,birthcity,resideprovince,residecity,note,spacenote,authstr,theme,css,privacy,friend,feedfriend,sendmail) values (" + id + ",'" + myemail + "','" + qq + "','" + msn + "','','','','','','','','','','','','','','')")


                        '插入实名
                        Dim namestatus As String = 0
                        'If ck.CheckInput(RealName.Value.ToString) <> "" Then
                        'namestatus = 1
                        'End If
                        '实名
                        'mysqlcn.mdb_exe("insert into uchome_space (uid,groupid,username,name,namestatus,domain) values (" + id + ",5,'" + username + "','" + ck.CheckInput(RealName.Value.ToString) + "'," + namestatus + ",'')")
                        mysqlcn.mdb_exe("insert into uchome_space (uid,groupid,username,name,namestatus,domain,dateline,ip) values (" + id + ",5,'" + username + "',''," + namestatus + ",''," + UnixTimestamp() + ",'" + Page.Request.UserHostAddress + "')")
                        cn.mdb_exe("update TB_User set UCenterHomeUid=" + id + " where UserId=" + userid)


                        '在ucenter中添加推荐好友
                        If Me.Request.Cookies("UID") Is Nothing Then

                        Else
                            If Request.Cookies("UID").Value = "" Then

                            Else



                                Dim gid As String = "0"
                                If Me.Request.Cookies("g") Is Nothing Then

                                Else
                                    If Request.Cookies("g").Value = "" Then

                                    Else
                                        gid = Request.Cookies("g").Value
                                        Try
                                            Dim g As Integer = Convert.ToInt32(gid)

                                            If (g > 0 And g < 8) Then
                                                gid = g.ToString
                                            Else
                                                gid = "0"
                                            End If
                                        Catch ex As Exception
                                            gid = "0"
                                        End Try

                                    End If

                                End If

                                Dim myUidds As DataSet = mysqlcn.mdb_ds("select username from uc_members where uid=" + Request.Cookies("UID").Value, "uid")
                                mysqlcn.mdb_exe("insert into uchome_friend (uid,fuid,fusername,status,gid,note,dateline) values (" + id + "," + Request.Cookies("UID").Value + ",'" + myUidds.Tables("uid").Rows(0)(0).ToString + "',1,0,''," + UnixTimestamp() + ")")
                                mysqlcn.mdb_exe("insert into uchome_friend (uid,fuid,fusername,status,gid,note,dateline) values (" + Request.Cookies("UID").Value + "," + id + ",'" + username + "',1," + gid + ",''," + UnixTimestamp() + ")")
                                mysqlcn.mdb_exe("insert into uc_friends (uid,friendid,direction,comment) values (" + id + "," + Request.Cookies("UID").Value + ",3,'')")
                                mysqlcn.mdb_exe("insert into uc_friends (uid,friendid,direction,comment) values (" + Request.Cookies("UID").Value + "," + id + ",3,'')")
                            End If
                        End If
                    End If


                End If

                'DataSet dscount = mysqlcn.mdb_ds("select * from uc_members where username='" + ds.Tables["user"].Rows[i]["UserName"] + "'", "ucenter");
                'if (dscount.Tables["ucenter"].Rows.Count == 0)
                '{
                '    Random r = new Random();
                '    string salt = r.Next().ToString().Substring(0, 6);

                '    string username = ds.Tables["user"].Rows[i]["UserName"].ToString();







                '    string password = MD5(MD5(ds.Tables["user"].Rows[i]["UserPassword"].ToString()) + salt);
                '    string email = ds.Tables["user"].Rows[i]["UserEmail"].ToString();
                '    string myid = "";
                '    string myidkey = "";
                '    string regip = "127.0.0.1";
                '    string regdate = UnixTimestamp();
                '    string lastloginip = "0";
                '    string lastlogintime = "0";

                '    //mysqlcn.mdb_exe("insert into uc_members (username,password,email,myid,myidkey,regip,regdate,lastloginip,lastlogintime,salt) values ('','','','','','',,,,'')");


                '    string id = this.insert(username, password, email, myid, myidkey, regip, regdate, lastloginip, lastlogintime, salt);
                '    if (id != "")
                '    {
                '        mysqlcn.mdb_exe("insert into uchome_member (uid,username,password) values (" + id + ",'','" + MD5(id + "|" + UnixTimestamp()) + "')");
                '        mysqlcn.mdb_exe("insert into uc_memberfields (uid,blacklist) values (" + id + ",'')");
                '    }

                '}























            End If

            Response.Cookies("useremail").Value = UserEmail.Value.ToString

            Try
                SendEmail(UserName.Value.ToString, UserPassword.Value.ToString, UserEmail.Value.ToString, "GB")
            Catch ex As Exception

                'If CompanyType.Value.ToString = "2" Then
                '    Response.Redirect("login_2_edit.aspx")
                'Else
                '    Response.Redirect("/member/regsuccess.aspx")
                'End If
                Response.Redirect("/member/regsuccess.aspx")
            End Try
        End If
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
        JMail.MailServerUserName = "cus@100allin.com"
        JMail.MailServerPassWord = "888888"
        JMail.From = "cus@100allin.com"
        JMail.FromName = "环球运费网"
        JMail.Subject = "您已成功注册环球运费网会员"
        JMail.Body = "<body> " & _
        "<table border=0 cellspacing=3 cellpadding=0 width=540 bgcolor=#F0690F align=center> " & _
          "<tbody> " & _
            "<tr> " & _
              "<td bgcolor=#ffffff> " & _
           "<table width=90% height=80 border=0 align=center cellpadding=0 cellspacing=0> " & _
                "<tbody> " & _
                  "<tr> " & _
                    "<td> " & _
            "<a href=http://www.100allin.com target=_blank><img border=0 src=http://www.100allin.com/images/logo.gif width=182 height=72 /></a> " & _
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
                            "<p>感谢您注册环球运费网，以下是您注册的详细信息：</p></font> " & _
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
                        "<td width=468><font size=2>注册成功后，您可以享受环球运费网提供的多项优质免费服务：</font></td> " & _
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
                        "<td><font size=2><p>您在使用过程中，如有任何问题或建议，请随时联系环球运费网客户服务人员，我们将热忱为您服务。 <br /> " & _
                        "</p></font></td> " & _
                      "</tr> " & _
                    "</tbody> " & _
                  "</table> " & _
            "<br /> " & _
                "<table border=0 cellspacing=0 cellpadding=0 width=90% align=center> " & _
                    "<tbody> " & _
                      "<tr> " & _
                        "<td align=center><font size=2>【温馨提示】<br /> " & _
                            "<font size=2 color=#CC0000><strong>为保证您正常接收邮件，环球运费网建议您将此邮件地址加入到地址簿中。</strong></font><br /> " & _
                        "</div></td> " & _
                      "</tr> " & _
                    "</tbody> " & _
                "</table></td> " & _
            "</tr> " & _
            "<tr> " & _
              "<td bgcolor=#FF6600 height=50 align=center><font size=2>环球运费网(<a href=http://www.100allin.com>http://www.100allin.com</a>)<br /> " & _
                "客服电话/传真：021-53853033/3022　邮箱：allin@100allin.com</font></td> " & _
            "</tr> " & _
          "</tbody>  " & _
        "</table>  " & _
        "</body> "

        JMail.AddRecipient(email)
        JMail.Priority = 3
        JMail.Send("mail.100allin.com")
        JMail.Close()
        JMail = Nothing

        'If CompanyType.Value.ToString = "2" Then
        '    Response.Redirect("login_2_edit.aspx")
        'Else
        '    Response.Redirect("/member/regsuccess.aspx")
        'End If
        Response.Redirect("/member/regsuccess.aspx")
    End Sub


    Function UnixTimestamp() As String
        Dim dtStart As DateTime = TimeZone.CurrentTimeZone.ToLocalTime(New DateTime(1970, 1, 1))
        Dim dtNow As DateTime = DateTime.Parse(DateTime.Now.ToString())
        Dim toNow As TimeSpan = dtNow.Subtract(dtStart)
        Dim timeStamp As String = toNow.Ticks.ToString()
        Return timeStamp.Substring(0, timeStamp.Length - 7)
    End Function


    Function MD5(ByVal str As String) As String
        Dim b() As Byte = System.Text.Encoding.Default.GetBytes(str)
        b = New System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b)
        Dim ret As String = ""
        Dim i As Integer
        For i = 0 To b.Length - 1
            ret += b(i).ToString("x").PadLeft(2, "0")
        Next
        Return ret
    End Function

    'public static string UnixTimestamp()
    '    {
    '        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
    '        DateTime dtNow = DateTime.Parse(DateTime.Now.ToString());
    '        TimeSpan toNow = dtNow.Subtract(dtStart);
    '        string timeStamp = toNow.Ticks.ToString();
    '        return timeStamp.Substring(0, timeStamp.Length - 7);
    '    }

    '    public static string MD5(string str)
    '    {
    '        byte[] b = System.Text.Encoding.Default.GetBytes(str);
    '        b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
    '        string ret = "";
    '        for (int i = 0; i < b.Length; i++)
    '        {
    '            ret += b[i].ToString("x").PadLeft(2, '0');
    '        }
    '        return ret;
    '    }
    Function insert(ByVal username As String, ByVal password As String, ByVal email As String, ByVal myid As String, ByVal myidkey As String, ByVal regip As String, ByVal regdate As String, ByVal lastloginip As String, ByVal lastlogintime As String, ByVal salt As String) As String
        Dim sql As String = ""
        Try
            Dim connection1 As New MySqlConnection
            connection1 = New MySqlConnection("Database=allin;Data Source = localhost;User Id = sasa;Password = takeeasy822822")
            Dim mysqlcn As New mysqldata_conn
            Dim command1 As New MySqlCommand
            connection1.Open()
            Dim da1 As New MySqlDataAdapter
            Dim ds As New DataSet
            sql = "insert into uc_members (username,password,email,myid,myidkey,regip,regdate,lastloginip,lastlogintime,salt) values ('" + username + "','" + password + "','" + email + "','" + myid + "','" + myidkey + "','" + regip + "'," + regdate + "," + lastloginip + "," + lastlogintime + ",'" + salt + "')"

            command1 = New MySqlCommand(sql, connection1)
            command1.ExecuteNonQuery()
            command1 = New MySqlCommand("SELECT LAST_INSERT_ID()", connection1)
            da1.SelectCommand = command1


            da1.Fill(ds, "aa")
            connection1.Close()
            Return ds.Tables("aa").Rows(0)(0).ToString()
        Catch ex As Exception
            Me.Response.Write(sql)
            Return ""
        End Try
    End Function
















    Protected Sub LoadList1()
        ddlcity1.Items.Clear()

        Dim doc As New XmlDocument
        doc.Load(Server.MapPath("../xml/Provinces.xml"))
        'Dim node As XmlNodeList = doc.SelectNodes("Cities")(0).ChildNodes
        Dim node As XmlNodeList = doc.SelectNodes("Provinces")(0).ChildNodes
        For i As Integer = 0 To node.Count - 1
            Dim pp As New ListItem(node(i).InnerText, node(i).Attributes("ID").Value)
            ddlcity1.Items.Add(pp)
        Next

    End Sub

    Protected Function LoadList1search(ByVal str As Integer) As String
        Dim doc As New XmlDocument
        doc.Load(Server.MapPath("../xml/Provinces.xml"))
        Dim node As XmlNodeList = doc.SelectNodes("Provinces")(0).ChildNodes
        For i As Integer = 0 To node.Count - 1
            If (node(i).InnerText = str) Then
                Return node(i).Attributes("ID").Value
            End If
        Next
        Return ""
    End Function

    Protected Sub LoadList2(ByVal ID As Integer)
        ddlcity2.Items.Clear()


        Dim doc As New XmlDocument
        doc.Load(Server.MapPath("../xml/Cities.xml"))


        Dim node As XmlNodeList = doc.SelectNodes("Cities")(0).ChildNodes


        Dim flag As String
        For i As Integer = 0 To node.Count - 1
            If node(i).Attributes("PID").Value = ID.ToString Or node(i).Attributes("PID").Value = 0 Then
                If ddlcity2.Items.Count = 0 Then
                    flag = node(i).Attributes("ID").Value
                End If
                Dim pp As New ListItem(node(i).InnerText, node(i).Attributes("ID").Value)
                ddlcity2.Items.Add(pp)
            End If
        Next

        'LoadList3(flag)
    End Sub

    Protected Sub LoadList3(ByVal ID As Integer)
        ddlcity3.Items.Clear()


        Dim doc As New XmlDocument
        doc.Load(Server.MapPath("../xml/Districts.xml"))


        Dim node As XmlNodeList = doc.SelectNodes("Districts")(0).ChildNodes



        For i As Integer = 0 To node.Count - 1
            If (node(i).Attributes("CID").Value = ID.ToString Or node(i).Attributes("CID").Value = 0) Then
                Dim pp As New ListItem(node(i).InnerText, node(i).Attributes("ID").Value)
                ddlcity3.Items.Add(pp)
            End If


        Next

        If ddlcity3.Items.Count = 1 And ddlcity2.SelectedItem.Text <> "请选择" Then
            ddlcity3.Items.Add(ddlcity2.SelectedItem.Text)
        End If

    End Sub



    Protected Sub ddlcity1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcity1.SelectedIndexChanged
        LoadList2(ddlcity1.SelectedValue)
        ddlcity1.Focus()

        If ddlcity1.SelectedValue <> 0 And ddlcity2.SelectedValue <> 0 Then
            tipLocusNormal.Style.Value = "display:none;"
            tipLocusTrue.Style.Value = ""
            tipLocusFalse.Style.Value = "display:none;"
        Else
            tipLocusNormal.Style.Value = "display:none;"
            tipLocusTrue.Style.Value = "display:none;"
            tipLocusFalse.Style.Value = ""
        End If
        


    End Sub

    Protected Sub ddlcity2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcity2.SelectedIndexChanged
        LoadList3(ddlcity2.SelectedValue)

        If ddlcity1.SelectedValue <> 0 And ddlcity2.SelectedValue <> 0 Then
            tipLocusNormal.Style.Value = "display:none;"
            tipLocusTrue.Style.Value = ""
            tipLocusFalse.Style.Value = "display:none;"
        Else
            tipLocusNormal.Style.Value = "display:none;"
            tipLocusTrue.Style.Value = "display:none;"
            tipLocusFalse.Style.Value = ""
        End If

    End Sub


End Class
