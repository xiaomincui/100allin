<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="admin_default" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="css/master.css" rel="stylesheet" type="text/css" />
	<link rel="stylesheet" type="text/css" href="/ext/resources/css/ext-all.css" />
	<link rel="stylesheet" type="text/css" href="/ext/resources/css/xtheme-gray.css" />
    <LINK href="css/WebResource.css" type=text/css rel=stylesheet />	
	<script type="text/javascript" src="/ext/adapter/ext/ext-base.js"></script>
	<script type="text/javascript" src="/ext/ext-all.js"></script>
	<script type="text/javascript" src="js/tabs-example.js"></script>
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
					<div class="icon"><img src="images/home_title.gif" /></div>
					<div class="text">网站信息</div>
				</div>
<div style="font-size:14px; line-height:25px;">
				<div id="tipBoxSearch" class="tipBox">
				<b>流量统计：</b>
				起始日期

<INPUT id=BasicDatePicker1_TextBox readOnly value="" name=BasicDatePicker1$TextBox style="width:70px;" runat="server" />
<IMG class=bdpButton id=BasicDatePicker1_Image style="BORDER: 0px; WIDTH: 28px; HEIGHT: 22px;" alt="点击日历选择日期" src="images/WebResource.gif" border=10 />
&nbsp;&nbsp;
结束日期
<INPUT id=BasicDatePicker2_TextBox readOnly value="" name=BasicDatePicker2$TextBox style="width:70px;" runat="server" />
<IMG class=bdpButton id=BasicDatePicker2_Image style="BORDER: 0px; WIDTH: 28px; HEIGHT: 22px;" alt="点击日历选择日期" src="images/WebResource.gif" border=10 />
&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" />
                    <b>&nbsp;&nbsp;&nbsp;&nbsp;
                    IP/PV比：
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    /
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </b>
                    
