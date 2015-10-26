<%@ Page Language="C#" AutoEventWireup="true" CodeFile="buy.aspx.cs" Inherits="products_buy" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link href="/css3/products.css" rel="stylesheet" type="text/css" /> 
<title>海空运精准营销-环球运费网</title>
</head>
<body>
<form id="form1" runat="server">
<div class="main"> 
<div class="h_box" style="margin-bottom:20px;">
<usertoptop20100711:usertoptop20100711 ID="usertoptop20100711_1" runat="server" />
<div class="head_nav">
<ul>
<li><a href="/"><img src="images/logo.jpg" border="0" /></a></li>
<li><img src="images/pro_5.jpg" width="508" height="64" border="0" /></li>
<li><img src="images/contact.jpg" border="0" /></li>
</ul>
</div>

</div><!--顶部结束-->

<div class="container"><!--主体开始-->
<div>
<img style="width:100%; height:0px;" src="/images2/products/blank.gif" />
</div>
<div style="border:1px solid #999999; padding:10px 100px;">
<div style="color:#960F0B; font-size:28px; text-align:center; font-weight:bold; line-height:68px; font-family:黑体;">
 环球运费网付费服务申请表</div>
<div style="color:#666666; font-size:14px; font-weight:bold; line-height:48px;">
<div><span class="orange">*</span>您申请购买的产品是（可多项选择）</div>
<div><span style="display:inline-block">
<asp:CheckBox ID="CheckBox1" runat="server" Text="精准营销套餐" />&nbsp;&nbsp;
<asp:CheckBox ID="CheckBox2" runat="server" Text="精准投递" />&nbsp;&nbsp;
<asp:CheckBox ID="CheckBox3" runat="server" Text="搜索直达" />&nbsp;&nbsp;
<asp:CheckBox ID="CheckBox4" runat="server" Text="精品商铺" />&nbsp;&nbsp;
<asp:CheckBox ID="CheckBox5" runat="server" Text="首页滚动" />&nbsp;&nbsp;
<asp:CheckBox ID="CheckBox6" runat="server" Text="图文展示" />&nbsp;&nbsp;
</span>
</div>
<div>1、请在下表中填写您的联系方式，我们将尽快与您联系！</div>
<div><span style="display:inline-block">2、您还可以直接拨打销售热线：400-888-9256，或向网站服务人员进行咨询</span> 
</div>
<div style="line-height:24px; margin-top:20px;">
  <table width="100%" border="0" cellpadding="3" cellspacing="3">
    <tr>
      <td width="34%"><div align="right"><span class="orange">*</span> 贵公司名称：</div></td>
      <td width="66%"><asp:TextBox ID="TextBox1" runat="server" Width="250" MaxLength="100"></asp:TextBox></td>
    </tr>
    <tr>
      <td><div align="right"><span class="orange">*</span> 真实姓名：</div></td>
      <td><asp:TextBox ID="TextBox2" runat="server" Width="250" MaxLength="100"></asp:TextBox></td>
    </tr>
    <tr>
      <td><div align="right"><span class="orange">*</span> 性别：</div></td>
      <td>&nbsp;<asp:RadioButtonList ID="RadioButtonList1" runat="server" BorderWidth="0px"
              CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" RepeatLayout="Flow">
              <asp:ListItem>男</asp:ListItem>
              <asp:ListItem>女</asp:ListItem>
          </asp:RadioButtonList></td>
    </tr>
    <tr>
      <td><div align="right"><span class="orange">*</span> 您的职位：</div></td>
      <td><asp:TextBox ID="TextBox3" runat="server" Width="250" MaxLength="100"></asp:TextBox></td>
    </tr>
    <tr>
      <td><div align="right"><span class="orange">*</span> 固定电话：</div></td>
      <td>国家&nbsp;&nbsp;&nbsp;&nbsp;区号&nbsp;&nbsp;&nbsp;&nbsp;电话号码<br />
        <asp:TextBox ID="TextBox4" runat="server" Width="37" MaxLength="4">86</asp:TextBox>-<asp:TextBox ID="TextBox7" runat="server" Width="37" MaxLength="4"></asp:TextBox>-<asp:TextBox ID="TextBox8" runat="server" Width="144" MaxLength="50"></asp:TextBox></td>
    </tr>
    <tr>
      <td><div align="right"><span class="orange">*</span> 手机：</div></td>
      <td><asp:TextBox ID="TextBox5" runat="server" Width="250" MaxLength="50"></asp:TextBox></td>
    </tr>
    <tr>
      <td><div align="right"><span class="orange">*</span> 电子邮箱：</div></td>
      <td><asp:TextBox ID="TextBox6" runat="server" Width="250" MaxLength="100"></asp:TextBox></td>
    </tr>
    <tr>
      <td height="100"><div align="right"></div></td>
      <td><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images2/products/qrtj.gif" OnClick="ImageButton1_Click"/></td>
    </tr>
  </table>
</div>
</div>
</div>
<userbottom100414:userbottom100414 ID="userbottom100414_1" runat="server" />
</div><!--主体结束-->
</div>

</form>
</body>
</html>