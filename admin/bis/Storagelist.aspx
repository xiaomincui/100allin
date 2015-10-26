<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Storagelist.aspx.cs" Inherits="admin_userlist" %>

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
					<div class="icon"><img src="../images/home_title.gif" /></div>
					<div class="text">用户管理</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">用户编辑</div>
				</div>
				
				<div class="rightArea txth22">
	                <div id="tipBoxSearch" class="tipBox">
	                <table border="0" cellspacing="0" cellpadding="0" height="30px">
	                  <tr>
	                    <td width="80" height="20"><strong>搜索用户：</strong></td>
	                    <td width="35">编号</td>
                        <td width="106px"><asp:TextBox ID="txtID" runat="server" CssClass="t2"></asp:TextBox></td>
	                    
	                    <td style="width: 60px">
                            联系人</td>
	                    <td style="width: 106px"><asp:TextBox ID="txtLink" runat="server" CssClass="t2"></asp:TextBox></td>
	                    <td style="width: 35px">
                            类型</td>
	                    <td width="146">
                            <asp:DropDownList ID="ddlType" runat="server">
                                <asp:ListItem Value="">全部</asp:ListItem>
                                <asp:ListItem>普通</asp:ListItem>
                                <asp:ListItem>保税</asp:ListItem>
                                <asp:ListItem>立体</asp:ListItem>
                                <asp:ListItem>冷库</asp:ListItem>
                                <asp:ListItem>危险</asp:ListItem>
                                <asp:ListItem>其他</asp:ListItem>
                            </asp:DropDownList></td>
	                    <td style="width: 20px"> </td>
	                  </tr>
	                 </table>
	                 <table border="0" cellspacing="0" cellpadding="0" height="30px">
	                  <tr>
	                    <td width="80" height="20"></td>
	                    <td width="35">
                            城市</td>
                        <td width="106"><asp:TextBox ID="txtCity" runat="server" CssClass="t2"></asp:TextBox></td>
	                    
	                    <td style="width: 60px">
                            仓库名称</td>
	                    <td style="width: 161px"><asp:TextBox ID="txtStorage" runat="server" CssClass="t3"></asp:TextBox></td>
	                    <td style="width: 35px"> 
                            状态</td>
	                    <td style="width: 20px"> 
                            <asp:DropDownList ID="ddlState" runat="server">
                                <asp:ListItem Selected="True" Value="">全部</asp:ListItem>
                                <asp:ListItem Value="0">待定</asp:ListItem>
                                <asp:ListItem Value="1">确认</asp:ListItem>
                            </asp:DropDownList></td>
	                  </tr>
	                 </table>
	                 
	                   
	                 
	                 
	                 
	                 	                 
	                 <table border="0" cellspacing="0" cellpadding="0" width="100%">
	                  <tr>
	                    <td align="center">
	                        <input type="button" name="Submit" value="搜索" onclick="sendSeacch()" id="Button2" style="width:60px; height:30px;" />
	                    </td>
	                  </tr>
	                 </table>
	                </div>
                    <asp:Panel ID="pnlSearchIntro" runat="server" CssClass="hidden">
                      <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                          <td width="200px" >&nbsp;&nbsp;&nbsp;&nbsp;搜索结果：&nbsp;</td>
                          <td width="570px"><div style="text-align:right;">您搜索的是：&nbsp;
                          <strong>
                          <asp:Label ID="hidID" runat="server"></asp:Label>&nbsp;&nbsp;
                          <asp:Label ID="hidLink" runat="server" ></asp:Label>&nbsp;&nbsp;
                          <asp:Label ID="hidType" runat="server" ></asp:Label>&nbsp;&nbsp;
                          <asp:Label ID="hidCity" runat="server" ></asp:Label>&nbsp;&nbsp;
                          <asp:Label ID="hidStorage" runat="server" ></asp:Label>&nbsp;&nbsp;
                          <asp:Label ID="hidState" runat="server" ></asp:Label>&nbsp;&nbsp;
                          
                          </strong>
                          &nbsp;，傲赢网共为您找到&nbsp;<strong><asp:Label ID="hidTotalItem" runat="server" ></asp:Label></strong>&nbsp;条记录&nbsp;&nbsp;&nbsp;&nbsp;<span class="edit"><asp:LinkButton ID="lnkShowAll" runat="server" Text="显示所有用户" OnClick="lnkShowAll_Click"></asp:LinkButton></span></div></td>
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
                                        编号
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Eval("id")%>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="35px" />
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        是/否
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <img src="<%#(Convert.ToInt32(Eval("state").ToString()) == 1) ? "/admin/bis/images/gou.jpg":"/admin/bis/images/cha.jpg"%>" border="0" />
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="38px" HorizontalAlign="Center" />
                                </asp:TemplateField> 
                                
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        类型
                                    </HeaderTemplate>
                                    <ItemTemplate>
					<%# Eval("TypeName") %>
                                        
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="40px" />
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        城市
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c2"><nobr><%# Eval("City")%></nobr></div>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="90px" />
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        联系人
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c3"><nobr><%# Eval("linkmen")%></nobr></div>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="65px" />
                                </asp:TemplateField>    
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        公司名称
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c4"><nobr><%# Eval("Company")%></nobr></div>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="168px" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        电话
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c5"><nobr><%# Eval("Phone")%></nobr></div>
                                        
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="110px" />
                                </asp:TemplateField>
                                  
                                
                                  
                               <asp:TemplateField>
                                    <HeaderTemplate>
                                        注册时间
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Convert.ToDateTime(Eval("Postdate")).ToString("yyyy-MM-dd")%><BR/>
                                        <%# Convert.ToDateTime(Eval("Postdate")).ToString("HH:mm:ss")%>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>   
                                <%--<asp:TemplateField>
                                    <HeaderTemplate>
                                        反馈
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <a href="usermemo.aspx?id=<%# Eval("ID") %>"><img src="/admin/images/<%# ( Convert.ToInt32(Eval("mcount")) > 0) ? "feedback1" : "feedback"%>.gif" border=0 /></a> 
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:TemplateField>   --%>                                                                                                                                                                                   
                               <asp:TemplateField>
                                    <HeaderTemplate>
                                        编辑
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <a href="Storage.aspx?id=<%# Eval("id") %>"><img src="/admin/images/edit.gif" border=0 /></a> 
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
