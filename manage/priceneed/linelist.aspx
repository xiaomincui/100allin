<%@ Page Language="C#" AutoEventWireup="true" CodeFile="linelist.aspx.cs" Inherits="manage_priceneed_linelist" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>缺失航线列表</title>
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
<div class=text>缺失运价</div></div>
<div class="tt14 bd rightSubTitle">
<div class=text>缺失航线列表</div></div>
<div class="rightArea txth22">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="buttons">
<a href="addline.aspx">新建</a> | <a href="javascript:void(0)" onclick="delAll()">删除选定</a>
<asp:Button ID="btnHidDel" runat="server" Text="Button" CssClass="hidden" OnClick="btnHidDel_Click"/>
<asp:TextBox ID="delList" runat="server" CssClass="hidden"></asp:TextBox>
</div>
<div class=hidden id=pnlSearchIntro>
<table cellSpacing=0 cellPadding=0 border=0>
  <tbody>
  <tr>
    <td width=500>&nbsp;&nbsp;&nbsp;&nbsp;<strong>您的筛选</strong> 
      &nbsp;&nbsp;找到：<strong><SPAN id=hidddlSuccess></SPAN></strong> 
      &nbsp;&nbsp;类型：<strong><SPAN id=hidddlStype></SPAN></strong> 
      &nbsp;&nbsp;航线：<strong><SPAN id=hidddlLine></SPAN></strong> 
      &nbsp;&nbsp;启运港：<strong><SPAN id=hidTxtStartport></SPAN></strong> 
      &nbsp;&nbsp;目的港：<strong><SPAN id=hidTxtdestport></SPAN></strong> &nbsp; 
</td>
    <td width=270>
      <div style="TEXT-ALIGN: right">共有&nbsp;<strong><SPAN 
      id=hidTotalItem>1527</SPAN></strong>&nbsp;条记录&nbsp;&nbsp;&nbsp;&nbsp;<SPAN 
      class=edit><A id=lnkShowAll 
      href="javascript:__doPostBack('lnkShowAll','')">显示所有记录</A></SPAN></div></td></tr></tbody></table></div>
      

<div class=listtable>
<div>
<table style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid; BORDER-COLLAPSE: collapse" borderColor=#d9d9d9 cellSpacing=0 cellPadding=3 rules=rows border=1>
  <tbody>
  <tr style="BACKGROUND-COLOR: #f0f0f0">
    <TH scope=col style="WIDTH: 0px"></TH>
    <TH scope=col style="WIDTH: 30px"><input id=chkAll onclick=CheckAll(this.form); type=checkbox 
      name=chkAll> </TH>
    <TH scope=col style="WIDTH: 50px">方式</TH>
    <TH scope=col style="WIDTH: 160px">更新日期 </TH>
    <TH scope=col style="WIDTH: 50px">类型</TH>
    <TH scope=col style="WIDTH: 140px">起运港</TH>
    <TH scope=col style="WIDTH: 80px">航线</TH>
    <TH scope=col style="WIDTH: 60px">优先级别</TH>
    <TH scope=col style="WIDTH: 58px">热度</TH>
    <TH scope=col style="WIDTH: 30px">显示</TH>
    <TH scope=col style="WIDTH: 30px">编辑</TH>
    <TH scope=col style="WIDTH: 30px">删除</TH></tr>
