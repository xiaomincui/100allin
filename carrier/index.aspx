<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="ship_shiplist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <asp:Literal id="Litkey" runat="server"><meta name="keywords" content="船公司-环球运费网" /></asp:Literal>
<asp:Literal id="Litdes" runat="server"><meta name="description" content="船公司-环球运费网" /></asp:Literal>
<asp:Literal id="Littitle" runat="server"><title>船公司,船公司信息,船公司联系方式,船公司介绍-环球运费网</title></asp:Literal> 
<link href="/css2/nav.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/MSClass.js"></script>
</head>

<body>
<form id="form2" runat="server">
<div class="h_box">
<usertoptop20100711:usertoptop20100711 ID="usertoptop20100711_2" runat="server" />
<usertopmid20100711:usertopmid20100711 ID="usertopmid20100711_2" runat="server" />		
<usertopmenu20100711:usertopmenu20100711 ID="usertopmenu20100711_2" runat="server" />
</div>
<div class="main_container"><!--页面主体开始-->	
		<div style="width:750px; float:left; margin-bottom:6px;"><a href="/">首页</a> > 船公司大全</div>
					<div class="main_left" style="float:right; width:727px;"><!--左边开始-->
<div class="company">
	<div class="company_box">
			  <div class="main_box_left">
			  <div class="bar_box" >
					  <h1>船公司联系方式大全</h1>
					  <div class="list_box">
							<div class="sh">按船公司首字母快速查找：
                                <asp:Localize ID="lclletter" runat="server"></asp:Localize>
							<%--<a href="#">A</a> <a href="#">B</a> <a href="#">C</a> <a href="#">D</a> <a href="#">E</a> <a href="#">F</a> <a href="#">G</a> <a href="#">H</a> <a href="#">I</a> <a href="#">J</a> <a href="#">K</a> <a href="#">L</a> <a href="#">M</a> <a href="#">N</a> <a href="#">O</a> <a href="#">P</a> <a href="#">Q</a> <a href="#">R</a> <a href="#">S</a> <a href="#">T</a> <a href="#">U</a> <a href="#">V</a> <a href="#">W</a> <a href="#">X</a> <a href="#">Y</a> <a href="#">Z</a>--%></div>
							<div class="list_search">输入关键词（代码/中英文/简称）查询船公司：
							  <input id="txtkey" name="textfield3" type="text" size="25" runat="server" />
							  &nbsp;
                                <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" />
							  <%--<input type="submit" name="Submit" value="查询" />--%>
							  </div>
							<div class="list_title">&nbsp;<b>中文简写</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/Storage/sh_bwd.gif" width="1" height="21" />&nbsp;&nbsp;<b>中文名</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/Storage/sh_bwd.gif" width="1" height="21" />&nbsp;&nbsp;<b>英文简写</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/Storage/sh_bwd.gif" width="1" height="21" />&nbsp;&nbsp;<b>英文名</b></div>
							<ul>
                                <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                <li>
								  <table width="100%" border="0" cellspacing="3" cellpadding="0">
                                    <tr>
                                      <td width="25%" height="42"><span class="list_title">&nbsp;</span><%#Eval("name_cn_s").ToString() %></td>
                                      <td width="35%"><a href="carrier-<%#Eval("name_en_s").ToString()  %>.html" target="_blank"><%#Eval("name_cn").ToString() %></a></td>
                                      <td width="15%"><%#Eval("name_en_s").ToString() %></td>
                                      <td width="25%"><%#Eval("name_en").ToString() %></td>
                                    </tr>
                                  </table>
								</li>
                                </ItemTemplate>
                                </asp:Repeater>
								
								<li style=" padding:12px 0px; border:none;">
                                    
								<DIV class=manu><asp:Literal ID="Literal1" runat="server"></asp:Literal>
								<%--<SPAN class=disabled>&lt; 上一页</SPAN><SPAN 
class=current>1</SPAN><A 
href="http://preview.zcool.com.cn/code/css/31/#?page=2">2</A><A 
href="http://preview.zcool.com.cn/code/css/31/#?page=3">3</A><A 
href="http://preview.zcool.com.cn/code/css/31/#?page=4">4</A><A 
href="http://preview.zcool.com.cn/code/css/31/#?page=5">5</A><A 
href="http://preview.zcool.com.cn/code/css/31/#?page=6">6</A><A 
href="http://preview.zcool.com.cn/code/css/31/#?page=7">7</A>...<A 
href="http://preview.zcool.com.cn/code/css/31/#?page=199">199</A><A 
href="http://preview.zcool.com.cn/code/css/31/#?page=200">200</A><A 
href="http://preview.zcool.com.cn/code/css/31/#?page=2">下一页 &gt; </A>--%>

</DIV></li>
							</ul>
					  </div>
					</div>
			  </div><!--左边结束-->	
	</div>
  </div>
		  </div>
					<!--左边结束-->	
					<div class="main_right" style="float: left; margin:0px;"><!--右边开始-->
					  <div class="c_us_l">
					    <useranswerleft:useranswerleft ID="useranswerleft_1" runat="server" />
					  </div>
					</div>
					<!--右边结束-->			
<userbottom100414:userbottom100414 ID="userbottom100414_1" runat="server" />
</div>
    </form>
    
  

</body>
</html>

