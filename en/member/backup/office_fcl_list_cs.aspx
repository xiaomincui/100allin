<%@ Page Language="C#" AutoEventWireup="true" CodeFile="office_fcl_list_cs.aspx.cs" Inherits="en_office" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/office.css" rel="stylesheet" type="text/css" />
    
   
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
		<enusertop:enusertop ID="enusertop1" runat="server" />
		<div class="main_page">
			<div class="dhang"><img src="../images/office/of_nav.gif" /></div>
			
			
			<enuserleft:enuserleft ID="enuserleft1" runat="server" />
			
			<div class="of_rg">

<div class="bill_box" style="line-height:18px; background:#FFFBCA; border:1px dashed #FFCC00; margin-top:8px;">
			    <p style="margin:0px 15px;">&nbsp;&nbsp;&nbsp;搜索我的整箱运价：&nbsp;编号
			      <asp:TextBox ID="txtYunjiaid" runat="server" CssClass="shortTextbox" Width="51px"></asp:TextBox>
			    航线
			    <asp:DropDownList ID="txtLine" runat="server" Width=85 Font-Size="12px">
                <asp:ListItem Text="全部航线" Value=""></asp:ListItem>
                <asp:ListItem>美加线</asp:ListItem>
                <asp:ListItem>欧地线</asp:ListItem>
                <asp:ListItem>中南美线</asp:ListItem>
                <asp:ListItem>日韩线</asp:ListItem>
                <asp:ListItem>近洋线</asp:ListItem>
                <asp:ListItem>非洲线</asp:ListItem>
                <asp:ListItem>澳洲线</asp:ListItem>
                <asp:ListItem>中东印巴线</asp:ListItem>
                <asp:ListItem>红海线</asp:ListItem>
            </asp:DropDownList>
			    起运港
			    <asp:TextBox ID="txtStartport" runat="server" CssClass="bigTextbox" Width="100px"></asp:TextBox>
			    目的港
			    <asp:TextBox ID="txtDestport" runat="server" CssClass="bigTextbox"  Width="100px"></asp:TextBox>
			    <input type="button" name="Submit" value="搜索" onclick="sendSeacch()" />
			    </p>
			</div>
			<div><asp:Panel ID="pnlSearchIntro" runat="server" CssClass="hidden">
      <table border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="200px">搜索结果：&nbsp;</td>
          <td width="570px"><div style="text-align:right;">您搜索的是：&nbsp;<strong><asp:Label ID="hidTxtYunjiaid" runat="server">
          </asp:Label>&nbsp;&nbsp;<asp:Label ID="hidTxtLine" runat="server" >
          </asp:Label>&nbsp;&nbsp;<asp:Label ID="hidTxtStartport" runat="server" >
          </asp:Label>&nbsp;&nbsp;<asp:Label ID="hidTxtDestport" runat="server" >
          </asp:Label></strong>&nbsp;，环球运费网共为您找到&nbsp;<strong><asp:Label ID="hidTotalItem" runat="server" ></asp:Label></strong>&nbsp;条记录&nbsp;&nbsp;&nbsp;&nbsp;<span class="edit"><asp:LinkButton ID="lnkShowAll" runat="server" Text="显示我所有的整箱运价"></asp:LinkButton></span></div></td>
        </tr>
      </table>
      </asp:Panel></div>
				<div class="of_rg_box">
					<h2>Business info</h2>
					<h3><table width="612" border="0" align="center" cellpadding="0" cellspacing="0">
	  <tr>
		<td width="10%" height="32"><strong>ID</strong></td>
		<td width="11%" height="32"><strong>POD</strong></td>
		<td width="35%" height="32"><strong>Title</strong></td>
		<td width="11%" height="32"><strong>line</strong></td>
		<td width="10%" height="32"><strong>Post date</strong></td>
		<td width="10%" height="32"><strong>Valid date</strong></td>
		<td width="11%" height="32"><strong>Edit</strong></td>
	  </tr>
	  <tr>
		<td height="1" colspan="7" bgcolor="#CDCDCD"></td>
		</tr>
      <asp:Repeater ID="Repeater1" runat="server">
      <ItemTemplate>
      <tr>
		<td ><%# Eval("id") %></td>
		<td bgcolor="<%# Container.ItemIndex%2==0 ? "#f0f0f0" : "" %>"><%# Eval("startport")%></td>
		<td><a href="/en/lcl/<%# key(Eval("id")) %>_0.html" target="_blank"><strong><asp:Label ID="Label3" runat="server" Text='<%# Eval("title") %>'></asp:Label></strong></a></td>
		<td><%# Eval("hangxianmiaoshu") %></td>
		<td><%# FORMAT(Eval("postdate"), "yyyy-MM-dd").ToString()%></td>
		<td><%# IIF ((FORMAT(NOW(),"yyyy-MM-dd").ToString() > eval("enddate")) ,"<span style=""color:#FF0000;"">" & eval("enddate") & "</span>",eval("enddate"))%></td>
		<td><%# eval("title") %></td>
	  </tr>
	  </ItemTemplate>
      </asp:Repeater>
	  <tr>
		<td>Cooperation</td>
		<td>Cooperation</td>
		<td>Cooperation</td>
		<td>2</td>
	  </tr>
	  <tr>
		<td bgcolor="#f0f0f0">Cooperation</td>
		<td bgcolor="#f0f0f0">Cooperation</td>
		<td bgcolor="#f0f0f0">Cooperation</td>
		<td bgcolor="#f0f0f0">2</td>
	  </tr>
	  <tr>
		<td>Cooperation</td>
		<td>Cooperation</td>
		<td>Cooperation</td>
		<td>2</td>
	  </tr>
	  <tr>
		<td bgcolor="#F0F0F0">Cooperation</td>
		<td bgcolor="#F0F0F0">Cooperation</td>
		<td bgcolor="#F0F0F0">Cooperation</td>
		<td bgcolor="#F0F0F0">2</td>
	  </tr>
	  <tr>
		<td>Cooperation</td>
		<td>Cooperation</td>
		<td>Cooperation</td>
		<td>2</td>
	  </tr>
	</table>
	<table width="100%" height="32" border="0" cellpadding="0" cellspacing="5">
                    <tr>
                      <td width="35%" align="left">共 <strong><asp:Label ID="lblTotalPage" runat="server"  Text="1"></asp:Label></strong>页<strong>
                      <asp:Label ID="lblTotalItem" runat="server" Text="0"></asp:Label></strong>条记录 &nbsp;以上是第 <strong><asp:Label
            ID="lblCurrentPage" runat="server" Text="1"></asp:Label></strong>页</td>
                      <td width="35%" align="left"><asp:LinkButton ID="lnkFirstPage" runat="server" OnClick="lnkFirstPage_Click">第一页</asp:LinkButton>
                      &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkPrePage" runat="server" OnClick="lnkPrePage_Click">上一页</asp:LinkButton>
                      &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkNextPage" runat="server" OnClick="lnkNextPage_Click">下一页</asp:LinkButton>
                      &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkLastPage" runat="server" OnClick="lnkLastPage_Click">最后页</asp:LinkButton></td>
                      <td align="center">直接翻页：
                          <asp:DropDownList ID="ddlPageSelect" runat="server" CssClass="pageDropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSelect_SelectedIndexChanged"></asp:DropDownList>                      </td>
                    </tr>
                  </table>
                  <div class="listTable"><input id="Button1" type="button" value="Delete" onclick="delAll()" style="width:100px; height:30px" />
				  <input id="Button2" type="button" value="Update" onclick="updateAll()" style="width:100px; height:30px" />
        <asp:Button ID="btnHidDel" runat="server" Text="Button" CssClass="hidden" OnClick="btnHidDel_Click"/>
        <asp:Button ID="btnHidUpdate" runat="server" Text="Button" CssClass="hidden" OnClick="btnHidUpdate_Click"/>
        <asp:TextBox ID="delList" runat="server" CssClass="hidden"></asp:TextBox>
        <asp:Button ID="btnHidSearch" runat="server" Text="Button" CssClass="hidden"/>
	</div>
	
					</h3>
				</div>
			</div>
		    <div class="foot"><a href="#">About Us</a>︱<a href="#">Privacy Policy</a>︱<a href="#">Terms Of Use Agreement</a>︱ <a href="#">Site Map</a>︱<a href="#">Contact Us</a></div>
		</div>
	</div>
    </form>
</body>
</html>
