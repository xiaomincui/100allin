<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Exhibition.aspx.vb" Inherits="message_Exhibition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>商务服务--环球运费网</title>
    <link href="/css/fcl_css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">


.divexcees {
    text-overflow:clip;
    overflow: hidden;
}

.pm a:link {
	color: #666666;
	text-decoration: none;
}
.pm a:visited {
	text-decoration: none;
	color: #666666;
}
.pm a:hover {
	text-decoration: none;
	color: #FF6600;
}
.pm a:active {
	text-decoration: none;
	color: #666666;
}

.divexcees a:link {
	color: #333333;
	text-decoration: underline;
}
.divexcees a:visited {
	text-decoration: underline;
	color: #333333;
}
.divexcees a:hover {
	text-decoration: underline;
	color: #FF6600;
}
.divexcees a:active {
	text-decoration: underline;
	color: #333333;
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
			<h1><userwelcome:userwelcome ID="userwelcome1" runat="server" />您现在的位置:<a href="/" target="_blank">首页</a> > <a href="/message/BBSListExhibition.aspx" target="_blank">商务服务</a> > <asp:Label ID="Labposition" runat="server" Text="Label"></asp:Label></h1>
			<userservice:userservice ID="userservice1" runat="server" />
		</div><!--导航结束-->
		<div class="main_content"><!--中部开始-->
			<div class="main_left"><!--左边开始-->
			  <div class="news_bar">
					<div class="bar_box">
						<h1><asp:Label ID="Labtitle" runat="server" Text="Label"></asp:Label></h1>
						<div class="artInfo"><a href="#">http://www.100allin.com.cn</a>  <asp:Label ID="LabPostDate" runat="server" Text="Label"></asp:Label> <a href="#">环球运费网动态</a></div>
						<div class="artibody">
                            <asp:Label ID="LabDetail" runat="server" Text="Label"></asp:Label>
						</div>
					</div>
		      </div>
			  <div class="ad"><img src="/images/ad/bbs_ad.GIF" /></div>
				 <usernewsbottom:usernewsbottom ID="usernewsbottom1" runat="server" />
		  </div><!--左边结束-->	
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
