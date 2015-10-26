<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BBSListExhibition.aspx.cs" Inherits="message_BBSListtype" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>商务服务--环球运费网</title>
    <link href="/css/fcl_css.css" rel="stylesheet" type="text/css" />
        <style type="text/css">

.hidden {
	display:none;
}
.divexcees {
    text-overflow:ellipsis;
    overflow: hidden;
}

.divexcees a:link {
	color: #293B5E;
	text-decoration: underline;
}
.divexcees a:visited {
	text-decoration: underline;
	color: #293B5E;
}
.divexcees a:hover {
	text-decoration: underline;
	color: #FF6600;
}
.divexcees a:active {
	text-decoration: underline;
	color: #293B5E;
}
.hidden {
    display:none;
}
</style>
    
</head>
<body>
    <form id="form1" runat="server">
    <div class="main_container"><!--页面主体开始-->	
		<usernewtop:usernewtop ID="usernewtop1" runat="server" />
		<div class="menu"><!--导航开始-->
			<h1><userwelcome:userwelcome ID="userwelcome1" runat="server" />
			您现在的位置:<a href="/" target="_blank">首页</a> > <a href="/message/BBSListExhibition.aspx" target="_blank">商务服务</a></h1>
			<userservice:userservice ID="userservice1" runat="server" />
		</div><!--导航结束-->
		<div class="main_content"><!--中部开始-->
			<div class="main_left"><!--左边开始-->
			  <table width="100%" border="1" cellspacing="0" 
bordercolor="#9EBCDE" rules="rows" id="GridView1" style="WIDTH:742px; BORDER-COLLAPSE: collapse">
                <tbody>
				<tr>
                    <td height="28" colspan="3" align="left" background="images/bbs/bbs_bg.gif">&nbsp;&nbsp;<a href="BBSList.aspx" class="blue bold"><asp:Label ID="Label6" runat="server" Text="论坛首页"></asp:Label></a>
                    ><span class="blue"><asp:Label ID="labtypes" runat="server" Text=""></asp:Label></span></td>
                  </tr>
					                  <tr style="HEIGHT: 20px; BACKGROUND-COLOR: #f2f8fb">
                    <th width="39" align="center" scope="col" style="height: 20px">&nbsp;</th>
                    <th width="536" scope="col" style="height: 20px">标题</th>
                    <th width="200" align="center" scope="col" style="height: 20px;">时间</th>
                  </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                    <tr style="HEIGHT: 45px">
                    <td width="39" align="center"></td>
                    <td width="490" style="WIDTH: 360px" class="blue"><a href='Exhibition.aspx?id=<%# Eval("id")%>'><%# Eval("title") %></a></td>
                    <td width="246" align="center"><div class="c1"><NOBR><%# Eval("PostDate") %></NOBR></div></td>
                  </tr>
                    
                    
                    </ItemTemplate>
                    </asp:Repeater>
                  <tr style="HEIGHT: 45px" bgcolor="#FFFFFF">
				    <td colspan="3" align="center"><DIV class=manu><SPAN class=disabled style="margin:0px; padding:0px; line-height:27px; height:27px; border:none; color:#28385A; float:left;">
				    共&nbsp;<strong><asp:Label ID="lblTotalPage" runat="server"  Text="1"></asp:Label></strong>&nbsp;页&nbsp;<strong><asp:Label
                                        ID="lblTotalItem" runat="server" Text="0"></asp:Label></strong>&nbsp;条记录&nbsp;&nbsp;以上是第&nbsp;<strong><asp:Label
                                        ID="lblCurrentPage" runat="server" Text="1"></asp:Label></strong>&nbsp;页
				    
				    </SPAN>
				    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lnkFirstPage_Click">第一页</asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lnkPrePage_Click">上一页</asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="lnkNextPage_Click">下一页</asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="lnkLastPage_Click">最后页</asp:LinkButton>
                                            <asp:Label ID="hidSaveSearchWords" runat="server" CssClass="hidden" Text="1"></asp:Label>
				    <asp:DropDownList ID="ddlPageSelect" runat="server" CssClass="pageDropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSelect_SelectedIndexChanged" >
                                    </asp:DropDownList></DIV></td>
  </tr>
                  
				 
			    </tbody>
		      </table>
		      <%--<table border="0" cellpadding="0" cellspacing="0" style="   float: left">
                        <tr>
                            <td width="10">
                                <img height="31" src="../images/box_7_2.gif" width="10" /></td>
                            <td background="../images/box_8_2.gif" width="780">
                                <div class="page" style="float: left">
                                    <div class="pageCount">
                            共 <strong>
                                            <asp:Label ID="lblTotalPage" runat="server" Text="1"></asp:Label></strong> 页
                                        <strong>
                                            <asp:Label ID="lblTotalItem" runat="server" Text="0"></asp:Label></strong> 条记录
                            &nbsp; 以上是第 <strong>
                                            <asp:Label ID="lblCurrentPage" runat="server" Text="1"></asp:Label></strong>
                                        页</div>
                                    <div class="pageControl">
                                        <asp:LinkButton ID="lnkFirstPage" runat="server" OnClick="lnkFirstPage_Click">第一页</asp:LinkButton>
                                        <asp:LinkButton ID="lnkPrePage" runat="server" OnClick="lnkPrePage_Click">上一页</asp:LinkButton>
                                        <asp:LinkButton ID="lnkNextPage" runat="server" OnClick="lnkNextPage_Click">下一页</asp:LinkButton>
                                        <asp:LinkButton ID="lnkLastPage" runat="server" OnClick="lnkLastPage_Click">最后页</asp:LinkButton>
                                        <asp:Label ID="hidSaveSearchWords" runat="server" CssClass="hidden" Text="1"></asp:Label>
                                    </div>
                                    <div class="pageText">
                            直接翻页：</div>
                                    <div class="pageSelect">
                                        <asp:DropDownList ID="ddlPageSelect" runat="server" AutoPostBack="true" CssClass="pageDropdown"
                                            OnSelectedIndexChanged="ddlPageSelect_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </td>
                            <td width="10">
                                <img height="31" src="../images/box_9_2.gif" width="10" /></td>
                        </tr>
                    </table>--%>
		  </div>
			<!--左边结束-->	
			<div class="main_right"><!--右边开始-->
			  <div class="right_box">
					<div class="right_box_title"><h2>您浏览过的运价有</h2>
					</div>
					<ul>
					<asp:Label ID="Label22" runat="server" Text=""></asp:Label>
					</ul>
				</div>
				<div class="right_box">
					<div class="right_box_title"><h2>您搜索过的港口有</h2>
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
