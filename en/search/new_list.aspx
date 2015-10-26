<%@ Page Language="VB" AutoEventWireup="false" CodeFile="new_list.aspx.vb" Inherits="en_search_new_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="/en/css/fcl_list.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
			<div class="head">
				<div class="ff_top_box">
					<div class="ff_solo">Welcome！Jason</div>
					<div class="ff_top_links"><img src="/en/images/fcl/exit.gif" width="16" height="16" /><a href="#" target="_blank">Exit</a></div>
				</div>
				<div class="head_mid">
					<div id="logo"><a href="#"><img src="/en/images/fcl/ff_logo.gif" width="299" height="89" border="0" /></a></div>
				  <div class="search_bar" style="height:auto; width:560px; background-image:none;">
						<div class="login_box" style="margin-top:20px;">
							<a href="#"><img src="/en/images/fcl/list_ico6.gif" />live help</a><br /><a><img src="/en/images/fcl/list_ico5.gif" />0086+02151086987</a><br />
						</div>
						<div class="login_box" style="border-right:1px dotted #666; margin-top:20px;">
							<a href="#"><img src="/en/images/fcl/list_ico7.gif" />login</a><br />
							<a href="#"><img src="/en/images/fcl/list_ico7.gif" />Office</a>
						</div>
				  </div>
				</div>
<div class="nav">
<ul>
<li><a href="/">Home</a></li>
<li class="divider"></li>
<li><a href="/en/fcl/">FCL Freight</a></li>
<li class="divider"></li>
<li><a href="/en/lcl/">LCL Freight</a></li>
<li class="divider"></li>
<li><a href="/en/air/">Air Freight</a></li>
<li class="divider"></li>
<li><a href="/en/surcharge/">Surcharge</a></li>
<li class="divider"></li>
<li><a href="/en/agent/">Agent</a></li>
<li class="divider"></li>
<li><a href="/en/company/">Company</a></li>
</ul>
</div>
			</div>
			<div class="menu">
				<h1><a href="#">Home</a> > <a href="#">Agent</a> <%--> <asp:Literal ID="Label1" runat="server" Text="运价标题"></asp:Literal>--%></h1>
			</div>
		<div class="main_page">
		  <div class="info_box">
		    <table width="872" border="0" cellspacing="1" cellpadding="0" style="background:url(images/fcl/coop_bg.jpg) repeat-x top; margin:1px; font-size:13px; color:#304d74;">
              <tr>
                <td height="38" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-size:16px;"><strong>Cooperation</strong></span></td>
                <td width="143">&nbsp;</td>
              </tr>
              <tr>
                <td width="87" height="38" align="center"><strong>No</strong></td>
                <td width="638"><strong>Subject </strong></td>
                <td><strong>Date</strong></td>
              </tr>
			  <tr>
                <td height="1" colspan="3" bgcolor="#EAEAEA"></td>
              </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                <tr>
                <td height="32" align="center">No.<%#Eval("id").ToString()%></td>
                <td><a href="../search/news.aspx?id=<%#Eval("id").ToString()%>"><%#Eval("title").ToString()%></a></td>
                <td><%#Month(Eval("month").ToString())%><%#Eval("day").ToString()%>,<%#Eval("year").ToString()%></td>
                  </tr>
			      <tr>
                    <td height="1" colspan="3" bgcolor="#EAEAEA"></td>
                  </tr>
                </ItemTemplate>
                </asp:Repeater>
              
              
              
              
              
              
              
              
              
              
              <tr>
                  
                <td height="10" colspan="3"><div class="page_head"><asp:Literal ID="lblCurrentPage" runat="server"></asp:Literal>Page</div><div class="page" style="margin-right:8px;">
				  		<%--<a class="next" href="#" style="padding:2px 6px 2px 6px; background: url(images/fcl/next_1.gif) no-repeat 6px;">&nbsp;</a>
						<span class="selected">1</span>
						<a href="bxj-2">2</a>
						<a href="bxj-3">3</a>
						<span>...</span>
						<a href="#">684</a>
						<a class="next" href="#" style="padding:2px 12px 2px 6px;">Next</a>--%>
						<asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
						<span class="f666">直接到第 <input id="txtPageJump" style="font:12px '宋体';" type="text" value="1" size="2" runat="server" /> 
						页 <input style="font:12px '宋体';" type="button" value="确定" id="Button1" runat="server" />
						</span>
				  </div></td>
              </tr>
            </table>
		  </div>
			<div class="foot"><a href="#">About Us</a>︱<a href="#">Privacy Policy</a>︱<a href="#">Terms Of Use Agreement</a>︱ <a href="#">Site Map</a>︱<a href="#">Contact Us</a></div>
		</div>
	</div>
    </form>
</body>
</html>
