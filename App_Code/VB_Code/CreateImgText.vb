Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Windows.Forms
' 
''' <summary> 
''' 创建图片文字 
''' </summary> 
Public Class CreateImgText
    Private _Text As String = Nothing
    Private _TextColor As Color = Color.Empty
    Private _BackgroundColor As Color = Color.Empty
    Private _TextStyle As FontStyle = FontStyle.Regular
    Private _Width As Integer
    Private _Height As Integer

#Region "+ 属性"
    ' 
    ''' <summary> 
    ''' 要显示的文本 
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
    ''' 文本颜色 
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
    '''背景颜色 
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
    ''' 文本样式 加粗 倾斜 普通等 
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
    ''' 图片的宽 
    ''' </summary> 
    Public ReadOnly Property Width() As Integer
        Get
            Return _Width
        End Get
    End Property
    'set { _Width = value; } 
    ' 
    ''' <summary> 
    ''' 图片的高 
    ''' </summary> 
    Public ReadOnly Property Height() As Integer
        Get
            Return _Height
        End Get
    End Property
    'set { _Height = value; } 
#End Region

#Region "+ 构造 + 3"
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
    ''' 创建输出的文字流 
    ''' </summary> 
    ''' <returns></returns> 
    Public Function CreateTextByte() As Byte()
        Dim font As New Font("宋体", 10, TextStyle)
        Dim brush As Brush = New SolidBrush(TextColor)
        ' 计算文字的宽和高 
        Dim sizeText As Size = TextRenderer.MeasureText(Text, font)
        _Width = sizeText.Width
        _Height = sizeText.Height
        ' 创建一个位图 
        Dim bmp As New Bitmap(sizeText.Width, sizeText.Height)


        ' 设置画布 
        Dim grph As Graphics = Graphics.FromImage(bmp)
        ' 指定消除锯齿 文字 
        grph.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        ' 清除画布 
        grph.Clear(BackgroundColor)
        ' 在画布上画图案 内容,字体,画刷,坐标 
        grph.DrawString(Text, font, brush, 0, 0)
        ' 新建一个内存流 
        Dim stream As New MemoryStream()
        ' 将图片保存在内存流中 
        bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)

        Dim byteBuf As Byte() = New Byte(stream.Length - 1) {}
        byteBuf = stream.ToArray()

        '资源回收 
        bmp.Dispose()
        grph.Dispose()
        stream.Close()

        Return byteBuf
    End Function
End Class



