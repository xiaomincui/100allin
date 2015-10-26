<%@ Page Language="VB" AutoEventWireup="false" CodeFile="news.aspx.vb" Inherits="en_search_news" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="/en/css/fcl_list.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
	<div class="main">
			<div class="head">
				<div class="ff_top_box">
					<div class="ff_solo">Welcome！Jason</div>
					<div class="ff_top_links"><img src="/en/images/fcl/exit.gif" width="16" height="16" /><a href="#" target="_blank">Exit</a></div>
				</div>
				<div class="head_mid">
					<div id="logo"><a href="#"><img src="/en/images/fcl/ff_logo.gif" width="299" height="89" border="0" /></a></div>
				  <div class="search_bar" style="height:auto; width:560px; background-image:none;">
						<div class="login_box" style="margin-top:20px;">
							<a href="#"><img src="/en/images/fcl/list_ico6.gif" />live help</a><br /><a><img src="/en/images/fcl/list_ico5.gif" />0086+02151086987</a><br />
						</div>
						<div class="login_box" style="border-right:1px dotted #666; margin-top:20px;">
							<a href="#"><img src="/en/images/fcl/list_ico7.gif" />login</a><br />
							<a href="#"><img src="/en/images/fcl/list_ico7.gif" />Office</a>
						</div>
				  </div>
				</div>
<div class="nav">
<ul>
<li><a href="/">Home</a></li>
<li class="divider"></li>
<li><a href="/en/fcl/">FCL Freight</a></li>
<li class="divider"></li>
<li><a href="/en/lcl/">LCL Freight</a></li>
<li class="divider"></li>
<li><a href="/en/air/">Air Freight</a></li>
<li class="divider"></li>
<li><a href="/en/surcharge/">Surcharge</a></li>
<li class="divider"></li>
<li><a href="/en/agent/">Agent</a></li>
<li class="divider"></li>
<li><a href="/en/company/">Company</a></li>
</ul>
</div>
			</div>
			<div class="menu">
				<h1><a href="#">Home</a> > <a href="#">Agent</a> <%--> <asp:Literal ID="Label1" runat="server" Text="运价标题"></asp:Literal>--%></h1>
			</div>
		<div class="main_page">
		  <div class="info_box">
		  	<h1>
                  <asp:Literal ID="Littitle" runat="server"></asp:Literal></h1>
			<p>
			<asp:Literal ID="Litcontent" runat="server"></asp:Literal>
			<%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;扬子晚报4月23日报道　昨天泰州警方公布，网上散布地震谣言的网民是一名在校大学生，目前他对自己的行为后悔不迭。<br />
              <br />
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4月20日晚，有群众向泰州警方举报，有网民发帖称“近期江苏有地震，上海世博会将取消”，该帖子严重失实，影响较坏。泰州警方初查发现网民在该市高教园一带活动，很快认定散布谣言者为该市一大学生江某，并将其找到。
              <br />
              <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;警方调查获悉，4月20日，江某听信了网友讲的有关地震的谣言，当晚他不负责任地将该虚假消息发到网上。民警随即对其进行批评教育江某对自己听信谣言、并在网上散布虚假信息的行为后悔不已。<br />
			<br />
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;扬子晚报4月23日报道　昨天泰州警方公布，网上散布地震谣言的网民是一名在校大学生，目前他对自己的行为后悔不迭。<br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4月20日晚，有群众向泰州警方举报，有网民发帖称“近期江苏有地震，上海世博会将取消”，该帖子严重失实，影响较坏。泰州警方初查发现网民在该市高教园一带活动，很快认定散布谣言者为该市一大学生江某，并将其找到。 <br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;警方调查获悉，4月20日，江某听信了网友讲的有关地震的谣言，当晚他不负责任地将该虚假消息发到网上。民警随即对其进行批评教育江某对自己听信谣言、并在网上散布虚假信息的行为后悔不已。<br />
			<br />
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;扬子晚报4月23日报道　昨天泰州警方公布，网上散布地震谣言的网民是一名在校大学生，目前他对自己的行为后悔不迭。<br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4月20日晚，有群众向泰州警方举报，有网民发帖称“近期江苏有地震，上海世博会将取消”，该帖子严重失实，影响较坏。泰州警方初查发现网民在该市高教园一带活动，很快认定散布谣言者为该市一大学生江某，并将其找到。 <br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;警方调查获悉，4月20日，江某听信了网友讲的有关地震的谣言，当晚他不负责任地将该虚假消息发到网上。民警随即对其进行批评教育江某对自己听信谣言、并在网上散布虚假信息的行为后悔不已。--%>

            </p>
		  </div>
			<div class="foot"><a href="#">About Us</a>︱<a href="#">Privacy Policy</a>︱<a href="#">Terms Of Use Agreement</a>︱ <a href="#">Site Map</a>︱<a href="#">Contact Us</a></div>
		</div>
	</div>
    </form>
</body>
</html>
