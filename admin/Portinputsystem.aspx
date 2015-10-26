<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Portinputsystem.aspx.cs" Inherits="admin_userlist"  ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="css/master.css" rel="stylesheet" type="text/css" />
    <link href="css/userlist.css" rel="stylesheet" type="text/css" />
    <script language=javascript src=js/function.js></script>
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
					<div class="text">船期服务</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">港口</div>
				</div>
	            
	            <div class="rightArea txth22">
	                
                    
                    <div class="listTable" style="border:1px solid #D9D9D9; margin:0px 10px 10px 0px; padding:10px 10px; width:758px">
                        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value="1">目的港</asp:ListItem>
                        <asp:ListItem Value="0">启运港</asp:ListItem>
                        </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
                        
                        港口名(中)：<input id="strPortcn" type="text" runat="server" style="width: 80px" />&nbsp;&nbsp;&nbsp;&nbsp;
                        港口名(英)：<input id="strPorten" type="text" runat="server" style="width: 80px" />&nbsp;&nbsp;&nbsp;&nbsp;
                        代号：<input id="strID" type="text" runat="server" style="width: 80px" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <%--国家：<input id="strcountry" type="text" runat="server" style="width: 80px;color:Gray; background-color:Gray" readonly="readonly" />&nbsp;&nbsp;&nbsp;&nbsp;--%>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                        启运港：<asp:DropDownList ID="DropDownList3" runat="server" >
                        <asp:ListItem Value="0">请选择</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        </asp:PlaceHolder>
                        
                        <asp:Button  ID="Button1" runat="server" Text="增加" OnClick="Button1_Click" />
                    </div>
                    
                    
                    
                    <div class="listTable" style="border:1px solid #D9D9D9; margin:0px 10px 10px 0px; padding:10px 10px; width:758px">
                        <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Rows="10">
                        <asp:ListItem Selected="True" Value="">全部</asp:ListItem>
                        </asp:ListBox>
                        <asp:ListBox ID="ListBox3" runat="server" Rows="10" AutoPostBack="True" OnSelectedIndexChanged="ListBox3_SelectedIndexChanged" Width="50px">
                        <asp:ListItem Selected="True" Value="">全部</asp:ListItem>
                        <asp:ListItem Value="A">A</asp:ListItem>
                        <asp:ListItem Value="B">B</asp:ListItem>
                        <asp:ListItem Value="C">C</asp:ListItem>
                        <asp:ListItem Value="D">D</asp:ListItem>
                        <asp:ListItem Value="E">E</asp:ListItem>
                        <asp:ListItem Value="F">F</asp:ListItem>
                        <asp:ListItem Value="G">G</asp:ListItem>
                        <asp:ListItem Value="H">H</asp:ListItem>
                        <asp:ListItem Value="I">I</asp:ListItem>
                        <asp:ListItem Value="J">J</asp:ListItem>
                        <asp:ListItem Value="K">K</asp:ListItem>
                        <asp:ListItem Value="L">L</asp:ListItem>
                        <asp:ListItem Value="M">M</asp:ListItem>
                        <asp:ListItem Value="N">N</asp:ListItem>
                        <asp:ListItem Value="O">O</asp:ListItem>
                        <asp:ListItem Value="P">P</asp:ListItem>
                        <asp:ListItem Value="Q">Q</asp:ListItem>
                        <asp:ListItem Value="R">R</asp:ListItem>
                        <asp:ListItem Value="S">S</asp:ListItem>
                        <asp:ListItem Value="T">T</asp:ListItem>
                        <asp:ListItem Value="U">U</asp:ListItem>
                        <asp:ListItem Value="V">V</asp:ListItem>
                        <asp:ListItem Value="W">W</asp:ListItem>
                        <asp:ListItem Value="X">X</asp:ListItem>
                        <asp:ListItem Value="Y">Y</asp:ListItem>
                        <asp:ListItem Value="Z">Z</asp:ListItem>
                        </asp:ListBox>
                        <asp:ListBox ID="ListBox2" runat="server" Rows="10"></asp:ListBox>
                    </div>
                    
                    <div class="rightArea txth22">
	                <div id="tipBoxSearch" class="tipBox">
	                <table border="0" cellspacing="0" cellpadding="0" height="30px">
	                  <tr>
	                    <td width="80" height="20"><strong>搜索用户：</strong></td>
	                    <td width="35">代号</td>
                        <td width="106px"><asp:TextBox ID="txtID" runat="server" CssClass="t2"></asp:TextBox></td>
	                    <td style="width: 60px">
                            港口名(中)
                        </td>
	                    <td width="110">  
                            <asp:TextBox ID="txtPortcn" runat="server" CssClass="t2"></asp:TextBox>
                        </td>
	                    <td style="width: 60px">
                            港口名(英)</td>
	                    <td style="width: 106px"><asp:TextBox ID="txtPorten" runat="server" CssClass="t2"></asp:TextBox></td>
	                    <td style="width: 35px">
                            类型</td>
	                    <td width="146"><asp:DropDownList ID="DropDownList2" runat="server">
                                <asp:ListItem Selected="True" Value="全部">全部</asp:ListItem>
                                <asp:ListItem Value="1">目的港</asp:ListItem>
                                <asp:ListItem Value="0">启运港</asp:ListItem>
                            </asp:DropDownList></td>
	                    <td style="width: 20px"> </td>
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
                          <asp:Label ID="hidPortcn" runat="server" ></asp:Label>&nbsp;&nbsp;
                          <asp:Label ID="hidPorten" runat="server" ></asp:Label>&nbsp;&nbsp;
                          <asp:Label ID="hidddl" runat="server" ></asp:Label>&nbsp;&nbsp;
                          </strong>
                          &nbsp;，傲赢网共为您找到&nbsp;<strong><asp:Label ID="hidTotalItem" runat="server" ></asp:Label></strong>&nbsp;条记录&nbsp;&nbsp;&nbsp;&nbsp;<span class="edit"><asp:LinkButton ID="lnkShowAll" runat="server" Text="显示所有用户" OnClick="lnkShowAll_Click"></asp:LinkButton></span></div></td>
                        </tr>
                      </table>
                    </asp:Panel>
                    <div class="listTable">
                        <asp:GridView ID="GridView1"  runat="server" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" BorderStyle="Solid" GridLines="Horizontal" OnRowDataBound="GridView1_RowDataBound"
                        OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                  OnRowEditing="GridView1_RowEditing" 
                  OnRowUpdating="GridView1_RowUpdating"
                        >
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
                                        代号
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Eval("numID")%>
                                    </ItemTemplate>  
                                    <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("numID")%>' Width="170px"></asp:TextBox>
                                    </EditItemTemplate>                                              
                                    <ItemStyle Width="170px" />
                                </asp:TemplateField> 
                                 <asp:TemplateField>
                                    <HeaderTemplate>
                                        港口名(中)
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c2" style="width:220px"><nobr><%# Eval("location")%></nobr></div>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="195px" />
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        港口名(英)
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c2" style="width:220px"><nobr><%# Eval("EnglishName")%></nobr></div>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="195px" />
                                </asp:TemplateField> 
                                <%--<asp:TemplateField>
                                    <HeaderTemplate>
                                        国家
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c3"><nobr><%# Eval("countryName")%></nobr></div>
                                    </ItemTemplate>
                                    <ItemStyle Width="60px" />
                                </asp:TemplateField> --%> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        类型
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                    
                                    <%# (Eval("PortLocation").ToString() == "0") ? "<a href=\"Portinputrelasion.aspx?id=" + Eval("id").ToString() + "\">启运港</a>" : "目的港"%>
                                    
					
                                        
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="40px" />
                                </asp:TemplateField> 
                               <asp:TemplateField>
                                    <HeaderTemplate>
                                        删除
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <a href="javascript:delConfirm('<%# Eval("id") %>')"><img src="/admin/images/del.gif" border=0 /></a>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="40px" HorizontalAlign="Center" />
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
                        <input id="Button3" type="button" value="删除选定用户" onclick="delAll()" style="width:100px; height:30px" />
                        <asp:Button ID="btnHidDel" runat="server" Text="Button" CssClass="hidden" OnClick="btnHidDel_Click"/>
                        <asp:TextBox ID="delList" runat="server" CssClass="hidden"></asp:TextBox>
                        <asp:Button ID="btnHidSearch" runat="server" Text="Button" CssClass="hidden" OnClick="btnHidSearch_Click"/>
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
