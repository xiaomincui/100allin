<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage_account.aspx.cs" Inherits="admin_order_manage_account" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" ><head><meta http-equiv="content-type" content="text/html; charset=UTF-8" /><title>
    用户帐户</title>
<link href="../css/master.css" rel="stylesheet" type="text/css" />
<link href="../css/userlist.css" rel="stylesheet" type="text/css" />
<script src="/member/order/admin/js/manage_account.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<div id="page">
<div id="center">
<admintop:admintop ID="admintop1" runat="server" />
<adminmenu:adminmenu id="adminmenu1" runat="server" />
<div id="main">
<adminleft:adminleft ID="adminleft1" runat="server" />										
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
<th scope="col" style="width:200px;">公司名</th>
<th scope="col" style="width:80px;">真实姓名</th>
<th scope="col" style="width:80px;">用户名</th>
<th scope="col" style="width:60px;">状态</th>
<th scope="col" style="width:90px;">余额 / 预存</th>
<th scope="col" style="width:100px;">操作</th>
<th scope="col" style="width:40px;">历史</th>
</tr>
<asp:Repeater ID="RptAccount" runat="server">
<ItemTemplate>
<tr onmouseover="this.style.backgroundColor='#F4F7FB';" onmouseout="this.style.backgroundColor='#ffffff';">
<td style="width:3px;height:60px;"></td>
<td style="width:60px;"><%#Eval("userid").ToString() %></td>
<td style="width:200px;"><%#highlight(Eval("companyname").ToString())%></td>
<td style="width:80px;"><%#highlight(Eval("realname").ToString())%></td>
<td style="width:80px;"><%#highlight(Eval("username").ToString())%></td>
<td style="width:60px;"><%#Eval("status_name").ToString()%></td>
<td style="width:90px;"><%#Eval("overage").ToString()%> / <%#Eval("credit").ToString()%></td>
<td style="width:100px;"><%#Eval("status_op").ToString().Replace("{1}", Eval("userid").ToString()).Replace("{2}", Eval("credit").ToString()).Replace("{3}", Eval("overage").ToString())%>&nbsp;</td>
<td style="width:40px;">历史</td>
</td>
</tr>
</ItemTemplate>
</asp:Repeater>
</table>

<div style="display:none;">

<asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
<asp:TextBox ID="txtCredits" runat="server"></asp:TextBox>
<asp:TextBox ID="txtOverage" runat="server"></asp:TextBox>
<asp:Button ID="btnCreate" runat="server" Text="开户" OnClick="btnCreate_Click" />
<asp:Button ID="btnForbidden" runat="server" Text="冻结" OnClick="btnForbidden_Click" />
<asp:Button ID="btnEnabled" runat="server" Text="恢复" OnClick="btnEnabled_Click" />
<asp:Button ID="btnClose1" runat="server" Text="关闭1" OnClick="btnClose1_Click" />
<asp:Button ID="btnClose2" runat="server" Text="关闭2" OnClick="btnClose2_Click" />
<asp:Button ID="btnCredits" runat="server" Text="预存费" OnClick="btnCredits_Click" />
<asp:Button ID="btnOverage" runat="server" Text="余额" OnClick="btnOverage_Click" />

</div>

<div style="position:absolute; top:100px; left:300px; border:1px solid #999999; background:#FFFFFF; text-align:center; padding:10px; display:none;" id="divTempOverage">
    请设置该用户的帐户余额<br/>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
        RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="1" Selected="True">增加</asp:ListItem>
        <asp:ListItem Value="0">减少</asp:ListItem>
    </asp:RadioButtonList>
    <br/>
<input type="text" id="txtTempOverage" value="0"/><input type="text" id="txtTempCode1" style="display:none;" /><br />
<input type="button" onclick="javascript:AcceptOverage();" value="确定" id="Button1"/> 
<input type="button" onclick="javascript:CloseOverage();" value="取消" id="Button2"/>
</div>

<div style="position:absolute; top:100px; left:300px; border:1px solid #999999; background:#FFFFFF; text-align:center; padding:10px; display:none;" id="divTempCredits">
    请设置该用户的帐户预存费<br/>
    <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
        RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="1" Selected="True">增加</asp:ListItem>
        <asp:ListItem Value="0">减少</asp:ListItem>
    </asp:RadioButtonList>
    <br/>
<input type="text" id="txtTempCredits" value="0" /><input type="text" id="txtTempCode" style="display:none;" /><input type="text" id="txtTempCreditsOrigin" style="display:none;" runat="server" /><br />
<input type="button" onclick="javascript:AcceptCredits();" value="确定" id="TempOk"/> 
<input type="button" onclick="javascript:CloseCredits();" value="取消" id="TempCancel"/>
</div>

</ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress ID="UpdateProgress1" runat="server">
<ProgressTemplate>
<div style="position:absolute; top:100px; left:200px; border:1px solid #999999; background:#FFFFFF; text-align:center; padding:10px;">
    正在处理，请稍候...<br/>
<img src="/member/images/loading5.gif" alt=""/>
</div>
</ProgressTemplate>
</asp:UpdateProgress>

</div>
</div>
</div>
</div>			
</div>
<adminbottom:adminbottom ID="adminbottom1" runat="server" />
</div>
</div>

</form>
</body>
</html>
