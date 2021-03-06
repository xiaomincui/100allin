﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="countpricepol.aspx.cs" Inherits="admin_countpricepol" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="css/master.css" rel="stylesheet" type="text/css" />
	<link rel="stylesheet" type="text/css" href="/ext/resources/css/ext-all.css" />
	<link rel="stylesheet" type="text/css" href="/ext/resources/css/xtheme-gray.css" />
	<script type="text/javascript" src="/ext/adapter/ext/ext-base.js"></script>
	<script type="text/javascript" src="/ext/ext-all.js"></script>
	<script type="text/javascript" src="js/tabs-countprice.js"></script>
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
					<div class="text">运价/货盘统计(按启运港分类)</div>
				</div>	
				<div class="rightArea txth22">
					<div id="tabs1">
						<div id="script" class="x-hide-display">
							<div style="padding:10px 15px 10px 15px;">
								<table border="0" cellspacing="0" cellpadding="0" width="100%">
								  <tr>
									<td width="33%" valign="top"><span class="tt14">整箱运价</span>
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
									<td width="33%" valign="top"><span class="tt14">拼箱运价</span>
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
									<td width="33%" valign="top"><span class="tt14">空运运价</span>
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


								  </tr>
								</table>
							</div>
						</div>
                        <div id="yest" class="x-hide-display">
							<div style="padding:10px 15px 10px 15px;">
								<table border="0" cellspacing="0" cellpadding="0" width="100%">
								  <tr>
									<td width="33%" valign="top"><span class="tt14">整箱运价</span>
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
									<td width="33%" valign="top"><span class="tt14">拼箱运价</span>
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
									<td width="33%" valign="top"><span class="tt14">空运运价</span>
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

								  </tr>
								</table>
							</div>
						</div>						
						<div id="markup" class="x-hide-display">
							<div style="padding:10px 15px 10px 15px;">
								<table border="0" cellspacing="0" cellpadding="0" width="100%">
								  <tr>
									<td width="33%" valign="top"><span class="tt14">整箱运价</span>
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
									<td width="33%" valign="top"><span class="tt14">拼箱运价</span>
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
									<td width="33%" valign="top"><span class="tt14">空运运价</span>
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

								  </tr>
								</table>
							</div>
						</div>
                        <div id="now" class="x-hide-display">
							<div style="padding:10px 15px 10px 15px;">
								<table border="0" cellspacing="0" cellpadding="0" width="100%">
								  <tr>
									<td width="33%" valign="top"><span class="tt14">整箱运价</span>
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
									<td width="33%" valign="top"><span class="tt14">拼箱运价</span>
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
									<td width="33%" valign="top"><span class="tt14">空运运价</span>
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
