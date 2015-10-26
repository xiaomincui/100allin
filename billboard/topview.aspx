<%@ Page Language="C#" AutoEventWireup="true" CodeFile="topview.aspx.cs" Inherits="billboard_topview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="/css/top.css" rel="stylesheet" type="text/css" />
<style type="text/css">


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
</style> 
</head>

<body>
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="main"><!--页面主体开始-->	
    <usernewtop1209:usernewtop1209 ID="usernewtop12091" runat="server" />
		<div class="menu_end">
			<h1><a href="/">首页</a> &gt; <a href="/news/1/2/list.html">航运动态</a> &gt; <asp:Label ID="Label4" runat="server" Text=""></asp:Label></h1>
 </div>	
		  <div class="top_tips">
		    <h2>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label><asp:Label ID="Label2"
                    runat="server" Text=""></asp:Label><asp:Label ID="Label3" runat="server" Text=""></asp:Label>关注排行 <asp:Label ID="Label5" runat="server" Text=""></asp:Label></h2>
  </div>
		<div class="main_content"><!--中部开始-->
			<div class="main_left"><!--左边开始-->
				<div class="freight_List">
				<div class="area blue">
				选择航线：
				<%if (Request.QueryString["type"].ToString() == "air") {%>
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=&l=<%=Server.UrlEncode("北美线")%>">北美</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=&l=<%=Server.UrlEncode("欧洲线")%>">欧洲</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=&l=<%=Server.UrlEncode("南美线")%>">南美</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=&l=<%=Server.UrlEncode("亚洲线")%>">亚洲</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=&l=<%=Server.UrlEncode("非洲线")%>">非洲</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=&l=<%=Server.UrlEncode("澳洲线")%>">澳洲</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=&l=<%=Server.UrlEncode("国内航线")%>">国内</a> ︱
				<br />
				选择起运地：
				<%}else {%>				
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=&l=<%=Server.UrlEncode("美加线")%>">美加</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=&l=<%=Server.UrlEncode("欧地线")%>">欧地</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=&l=<%=Server.UrlEncode("日韩线")%>">日韩</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=&l=<%=Server.UrlEncode("非洲线")%>">非洲</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=&l=<%=Server.UrlEncode("澳洲线")%>">澳洲南太平洋</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=&l=<%=Server.UrlEncode("近洋线")%>">东南亚</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=&l=<%=Server.UrlEncode("中南美线")%>">中南美</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=&l=<%=Server.UrlEncode("中东印巴线")%>">中东印巴红海</a> ︱
				<br />
				选择起运港：
				<%} %>
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=<%=Server.UrlEncode("shanghai")%>&l=">上海</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=<%=Server.UrlEncode("shenzhen")%>&l=">深圳</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=<%=Server.UrlEncode("tianjin")%>&l=">天津</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=<%=Server.UrlEncode("ningbo")%>&l=">宁波</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=<%=Server.UrlEncode("qingdao")%>&l=">青岛</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=<%=Server.UrlEncode("dalian")%>&l=">大连</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=<%=Server.UrlEncode("guangzhou")%>&l=">广州</a> ︱
				<a href="/billboard/topview.aspx?type=<%=Request.QueryString["type"].ToString()%>&y=<%=Request.QueryString["y"].ToString()%>&m=<%=Request.QueryString["m"].ToString()%>&sp=<%=Server.UrlEncode("xiamen")%>&l=">厦门</a>
				</div>
				  <div class="list_box">
					  		<table id="pd" border="0" cellpadding="0" cellspacing="1" bgcolor="#CAE7F0">
  <tr>
    <td width="30px" height="38" align="center" bgcolor="#E9F3F8" class="blue">排名</td>
    <td width="230px" align="center" bgcolor="#E9F3F8" class="blue">公司名</td>
    <td width="200px" align="center" bgcolor="#E9F3F8" class="blue">运价主题</td>
    <td width="70px" align="center" bgcolor="#E9F3F8" class="blue">起运港</td>
    <td width="70px" align="center" bgcolor="#E9F3F8" class="blue">目的港</td>
    <td width="50px" align="center" bgcolor="#E9F3F8" class="blue">航线</td>
    <td width="40px" align="center" bgcolor="#E9F3F8" class="blue">访问量</td>
    </tr>
  <asp:Repeater ID="RptTopView" runat="server">
  <ItemTemplate>
  <tr>
    <td height="46" align="center" bgcolor="#FFFFFF"><div class="divexcees" style="width:30px"><%#this.RptTopView.Items.Count + 1%></div></td>
    <td align="left" bgcolor="#FFFFFF"><div class="divexcees" style="width:230px"><%#Eval("RealName")%> [<%#Eval("CompanyName")%>]</div></td>
    <td align="center" bgcolor="#FFFFFF"><div class="divexcees" style="width:200px"><a href="/<%=Request.QueryString["type"].ToString()%>/<%#setkey(Eval("yid").ToString())%>_<%#(Eval("ydid"))%>.html" target="_blank"><%#Eval("ttitle")%></a></td>
    <td align="center" bgcolor="#FFFFFF"><div class="divexcees" style="width:70px""><%#Eval("tstartport")%></div></td>
    <td align="center" bgcolor="#FFFFFF"><div class="divexcees" style="width:70px"><%#Eval("tdestport")%></div></td>
    <td align="center" bgcolor="#FFFFFF"><div class="divexcees" style="width:50px""><%#Eval("tline")%></div></td>
    <td align="center" bgcolor="#FFFFFF"><div class="divexcees" style="width:40px"><%#Eval("infohits")%></div></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
