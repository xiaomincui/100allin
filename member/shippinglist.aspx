<%@ Page Language="VB" AutoEventWireup="false" CodeFile="shippinglist.aspx.vb" Inherits="member_shippinglist1" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>我的整箱运价</title>
    <link href="css/offices.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="js/function1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main_container">
		<memberheader:memberheader ID="memberheader1" runat="server" />
		<div class="center">
			<memberleft:memberleft ID="memberleft1" runat="server" />	
		  <div class="main">
				<memberwelcome:memberwelcome ID="memberwelcome1" runat="server" />
				<div class="fcl_tit"><table width="100%" border="0" cellspacing="1" cellpadding="0">
  <tr>
    <td width="6%" align="center"><img src="images/edit_icon.gif" /></td>
    <td width="44%"><strong>我的整箱运价</strong></td>
    <td width="50%" align="right"><a href="/member/Release.aspx"><img src="images/ttt2.gif" border="0" /></a></td>
  </tr>
</table>
</div>
				<div class="bill_box" style="line-height:18px; background:#FFFBCA; border:1px dashed #FFCC00; margin-top:8px;">
			    <p style="margin:0px 15px;">&nbsp;&nbsp;&nbsp;搜索我的整箱运价：&nbsp;编号
			      <asp:TextBox ID="txtYunjiaid" runat="server" CssClass="shortTextbox" Width="51px"></asp:TextBox>
			    航线
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
			    起运港
			    <asp:TextBox ID="txtStartport" runat="server" CssClass="bigTextbox" Width="100px"></asp:TextBox>
			    目的港
			    <asp:TextBox ID="txtDestport" runat="server" CssClass="bigTextbox"  Width="100px"></asp:TextBox>
			    <input type="button" name="Submit" value="搜索" onclick="sendSeacch()" />
			    </p>
			</div>
			<div><asp:Panel ID="pnlSearchIntro" runat="server" CssClass="hidden">
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
      </asp:Panel></div>
			<div class="fcl" style="padding:0px;">
			  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                  <td width="2%" height="28" align="center"><input type="checkbox" name="chkAll" value="checkbox"  onclick="CheckAll(this.form);"  /></td>
                  <td width="10%" height="32" align="center"><strong>编号</strong></td>
                  <td width="11%" align="center"><strong>起运港</strong></td>
                  <td width="35%" align="center"><strong>标题</strong></td>
                  <td width="11%" align="center"><strong>航线</strong></td>
                  <td width="10%" align="center"><strong>发布日期</strong></td>
                  <td width="10%" align="center"><strong>截止日期</strong></td>
                  <td width="11%" align="center"><strong>操作</strong></td>
                </tr>
                  
                  <asp:Repeater ID="Repeater1" runat="server">
                  <ItemTemplate>
                  <tr>
                  <td height="28" align="center" bgcolor="#FFFFFF"><input id="id" type="checkbox" value="<%# eval("id") %>" onclick="checkToList(this.form)" /></td>
                  <td height="32" align="center" bgcolor="#FFFFFF"><asp:Label ID="Label1" runat="server" Text='<%# eval("id") %>'></asp:Label></td>
                  <td align="center" bgcolor="#FFFFFF"><div class="startPortText"><nobr><asp:Label ID="Label2" runat="server" Text='<%# eval("startport") %>'></asp:Label></nobr></div></td>
                  <td align="center" bgcolor="#FFFFFF"><div class="titleText"><nobr><a href="/fcl/<%# key(eval("id")) %>_0.html" target="_blank"><strong><asp:Label ID="Label3" runat="server" Text='<%# eval("title") %>'></asp:Label></strong></a></nobr></div></td>
                  <td align="center" bgcolor="#FFFFFF"><div class="dateText"><asp:Label ID="Label4" runat="server" Text='<%# eval("hangxianmiaoshu") %>'></asp:Label></div></td>
                  <td align="center" bgcolor="#FFFFFF"><div class="dateText"><asp:Label ID="Label5" runat="server" Text='<%# FORMAT(eval("postdate"),"yyyy-MM-dd").tostring  %>'></asp:Label></div></td>
                  <td align="center" bgcolor="#FFFFFF"><div class="dateText"><asp:Label ID="Label6" runat="server" Text='<%# IIF ((FORMAT(NOW(),"yyyy-MM-dd").tostring > eval("enddate")) ,"<span style=""color:#FF0000;"">" & eval("enddate") & "</span>",eval("enddate"))%>'></asp:Label></div></td>
                  <td align="center" bgcolor="#FFFFFF"><div class="edit"><a href="jilu.aspx?id=<%# eval("id") %>">编辑</a>&nbsp;&nbsp;<a href="javascript:delConfirm('<%# eval("id") %>')">删除</a></div></td>
                </tr>
                  </ItemTemplate>
                  </asp:Repeater>
			  
                
				<tr>
				  <td height="32" colspan="8" align="center" bgcolor="#E8F6FF">
				  
				  <table width="100%" height="32" border="0" cellpadding="0" cellspacing="5">
                    <tr>
                      <td width="35%" align="left">共 <strong><asp:Label ID="lblTotalPage" runat="server"  Text="1"></asp:Label></strong>页<strong>
                      <asp:Label ID="lblTotalItem" runat="server" Text="0"></asp:Label></strong>条记录 &nbsp;以上是第 <strong><asp:Label
            ID="lblCurrentPage" runat="server" Text="1"></asp:Label></strong>页</td>
                      <td width="40%" align="left"><asp:LinkButton ID="lnkFirstPage" runat="server">第一页</asp:LinkButton>
                      &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkPrePage" runat="server">上一页</asp:LinkButton>
                      &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkNextPage" runat="server">下一页</asp:LinkButton>
                      &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkLastPage" runat="server">最后页</asp:LinkButton></td>
                      <td align="center">直接翻页：
                          <asp:DropDownList ID="ddlPageSelect" runat="server" CssClass="pageDropdown" AutoPostBack="true"></asp:DropDownList>                      </td>
                    </tr>
                  </table>
                  
                
                
                
                  
                  </td>
			    </tr>
			    <tr>
				  <td height="32" colspan="8" bgcolor="#E8F6FF">
				  <div class="listTable">
				  <input id="Button1" type="button" value="删除选定运价" onclick="delAll()" style="width:100px; height:30px" />
				   <input id="Button2" type="button" value="更新选定运价" onclick="updateAll()" style="width:100px; height:30px" />
        <asp:Button ID="btnHidDel" runat="server" Text="Button" CssClass="hidden"/>
        <asp:Button ID="btnHidUpdate" runat="server" Text="Button" CssClass="hidden"/>
        <asp:TextBox ID="delList" runat="server" CssClass="hidden"></asp:TextBox>
        <asp:Button ID="btnHidSearch" runat="server" Text="Button" CssClass="hidden"/>
	</div>
	
				  </td>
			    </tr>
              </table>
              
              
			</div>
		  </div>
		</div>
		<memberfooter:memberfooter ID="memberfooter1" runat="server" />
	</div>
    </form>
</body>
</html>
