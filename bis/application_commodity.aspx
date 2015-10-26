<%@ Page Language="C#" AutoEventWireup="true" CodeFile="application_commodity.aspx.cs" Inherits="biz_application_commodity" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>商务服务-报关商检-环球运费网</title>
    <link href="/css/Storage.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main_container"><!--页面主体开始-->	
		<usernewtop:usernewtop ID="usernewtop1" runat="server" />
		<div class="menu"><!--导航开始-->
			<h1><userwelcome:userwelcome ID="userwelcome1" runat="server" /><a href="/" target="_blank">首页</a> > <a href="/bis/Storage.aspx" target="_blank">商务服务</a> > 报关商检 </h1>
			<userservice:userservice ID="userservice1" runat="server" />
  </div><!--导航结束-->
  <div class="login_box" style="margin-top:8px; border:3px solid #d7e0ef; text-align:center;">
  		<fieldset style="border: 1px solid rgb(204, 204, 204); padding-bottom: 5px;">
          <table width="100%" height="530" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr>
              <td height="42" colspan="3" align="center" bgcolor="#F2F2F2"><strong style="font-size:14px;">申请报关商检</strong></td>
            </tr>
            <tr>
              <td width="30%" height="38" align="right"><span class="red">*</span>&nbsp;业务类型;</td>
              <td colspan="2" align="left"><input type="checkbox" name="checkbox" value="checkbox" id="chkshipout" runat="server" />
              海运出口
                <input type="checkbox" name="checkbox2" value="checkbox" id="chkshipin" runat="server" />
海运进口
<input type="checkbox" name="checkbox3" value="checkbox" id="chkshipinout" runat="server" />
海运进出口
<input type="checkbox" name="checkbox4" value="checkbox" id="chkair" runat="server" />
空运报关</td>
            </tr>
            <tr>
              <td height="38" align="right" bgcolor="#FAFAFA"><span class="red">*</span>&nbsp;所在城市:</td>
              <td colspan="2" align="left" bgcolor="#FAFAFA"><input name="Username2" type="text" id="txtcity" size="30" runat="server" /></td>
            </tr>
            <tr>
              <td height="38" align="right"><span class="red">*</span>&nbsp;业务规模;</td>
              <td colspan="2" align="left"><input name="text" type="text" id="txtportfolio" size="30" runat="server" />
              票/月</td>
            </tr>
            <tr>
              <td height="38" align="right" bgcolor="#FAFAFA"><span class="red">*</span>&nbsp;报关员数量;</td>
              <td colspan="2" align="left" bgcolor="#FAFAFA"><input name="text2" type="text" id="txtdeclarer" size="30" runat="server" />
              人</td>
            </tr>
            <tr>
              <td height="38" align="right"><span class="red">*</span>&nbsp;查验员数量;</td>
              <td colspan="2" align="left"><input name="text22" type="text" id="txtchecker" size="30" runat="server" />
人</td>
            </tr>
            <tr>
              <td height="38" align="right"><span class="red">*</span>&nbsp;业务描述;</td>
              <td colspan="2" align="left"><textarea name="textarea" cols="30" rows="5" id="txtdescription" runat="server"></textarea>
                <br />
                <span class="gray"><br />
              业务描述的字数要求不超过360个汉字<br />
              </span></td>
            </tr>
            <tr>
              <td height="38" align="right" bgcolor="#FAFAFA"><span class="red">*</span>&nbsp;联系方式;</td>
              <td colspan="2" align="left" bgcolor="#FAFAFA"><input name="Username82" type="text" id="txtlinkmen" size="30" runat="server" /></td>
            </tr>
            <tr>
              <td height="38" align="right">&nbsp;</td>
              <td colspan="2" align="left"><input name="Username8" type="text" id="txtphone" size="30" runat="server" /></td>
            </tr>
            <tr>
              <td height="38" align="right" bgcolor="#FAFAFA">&nbsp;</td>
              <td width="28%" align="left" bgcolor="#FAFAFA"><input name="txtcompany" type="text" id="txtcompany" size="30" runat="server" /></td>
              <td width="44%" align="left" bgcolor="#FAFAFA">&nbsp;</td>
            </tr>
            <tr>
              <td height="38" align="right">上传营业执照副本;</td>
              <td colspan="2" align="left"><input name="Username4242" type="text" id="Username4242" size="10" />
                <input type="submit" name="Submit32" value="浏览.." />
                &nbsp;&nbsp;<span class="gray">您也可以选择将营业执照副本发传真至021-53853022</span></td>
            </tr>
            <tr>
              <td height="10" colspan="3" align="center"></td>
            </tr>
            <tr>
              <td height="1" colspan="3" align="center" bgcolor="#999999"></td>
            </tr>
            <tr>
              <td height="10" colspan="3" align="right"></td>
            </tr>
            <tr>
              <td height="32" align="right">&nbsp;</td>
              <td colspan="2" align="left">
                  <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="提交" /></td>
            </tr>
            <tr>
              <td height="32" align="right">&nbsp;</td>
              <td colspan="2" align="left">&nbsp;</td>
            </tr>
    </table>
	</fieldset>
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
