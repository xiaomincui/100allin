Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

'/ <summary>
'/ Pager ��ժҪ˵��
'/ </summary>
Public Class Pager

    Public Sub New()
    End Sub 'New
    '
    ' TODO: �ڴ˴���ӹ��캯���߼�
    '

    Protected Shared _ButtonCount As Integer = 11
    Protected Shared _NextPage As String = "<a href={0}>��һҳ</a>"
    Protected Shared _LinkUrl As String = "?page={0}"
    Protected Shared _LastPage As String = "<a href={0}>��һҳ</a>"

    '/ <summary>
    '/ ��һҳ����
    '/ </summary>

    Public Shared Property NextPage() As String
        Get
            Return _NextPage
        End Get
        Set(ByVal value As String)
            _NextPage = value
        End Set
    End Property
    '/ <summary>
    '/ ��һҳ����
    '/ </summary>

    Public Shared Property LastPage() As String
        Get
            Return _LastPage
        End Get
        Set(ByVal value As String)
            _LastPage = value
        End Set
    End Property
    '/ <summary>
    '/ ����ʱΪ��ʽ
    '/ </summary>

    Public Shared Property NextPageText() As String
        Get
            Return _NextPage
        End Get
        Set(ByVal value As String)
            _NextPage = value
        End Set
    End Property
    '/ <summary>
    '/ ��ʾ��ť����
    '/ </summary>

    Public Shared Property BottonCount() As Integer
        Get
            Return _ButtonCount
        End Get
        Set(ByVal value As Integer)
            _ButtonCount = value
        End Set
    End Property
    '/ <summary>
    '/ ����ҳ��ķ�ҳ��Ϣ
    '/ </summary>
    '/ <param name="_RecordCount">��¼����</param>
    '/ <param name="_PageSize">��ҳ����</param>
    '/ <param name="_PageIndex">��ǰҳ</param>
    '/ <returns></returns>
    Public Shared Function PageInfo(ByVal _RecordCount As Integer, ByVal _PageSize As Integer, ByVal _PageIndex As Integer, ByVal link As String) As String
        Dim Firstpage As String = String.Format("<a href=" + link + ">[��ҳ]</a>", "1")
        Dim pageinfo1 As String = "����{0}ҳ / ��ǰ��{1}ҳ " + Firstpage
        Dim pagenext As String = " <a href=" + link + "><b>{0}</b></a> "
        Dim PageCount As Integer = _RecordCount / _PageSize ' ҳ���ϼ�
        If PageCount <= 0 Then
            PageCount = 1
        Else
            PageCount = PageCount
        End If
        pageinfo1 = String.Format(pageinfo1, PageCount.ToString(), _PageIndex.ToString())
        Dim LastPage As String = String.Format("<a href=" + link + ">[ĩҳ]</a>", PageCount)

        Dim n As Integer = _ButtonCount / 2 '������ʾ����
        Dim StartPage As Integer = _PageIndex - n
        Dim EndPage As Integer = _PageIndex + n
        _LastPage = String.Format(_LastPage, link) '��һҳ
        If _PageIndex - 1 > 1 Then
            _LastPage = String.Format(_LastPage, (_PageIndex - 1).ToString())
        Else
            _LastPage = String.Format(_NextPage, "1")
        End If

        _NextPage = String.Format(_NextPage, link) '��һҳ

        If _PageIndex + 1 <= PageCount Then
            _NextPage = String.Format(_NextPage, _PageIndex.ToString())
        Else
            _NextPage = String.Format(_NextPage, PageCount.ToString())
        End If

        If EndPage > PageCount Then
            StartPage = _PageIndex - n - (EndPage - PageCount)
            EndPage = PageCount
        End If
        If StartPage < 1 Then
            EndPage = _ButtonCount
            StartPage = 1
        End If

        Dim i As Integer
        For i = StartPage To EndPage
            If i <> _PageIndex Then
                pageinfo1 += String.Format(pagenext, i)
            Else
                pageinfo1 += " <b>" + i.ToString() + "</b> "
            End If
        Next i
        pageinfo1 += LastPage
        Return pageinfo1
    End Function 'PageInfo
End Class 'Pager 
