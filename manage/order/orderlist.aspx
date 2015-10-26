<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orderlist.aspx.cs" Inherits="manage_order_orderlist" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>所有订单</title>
    <link href="/manage/css/master.css" type="text/css" rel="stylesheet" />
    <link href="/js/date/css/w.css" type="text/css" rel="stylesheet" />	
    <script type="text/javascript" src="/js/date/js/w.js"></script>
    <script type="text/javascript" src="/js/date/js/w1.js"></script>
    <script type="text/javascript" src="/js/date/js/w2.js"></script>
<script language="javascript" src="/manage/js/function.js"></script>
<link href="/js/autocomplete/port.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" language="javascript" src="/js/autocomplete/prototype.js"></script>
<script type="text/javascript" language="javascript" src="/js/autocomplete/startport.js"></script>
<script type="text/javascript" language="javascript">
function selectftype(){

var obj = document.getElementsByName("rbl_lftype");
var obj1 = document.getElementById("rbl_line1");
var obj2 = document.getElementById("rbl_line2");
var valuel; // 选中值
for(var i=0; i<obj.length; i++)
{
    if(obj[i].checked)
    {
        value = obj[i].value;
    }
}
    
if (value == "8")
{
    obj1.style.display = "";
    obj2.style.display = "none";
}
else if (value == "9")
{
    obj1.style.display = "";
    obj2.style.display = "none";
}
else if (value == "10")
{
    obj1.style.display = "none";
    obj2.style.display = "";
}
}
</script>  	
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
<!--

-->
</style>
</head>
<body>
<form id="form1" runat="server">
    <div id="page">
		<div id="center">
			<managertop:managertop id="managertop1" runat="server" />
			<managermenu:managermenu id="managermenu1" runat="server" />
		  <div id="main">
			<managerleft:managerleft id="managerleft1" runat="server" />												
		  	<div id=right>
<div class="tt18 bd rightTitle">
<div class=icon><img src="/manage/images/home_title.gif"></div>
<div class=text>订单</div></div>
<div class="tt14 bd rightSubTitle">
<div class=text>所有订单</div></div>
<div class="rightArea txth22">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="buttons">
<a href="javascript:void(0)" onclick="delAll()">删除选定</a>
<asp:Button ID="btnHidDel" runat="server" Text="Button" CssClass="hidden" OnClick="btnHidDel_Click"/>
<asp:TextBox ID="delList" runat="server" CssClass="hidden"></asp:TextBox>
</div>

<div class=listtable>
<div>
<table style="BORDER: 1px #d9d9d9 solid; BORDER-COLLAPSE: collapse" cellSpacing=0 cellPadding=0 rules=rows border=1>
  <tbody>
  <tr style="BACKGROUND-COLOR: #f0f0f0">
    <TH scope=col style="WIDTH: 5px"></TH>
    <TH scope=col style="WIDTH: 30px" align="left"><input id=chkAll onclick=CheckAll(this.form); type=checkbox 
      name=chkAll> </TH>
    <TH scope=col style="WIDTH: 160px" align="left">订单号</TH>
    <TH scope=col style="WIDTH: 228px" align="left">交易双方</TH>
    <TH scope=col style="WIDTH: 190px" align="left">关联运价</TH>
    <TH scope=col style="WIDTH: 100px" align="left">状态</TH>
    <TH scope=col style="WIDTH: 30px" align="left">编辑</TH>
    <TH scope=col style="WIDTH: 30px" align="left">删除</TH>
    <TH scope=col style="WIDTH: 5px"></TH>
  </tr>
