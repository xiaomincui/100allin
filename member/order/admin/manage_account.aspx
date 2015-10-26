<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage_account.aspx.cs" Inherits="pro_admin_manage_account" EnableEventValidation="false" EnableViewState="false" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="content-type" content="text/html; charset=UTF-8" />
<title>整箱运价订舱</title>
<link href="../order/css/master.css" rel="stylesheet" type="text/css" />
<link href="../order/css/userlist.css" rel="stylesheet" type="text/css" />
<script src="js/manage_account.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<div id="page">
<div id="center">
<protop:protop ID="protop1" runat="server" />
<div id="main">
<proleft:proleft ID="proleft1" runat="server" />										
<div id="right">
<div class="tt18 bd rightTitle">
<div class="text"><asp:Literal ID="ltrHeadTitle" runat="server"></asp:Literal></div>
</div>
<div class="rightArea txth22">
<div id="tipBoxSearch" class="tipBox">
<table border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="20">
<asp:Literal ID="ltrOrderAll" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;
<asp:Literal ID="ltrOrderOpen" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;
<asp:Literal ID="ltrOrderClose" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;
<asp:Literal ID="ltrOrderForbidden" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;
<span style="margin-left:360px;">
<asp:TextBox ID="txtSearch" runat="server" Width="200px"></asp:TextBox> 
<asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click" /></span>
</td>
</tr> 
</table>
</div>
<div class="listTable">
<div style="position:relative;">
<asp:ScriptManager ID="ScriptManager2" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<table cellspacing="0" cellpadding="3" rules="rows" bordercolor ="#D9D9D9" border="1" id="GridView1" style="border-width:1px;border-style:Solid;border-collapse:collapse;">
<tr style="background-color:#F0F0F0;">
<th scope="col" style="width:3px;"></th>
<th scope="col" style="width:60px;">编号</th>
<th scope="col" style="width:230px;">公司名</th>
<th scope="col" style="width:80px;">真实姓名</th>
<th scope="col" style="width:80px;">用户名</th>
<th scope="col" style="width:60px;">状态</th>
<th scope="col" style="width:60px;">余额</th>
<th scope="col" style="width:100px;">操作</th>
<th scope="col" style="width:40px;">历史</th>
</tr>
<asp:Repeater ID="RptAccount" runat="server">
<ItemTemplate>
<tr onmouseover="this.style.backgroundColor='#F4F7FB';" onmouseout="this.style.backgroundColor='#ffffff';">
<td style="width:3px;height:40px;"></td>
<td style="width:60px;"><%#Eval("userid").ToString() %></td>
<td style="width:230px;"><%#highlight(Eval("companyname").ToString())%></td>
<td style="width:80px;"><%#highlight(Eval("realname").ToString())%></td>
<td style="width:80px;"><%#highlight(Eval("username").ToString())%></td>
<td style="width:60px;"><%#Eval("status_name").ToString()%></td>
<td style="width:60px;"><%#Eval("credit").ToString()%></td>
<td style="width:100px;"><%#Eval("status_op").ToString().Replace("{1}", Eval("userid").ToString()).Replace("{2}", Eval("credit").ToString())%>&nbsp;</td>
<td style="width:40px;">历史</td>
</td>
</tr>
</ItemTemplate>
</asp:Repeater>
</table>

<div style="display:none;">

<asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
<asp:TextBox ID="txtCredits" runat="server"></asp:TextBox>
<asp:Button ID="btnCreate" runat="server" Text="开户" OnClick="btnCreate_Click" />
<asp:Button ID="btnForbidden" runat="server" Text="冻结" OnClick="btnForbidden_Click" />
<asp:Button ID="btnEnabled" runat="server" Text="恢复" OnClick="btnEnabled_Click" />
<asp:Button ID="btnClose1" runat="server" Text="关闭1" OnClick="btnClose1_Click" />
<asp:Button ID="btnClose2" runat="server" Text="关闭2" OnClick="btnClose2_Click" />
<asp:Button ID="btnCredits" runat="server" Text="余额" OnClick="btnCredits_Click" />

</div>
</ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress ID="UpdateProgress1" runat="server">
<ProgressTemplate>
<div style="position:absolute; top:100px; left:200px; border:1px solid #999999; background:#FFFFFF; text-align:center; padding:10px;">
正在处理，请稍候...<br/>
<img src="/pro/order/images/loading5.gif" alt=""/>
</div>
</ProgressTemplate>
</asp:UpdateProgress>
<div style="position:absolute; top:100px; left:300px; border:1px solid #999999; background:#FFFFFF; text-align:center; padding:10px; display:none;" id="divTempCredits">
请设置该用户的帐户余额<br/>
<input type="text" id="txtTempCredits" /><input type="text" id="txtTempCode" style="display:none;" /><br />
<input type="button" onclick="javascript:AcceptCredits();" value="确定" id="TempOk"/> 
<input type="button" onclick="javascript:CloseCredits();" value="取消" id="TempCancel"/>
</div>
</div>
</div>
</div>
</div>			
</div>
<probottom:probottom ID="probottom1" runat="server" />
</div>
</div>

</form>
</body>
</html>
