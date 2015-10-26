<%@ Page Language="VB" AutoEventWireup="false" CodeFile="bar2.aspx.vb" Inherits="search_bar2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>运价搜索</title>
    <link href="/css/master.css" rel="stylesheet" type="text/css" />
    <link href="/css/list.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="/js/function.js"></script>    
</head>
<body>
    <form id="form1" runat="server">
	<br />
		<div>
			  <table border="0" cellspacing="0" cellpadding="0">
					<tr>
					      <td valign="top">
					        <div>
					          <table border="0" cellspacing="0" cellpadding="0" id="s1"  style="display:none">
                                <tr>
                                  <td width="35">航线</td>
                                  <td width="110">
									<asp:DropDownList ID="txtLine" runat="server" Width="90px" Font-Size="12px">
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
								    </asp:DropDownList>								  </td>
                                  <td width="47">启运港</td>
                                  <td width="130">
									<asp:TextBox ID="txtStartport" runat="server" Width="100px"></asp:TextBox>								  </td>
                                  <td width="47">目的港</td>
                                  <td width="130">
                                    <asp:TextBox ID="txtDestport" runat="server" Width="100px"></asp:TextBox>                                  </td>
                                  <td>
                                      <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images/search3.gif" PostBackUrl="fcl.htm" />                                  </td>
                                </tr>
                              </table>
							<table border="0" cellspacing="0" cellpadding="0" id="s2" style="display:none">
                                <tr>
                                  <td width="35">航线</td>
                                  <td width="110">
									<asp:DropDownList ID="txtLine2" runat="server" Width="90px" Font-Size="12px">
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
								  </asp:DropDownList>								  </td>
                                  <td width="47">启运港</td>
                                  <td width="130">
									<asp:TextBox ID="txtStartport2" runat="server" Width="100px"></asp:TextBox>								  </td>
                                  <td width="47">目的港</td>
                                  <td width="130"><asp:TextBox ID="txtDestport2" runat="server" Width="100px"></asp:TextBox>                                  </td>
                                  <td>
                                      <asp:ImageButton ID="ImageButton12" runat="server" ImageUrl="/images/search3.gif" PostBackUrl="lcl.htm" />                                  </td>
                                </tr>
                              </table>
							<table border="0" cellspacing="0" cellpadding="0" id="s3" style="display:none">
                                <tr>
                                  <td width="35">航线</td>
                                  <td width="110">
									<asp:DropDownList ID="txtLine3" runat="server" Width="90px" Font-Size="12px">
                                        <asp:ListItem Text="全部航线" Value=""></asp:ListItem>
                                        <asp:ListItem>北美线</asp:ListItem>
                                        <asp:ListItem>欧洲线</asp:ListItem>
                                        <asp:ListItem>南美线</asp:ListItem>
                                        <asp:ListItem>亚洲线</asp:ListItem>
                                        <asp:ListItem>非洲线</asp:ListItem>
                                        <asp:ListItem>澳洲线</asp:ListItem>
                                        <asp:ListItem>国内航线</asp:ListItem>
								  </asp:DropDownList>									  </td>
                                  <td width="47">启运港</td>
                                  <td width="130">
									<asp:TextBox ID="txtStartport3" runat="server" Width="100px"></asp:TextBox>								  </td>
                                  <td width="47">目的港</td>
                                  <td width="130"><asp:TextBox ID="txtDestport3" runat="server" Width="100px"></asp:TextBox>                                  </td>
                                  <td>
                                      <asp:ImageButton ID="ImageButton13" runat="server" ImageUrl="/images/search3.gif" PostBackUrl="air.htm" />                                  </td>
                                </tr>
                              </table>
							<table border="0" cellspacing="0" cellpadding="0" id="s4" style="display:none">
                                <tr>
                                  <td width="35">种类</td>
                                  <td width="110">
									<asp:DropDownList ID="txtLine4" runat="server" Width="90px" Font-Size="12px">
                                        <asp:ListItem Text="全部" Value=""></asp:ListItem>
                                        <asp:ListItem>海运货盘</asp:ListItem>
                                        <asp:ListItem>空运货盘</asp:ListItem>
								  </asp:DropDownList>									  </td>
                                  <td width="47">启运港</td>
                                  <td width="130">
									<asp:TextBox ID="txtStartport4" runat="server" Width="100px"></asp:TextBox>								  </td>
                                  <td width="47">目的港</td>
                                  <td width="130"><asp:TextBox ID="txtDestport4" runat="server" Width="100px"></asp:TextBox>                                  </td>
                                  <td>
                                      <asp:ImageButton ID="ImageButton14" runat="server" ImageUrl="/images/search3.gif" PostBackUrl="cargo.htm" />                                  </td>
                                </tr>
                              </table>
                              <div style="margin-top:4px;">
                                    <input id="tt1" type="radio" name="tt" value="找整箱运价" onclick="dyts3.showtab(0);" checked/><label for="tt1" style="font-size:13px;">找整箱运价</label>
                                    <input id="tt2" type="radio" name="tt" value="找拼箱运价" onclick="dyts3.showtab(1);"/><label for="tt2" style="font-size:13px;">找拼箱运价</label>
                                    <input id="tt3" type="radio" name="tt" value="找空运运价" onclick="dyts3.showtab(2);"/><label for="tt3" style="font-size:13px;">找空运运价</label>
                                    <span class="blue" id="t1"></span><span class="blue" id="t2"></span><span class="blue" id="t3"></span><span class="blue" id="t4"></span>                                </div>
					        </div>				      </td>
					      <td></td>
					</tr>
					<tr>
					  <td></td>
					  <td></td>
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
dyts3.showtab(0);dyts3.clearautoshow();
//-->
</script>    
</body>
</html>
