Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Text
Imports System.Security.Cryptography

Public Class AliPay

    Public Shared Function GetMD5(ByVal s As String) As String

        Dim md5 As MD5 = New MD5CryptoServiceProvider()
        Dim t As Byte() = md5.ComputeHash(Encoding.GetEncoding("utf-8").GetBytes(s))
        Dim sb As New StringBuilder(32)
        For i As Integer = 0 To t.Length - 1
            sb.Append(t(i).ToString("x").PadLeft(2, "0"c))
        Next
        Return sb.ToString()
    End Function

    Public Shared Function BubbleSort(ByVal r As String()) As String()

        Dim i As Integer, j As Integer
        '交换标志 
        Dim temp As String

        Dim exchange As Boolean

        For i = 0 To r.Length - 1
            '最多做R.Length-1趟排序 
            exchange = False
            '本趟排序开始前，交换标志应为假 
            For j = r.Length - 2 To i Step -1
                If System.[String].CompareOrdinal(r(j + 1), r(j)) < 0 Then
                    '交换条件 
                    temp = r(j + 1)
                    r(j + 1) = r(j)
                    r(j) = temp

                    '发生了交换，故将交换标志置为真 
                    exchange = True
                End If
            Next

            If Not exchange Then
                '本趟排序未发生交换，提前终止算法 
                Exit For

            End If
        Next
        Return r
    End Function

    Public Function CreatUrl(ByVal gateway As String, ByVal service As String, ByVal partner As String, ByVal sign_type As String, ByVal _input_charset As String, ByVal out_order_no As String, _
    ByVal subject As String, ByVal seller_email As String, ByVal buyer_email As String, ByVal out_order_dt As String, ByVal order_from As String, ByVal goods_url As String, _
    ByVal memo As String, ByVal amount As String, ByVal op_type As String, ByVal key As String, ByVal return_url As String, ByVal notify_url As String) As String
        Dim i As Integer

        '构造数组； 
        Dim Oristr As String() = {"service=" & service, "partner=" & partner, "_input_charset=" & _input_charset, "subject=" & subject, "out_order_no=" & out_order_no, "seller_email=" & seller_email, _
        "buyer_email=" & buyer_email, "notify_url=" & notify_url, "return_url=" & return_url, "out_order_dt=" & out_order_dt, "order_from=" & order_from, "goods_url=" & goods_url, _
        "memo=" & memo, "amount=" & amount, "op_type=" & op_type}

        '进行排序； 
        Dim Sortedstr As String() = BubbleSort(Oristr)


        '构造待md5摘要字符串 ； 

        Dim prestr As New StringBuilder()

        For i = 0 To Sortedstr.Length - 1
            If i = Sortedstr.Length - 1 Then

                prestr.Append(Sortedstr(i))
            Else

                prestr.Append(Sortedstr(i) & "&")

            End If
        Next

        prestr.Append(key)

        '生成Md5摘要； 
        Dim sign As String = GetMD5(prestr.ToString())

        '构造支付Url； 
        Dim parameter As New StringBuilder()
        parameter.Append(gateway)
        For i = 0 To Sortedstr.Length - 1
            parameter.Append(Sortedstr(i) & "&")
        Next

        parameter.Append(("sign=" & sign & "&sign_type=") + sign_type)


        '返回支付Url； 

        Return parameter.ToString()
    End Function

End Class
