<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reg0926.aspx.cs" Inherits="admin_topic_reg0926" %>
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
					<div class="text">活动管理</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">申请“注册发运价获得免费推广”的客户</div>
				</div>
				<div class="rightArea txth22">
	                <div id="tipBoxSearch" class="tipBox" style="display:none;">
	                <table border="0" cellspacing="0" cellpadding="0" height="30px">
	                  <tr>
	                    <td width="80" height="20"><strong>搜索用户：</strong></td>
	                    <td width="35">编号</td>
                        <td width="106px"><asp:TextBox ID="txtYunjiaid" runat="server" CssClass="t2"></asp:TextBox></td>
	                    <td style="width: 45px">
                            用户名
                        </td>
	                    <td width="110">  
                            <asp:TextBox ID="txtLine" runat="server" CssClass="t2"></asp:TextBox>
                        </td>
	                    <td style="width: 60px">
                            真实姓名</td>
	                    <td style="width: 106px"><asp:TextBox ID="txtStartport" runat="server" CssClass="t2"></asp:TextBox></td>
	                    <td style="width: 35px">
                            邮件</td>
	                    <td width="146"><asp:TextBox ID="txtEmail" runat="server" CssClass="t2"></asp:TextBox></td>
	                    <td style="width: 20px"> </td>
	                  </tr>
	                 </table>
	                 <table border="0" cellspacing="0" cellpadding="0" height="30px">
	                  <tr>
	                    <td width="80" height="20"></td>
	                    <td width="35">电话</td>
                        <td width="106"><asp:TextBox ID="txtTel" runat="server" CssClass="t2"></asp:TextBox></td>
	                    <td style="width: 45px">
                            手机
                        </td>
	                    <td width="110">  
                            <asp:TextBox ID="txtMobile" runat="server" CssClass="t2"></asp:TextBox>
                        </td>
	                    <td style="width: 60px">
                            公司名称</td>
	                    <td style="width: 161px"><asp:TextBox ID="txtDestport" runat="server" CssClass="t3"></asp:TextBox></td>
	                    
	                  </tr>
	                 </table>
	                 
	                 <table border="0" cellspacing="0" cellpadding="0" height="30px">
	                  <tr>
	                  <td width="80" height="20"></td>
	                    <td style="width: 35px"> 
                            状态</td>
	                    <td style="width: 20px"> 
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem Selected="True" Value="全部">全部</asp:ListItem>
                                <asp:ListItem Value="0">待定</asp:ListItem>
                                <asp:ListItem Value="1">正确</asp:ListItem>
                                <asp:ListItem Value="2">错误</asp:ListItem>
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
                          <asp:Label ID="hidTxtYunjiaid" runat="server"></asp:Label>&nbsp;&nbsp;
                          <asp:Label ID="hidTxtLine" runat="server" ></asp:Label>&nbsp;&nbsp;
                          <asp:Label ID="hidTxtStartport" runat="server" ></asp:Label>&nbsp;&nbsp;
                          <asp:Label ID="hidTxtEmail" runat="server" ></asp:Label>&nbsp;&nbsp;
                          <asp:Label ID="hidTxtTel" runat="server" ></asp:Label>&nbsp;&nbsp;
                          <asp:Label ID="hidTxtMobile" runat="server" ></asp:Label>&nbsp;&nbsp;
                          <asp:Label ID="hidTxtDestport" runat="server" ></asp:Label>&nbsp;&nbsp;
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
                                        <input id="id" type="checkbox" value="<%# Eval("rid") %>" onclick="checkToList(this.form)" />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>                               
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        编号
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Eval("UserID") %>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="35px" />
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        类型
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                    
                                    <%# (Eval("CompanyType").ToString() == "1") ? "货主" : 
    (Eval("CompanyType").ToString() == "2") ? "货代" :
    (Eval("CompanyType").ToString() == "3") ? "船东" :
    (Eval("CompanyType").ToString() == "4") ? "其他" :
    (Eval("CompanyType").ToString() == "5") ? "船代" :
    (Eval("CompanyType").ToString() == "6") ? "快递" :
    (Eval("CompanyType").ToString() == "7") ? "场站" :
    (Eval("CompanyType").ToString() == "8") ? "仓储" :
    (Eval("CompanyType").ToString() == "9") ? "集卡" :
    (Eval("CompanyType").ToString() == "10") ? "报关" :  ""                                  
                                        %>
                                    
					
                                        
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="40px" />
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        用户名
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c2"><nobr><%# Eval("UserName") %></nobr></div>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="75px" />
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        真实姓名
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c3"><nobr><%# Eval("RealName")%></nobr></div>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="60px" />
                                </asp:TemplateField>    
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        公司名称
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c4"><nobr><%# Eval("CompanyName")%></nobr></div>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="232px" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        电话
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c5"><nobr>固: <%# Eval("Phone")%></nobr></div>
                                        <div class="c5"><nobr>移: <%# Eval("MovePhone")%>&nbsp;</nobr></div>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="110px" />
                                </asp:TemplateField>
                          
                               <asp:TemplateField>
                                    <HeaderTemplate>
                                        注册时间
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Convert.ToDateTime(Eval("Regtime")).ToString("yyyy-MM-dd")%><BR/>
                                        <%# Convert.ToDateTime(Eval("Regtime")).ToString("HH:mm:ss")%>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>   
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        人员
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Eval("importer") %>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                
                               <asp:TemplateField>
                                    <HeaderTemplate>
                                        编辑
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <a href="../useredit.aspx?id=<%# Eval("UserID") %>"><img src="/admin/images/edit.gif" border=0 /></a> 
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