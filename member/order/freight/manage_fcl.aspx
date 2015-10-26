<%@ Page Language="VB" AutoEventWireup="false" CodeFile="manage_fcl.aspx.vb" Inherits="pro_freight_manage_fcl" EnableEventValidation="false" EnableViewState="false"%><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="content-type" content="text/html; charset=UTF-8" />
<title>整箱运价发布</title>
<link href="../order/css/master.css" rel="stylesheet" type="text/css" />
<link href="../order/css/userlist.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="/js/function.js"></script>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div id="page">
<div id="center">
<protop:protop ID="protop1" runat="server" />
<div id="main">
<proleft:proleft ID="proleft1" runat="server" />										
<div id="right">
<div class="tt18 bd rightTitle">
<div class="text"><asp:Literal ID="ltrHeadTitle" runat="server"></asp:Literal></div>
</div>
<div class="rightArea txth22">
	<div id="tipBoxSearch" class="tipBox underline">
	<table border="0" cellspacing="0" cellpadding="0">
	  <tr>
	    <td width="137" height="20"><div>搜索我的整箱运价：</div></td>
	    <td width="35">编号</td>
        <td width="70"><asp:TextBox ID="txtYunjiaid" runat="server" Width="50px"></asp:TextBox></td>
	    <td width="35">航线</td>
	    <td width="110">
            <asp:DropDownList ID="txtLine" runat="server" Width=85 Font-Size="12px">
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
            </asp:DropDownList>
        </td>
	    <td width="45">启运港</td>
	    <td width="110"><asp:TextBox ID="txtStartport" runat="server" Width="100px"></asp:TextBox></td>
	    <td width="45">目的港</td>
	    <td width="110"><asp:TextBox ID="txtDestport" runat="server" Width="100px"></asp:TextBox></td>
	    <td width="28"><input type="button" name="Submit" value="搜索" onclick="sendSeacch()" /></td>
	  </tr>
	</table>
	</div>
    <asp:Panel ID="pnlSearchIntro" runat="server" CssClass="hidden">
      <table border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="200px">搜索结果：&nbsp;</td>
          <td width="570px"><div style="text-align:right;">您搜索的是：&nbsp;<strong><asp:Label ID="hidTxtYunjiaid" runat="server">
          </asp:Label>&nbsp;&nbsp;<asp:Label ID="hidTxtLine" runat="server" >
          </asp:Label>&nbsp;&nbsp;<asp:Label ID="hidTxtStartport" runat="server" >
          </asp:Label>&nbsp;&nbsp;<asp:Label ID="hidTxtDestport" runat="server" >
          </asp:Label></strong>&nbsp;，环球运费网共为您找到&nbsp;<strong><asp:Label ID="hidTotalItem" runat="server" ></asp:Label></strong>&nbsp;条记录&nbsp;&nbsp;&nbsp;&nbsp;<span class="edit"><asp:LinkButton ID="lnkShowAll" runat="server" Text="显示我所有的整箱运价"></asp:LinkButton></span></div></td>
        </tr>
      </table>
      </asp:Panel>
	<div class="listTable">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" name="chkAll" type="checkbox" onclick="CheckAll(this.form);" />
                </HeaderTemplate>
                <ItemTemplate>
                    <input id="id" type="checkbox" value="<%# eval("id") %>" onclick="checkToList(this.form)" />
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#333333" HorizontalAlign="Center" Width="30px" />
                <ItemStyle HorizontalAlign="Center" Width="30px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="编号">
                <ItemTemplate>
                    <a href="/fcl/<%# key(eval("id")) %>_0.html" target="_blank"><div class="idText"><asp:Label ID="Label1" runat="server" Text='<%# eval("id") %>'></asp:Label></a>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#333333" HorizontalAlign="Center" Width="60px" />
                <ItemStyle HorizontalAlign="Left" Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="启运港">
                <ItemTemplate>
                    <a href="/fcl/<%# key(eval("id")) %>_0.html" target="_blank"><div class="startPortText"><nobr><asp:Label ID="Label2" runat="server" Text='<%# eval("startport") %>'></asp:Label></a>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#333333" HorizontalAlign="Center" Width="90px" />
                <ItemStyle HorizontalAlign="Left" Width="90px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="标题">
                <ItemTemplate>
                    <a href="/fcl/<%# key(eval("id")) %>_0.html" target="_blank"><div class="titleText"><nobr><asp:Label ID="Label3" runat="server" Text='<%# eval("title") %>'></asp:Label></a>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#333333" HorizontalAlign="Center" Width="270px" />
                <ItemStyle HorizontalAlign="Left" Width="270px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="航线">
                <ItemTemplate>
                    <a href="/fcl/<%# key(eval("id")) %>_0.html" target="_blank"><div class="dateText"><asp:Label ID="Label4" runat="server" Text='<%# eval("hangxianmiaoshu") %>'></asp:Label></a>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#333333" HorizontalAlign="Center" Width="75px" />
                <ItemStyle HorizontalAlign="Left" Width="75px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发布日期">
                <ItemTemplate>
                    <a href="/fcl/<%# key(eval("id")) %>_0.html" target="_blank"><div class="dateText"><asp:Label ID="Label5" runat="server" Text='<%# FORMAT(eval("postdate"),"yyyy-MM-dd").tostring  %>'></asp:Label></a>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#333333" HorizontalAlign="Center" Width="75px" />
                <ItemStyle HorizontalAlign="Left" Width="75px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="截止日期">
                <ItemTemplate>
                    <a href="/fcl/<%# key(eval("id")) %>_0.html" target="_blank"><div class="dateText"><asp:Label ID="Label6" runat="server" Text='<%# IIF ((FORMAT(NOW(),"yyyy-MM-dd").tostring > eval("enddate")) ,"<span style=""color:#FF0000;"">" & eval("enddate") & "</span>",eval("enddate"))%>'></asp:Label></a>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#333333" HorizontalAlign="Center" Width="75px" />
                <ItemStyle HorizontalAlign="Left" Width="75px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <div class="edit"><a href="edit_fcl.aspx?id=<%# eval("id") %>">编辑</a>&nbsp;&nbsp;<a href="javascript:delConfirm('<%# eval("id") %>')">删除</a></div>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" ForeColor="#333333" HorizontalAlign="Center" Width="80px" />
                <ItemStyle HorizontalAlign="Center" Width="80px" />
            </asp:TemplateField>                                                     
        </Columns>
        <HeaderStyle BackColor="#F9F9F9" Height="30px" />
        <RowStyle Height="30px"  />
    </asp:GridView>
	</div>
	<div class="page"><div class="pageCount">共&nbsp;<strong><asp:Label ID="lblTotalPage" runat="server"  Text="1"></asp:Label></strong>&nbsp;页&nbsp;<strong><asp:Label
            ID="lblTotalItem" runat="server" Text="0"></asp:Label></strong>&nbsp;条记录&nbsp;&nbsp;以上是第&nbsp;<strong><asp:Label
            ID="lblCurrentPage" runat="server" Text="1"></asp:Label></strong>&nbsp;页</div><div class="pageControl">
                <asp:LinkButton ID="lnkFirstPage" runat="server">第一页</asp:LinkButton>
                <asp:LinkButton ID="lnkPrePage" runat="server">上一页</asp:LinkButton>
                <asp:LinkButton ID="lnkNextPage" runat="server">下一页</asp:LinkButton>
                <asp:LinkButton ID="lnkLastPage" runat="server">最后页</asp:LinkButton>
                </div>
	<div class="pageText">直接翻页：</div>
	<div class="pageSelect">
        <asp:DropDownList ID="ddlPageSelect" runat="server" CssClass="pageDropdown" AutoPostBack="true">
        </asp:DropDownList>
	  </div>
	</div>
    <div class="listTable"><input id="Button1" type="button" value="删除选定运价" onclick="delAll()" style="width:100px; height:30px" />
        <asp:Button ID="btnHidDel" runat="server" Text="Button" CssClass="hidden"/>
        <asp:TextBox ID="delList" runat="server" CssClass="hidden"></asp:TextBox>
        <asp:Button ID="btnHidSearch" runat="server" Text="Button" CssClass="hidden"/>
	</div>
			

</div>
</div>
</div>
<probottom:probottom ID="probottom1" runat="server" />
</div>
</div>


</form>
</body>
</html>
