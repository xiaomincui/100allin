<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Agent_detail.aspx.vb" Inherits="en_search_fcl_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<asp:Literal id="Literal2" runat="server"><meta name="keywords" content="整箱海运运价-环球运费网" /></asp:Literal>
<asp:Literal id="Literal3" runat="server"><meta name="description" content="整箱海运运价-环球运费网" /></asp:Literal>
<asp:Literal id="Literal1" runat="server"><title>整箱海运运价-环球运费网</title></asp:Literal>
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
			<div class="info_box" style="border:0px">
						<div class="info_left" style="width:873px;">
						
					<ul style="width:833px;">
						<li style="width:837px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-size:large"><strong><asp:Literal
                            ID="LitCompanyName" runat="server"></asp:Literal></strong></span><span style="color:Gray"> (<asp:Literal ID="LitCity" runat="server"></asp:Literal><asp:Literal ID="LitHeadOffice" runat="server"></asp:Literal>)</span>
</li>
						<li style="width:837px;">
						<table width="80%" border="0" align="left"cellpadding="3" cellspacing="1"  style="margin-left:30px;border:1px #FF6600 solid; line-height:15px">
               <tr>
                 <td style="border-bottom:1px #FF6600 solid">WCA Family Gold Medallion Financial Protection Program <font color='red'>* </font>
                 </td>
               </tr>
               <tr>
                 <td>The following offices of this member are enrolled:</td>
               </tr>
               <tr>
                 <td>
                 <table width='100%'><tr>
                 <td align='left' valign='top' width='25%'><b>Brazil</b></td>
                     <asp:Repeater ID="Repeater1" runat="server">
                     <ItemTemplate>
                     <td align=left width='180' valign=top>&nbsp; [<a href='Agent_detail.aspx?id=<%# eval("id") %>'><%# eval("City") %></a>]</td>
                     </ItemTemplate>
                     </asp:Repeater>
                 
                 
               </tr>
                </table>
                </td>
               </tr>
               
               <tr>
                 <td align="left" style="border-top:1px #FF6600 solid"> <font color='red'>* </font> Only these offices are covered and protected under this program.</td>
               </tr>
               
             </table>
                        
						</li>
						<li style="width:837px;">
						<table width="100%" border="0" cellpadding="0" cellspacing="0" style="margin-left:30px">
                            <tr>
                              <td><b style="font-size:12px; color:#000000">Member(s) of</b></td>
                              <td>&nbsp;</td>
                            </tr>
                            <tr>
                              <td valign="top">
                              <table cellpadding="3" cellspacing="3">
                              <tr>
                                  <asp:Literal ID="Litmember" runat="server"></asp:Literal>
                                <%--<td align="center" valign="top"><a href="http://www.igln.net/" target="_blank" ><img src="/en/images/agent/logo_igln.gif" border=0 vspace=1 hspace=1  alt='Inter-Global Logistics Network' /></a>&nbsp;<br><font style='font-size:11px;color:#990000' title='Expiration Date'><font style'font-size:9px'>Expires:</font> Dec 04, 2010</font></td><td align="center" valign="top"><a href="http://www.allworldshipping.com" target="_blank" ><img src="/en/images/agent/logo_aws.gif" border=0 vspace=1 hspace=1 alt='All World Shipping' /></a>&nbsp;<br></td></tr></table>
                  
                  </td>--%>
                              <td>&nbsp;</td>
                            </tr>
                        </table>
						</li>
						<li style="width:837px;"><div style="margin:0px 30px 0px 0px; line-height:20px">
                            <asp:Literal ID="Litprofile" runat="server"></asp:Literal>

<br />
<span style="color:red">Warning - sending shipments to any Brazilian Port, Air or Sea without consent from your Brazilian WCA Family member could lead to you paying heavy fines due to the very strict Importation Laws imposed by Brazilian Customs. Please always check with your WCA Family partner in Brazil and send all documents beforehand for them to check and confirm the shipment can be sent, in fact this is a good practice for any Country you are exporting to.</span>

</div></li>
						<li style="width:837px;">
						
						<table width="100%" border="0" cellspacing="1" cellpadding="2" class="body_txt" style="margin:15px 30px 0px 30px; line-height:15px">
<tr>
	<th width="27%" align="left" valign="top">Address:</th>
<td>	
	
	<table width="100%" border="0" cellspacing="0" cellpadding="0" class="body_txt"> 
					<tr><td valign="top">
                        <asp:Literal ID="Literal4" runat="server"></asp:Literal><br></td></tr>	

					
			</table></td>
</tr>	
<tr>
	<th width="27%" align="left" valign="top">Telephone:</th>
	<td width="73%" valign="top">
        <asp:Literal ID="Literal5" runat="server"></asp:Literal></td>
</tr>
<tr>
	<td width="27%" align="left" valign="top">Fax:</td>
	<td width="73%" valign="top"><asp:Literal ID="Literal6" runat="server"></asp:Literal></td>
</tr>

<tr>
	<td width="27%" align="left" valign="top">Mobile Phone:</td>
	<td width="73%" valign="top"><asp:Literal ID="Literal7" runat="server"></asp:Literal></td>
</tr>

<tr>
	<th width="27%" align="left" valign="top">Emergency Call:</th>
	<td width="73%" valign="top"><asp:Literal ID="Literal8" runat="server"></asp:Literal></td>
</tr>

<tr>
  <th align="left" valign="top">&nbsp;</th>
  <td valign="top">&nbsp;</td>
</tr>
<tr>
	<th width="27%" align="left" valign="top">Website:</th>
	<td width="73%" valign="top">
	<asp:Literal ID="Literal9" runat="server"></asp:Literal>
		</td>
</tr>
<tr>
	<th width="27%" align="left" valign="top">Email:</th>
	<td width="73%" valign="top">
        <asp:Literal ID="Literal10" runat="server"></asp:Literal>
	</td>
</tr>
<tr><th align="left" valign="top" colspan="2">&nbsp;</th></tr>

<tr><th align="left" valign="top" colspan="2">Contact:</th></tr>
			   
               
                            <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                            <tr>
                             <td>Name:</td>
                             <td><%#Eval("name")%></td>
                           </tr>
                           <tr>
                             <td>Title</td>
                             <td><%#Eval("title")%></td>
                           </tr>
            			   
            			   
                           <tr>
                             <td>Email</td>
                             <td><a href='mailto:<%# eval("Email") %>'><%#Eval("Email")%></a></td>
			               </tr>
            			   		   			   
			               <tr><td colspan="2">&nbsp;</td></tr>
                            </ItemTemplate>
                            </asp:Repeater>
               
               
			   <tr>
                 <td>Name:</td>
                 <td>Mrs. Ligia C. Bini</td>
               </tr>
               
               <tr>
                 <td>Title</td>
                 <td>Accoutings</td>
               </tr>
			   
			   
               <tr>
                 <td>Email</td>
                 <td><a href='mailto:ligia@bmlog.com'>ligia@bmlog.com</a></td>
			   </tr>
			   		   			   
			   <tr><td colspan="2">&nbsp;</td></tr>
               
               
			   <tr>
                 <td>Name:</td>
                 <td>Mr. Alexandre Bini</td>
               </tr>
               
               <tr>
                 <td>Title</td>
                 <td>General Sales Director/WCA Contact</td>
               </tr>
			   
			   
               <tr>
                 <td>Email</td>
                 <td><a href='mailto:alexandre@bmlog.com'>alexandre@bmlog.com</a></td>
			   </tr>
			   		   			   
			   <tr><td colspan="2">&nbsp;</td></tr>
               
               
			   <tr>
                 <td>Name:</td>
                 <td>Ms. Sabrina Caldas</td>
               </tr>
               
               <tr>
                 <td>Title</td>
                 <td>Import Manager</td>
               </tr>
			   
			   
               <tr>
                 <td>Email</td>
                 <td><a href='mailto:sabrina@bmlog.com'>sabrina@bmlog.com</a></td>
			   </tr>
			   		   			   
			   <tr><td colspan="2">&nbsp;</td></tr>
               
			<!---- END contact listing from MSDB2 ----->
</table>
</li>
		
						
						
					  				  
					  </ul>
				  </div>
									
		  </div>
			
			
			<div class="foot"><a href="#">About Us</a>︱<a href="#">Privacy Policy</a>︱<a href="#">Terms Of Use Agreement</a>︱ <a href="#">Site Map</a>︱<a href="#">Contact Us</a></div>
		</div>
	</div>
</body>
</html>

