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
    End Sub '��ǰ�û������˻�

    Public Sub OrderAddCredit(ByVal u As String, ByVal a As String, ByVal t As String, ByVal o As String, ByVal ou As String, ByVal p As String)
        Dim ck As New check
        Dim userid As String = ck.CheckNumber(u)
        Dim amount As String = ck.CheckNumber(a)
        Dim orderid As String = ck.CheckInput(t)
        Dim billtype As String = ck.CheckNumber(o)
        Dim otherid As String = ck.CheckNumber(ou)
        Dim pay As String = ck.CheckNumber(p)
        OrderAddCreditOriginal(userid, amount, billtype, orderid, otherid, pay)
    End Sub '�κ��û������˻�

    Public Sub OrderAddCreditOriginal(ByVal u As String, ByVal a As String, ByVal t As String, ByVal o As String, ByVal ou As String, ByVal p As String)
        '����˵��
        'uΪ�û�id
        'aΪ�۸��������
        'tΪ�۸�����¼�����
        'oΪ������
        'ouΪ�ͻ�id
        'pΪ�Ƿ�����Ԥ�����ȣ�1Ϊ���ӣ�0Ϊ�����ӣ�Ĭ��Ϊ0

        Dim conn As New data_conn
        Dim ds As New Data.DataSet

        Dim userid As String = u
        Dim amount As String = a '�۸��������
        Dim orderid As String = o '������
        Dim billtype As String = t '�˵��¼�����
        Dim billtypetext As String = "" '�˵��¼�����
        Dim otherid As String = ou
        Dim pay As String = p
        Dim pmtext As String = "" '����Ϣ����

        Dim sql As String = ""

        If p = "0" Then
            sql = "UPDATE TB_ORDER_ACCOUNT SET overage = overage + " & amount & " WHERE userid = " & userid
        Else
            sql = "UPDATE TB_ORDER_ACCOUNT SET credit = credit + " & amount & ",overage = overage + " & amount & " WHERE userid = " & userid
        End If

        conn.mdb_exe(sql) '�����ʻ���Ϣ

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
        conn.mdb_exe(sql) '���°���ͨ����


        Select Case billtype
            Case "1"
                billtypetext = "Ԥ��(֧����)"
                pmtext = "����ʹ��֧������ʽ������" & amount & "ԪԤ��ѣ�֧����������<a href=""/member/order/ali_order.aspx?orderid=" & orderid & """ target=""_blank"">" & orderid
            Case "2"
                billtypetext = "Ԥ��(���л��)"
            Case "3"
                billtypetext = "Ԥ��(��������)"
            Case "4"
                billtypetext = "���ճɹ�<br/>�ݿ۶��շ�"
            Case "5"
                billtypetext = "���׽���<br/>�˻����շ�"
            Case "6"
                billtypetext = "���׽���<br/>������Ϣ��"
            Case "7"
                billtypetext = "���׽���<br/>��ȡ��Ϣ��"
            Case "8"
                billtypetext = "������ֹ<br/>�˻����շ�"
            Case "9"
                billtypetext = "���ճɹ�<br/>�ݿ۶��շ�<br/>(֧����)"
                pmtext = "����ʹ��֧������ʽ������" & amount & "ԪԤ��ѣ�֧����������<a href=""/member/order/ali_order.aspx?orderid=" & orderid & """ target=""_blank"">" & orderid
        End Select

        sql = "INSERT INTO TB_ORDER_ACCOUNT_DETAIL (detail_date,order_code,userid,otherid,status,fee,overage,ispay) "
        sql = sql + " VALUES (getdate(),'" & orderid & "'," & userid & "," & ou & ",'" & billtypetext & "'," & amount & "," & overage & ",0)"
        conn.mdb_exe(sql)

        If pmtext <> "" Then
            Dim pm1 As New pm
            pm1.sendpm("41", userid, pmtext, 1) '��֧����֧�����˷���һ������Ϣ
        End If

    End Sub '�����ʻ�Ԥ��ѣ�������������Ӧ��Ա����

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
    End Function '��õ�ǰ�û��İ����˻�

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
    End Function '����κ��û��İ����˻�

    Public Function GetRequestQueryString(ByVal q As String, ByVal d As String) As String
        Dim outputstring As String = d
        If HttpContext.Current.Request.QueryString(q) IsNot Nothing Then
            If HttpContext.Current.Request.QueryString(q).ToString() <> "" Then
                outputstring = HttpContext.Current.Request.QueryString(q).ToString()
            End If
        End If
        Return outputstring
    End Function '�����ҳ�ַ������� 

    Public Function GetRequestCookies(ByVal c As String, ByVal d As String) As String
        Dim outputstring As String = d
        If HttpContext.Current.Request.Cookies(c) IsNot Nothing Then
            If HttpContext.Current.Request.Cookies(c).Value.ToString() <> "" Then
                outputstring = HttpContext.Current.Request.Cookies(c).Value.ToString()
            End If
        End If
        Return outputstring
    End Function '���ָ��Cookies���� 

End Class
