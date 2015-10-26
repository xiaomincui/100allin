<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecommendAdmin.aspx.cs" Inherits="admin_userlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="../css/master.css" rel="stylesheet" type="text/css" />
    <link href="../css/userlist.css" rel="stylesheet" type="text/css" />
    <script language=javascript src=../js/function.js></script>    
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
					<div class="text">用户管理</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">用户编辑</div>
				</div>	
				<div class="rightArea txth22">
	                <div class="tipBox">
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>的积分：<asp:Label ID="Label6"
                            runat="server" Text="Label"></asp:Label></div>
                    <div class="listTable">
                        <asp:GridView ID="GridView1" runat="server" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" BorderStyle="Solid" GridLines="Horizontal" OnRowDataBound="GridView1_RowDataBound" Width="780px">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>                                   
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="0px" />
                                </asp:TemplateField>                               

                            <asp:TemplateField >
                                <ItemTemplate>
                                <div class="c1" style=" padding-left:5px">
                                <nobr>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("id") %>'></asp:Label></nobr>
                                </div>
                                </ItemTemplate>
                                
                                <ItemStyle Width="5px" />
                                <HeaderTemplate>
                                    <div style=" padding-left:5px">编号</div>
                                </HeaderTemplate>
                                
                            </asp:TemplateField>

                                <asp:TemplateField >
                                <ItemTemplate>
                                <div class="c6" style=" padding-left:20px">
                                <nobr>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("reason") %>'></asp:Label></nobr>
                                </div>
                                </ItemTemplate>
                                
                                <ItemStyle Width="290px" />
                                <HeaderTemplate>
                                    <div style=" padding-left:20px">原因</div>
                                </HeaderTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="时间">
                                <ItemTemplate>
                                
                                    
                                    <div class="c7"><nobr><asp:Label ID="Label5" runat="server" Text='<%# Eval("MarkTime") %>'></asp:Label></nobr></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="分数">
                                <ItemTemplate>
                                    
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("mark") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="推荐人">
                                <ItemTemplate>
                                    
                                    <div class="c7"><nobr><asp:Label ID="Label4" runat="server" Text='<%# Eval("Username") %>'></asp:Label></nobr></div>
                                </ItemTemplate>
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
                        <asp:Button ID="btnHidDel" runat="server" CssClass="hidden" OnClick="btnHidDel_Click"
                            Text="Button" /><asp:TextBox ID="delList" runat="server" CssClass="hidden"></asp:TextBox><br />
                        &nbsp;<table style="width: 500px">
                            <tr>
                                <td style="width: 124px; height: 24px">
                                    金额</td>
                                <td style="width: 100px; height: 24px">
                                    <asp:TextBox ID="txtAmount" runat="server" Width="293px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 124px">
                                    原因</td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtReason" runat="server" Width="293px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center">
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确定" /></td>
                            </tr>
                        </table>
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
