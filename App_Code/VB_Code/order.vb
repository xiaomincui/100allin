Imports Microsoft.VisualBasic

Public Class order
    Public Sub OrderAddCredit(ByVal a As String, ByVal t As String, ByVal o As String, ByVal ou As String, ByVal p As String)
        Dim ck As New check
        Dim userid As String = ck.CheckNumber(GetRequestCookies("user_id", "0"))
        Dim amount As String = ck.CheckNumber(a)
        Dim orderid As String = ck.CheckInput(o)
        Dim billtype As String = ck.CheckNumber(t)
        Dim otherid As String = ck.CheckNumber(ou)
        Dim pay As String = ck.CheckNumber(p)
        OrderAddCreditOriginal(userid, amount, billtype, orderid, otherid, pay)
    End Sub '当前用户调整账户

    Public Sub OrderAddCredit(ByVal u As String, ByVal a As String, ByVal t As String, ByVal o As String, ByVal ou As String, ByVal p As String)
        Dim ck As New check
        Dim userid As String = ck.CheckNumber(u)
        Dim amount As String = ck.CheckNumber(a)
        Dim orderid As String = ck.CheckInput(t)
        Dim billtype As String = ck.CheckNumber(o)
        Dim otherid As String = ck.CheckNumber(ou)
        Dim pay As String = ck.CheckNumber(p)
        OrderAddCreditOriginal(userid, amount, billtype, orderid, otherid, pay)
    End Sub '任何用户调整账户

    Public Sub OrderAddCreditOriginal(ByVal u As String, ByVal a As String, ByVal t As String, ByVal o As String, ByVal ou As String, ByVal p As String)
        '参数说明
        'u为用户id
        'a为价格调整数量
        't为价格调整事件类型
        'o为订单号
        'ou为客户id
        'p为是否增加预付款额度，1为增加，0为不增加，默认为0

        Dim conn As New data_conn
        Dim ds As New Data.DataSet

        Dim userid As String = u
        Dim amount As String = a '价格调整数量
        Dim orderid As String = o '订单号
        Dim billtype As String = t '账单事件类型
        Dim billtypetext As String = "" '账单事件类型
        Dim otherid As String = ou
        Dim pay As String = p
        Dim pmtext As String = "" '短消息内容

        Dim sql As String = ""

        If p = "0" Then
            sql = "UPDATE TB_ORDER_ACCOUNT SET overage = overage + " & amount & " WHERE userid = " & userid
        Else
            sql = "UPDATE TB_ORDER_ACCOUNT SET credit = credit + " & amount & ",overage = overage + " & amount & " WHERE userid = " & userid
        End If

        conn.mdb_exe(sql) '更新帐户信息

        sql = "SELECT * FROM TB_ORDER_ACCOUNT WHERE userid = " & userid
        ds = conn.mdb_ds(sql, "account")

        Dim credit As Double = 0
        Dim overage As Double = 0
        Dim level As Integer = 0

        If ds.Tables("account").Rows.Count > 0 Then
            credit = Convert.ToDouble(ds.Tables("account").Rows(0)("credit").ToString)
            overage = Convert.ToDouble(ds.Tables("account").Rows(0)("overage").ToString)
        End If

        Select Case credit
            Case 0 To 2000
                level = 1
            Case 2000 To 4999
                level = 2
            Case 5000 To 9999
                level = 3
            Case 10000 To 19999
                level = 4
            Case 20000 To 100000
                level = 5
        End Select

        sql = "UPDATE TB_USER SET star_allin = " & level.ToString & " WHERE userid = " & userid
        conn.mdb_exe(sql) '更新安运通级别


        Select Case billtype
            Case "1"
                billtypetext = "预存(支付宝)"
                pmtext = "您已使用支付宝方式增加了" & amount & "元预存费，支付宝订单号<a href=""/member/order/ali_order.aspx?orderid=" & orderid & """ target=""_blank"">" & orderid
            Case "2"
                billtypetext = "预存(银行汇款)"
            Case "3"
                billtypetext = "预存(网上银行)"
            Case "4"
                billtypetext = "订舱成功<br/>暂扣订舱费"
            Case "5"
                billtypetext = "交易结束<br/>退还订舱费"
            Case "6"
                billtypetext = "交易结束<br/>奖励信息费"
            Case "7"
                billtypetext = "交易结束<br/>收取信息费"
            Case "8"
                billtypetext = "交易中止<br/>退还订舱费"
            Case "9"
                billtypetext = "订舱成功<br/>暂扣订舱费<br/>(支付宝)"
                pmtext = "您已使用支付宝方式增加了" & amount & "元预存费，支付宝订单号<a href=""/member/order/ali_order.aspx?orderid=" & orderid & """ target=""_blank"">" & orderid
        End Select

        sql = "INSERT INTO TB_ORDER_ACCOUNT_DETAIL (detail_date,order_code,userid,otherid,status,fee,overage,ispay) "
        sql = sql + " VALUES (getdate(),'" & orderid & "'," & userid & "," & ou & ",'" & billtypetext & "'," & amount & "," & overage & ",0)"
        conn.mdb_exe(sql)

        If pmtext <> "" Then
            Dim pm1 As New pm
            pm1.sendpm("41", userid, pmtext, 1) '给支付宝支付的人发送一条短消息
        End If

    End Sub '增加帐户预存费，增加余额，调整相应会员级别

    Public Function OrderGetAliAccount() As String
        Dim ck As New check
        Dim userid As String = ck.CheckNumber(GetRequestCookies("user_id", "0"))
        Dim ali_account = ""

        Dim conn As New data_conn
        Dim ds As New Data.DataSet

        Dim sql As String = ""
        sql = "SELECT * FROM TB_USER WHERE userid = " & userid
        ds = conn.mdb_ds(sql, "user")

        ali_account = ds.Tables("user").Rows(0)("ali_account").ToString

        Return ali_account
    End Function '获得当前用户的阿里账户

    Public Function OrderGetAliAccount(ByVal u As String) As String
        Dim ck As New check
        Dim userid As String = ck.CheckNumber(u)
        Dim ali_account = ""

        Dim conn As New data_conn
        Dim ds As New Data.DataSet

        Dim sql As String = ""
        sql = "SELECT * FROM TB_USER WHERE userid = " & userid
        ds = conn.mdb_ds(sql, "user")

        ali_account = ds.Tables("user").Rows(0)("ali_account").ToString

        Return ali_account
    End Function '获得任何用户的阿里账户

    Public Function GetRequestQueryString(ByVal q As String, ByVal d As String) As String
        Dim outputstring As String = d
        If HttpContext.Current.Request.QueryString(q) IsNot Nothing Then
            If HttpContext.Current.Request.QueryString(q).ToString() <> "" Then
                outputstring = HttpContext.Current.Request.QueryString(q).ToString()
            End If
        End If
        Return outputstring
    End Function '获得网页字符串参数 

    Public Function GetRequestCookies(ByVal c As String, ByVal d As String) As String
        Dim outputstring As String = d
        If HttpContext.Current.Request.Cookies(c) IsNot Nothing Then
            If HttpContext.Current.Request.Cookies(c).Value.ToString() <> "" Then
                outputstring = HttpContext.Current.Request.Cookies(c).Value.ToString()
            End If
        End If
        Return outputstring
    End Function '获得指定Cookies参数 

End Class
