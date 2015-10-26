<%@ Page Language="C#" AutoEventWireup="true" CodeFile="airbbs.aspx.cs" Inherits="admin_userlist" %>

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
				
				
				<div class="rightArea txth22">
	                
                    
                    <div class="listTable">
                        <asp:GridView ID="GridView1" runat="server" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" BorderStyle="Solid" GridLines="Horizontal" OnRowDataBound="GridView1_RowDataBound" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" Width="780px">
                            <Columns>
                                <asp:TemplateField>
                                <EditItemTemplate>
                                    &nbsp;
                                </EditItemTemplate>
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemStyle Width="0px" />
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>                             
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        编号
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Eval("id") %>
                                    </ItemTemplate> <ItemStyle Width="35px" />
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        类型
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Eval("UserID")%>
                                    </ItemTemplate><ItemStyle Width="70px" />
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        内容
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c13"><nobr><%# Eval("Data")%></nobr></div>
                                    </ItemTemplate> 
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Data") %>' Width="260px"></asp:TextBox>
                                    </EditItemTemplate>                                               
                                    <ItemStyle Width="290px" />
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        日期
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c14"><nobr><%# Eval("PostDate")%></nobr></div>
                                    </ItemTemplate>  
                                                 
                                    <ItemStyle Width="120px" />
                                </asp:TemplateField>    
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        公司名称
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c4"><nobr><%# Eval("username")%></nobr></div>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="168px" />
                                </asp:TemplateField>

                                  
                                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" HeaderText="操作" >
                                    <HeaderStyle  Font-Bold="False" Font-Names="宋体" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                                </asp:CommandField>
                            </Columns>                        
                            <HeaderStyle BackColor="#F0F0F0" />
                            <EmptyDataTemplate>
                                &nbsp;
                            </EmptyDataTemplate>
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
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="返回列表" />&nbsp;</div>                  
			    </div>			
			</div>			
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>
