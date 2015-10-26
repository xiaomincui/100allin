Imports Microsoft.VisualBasic

Public Class Mark
    Public Sub MarkOperate(ByVal UserID As Integer, ByVal mark As Double, ByVal reason As String, ByVal recommendUserID As Integer)
        Dim cn As New data_conn
        Dim ck As New check
        cn.mdb_exe("insert into TB_Mark (UserID,mark,reason,MarkTime,recommendUserID) values (" + ck.CheckInput(UserID.ToString) + "," + ck.CheckInput(mark.ToString) + ",'" + ck.CheckInput(reason) + "',getdate()," + ck.CheckInput(recommendUserID.ToString) + ")")
    End Sub
End Class
