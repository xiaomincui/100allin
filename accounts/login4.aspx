<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login4.aspx.cs" Inherits="login4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="css/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main_container"><!--页面主体开始-->
  <!--顶部登陆结束-->
<div class="header"><!--头部LOGO开始-->	
			<div id="logo">
				<a href="#" target="_blank"><img src="images/logo.gif" alt="环球运费网" border="0" width="340" height="75" /></a>			</div>
			<ul><li><a title="欢迎使用在线客服" href="#" onclick="document.getElementById('aliserv').click();">在线客服</a> | <a href="/" target="_blank">返回首页</a><br />
			  如遇注册问题请拨打：<span class="red">400-888-9256</span></li>
			</ul>
  </div><!--头部LOGO结束-->
  <div class="menu"><!--导航开始-->
    <h1><span style="color:#29395b;">注册步骤</span>：<span class="orange"><img src="images/1.jpg" width="12" height="12" /><strong>初级会员</strong></span> &gt; <img src="images/2_2.JPG" width="12" height="12" />普通会员</h1>
  </div>
		<!--导航结束-->
		<div class="main_content"><!--中部开始-->
		  <div class="login_box">
		  	<div class="lg">
				<div class="zc2">
					<div class="zc2_top">
					  <p><span class="tt">恭喜您:<b style="color:#3399FF;"><asp:Literal ID="ltrName" runat="server"></asp:Literal></b>,您已注册成功普通会员!您现在拥有的功能有：</span>
                      <br /> 
                      ①&nbsp;<a href="#">发布货盘</a>&nbsp;&nbsp;②&nbsp;<a href="#">查看运价</a>&nbsp;&nbsp;③&nbsp;<a href="http://www.100allin.com/bbs/post.aspx" target="_blank">论坛发贴</a><br />
                      <%--免费向环球运费网的货代订舱，可享受运价保障和现金奖励&nbsp;&nbsp;<a href="http://www.100allin.com/help/help_1.aspx" target="_blank" style="color:#FF6600;">了解详情</a><br />--%>
					</p>
				  </div>
				  	<div class="zc2_bt">
				  	  <p style=" background-image:none;"><span class="tt"><b style="color:red;">如果您希望获得环球运费网的运价推荐服务，请填写以下推荐需求</b></span><br />
<img src="images/jt3.gif" width="8" height="8" />&nbsp;<span class="orange"><strong>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</strong></span>
				  	  </p><br /><br />
			  	  </div>
				</div>
				<div class="zc1">
					<div class="zc1_left" style="width:880px;"><table width="100%" height="239" border="0" align="left" cellpadding="0" cellspacing="1">
	  <tr>
		<td height="42" colspan="3" align="center" class="red">为避免您受到打扰,以下资料仅作为环球运费网提供运价推荐服务之用,不在网页中显示</td>
		</tr>
	  <tr>
		<td width="25%" height="48" align="right"><span class="zc_tn">出货方式</span>：</td>
		<td colspan="2"><asp:CheckBox ID="CheckBox4" runat="server" />
		  海运整箱
		  <asp:CheckBox ID="CheckBox3" runat="server" />
海运拼箱
<asp:CheckBox ID="CheckBox2" runat="server" />
空运
<asp:CheckBox ID="CheckBox1" runat="server" />
其他</td>
		</tr>
	  <tr>
		<td height="48" align="right"><span class="zc_tn">主要出货品名</span>：</td>
		<td colspan="2"><input name="Username222" type="text"  id="text1" value="" size="34" runat="server" /></td>
		</tr>
	  <tr>
		<td height="48" align="right"><span class="zc_tn">货物类型</span>：</td>
		<td colspan="2"><asp:CheckBox ID="CheckBox5" runat="server" />
普货
  <asp:CheckBox ID="CheckBox6" runat="server" />
