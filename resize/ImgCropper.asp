<%@LANGUAGE="VBSCRIPT" CODEPAGE="936"%>
<% 
Response.Expires = 0

Pic = Request("p")
PointX = CInt(Request("x"))
PointY = CInt(Request("y"))
CutWidth = CInt(Request("w"))
CutHeight = CInt(Request("h"))
PicWidth = CInt(Request("pw"))
PicHeight = CInt(Request("ph"))

Set Jpeg = Server.CreateObject("Persits.Jpeg")
Jpeg.Open Server.MapPath(Pic)

'�����и�ͼƬ
Jpeg.Width = PicWidth
Jpeg.Height = PicHeight
Jpeg.Crop PointX, PointY, CutWidth + PointX, CutHeight + PointY
 
'���ͼƬ
Response.ContentType = "image/jpeg"
Jpeg.SendBinary
%>