'数据适配器类，以sql语句为参数，输出适配器类

Imports Microsoft.VisualBasic

Public Class data_conn
    Inherits System.Web.UI.Page
    Public Function mdb_conn() As Data.OleDb.OleDbConnection
        Dim connection1 As Data.OleDb.OleDbConnection
        'Dim dbname1 As String
        'dbname1 = Server.MapPath("~/Connections/DB_DataBase_new.mdb")
        connection1 = New Data.OleDb.OleDbConnection("Provider=SQLOLEDB.1;Persist Security Info=False;Server=139.196.52.121;User ID=sa;Password=65127389;Database=DB_DataBase_new")
        Return connection1
    End Function

    Public Function mdb_da(ByVal sql As String) As Data.OleDb.OleDbDataAdapter
        Dim connection1 As Data.OleDb.OleDbConnection
        Dim da1 As New Data.OleDb.OleDbDataAdapter
        Dim command1 As Data.OleDb.OleDbCommand
        Dim conn1 As New data_conn
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
        Dim conn1 As New data_conn
        da1 = conn1.mdb_da(sql)
        da1.Fill(ds1, table)
        Return ds1
    End Function

    Public Sub mdb_exe(ByVal sql As String)
        Dim connection1 As Data.OleDb.OleDbConnection
        Dim command1 As Data.OleDb.OleDbCommand
        Dim conn1 As New data_conn
        connection1 = conn1.mdb_conn()
        connection1.Open()
        command1 = New Data.OleDb.OleDbCommand(sql, connection1)
        command1.ExecuteNonQuery()
        connection1.Close()
    End Sub

    Public Function mdb_exe_return(ByVal sql As String) As String
        Dim connection1 As Data.OleDb.OleDbConnection
        Dim command1 As Data.OleDb.OleDbCommand
        Dim conn1 As New data_conn
        Dim da As New Data.OleDb.OleDbDataAdapter
        Dim ds As New Data.DataSet
        connection1 = conn1.mdb_conn()
        connection1.Open()
        command1 = New Data.OleDb.OleDbCommand(sql, connection1)
        command1.ExecuteNonQuery()
        command1 = New Data.OleDb.OleDbCommand("SELECT SCOPE_IDENTITY()", connection1)
        da.SelectCommand = command1
        da.Fill(ds, "aa")
        connection1.Close()
        Return ds.Tables("aa").Rows(0)(0).ToString()
    End Function

End Class