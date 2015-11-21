'数据适配器类，以sql语句为参数，输出适配器类

Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class data_conn3
    Inherits System.Web.UI.Page
    Public Function mdb_conn() As Data.SqlClient.SqlConnection
        Dim connection1 As Data.SqlClient.SqlConnection
        'Dim dbname1 As String
        'dbname1 = Server.MapPath("../Connections/DB_DataBase_new.mdb")
        connection1 = New Data.SqlClient.SqlConnection("Persist Security Info=False;Server=139.196.52.121;User ID=sa;Password=65127389;Database=DB_DataBase_new")
        Return connection1
    End Function

    Public Function mdb_da(ByVal sql As String) As SqlDataAdapter
        Dim connection1 As SqlConnection
        Dim da1 As New SqlDataAdapter
        Dim command1 As SqlCommand
        Dim conn1 As New data_conn3
        connection1 = conn1.mdb_conn()
        connection1.Open()
        command1 = New Data.SqlClient.SqlCommand(sql, connection1)
        command1 = New Data.SqlClient.SqlCommand(sql, connection1)
        da1.SelectCommand = command1
        connection1.Close()
        Return da1
    End Function


    Public Function mdb_ds(ByVal sql As String, ByVal table As String) As Data.DataSet
        Dim ds1 As New Data.DataSet
        Dim da1 As New SqlDataAdapter
        Dim conn1 As New data_conn3
        da1 = conn1.mdb_da(sql)
        da1.Fill(ds1, table)
        Return ds1
    End Function
End Class