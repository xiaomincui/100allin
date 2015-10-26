<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Storage.aspx.cs" Inherits="bis_Storage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>商务服务-仓储-环球运费网</title>
    <link href="/css/Storage.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
    
    
function change(a,b)
{


    document.getElementById("imgbig_"+a).src ="images/Storage/upload/"+a+"_big_"+b+".jpg";
}
    

</script>
</head>
<body>
    <form id="form1" runat="server">
<div class="main_container"><!--页面主体开始-->	
		<usernewtop:usernewtop ID="usernewtop1" runat="server" />
		<div class="menu"><!--导航开始-->
			<h1><userwelcome:userwelcome ID="userwelcome1" runat="server" /><a href="/" target="_blank">首页</a> > <a href="/bis/Storage.aspx" target="_blank">商务服务</a> > 仓储</h1>
			<userservice:userservice ID="userservice1" runat="server" />
  </div><!--导航结束-->
		<div class="main_content"><!--中部开始-->
			<div class="main_box">
				<div class="main_box_right">
					<h1>&nbsp;</h1>
					<ul>
					
					    <li><a style="color:#FF6600; font-weight:bold; background: url(images/Storage/li_hover.gif) no-repeat right; text-decoration:none;" href="Storage.aspx"><img src="images/Storage/ico_1.GIF" border="0"/>仓储</a></li>
						<li><a href="commodity.aspx"><img src="images/Storage/ico_2.GIF" border="0"/>报关商检</a></li>
						<li><a href="nvocc.aspx"><img src="images/Storage/ico_3.GIF" border="0"/>无船承运人</a></li>
						<li><a href="hongkong.aspx"><img src="images/Storage/ico_4.GIF" border="0" />香港公司</a></li>
						<li><a href="#"><img src="images/Storage/ico_5.GIF" border="0"/>保险</a></li>
						<%--<li><a href="#"><img src="images/Storage/ico_6.GIF" border="0"/>支付</a></li>--%>
						<%--<li><a href="../message/BBSListExhibition.aspx"><img src="images/Storage/ico_7.GIF" border="0"/>展会</a></li>--%>
						<li><a href="bank.aspx"><img src="images/Storage/ico_8.GIF" border="0"/>银行</a></li>
						
						
						
					</ul>
					<div style="line-height:68px; text-align:center;"><a style="color:#000;" href="#">下载仓储合同范本</a></div>
					<p>免责申明：<br />
