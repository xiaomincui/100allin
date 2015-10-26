<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pricelist.aspx.cs" Inherits="manage_priceneed_pricelist" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>缺失运价列表</title>
    <link href="/manage/css/master.css" type="text/css" rel="stylesheet" />
    <link href="/js/date/css/w.css" type="text/css" rel="stylesheet" />	
	<script type="text/javascript" src="/js/date/w.js"></script>
	<script type="text/javascript" src="/js/date/w1.js"></script>
	<script type="text/javascript" src="/js/date/w2.js"></script>
<script language="javascript" src="/manage/js/function.js"></script>    	
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
<div class=text>缺失运价列表</div></div>
<div class="rightArea txth22">
<div class=tipBox id=tipBoxSearch>
<table cellSpacing=0 cellPadding=0 border=0>
  <tbody>
  <tr>
    <td width=80 height=20><strong>筛选结果：</strong></td>
    <td style="WIDTH: 45px">航线</td>
    <td style="WIDTH: 124px"><SELECT id=ddlLine style="WIDTH: 100px" 
      name=ddlLine> <option value="" selected>全部航线</option> <option 
        value=美加线>美加线</option> <option value=欧地线>欧地线</option> <option 
        value=中南美线>中南美线</option> <option value=日韩线>日韩线</option> <option 
        value=近洋线>近洋线</option> <option value=非洲线>非洲线</option> <option 
        value=澳洲线>澳洲线</option> <option value=中东印巴线>中东印巴线</option> <option 
        value=红海线>红海线</option></SELECT> </td>
    <td style="WIDTH: 74px">港口英文名</td>
    <td style="WIDTH: 80px"><input class=t3 id=txtStartport 
      style="WIDTH: 53px" name=txtStartport></td>
    <td style="WIDTH: 74px">港口中文名</td>
    <td style="WIDTH: 80px"><input class=t3 id=txtdestport style="WIDTH: 53px" 
      name=txtdestport></td>
    <td width=20><input id=Button2 onclick=sendSeacch() type=button value=搜索 name=Submit></td></tr></tbody></table></div>
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
      
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
<div class=listtable>
<div>
<table style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid; BORDER-COLLAPSE: collapse" 
borderColor=#d9d9d9 cellSpacing=0 cellPadding=3 rules=rows border=1>
  <tbody>
  <tr style="BACKGROUND-COLOR: #f0f0f0">
    <th scope="col" style="WIDTH: 0px"></th>
    <th scope="col" style="WIDTH: 30px"><input id=chkAll onclick=CheckAll(this.form); type=checkbox 
      name=chkAll> </th>
    <th scope="col" style="WIDTH: 30px">类型 </th>
    <th scope="col" style="WIDTH: 120px">搜索日期 </th>
    <th scope="col" style="WIDTH: 100px">航线</th>
    <th scope="col" style="WIDTH: 130px">起运港</th>
    <th scope="col" style="WIDTH: 150px">目的港</th>
    <th scope="col" style="WIDTH: 98px">船公司</th>
    <th scope="col" style="WIDTH: 30px">查询</th>
    <th scope="col" style="WIDTH: 30px">删除</th></tr>
<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate>
  <tr>
    <td style="WIDTH: 0px"></td>
    <td style="WIDTH: 30px"><input id="id" type="checkbox" value="<%# Eval("sid").ToString() %>" onclick="checkToList(this.form)" /> </td>
    <td style="WIDTH: 30px"><%#Eval("STYPE").ToString()%></td>
    <td style="WIDTH: 120px"><%#Eval("STIME").ToString()%></td>
    <td style="WIDTH: 100px"><%#Eval("LINE").ToString()%></td>
    <td style="WIDTH: 130px"><%#Eval("STARTPORT").ToString()%></td>
    <td style="WIDTH: 150px"><%#Eval("DESTPORT").ToString()%></td>
    <td style="WIDTH: 98px"><%#Eval("CARRIER").ToString()%></td>
    <td style="WIDTH: 30px" align=middle><a href="/member/editprice.aspx?id=1">编辑</a> </td>
    <td style="WIDTH: 30px" align=middle><a href="javascript:delConfirm('<%# Eval("sid").ToString() %>')">删除</a> </td></tr>
<tr><td colspan="10"><%#Eval("REALNAME").ToString()%> <%#Eval("COMPANYNAME").ToString()%> <%#Eval("USEREMAIL").ToString()%></td><tr/>
</ItemTemplate>
</asp:Repeater>
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
<div class="buttons">
<input id="Button1" type="button" value="删除选定港口" onclick="delAll()" style="width:100px; height:30px" />
<asp:Button ID="btnHidDel" runat="server" Text="Button" CssClass="" OnClick="btnHidDel_Click"/>
<asp:TextBox ID="delList" runat="server" CssClass=""></asp:TextBox>
</div>

                </ContentTemplate>
                </asp:UpdatePanel>
                    
                    </div></div>			
		  </div>
		<managerbottom:managerbottom id="managerbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>
