<%
Response.Buffer = True
Response.ExpiresAbsolute = Now() - 1
Response.Expires = 0
Response.CacheControl = "no-cache"

Dim zNum,CnText,NewString,urlget
urlget=Request.ServerVariables("HTTP_REFERER")
'此处判断直接输入验证码页打开时禁止显示
if urlget="" then
Response.Write ("")
Response.End
End IF
'常用498个汉字,如增加汉字,要修改下面的数字498
NewString="的一是在不了有和人这中大为上个国我以要他时来用们生到作地于出就分对成会可主发年动同工也能下过子说产种面而方后多定行学法所民得经十三之进着等部度家电力里如水化高自二理起小物现实加量都两体制机当使点从业本去把性好应开它合还因由其些然前外天政四日那社义事平形相全表间样与关各重新线内数正心反你明看原又么利比或但质气第向道命此变条只没结解问意建月公无系军很情者最立代想已通并提直题党程展五果料象员革位入常文总次品式活设及管特件长求老头基资边流路级少图山统接知较将组见计别她手角期根论运农指几九区强放决西被干做必战先回则任取据处队南给色光门即保治北造百规热领七海口东导器压志世金增争济阶油思术极交受联什认六共权收证改清己美再采转更单风切打白教速花带安场身车例真务具万每目至达走积示议声报斗完类八离华名确才科张信马节话米整空元况今集温传土许步群广石记需段研界拉林律叫且究观越织装影算低持音众书布复容儿须际商非验连断深难近矿千周委素技备半办青省列习响约支般史感劳便团往酸历市克何除消构府称太准精值号率族维划选标写存候毛亲快效斯院查江型眼王按格养易置派层片始却专状育厂京识适属圆包火住调满县局照参红细引听该铁价严"
Randomize timer
zNum = cint(9*Rnd)
CnText=""
for i=1 to 4
CnText=CnText&Mid(newString,Int(Rnd()*498)+1,1)
next
TargetFile="GetCode/"&zNum&".gif"
Dim Jpeg
Set Jpeg = Server.CreateObject("Persits.Jpeg") 
If Err.Number=-2147221005 then 
Response.write "没有这个组件，请安装!"'
Response.End() 
End If 
Jpeg.Open Server.MapPath(TargetFile)
If err.number then 
Response.write"打开图片失败,请检查路径！" 
Response.End() 
End if 
Dim TempA 
Dim TempB
Dim TempC
TempA=Jpeg.Binary
'=========加文字水印=================
if zNum<2 then
Jpeg.Canvas.Font.Color = &Hffffff
elseif zNum<3 then
Jpeg.Canvas.Font.Color = &HFF7800
elseif zNum<4 then
Jpeg.Canvas.Font.Color = &H7B3A00
elseif zNum<5 then
Jpeg.Canvas.Font.Color = &HF000FF
elseif zNum<6 then
Jpeg.Canvas.Font.Color = &H8498FF
elseif zNum<7 then
Jpeg.Canvas.Font.Color = &H00FFF6
elseif zNum<8 then
Jpeg.Canvas.Font.Color = &H24FF00
elseif zNum<9 then
Jpeg.Canvas.Font.Color = &H873238
else
Jpeg.Canvas.Font.Color = &H348382
end if
Jpeg.Canvas.Font.Family = "方正粗活意简体"
Jpeg.Canvas.Font.Bold = false
Jpeg.Canvas.Font.Size = 38
Jpeg.Canvas.Font.ShadowColor = &H000000
Jpeg.Canvas.Font.ShadowYOffset = 1 
Jpeg.Canvas.Font.ShadowXOffset = 3 
Jpeg.Canvas.Brush.Solid = True 
Jpeg.Canvas.Font.Quality = 10
Jpeg.Canvas.PrintText 4,6,CnText
TempB=Jpeg.Binary

Set MyJpeg = Server.CreateObject("Persits.Jpeg") 
MyJpeg.OpenBinary TempA 
Set Logo = Server.CreateObject("Persits.Jpeg") 
Logo.OpenBinary TempB 
MyJpeg.DrawImage 0,0, Logo, 0.8
TempC=MyJpeg.Binary
response.BinaryWrite TempC
'MyJpeg.Save (TargetFile) 
set TempA=nothing 
set TempB=nothing 
set TempC=nothing 
Jpeg.close 
MyJpeg.Close 
Logo.Close

Session("GetCode")=CnText
%>