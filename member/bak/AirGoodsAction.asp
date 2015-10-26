<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<!--#include file="../include/include_All.asp" -->

<%
if Request.Cookies("user_id")=""  then response.Redirect("JumpHome.html")
Action= Replace(request("Action"), "'", "''")
SubName = CheckInput(request("SubName"))

ID= Replace(request("ID"), "'", "''")

title = CheckInput(request("title"))
endtime = CheckInput(request("endtime"))

nums = CheckInput(request("nums"))
ddlPayType = CheckInput(request("ddlPayType"))
tbGoodsAddr = CheckInput(request("tbGoodsAddr"))
tbGoodsName = CheckInput(request("tbGoodsName"))
ddlline = CheckInput(request("ddlline"))
rbldange = CheckInput(request("rbldange"))
price = CheckInput(request("price"))
hlinemiaoshu = CheckInput(request("hlinemiaoshu"))
StartPort = CheckInput(request("StartPort"))
CityName=TRIM(request("CityName"))

cbEnd = CheckInput(request("cbEnd"))
tbEnd = CheckInput(request("tbEnd"))
zhuangxiang = CheckInput(request("zhuangxiang"))
yaoqiu = CheckInput(request("yaoqiu"))
tbremark = CheckInput(request("tbremark"))

chkTel = CheckInput(request("txtTelc"))
chkMobile = CheckInput(request("txtMobilec"))
chkAddress = CheckInput(request("txtAddressc"))
chkEmail = CheckInput(request("txtEmailc"))
chkCompany = CheckInput(request("txtCompanyc"))

posttime = CheckInput(request("posttime"))
if posttime="" then posttime = now
ispass = CheckInput(request("ispass"))

if cbStart = "" then cbStart = 0
if cbEnd = "" then cbEnd = 0
if ispass = "" then ispass = 1
if price = "" then price = 0
UserId = Request.Cookies("user_id")



select case Action 

	
case "Add"
if endtime=""  then Gi_sOnErrGoBack"出运日期必须填写"
	sql="select * from TB_AIRGOODS"
	set rs=server.CreateObject("adodb.recordset")
	rs.open sql,conn,1,3
	rs.addnew
	rs("userId") = UserID
	rs("TITLE") = title
	rs("TYPE") =  CheckInput(trim(request.form("type")))
	rs("TYPES") =  CheckInput(trim(request("types")))
	rs("TYPEM") =  CheckInput(trim(request("typem")))
	rs("POSTDATE") = posttime
	rs("LAUNCHDATE") = endtime
	rs("AMOUNT") =nums
	rs("PAYMENT") = ddlPayType
	rs("price") = price
	rs("NAME") = tbGoodsName
	rs("DESCRIPTION") = tbremark
	rs("LINE") = ddlline
	rs("STARTPORT") = StartPort
	rs("DESTPORT") = CityName
	rs("ISDANGER") = rbldange
	rs("showtel") = chkTel
	rs("showmo") = chkMobile
	rs("showadd") = chkAddress
	rs("showemail") = chkEmail
	rs("showcom") = chkCompany
	rs.update
	rs.close
	set rs = nothing
	conn.close
	set conn = nothing	
	
	if SubName="SubNext" then
		Gi_sOnSucsGoNext "恭喜您,信息发布成功,请等待管理员的审核.继续添加下一条信息","User_addgoods.asp"
	elseif SubName="" then
		Gi_sOnSucsGoNext "恭喜您,信息发布成功,请等待管理员的审核.","../default.asp"
	end if
	
case "Edit"
if endtime=""  then Gi_sOnErrGoBack"出运日期必须填写"
	sql="select * from TB_AIRGOODS where id = " & id
	set rs=server.CreateObject("adodb.recordset")
	rs.open sql,conn,1,3
	rs.update
	rs("userId") = UserID
	rs("price") = price
	rs("TITLE") = title
	rs("POSTDATE") = posttime
	rs("LAUNCHDATE") = endtime
	rs("AMOUNT") =nums
	rs("PAYMENT") = ddlPayType
	rs("NAME") = tbGoodsName
	rs("DESCRIPTION") = tbremark
	rs("LINE") = ddlline
	rs("STARTPORT") = startport
	rs("DESTPORT") = CityName
	rs("TYPE") =  CheckInput(trim(request.form("type")))
	rs("TYPES") =  CheckInput(trim(request("types")))
	rs("TYPEM") =  CheckInput(trim(request("typem")))
	rs("ISDANGER") = rbldange
	rs("showtel") = chkTel
	rs("showmo") = chkMobile
	rs("showadd") = chkAddress
	rs("showemail") = chkEmail
	rs("showcom") = chkCompany	
	rs.update
	rs.close
	set rs = nothing
	conn.close
	set conn = nothing	
case "Del"
	conn.execute("delete from TB_AIRGOODS where ID in (" & ID & ")")
end select

if request.QueryString("type") = "1" then
response.Redirect("jump4.htm")
else
response.Redirect("jump5.htm")
end if
%>