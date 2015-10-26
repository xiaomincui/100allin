<%@ Page Language="C#" AutoEventWireup="true" CodeFile="overdue_thc.aspx.cs" Inherits="surcharge_thc" %><%@ OutputCache Duration="3600" Location="Any" VaryByCustom="browser" VaryByParam="none" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="THC" />
<meta name="description" content="环球运费网是全球最大的专业运价查询平台，提供最新THC附加费查询。" />
<asp:Literal ID="Littitle" runat="server"><title>最新THC-环球运费网</title></asp:Literal>
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

.right_box1{
	width:198px;

	float:left;
	margin-bottom:8px;
	border:1px solid #9EBCDE;
}

.right_box1 ul{
	width:168px;
	padding:12px 15px 0px 15px;
	margin:0px;
	float:left;
}

.right_box1 ul li{
	display:block;
	list-style:none;
	line-height:24px;
}

.right_box_title1{
	width:189px;
	height:24px;
	padding: 7px 0px 0px 9px;
	background:url(../images/fcl/right_tt.gif) no-repeat top;
}

.right_box1 h2,.right_box h2 a{
	font:13px "宋体";
	font-weight:bold;
	margin:0px;
	padding:0px;
	color:#081023;
	text-decoration:none;
}

.right_box1 h2 a:hover{
	text-decoration:underline;
}

.right_box1 p{
	clear:both;
	padding:0px;
	margin:0px 0px 0px 18px;
	line-height:23px;
}
.right_box1 ul li a:hover{
	color: #FF6600;
	text-decoration: underline;
}

.right_box1 ul li a:active{
	font:12px "宋体";
	color:#28385A;
	text-decoration:none;
}

.right_box1 ul li a:visited,.right_box ul li a:active{
	font:12px "宋体";
	color:#28385A;
	text-decoration:none;
}

.right_box1 ul li a:link,.right_box ul li a:visited,.right_box ul li a:active{
	font:12px "宋体";
	color:#28385A;
	text-decoration:none;
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
    <div class="main_container"><!--页面主体开始-->	
		<usernewtop:usernewtop ID="usernewtop1" runat="server" />
		<div class="menu"><!--导航开始-->
			<h1><userwelcome:userwelcome ID="userwelcome1" runat="server" />
			您现在的位置:<a href="/" target="_blank">首页</a> > <asp:Literal ID="LitYear1" runat="server"></asp:Literal>年<asp:Literal ID="LitMonth1" runat="server"></asp:Literal>月最新THC</h1>
			<userservice:userservice ID="userservice1" runat="server" />
		</div><!--导航结束-->
		<div class="main_content"><!--中部开始-->
			<div class="main_left"><!--左边开始-->
			  <div class="news_bar">
				<div class="bar_box">
						<h1><asp:Literal ID="LitYear2" runat="server"></asp:Literal>年<asp:Literal ID="LitMonth2" runat="server"></asp:Literal>月船公司最新THC</h1>
						<div class="thc">按船公司首字母快速查找：
						
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            
						<div style="padding-top:18px; line-height:22px; display:none;"><img src="/images/fcl/gt.gif" width="14" height="13" /> 如果您有BAF/CAF的更新信息，欢迎在此上传与环球运费网的广大客户们分享。如经审核通过，我们将贵公司列入本页右侧“特别鸣谢单位”名单。当月提交越早，排名越靠前，以示特别感谢！</div>
					    <div class="thcboby">
					    <table width="100%" border="1" cellpadding="3" cellspacing="0" bgcolor="#d3e8f2">
                          <tbody>
                            <tr>
                              <td width="15%" align="center" bgcolor="e3e3e3"><strong style="font-size:14px;">口岸</strong></td>
                              <td width="15%" align="center" bgcolor="e3e3e3"><strong style="font-size:14px;">Carriers</strong></td>
                              <td width="15%" align="center" bgcolor="e3e3e3"><strong style="font-size:14px;">船公司</strong></td>
                              <td width="22%" align="center" bgcolor="e3e3e3"><strong style="font-size:14px;">THC（码头操作费RMB）</strong></td>
                              <td width="21%" align="center" bgcolor="e3e3e3"><strong style="font-size:14px;">航线范围</strong></td>
                              <%--<td width="12%" align="center" bgcolor="d3e8f2"><strong style="font-size:14px;">提交更新</strong></td>--%>
                            </tr>
                              <asp:Repeater ID="Repeater1" runat="server">
                              <ItemTemplate>
                              <tr id="<%#"anchor"+Eval("id")%>">
                              <td bgcolor="#FFFFFF"><%#Eval("port")%></td>
                              <td bgcolor="#FFFFFF"><%#Eval("Carriers")%></td>
                              <td bgcolor="#FFFFFF"><%#Eval("Carriers_cn")%></td>
                              <td bgcolor="#FFFFFF"><p align="left"><%#Eval("thc_fee")%></p></td>
                              <td align="center" bgcolor="#FFFFFF"><%#Eval("Line")%> &nbsp;</td>
                              <%--<td align="center" bgcolor="#FFFFFF" ><a href="#"><span class="orange">我有更新</span></a></td>--%>
                              </tr>
                              
                              </ItemTemplate>
                              </asp:Repeater>
                            
                            
                          </tbody>
				        </table>
					  </div>
				        
				</div>
		      </div>
				 
		  </div><!--左边结束-->	
				
  		</div>
			<div class="main_right"><!--右边开始-->
			<div class="right_box1">
					<div class="right_box_title1"><h2>特别鸣谢单位</h2>
					</div>
					<ul>
						<li>上海润波国际货运代理有限公司</li>
						<li class="gray">许晔 021-63809909 </li>
						<li>上海朗沃国际物流有限公司</li>
						<li class="gray">谢虹 021-63098492 </li>
						<li>大连顺翔上海分公司</li>
						<li class="gray">李恋恋 021-63075486 </li>			
					</ul>
			  </div>
			<div class="right_box">
					<div class="right_box_title"><h2>其他附加费</h2>
					</div>
					<ul>
						<li><a href="/baf/"><asp:Literal ID="LitMonth3" runat="server"></asp:Literal>月各大船公司最新BAF/CAF</a> </li>					
						<li><a href="/caf/"><asp:Literal ID="LitMonth4" runat="server"></asp:Literal>月各大船公司最新CAF</a> </li>	
						<li><a href="/thc/"><asp:Literal ID="LitMonth5" runat="server"></asp:Literal>月各大船公司最新THC</a> </li>
						<li><a href="/orc/"><asp:Literal ID="LitMonth6" runat="server"></asp:Literal>月最新ORC</a> </li>
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
