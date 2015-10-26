<%@ Page Language="C#" AutoEventWireup="true" CodeFile="err.aspx.cs" Inherits="search_err" EnableViewState="false" enableEventValidation="false" ValidateRequest="false"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<asp:Literal id="Literal1" runat="server"><title>环球运费网是全球最大的空运运价与海运运价查询与订舱平台,空运费与海运费查询与订舱平台</title></asp:Literal>
<meta name="description" content="环球运费网是全球最大的运费查询与订舱平台,提供海运运价与空运运价查询和订舱服务,拥有海量货主与货代会员进行运费查询和在线订舱,更多运费查询订舱服务请点击进入" />
<meta name="keywords" content="运费,运价,订舱" />
<meta name="google-site-verification" content="Tkd5hCwEyv9Qr3uq0ajP_PCHqFkuQu3i7Un7G5Ql91c" />
<script src="/topic/lcl090619/js/jquery-1.2.1.pack.js" type="text/javascript"></script>
<script type="text/javascript" src="/js/MSClass.js"></script>
<script type="text/javascript" src="/js/home.js"></script>
<script type="text/javascript" language="javascript" src="/js/auto/ac_zd.js"></script>
<script type="text/javascript" language="javascript" src="/js/auto/airprot_ch.js"></script>
<script type="text/javascript" language="javascript" src="/js/auto/ac_zd_head_home.js"></script>
<script language="javascript" src="/js/fullad.js" type="text/javascript"></script>
<link href="/js/auto/port.css" rel="stylesheet" type="text/css" />
<link href="/css2/index.css" rel="stylesheet" type="text/css" /> 
</head>

<body> 
<form id="form1" runat="server" autocomplete="off">
<div id="messages"></div>
<div class="main"> 
<div id="mm" style="position:absolute; width:300px; background:#FFFFFF; left:10px;border:1px solid #999999; visibility:hidden; z-index:10;"></div>


<div class="h_box">
<div class="head"><!--顶部开始-->
<div class="head_top" style="position:relative;">
<h2><asp:Label ID="Label8" runat="server" Text=""></asp:Label> <a href="/accounts/reg.aspx">[免费注册]</a> <asp:Literal ID="Literal7" runat="server"></asp:Literal></h2>
<ul>
<li><a href="/member/">我的办公室</a>&nbsp;|&nbsp;</li>
<li><a href="#" onmouseover="javascript:document.getElementById('menu_base').style.display = '';" onmouseout="javascript:document.getElementById('menu_base').style.display = 'none';">免费会员服务</a>&nbsp;|&nbsp;</li>
<li><a href="#" onmouseover="javascript:document.getElementById('menu_pro').style.display = '';" onmouseout="javascript:document.getElementById('menu_pro').style.display = 'none';">付费服务</a>&nbsp;|&nbsp;</li>
<li><a href="/help/help_23.aspx" target="_blank">帮助</a>&nbsp;&nbsp;</li>
</ul>
<div style="border:1px solid #E69B9B;background:#FDFDFD;padding:8px;line-height:20px;position:absolute;top:20px; left:773px; display:none;" id="menu_base" onmouseover="javascript:document.getElementById('menu_base').style.display = '';" onmouseout="javascript:document.getElementById('menu_base').style.display = 'none';">
<a href="/accounts/reg.aspx" target="_blank">会员注册</a> <br/>
<a href="/member/releaseselect.aspx" target="_blank">发布运价</a> <br/>
<a href="/member/ReleaseCargo.aspx" target="_blank">发布货盘</a> <br/>
<a href="/fcl/" target="_blank">查询运价</a> <br/>
<a href="/bbs/post.aspx" target="_blank">发布帖子</a> <br/>
</div>
<div style="border:1px solid #E69B9B;background:#FDFDFD;padding:8px;line-height:20px;position:absolute;top:20px; left:813px; display:none;" id="menu_pro" onmouseover="javascript:document.getElementById('menu_pro').style.display = '';" onmouseout="javascript:document.getElementById('menu_pro').style.display = 'none';">
<a href="/products/" target="_blank">海空运精准营销</a> <br/>
<a href="/products/products2.aspx" target="_blank">邮件/短信群发</a> <br/>
<a href="/products/products3.aspx" target="_blank">航线优势代理</a> <br/>
<a href="/products/products4.aspx" target="_blank">广告</a> <br/>
</div>
</div>
</div>

<div class="head_mid">
<div class="head_mid_box">
<div id="logo"><a href="/"><img src="http://img02.100allin.com/images2/index/logo.jpg"  border="0" alt="环球运费网 - 全球最大的空运运价海运运价查询与订舱平台,空运费海运费查询与订舱平台"/></a></div>