<SCRIPT src="js/WebResource.js" type=text/javascript></SCRIPT>
<SCRIPT src="js/coolite.js" type=text/javascript></SCRIPT>
<SCRIPT src="js/basicdatepicker.js" type=text/javascript></SCRIPT>
<SCRIPT type=text/javascript>
//<![CDATA[
var BasicDatePicker1 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker1",dateFormat:"yyyy-M-d",selectableWeekendDays:true,minimumDate:"1999/1/1",nullDateText:"",showWeekNumbers:true,showDaysInNextMonth:false,showDaysInPrevMonth:false,northImage:"images/arrow_up.gif",southImage:"images/arrow_down.gif",eastImage:"images/arrow_right.gif",westImage:"images/arrow_left.gif"}).applyTo({inputID:"BasicDatePicker1_TextBox",buttonID:"BasicDatePicker1_Image"}) : alert("日期控件出现问题，请刷新该页面");
var BasicDatePicker2 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker2",dateFormat:"yyyy-M-d",selectableWeekendDays:true,minimumDate:"1999/1/1",nullDateText:"",showWeekNumbers:true,showDaysInNextMonth:false,showDaysInPrevMonth:false,northImage:"images/arrow_up.gif",southImage:"images/arrow_down.gif",eastImage:"images/arrow_right.gif",westImage:"images/arrow_left.gif"}).applyTo({inputID:"BasicDatePicker2_TextBox",buttonID:"BasicDatePicker2_Image"}) : alert("日期控件出现问题，请刷新该页面");
//]]>
</SCRIPT>
	            </div>
				</div>
                				<a href="/manage/">2.0后台地址</a>
				<br/>				
				<div class="tt14 bd rightSubTitle">
					<div class="text">运价/货盘统计</div>
				</div>	
				<div class="rightArea txth22" >
					<div id="tabs1">
						<div id="script" class="x-hide-display">
							<div style="padding:10px 15px 10px 15px;">
								<table border="0" cellspacing="0" cellpadding="0" width="100%">
								  <tr>
									<td width="20%" valign="top"><span class="tt14">整箱运价</span>
                                        <asp:GridView ID="GridView3" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>									  
									</td>
									<td width="20%" valign="top"><span class="tt14">拼箱运价</span>
                                        <asp:GridView ID="GridView4" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>										    
									</td>
									<td width="20%" valign="top"><span class="tt14">空运运价</span>
                                        <asp:GridView ID="GridView5" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>										
									</td>
									<td width="20%" valign="top"><span class="tt14">海运货盘</span>
                                        <asp:GridView ID="GridView6" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>										
									</td>
									<td width="20%" valign="top"><span class="tt14">空运货盘</span>
                                        <asp:GridView ID="GridView7" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>									        	
									</td>
								  </tr>
								</table>
							</div>
						</div>
                        <div id="yest" class="x-hide-display">
							<div style="padding:10px 15px 10px 15px;">
								<table border="0" cellspacing="0" cellpadding="0" width="100%">
								  <tr>
									<td width="20%" valign="top"><span class="tt14">整箱运价</span>
                                        <asp:GridView ID="GridView13" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>									  
									</td>
									<td width="20%" valign="top"><span class="tt14">拼箱运价</span>
                                        <asp:GridView ID="GridView14" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>										    
									</td>
									<td width="20%" valign="top"><span class="tt14">空运运价</span>
                                        <asp:GridView ID="GridView15" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>										
									</td>
									<td width="20%" valign="top"><span class="tt14">海运货盘</span>
                                        <asp:GridView ID="GridView16" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>										
									</td>
									<td width="20%" valign="top"><span class="tt14">空运货盘</span>
                                        <asp:GridView ID="GridView17" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>									        	
									</td>
								  </tr>
								</table>
							</div>
						</div>						
						<div id="markup" class="x-hide-display">
							<div style="padding:10px 15px 10px 15px;">
								<table border="0" cellspacing="0" cellpadding="0" width="100%">
								  <tr>
									<td width="20%" valign="top"><span class="tt14">整箱运价</span>
                                        <asp:GridView ID="GridView8" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>									  
									</td>
									<td width="20%" valign="top"><span class="tt14">拼箱运价</span>
                                        <asp:GridView ID="GridView9" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>										    
									</td>
									<td width="20%" valign="top"><span class="tt14">空运运价</span>
                                        <asp:GridView ID="GridView10" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>										
									</td>
									<td width="20%" valign="top"><span class="tt14">海运货盘</span>
                                        <asp:GridView ID="GridView11" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>										
									</td>
									<td width="20%" valign="top"><span class="tt14">空运货盘</span>
                                        <asp:GridView ID="GridView12" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>									        	
									</td>
								  </tr>
								</table>
							</div>
						</div>
                        <div id="now" class="x-hide-display">
							<div style="padding:10px 15px 10px 15px;">
								<table border="0" cellspacing="0" cellpadding="0" width="100%">
								  <tr>
									<td width="20%" valign="top"><span class="tt14">整箱运价</span>
                                        <asp:GridView ID="GridView19" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>									  
									</td>
									<td width="20%" valign="top"><span class="tt14">拼箱运价</span>
                                        <asp:GridView ID="GridView20" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>										    
									</td>
									<td width="20%" valign="top"><span class="tt14">空运运价</span>
                                        <asp:GridView ID="GridView21" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>										
									</td>
									<td width="20%" valign="top"><span class="tt14">海运货盘</span>
                                        <asp:GridView ID="GridView22" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>										
									</td>
									<td width="20%" valign="top"><span class="tt14">空运货盘</span>
                                        <asp:GridView ID="GridView23" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="40px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>									        	
									</td>
								  </tr>
								</table>
							</div>
						</div>						
					</div>				
			  </div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">用户统计</div>
				</div>	
			  <div class="rightArea txth22">
				<div id="tabs2">
						<div id="script2" class="x-hide-display">
							<div style="padding:10px 15px 10px 15px;">
								<table border="0" cellspacing="0" cellpadding="0" width="100%">
								  <tr>
									<td width="20%"><span class="tt14">普通用户</span>&nbsp;
                                        <asp:GridView ID="GridView1" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="50px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>
                                    </td>
									<td width="20%"><span class="tt14">高级用户</span>
									  <table border="0" cellspacing="0" cellpadding="0">
										<tr>
										  <td style="width: 50px">合&nbsp;&nbsp;&nbsp;&nbsp;计</td>
										  <td width="50" align="right">无</td>
										</tr>
										<tr>
										  <td style="width: 50px">直&nbsp;&nbsp;&nbsp;&nbsp;客</td>
										  <td align="right">无</td>
										</tr>
										<tr>
										  <td style="width: 50px">货&nbsp;&nbsp;&nbsp;&nbsp;代</td>
										  <td align="right">无</td>
										</tr>
										<tr>
										  <td style="width: 50px">船公司</td>
										  <td align="right">无</td>
										</tr>										
										<tr>
										  <td style="width: 50px">其&nbsp;&nbsp;&nbsp;&nbsp;它</td>
										  <td align="right">无</td>
										</tr>
									  </table></td>
									<td width="20%"><span class="tt14">VIP用户</span>
									  <table border="0" cellspacing="0" cellpadding="0">
										<tr>
										  <td width="50">合&nbsp;&nbsp;&nbsp;&nbsp;计</td>
										  <td width="50" align="right">无</td>
										</tr>
										<tr>
										  <td>直&nbsp;&nbsp;&nbsp;&nbsp;客</td>
										  <td align="right">无</td>
										</tr>
										<tr>
										  <td>货&nbsp;&nbsp;&nbsp;&nbsp;代</td>
										  <td align="right">无</td>
										</tr>
										<tr>
										  <td style="width: 50px">船公司</td>
										  <td align="right">无</td>
										</tr>											
										<tr>
										  <td>其&nbsp;&nbsp;&nbsp;&nbsp;它</td>
										  <td align="right">无</td>
										</tr>
									  </table></td>
									<td width="20%"></td>
									<td width="20%"></td>
								  </tr>
								</table>
							</div>
						</div>
                        <div id="yest2" class="x-hide-display">
							<div style="padding:10px 15px 10px 15px;">
								<table border="0" cellspacing="0" cellpadding="0" width="100%">
								  <tr>
									<td width="20%"><span class="tt14">普通用户</span>&nbsp;
                                        <asp:GridView ID="GridView18" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="50px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>
                                    </td>
									<td width="20%"><span class="tt14">高级用户</span>
									  <table border="0" cellspacing="0" cellpadding="0">
										<tr>
										  <td style="width: 50px">合&nbsp;&nbsp;&nbsp;&nbsp;计</td>
										  <td width="50" align="right">无</td>
										</tr>
										<tr>
										  <td style="width: 50px">直&nbsp;&nbsp;&nbsp;&nbsp;客</td>
										  <td align="right">无</td>
										</tr>
										<tr>
										  <td style="width: 50px">货&nbsp;&nbsp;&nbsp;&nbsp;代</td>
										  <td align="right">无</td>
										</tr>
										<tr>
										  <td style="width: 50px">船公司</td>
										  <td align="right">无</td>
										</tr>											
										<tr>
										  <td style="width: 50px">其&nbsp;&nbsp;&nbsp;&nbsp;它</td>
										  <td align="right">无</td>
										</tr>
									  </table></td>
									<td width="20%"><span class="tt14">VIP用户</span>
									  <table border="0" cellspacing="0" cellpadding="0">
										<tr>
										  <td width="50">合&nbsp;&nbsp;&nbsp;&nbsp;计</td>
										  <td width="50" align="right">无</td>
										</tr>
										<tr>
										  <td>直&nbsp;&nbsp;&nbsp;&nbsp;客</td>
										  <td align="right">无</td>
										</tr>
										<tr>
										  <td>货&nbsp;&nbsp;&nbsp;&nbsp;代</td>
										  <td align="right">无</td>
										</tr>
										<tr>
										  <td style="width: 50px">船公司</td>
										  <td align="right">无</td>
										</tr>											
										<tr>
										  <td>其&nbsp;&nbsp;&nbsp;&nbsp;它</td>
										  <td align="right">无</td>
										</tr>
									  </table></td>
									<td width="20%"></td>
									<td width="20%"></td>
								  </tr>
								</table>
							</div>
						</div>						
						<div id="markup2" class="x-hide-display">
							<div style="padding:10px 15px 10px 15px;">
                                <table border="0" cellspacing="0" cellpadding="0" width="100%">
								  <tr>
									<td width="20%"><span class="tt14">普通用户</span>
                                        <asp:GridView ID="GridView2" runat="server" BorderWidth="0px" CellPadding="0" ShowHeader="False" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("T") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Eval("C") %>
                                                    </ItemTemplate>                                                
                                                    <ItemStyle Width="50px" HorizontalAlign="Right" />
                                                </asp:TemplateField>                                                
                                            </Columns>
                                        </asp:GridView>
									</td>
									<td width="20%"><span class="tt14">高级用户</span>
									  <table border="0" cellspacing="0" cellpadding="0">
										<tr>
										  <td width="50">合&nbsp;&nbsp;&nbsp;&nbsp;计</td>
										  <td width="50" align="right">无</td>
										</tr>
										<tr>
										  <td>直&nbsp;&nbsp;&nbsp;&nbsp;客</td>
										  <td align="right">无</td>
										</tr>
										<tr>
										  <td>货&nbsp;&nbsp;&nbsp;&nbsp;代</td>
										  <td align="right">无</td>
										</tr>
										<tr>
										  <td style="width: 50px">船公司</td>
										  <td align="right">无</td>
										</tr>											
										<tr>
										  <td>其&nbsp;&nbsp;&nbsp;&nbsp;它</td>
										  <td align="right">无</td>
										</tr>
									  </table></td>
									<td width="20%"><span class="tt14">VIP用户</span>
									  <table border="0" cellspacing="0" cellpadding="0">
										<tr>
										  <td width="50">合&nbsp;&nbsp;&nbsp;&nbsp;计</td>
										  <td width="50" align="right">无</td>
										</tr>
										<tr>
										  <td>直&nbsp;&nbsp;&nbsp;&nbsp;客</td>
										  <td align="right">无</td>
										</tr>
										<tr>
										  <td>货&nbsp;&nbsp;&nbsp;&nbsp;代</td>
										  <td align="right">无</td>
										</tr>
										<tr>
										  <td style="width: 50px">船公司</td>
										  <td align="right">无</td>
										</tr>											
										<tr>
										  <td>其&nbsp;&nbsp;&nbsp;&nbsp;它</td>
										  <td align="right">无</td>
										</tr>
									  </table></td>
									<td width="20%"></td>
									<td width="20%"></td>
								  </tr>
								</table>
							</div>
						</div>
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