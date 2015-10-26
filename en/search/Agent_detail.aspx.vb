Imports System.Data

Partial Class en_search_fcl_detail
    Inherits System.Web.UI.Page
    Public chatuser As String = ""
    Public chatowner As String = ""
    Public ddest As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then

            LoadDetail()
        End If
    End Sub

    Sub LoadDetail()



        Dim cn As New data_conn
        Dim ds As Data.DataSet = cn.mdb_ds("SELECT TB_Agent_Company.id as CompanyID,Telephone,Fax,Mobile_Phone,Emergency_Call,Website,URL,Email,TB_Agent.id,TB_Agent.Address,country,TB_Agent_City.city,CompanyName,Profile_txt,ifHead_Office,Publishers,Partner_Pay,Risk_Management,WCA,APLN,CGLN,IGLN,WCAPN,DGLA FROM TB_Agent,TB_Agent_Company,TB_Agent_City,TB_Agent_Country WHERE TB_Agent_Company.id = TB_Agent.CompanyID and TB_Agent.City=TB_Agent_City.id and TB_Agent_City.CountryID=TB_Agent_Country.id and TB_Agent.id=" + Me.Request("id").ToString, "agent")
        LitCompanyName.Text = ds.Tables("agent").Rows(0)("CompanyName").ToString
        LitCity.Text = ds.Tables("agent").Rows(0)("city").ToString
        If (ds.Tables("agent").Rows(0)("ifHead_Office").ToString = "1") Then
            LitHeadOffice.Text = ", Head Office"
        End If
        Dim dsCompany As Data.DataSet = cn.mdb_ds("select TB_Agent.id,TB_Agent_City.City from TB_Agent,TB_Agent_City where TB_Agent.City=TB_Agent_City.id and TB_Agent.CompanyID=" + ds.Tables("agent").Rows(0)("CompanyID").ToString, "Company")
        Repeater1.DataSource = dsCompany.Tables("Company").DefaultView
        Repeater1.DataBind()
        Dim strHtml As String = ""
        If CInt(ds.Tables("agent").Rows(0)("WCA")) = 1 Then
            strHtml += "<td align=""center"" valign=""top"">"
            strHtml += "<a href=""http://www.worldcargoalliance.com/"" target=""_blank"" >"
            strHtml += "<img src=""/en/images/agent/logo_wca.gif"" border=0 vspace=1 hspace=1  alt='World Cargo Alliance' />"
            strHtml += "</a>"
            strHtml += "&nbsp;<br>"
            strHtml += "<font style='font-size:11px;color:#990000' title='Expiration Date'><font style'font-size:9px'>Expires:</font> Nov 03, 2010</font></td>"
        End If

        If CInt(ds.Tables("agent").Rows(0)("APLN")) = 1 Then
            strHtml += "<td align=""center"" valign=""top"">"
            strHtml += "<a href=""http://www.worldcargoalliance.com/"" target=""_blank"" >"
            strHtml += "<img src=""/en/images/agent/logo_apln.gif"" border=0 vspace=1 hspace=1  alt='World Cargo Alliance' />"
            strHtml += "</a>"
            strHtml += "&nbsp;<br>"
            strHtml += "<font style='font-size:11px;color:#990000' title='Expiration Date'><font style'font-size:9px'>Expires:</font> Nov 03, 2010</font></td>"
        End If

        If CInt(ds.Tables("agent").Rows(0)("CGLN")) = 1 Then
            strHtml += "<td align=""center"" valign=""top"">"
            strHtml += "<a href=""http://www.worldcargoalliance.com/"" target=""_blank"" >"
            strHtml += "<img src=""/en/images/agent/logo_cgln.gif"" border=0 vspace=1 hspace=1  alt='World Cargo Alliance' />"
            strHtml += "</a>"
            strHtml += "&nbsp;<br>"
            strHtml += "<font style='font-size:11px;color:#990000' title='Expiration Date'><font style'font-size:9px'>Expires:</font> Nov 03, 2010</font></td>"
        End If

        If CInt(ds.Tables("agent").Rows(0)("IGLN")) = 1 Then
            strHtml += "<td align=""center"" valign=""top"">"
            strHtml += "<a href=""http://www.worldcargoalliance.com/"" target=""_blank"" >"
            strHtml += "<img src=""/en/images/agent/logo_igln.gif"" border=0 vspace=1 hspace=1  alt='World Cargo Alliance' />"
            strHtml += "</a>"
            strHtml += "&nbsp;<br>"
            strHtml += "<font style='font-size:11px;color:#990000' title='Expiration Date'><font style'font-size:9px'>Expires:</font> Nov 03, 2010</font></td>"
        End If


        If CInt(ds.Tables("agent").Rows(0)("WCAPN")) = 1 Then
            strHtml += "<td align=""center"" valign=""top"">"
            strHtml += "<a href=""http://www.worldcargoalliance.com/"" target=""_blank"" >"
            strHtml += "<img src=""/en/images/agent/logo_wcapn.gif"" border=0 vspace=1 hspace=1  alt='World Cargo Alliance' />"
            strHtml += "</a>"
            strHtml += "&nbsp;<br>"
            strHtml += "<font style='font-size:11px;color:#990000' title='Expiration Date'><font style'font-size:9px'>Expires:</font> Nov 03, 2010</font></td>"
        End If

        If CInt(ds.Tables("agent").Rows(0)("Publishers")) = 1 Then
            strHtml += "<td align=""center"" valign=""top"">"
            strHtml += "<a href=""http://www.worldcargoalliance.com/"" target=""_blank"" >"
            strHtml += "<img src=""/en/images/agent/logo_pla.gif"" border=0 vspace=1 hspace=1  alt='World Cargo Alliance' />"
            strHtml += "</a>"
            strHtml += "&nbsp;<br>"
            strHtml += "<font style='font-size:11px;color:#990000' title='Expiration Date'><font style'font-size:9px'>Expires:</font> Nov 03, 2010</font></td>"
        End If

        If CInt(ds.Tables("agent").Rows(0)("Partner_Pay")) = 1 Then
            strHtml += "<td align=""center"" valign=""top"">"
            strHtml += "<a href=""http://www.worldcargoalliance.com/"" target=""_blank"" >"
            strHtml += "<img src=""/en/images/agent/LogoWcafPP.gif"" border=0 vspace=1 hspace=1  alt='World Cargo Alliance' />"
            strHtml += "</a>"
            strHtml += "&nbsp;<br>"
            strHtml += "<font style='font-size:11px;color:#990000' title='Expiration Date'><font style'font-size:9px'>Expires:</font> Nov 03, 2010</font></td>"
        End If

        If CInt(ds.Tables("agent").Rows(0)("Risk_Management")) = 1 Then
            strHtml += "<td align=""center"" valign=""top"">"
            strHtml += "<a href=""http://www.worldcargoalliance.com/"" target=""_blank"" >"
            strHtml += "<img src=""/en/images/agent/Insured.gif"" border=0 vspace=1 hspace=1  alt='World Cargo Alliance' />"
            strHtml += "</a>"
            strHtml += "&nbsp;<br>"
            strHtml += "<font style='font-size:11px;color:#990000' title='Expiration Date'><font style'font-size:9px'>Expires:</font> Nov 03, 2010</font></td>"
        End If

        Litmember.Text = strHtml

        Litprofile.Text = ds.Tables("agent").Rows(0)("Profile_txt").ToString
        Literal4.Text = ds.Tables("agent").Rows(0)("Address").ToString
        Literal5.Text = ds.Tables("agent").Rows(0)("Telephone").ToString
        Literal6.Text = ds.Tables("agent").Rows(0)("Fax").ToString
        Literal7.Text = ds.Tables("agent").Rows(0)("Mobile_Phone").ToString
        Literal8.Text = ds.Tables("agent").Rows(0)("Emergency_Call").ToString
        Literal9.Text = "<a href=""" + ds.Tables("agent").Rows(0)("URL").ToString + """ target=""_blank"">" + ds.Tables("agent").Rows(0)("Website").ToString + "</a>"
        Literal10.Text = "<a href=""mailto:" + ds.Tables("agent").Rows(0)("Email").ToString + """>" + ds.Tables("agent").Rows(0)("Email").ToString + "</a>"

        Dim dsContact = cn.mdb_ds("select * from TB_Agent_Contact where AgentID=" + ds.Tables("agent").Rows(0)("id").ToString, "Contact")
        Repeater2.DataSource = dsContact.Tables("Contact").DefaultView
        Repeater2.DataBind()

    End Sub

    

    'alert弹窗
    Sub MessageBox(ByVal strKey As String, ByVal strInfo As String)
        If (Not ClientScript.IsClientScriptBlockRegistered(strKey)) Then
            Dim strjs As String = "alert('" + strInfo + "');"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), strKey, strjs, True)
        End If
    End Sub

    Function UnixTimestamp(ByVal dt As DateTime) As String
        Dim dtStart As DateTime = TimeZone.CurrentTimeZone.ToLocalTime(New DateTime(1970, 1, 1))
        Dim toNow As TimeSpan = dt.Subtract(dtStart)
        Dim timeStamp As String = toNow.Ticks.ToString()
        Return timeStamp.Substring(0, timeStamp.Length - 7)
    End Function

    Function IptoInt(ByVal sip As String) As Int64
        Dim Ip_List() As String = sip.Split(".".ToCharArray())
        Dim X_Ip As String = ""
        For Each ip As String In Ip_List
            If CInt(ip) < 10 Then
                X_Ip += "0" + CInt(ip).ToString("X")
            Else
                X_Ip += CInt(ip).ToString("X")
            End If
        Next
        Dim N_Ip As Int64 = Int64.Parse(X_Ip, System.Globalization.NumberStyles.HexNumber)
        Return N_Ip
    End Function

    Public Function key(ByVal es As String) As String
        Dim s As New SymmetricMethod
        Return s.Encrypto(es)
    End Function

    Protected Function Encode(ByVal str As String) As String
        str = str.Replace("&", "&amp;")
        str = str.Replace("'", "''")
        str = str.Replace("\", "&amp;")
        str = str.Replace("   ", "&nbsp;")
        str = str.Replace("<", "&lt;")
        str = str.Replace(">", "&gt;")
        str = str.Replace(vbCrLf, "<br />")
        Return str
    End Function

    Public Function GetQueryString(ByVal q As String) As String
        If Request.QueryString(q) Is Nothing Then
            Return "0"
        Else
            If Request.QueryString(q) = "" Then
                Return "0"
            Else
                Return Request.QueryString(q).ToString
            End If
        End If
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

        If isCut Then
            Return sb.ToString() & ".."
        Else
            Return sb.ToString()
        End If

        Return sb.ToString()

    End Function

    Public Shared Function JingHao(ByVal s As String) As String
        Try
            Return s.Replace("#", "%23")
        Catch ex As Exception
            Return "0"
        End Try
    End Function

    Public Shared Function Every3(ByVal s As String) As String
        If ((CInt(s) + 1) Mod 3) = 0 Then
            Return ""
        Else
            Return "none"
        End If
    End Function

    Public Function DateToWord(ByVal s As String) As String

    End Function


End Class
