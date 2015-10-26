<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userdataprice.aspx.cs" Inherits="admin_userdataprice" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="css/master.css" rel="stylesheet" type="text/css" />
    <link href="css/searchwordslist.css" rel="stylesheet" type="text/css" />
    <LINK href="css/WebResource.css" type=text/css rel=stylesheet />
    <script language=javascript src=js/function.js></script>    
    <script type="text/javascript" language="javascript" src="../Web_Admin/include/calendar.js"></script>
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
					<div class="text">用户管理</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">
                        <asp:Literal ID="ltrRealname" runat="server"></asp:Literal> 的运价分析</div>
				</div>	
				<div class="rightArea txth22" style="font-size:14px; line-height:25px;">
				<table border="1">
				<tr>
				<td>置顶详情</td><td>起运港</td><td>航线</td><td>目的港</td><td>船公司</td>
				</tr>
				<tr>
				<td>整箱海运</td><td><asp:Literal ID="Literal1" runat="server"></asp:Literal></td><td><asp:Literal ID="Literal2" runat="server"></asp:Literal></td><td><asp:Literal ID="Literal3" runat="server"></asp:Literal></td><td><asp:Literal ID="Literal4" runat="server"></asp:Literal></td>
				</tr>
				<tr>
				<td>拼箱海运</td><td><asp:Literal ID="Literal5" runat="server"></asp:Literal></td><td><asp:Literal ID="Literal6" runat="server"></asp:Literal></td><td><asp:Literal ID="Literal7" runat="server"></asp:Literal></td><td><asp:Literal ID="Literal8" runat="server"></asp:Literal></td>
				</tr>
				<tr>
				<td>空运</td><td><asp:Literal ID="Literal9" runat="server"></asp:Literal></td><td><asp:Literal ID="Literal10" runat="server"></asp:Literal></td><td><asp:Literal ID="Literal11" runat="server"></asp:Literal></td><td><asp:Literal ID="Literal12" runat="server"></asp:Literal></td>
				</tr>								
				</table>
                    <asp:Literal ID="ltrDetail" runat="server"></asp:Literal>
				<br/>
				<br/>
				<asp:Literal ID="ltrFclTotal" runat="server"></asp:Literal>
                    <asp:PlaceHolder ID="phFclTotal" runat="server">
				<table>
				<tr><td>按航线排列：</td><td>按航线-船公司排列：</td></tr>
				<tr>
				<td width="300" valign="top">
                <table border="1">
                    <tr style="font-weight:bold;">
                        <td width="40">序号</td><td width="100">航线</td><td  align=right>运价(条)</td>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                    <tr>
                        <td><%#this.Repeater1.Items.Count + 1%></td>
                        <td><a href="price/fcl.aspx?l=<%#Server.UrlEncode(Eval("hangxianmiaoshux").ToString())%>&u=<%=Request.QueryString["u"].ToString() %>"><%#Eval("hangxianmiaoshux").ToString()%></td>
                        <td  align=right><%#Eval("c").ToString()%></td>
                    </tr>
                        </ItemTemplate>
                    </asp:Repeater>  
                </table>
				</td>
				<td valign="top">
                <table border="1">
                    <tr style="font-weight:bold;">
                        <td width="40">序号</td><td>航线 - 船公司</td><td  align=right>运价(条)</td>
                    </tr>
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                    <tr>
                        <td><%#this.Repeater2.Items.Count + 1%></td>
                        <td><a href="price/fcl.aspx?l=<%#Server.UrlEncode(Eval("hangxianmiaoshux").ToString())%>&cr=<%#Server.UrlEncode(Eval("shipcompany").ToString())%>&u=<%=Request.QueryString["u"].ToString() %>"><%#Eval("hangxianmiaoshux").ToString()%> - <%#Eval("shipcompany").ToString()%></a></td>
                        <td  align=right><%#Eval("c").ToString()%></td>
                    </tr>
                        </ItemTemplate>
                    </asp:Repeater>  
                </table>
				</td>
				</tr>
				</table>
				</asp:PlaceHolder>
				<br/>
				
				<asp:Literal ID="ltrLclTotal" runat="server"></asp:Literal>
				<asp:PlaceHolder ID="phLclTotal" runat="server">
				<table>
				<tr><td>按航线排列：</td><td>按航线-船公司排列：</td></tr>
				<tr>
				<td width="300" valign="top">
                <table border="1">
                    <tr style="font-weight:bold;">
                        <td width="40">序号</td><td width="100">航线</td><td  align=right>运价(条)</td>
                    </tr>
                    <asp:Repeater ID="Repeater3" runat="server">
                        <ItemTemplate>
                    <tr>
                        <td><%#this.Repeater3.Items.Count + 1%></td>
                        <td><a href="price/lcl.aspx?l=<%#Server.UrlEncode(Eval("hangxianmiaoshux").ToString())%>&u=<%=Request.QueryString["u"].ToString() %>"><%#Eval("hangxianmiaoshux").ToString()%></td>
                        <td  align=right><%#Eval("c").ToString()%></td>
                    </tr>
                        </ItemTemplate>
                    </asp:Repeater>  
                </table>
				</td>
				<td valign="top">
                <table border="1">
                    <tr style="font-weight:bold;">
                        <td width="40">序号</td><td>航线-船公司</td><td  align=right>运价(条)</td>
                    </tr>
                    <asp:Repeater ID="Repeater4" runat="server">
                        <ItemTemplate>
                    <tr>
                        <td><%#this.Repeater4.Items.Count + 1%></td>
                        <td><a href="price/lcl.aspx?l=<%#Server.UrlEncode(Eval("hangxianmiaoshux").ToString())%>&cr=<%#Server.UrlEncode(Eval("shipcompany").ToString())%>&u=<%=Request.QueryString["u"].ToString() %>"><%#Eval("hangxianmiaoshux").ToString()%> - <%#Eval("shipcompany").ToString()%></a></td>
                        <td  align=right><%#Eval("c").ToString()%></td>
                    </tr>
                        </ItemTemplate>
                    </asp:Repeater>  
                </table>
				</td>
				</tr>
				</table>
                </asp:PlaceHolder>
				<br/>
				
				<asp:Literal ID="ltrAirTotal" runat="server"></asp:Literal>
				<asp:PlaceHolder ID="phAirTotal" runat="server">
				<table>
				<tr><td>按航线排列：</td><td></td></tr>
				<tr>
				<td width="300" valign="top">
                <table border="1">
                    <tr style="font-weight:bold;">
                        <td width="40">序号</td><td width="100">航线</td><td  align=right>运价(条)</td>
                    </tr>
                    <asp:Repeater ID="Repeater5" runat="server">
                        <ItemTemplate>
                    <tr>
                        <td><%#this.Repeater5.Items.Count + 1%></td>
                        <td><%#Eval("linex").ToString()%></td>
                        <td  align=right><%#Eval("c").ToString()%></td>
                    </tr>
                        </ItemTemplate>
                    </asp:Repeater>  
                </table>
				</td>
				<td>
				</td>
				</tr>
				</table>
                </asp:PlaceHolder>
                
 			    </div>			
			</div>			
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>