</table>
				  </div>
				</div>
		  </div>
			<!--左边结束-->	
			<div class="main_right"><!--右边开始-->
				<div style="height:28px;" style="display:none;">
				  <input name="textfield" type="text" size="13" />
				  <input type="submit" name="Submit3" value="排名搜索" />
				</div>
			  <div class="right_box" style="margin-top:0px;">
		    <ul>
						<li style="border-bottom:1px dashed #CCCCCC;">·<a href="/help/help_top.html#tips1" target="_blank">什么是整箱海运价关注排行？</a></li>
						<li style="border-bottom:1px dashed #CCCCCC;">·<a href="/help/help_top.html#tips2" target="_blank">运价关注排行的规则是什么?</a></li>
						<li style="border-bottom:1px dashed #CCCCCC;">·<a href="/help/help_top.html#tips3" target="_blank">我怎么样才能上榜？</a></li>
				</ul>
			  </div>
				<div class="right_box">
					<div class="right_box_title"><h2>环球运费网其他排行榜</h2>
					</div>
					<ul>
						<li><a href="/billboard/toppublished.aspx?type=fcl&y=2009&m=8&sp=&l=">本月整箱海运价发布量排行</a></li>
						<li><a href="/billboard/toppublished.aspx?type=lcl&y=2009&m=8&sp=&l=">本月拼箱海运价发布量排行</a></li>
						<li><a href="/billboard/toppublished.aspx?type=air&y=2009&m=8&sp=&l=">本月空运运价发布量排行</a></li>
						<li><a href="/billboard/topview.aspx?type=fcl&y=2009&m=8&sp=&l=" >本月整箱海运价关注排行</a></li>
						<li><a href="/billboard/topview.aspx?type=lcl&y=2009&m=8&sp=&l=" >本月拼箱海运价关注排行</a></li>
						<li><a href="/billboard/topview.aspx?type=air&y=2009&m=8&sp=&l=" >本月空运运价关注排行</a></li>
					</ul>
				</div>
				<div class="right_box">
                  <div class="right_box_title">
                    <h2>历史排行榜</h2>
                  </div>
				  <ul>
                    <li><a href="/billboard/topview.aspx?type=fcl&y=2009&m=7&sp=&l=">2009年7月整箱运价关注排行</a></li>
				    <li><a href="/billboard/topview.aspx?type=fcl&y=2009&m=6&sp=&l=">2009年6月整箱运价关注排行</a></li>
				    <li><a href="/billboard/topview.aspx?type=lcl&y=2009&m=7&sp=&l=">2009年7月拼箱运价关注排行</a></li>
				    <li><a href="/billboard/topview.aspx?type=lcl&y=2009&m=6&sp=&l=">2009年6月拼箱运价关注排行</a></li>
				    <li><a href="/billboard/topview.aspx?type=air&y=2009&m=7&sp=&l=">2009年7月空运运价关注排行</a></li>
				    <li><a href="/billboard/topview.aspx?type=air&y=2009&m=6&sp=&l=">2009年6月空运运价关注排行</a></li>
			      </ul>
			  </div>
		  </div>
			<!--右边结束-->		
  		</div>
<userbottomline:userbottomline ID="userbottomline1" runat="server" />
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
</form>
</body>
</html>
