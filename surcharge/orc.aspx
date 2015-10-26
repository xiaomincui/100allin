<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orc.aspx.cs" Inherits="surcharge_orc" %>
<%@ OutputCache Duration="3600" Location="Any" VaryByCustom="browser" VaryByParam="none" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<asp:Literal ID="Littitle" runat="server"><title>最新ORC-环球运费网</title></asp:Literal>
<meta name="keywords" content="ORC" />
<meta name="description" content="环球运费网是全球最大的专业运价查询平台，提供最新ORC附加费查询。" />
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
		<div style="width:750px; float:left; margin-bottom:6px;"><a href="/">首页</a> > 最新ORC</div>
					<div class="main_left" style="float:right; width:727px;"><!--左边开始-->
<div class="company">
	<div class="company_box">
			  <div class="news_bar">
				<div class="bar_box" style="height:550px;">
						<h1><asp:Literal ID="LitYear2" runat="server"></asp:Literal>年<asp:Literal ID="LitMonth2" runat="server"></asp:Literal>月船公司最新ORC</h1>
	    <div style="margin:5px 0px 10px 0px; border-top:1px #DDDDDD solid; width:100%; height:1px;overflow:hidden;" ></div>		
						<div class="artibody" style="font-size:14px; text-align:left; line-height:22px;">ORC：
						<br/>origin  receiving charge ( applicable to shipments from South China,payable by  consignee if not paid by shipper )<br/>我们叫做远洋码头费, 其实学名是原产地接受费, 凡从广东省或华南地区（福建、广西、广东、海南）港口起的货物都加ORC,<strong><br />
						  <br />
						</strong>
						<table border="1" cellpadding="3" cellspacing="0" width="100%">
                          <tr>
                            <td>航线</td>
                            <td>20'</td>
                            <td>40'</td>
                          </tr>
                          <tr>
                            <td>中东线：</td>
                            <td>USD105/20'</td>
                            <td>USD210/40'</td>
                          </tr>
                          <tr>
                            <td>近洋线：</td>
                            <td>RMB375/20'</td>
                            <td>RMB560/40'</td>
                          </tr>
                          <tr>
                            <td>欧美线： </td>
                            <td>USD141/20'</td>
                            <td>USD 269/40'</td>
                          </tr>
                          <tr>
                            <td>中南美： </td>
                            <td>USD141/20'</td>
                            <td>USD 269/40'</td>
                          </tr>
                          <tr>
                            <td>非洲线： </td>
                            <td>USD141/20'</td>
                            <td>USD 269/40'</td>
                          </tr>
                          <tr>
                            <td>澳洲线： </td>
                            <td>USD141/20'</td>
                            <td>USD 269/40'</td>
                          </tr>
                          <tr>
                            <td>红海线： </td>
                            <td>USD141/20'</td>
                            <td>USD 269/40'</td>
                          </tr>
						  </table>
						<br />
						<br />
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