<div class="search_bar">
<div class="search_bar_box">
<div class="search_bar_t">
<ul>
<li class="set" id="fcl_search_tab"><a href="#" onclick="change_search('fcl_search');">整箱海运价</a></li>
<li id="lcl_search_tab"><a href="#" onclick="change_search('lcl_search');">拼箱海运价</a></li>
<li id="air_search_tab"><a href="#" onclick="change_search('air_search');">空运运价</a></li>
<li id="company_search_tab"><a href="#" onclick="change_search('company_search');">公司库</a></li>
</ul>
<div class="search_form" id="fcl_search">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="130"><div id="select">
<span id="select_text">
<span class="select-style">
<select name="txtLine" id="txtLine" style="width:115px; color:#AAAAAA;" onkeydown="KeyDown(event);" onfocus="javascript:this.style.color='#000000';"  onblur="javascript:this.style.color='#AAAAAA';">
<option value="">全部航线</option>
<option value="美加线">美加线</option>
<option value="欧地线">欧地线</option>
<option value="中南美线">中南美线</option>
<option value="日韩线">日韩线</option>
<option value="近洋线">近洋线</option>
<option value="非洲线">非洲线</option>
<option value="澳洲线">澳洲线</option>
<option value="中东印巴线">中东印巴线</option>
<option value="红海线">红海线</option>
</select>
</span></span>
</div></td>
<td width="176">
<asp:TextBox ID="txtStartport" runat="server" CssClass="text_area" ForeColor="#CCCCCC" Text="起运港" sou_type="start_port"></asp:TextBox>
</td>
<td width="176">
<asp:TextBox ID="txtDestport" runat="server" CssClass="text_area" ForeColor="#CCCCCC" Text="目的港" sou_type="end_port"></asp:TextBox>
</td>
<td width="97">
<asp:TextBox ID="txtCarrier" runat="server" CssClass="ship_area" ForeColor="#CCCCCC" Text="船公司" sou_type="ship_com"></asp:TextBox>
</td>
<td>
<a href="/fcl/" id="fcl_jump" target="_blank" onclick="search_fcl_jump();"><img src="http://img02.100allin.com/images/index/bot1.GIF" style="border:0; width:123px; height:26px;" /></a></td>
</tr> 
</table>
</div>

<div class="search_form" id="lcl_search" style="display:none;">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="130"><div id="select">
<span id="select_text">
<span class="select-style">
<select name="txtLine2" id="txtLine2" style="width:115px; color:#AAAAAA;" onkeydown="KeyDown(event);" onfocus="javascript:this.style.color='#000000';"  onblur="javascript:this.style.color='#AAAAAA';">
<option value="">全部航线</option>
<option value="美加线">美加线</option>
<option value="欧地线">欧地线</option>
<option value="中南美线">中南美线</option>
<option value="日韩线">日韩线</option>
<option value="近洋线">近洋线</option>
<option value="非洲线">非洲线</option>
<option value="澳洲线">澳洲线</option>
<option value="中东印巴线">中东印巴线</option>
<option value="红海线">红海线</option>
</select>
</span></span>
</div></td>
<td width="176">
<asp:TextBox ID="txtStartport2" runat="server" CssClass="text_area" ForeColor="#CCCCCC" Text="起运港" sou_type="start_port"></asp:TextBox>
</td>
<td width="176">
<asp:TextBox ID="txtDestport2" runat="server" CssClass="text_area" ForeColor="#CCCCCC" Text="目的港" sou_type="end_port"></asp:TextBox>
</td>
<td width="97">
<asp:TextBox ID="txtCarrier2" runat="server" CssClass="ship_area" ForeColor="#CCCCCC" Text="船公司" sou_type="ship_com"></asp:TextBox>
</td>
<td>
<a href="/fcl/" id="lcl_jump" target="_blank" onclick="search_lcl_jump();"><img src="http://img02.100allin.com/images/index/bot1.GIF" style="border:0; width:123px; height:26px;"/></a></td>
</tr> 
</table>
</div>

<div class="search_form" id="air_search" style="display:none;">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="130"><div id="select">
<span id="select_text">
<span class="select-style">
<select name="txtLine3" id="txtLine3" style="width:115px; color:#AAAAAA;" onkeydown="KeyDown(event);" onfocus="javascript:this.style.color='#000000';"  onblur="javascript:this.style.color='#AAAAAA';">
<option value="">全部航线</option>
<option value="美加线">北美线</option>
<option value="欧地线">欧洲线</option>
<option value="中南美线">南美线</option>
<option value="日韩线">亚洲线</option>
<option value="近洋线">非洲线</option>
<option value="非洲线">澳洲线</option>
<option value="澳洲线">国内航线</option>
</select>
</span></span>
</div></td>
<td width="220">
<asp:TextBox ID="txtStartport3" runat="server" CssClass="text_area3" ForeColor="#CCCCCC" Text="起运地" sou_type="air_start"></asp:TextBox>
</td>
<td width="229">
<asp:TextBox ID="txtDestport3" runat="server" CssClass="text_area3" ForeColor="#CCCCCC" Text="目的地" sou_type="air_port"></asp:TextBox>
</td>
<td>
<a href="/air/" id="air_jump" target="_blank" onclick="search_air_jump();"><img src="http://img02.100allin.com/images/index/bot1.GIF" style="border:0; width:123px; height:26px;" /></a></td>
</tr> 
</table>
</div>

