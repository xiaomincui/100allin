Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Windows.Forms
' 
''' <summary> 
''' ����ͼƬ���� 
''' </summary> 
Public Class CreateImgText
    Private _Text As String = Nothing
    Private _TextColor As Color = Color.Empty
    Private _BackgroundColor As Color = Color.Empty
    Private _TextStyle As FontStyle = FontStyle.Regular
    Private _Width As Integer
    Private _Height As Integer

#Region "+ ����"
    ' 
    ''' <summary> 
    ''' Ҫ��ʾ���ı� 
    ''' </summary> 
    Public Property Text() As String
        Get
            If _Text Is Nothing OrElse _Text.Trim().Length <= 0 Then
                Return " "
            End If
            Return _Text
        End Get
        Set(ByVal value As String)
            _Text = value
        End Set
    End Property
    ' 
    ''' <summary> 
    ''' �ı���ɫ 
    ''' </summary> 
    Public Property TextColor() As Color
        Get
            If _TextColor = Color.Empty Then
                Return Color.Black
            End If
            Return _TextColor
        End Get
        Set(ByVal value As Color)
            _TextColor = value
        End Set
    End Property
    ' 
    ''' <summary> 
    '''������ɫ 
    ''' </summary> 
    Public Property BackgroundColor() As Color
        Get
            If _BackgroundColor = Color.Empty Then
                Return Color.Black
            End If
            Return _BackgroundColor
        End Get
        Set(ByVal value As Color)
            _BackgroundColor = value
        End Set
    End Property
    ' 
    ''' <summary> 
    ''' �ı���ʽ �Ӵ� ��б ��ͨ�� 
    ''' </summary> 
    Public Property TextStyle() As FontStyle
        Get
            Return _TextStyle
        End Get
        Set(ByVal value As FontStyle)
            _TextStyle = value
        End Set
    End Property
    ' 
    ''' <summary> 
    ''' ͼƬ�Ŀ� 
    ''' </summary> 
    Public ReadOnly Property Width() As Integer
        Get
            Return _Width
        End Get
    End Property
    'set { _Width = value; } 
    ' 
    ''' <summary> 
    ''' ͼƬ�ĸ� 
    ''' </summary> 
    Public ReadOnly Property Height() As Integer
        Get
            Return _Height
        End Get
    End Property
    'set { _Height = value; } 
#End Region

#Region "+ ���� + 3"
    Public Sub New()

    End Sub
    Public Sub New(ByVal strText As String)
        _Text = strText
    End Sub

    Public Sub New(ByVal strText As String, ByVal TextColor As Color)
        _Text = strText
        _TextColor = TextColor
    End Sub
    Public Sub New(ByVal strText As String, ByVal TextColor As Color, ByVal TextStyle As FontStyle)
        _Text = strText
        _TextColor = TextColor
        _TextStyle = TextStyle
    End Sub

    Public Sub New(ByVal strText As String, ByVal TextColor As Color, ByVal BackgroundColor As Color, ByVal TextStyle As FontStyle)
        _Text = strText
        _TextColor = TextColor
        _BackgroundColor = BackgroundColor
        _TextStyle = TextStyle
    End Sub
#End Region

    ' 
    ''' <summary> 
    ''' ��������������� 
    ''' </summary> 
    ''' <returns></returns> 
    Public Function CreateTextByte() As Byte()
        Dim font As New Font("����", 10, TextStyle)
        Dim brush As Brush = New SolidBrush(TextColor)
        ' �������ֵĿ�͸� 
        Dim sizeText As Size = TextRenderer.MeasureText(Text, font)
        _Width = sizeText.Width
        _Height = sizeText.Height
        ' ����һ��λͼ 
        Dim bmp As New Bitmap(sizeText.Width, sizeText.Height)


        ' ���û��� 
        Dim grph As Graphics = Graphics.FromImage(bmp)
        ' ָ��������� ���� 
        grph.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        ' ������� 
        grph.Clear(BackgroundColor)
        ' �ڻ����ϻ�ͼ�� ����,����,��ˢ,���� 
        grph.DrawString(Text, font, brush, 0, 0)
        ' �½�һ���ڴ��� 
        Dim stream As New MemoryStream()
        ' ��ͼƬ�������ڴ����� 
        bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)

        Dim byteBuf As Byte() = New Byte(stream.Length - 1) {}
        byteBuf = stream.ToArray()

        '��Դ���� 
        bmp.Dispose()
        grph.Dispose()
        stream.Close()

        Return byteBuf
    End Function
End Class



