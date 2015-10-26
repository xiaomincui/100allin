<%@ Control Language="C#" AutoEventWireup="true" CodeFile="enusertop.ascx.cs" Inherits="en_enusertop" %>
<div class="head">
				<div class="ff_top_box">
					<div class="ff_solo">Welcome! 
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal></div>
					<div class="ff_top_links"><img src="/en/images/fcl/exit.gif" width="16" height="16" /><a href="/accounts/logout.aspx" target="_blank">Exit</a></div>
				</div>
				<div class="head_mid">
					<div id="logo"><a href="#"><img src="/en/images/fcl/ff_logo.gif" width="299" height="89" border="0" /></a></div>
				  <div class="search_bar" style="height:auto; width:560px; background-image:none;">
						<div class="login_box" style="margin-top:20px;">
							<a href="#"><img src="/en/images/fcl/list_ico6.gif" />live help</a><br /><a><img src="/en/images/fcl/list_ico5.gif" />0086+02151086987</a><br />
						</div>
						<div class="login_box" style="border-right:1px dotted #666; margin-top:20px;">
							<a href="/en/sign.aspx"><img src="/en/images/fcl/list_ico7.gif" />login</a><br />
							<a href="/en/office.aspx"><img src="/en/images/fcl/list_ico7.gif" />Office</a>
						</div>
				  </div>
				</div>
				<div class="nav">
					<ul>
						<li><a href="/en/">Home</a></li>
						<li class="divider"></li>
						<li class="st"><a href="/en/search/fcl.aspx">FCL Freight</a></li>
						<li class="divider"></li>
						<li><a href="/en/search/lcl.aspx">LCL Freight</a></li>
						<li class="divider"></li>
						<li><a href="/en/search/air.aspx">Air Freight</a></li>
						<li class="divider"></li>
						<li><a href="#">Surcharge</a></li>
						<li class="divider"></li>
						<li><a href="/en/search/cooperation.aspx">Cooperation</a></li>
						<li class="divider"></li>
						<li><a href="/en/search/company.aspx">Company</a></li>
					</ul>
				</div>
</div>