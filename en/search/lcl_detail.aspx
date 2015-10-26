<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lcl_detail.aspx.vb" Inherits="en_search_fcl_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<asp:Literal id="Literal2" runat="server"><meta name="keywords" content="FCL-100allin" /></asp:Literal>
<asp:Literal id="Literal3" runat="server"><meta name="description" content="FCL-100allin" /></asp:Literal>
<asp:Literal id="Literal1" runat="server"><title>FCL-100allin</title></asp:Literal>
<link href="/en/css/fcl_list.css" rel="stylesheet" type="text/css" />
</head>

<body>
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
<li><a href="/en/cooperation/">Cooperation</a></li>
<li class="divider"></li>
<li><a href="/en/company/">Company</a></li>
</ul>
</div>
			</div>
			<div class="menu">
				<h1><a href="../">Home</a> > <a href="../lcl/">LCL</a> > <asp:Literal ID="Label1" runat="server" Text="运价标题"></asp:Literal></h1>
			</div>
		<div class="main_page">
			<div class="info_box">
						<div class="info_left">
					<ul>
						<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Rate Type</strong> : <span class="blue">FCL</span></li>
						<li><strong>Trade Lane</strong> : <span class="blue"><asp:Literal ID="Literal6" runat="server"></asp:Literal></span></li>
						<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Post Date</strong> : <span class="blue"><asp:Literal ID="ltrPostDate" runat="server"></asp:Literal></span></li>
						<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Valid to</strong> : <span class="blue"><asp:Literal ID="ltrEndDate" runat="server"></asp:Literal></span></li>
						<li>
						<div class="blue_box">
						<span class="sju">Price(Vol):<a class="blue"><asp:Literal ID="Lab20GP" runat="server"></asp:Literal></a></span>
						<span class="sju">Price(KG):<a class="blue"><asp:Literal ID="Lab40GP" runat="server"></asp:Literal></a></span>
						</div>
					  </li>
					  <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>&nbsp;POL(Port of loading)</strong><span class="blue2"> : <asp:Literal ID="Literal5" runat="server"></asp:Literal></span></li>
					  <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>&nbsp;POL(Port of loading)</strong><span class="blue2"> : <asp:Literal ID="LabDestport" runat="server"></asp:Literal></span></li>					  
					  </ul>
				  </div>
						<asp:Panel ID="Panel1" runat="server" CssClass="info_right">
							<h2><asp:Literal ID="Literal8" runat="server"></asp:Literal></h2>
							<div id="pic"><img src="/en/images/fcl/people.GIF" id="imghead" runat="server" width="76" height="76" /></div>
						  <div class="name">contact : <asp:Label ID="Label15" runat="server" Text=""></asp:Label><br />
							  <asp:Literal ID="Literal25" runat="server"></asp:Literal><br />
							  <asp:Literal ID="Literal29" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal ID="Literal30" runat="server"></asp:Literal></div>
							<div class="details_info" style="border:none; margin-top:0px;">
								<ul>
								<li>country&amp;city : <span class="blue">Shanghai.China</span></li>
								<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tel : <span class="blue"><asp:Literal ID="Literal9" runat="server"></asp:Literal></span></li>
								  <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Fax : <span class="blue"><asp:Literal ID="Literal11" runat="server"></asp:Literal></span></li>
									<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email : <span class="blue"><asp:Literal ID="Literal12" runat="server"></asp:Literal></span></li>
									<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Address : <span class="blue"><asp:Literal ID="Literal13" runat="server"></asp:Literal></span></li>
									<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pst code : <span class="blue"><asp:Literal ID="Literal14" runat="server"></asp:Literal></span></li>
								</ul>
						  </div>
						</asp:Panel>
						<asp:Panel ID="Panel3" runat="server" CssClass="info_right">
							<a href="../sign.aspx">
							Please login first to show the contact infomation</a>
						</asp:Panel>				
		  </div>
			<div class="fcl_rd">
				<h2>Freight Details</h2>
				<div class="fcl_rd_bg"><table id="pd" width="874" border="0" cellpadding="0" cellspacing="0" bgcolor="#EEFAEE">
								<tr>
								  <td width="14" height="38" align="center" bgcolor="#E9F3F8" class="blue2">&nbsp;</td>
								  <td width="86" align="left" bgcolor="#E9F3F8" class="blue_1"><strong>POD</strong></td>
								  <td width="65" align="left" bgcolor="#E9F3F8" class="blue_1"><strong>Rate(W)</strong></td>
								  <td width="65" align="left" bgcolor="#E9F3F8" class="blue_1"><strong>Rate(V)</strong></td>
								  <%--<td width="110" align="left" bgcolor="#E9F3F8" class="blue_1"><strong>Rate attached</strong></td>--%>
								  <td width="86" align="left" bgcolor="#E9F3F8" class="blue_1"><strong>T/T</strong></td>
								  <td width="106" align="left" bgcolor="#E9F3F8" class="blue_1"><strong>ETD</strong></td>
								  <td width="106" align="left" bgcolor="#E9F3F8" class="blue_1"><strong>Carrier</strong></td>
								  <td width="106" align="left" bgcolor="#E9F3F8" class="blue2"><strong>Attachment</strong></td>
								</tr>
                                <asp:Repeater ID="RptYunjia" runat="server">
                                <ItemTemplate>   								
                                <tr>
                                  <td height="32" align="center" bgcolor="#FFFFFF">&nbsp;</td>
                                  <td align="left" bgcolor="#FFFFFF"><%#Eval("destport") %></td>
                                  <td align="left" bgcolor="#FFFFFF" class="blue"><%#Eval("pricegp")%></td>
                                  <td align="left" bgcolor="#FFFFFF" class="blue"><%#Eval("pricegpv")%></td>
                                  <%--<td align="left" bgcolor="#FFFFFF"><%#Eval("price20gpAppend") %></td>--%>
                                  <td align="left" bgcolor="#FFFFFF"><%#Eval("Distance")%></td>
                                  <td align="left" bgcolor="#FFFFFF"><%#Eval("DepartureWkd")%></td>
                                  <td align="left" bgcolor="#FFFFFF"><%#Eval("shipcompany")%></td>
                                  <td align="left" bgcolor="#FFFFFF"><%#Eval("memo")%></td>
                                </tr>
                                </ItemTemplate>
                                </asp:Repeater>								
							  </table>
				</div>
			</div>
			<div class="fcl_rd" style="display:none;">
              <h2>上海港非洲线相关运价</h2>
			  <div class="fcl_rd_bg">
			    <table id="Table1" width="874" border="0" cellpadding="0" cellspacing="0" bgcolor="#EEFAEE">
                  <tr>
                    <td width="14" height="38" align="center" bgcolor="#E9F3F8" class="blue2">&nbsp;</td>
                    <td width="86" align="left" bgcolor="#E9F3F8" class="blue_1"><strong>POD</strong></td>
                    <td width="65" align="left" bgcolor="#E9F3F8" class="blue_1"><strong> 20GP</strong></td>
                    <td width="65" align="left" bgcolor="#E9F3F8" class="blue_1"><strong>40GP</strong></td>
                    <td width="65" align="left" bgcolor="#E9F3F8" class="blue_1"><strong>40HP</strong></td>
                    <td width="65" align="left" bgcolor="#E9F3F8" class="blue_1"><strong><strong>40HQ</strong></strong></td>
                    <%--<td width="110" align="left" bgcolor="#E9F3F8" class="blue_1"><strong>Rate attached</strong></td>--%>
                    <td width="86" align="left" bgcolor="#E9F3F8" class="blue_1"><strong>T/T</strong></td>
                    <td width="106" align="left" bgcolor="#E9F3F8" class="blue_1"><strong>ETD</strong></td>
                    <td width="106" align="left" bgcolor="#E9F3F8" class="blue_1"><span class="blue2"><strong>Carrier</strong></span></td>
                    <td width="106" align="left" bgcolor="#E9F3F8" class="blue2"><strong>Attachment</strong></td>
                  </tr>
                  <tr>
                    <td height="32" align="center" bgcolor="#FFFFFF">&nbsp;</td>
                    <td align="left" bgcolor="#FFFFFF">上海</td>
                    <td align="left" bgcolor="#FFFFFF">东京</td>
                    <td align="left" bgcolor="#FFFFFF" class="blue">33</td>
                    <td align="left" bgcolor="#FFFFFF" class="blue">33</td>
                    <td align="left" bgcolor="#FFFFFF" class="blue">44</td>
                    <td align="left" bgcolor="#FFFFFF">美加</td>
                    <td align="left" bgcolor="#FFFFFF">5.12-31.31</td>
                    <td align="center" bgcolor="#FFFFFF">&nbsp;</td>
                    <td align="center" bgcolor="#FFFFFF">&nbsp;</td>
                  </tr>
                  <tr>
                    <td height="32" align="center" bgcolor="#FFFFFF">&nbsp;</td>
                    <td align="left" bgcolor="#FFFFFF">上海</td>
                    <td align="left" bgcolor="#FFFFFF">东京</td>
                    <td align="left" bgcolor="#FFFFFF" class="blue">33</td>
                    <td align="left" bgcolor="#FFFFFF" class="blue">33</td>
                    <td align="left" bgcolor="#FFFFFF" class="blue">44</td>
                    <td align="left" bgcolor="#FFFFFF">美加</td>
                    <td align="left" bgcolor="#FFFFFF">05.12.31</td>
                    <td align="center" bgcolor="#FFFFFF">&nbsp;</td>
                    <td align="center" bgcolor="#FFFFFF">&nbsp;</td>
                  </tr>
                  <tr>
                    <td height="32" align="center" bgcolor="#FFFFFF">&nbsp;</td>
                    <td align="left" bgcolor="#FFFFFF">上海</td>
                    <td align="left" bgcolor="#FFFFFF">东京</td>
                    <td align="left" bgcolor="#FFFFFF" class="blue">33</td>
                    <td align="left" bgcolor="#FFFFFF" class="blue">33</td>
                    <td align="left" bgcolor="#FFFFFF" class="blue">44</td>
                    <td align="left" bgcolor="#FFFFFF">美加</td>
                    <td align="left" bgcolor="#FFFFFF">05.12.31</td>
                    <td align="center" bgcolor="#FFFFFF">&nbsp;</td>
                    <td align="center" bgcolor="#FFFFFF">&nbsp;</td>
                  </tr>
                </table>
			  </div>
		  </div>
			<div class="foot"><a href="#">About Us</a>︱<a href="#">Privacy Policy</a>︱<a href="#">Terms Of Use Agreement</a>︱ <a href="#">Site Map</a>︱<a href="#">Contact Us</a></div>
		</div>
	</div>
</body>
</html>

