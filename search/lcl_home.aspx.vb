
Partial Class search_lcl_home
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not Page.IsPostBack Then
        '    '定义所有输入框按回车跳到下一格
        '    txtLine.Attributes.Add("onkeydown", "KeyDown(event);")
        '    txtStartport.Attributes.Add("onfocus", "auto_init(event,this);")
        '    txtDestport.Attributes.Add("onfocus", "auto_init(event,this);")
        '    txtDestport.Attributes.Add("onkeydown", "if(event.keyCode==13){return false;}")
        '    txtCarrier.Attributes.Add("onfocus", "auto_init(event,this);")
        '    txtCarrier.Attributes.Add("onkeydown", "if(event.keyCode==13){return false;}")


        LoadBase()
        '    hotPort()


        'End If
    End Sub

    Sub LoadBase()
        Dim sql As String = ""
        Dim ds As New Data.DataSet
        Dim ds2 As New Data.DataSet
        Dim ds3 As New Data.DataSet
        Dim cn As New data_conn

        sql = ""
        sql = "select top 12 "
        sql = sql + "id,startport,destport,title,hangxianmiaoshu,companyname,UserID,pricegp,pricegpv "
        sql = sql + "FROM  "
        sql = sql + "V_最新_拼箱运价 "
        ds2 = cn.mdb_ds(sql, "bbs")
        ds3 = cn.mdb_ds(sql, "bbs")

        For i2 As Integer = 6 To 11
            ds2.Tables("bbs").Rows(i2).Delete()
        Next

        For i3 As Integer = 0 To 5
            ds3.Tables("bbs").Rows(i3).Delete()
        Next


        Rptfcl2.DataSource = ds2.Tables("bbs").DefaultView
        Rptfcl2.DataBind()

        Rptfcl3.DataSource = ds3.Tables("bbs").DefaultView
        Rptfcl3.DataBind()

        sql = "select ratesimple from TB_NEWRATE"
        ds = cn.mdb_ds(sql, "rate")

        Dim ratexxs(4) As String

        Dim ratexx As String
        ratexx = ds.Tables("rate").Rows(0)(0).ToString()

        ratexxs = ratexx.Split("|")


        ltrRate1.Text = (Convert.ToDouble(ratexxs(0)) / 100).ToString()
        ltrRate2.Text = (100 / Convert.ToDouble(ratexxs(0))).ToString("f4")


    End Sub

    Public Function key(ByVal es As String) As String
        Dim s As New SymmetricMethod
        Return s.Encrypto(es)
    End Function

    Public Function setprice(ByVal es As String) As String
        es = es.ToUpper.Replace("USD", "").Replace("$", "").Replace("KG", "").Replace("/", "").Trim()
        Return es
    End Function

    Public Function output(ByVal s As String) As String
        If s = "" Then
            s = "-"
        End If
        s = s.Replace("USD", "").Replace("$", "").ToString()

        Return s
    End Function

    Public Shared Function GetFirstString(ByVal stringToSub As String, ByVal length As Integer) As String
        '\u4e00-\u9fa5 中文区
        '\uff00-\uffef 逗号区
        '\u3000-\u303f 句号区
        '\u2000-\u206f 引号区
        '\u25a0-\u25ff 几何图形区


        Dim regex As New Regex("[\u4e00-\u9fa5\uff00-\uffef\u3000-\u303f\u2000-\u206f\u25a0-\u25ff]+", RegexOptions.Compiled)
        Dim stringChar As Char() = stringToSub.ToCharArray()
        Dim sb As New StringBuilder()
        Dim nLength As Integer = 0
        Dim isCut As Boolean = False
        For i As Integer = 0 To stringChar.Length - 1
            If regex.IsMatch((stringChar(i)).ToString()) Then
                sb.Append(stringChar(i))
                nLength += 2
            Else
                sb.Append(stringChar(i))
                nLength = nLength + 1
            End If

            If nLength > length Then
                isCut = True
                Exit For
            End If
        Next

        If isCut = True Then
            Return sb.ToString() & ".."
        Else
            Return sb.ToString()
        End If

    End Function
End Class
