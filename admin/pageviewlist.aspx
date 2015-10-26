<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageviewlist.aspx.cs" Inherits="admin_pageviewlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="css/master.css" rel="stylesheet" type="text/css" />
    <link href="css/searchwordslist.css" rel="stylesheet" type="text/css" />
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
					<div class="text">页面统计</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">页面访问管理</div>
				</div>	
				<div class="rightArea txth22">
	                <div id="tipBoxSearch" class="tipBox hidden">
	                <table border="0" cellspacing="0" cellpadding="0">
	                  <tr>
	                    <td width="80" height="20"><strong>筛选结果：</strong></td>
	                    <td style="width: 45px">找到</td>
                        <td style="width: 70px"><asp:DropDownList ID="ddlSuccess" runat="server" Width="53px">
                            <asp:ListItem Value="">全部</asp:ListItem>
                            <asp:ListItem Value="1">找到</asp:ListItem>
                            <asp:ListItem Value="0">未找到</asp:ListItem>
                            </asp:DropDownList> </td>
	                    <td style="width: 45px">
                            类型&nbsp;</td>
	                    <td style="width: 70px">  
                            <asp:DropDownList ID="ddlStype" runat="server" Width="53px">
                            <asp:ListItem Value="">全部</asp:ListItem>
                            <asp:ListItem Value="8">整箱</asp:ListItem>
                            <asp:ListItem Value="9">拼箱</asp:ListItem>
                            </asp:DropDownList>
                        </td>
	                    <td style="width: 45px">
                            航线</td>
	                    <td style="width: 124px">
                            <asp:DropDownList ID="ddlLine" runat="server" Width="100px">
                            <asp:ListItem Value="">全部航线</asp:ListItem>
                            <asp:ListItem Value="美加线">美加线</asp:ListItem>
                            <asp:ListItem Value="欧地线">欧地线</asp:ListItem>
                            <asp:ListItem Value="中南美线">中南美线</asp:ListItem>
                            <asp:ListItem Value="日韩线">日韩线</asp:ListItem>
                            <asp:ListItem Value="近洋线">近洋线</asp:ListItem>
                            <asp:ListItem Value="非洲线">非洲线</asp:ListItem>
                            <asp:ListItem Value="澳洲线">澳洲线</asp:ListItem>
                            <asp:ListItem Value="中东印巴线">中东印巴线</asp:ListItem>
                            <asp:ListItem Value="红海线">红海线</asp:ListItem>
                            </asp:DropDownList>	                    
                           </td>
	                    <td style="width: 54px">
                            启运港</td>
	                    <td style="width: 80px"><asp:TextBox ID="txtStartport" runat="server" CssClass="t3" Width="53px"></asp:TextBox></td>
	                    <td style="width: 54px">
                            目的港</td>
	                    <td style="width: 80px"><asp:TextBox ID="txtDestport" runat="server" CssClass="t3" Width="53px"></asp:TextBox></td>	                    
	                    <td width="20"><input type="button" name="Submit" value="搜索" onclick="sendSeacch()" id="Button2" /></td>
	                  </tr> 
	                </table>
	                </div>
                    <asp:Panel ID="pnlSearchIntro" runat="server" CssClass="hidden">
                      <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                          <td width="500px" >&nbsp;&nbsp;&nbsp;&nbsp;<strong>您的筛选</strong>
                          &nbsp;&nbsp;找到：<strong><asp:Label ID="hidddlSuccess" runat="server"></asp:Label></strong>
                          &nbsp;&nbsp;类型：<strong><asp:Label ID="hidddlStype" runat="server" ></asp:Label></strong>
                          &nbsp;&nbsp;航线：<strong><asp:Label ID="hidddlLine" runat="server" ></asp:Label></strong>
                          &nbsp;&nbsp;启运港：<strong><asp:Label ID="hidTxtStartport" runat="server" ></asp:Label></strong>
                          &nbsp;&nbsp;目的港：<strong><asp:Label ID="hidTxtDestport" runat="server" ></asp:Label></strong>
                          &nbsp;
                          </td>
                          <td width="270px"><div style="text-align:right;">共有&nbsp;<strong><asp:Label ID="hidTotalItem" runat="server" ></asp:Label></strong>&nbsp;条记录&nbsp;&nbsp;&nbsp;&nbsp;<span class="edit"><asp:LinkButton ID="lnkShowAll" runat="server" Text="显示所有记录" OnClick="lnkShowAll_Click"></asp:LinkButton></span></div></td>
                        </tr>
                      </table>
                    </asp:Panel>
                    <div class="listTable">
                        <asp:GridView ID="GridView1" runat="server" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" BorderStyle="Solid" GridLines="Horizontal" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>                                   
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="0px" />
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <input id="chkAll" name="chkAll" type="checkbox" onclick="CheckAll(this.form);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input id="id" type="checkbox" value="<%# Eval("id") %>" onclick="checkToList(this.form)" />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>    
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        用户名 IP地址 公司名称
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c10"><a href="useredit.aspx?id=<%# Eval("Userid") %>"><%# Eval("username")%></a>&nbsp;&nbsp;(<a href="pageviewlist.aspx?uip=<%# Eval("Userip") %>"><%# Eval("Userip")%></a>)</div>
                                        <div class="c101"><nobr><%# Eval("companyname")%></nobr></div>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                 
                               <asp:TemplateField>
                                    <HeaderTemplate>
                                        访问时间
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div><%# Convert.ToDateTime(Eval("NowTime")).ToString("yyyy-MM-dd")%></div>
                                        <div class="c14"><%# Convert.ToDateTime(Eval("NowTime")).ToString("HH:mm:ss")%></div>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="80px" />
                                </asp:TemplateField>                                                                                              
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        板块
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# (Eval("pagearea"))%>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="60px" />
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        访问页面
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div><%# Eval("page")%></div>
                                        <div class="c14">来自：<%# Eval("request")%></div>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="335px" />
                                </asp:TemplateField>                                      
                               <asp:TemplateField>
                                    <HeaderTemplate>
                                        删除
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <a href="javascript:delConfirm('<%# Eval("id") %>')"><img src="/admin/images/del.gif" border=0 /></a>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:TemplateField>                                  
                            </Columns>                        
                            <HeaderStyle BackColor="#F0F0F0" />
                        </asp:GridView>
                    </div>
                    <div class="page"><div class="pageCount">共&nbsp;<strong><asp:Label ID="lblTotalPage" runat="server"  Text="1"></asp:Label></strong>&nbsp;页&nbsp;<strong><asp:Label
                            ID="lblTotalItem" runat="server" Text="0"></asp:Label></strong>&nbsp;条记录&nbsp;&nbsp;以上是第&nbsp;<strong><asp:Label
                            ID="lblCurrentPage" runat="server" Text="1"></asp:Label></strong>&nbsp;页</div><div class="pageControl">
                                <asp:LinkButton ID="lnkFirstPage" runat="server" OnClick="lnkFirstPage_Click">第一页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkPrePage" runat="server" OnClick="lnkPrePage_Click">上一页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkNextPage" runat="server" OnClick="lnkNextPage_Click">下一页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkLastPage" runat="server" OnClick="lnkLastPage_Click">最后页</asp:LinkButton>
                                </div>
                        <div class="pageText">直接翻页：</div>
                        <div class="pageSelect">
                        <asp:DropDownList ID="ddlPageSelect" runat="server" CssClass="pageDropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSelect_SelectedIndexChanged">
                        </asp:DropDownList>
                      </div>
                    </div>
                    <div class="buttons">
                        <input id="Button1" type="button" value="删除选定用户" onclick="delAll()" style="width:100px; height:30px" />
                        <asp:Button ID="btnHidDel" runat="server" Text="Button" CssClass="hidden" OnClick="btnHidDel_Click"/>
                        <asp:TextBox ID="delList" runat="server" CssClass="hidden"></asp:TextBox>
                        <asp:Button ID="btnHidSearch" runat="server" Text="Button" CssClass="hidden" OnClick="btnHidSearch_Click"/>
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