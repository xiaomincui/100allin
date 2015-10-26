<%@ Page Language="C#" AutoEventWireup="true" CodeFile="caf.aspx.cs" Inherits="surcharge_caf" %><%@ OutputCache Duration="3600" Location="Any" VaryByCustom="browser" VaryByParam="none" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<asp:Literal ID="Littitle" runat="server"><title>最新CAF-环球运费网</title></asp:Literal>
<meta name="keywords" content="BAF CAF" />
<meta name="description" content="环球运费网提供最新CAF/BAF海运附加费查询。" />

    <link href="/css/fcl_css.css" rel="stylesheet" type="text/css" />

    <style type="text/css">.artibody a:link {
	color: #333333;
	text-decoration: underline;
}
.artibody a:visited {
	text-decoration: underline;
	color: #333333;
}
.artibody a:hover {
	text-decoration: underline;
	color: #FF6600;
}
.artibody a:active {
	text-decoration: underline;
	color: #333333;
}
.hidden {
    display:none;
}
    </style>
<script language="javascript" type="text/javascript" src="../js/function.js"></script>
<script type="text/javascript" language="javascript">


</script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="main"><!--页面主体开始-->	
		<usernewtop1209:usernewtop1209 ID="usernewtop12091" runat="server" />
		<div class="menu_end">
			<h1><a href="/" target="_blank">首页</a> > <asp:Literal ID="LitYear1" runat="server"></asp:Literal>年<asp:Literal ID="LitMonth1" runat="server"></asp:Literal>月最新CAF</h1>
        </div>
		<div class="main_content"><!--中部开始-->
			<div class="main_left"><!--左边开始-->
			  <div class="news_bar">
				<div class="bar_box">
						<h1><asp:Literal ID="LitYear2" runat="server"></asp:Literal>年<asp:Literal ID="LitMonth2" runat="server"></asp:Literal>月船公司最新CAF</h1>
						<div class="thc">
						
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            
						<div style="padding-top:18px; line-height:22px; display:none;"><img src="/images/fcl/gt.gif" width="14" height="13" /> 如果您有BAF/CAF的更新信息，欢迎在此上传与环球运费网的广大客户们分享。如经审核通过，我们将贵公司列入本页右侧“特别鸣谢单位”名单。当月提交越早，排名越靠前，以示特别感谢！</div>
					    <div class="thcboby" style="font-size:14px;">
					    
                              <asp:Repeater ID="Repeater1" runat="server">
                              <ItemTemplate>
                                  <%#Eval("Carriers")%>
                                  <%#Eval("Carriers_cn")%>
                                  <%#Eval("caf_fee")%>
                                  <%#Eval("Line")%><BR/>
                              </ItemTemplate>
                              </asp:Repeater>					    
					  </div>
				        
				</div>
		      </div>
				 
		  </div><!--左边结束-->	
				
  		</div>
			<div class="main_right"><!--右边开始-->
			  <div class="right_box">
					<div class="right_box_title"><h2>其他附加费</h2>
					</div>
					<ul>
						<li><a href="/baf/"><asp:Literal ID="LitMonth3" runat="server"></asp:Literal>月各大船公司最新BAF/CAF</a> </li>					
						<li><a href="/caf/"><asp:Literal ID="LitMonth4" runat="server"></asp:Literal>月各大船公司最新CAF</a> </li>	
						<li><a href="/thc/"><asp:Literal ID="LitMonth5" runat="server"></asp:Literal>月各大船公司最新THC</a> </li>
						<li><a href="/orc/"><asp:Literal ID="LitMonth6" runat="server"></asp:Literal>月最新ORC</a> </li>
						<li><asp:Literal ID="LitPreviousMonthBaf" runat="server"></asp:Literal></li>
						<li><asp:Literal ID="LitPreviousMonthThc" runat="server"></asp:Literal></li>
					</ul>
			  </div>
				<usertranslate2:usertranslate2 ID="usertranslate22" runat="server" />
			</div><!--右边结束-->		
  		</div>
	  <userbottomline:userbottomline ID="userbottomline1" runat="server" />
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	

    </form>

</body>
</html>