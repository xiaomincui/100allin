<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bbsEditlist.aspx.cs" Inherits="admin_userlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="css/master.css" rel="stylesheet" type="text/css" />
    <link href="css/userlist.css" rel="stylesheet" type="text/css" />
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
					<div class="icon"><img src="images/home_title.gif" /></div>
					<div class="text">用户管理</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">用户编辑</div>
				</div>	
				<div class="rightArea txth22">
	                <div id="tipBoxSearch" class="tipBox">
	                <table border="0" cellspacing="0" cellpadding="0">
	                  <tr>
	                    <td width="80" height="20"><strong>搜索用户：</strong></td>
	                    <td style="width: 30px">编号</td>
                        <td style="width: 53px"><asp:TextBox ID="txtYunjiaid" runat="server" CssClass="t1"></asp:TextBox></td>
	                    <td style="width: 45px">
                            管理员&nbsp;</td>
	                    <td style="width: 89px">  
                            <asp:TextBox ID="txtLine" runat="server" CssClass="t2"></asp:TextBox>
                        </td>
	                    <td style="width: 43px">
                            日期</td>
	                    <td style="width: 184px">
	                    
	                    <span style="color: #226077">
                                    <input id="txtenddate" runat="server" name="date1" type="text" style="width: 74px" />
                                        <A onclick=event.cancelBubble=true; href="javascript:showCalendar('IMG1',true,'txtenddate',null);">
	  <IMG id=IMG1 height=21 src="../web_Admin/images/button.gif" width=34 align=absMiddle border=0></A>
                            </span>
                           <asp:DropDownList ID="DropDownList1" runat="server" Width="53px">
                            <asp:ListItem Value="&gt;">以前</asp:ListItem>
                            <asp:ListItem Value="=">当天</asp:ListItem>
                            <asp:ListItem Value="&lt;">以后</asp:ListItem>
                            </asp:DropDownList> 
                           </td>
	                    <td style="width: 54px">
                            类型</td>
	                    <td style="width: 119px">
                            <asp:DropDownList ID="DropDownList2" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="0">删除</asp:ListItem>
                                <asp:ListItem Value="1">置顶</asp:ListItem>
                                <asp:ListItem Value="2">移动板块</asp:ListItem>
                                <asp:ListItem Value="3">恢复</asp:ListItem>
                                <asp:ListItem Value="4">取消置顶</asp:ListItem>
                                <asp:ListItem Value="5">编辑帖子</asp:ListItem>
                                <asp:ListItem Value="6">编辑回帖</asp:ListItem>
                            </asp:DropDownList></td>
	                    <td width="20"><input type="button" name="Submit" value="搜索" onclick="sendSeacch()" id="Button2" /></td>
	                  </tr> 
	                </table>
	                </div>
                    <asp:Panel ID="pnlSearchIntro" runat="server" CssClass="hidden">
                      <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                          <td width="200px" >&nbsp;&nbsp;&nbsp;&nbsp;搜索结果：&nbsp;</td>
                          <td width="570px"><div style="text-align:right;">您搜索的是：&nbsp;<strong><asp:Label ID="hidTxtYunjiaid" runat="server">
                          </asp:Label>&nbsp;&nbsp;<asp:Label ID="hidTxtLine" runat="server" >
                          </asp:Label>&nbsp;&nbsp;<asp:Label ID="hidTxtStartport" runat="server" >
                          </asp:Label>&nbsp;&nbsp;<asp:Label ID="hidTxtDestport" runat="server" >
                          </asp:Label></strong>&nbsp;，傲赢网共为您找到&nbsp;<strong><asp:Label ID="hidTotalItem" runat="server" ></asp:Label></strong>&nbsp;条记录&nbsp;&nbsp;&nbsp;&nbsp;<span class="edit"><asp:LinkButton ID="lnkShowAll" runat="server" Text="显示所有用户" OnClick="lnkShowAll_Click"></asp:LinkButton></span></div></td>
                        </tr>
                      </table>
                    </asp:Panel>
                    <div class="listTable">
                        <asp:GridView ID="GridView1" runat="server" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" BorderStyle="Solid" GridLines="Horizontal" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                                              
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        编号
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Eval("BBSID")%>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="35px" />
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        类型
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Eval("Types").ToString() == "0" ? "删除" : Eval("Types").ToString() == "1" ? "置顶" : Eval("Types").ToString() == "2" ? "移动板块" : Eval("Types").ToString() == "3" ? "恢复" : Eval("Types").ToString() == "4" ? "取消置顶" : Eval("Types").ToString() == "5" ? "编辑帖子" : Eval("Types").ToString() == "6" ? "回帖内容" : "无"%>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        标题
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c10" style=" width:503px"><nobr><%# Eval("Meno")%></nobr></div>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="503px" />
                                </asp:TemplateField> 
                                
                                
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        用户名
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c12"><nobr><%# Eval("username")%></nobr></div>
                                        
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                  

                                  
                               <asp:TemplateField>
                                    <HeaderTemplate>
                                        有效时间
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Convert.ToDateTime(Eval("EditTime")).ToString("yyyy-MM-dd")%>
                                        <br />
                                        <%# Convert.ToDateTime(Eval("EditTime")).ToString("t")%>
                                        
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>                                                                                                                                                                                       
                               <%--<asp:TemplateField>
                                    <HeaderTemplate>
                                        编辑
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <a href="lclbbs.aspx?id=<%# Eval("id") %>"><img src="/admin/images/edit.gif" border=0 /></a> 
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:TemplateField>    
                               <asp:TemplateField>
                                    <HeaderTemplate>
                                        删除
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <a href="javascript:delConfirm('<%# Eval("id") %>')"><img src="/admin/images/del.gif" border=0 /></a>
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:TemplateField>  --%>                                
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
