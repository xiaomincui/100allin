Imports System
Imports System.Web.Services
Imports System.Collections.Generic
Imports System.Data.SqlClient

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<System.Web.Script.Services.ScriptService()> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class sql_test
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetShippingStartPortList(ByVal prefixText As String, ByVal count As String) As String()
        Dim items As New List(Of String)
        Dim ck As New check
        Dim myCon As New SqlConnection("Server=localhost;uid=sasa;pwd=SmNETEkwLzJNQmNoS;Database=DB_DataBase_new")
        myCon.Open()
        Dim myCmd As New SqlCommand("select top " + ck.CheckInput(count) + " CityNameCH,CityName from TB_CHINACITY where CityNameCH like '" + ck.CheckInput(prefixText) + "%' or CityName like '" + ck.CheckInput(prefixText) + "%' order by CityName ", myCon)
        Dim myDR As SqlDataReader = myCmd.ExecuteReader()
        While myDR.Read
            items.Add(myDR("CityNameCH").ToString())
        End While
        myCon.Close()
        Return items.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetShippingPortList(ByVal prefixText As String, ByVal count As String) As String()
        Dim items As New List(Of String)
        Dim ck As New check
        Dim myCon As New SqlConnection("Server=localhost;uid=sasa;pwd=SmNETEkwLzJNQmNoS;Database=DB_DataBase_new")
        myCon.Open()
        Dim myCmd As New SqlCommand("select top " + ck.CheckInput(count) + " CityName from TB_City where suggest = 1 and CityName like '" + ck.CheckInput(prefixText) + "%' order by CityName ", myCon)
        Dim myDR As SqlDataReader = myCmd.ExecuteReader()
        While myDR.Read
            items.Add(myDR("CityName").ToString())
        End While
        myCon.Close()
        Return items.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetAirPortList(ByVal prefixText As String, ByVal count As String) As String()
        Dim items As New List(Of String)
        Dim ck As New check
        Dim myCon As New SqlConnection("Server=localhost;uid=sasa;pwd=SmNETEkwLzJNQmNoS;Database=DB_DataBase_new")
        myCon.Open()
        Dim myCmd As New SqlCommand("select top " + ck.CheckInput(count) + " CityNameEn,Ad from TB_Airport where CityNameEn like '" + ck.CheckInput(prefixText) + "%' or Ad = '" + ck.CheckInput(prefixText) + "' order by CityNameEn ", myCon)
        Dim myDR As SqlDataReader = myCmd.ExecuteReader()
        While myDR.Read
            items.Add(myDR("CityNameEn").ToString() & " (" & myDR("Ad").ToString() & ") ")
        End While
        myCon.Close()
        Return items.ToArray()
    End Function


    <WebMethod()> _
    Public Function GetCarrierList(ByVal prefixText As String, ByVal count As String) As String()
        Dim items As New List(Of String)
        Dim ck As New check
        Dim myCon As New SqlConnection("Server=localhost;uid=sasa;pwd=SmNETEkwLzJNQmNoS;Database=DB_DataBase_new")
        myCon.Open()
        Dim myCmd As New SqlCommand("select top " + ck.CheckInput(count) + " cname from TB_CARRIER where cname like '" + ck.CheckInput(prefixText) + "%' order by cname ", myCon)
        Dim myDR As SqlDataReader = myCmd.ExecuteReader()
        While myDR.Read
            items.Add(myDR("cname").ToString())
        End While
        myCon.Close()
        Return items.ToArray()
    End Function

End Class
