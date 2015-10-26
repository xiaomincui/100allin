'数据适配器类，以sql语句为参数，输出适配器类

Imports Microsoft.VisualBasic

Public Class data_conn2
    Inherits System.Web.UI.Page
    Public Function mdb_conn() As Data.OleDb.OleDbConnection
        Dim connection1 As Data.OleDb.OleDbConnection
        Dim dbname1 As String
        dbname1 = Server.MapPath("~/App_Data/email.mdb")
        connection1 = New Data.OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA Source=" & dbname1)
        Return connection1
    End Function

    Public Function mdb_da(ByVal sql As String) As Data.OleDb.OleDbDataAdapter
        Dim connection1 As Data.OleDb.OleDbConnection
        Dim da1 As New Data.OleDb.OleDbDataAdapter
        Dim command1 As Data.OleDb.OleDbCommand
        Dim conn1 As New data_conn2
        connection1 = conn1.mdb_conn()
        connection1.Open()
        command1 = New Data.OleDb.OleDbCommand(sql, connection1)
        da1.SelectCommand = command1
        connection1.Close()
        Return da1
    End Function


    Public Function mdb_ds(ByVal sql As String, ByVal table As String) As Data.DataSet
        Dim ds1 As New Data.DataSet
        Dim da1 As New Data.OleDb.OleDbDataAdapter
        Dim conn1 As New data_conn2
        da1 = conn1.mdb_da(sql)
        da1.Fill(ds1, table)
        Return ds1
    End Function
End Class