<div class="search_form" id="company_search" style="display:none;">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="579">
<asp:TextBox ID="txtCompanyName" runat="server" CssClass="text_area4" ForeColor="#CCCCCC" Text="公司名称"></asp:TextBox>
</td>
<td>
<a href="/company/" id="company_jump" target="_blank" onclick="search_company_jump();"><img src="http://img02.100allin.com/images/index/bot1.GIF" style="border:0; width:123px; height:26px;" /></a></td>
</tr> 
</table>
</div>
</div>
<div class="fcl_bar" style="display:none;"></div>
</div>
</div>
</div>
</div>
<usertopmenu20100711:usertopmenu20100711 ID="usertopmenu20100711_1" runat="server" />
</div><!--顶部结束-->

<div class="container"><!--主体开始-->
		      <table width="92%" border="0" align="center" cellpadding="3" cellspacing="1" style="background:url(images/fcl/33.gif) no-repeat right 65px;">
				<tr>
                  <td height="32" colspan="2" align="left" ><div class="blue" style=" font:14px '宋体'; line-height:48px; border-bottom:1px dashed #ccc;"><img src="/images/fcl/jt2.gif" />&nbsp;<strong>错误</strong></div></td>
                </tr>
				<tr>
                  <td height="10" colspan="2" align="center" ></td>
				</tr>
				<tr>
                  <td height="10" colspan="2" align="left" >
                  





                <table cellspacing="0" cellpadding="0" border="0">
                              <tbody>
                                <tr>
                                  <td width="222" align="center"><img height="184" 
            src="/images/nothing.jpg" width="192" /></td>
                                  <td width="525"><div 
            style="FONT-WEIGHT: bold; FONT-SIZE: 18px; COLOR: #226077; LINE-HEIGHT: 30px">
                                      <p>亲爱的用户：<br />
                                        对不起，该页面有错误、被更名，被删除或不存在！ </p>
                                  </div></td>
                                </tr>
                              </tbody>
                          </table>
                              <table cellspacing="0" cellpadding="0" border="0">
                                <tbody>
                                  <tr>
                                    <td width="222">&nbsp;</td>
                                    <td width="525"><div 
            style="FONT-SIZE: 14px; COLOR: #226077; LINE-HEIGHT: 30px">
                                        <p><strong>您选择可以尝试以下任意一种操作</strong>：<br />
                                          &nbsp;&nbsp;&nbsp;&nbsp;· 等待片刻，重新打开您刚才需要访问的页面<br />
                                          &nbsp;&nbsp;&nbsp;&nbsp;· 单击 <a href="javascript:history.back(1)">后退</a> 回到上一个页面</p>                                        
                                      <p><br />
                                            <strong>您是否还有疑惑？不妨联系我们</strong>：<br />
                                        </p>
                                      <p><span><strong>地址</strong>：</span><br />
                                        上海市延安东路588号东海商业中心东楼11楼B 邮编：200001<br />
                                      </p>
                                      <p><span><strong>联系电话</strong>：</span><br />
                                            <strong>总机</strong>：400-888-9256<br />
                                            <strong>客户服务部</strong>：021-51086987-106<br />
                                            <strong>客服QQ1</strong>：<a 
            href="tencent://message/?uin=744593820&amp;Site=www.100allin.com&amp;Menu=yes">744593820（点击可直接联系我）</a> <br />
                                            <strong>客服QQ2</strong>：<a 
            href="tencent://message/?uin=914019684&amp;Site=www.100allin.com&amp;Menu=yes">914019684（点击可直接联系我）</a> <br />
                                            <strong>技术支持</strong>：021-51086987-101<br />
                                        </p>
                                      <p><span><strong>传真</strong>：</span><br />
                                        021-63509508<br />
                                      </p>
                                      <p><span><strong>E-mail</strong>：</span><br />
                                        allin@100allin.com</p>
                                      <br />
                                      <br />
                                    </div></td>
                                  </tr>
                                </tbody>
                              </table>

                  
                  </td>
				</tr>
                </table> 
<userbottomline:userbottomline id="userbottomline1" runat="server"/>
<userbottom100414:userbottom100414 ID="userbottom100414_1" runat="server" />
</div><!--主体结束-->
</div>



</form>

</body>
</html>
<script language="javascript">
<!--
if(typeof(LiveReceptionCode_isonline)!='undefined'  && LR_GetObj('LR_User_Icon0')!=null)
{
if(LiveReceptionCode_isonline)
LR_GetObj('LR_User_Icon0').innerHTML='<a '+LiveReceptionCode_BuildChatWin('您有新访客','您好，请问有什么需要帮忙？')+'><img src="http://img02.100allin.com/images2/index/lx_2.gif" border="0"></a>';
else
LR_GetObj('LR_User_Icon0').innerHTML='<a '+LiveReceptionCode_BuildChatWin('您有新访客','客服人员不在线,请点击留言')+'><img src="http://img02.100allin.com/images2/index/lx_2.gif" border="0"></a>';
}
//-->
</script>