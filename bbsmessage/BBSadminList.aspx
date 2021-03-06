﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BBSadminList.aspx.cs" Inherits="admin_userlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="../admin/css/master.css" rel="stylesheet" type="text/css" />
    <link href="../admin/css/userlist.css" rel="stylesheet" type="text/css" />
    <script language=javascript src=../admin/js/function.js></script>    
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
<!--

-->
</style>

<script language="javascript">
function delConfirmbbs(id) 
{
	document.getElementById("delList").value = id;
	var delQus;
	delQus=confirm('真的要确认吗？');
	if (delQus==true){
		document.getElementById("btnHidDelbbs").click();
	}else{
		checkToList(document.getElementById('form1'));
	}	
}

function delAllbbs() {
	var delQus;
	delQus=confirm('真的要确认吗？');
	if (delQus==true){
		document.getElementById("btnHidDelbbs").click();
	}else{
		
	}	
}
</script>  
</head>
<body>
<form id="form1" runat="server">
    <div id="page">
		<div id="center">
			<bbsadmintop:bbsadmintop id="bbsadmintop1" runat="server" />
			<bbsadminmenu:bbsadminmenu id="bbsadminmenu1" runat="server" />
		  <div id="main">
			<bbsadminleft:bbsadminleft id="bbsadminleft1" runat="server" />												
		  	<div id="right">
				<div class="tt18 bd rightTitle">
					<div class="text">用户管理</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">用户编辑</div>
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
                            回复人</td>
	                    <td style="width: 100px"><asp:TextBox ID="txtDestport" runat="server" CssClass="t3" Width="90px"></asp:TextBox></td>
                          <td style="width: 38px">
                              板块</td>
                          <td style="width: 95px">
                              <asp:DropDownList ID="DropDownList1" runat="server">
                                  <asp:ListItem Selected="True"></asp:ListItem>
                                  <asp:ListItem Value="1">货主天地</asp:ListItem>
                                  <asp:ListItem Value="2">货代之家</asp:ListItem>
                                  <asp:ListItem Value="3">谈天说地</asp:ListItem>
<asp:ListItem Value="6">紧急询价</asp:ListItem>
                                  <asp:ListItem  Value="7">公司优势展示</asp:ListItem>
                                  <asp:ListItem Value="4">网站公告区</asp:ListItem>
                              </asp:DropDownList></td>
	                    <td width="20"><input type="button" name="Submit" value="搜索" onclick="sendSeacch()" id="Button2" /></td>
	                  </tr>
	                </table>
	                </div>
	                
	                <div class="tipBox">
                        操作备注（必填）：
                        <asp:TextBox ID="txtMeno" runat="server" Height="42px" TextMode="MultiLine" Width="746px"></asp:TextBox>
	                </div>
	                
	                <div class="tipBox">
                        发送给客户（删除必填）：
                        <asp:TextBox ID="txtdelete" runat="server" Height="42px" TextMode="MultiLine" Width="746px"></asp:TextBox>
	                </div>
	                
	                
	                
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
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        置顶
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckbtop" runat="server" Checked='<%# (Convert.ToInt32(Eval("istop").ToString()) == 0) ? false:true%>' AutoPostBack="True" OnCheckedChanged="ckbtop_CheckedChanged" />
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
                                <div class="c6" style=" width:140px;	overflow: hidden; 	text-overflow:ellipsis;padding-left:20px">
                                <nobr><a href='BBSadminMessage.aspx?id=<%# Eval("id")%>'>
                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("title") %>'></asp:Label></a></nobr>
                                </div>
                                </ItemTemplate>
                                
                                <ItemStyle Width="140px" />
                                <HeaderTemplate>
                                    <div style=" padding-left:20px">标题</div>
                                </HeaderTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="板块">
                                <ItemTemplate>
                                
                                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="80px">
                                  <asp:ListItem   Value="1">货主天地</asp:ListItem>
                                  <asp:ListItem Value="2">货代之家</asp:ListItem>
                                  <asp:ListItem  Value="3">谈天说地</asp:ListItem>
<asp:ListItem Value="6">紧急询价</asp:ListItem>
                                  <asp:ListItem  Value="7">公司优势展示</asp:ListItem>
                                  <asp:ListItem  Value="4">网站公告区</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发帖人">
                                <ItemTemplate>
                                
                                    <div class="c7"><nobr><asp:Label ID="Label3" runat="server" Text='<%# Eval("releasename") %>'></asp:Label></nobr></div>
                                    <div class="c7"><nobr><asp:Label ID="Label5" runat="server" Text='<%# Eval("PostDate") %>'></asp:Label></nobr></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="回帖数">
                                <ItemTemplate>
                                    <asp:Label ID="Label15" runat="server" Text='<%# Eval("message") %>'></asp:Label>/
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("hits") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="回复人">
                                <ItemTemplate>
                                    <div class="c7"><nobr><asp:Label ID="Label25" runat="server" Text='<%# (Eval("restorename").ToString() != "" ) ? Eval("restorename"):"无" %>'></asp:Label></nobr></div>
                                    <div class="c7"><nobr><asp:Label ID="Label4" runat="server" Text='<%# (Eval("restorename").ToString() != "" ) ? Eval("UpdateDate"):"" %>'></asp:Label></nobr></div>
                                </ItemTemplate>
                            </asp:TemplateField>






                                                                                                                                                                                       
                               <asp:TemplateField>
                                    <HeaderTemplate>
                                        确定
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Convert.ToBoolean(Eval("displaySign")) ? "" : "<a href=\"javascript:delConfirmbbs('" + Eval("id") + "')\"><img src=\"/admin/images/edit.gif\" border=0 /></a>"%>
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
                        <input id="Button1" type="button" value="删除选定帖子" onclick="delAll()" style="width:100px; height:30px" />
                        <input id="Button3" type="button" value="确定选定帖子" onclick="delAllbbs()" style="width:100px; height:30px" />
                        <asp:Button ID="btnHidDel" runat="server" Text="Button" CssClass="hidden" OnClick="btnHidDel_Click"/>
                        <asp:Button ID="btnHidDelbbs" runat="server" Text="Button" CssClass="hidden" OnClick="btnHidDelbbs_Click" />
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
