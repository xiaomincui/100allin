<%
Response.Buffer = True
Response.ExpiresAbsolute = Now() - 1
Response.Expires = 0
Response.CacheControl = "no-cache"

Dim zNum,CnText,NewString,urlget
urlget=Request.ServerVariables("HTTP_REFERER")
'�˴��ж�ֱ��������֤��ҳ��ʱ��ֹ��ʾ
if urlget="" then
Response.Write ("")
Response.End
End IF
'����498������,�����Ӻ���,Ҫ�޸����������498
NewString="��һ���ڲ����к������д�Ϊ�ϸ�������Ҫ��ʱ���������������ڳ��ͷֶԳɻ�������궯ͬ��Ҳ���¹���˵�����������ඨ��ѧ������þ�ʮ��֮���ŵȲ��ȼҵ�������ˮ�����Զ�����С����ʵ�����������ƻ���ʹ���ҵ��ȥ���Ժ�Ӧ�����ϻ�������ЩȻǰ������������������ƽ����ȫ�������ظ��������������ķ�������ԭ��ô���Ȼ�������������˱���ֻû������⽨�¹���ϵ������������������ͨ����ֱ�⵳��չ�������Ա��λ�볣���ܴ�Ʒʽ���輰���ؼ�������ͷ���ʱ���·����ͼɽͳ��֪�Ͻ�����Ʊ����ֽ��ڸ�����ũָ������ǿ�ž�����������ս�Ȼ�����ȡ�ݴ����ϸ�ɫ���ż����α���ٹ������ߺ��ڶ�����ѹ־���������ý���˼����������ʲ������Ȩ��֤���强���ٲ�ת�������д�׽��ٻ������������������ÿĿ�����߻�ʾ��������������뻪��ȷ�ſ�������ڻ�������Ԫ�����´�����Ⱥ��ʯ������н������ɽ��Ҿ���Խ֯װӰ��ͳ������鲼���ݶ�����̷����������ѽ���ǧ��ί�ؼ��������ʡ��ϰ��Լ֧��ʷ���ͱ����������п˺γ���������̫׼��ֵ������ά��ѡ��д���ë�׿�Ч˹Ժ�齭�����������������ɲ�Ƭʼȴר״������ʶ����Բ����ס�����ؾ��ղκ�ϸ������������"
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
Response.write "û�����������밲װ!"'
Response.End() 
End If 
Jpeg.Open Server.MapPath(TargetFile)
If err.number then 
Response.write"��ͼƬʧ��,����·����" 
Response.End() 
End if 
Dim TempA 
Dim TempB
Dim TempC
TempA=Jpeg.Binary
'=========������ˮӡ=================
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
Jpeg.Canvas.Font.Family = "�����ֻ������"
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