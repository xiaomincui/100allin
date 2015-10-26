<%@ Page Language="VB" AutoEventWireup="false" CodeFile="office_fcl_list.aspx.vb" Inherits="en_member_office_fcl_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/office.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../member/js/function1.js"></script>
    <style type="text/css">
    .hidden{
	display:none;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
		<enusertop:enusertop ID="enusertop1" runat="server" />
		<div class="main_page">
			<div class="dhang"><img src="../images/office/of_nav.gif" /></div>
			
			
			<enuserleft:enuserleft ID="enuserleft1" runat="server" />
			
			<div class="of_rg">

<div class="bill_box" style="line-height:18px; background:#FFFBCA; border:1px dashed #FFCC00; margin-top:8px; font-size:12px">
			    <p style="margin:0px 15px;">&nbsp;&nbsp;&nbsp;Search：&nbsp;&nbsp;ID&nbsp;
			      <asp:TextBox ID="txtYunjiaid" runat="server" CssClass="shortTextbox" Width="50px"></asp:TextBox>
			    line&nbsp;
			    <asp:DropDownList ID="txtLine" runat="server" Width=85 Font-Size="12px">
<asp:ListItem Value="">Please Choose</asp:ListItem>
<asp:ListItem Value="美加线">North America</asp:ListItem>
<asp:ListItem Value="欧地线">Euro/Med</asp:ListItem>
<asp:ListItem Value="中南美线">Middle/South America</asp:ListItem>
<asp:ListItem Value="日韩线">Japan and Korea</asp:ListItem>
<asp:ListItem Value="近洋线">Southeast Asia</asp:ListItem>
<asp:ListItem Value="非洲线">Africa</asp:ListItem>
<asp:ListItem Value="澳洲线">Australia</asp:ListItem>
<asp:ListItem Value="中东印巴线">Middle East</asp:ListItem>
<asp:ListItem Value="红海线">Red Sea</asp:ListItem>
</asp:DropDownList>
			    POL&nbsp;
			    <asp:TextBox ID="txtStartport" runat="server" CssClass="bigTextbox" Width="100px"></asp:TextBox>
			    POD&nbsp;
			    <asp:TextBox ID="txtDestport" runat="server" CssClass="bigTextbox"  Width="100px"></asp:TextBox>
			    <input type="button" name="Submit" value="Search" onclick="sendSeacch()" />
			    </p>
			</div>
			<div style="font-size:12px"><asp:Panel ID="pnlSearchIntro" runat="server" CssClass="hidden">
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
	    <td width="3%" height="32"></td>
		<td width="7%" height="32" align="center"><strong>ID</strong></td>
		<td width="10%" height="32" align="center"><strong>POD</strong></td>
		<td width="15%" height="32" align="center"><strong>Title</strong></td>
		<td width="14%" height="32" align="center"><strong>line</strong></td>
		<td width="10%" height="32" align="center"><strong>Post date</strong></td>
		<td width="10%" height="32" align="center"><strong>Valid date</strong></td>
		<td width="10%" height="32" align="center"><strong>Edit</strong></td>
	  </tr>
	  <tr>
		<td height="1" colspan="8" bgcolor="#CDCDCD"></td>
		</tr>
      <asp:Repeater ID="Repeater1" runat="server">
      <ItemTemplate>
      <tr>
      
      <td bgcolor="<%# IIF((Container.ItemIndex mod 2)=1 , "#f0f0f0" , "") %>"><input id="id" type="checkbox" value="<%# eval("id") %>" onclick="checkToList(this.form)" /></td>
		<td bgcolor="<%# IIF((Container.ItemIndex mod 2)=1 , "#f0f0f0" , "") %>"><%# Eval("id") %></td>
		<td bgcolor="<%# IIF((Container.ItemIndex mod 2)=1 , "#f0f0f0" , "") %>"><%# eval("startport") %></td>
		<td bgcolor="<%# IIF((Container.ItemIndex mod 2)=1 , "#f0f0f0" , "") %>"><a href="/en/lcl/<%# key(Eval("id")) %>_0.html" target="_blank"><strong><asp:Label ID="Label3" runat="server" Text='<%# Eval("entitle") %>'></asp:Label></strong></a></td>
		<td bgcolor="<%# IIF((Container.ItemIndex mod 2)=1 , "#f0f0f0" , "") %>"><%#LineCNtoEN(Eval("hangxianmiaoshu"))%></td>
		<td bgcolor="<%# IIF((Container.ItemIndex mod 2)=1 , "#f0f0f0" , "") %>"><%# FORMAT(Eval("postdate"), "yyyy-MM-dd").ToString()%></td>
		<td bgcolor="<%# IIF((Container.ItemIndex mod 2)=1 , "#f0f0f0" , "") %>"><%# IIF ((FORMAT(NOW(),"yyyy-MM-dd").tostring > eval("enddate")) ,"<span style=""color:#FF0000;"">" & eval("enddate") & "</span>",eval("enddate"))%></td>
		<td bgcolor="<%# IIF((Container.ItemIndex mod 2)=1 , "#f0f0f0" , "") %>"><div class="edit"><a href="office_fcl_edit.aspx?id=<%# eval("id") %>">Edit</a>&nbsp;&nbsp;<a href="javascript:delConfirm('<%# eval("id") %>')">Del</a></div></td>
	  </tr>
	  </ItemTemplate>
      </asp:Repeater>
	  
	</table>
	<table width="100%" height="32" border="0" cellpadding="0" cellspacing="5">
                    <tr>
                      <td width="35%" align="left"><strong>
                      <asp:Label ID="lblTotalItem" runat="server" Text="0" Visible="false"></asp:Label></strong><strong><asp:Label
            ID="lblCurrentPage" runat="server" Text="1"></asp:Label></strong> / <strong><asp:Label ID="lblTotalPage" runat="server"  Text="1"></asp:Label></strong></td>
                      <td width="40%" align="left"><asp:LinkButton ID="lnkFirstPage" runat="server" OnClick="lnkFirstPage_Click">First</asp:LinkButton>
                      &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkPrePage" runat="server" OnClick="lnkPrePage_Click">Prev</asp:LinkButton>
                      &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkNextPage" runat="server" OnClick="lnkNextPage_Click">next</asp:LinkButton>
                      &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkLastPage" runat="server" OnClick="lnkLastPage_Click">Last</asp:LinkButton></td>
                      <td align="center">To：
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
