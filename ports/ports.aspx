<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ports.aspx.cs" Inherits="ship_ship"  EnableViewState="false" %>

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
					  <h1>
                          <asp:Literal ID="Literal1" runat="server"></asp:Literal></h1>
                          <br /><br />
				  <div class="box_company">
				    <table width="100%" border="0" cellspacing="1" cellpadding="0">
                      <tr>
                        <td width="33%" height="32"  align="left"><strong>港口英文名：</strong><asp:Literal ID="Literal4" runat="server"></asp:Literal></td>
                        <td width="33%"  align="left"><strong>港口中文名：</strong><asp:Literal ID="Literal2" runat="server"></asp:Literal></td>
                        <td width="33%"  align="left"><strong>港口代码：</strong><asp:Literal ID="Literal10" runat="server"></asp:Literal></td>
                      </tr>
                      <tr>
                        <td height="72"   align="left"><strong>所属航线：</strong><asp:Literal ID="Literal5" runat="server"></asp:Literal></td>
                        <td   align="left"><strong>所在国家(英)：</strong><asp:Literal ID="Literal3" runat="server"></asp:Literal></td>
                        <td  align="left"><strong>所在国家：</strong><asp:Literal ID="Literal11" runat="server"></asp:Literal></td>
                      </tr>
                      
                    </table>
				  </div>
				  <div class="box_company">
				    <table width="100%" border="0" cellspacing="1" cellpadding="0">
                      
                      
                      <tr>
                        <td width="33%" height="38" align="center" valign="middle">&nbsp;<a href="../fcl/list-shanghai-<asp:Literal ID="Literal9" runat="server"></asp:Literal>--0-0-0-----1.html">上海-<asp:Literal ID="Literal8" runat="server"></asp:Literal>运价</a></td>
                        <td width="33%" height="38" align="center" valign="middle">&nbsp;<a href="../fcl/list-shenzhen-<asp:Literal ID="Literal12" runat="server"></asp:Literal>--0-0-0-----1.html">深圳-<asp:Literal ID="Literal13" runat="server"></asp:Literal>运价</a></td>
                        <td width="33%" height="38" align="center" valign="middle">&nbsp;<a href="../fcl/list-ningbo-<asp:Literal ID="Literal14" runat="server"></asp:Literal>--0-0-0-----1.html">宁波-<asp:Literal ID="Literal15" runat="server"></asp:Literal>运价</a></td>
                        
                      </tr>
                      <tr>
                        <td width="33%" height="38" align="center" valign="middle">&nbsp;<a href="../fcl/list-tianjin-<asp:Literal ID="Literal16" runat="server"></asp:Literal>--0-0-0-----1.html">天津-<asp:Literal ID="Literal17" runat="server"></asp:Literal>运价</a></td>
                        <td width="33%" height="38" align="center" valign="middle">&nbsp;<a href="../fcl/list-guangzhou-<asp:Literal ID="Literal18" runat="server"></asp:Literal>--0-0-0-----1.html">广州-<asp:Literal ID="Literal19" runat="server"></asp:Literal>运价</a></td>
                        <td width="33%" height="38" align="center" valign="middle">&nbsp;<a href="../fcl/list-qingdao-<asp:Literal ID="Literal20" runat="server"></asp:Literal>--0-0-0-----1.html">青岛-<asp:Literal ID="Literal21" runat="server"></asp:Literal>运价</a></td>
                        
                      </tr>
                      <tr>
                        <td width="33%" height="38" align="center" valign="middle">&nbsp;<a href="../fcl/list-xiamen-<asp:Literal ID="Literal22" runat="server"></asp:Literal>--0-0-0-----1.html">厦门-<asp:Literal ID="Literal23" runat="server"></asp:Literal>运价</a></td>
                        <td width="33%" height="38" align="center" valign="middle">&nbsp;<a href="../fcl/list-dalian-<asp:Literal ID="Literal24" runat="server"></asp:Literal>--0-0-0-----1.html">大连-<asp:Literal ID="Literal25" runat="server"></asp:Literal>运价</a></td>
                        <td width="33%" height="38" align="center" valign="middle"></td>
                        
                      </tr>
                    </table>
				  </div>
				  <div class="box_company" style=" padding-bottom:48px; border-bottom:none">
				    <table width="100%" border="0" cellspacing="1" cellpadding="0">
                      <tr>
                        <td height="38" align="left"><img src="images/Storage/fatcow_097.png" width="16" height="16" />&nbsp;<strong>港口介绍</strong></td>
                      </tr>
                      <tr>
                        <td valign="middle">
                        <p>　　
                            <asp:Literal ID="Literal6" runat="server"></asp:Literal>
　　
　　</p>
　　
　　</td>
                      </tr>
                    </table>
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
