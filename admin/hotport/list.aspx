<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="admin_hotport_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="../css/master.css" rel="stylesheet" type="text/css" />
    <link href="../css/userlist.css" rel="stylesheet" type="text/css" />
    <script language=javascript src=../js/function.js></script>
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
			<admintop:admintop id="admintop1" runat="server" />
			<adminmenu:adminmenu id="adminmenu1" runat="server" />
		  <div id="main">
			<adminleft:adminleft id="adminleft1" runat="server" />												
		  	<div id="right">
				<div class="tt18 bd rightTitle">
					<div class="icon"><img src="../images/home_title.gif" /></div>
					<div class="text">热门港口</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">热门港口列表</div>
				</div>
				<div class="rightArea txth22">
	                <div id="tipBoxSearch" class="tipBox"  style="display:none;">
	                <table border="0" cellspacing="0" cellpadding="0" height="30px">
	                  <tr>
	                    <td width="80" height="20"><strong>搜索用户：</strong></td>
	                    <td width="35">编号</td>
                        <td width="106px"><asp:TextBox ID="txtYunjiaid" runat="server" CssClass="t2"></asp:TextBox></td>
	                    <td style="width: 45px">
                            用户名
                        </td>
	                    <td width="110">  
                            <asp:TextBox ID="txtLine" runat="server" CssClass="t2"></asp:TextBox>
                        </td>
	                    <td style="width: 60px">
                            真实姓名</td>
	                    <td style="width: 106px"><asp:TextBox ID="txtStartport" runat="server" CssClass="t2"></asp:TextBox></td>
	                    <td style="width: 35px">
                            邮件</td>
	                    <td width="146"><asp:TextBox ID="txtEmail" runat="server" CssClass="t2"></asp:TextBox></td>
	                    <td style="width: 20px"> </td>
	                  </tr>
	                 </table>
	                 <table border="0" cellspacing="0" cellpadding="0" height="30px">
	                  <tr>
	                    <td width="80" height="20"></td>
	                    <td width="35">电话</td>
                        <td width="106"><asp:TextBox ID="txtTel" runat="server" CssClass="t2"></asp:TextBox></td>
	                    <td style="width: 45px">
                            手机
                        </td>
	                    <td width="110">  
                            <asp:TextBox ID="txtMobile" runat="server" CssClass="t2"></asp:TextBox>
                        </td>
	                    <td style="width: 60px">
                            公司名称</td>
	                    <td style="width: 161px"><asp:TextBox ID="txtDestport" runat="server" CssClass="t3"></asp:TextBox></td>
	                    
	                  </tr>
	                 </table>
	                 
	                 <table border="0" cellspacing="0" cellpadding="0" height="30px">
	                  <tr>
	                  <td width="80" height="20"></td>
	                    <td style="width: 35px"> 
                            状态</td>
	                    <td style="width: 20px"> 
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem Selected="True" Value="全部">全部</asp:ListItem>
                                <asp:ListItem Value="0">待定</asp:ListItem>
                                <asp:ListItem Value="1">正确</asp:ListItem>
                                <asp:ListItem Value="2">错误</asp:ListItem>
                            </asp:DropDownList></td>
	                  </tr>
	                 </table>	  
	                 
	                 
	                 
	                 	                 
	                 <table border="0" cellspacing="0" cellpadding="0" width="100%">
	                  <tr>
	                    <td align="center">
	                        <input type="button" name="Submit" value="搜索" onclick="sendSeacch()" id="Button2" style="width:60px; height:30px;" />
	                    </td>
	                  </tr>
	                 </table>
	                </div>
                    
                    <div class="listTable">
<table cellspacing="0" cellpadding="3" rules="rows" id="Table1" style="border-width:1px;border-style:Solid;border-collapse:collapse; border-color:#D9D9D9">
<tr style="background-color:#F0F0F0;">
<td></td>
<td><input id="chkAll" name="chkAll" type="checkbox" onclick="CheckAll(this.form);" /></td>
<td><strong>编号</strong></td>
<td><strong>起运港</strong></td>
<td><strong>目的港</strong></td>
<td><strong>类型</strong></td>
<td><strong>次序</strong></td>
<td><strong>编辑</strong></td>
<td><strong>删除</strong></td>
</tr>
<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate>
<tr onmouseover="this.style.backgroundColor='#F4F7FB';" onmouseout="this.style.backgroundColor='#ffffff';">
<td style="width:0px;"></td>
<td style="width:30px;"><input id="id" type="checkbox" value="<%# Eval("hid").ToString() %>" onclick="checkToList(this.form)" /></td>
<td style="width:35px;"><%# Eval("hid").ToString() %></td>
<td style="width:200px;"><%# Eval("startport").ToString() %></td>
<td style="width:259px;"><%# Eval("destport").ToString() %></td>
<td style="width:70px;"><%# totype(Eval("htype").ToString())%></td>
<td style="width:70px;"><%# Eval("horder").ToString() %></td>
<td style="width:30px;"><a href="edit.aspx?id=<%# Eval("hid") %>"><img src="/admin/images/edit.gif" border=0 /></a></td>
<td style="width:30px;"><a href="javascript:delConfirm('<%# Eval("hid") %>')"><img src="/admin/images/del.gif" border=0 /></a></td>
</tr>
</ItemTemplate>
</asp:Repeater>
</table>
                    </div>
                    <div class="page"><div class="pageCount">共&nbsp;<strong><asp:Label ID="lblTotalPage" runat="server"  Text="1" Visible="false"></asp:Label>1</strong>&nbsp;页&nbsp;<strong><asp:Label
                            ID="lblTotalItem" runat="server" Text="0"></asp:Label></strong>&nbsp;条记录&nbsp;&nbsp;以上是第&nbsp;<strong><asp:Label
                            ID="lblCurrentPage" runat="server" Text="1"></asp:Label></strong>&nbsp;页</div><div class="pageControl">
                                <asp:LinkButton ID="lnkFirstPage" runat="server" OnClick="lnkFirstPage_Click">第一页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkPrePage" runat="server" OnClick="lnkPrePage_Click">上一页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkNextPage" runat="server" OnClick="lnkNextPage_Click">下一页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkLastPage" runat="server" OnClick="lnkLastPage_Click">最后页</asp:LinkButton>
                                </div>
                        <div class="pageText">直接翻页：</div>
                        <div class="pageSelect">
                        <asp:DropDownList ID="ddlPageSelect" runat="server" CssClass="pageDropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSelect_SelectedIndexChanged">
                        </asp:DropDownList>
                      </div>
                    </div>
                    <div class="buttons">
                        <input id="Button1" type="button" value="删除选定记录" onclick="delAll()" style="width:100px; height:30px" />
                        <asp:Button ID="btnHidDel" runat="server" Text="Button" CssClass="hidden" OnClick="btnHidDel_Click"/>
                        <asp:TextBox ID="delList" runat="server" CssClass="hidden"></asp:TextBox>
                        <asp:Button ID="btnHidSearch" runat="server" Text="Button" CssClass="hidden" OnClick="btnHidSearch_Click"/>
                    </div>                  
			    </div>			
			</div>			
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>