<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate>
  <tr onmouseover="this.style.backgroundColor='#F4F7FB';" onmouseout="this.style.backgroundColor='#ffffff';">
    <td style="WIDTH: 0px"></td>
    <td style="WIDTH: 30px"><input id="id" type="checkbox" value="<%# Eval("lid").ToString() %>" onclick="checkToList(this.form)" /> </td>
    <td style="WIDTH: 50px"><%#(Eval("ltype").ToString()=="0"?"手工":"自动")%></td>
    <td style="WIDTH: 160px"><%#Eval("ltime").ToString()%></td>
    <td style="WIDTH: 50px"><%#(Eval("lftype").ToString()=="8"?"整箱":(Eval("lftype").ToString()=="9"?"拼箱":"空运"))%></td>
    <td style="WIDTH: 140px"><%#Eval("startport").ToString()%></td>
    <td style="WIDTH: 80px"><%#Eval("line").ToString()%></td>
    <td style="WIDTH: 60px"><%#Eval("lorder").ToString()%></td>
    <td style="WIDTH: 58px"><%#Eval("lhot").ToString()%></td>
    <td style="WIDTH: 30px"><%#(Eval("lhidden").ToString()=="0"?"是":"否")%></td>
    <td style="WIDTH: 30px" align=middle><a href="addline.aspx?id=<%# Eval("lid").ToString() %>">编辑</a> </td>
    <td style="WIDTH: 30px" align=middle><a href="javascript:delConfirm('<%# Eval("lid").ToString() %>')">删除</a> </td></tr>
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
<td>方式</td>
<td>
<asp:RadioButtonList ID="rbl_ltype" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radiolist">
  <asp:ListItem Value="" Selected="True">所有</asp:ListItem>
  <asp:ListItem Value="0">手工</asp:ListItem>
  <asp:ListItem Value="1">自动</asp:ListItem>
</asp:RadioButtonList>
</td>
</tr>
<tr>
<td>更新日期</td>
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
<td>类型</td>
<td>
<asp:RadioButtonList ID="rbl_lftype" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radiolist">
  <asp:ListItem Value="" Selected="True">所有</asp:ListItem>
  <asp:ListItem Value="8">整箱</asp:ListItem>
  <asp:ListItem Value="9">拼箱</asp:ListItem>
  <asp:ListItem Value="10">空运</asp:ListItem>
</asp:RadioButtonList>
</td>
</tr>
<tr>
<td>起运港</td>
<td><asp:TextBox ID="txt_lstartport" runat="server" Width="80"></asp:TextBox></td>
</tr>
<tr>
<td>航线</td>
<td>

                              <asp:RadioButtonList ID="rbl_line1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radiolist">
                                   <asp:ListItem Selected="True" Value="">所有</asp:ListItem>
                                   <asp:ListItem Value="美加线">美加线</asp:ListItem>
                                  <asp:ListItem Value="欧地线">欧地线</asp:ListItem>
                                  <asp:ListItem Value="中南美线">中南美线</asp:ListItem>
                                  <asp:ListItem Value="日韩线">日韩线</asp:ListItem>
                                  <asp:ListItem Value="近洋线">近洋线</asp:ListItem>
                                  <asp:ListItem Value="非洲线">非洲线</asp:ListItem>
                                  <asp:ListItem Value="澳洲线">澳洲线</asp:ListItem>
                                  <asp:ListItem Value="中东印巴线">中东印巴线</asp:ListItem>
                                  <asp:ListItem Value="红海线">红海线</asp:ListItem>
                              </asp:RadioButtonList>
                              <asp:RadioButtonList ID="rbl_line2" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radiolist">
                                  <asp:ListItem Selected="True" Value="">所有</asp:ListItem>
                                  <asp:ListItem Value="北美线">北美线</asp:ListItem>
                                  <asp:ListItem Value="欧地线">欧洲线</asp:ListItem>
                                  <asp:ListItem Value="南美线">南美线</asp:ListItem>
                                  <asp:ListItem Value="亚洲线">亚洲线</asp:ListItem>
                                  <asp:ListItem Value="非洲线">非洲线</asp:ListItem>
                                  <asp:ListItem Value="澳洲线">澳洲线</asp:ListItem>
                                  <asp:ListItem Value="国内航线">国内航线</asp:ListItem>
                              </asp:RadioButtonList>                              
</td>
</tr>
<tr>
<td>显示</td>
<td>
<asp:RadioButtonList ID="rbl_hidden" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radiolist">
  <asp:ListItem Value="" Selected="True">所有</asp:ListItem>
  <asp:ListItem Value="0">是</asp:ListItem>
  <asp:ListItem Value="1">否</asp:ListItem>
</asp:RadioButtonList>
</td>
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
