<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login3.aspx.cs" Inherits="accounts_login3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>注册普通会员</title>
    <link href="css/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<div class="main_container"><!--页面主体开始-->
  <!--顶部登陆结束-->
<div class="header"><!--头部LOGO开始-->	
			<div id="logo">
				<a href="/" target="_blank"><img src="images/logo.gif" alt="环球运费网" border="0" width="340" height="75" /></a>			</div>
			<ul><li><a title="欢迎使用在线客服" href="#" onclick="document.getElementById('aliserv').click();">在线客服</a> | <a href="/" target="_blank">返回首页</a><br />
			  如遇注册问题请拨打：<span class="red">400-888-9256</span></li>
			</ul>
  </div><!--头部LOGO结束-->
  <div class="menu"><!--导航开始-->
			<h1><span style="color:#29395b;">注册步骤</span>：<span><img src="images/1_1.jpg" width="12" height="12" />注册初级会员</span> >    <img src="images/2.JPG" width="12" height="12" /><span class="orange"><strong>注册普通会员</strong></span> >    <img src="images/3_3.JPG" width="12" height="12" />审核注册资料 </h1>
  <span class="right_tn"><a>*</a> 为必填项</span></div>
		<!--导航结束-->
		<div class="main_content"><!--中部开始-->
		  <div class="login_box">
		  	<div class="lg">
				<div class="zc2">
					<div class="zc2_top" style="height:160px;">
					  <p><span class="tt">您好！<b style="color:#3399FF;"><asp:Literal ID="Literal1" runat="server" Text="尊敬的网站访客"></asp:Literal></b>,系统正在审核您的普通会员资料</span>
                      <br /> 
		      您的账户资料正在审核中，审核完成即可享受网站全部功能<br />若账户资料中包含色情, 淫秽, 反动和其它违法内容，审核将不予通过<br />
                      免费向环球运费网的货代订舱，可享受运价保障和现金奖励&nbsp;&nbsp;<a href="http://www.100allin.com/topic/order20091104/product_4.aspx" target="_blank" style="color:#FF6600;">了解详情</a><br />
					</p>
				  </div>
				  	<div class="zc2_bt">
				  	  <p><span class="tt"><b style="color:red;">上传资质证明，您将升级成为安运通会员！安运通可以：</b></span>
                      <br />
                      ·&nbsp;发布运价排名靠前&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;·&nbsp;公司库排名靠前<br />
                      ·&nbsp;获得首页安运通推荐&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;·&nbsp;所发运价获得邮件推广<br />
                      ·&nbsp;安运通是环球运费网向广大货主和同行推荐的高信誉货代品牌&nbsp;&nbsp;<a href="http://www.100allin.com/topic/order20091104/product_1.aspx" target="_blank" style="color:#FF6600;display:none;">了解详情</a><br /><br />
                      <span style=" background-image:none;"><img src="images/jt3.gif" width="8" height="8" />&nbsp;<span class="orange"><strong><asp:Literal
                              ID="Literal2" runat="server"></asp:Literal></strong></span></span>				  	  </p>
			  	  </div>
				</div>
				<h3><img src="images/jt.gif" />成为安运通所需资质</h3>
				<div class="zc1">
					
					
					<div class="zc1_left" style="width:880px;"><table width="100%" height="333" border="0" align="left" cellpadding="0" cellspacing="1">
	  <tr>
		<td height="58" colspan="4" align="center" class="red">为确保安全，以下资质只作为升级凭证在环球运费网后台备档，不作他用。如果您没有电子版文件，也可直接发传真至<strong>021-53853022</strong></td>
		</tr>
	  <tr>
		<td width="25%" height="58" align="right"><span class="zc_tn">企业营业执照</span>：</td>
		<td colspan="2"><asp:FileUpload ID="FileUpload1" runat="server"  /></td>
		<td width="37%">&nbsp;</td>
	  </tr>
	  <tr>
		<td height="58" align="right"><span class="zc_tn">一代资质</span>：</td>
		<td colspan="2"><asp:FileUpload ID="FileUpload2" runat="server" /></td>
		<td class="gray">海运业务：商务部颁发的国际货运代理企业备案表<br />
		  空运业务：中国民用航空运输销售代理资格认可证书(即铜版)</td>
	  </tr>
	  <tr>
		<td height="58" align="right"><span class="zc_tn">无船承运人NVOCC资质</span>：</td>
		<td colspan="2"><asp:FileUpload ID="FileUpload3" runat="server"  /></td>
		<td class="gray">海运业务：无船承运业务经营资格经营登记证</td>
	  </tr>
	  <tr>
		<td height="58" align="right"><span class="zc_tn">身份证</span>：</td>
		<td colspan="2"><asp:FileUpload ID="FileUpload4" runat="server"  /></td>
		<td>&nbsp;</td>
	  </tr>
		  <tr>
		    <td height="58" align="right">&nbsp;</td>
		    <td height="38" align="left">
                <asp:Button ID="Button2" runat="server" Text="提 交" OnClick="Button2_Click" /></td>
		    <td height="38" align="center"></td>
		    <td align="center"></td>
		  </tr>
		  <tr>
		    <td height="38" align="right">&nbsp;</td>
		    <td height="38" align="left">&nbsp;</td>
		    <td height="38" align="center"></td>
		    <td align="center"></td>
		  </tr>
		  <tr>
		    <td height="38" align="right">&nbsp;</td>
		    <td height="38" align="left">&nbsp;</td>
		    <td height="38" align="center"></td>
		    <td align="center"></td>
		  </tr>
	</table>
					</div>
			  
					
					
					
					<%--<div class="zc1_rg">
					  <div class="zc1_rg_box">
							<h2>免费注册普通会员<br />您将享受以下专享服务! </h2>
							<a><img src="images/diqiu.gif" />拥有独立网页,更多宣传机会<br />
							<span class="gray">&nbsp;&nbsp;&nbsp;&nbsp;增加公司知名度和商业机会</span></a>
							<a><img src="images/benb.gif" width="18" height="18" />无限制发布各类信息<br />
							<span class="gray">&nbsp;&nbsp;&nbsp;&nbsp;初级会员的所有服务</span></a>
							  <a><img src="images/dunp.gif" width="18" height="18" />初级会员的所有服务<br />
							  <span class="gray">&nbsp;&nbsp;&nbsp;&nbsp;无限制浏览环球运费网<br />
							  &nbsp;&nbsp;&nbsp;&nbsp;论坛发帖与客户交流增加信任感</span></a></div>
					</div>--%>
				</div>
			</div>
		  </div>
		</div>
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
    </form>
</body>
</html>