<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate>
  <tr onmouseover="this.style.backgroundColor='#F4F7FB';" onmouseout="this.style.backgroundColor='#ffffff';">
    <td style="WIDTH: 5px; height:60px;"></td>
    <td style="WIDTH: 30px" align="left"><input id="id" type="checkbox" value="<%# Eval("oid").ToString() %>" onclick="checkToList(this.form)" /> </td>
    <td style="WIDTH: 160px"><a href="<%#GetFeightType(Eval("freight_type").ToString())%>_order.aspx?orderid=<%#Eval("order_code").ToString()%>" target="_blank"><%# Eval("order_code").ToString()%></a><br/><%# Eval("date_create").ToString()%></td>
    <td style="WIDTH: 228px">货主: <a href="/company/<%#setkey(Eval("aid").ToString())%>/" target="_blank"><%# Eval("acompany").ToString() %> | <%# Eval("aname").ToString() %></a><br/>货代: <a href="/company/<%#setkey(Eval("bid").ToString())%>/" target="_blank"><%# Eval("bcompany").ToString() %> | <%# Eval("bname").ToString() %></a></td>
    <td style="WIDTH: 190px"><a href="/<%#GetFeightType(Eval("freight_type").ToString())%>/<%#setkey(Eval("freight_code").ToString())%>_<%# Eval("freight_code1").ToString()%>.html" target="_blank"><%# Eval("price_title").ToString()%></a><br/><%#(Eval("freight_type").ToString()=="8"?"整箱":(Eval("freight_type").ToString()=="9"?"拼箱":"空运"))%> <%# Eval("startport").ToString()%> 至 <%# Eval("destport").ToString()%></td>
    <td style="WIDTH: 100px"><%# Eval("status_name_admin").ToString() %></td>
    <td style="WIDTH: 30px" align="left"><a href="adduser.aspx?id=<%# Eval("oid").ToString() %>">编辑</a> </td>
    <td style="WIDTH: 30px" align="left"><a href="javascript:delConfirm('<%# Eval("oid").ToString() %>')">删除</a> </td>
    <td style="WIDTH: 5px"></td>
    </tr>
</ItemTemplate>
</asp:Repeater>
<asp:PlaceHolder ID="phNorecord" runat="server" Visible="false">
<tr onmouseover="this.style.backgroundColor='#F4F7FB';" onmouseout="this.style.backgroundColor='#ffffff';">
<td colspan="12" align="center">暂无记录</td>
</tr>
</asp:PlaceHolder>
    </tbody>
</table>
</div></div>
<div class="page">
<div class="manu" style="font-family:宋体;">
<span  style="margin:0px; padding:0px; border:none; color:#28385A; float:left;">
<asp:Label ID="lblCurrentPage" runat="server" Text="1"></asp:Label>/<asp:Label ID="lblTotalPage" runat="server"  Text="1"></asp:Label><asp:HiddenField
ID="hidTotalPage" runat="server" />
</span>
<asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
</div>
</div>
</ContentTemplate>
</asp:UpdatePanel>

<div class=tipBox id=tipBoxSearch>
<table cellSpacing=1 cellPadding=2 border=0>
<tr>
<td width="80"><strong>高级搜索：</strong></td>
<td></td>
</tr>
<tr>
<td>订单日期</td>
<td>
<link rel="stylesheet" type="text/css" href="/js/date/css/w.css"></link>
<asp:TextBox ID="txtDate1" runat="server" Width="80"></asp:TextBox>
<img id="imgDate1" class="bdpButton" alt="" border="10" src="/js/date/images/button.gif" style="height:22px;width:28px;border-width:0px;" />
 至 
<asp:TextBox ID="txtDate2" runat="server" Width="80"></asp:TextBox>
<img id="imgDate2" class="bdpButton" alt="" border="10" src="/js/date/images/button.gif" style="height:22px;width:28px;border-width:0px;" />

<script type="text/javascript">
//<![CDATA[
var BasicDatePicker1 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker1",dateFormat:"yyyy-M-d",showCalendarOnTextBoxFocus:true,todayButtonText:"今日",noneButtonText:"清空",northImage:"/js/date/images/arrow_down.gif",southImage:"/js/date/images/arrow_up.gif",eastImage:"/js/date/images/arrow_right.gif",westImage:"/js/date/images/arrow_left.gif"}).applyTo({inputID:"txtDate1",buttonID:"imgDate1"}) : alert("无法载入日期控件，请联系网站客服！");

var BasicDatePicker2 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker2",dateFormat:"yyyy-M-d",showCalendarOnTextBoxFocus:true,todayButtonText:"今日",noneButtonText:"清空",northImage:"/js/date/images/arrow_down.gif",southImage:"/js/date/images/arrow_up.gif",eastImage:"/js/date/images/arrow_right.gif",westImage:"/js/date/images/arrow_left.gif"}).applyTo({inputID:"txtDate2",buttonID:"imgDate2"}) : alert("无法载入日期控件，请联系网站客服！");
//]]>
</script>
</td>
</tr>
<tr>
<td>运价类型</td>
<td><asp:TextBox ID="txt_realname" runat="server" Width="80"></asp:TextBox></td>
</tr>
<tr>
<td>订单状态</td>
<td><asp:TextBox ID="txt_companyname" runat="server" Width="400"></asp:TextBox></td>
</tr>
<tr>
<td>
<asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" Width="80" Height="30" />
</td>
<td>
<td>
</tr>
</table>
</div>
</div>

</div>			
</div>
		<managerbottom:managerbottom id="managerbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>
