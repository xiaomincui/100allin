Imports System.Xml
Imports System.Data

Partial Class search_company_home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadList1()
            LoadList2(0)
            Dim cn As New data_conn
            Dim ds As New Data.DataSet
            Dim sql As String = ""


            sql = sql & "select top 9 userid,Realname,Companyname,Phone,HeadURL, star_adv, Login2_Locus1,Login2_Locus2,Login2_Adventage_Type_fcl,Login2_Adventage_Type_lcl,Login2_Adventage_Type_air FROM V_COMPANY_USER where userid in (65192,74777,1199,156979,50894,62951,62944,121537,135459)  order by newid()"


            'sql = sql & "SELECT top 10"
            'sql = sql & "iflocus,"
            'sql = sql & "ifadv,"
            'sql = sql & "userid,"
            'sql = sql & "Realname,"
            'sql = sql & "Companyname,"
            'sql = sql & "Phone,"
            'sql = sql & "HeadURL,"
            'sql = sql & "star_allin, "
            'sql = sql & "star_user, "
            'sql = sql & "star_adv, "
            'sql = sql & "Login2_Locus1,"
            'sql = sql & "Login2_Locus2,"
            'sql = sql & "Login2_Adventage_Type_fcl,"
            'sql = sql & "Login2_Adventage_Type_lcl,"
            'sql = sql & "Login2_Adventage_Type_air, "
            'sql = sql & "Login2_Adventage_Line, "
            'sql = sql & "Login2_Adventage_Line2, "
            'sql = sql & "Login2_Adventage_Line_Adv, "
            'sql = sql & "Login2_Adventage_Line2_Adv "
            'sql = sql & "FROM "
            'sql = sql & "V_COMPANY_USER "
            'Sql = Sql & "Where CompanyType = 2 "
            'Sql = Sql & "Order BY userid DESC"

            ds = cn.mdb_ds(Sql, "newuser")

            RptNewUser.DataSource = ds.Tables("newuser").DefaultView
            RptNewUser.DataBind()

        End If
    End Sub




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

    End Sub

    Protected Sub ddlcity1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcity1.SelectedIndexChanged
        LoadList2(ddlcity1.SelectedValue)
    End Sub


    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim city1 As String = ""
        Dim city2 As String = ""
        If ddlcity1.SelectedItem.Text <> "请选择" Then
            city1 = ddlcity1.SelectedItem.Text
        End If
        If ddlcity2.SelectedItem.Text <> "请选择" Then
            city2 = ddlcity2.SelectedItem.Text
        End If
        Response.Redirect("/company/list-" & city1 & "-" & city2 & "--" & txtCompanyName.Text & "---0-0----------1.html")
    End Sub

    Public Function key(ByVal es As String) As String
        Dim s As New SymmetricMethod
        Return s.Encrypto(es)
    End Function
End Class
