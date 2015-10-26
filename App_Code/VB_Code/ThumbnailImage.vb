Imports Microsoft.VisualBasic

Public Class ThumbnailImage
    'sourcepath表示图片的路径,savepath,表示生图的保存路径width和height表示所要生成的图片的宽和高
    Public Sub GetThumbnailImage(ByVal sourcepath As String, ByVal savepath As String, ByVal width As Double, ByVal height As Double)
        Dim originalFilename As String = sourcepath
        '生成的高质量图片名称
        '从文件取得图片对象
        Dim image As System.Drawing.Image = System.Drawing.Image.FromFile(originalFilename)

        Dim iImgWidth As Double = image.Width
        Dim iImgHeight As Double = image.Height
        Dim iScale As Double = IIf((iImgWidth / width) > (iImgHeight / height), (iImgHeight / height), (iImgWidth / width))
        '取得图片大小
        Dim size As New System.Drawing.Size(CInt(iScale * width), CInt(iScale * height))
        '新建一个bmp图片
        Dim bitmap As New System.Drawing.Bitmap(CInt(width), CInt(height))
        '新建一个画板
        Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(bitmap)
        '设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High
        '设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        '清空一下画布
        g.Clear(System.Drawing.Color.Black)
        '在指定位置画图
        Dim cutwidth, cutheight As Integer
        If (iImgWidth - size.Width) <> 0 Then
            cutwidth = CInt(iImgWidth - size.Width) / 2
        Else
            cutwidth = 0
        End If

        If (iImgHeight - size.Height) <> 0 Then
            cutheight = CInt(iImgHeight - size.Height) / 2
        Else
            cutheight = 0
        End If


        g.DrawImage(image, New System.Drawing.Rectangle(0, 0, CInt(width), CInt(height)), New System.Drawing.Rectangle(cutwidth, cutheight, size.Width, size.Height), System.Drawing.GraphicsUnit.Pixel)
        '保存高清晰度的缩略图，参数表示，开始X坐标，开始Y坐标，所取长度，所取宽度，单位，取中心点

        'System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);

        'System.Drawing.Image myThumbnail = bitmap.GetThumbnailImage(bitmap.Width, bitmap.Height, myCallback, IntPtr.Zero);
        'myThumbnail.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        bitmap.Save(savepath, System.Drawing.Imaging.ImageFormat.Jpeg)
        g.Dispose()
        bitmap.Dispose()
        image.Dispose()




    End Sub
End Class
