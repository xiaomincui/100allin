<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cargolist.aspx.vb" Inherits="member_shippinglist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>环球运费网 - 我的办公室 - 海运货盘列表</title>
    <link href="css/offices.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="js/function1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main_container">
		<memberheader:memberheader ID="memberheader1" runat="server" />
		<div class="center">
			<memberleft:memberleft ID="memberleft1" runat="server" />	
		  <div class="main">
				<memberwelcome:memberwelcome ID="memberwelcome1" runat="server" />
				<div class="fcl_tit"><table width="100%" border="0" cellspacing="1" cellpadding="0">
  <tr>
    <td width="6%" align="center"><img src="images/edit_icon.gif" /></td>
    <td width="44%"><strong>我的海运货盘</strong></td>
    <td width="50%" align="right"></td>
  </tr>
</table>
</div>
				
			
			<div class="fcl" style="padding:0px;">
			  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                  <td height="28" align="center" style=" width:50px"><input type="checkbox" name="checkbox" value="checkbox" /></td>
                  <td colspan="7" height="32" align="center"  style=" width:300px"><strong>标题</strong></td>
                  <td align="center"  style="width:60px"><strong>操作</strong></td>
                </tr>
                  
                  <asp:Repeater ID="Repeater1" runat="server">
                  <ItemTemplate>
                  <tr>
                  <td height="28" align="center" bgcolor="#FFFFFF"  style=" width:50px"><input id="id" type="checkbox" value="<%# eval("id") %>" onclick="checkToList(this.form)" /></td>
                  <td height="32"  colspan="7" align="center" bgcolor="#FFFFFF" style=" width:300px"><asp:Label ID="Label1" runat="server" Text='<%# eval("title") %>'></asp:Label></td>


                  <td align="center" bgcolor="#FFFFFF"  style="width:60px">
                  <div class="edit"><a href="Cargojilu.aspx?id=<%# eval("id") %>">编辑</a>&nbsp;&nbsp;<a href="javascript:delConfirm('<%# eval("id") %>')">删除</a></div>
                  </td>
                  
                  
                  
                </tr>
                  </ItemTemplate>
                  </asp:Repeater>
			  
                
				<tr>
				  <td height="32" colspan="9" align="center" bgcolor="#E8F6FF">
				  
				  <table width="100%" height="32" border="0" cellpadding="0" cellspacing="5">
                    <tr>
                      <td width="35%" align="left">共 <strong><asp:Label ID="lblTotalPage" runat="server"  Text="1"></asp:Label></strong>页<strong>
                      <asp:Label ID="lblTotalItem" runat="server" Text="0"></asp:Label></strong>条记录 &nbsp;以上是第 <strong><asp:Label
            ID="lblCurrentPage" runat="server" Text="1"></asp:Label></strong>页</td>
                      <td width="40%" align="left"><asp:LinkButton ID="lnkFirstPage" runat="server">第一页</asp:LinkButton>
                      &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkPrePage" runat="server">上一页</asp:LinkButton>
                      &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkNextPage" runat="server">下一页</asp:LinkButton>
                      &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkLastPage" runat="server">最后页</asp:LinkButton></td>
                      <td align="center">直接翻页：
                          <asp:DropDownList ID="ddlPageSelect" runat="server" CssClass="pageDropdown" AutoPostBack="true"></asp:DropDownList>                      </td>
                    </tr>
                  </table>
                  
                
                
                
                  
                  </td>
			    </tr>
			    <tr>
				  <td height="32" colspan="8" bgcolor="#E8F6FF">
				  <div class="listTable"><input id="Button1" type="button" value="删除选定运价" onclick="delAll()" style="width:100px; height:30px" />
        <asp:Button ID="btnHidDel" runat="server" Text="Button" CssClass="hidden"/>
        <asp:TextBox ID="delList" runat="server" CssClass="hidden"></asp:TextBox>
        <asp:Button ID="btnHidSearch" runat="server" Text="Button" CssClass="hidden"/>
	</div>
				  </td>
			    </tr>
              </table>
              
              
			</div>
		  </div>
		</div>
		<memberfooter:memberfooter ID="memberfooter1" runat="server" />
	</div>
    </form>
</body>
</html>