&nbsp;&nbsp;&nbsp;&nbsp;环球运费网所展示的信息真实性和准确性由展示公司自行提供和负责环球运费网不提供任何交易保证，不承担任何法律责任。</p>
				</div>
				<div class="main_box_left">
					  <h1>仓储&nbsp;<span style="font-size:13px; font-weight:normal;">[Storage]</span></h1>
					  <div class="list_box">
							<div class="sh">筛选城市：
							<a href="Storage.aspx" style="color:#FF6600"><strong>全部</strong></a> 
							<a href="Storage.aspx?city=上海">上海</a> 
							<a href="Storage.aspx?city=深圳">深圳</a> 
							<a href="Storage.aspx?city=广州">广州</a> 
							<a href="Storage.aspx?city=北京">北京</a> 
							<a href="Storage.aspx?city=天津">天津</a> 
							<a href="Storage.aspx?city=青岛">青岛</a> 
							<a href="Storage.aspx?city=东莞">东莞</a>  
							<a href="Storage.aspx?city=厦门">厦门</a> 
							<a href="Storage.aspx?city=宁波">宁波</a> 
							<a href="Storage.aspx?city=苏州">苏州</a>  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a style="color:#000; text-decoration:underline;" href="application_storage.aspx">申请展示我的仓库</a></div>
							<div class="list_title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;图片展示&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/Storage/sh_bwd.gif" width="1" height="21" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;简 介&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/Storage/sh_bwd.gif" width="1" height="21" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;报价&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/Storage/sh_bwd.gif" width="1" height="21" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;联系方式</div>
							<ul>
								
                                <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                <li>
								  <table width="100%" border="0" cellspacing="3" cellpadding="0">
                                    <tr>
                                      <td width="30%">
									  	<div class="product_name">
											<div class="product_bigimage"><a href="#"><img id="imgbig_<%#Eval("id")%>" src="images/Storage/upload/<%#Eval("id")%>_big_1.jpg" border="0" /></a></div>
										  <div class="picSmall">
										    <div id="left_bar"><%--<a href="#"><img src="images/Storage/lf.gif" border="0" /></a>--%></div>
										    <a href="javascript:;"><img onerror="this.style.display = 'none'" id="img<%#Eval("id")%>_1" onclick="change('<%#Eval("id")%>',1)" src="images/Storage/upload/<%#Eval("id")%>_1.jpg" width="48" height="48" border="0" /></a>
										    <a href="javascript:;"><img onerror="this.style.display = 'none'" id="img<%#Eval("id")%>_2" onclick="change('<%#Eval("id")%>',2)" src="images/Storage/upload/<%#Eval("id")%>_2.jpg" width="48" height="48" border="0" /></a>
										    <a href="javascript:;"><img onerror="this.style.display = 'none'" id="img<%#Eval("id")%>_3" onclick="change('<%#Eval("id")%>',3)" src="images/Storage/upload/<%#Eval("id")%>_3.jpg" width="48" height="48" border="0" /></a>
										    <%--<a href="javascript:;"><img onerror="this.style.display = 'none'" id="img<%#Eval("id")%>_4" onclick="change('<%#Eval("id")%>',4)" src="images/Storage/upload/<%#Eval("id")%>_4.jpg" width="48" height="48" border="0" /></a>
										    <a href="javascript:;"><img onerror="this.style.display = 'none'" id="img<%#Eval("id")%>_5" onclick="change('<%#Eval("id")%>',5)" src="images/Storage/upload/<%#Eval("id")%>_5.jpg" width="48" height="48" border="0" /></a>--%>
										    <div id="rt_bar"><%--<a href="#"><img src="images/Storage/rt.gif" width="6" height="12" border="0" />--%></a></div>
										  </div>
										</div>
									  </td>
                                      <td width="34%">
									  	<div class="detail">
											<h2><a href="#"><%#Eval("StorageName")%></a>&nbsp;<a name="dizhi" id="dizhi">[<%#Eval("Address")%>]</a></h2>
											<p><%#Eval("intro")%></p>
											<span class="blue3"><%#Eval("City")%>/<%#Eval("TypeName")%></span>	
										</div>
									  </td>
                                      <td width="18%">
									  	<div class="detail2">
											<p>仓储面积：<span class="red bold"><%#Eval("Storage_area").ToString()%></span>
                                              <br />
                                              场面面积：<span class="red bold"><%#Eval("Storage_area").ToString()%></span>
                                              <br />
                                          内装：<span class="red bold"><%#Eval("inbuiltValue")%></span></p>
										</div>
									  </td>
                                      <td width="18%"><div class="detail2">
                                        <p><strong style="font-size:14px;"><%#Eval("Company")%></strong><br />
                                          联系人：<%#Eval("linkmen")%><br />
                                        电话：<%#Eval("Phone")%></p>
                                      </div>
                                      </td>
                                    </tr>
                                  </table>
								</li>
                                </ItemTemplate>
                                </asp:Repeater>
								
								<li style=" padding:12px 0px; border:none;"><DIV class=manu><span class="disabled"
    style="padding-right: 0px; padding-left: 0px; float: left; padding-bottom: 0px;
    margin: 0px; color: #28385a; border-top-style: none; line-height: 27px; padding-top: 0px;
    border-right-style: none; border-left-style: none; height: 27px; border-bottom-style: none">
    共 <strong>
        <asp:Label ID="lblTotalPage" runat="server" Text="1"></asp:Label></strong> 页
    <strong>
        <asp:Label ID="lblTotalItem" runat="server" Text="0"></asp:Label></strong> 条记录
    &nbsp;以上是第 <strong>
        <asp:Label ID="lblCurrentPage" runat="server" Text="1"></asp:Label></strong>
    页 </span>
                                    <asp:LinkButton ID="lnkFirstPage" runat="server" OnClick="lnkFirstPage_Click">第一页</asp:LinkButton>
                                <asp:LinkButton ID="lnkPrePage" runat="server" OnClick="lnkPrePage_Click">上一页</asp:LinkButton>
                                <asp:LinkButton ID="lnkNextPage" runat="server" OnClick="lnkNextPage_Click">下一页</asp:LinkButton>
                                <asp:LinkButton ID="lnkLastPage" runat="server" OnClick="lnkLastPage_Click">最后页</asp:LinkButton>
                                    <asp:DropDownList ID="ddlPageSelect" runat="server" AutoPostBack="true" CssClass="pageDropdown" OnSelectedIndexChanged="ddlPageSelect_SelectedIndexChanged"
                                        >
                                    </asp:DropDownList></DIV></li>
							</ul>
					  </div>
					
				</div>
	        </div>
        </div>
		<userbottomline:userbottomline ID="userbottomline1" runat="server" />
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
    </form>
</body>
</html>
