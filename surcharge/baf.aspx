<%@ Page Language="C#" AutoEventWireup="true" CodeFile="baf.aspx.cs" Inherits="surcharge_baf" %>
<%@ OutputCache Duration="3600" Location="Any" VaryByCustom="browser" VaryByParam="none" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head> 
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<asp:Literal ID="Littitle" runat="server"><title>最新BAF/CAF-环球运费网</title></asp:Literal>
<meta name="keywords" content="BAF CAF" />
<meta name="description" content="环球运费网是全球最大的专业运价查询平台，提供最新BAF/CAF附加费查询。" />
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
		<div style="width:750px; float:left; margin-bottom:6px;"><a href="/">首页</a> > 最新BAF/CAF</div>
					<div class="main_left" style="float:right; width:727px;"><!--左边开始-->
<div class="company">
	<div class="company_box">
			  <div class="news_bar">
				<div class="bar_box">
						<h1><asp:Literal ID="LitYear2" runat="server"></asp:Literal>年<asp:Literal ID="LitMonth2" runat="server"></asp:Literal>月船公司最新BAF/CAF</h1>
	    <div style="margin:5px 0px 10px 0px; border-top:1px #DDDDDD solid; width:100%; height:1px;overflow:hidden;" ></div>		
						<div class="thc"><div style="text-align:center; margin-bottom:10px;">按船公司首字母快速查找：<asp:Label ID="Label1" runat="server" Text=""></asp:Label></div>
                            
						<div style="padding-top:18px; line-height:22px; display:none;"><img src="/images/fcl/gt.gif" width="14" height="13" /> 如果您有BAF/CAF的更新信息，欢迎在此上传与环球运费网的广大客户们分享。如经审核通过，我们将贵公司列入本页右侧“特别鸣谢单位”名单。当月提交越早，排名越靠前，以示特别感谢！</div>
					    <div class="thcboby">
					    <table border="1" cellpadding="3" cellspacing="0" bgcolor="#e3e3e3" align="center">
                          <tbody>
                            <tr>
                              <td width="15%" align="center" bgcolor="e3e3e3"><strong style="font-size:14px;">Carriers</strong></td>
                              <td width="15%" align="center" bgcolor="e3e3e3"><strong style="font-size:14px;">船公司</strong></td>
                              <td width="15%" align="center" bgcolor="e3e3e3"><strong style="font-size:14px;">BAF（燃油附加费）</strong></td>
                              <td width="15%" align="center" bgcolor="e3e3e3"><strong style="font-size:14px;">CAF（货币调整附加费）</strong></td>
                              <td width="40%" align="center" bgcolor="e3e3e3"><strong style="font-size:14px;">航线范围</strong></td>
                              <%--<td width="12%" align="center" bgcolor="d3e8f2"><strong style="font-size:14px;">提交更新</strong></td>--%>
                            </tr>
                              <asp:Repeater ID="Repeater1" runat="server">
                              <ItemTemplate>
                              <tr id="<%#"anchor"+Eval("id")%>">
                              <td bgcolor="#FFFFFF"><%#Eval("Carriers")%></td>
                              <td bgcolor="#FFFFFF"><%#Eval("Carriers_cn")%></td>
                              <td bgcolor="#FFFFFF"><p align="left"><%#Eval("baf_fee")%></p></td>
                              <td bgcolor="#FFFFFF"><p align="left"><%#Eval("caf_fee")%> &nbsp;</p></td>
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