危险品
<asp:CheckBox ID="CheckBox7" runat="server" />
冷冻品
<asp:CheckBox ID="CheckBox8" runat="server" />
大件货物
<asp:CheckBox ID="CheckBox9" runat="server" />
其他</td>
		</tr>
		<tr>
		<td height="48" align="right"><span class="zc_tn">主要出货港口</span>：</td>
		<td colspan="2"><input name="Username222" type="text"  id="text2" value="" size="34" runat="server" /></td>
		</tr>
	  <tr>
		<td height="48" align="right" valign="top"><span class="zc_tn">主要出货航线</span>：</td>
		<td colspan="2"><table width="440" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td><table width="220" border="0" cellspacing="1" cellpadding="0">
                <tr>
                  <td width="160"> 海运：</td>
                  <td width="160">&nbsp;</td>
                </tr>
                <tr>
                  <td><asp:CheckBox ID="CheckBox26" runat="server" />
                    欧地</td>
                  <td><asp:CheckBox ID="CheckBox10" runat="server" />
                    中南美</td>
                </tr>
                <tr>
                  <td><asp:CheckBox ID="CheckBox11" runat="server" />
                    澳洲</td>
                  <td><asp:CheckBox ID="CheckBox12" runat="server" />
                    美加</td>
                </tr>
                <tr>
                  <td><asp:CheckBox ID="CheckBox13" runat="server" />
                    红海</td>
                  <td><asp:CheckBox ID="CheckBox14" runat="server" />
                    日韩</td>
                </tr>
                <tr>
                  <td><asp:CheckBox ID="CheckBox15" runat="server" />
                    中东印巴</td>
                  <td><asp:CheckBox ID="CheckBox16" runat="server" />
                    非洲</td>
                </tr>
                <tr>
                  <td><asp:CheckBox ID="CheckBox17" runat="server" />
                    近洋</td>
                  <td>&nbsp;</td>
                </tr>
            </table></td>
            <td><table width="220" border="0" cellspacing="1" cellpadding="0">
                <tr>
                  <td width="160" align="left">空运：</td>
                  <td width="160">&nbsp;</td>
                </tr>
                <tr>
                  <td align="left"><asp:CheckBox ID="CheckBox18" runat="server" />
                    北美</td>
                  <td align="left"><asp:CheckBox ID="CheckBox19" runat="server" />
                    欧洲</td>
                </tr>
                <tr>
                  <td align="left"><asp:CheckBox ID="CheckBox20" runat="server" />
                    亚洲</td>
                  <td align="left"><asp:CheckBox ID="CheckBox23" runat="server" />
                  非洲
                    </td>
                </tr>
                <tr>
                  <td align="left"><asp:CheckBox ID="CheckBox21" runat="server" />
                  南美
                    </td>
                  <td align="left"><asp:CheckBox ID="CheckBox22" runat="server" />
                  澳洲
                    </td>
                </tr>
                <tr>
                  <td align="left"><asp:CheckBox ID="CheckBox24" runat="server" />
                  国内</td>
                  <td align="left">&nbsp;</td>
                </tr>
                <tr>
                  <td align="left">&nbsp;</td>
                  <td align="left">&nbsp;</td>
                </tr>
            </table></td>
          </tr>
        </table></td>
		</tr>

		  <tr>
		    <td height="58" align="right">&nbsp;</td>
		    <td width="37%" height="38" align="left">
                <asp:Button ID="Button2" runat="server" Text="保 存" OnClick="Button2_Click" />
		    </td>
		    <td width="41%" height="38" align="center"></td>
		    </tr>
	</table>
					</div>
			  </div>
		  	</div>
		  </div>
		</div>
	  <div class="foot"><strong>友情链接</strong>：<a href="#" target="_blank">中国航贸网</a> 递四方速递 青岛物流网 中国物流招聘网 中国物流联合网 进口交流论坛 便易精品服饰网 中国软启动网 重型物流行业网 物流网 08中国商机网 
          <br />
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;物流招聘网 快递查询网 猎头学院 城市通 现代物流专线网 泛珠三角物流网 上海租车 MAX56物流网 中国物流人才招聘网 制造资源网 中国货架网 网络114	  </div>
	  <div class="bottom_tn"><a href="#">关于傲赢</a> | <a href="#">服务条款</a> | <a href="#">法律声明</a> | <a href="#">广告合作</a> | <a href="#">联系我们</a><br />
Copyright 2007 100Allin.com All Rights Reserved<br />
沪ICP备07510944号</div>
</div><!--页面主体结束-->	
    </form>
</body>
</html>
