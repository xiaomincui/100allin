<%@ Page Language="VB" AutoEventWireup="false" CodeFile="bar.aspx.vb" Inherits="search_bar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="/css/master.css" rel="stylesheet" type="text/css" />
    <link href="/css/list.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="/js/function.js"></script>    
</head>
<body>
    <form id="form1" runat="server">
<div id="search">
					  <table border="0" cellspacing="0" cellpadding="0">
							<tr>
							  <td width="10" ><img src="/images/box_1.gif" width="10" height="31" /></td>
							  <td width="780" background="/images/box_2.gif" >
							    <table width="100%">
							        <tr>
							            <td>
                                            <span class="blue" id="t1" onclick="dyts3.showtab(0);" >找整箱运价</span> | <span class="blue" id="t2" onclick="dyts3.showtab(1);" >找拼箱运价</span> | <span class="blue" id="t3" onclick="dyts3.showtab(2);" >找空运运价</span> | <span class="blue" id="t4" onclick="dyts3.showtab(3);">找货盘信息</span>					            
							            </td>
							            <td align=right>
							                <img src="/images/searchbar.gif" />
							            </td>
							        </tr>
							    </table>
							  </td>
							  <td width="10" ><img src="/images/box_3.gif" width="10" height="31" /></td>
							</tr>
							<tr>
							      <td background="/images/box_4_b.gif" style="height: 15px"></td>
							      <td bgcolor="#F6FBFD">
							        <div class="searchbox">
							          <table border="0" cellspacing="0" cellpadding="0" id="s1"  style="display:none">
                                        <tr>
                                          <td width="40">航线</td>
                                          <td width="140">
											<asp:DropDownList ID="txtLine" runat="server" Width=105 Font-Size="12px">
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
										  </asp:DropDownList>									  </td>
                                          <td width="52">启运港</td>
                                          <td width="178">
											<asp:TextBox ID="txtStartport" runat="server" CssClass="bigTextbox"></asp:TextBox>
											 
										  </td>
                                          <td width="52">目的港</td>
                                          <td width="178"><asp:TextBox ID="txtDestport" runat="server" CssClass="bigTextbox"></asp:TextBox>
                                                  
                                          </td>
                                          <td width="120"><div style="text-align:right">
                                              <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images/search.gif" PostBackUrl="fcl.htm" /></div></td>
                                        </tr>
                                        <tr>
                                          <td colspan="7"><div style="margin-top:10px; margin-bottom:5px; color:#FF0000;">提示： 输入启运港或目的港名称时，请尽量使用英语，如 <strong>上海</strong> 请输入 <strong>shanghai</strong></div></td>
                                        </tr>
                                      </table>
									<table border="0" cellspacing="0" cellpadding="0" id="s2" style="display:none">
                                        <tr>
                                          <td width="40">航线</td>
                                          <td width="140">
											<asp:DropDownList ID="txtLine2" runat="server" Width=105 Font-Size="12px">
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
										  </asp:DropDownList>									  </td>
                                          <td width="52">启运港</td>
                                          <td width="178">
											<asp:TextBox ID="txtStartport2" runat="server" CssClass="bigTextbox"></asp:TextBox>
											 
										  </td>
                                          <td width="52">目的港</td>
                                          <td width="178"><asp:TextBox ID="txtDestport2" runat="server" CssClass="bigTextbox"></asp:TextBox>
                                                  
                                          </td>
                                          <td width="120"><div style="text-align:right">
                                              <asp:ImageButton ID="ImageButton12" runat="server" ImageUrl="/images/search.gif" PostBackUrl="lcl.htm" /></div></td>
                                        </tr>
                                        <tr>
                                          <td colspan="7"><div style="margin-top:10px; margin-bottom:5px; color:#FF0000;">提示： 输入启运港或目的港名称时，请尽量使用英语，如 <strong>上海</strong> 请输入 <strong>shanghai</strong></div></td>
                                        </tr>
                                      </table>
									<table border="0" cellspacing="0" cellpadding="0" id="s3" style="display:none">
                                        <tr>
                                          <td width="40">航线</td>
                                          <td width="140">
											<asp:DropDownList ID="txtLine3" runat="server" Width=105 Font-Size="12px">
                                                <asp:ListItem Text="全部航线" Value=""></asp:ListItem>
                                                <asp:ListItem>北美线</asp:ListItem>
                                                <asp:ListItem>欧洲线</asp:ListItem>
                                                <asp:ListItem>中南美线</asp:ListItem>
                                                <asp:ListItem>亚洲线</asp:ListItem>
                                                <asp:ListItem>非洲线</asp:ListItem>
                                                <asp:ListItem>澳洲线</asp:ListItem>
                                                <asp:ListItem>国内航线</asp:ListItem>
										  </asp:DropDownList>									  </td>
                                          <td width="52">启运港</td>
                                          <td width="178">
											<asp:TextBox ID="txtStartport3" runat="server" CssClass="bigTextbox"></asp:TextBox>
											 
										  </td>
                                          <td width="52">目的港</td>
                                          <td width="178"><asp:TextBox ID="txtDestport3" runat="server" CssClass="bigTextbox"></asp:TextBox>
                                                  
                                          </td>
                                          <td width="120"><div style="text-align:right">
                                              <asp:ImageButton ID="ImageButton13" runat="server" ImageUrl="/images/search.gif" PostBackUrl="air.htm" /></div></td>
                                        </tr>
                                        <tr>
                                          <td colspan="7"><div style="margin-top:10px; margin-bottom:5px; color:#FF0000;">提示： 输入启运港或目的港名称时，请尽量使用英语，如 <strong>上海</strong> 请输入 <strong>shanghai</strong></div></td>
                                        </tr>
                                      </table>
									<table border="0" cellspacing="0" cellpadding="0" id="s4" style="display:none">
                                        <tr>
                                          <td width="40">种类</td>
                                          <td width="140">
											<asp:DropDownList ID="txtLine4" runat="server" Width=105 Font-Size="12px">
                                                <asp:ListItem Text="全部" Value=""></asp:ListItem>
                                                <asp:ListItem>海运货盘</asp:ListItem>
                                                <asp:ListItem>空运货盘</asp:ListItem>
										  </asp:DropDownList>									  </td>
                                          <td width="52">启运港</td>
                                          <td width="178">
											<asp:TextBox ID="txtStartport4" runat="server" CssClass="bigTextbox"></asp:TextBox>
											 
										  </td>
                                          <td width="52">目的港</td>
                                          <td width="178"><asp:TextBox ID="txtDestport4" runat="server" CssClass="bigTextbox"></asp:TextBox>
                                                  
                                          </td>
                                          <td width="120"><div style="text-align:right">
                                              <asp:ImageButton ID="ImageButton14" runat="server" ImageUrl="/images/search.gif" PostBackUrl="cargo.htm" /></div></td>
                                        </tr>
                                        <tr>
                                          <td colspan="7"><div style="margin-top:10px; margin-bottom:5px; color:#FF0000;">提示： 输入启运港或目的港名称时，请尽量使用英语，如 <strong>上海</strong> 请输入 <strong>shanghai</strong></div></td>
                                        </tr>
                                      </table>
							        </div>
							      </td>
							      <td background="/images/box_6_b.gif" style="height: 15px"></td>
							</tr>
							<tr>
							  <td><img src="/images/box_7_b.gif" width="10" height="10" /></td>
							  <td background="/images/box_8_b.gif"></td>
							  <td><img src="/images/box_9_b.gif" width="10" height="10" /></td>
							</tr>
				      </table>
				</div>
    </form>
<script type="text/javascript">
<!--
var dyts3 = new dytabstrip("bigBoxTitle","blue");
dyts3.addtab(document.getElementById("t1"),document.getElementById("s1"));
dyts3.addtab(document.getElementById("t2"),document.getElementById("s2"));
dyts3.addtab(document.getElementById("t3"),document.getElementById("s3"));
dyts3.addtab(document.getElementById("t4"),document.getElementById("s4"));
dyts3.showtab(0);dyts3.clearautoshow();
//-->
</script>    
</body>
</html>
