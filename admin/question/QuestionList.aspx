﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuestionList.aspx.cs" Inherits="admin_userlist" %>

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
.c7 {
	width:130px;
	overflow: hidden; 
	text-overflow:ellipsis;
}
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
					<div class="text">问答管理</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">问题列表</div>
				</div>	
				<div class="rightArea txth22">
	                <div class="tipBox">
	                <table border="0" cellspacing="0" cellpadding="0">
	                  <tr>
	                    <td width="80" height="20"><strong>搜索用户：</strong></td>
	                    <td width="35">编号</td>
                        <td style="width: 49px"><asp:TextBox ID="txtYunjiaid" runat="server" CssClass="t1"></asp:TextBox></td>
	                    <td style="width: 34px">
                            标题
                        </td>
	                    <td style="width: 92px">  
                            <asp:TextBox ID="txtLine" runat="server" CssClass="t2"></asp:TextBox>
                        </td>
	                    <td style="width: 40px">
                            发布人</td>
	                    <td style="width: 90px"><asp:TextBox ID="txtStartport" runat="server" CssClass="t2"></asp:TextBox></td>
	                    <td style="width: 39px">
                            板块</td>
	                    <td style="width: 100px"><asp:DropDownList ID="DropDownList3" runat="server">
                                  <asp:ListItem Value="" Selected="True">全部</asp:ListItem>
                                  <asp:ListItem Value="1">海运类</asp:ListItem>
                                    <asp:ListItem Value="2">空运类</asp:ListItem>
                                    <asp:ListItem Value="3">贸易类</asp:ListItem>
                                    <asp:ListItem Value="4">其他</asp:ListItem>
                              </asp:DropDownList></td>
                          <td style="width: 38px">
                              状态</td>
                          <td style="width: 95px">
                              <asp:DropDownList ID="DropDownList1" runat="server">
                                  <asp:ListItem Value="" Selected="True"></asp:ListItem>
                                  <asp:ListItem   Value="1">已解决</asp:ListItem>
                                  <asp:ListItem Value="2">已过期</asp:ListItem>
                                  <asp:ListItem  Value="3">未解决</asp:ListItem>
                              </asp:DropDownList></td>
	                    <td width="20"><input type="button" name="Submit" value="搜索" onclick="sendSeacch()" id="Button2" /></td>
	                  </tr>
	                </table>
	                </div>
	                <div><a href="QuestionList.aspx">问题列表</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="AnswerList.aspx">所有回答</a></div>
                    <asp:Panel ID="pnlSearchIntro" runat="server" CssClass="hidden">
                      <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                          <td width="200px" >&nbsp;&nbsp;&nbsp;&nbsp;搜索结果：&nbsp;</td>
                          <td width="570px"><div style="text-align:right;">您搜索的是：&nbsp;<strong><asp:Label ID="hidTxtYunjiaid" runat="server">
                          </asp:Label>&nbsp;&nbsp;<asp:Label ID="hidTxtLine" runat="server" >
                          </asp:Label>&nbsp;&nbsp;<asp:Label ID="hidTxtStartport" runat="server" >
                          </asp:Label>&nbsp;&nbsp;<asp:Label ID="hidTxtDestport" runat="server" >
                          </asp:Label>&nbsp;&nbsp;<asp:Label ID="hidTxtType" runat="server" >
                          </asp:Label></strong>&nbsp;，傲赢网共为您找到&nbsp;<strong><asp:Label ID="hidTotalItem" runat="server" ></asp:Label></strong>&nbsp;条记录&nbsp;&nbsp;&nbsp;&nbsp;<span class="edit"><asp:LinkButton ID="lnkShowAll" runat="server" Text="显示所有用户" OnClick="lnkShowAll_Click"></asp:LinkButton></span></div></td>
                        </tr>
                      </table>
                    </asp:Panel>
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
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <input id="chkAll" name="chkAll" type="checkbox" onclick="CheckAll(this.form);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input id="id" type="checkbox" value="<%# Eval("id") %>" onclick="checkToList(this.form)" />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
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
                                <div class="c6" style=" width:170px;	overflow: hidden; 	text-overflow:ellipsis;padding-left:20px">
                                <nobr><a href='/question/<%# Eval("id")%>.html'>
                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("title") %>'></asp:Label></a></nobr>
                                </div>
                                </ItemTemplate>
                                
                                <ItemStyle Width="170px" />
                                <HeaderTemplate>
                                    <div style=" padding-left:20px">标题</div>
                                </HeaderTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="板块">
                                <ItemTemplate>
                                
                                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                  <asp:ListItem Value="1">海运类</asp:ListItem>
                                    <asp:ListItem Value="2">空运类</asp:ListItem>
                                    <asp:ListItem Value="3">贸易类</asp:ListItem>
                                    <asp:ListItem Value="4">其他</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发帖人/发帖时间">
                                <ItemTemplate>
                                
                                    <div class="c7"><nobr><asp:Label ID="Label3" runat="server" Text='<%# Eval("RealName") %>'></asp:Label></nobr></div>
                                    <div class="c7"><nobr><asp:Label ID="Label5" runat="server" Text='<%# Eval("postdate") %>'></asp:Label></nobr></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="过期时间/回帖数">
                                <ItemTemplate>
                                    <%#
                                        Convert.ToInt16(Eval("answer")) == 0 ? "<span style=\"color:Red\">" + Eval("overdue") + "/" + Eval("answer") + "</span>" :
                                        Convert.ToDateTime(Eval("overdue")) < DateTime.Now && Eval("best_answer").ToString() == "" ? "<span style=\"color:Green\">" + Eval("overdue") + "</span>" : Eval("overdue")%>
                                    
                                    <%--<asp:Label ID="Label15" runat="server" Text='<%# Eval("overdue") %>'></asp:Label>--%>/
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("answer") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            






                                                                                                                                                                                       
                               <asp:TemplateField>
                                    <HeaderTemplate>
                                        编辑
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <a href='QuestionAnswer.aspx?id=<%# Eval("id")%>'><img src="/admin/images/edit.gif" border=0 /></a> 
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
