<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="ship_shiplist" EnableViewState="true" EnableEventValidation="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <asp:Literal id="Litkey" runat="server"><meta name="keywords" content="船公司-环球运费网" /></asp:Literal>
<asp:Literal id="Litdes" runat="server"><meta name="description" content="船公司-环球运费网" /></asp:Literal>
<asp:Literal id="Littitle" runat="server"><title>船公司,船公司信息,船公司联系方式,船公司介绍-环球运费网</title></asp:Literal> 
<link href="/css2/nav.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/MSClass.js"></script>
    <script type="text/javascript" src="/js/home.js"></script>
    
    <script type="text/javascript">
    function displaymore()
    {
        document.getElementById("divCountry").style.display = "none";
        document.getElementById("divCountry1").style.display = "";
    }displaydata
    
    function displaydata()
    {
        document.getElementById("divCountry").style.display = "";
        document.getElementById("divCountry1").style.display = "none";
    }
    
    </script>
</head>

<body>
<form id="form2" runat="server">
<div class="h_box">
<usertoptop20100711:usertoptop20100711 ID="usertoptop20100711_2" runat="server" />
<usertopmid20100711:usertopmid20100711 ID="usertopmid20100711_2" runat="server" />		
<usertopmenu20100711:usertopmenu20100711 ID="usertopmenu20100711_2" runat="server" />
</div>
<div class="main_container"><!--页面主体开始-->	
		<div style="width:750px; float:left; margin-bottom:6px;"><a href="/">首页</a> > 世界港口</div>
					<div class="main_left" style="float:right; width:727px;"><!--左边开始-->
<div class="company">
	<div class="company_box">
			  <div class="main_box_left">
			  <div class="bar_box" >
					  <h1>世界港口介绍</h1>
					  <div class="list_box">
							<div class="sh">
							<a href="index.aspx">港口首页</a>
							  <a href="list--0------1.html">按航线查找</a>
							  <a href="list---0-----1.html">按国家查找</a>                               
							</div>
							
							
							
							
							<div class="list_search">输入关键词（代码/中英文/简称/航线/国家）查询港口：
							  <input id="txtkey" name="textfield3" type="text" size="25" runat="server" />
							  &nbsp;
                                <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" />
							  <%--<input type="submit" name="Submit" value="查询" />--%>
							  <br />
							热门查询：
							<asp:Repeater ID="Repeater3" runat="server">
                        <ItemTemplate>
                        <a href="/ports/list-<%#Eval("search").ToString()%>-------1.html"><%#Eval("search").ToString()%></a>&nbsp;&nbsp;
                        </ItemTemplate>
                        </asp:Repeater>
							</div>
							
							
							<div id="divLine" class="sh1" style="text-align:center; font-size:small" runat="server">
							
							
                                <asp:Repeater ID="Repeater4" runat="server">
                                <ItemTemplate>
                                    <%# Request["n"].ToString() == Eval("id").ToString() ? "<div style=\"width:115px;height:17px; float:left;background-color:Gray\">" : "<div style=\"width:115px;height:17px; float:left\">"%><a href="list--<%#Eval("id").ToString()%>------1.html"><%#Eval("Line").ToString()%>(<%#Eval("count").ToString()%>)</a></div>
                                    
                                </ItemTemplate>
                                </asp:Repeater>
                               
							
							                                 
							</div>
							
							
							
							
							
							
							<div id="divCountry" class="sh1" style="text-align:center; font-size:small" runat="server">
							<asp:Repeater ID="Repeater5" runat="server">
                                <ItemTemplate>
                                    <%# Request["c"].ToString() == Eval("id").ToString() ? "<div style=\"width:115px;height:17px; float:left;background-color:Gray\">" : "<div style=\"width:115px;height:17px; float:left\">"%><a href="list---<%#Eval("id").ToString()%>-----1.html"><%#trimString(Eval("country").ToString(),5)%>(<%#Eval("count").ToString()%>)</a></div>
                                    
                                </ItemTemplate>
                            </asp:Repeater>
							
							
							<div style="width:115px;height:17px; float:left">
                                <a href="javascript:displaymore()"><span style="color:#CC0000">更多</span></a><asp:Literal ID="Literal2" runat="server"></asp:Literal></div>
							
							</div>
							
							
							<div id="divCountry1" class="sh" style="height:635px;background:url('images/t2.gif') no-repeat scroll 0 0 transparent;text-align:center; display:none; font-size:small" runat="server">
							<asp:Repeater ID="Repeater6" runat="server">
                                <ItemTemplate>
                                    <%# Request["c"].ToString() == Eval("id").ToString() ? "<div style=\"width:115px;height:17px; float:left;background-color:Gray\">" : "<div style=\"width:115px;height:17px; float:left\">"%><a href="list---<%#Eval("id").ToString()%>-----1.html"><%#trimString(Eval("country").ToString(),5)%>(<%#Eval("count").ToString()%>)</a></div>
                                    
                                </ItemTemplate>
                            </asp:Repeater>
							<div style="width:115px; float:left"></div><div style="width:115px; float:left"></div>
							<div style="width:115px;height:17px; float:left"><a href="javascript:displaydata()"><span style="color:#CC0000">收起</span></a></div>
							
							
							</div>
							
                                <asp:Literal ID="Literal3" runat="server"></asp:Literal>
							
							
							
							<div class="list_title">&nbsp;<b>港口代码</b>&nbsp;&nbsp;<img src="images/Storage/sh_bwd.gif" width="1" height="21" />&nbsp;<b>港口英文名</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/Storage/sh_bwd.gif" width="1" height="21" />&nbsp;<b>港口中文名</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/Storage/sh_bwd.gif" width="1" height="21" />&nbsp;<b>所属航线</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/Storage/sh_bwd.gif" width="1" height="21" />&nbsp;<b>所属国家</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/Storage/sh_bwd.gif" width="1" height="21" />&nbsp;<b>港口运价</b></div>
							<ul>
                                <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                <li>
								  <table width="100%" border="0" cellspacing="3" cellpadding="0">
                                    <tr>
                                      <td width="10%" height="42"><span class="list_title">&nbsp;</span><%#Eval("portNum").ToString()%></td>
                                      <td width="18%"><a href="<%#Eval("portname_en").ToString()  %>.html" target="_blank" style="text-decoration:underline;"><%#Eval("portname_en").ToString()%></a></td>
                                      <td width="18%"><%#Eval("portname").ToString()%></td>
                                      <td width="18%"><%#Eval("Line").ToString()%></td>
                                      
                                      <td width="18%"><%#Eval("country").ToString()%></td>
                                      <td width="18%"><a href="<%# (Eval("country").ToString()!="中国") ? "../fcl/list--" + Eval("portname_en").ToString() : "../fcl/list-" + Eval("portname_en").ToString() + "-"  %>--0-0-0-----1.html"  target="_blank">查看该港口运价</a></td>
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
