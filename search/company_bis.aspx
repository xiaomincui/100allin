<%@ Page Language="VB" AutoEventWireup="false" CodeFile="company_bis.aspx.vb" Inherits="search_company_bis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>公司库-环球运费网</title>
    <link href="/css/fcl_css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">


.divexcees {
    text-overflow:ellipsis;
    overflow: hidden;
}

</style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="main_container"><!--页面主体开始-->	
		<usernewtop:usernewtop ID="usernewtop1" runat="server" />
		<div class="menu"><!--导航开始-->
			<h1><userwelcome:userwelcome ID="userwelcome1" runat="server" />您现在的位置:<a href="/" target="_blank">首页</a> > <a href="/company/" >公司库</a> > 贸易公司黄页</h1>
			<userservice:userservice ID="userservice1" runat="server" />
  </div><!--导航结束-->
		<div class="main_content"><!--中部开始-->
			<div class="main_left"><!--左边开始-->
				<div class="search">
					<div class="left_menu_corner"></div>
					
					
					
					
					
					<div class="search_mid">
					
					  <div class="search_bar" style="padding-bottom:10px;"><span class="blue">搜索公司库</span>
					      </span>
					      <asp:TextBox ID="txtDestport" runat="server" CssClass="companyTextbox" Width="430px"></asp:TextBox>
						  
						&nbsp;
						<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/fcl/search.gif" width="111" height="28" border="0" style="margin-bottom:-6px;"   />
						<br /><br />
					  <span class="red">提示： 可在搜索框中输入公司信息的关键词，如 <strong>上海</strong> 或 <strong>聚乙烯</strong> <strong>山东</strong>，用空格分开的关键词，关键词的数量不可大于3个</span></p>
				     </div>
				  </div>
				  
				  
				  
				  
				 
				  
				  
				  
				  
				  
				  
					<div class="right_menu_corner"></div>
				</div>
	
                      
                      
			    <div class="search_tips">
			    <asp:Panel ID="pnlSearchIntro" runat="server" CssClass="hidden">
			    <img src="images/fcl/gt.gif" />
			    &nbsp;环球运费网共为您找到<span class="orange"><asp:Label ID="hidTotalItem" runat="server" ></asp:Label></span>条记录
			    您搜索的是：&nbsp;<asp:Label ID="hidTxtDestport" runat="server" ></asp:Label>
			    
			  </asp:Panel>
			    </div>
			    
			    
			    
				<div class="freight_List">
				  <div class="freight_List_title">
							<h2>公司库列表</h2>
					  </div>
					  <div class="list_box">
					  		<table id="pd" width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CAE7F0">
  <tr>
    <td width="10%" height="38" align="center" bgcolor="#E9F3F8" class="blue">编号</td>
    <td width="20%" align="center" bgcolor="#E9F3F8" class="blue">联系人</td>
    <td width="30%" align="center" bgcolor="#E9F3F8" class="blue">公司名称</td>
    <td width="25%" align="center" bgcolor="#E9F3F8" class="blue">经营范围</td>
    <td width="15%" align="center" bgcolor="#E9F3F8" class="blue">电话</td>
    </tr>
  <asp:Repeater ID="Repeater1" runat="server">
  <ItemTemplate>
  <tr>
    <td height="46" align="center" bgcolor="#FFFFFF"><%# eval("id") %></td>
    <td align="center" bgcolor="#FFFFFF"><%# eval("法人") %></td>
    <td align="center" bgcolor="#FFFFFF"><div class="divexcees" style="width:190px"><nobr><a href="../company/<%# eval("id") %>.html" target="_blank"><span id="Label1"><%#Eval("机构名称")%></span></a></nobr></div></td>
    <td align="center" bgcolor="#FFFFFF"><%#Eval("经营范围")%></td>
    <td align="center" bgcolor="#FFFFFF"><%#Eval("电话")%></td>
    </tr>
  
  </ItemTemplate>
  </asp:Repeater>  
    
  <tr style="HEIGHT: 45px" bgcolor="#FFFFFF">
				    <td colspan="5" align="center"><DIV class=manu><SPAN class=disabled style="margin:0px; padding:0px; line-height:27px; height:27px; border:none; color:#28385A; float:left;">
				    共&nbsp;<strong><asp:Label ID="lblTotalPage" runat="server"  Text="1"></asp:Label></strong>&nbsp;页&nbsp;<strong><asp:Label
                                        ID="lblTotalItem" runat="server" Text="0"></asp:Label></strong>&nbsp;条记录&nbsp;&nbsp;以上是第&nbsp;<strong><asp:Label
                                        ID="lblCurrentPage" runat="server" Text="1"></asp:Label></strong>&nbsp;页
				    
				    </SPAN>
				    <asp:LinkButton ID="lnkFirstPage" runat="server">第一页</asp:LinkButton>
                                            <asp:LinkButton ID="lnkPrePage" runat="server">上一页</asp:LinkButton>
                                            <asp:LinkButton ID="lnkNextPage" runat="server">下一页</asp:LinkButton>
                                            <asp:LinkButton ID="lnkLastPage" runat="server">最后页</asp:LinkButton>
				    <asp:DropDownList ID="ddlPageSelect" runat="server" CssClass="pageDropdown" AutoPostBack="true" Visible="false">
                                    </asp:DropDownList></DIV></td>
  </tr>
			      
  
</table>
					  </div>
				</div>

				 <usernewsbottom:usernewsbottom ID="usernewsbottom1" runat="server" />
			</div><!--左边结束-->	
			<div class="main_right"><!--右边开始-->
			  <div class="right_box" style="margin-top:0px;">
					<div class="right_box_title"><h2>您浏览过的运价有</h2>
					</div>
					<ul>
					<asp:Label ID="Label24" runat="server" Text=""></asp:Label>
					</ul>
				</div>
				<div class="right_box" >
					<div class="right_box_title"><h2>您搜索过的运价有</h2>
					</div>
					<ul>
                         <asp:Label ID="Label23" runat="server" Text=""></asp:Label>
                    </ul>
				</div>
				<userrate2:userrate2 ID="userrate22" runat="server" />
				<usertranslate2:usertranslate2 ID="usertranslate22" runat="server" />
			</div><!--右边结束-->		
  		</div>
<userbottomline:userbottomline ID="userbottomline1" runat="server" />
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
    </form>
</body>
</html>
