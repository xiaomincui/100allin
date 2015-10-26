<%@ Page Language="C#" AutoEventWireup="true" CodeFile="countuser.aspx.cs" Inherits="admin_countuser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="css/master.css" rel="stylesheet" type="text/css" />
	<link rel="stylesheet" type="text/css" href="/ext/resources/css/ext-all.css" />
	<link rel="stylesheet" type="text/css" href="/ext/resources/css/xtheme-gray.css" />
	<script type="text/javascript" src="/ext/adapter/ext/ext-base.js"></script>
	<script type="text/javascript" src="/ext/ext-all.js"></script>
	<script type="text/javascript" src="js/tabs-countuser.js"></script>
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
					<div class="text">相关统计</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">注册用户统计</div>
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