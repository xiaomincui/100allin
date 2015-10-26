<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="poll_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>新版用户体验调查 - 环球运费网</title>
    <style type="text/css">
<!--
.STYLE1 {font-size: 13px; line-height:22px; color:#FF6600;}
.STYLE3 {font-size: 12px; line-height: 24px; color: #000000; }
-->
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="812" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="812" height="124" background="images/top_bg.jpg">&nbsp;</td>
  </tr>
  <tr>
    <td background="images/bg.jpg">
		<table width="90%" border="0" align="center" cellpadding="0" cellspacing="12">
  <tr>
    <td height="60" style="border-bottom:#CCCCCC 1px dashed;"><span class="STYLE1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>尊敬的用户，欢迎浏览新版环球运费网，您对我们的新面貌感觉如何，使用是否方便，请把您的感受告诉我们，我们会根据您的建议进一步完善，为您提供更贴切的服务，深切感谢您对我们工作的支持！</strong></span></td>
  </tr>
  <tr>
    <td class="STYLE3"><span class="STYLE3"><strong>1.对网站的整体设计风格和色彩是否满意？</strong> <br />
     
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="0">很满意</asp:ListItem>
            <asp:ListItem Value="1">还可以</asp:ListItem>
            <asp:ListItem Value="2">一般</asp:ListItem>
            <asp:ListItem Value="3">不好看</asp:ListItem>

        </asp:RadioButtonList>

        <br />
        <strong>2. 您对网站导航栏分类和显示方式是否满意？</strong><br />
			<asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="0">很满意</asp:ListItem>
            <asp:ListItem Value="1">还可以</asp:ListItem>
            <asp:ListItem Value="2">一般</asp:ListItem>
            <asp:ListItem Value="3">不好看</asp:ListItem>

        </asp:RadioButtonList>
</span>
<br />
<strong>3. 您觉得目前网站的内容更新？</strong><br />
    
  
  <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="0">很及时，数量也够多</asp:ListItem>
            <asp:ListItem Value="1">很及时，每天更新的量少了些</asp:ListItem>
            <asp:ListItem Value="2">不够及时，更新量还行</asp:ListItem>
            <asp:ListItem Value="3">不够及时，数量也比较少</asp:ListItem>

        </asp:RadioButtonList>

  <br />
  <strong>4. 您觉得网站内容的实用性如何？ </strong><br />
  
  <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="0">内容都很实用</asp:ListItem>
            <asp:ListItem Value="1">大部分内容比较实用</asp:ListItem>
            <asp:ListItem Value="2">实用的内容比较少</asp:ListItem>
            <asp:ListItem Value="3">基本没什么实用的内容</asp:ListItem>

        </asp:RadioButtonList>
  <br />
  <strong>5. 您觉得网站的浏览速度？</strong><br />
  

<asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="0">很快</asp:ListItem>
            <asp:ListItem Value="1">还行</asp:ListItem>
            <asp:ListItem Value="2">比较慢，但还可以接受</asp:ListItem>
            <asp:ListItem Value="3">非常慢，难以忍受</asp:ListItem>

        </asp:RadioButtonList>

<br />
<strong>6.其它建议</strong><br />
<textarea style="font:12px '宋体'; margin-top:8px;" name="textfield" cols="70" rows="5" id="advice" runat="server"></textarea>
<br />
<br />
&nbsp;&nbsp;&nbsp;<strong>您的姓名：
<input type="text" name="textfield2" id="username" runat="server" />
<br />
</strong><br />
<strong>您的e-mail：
<input type="text" name="textfield22" id="Email" runat="server" />
</strong></td>
  </tr>
  <tr>
    <td align="center" style="border-top:#CCCCCC 1px dashed;">&nbsp;</td>
  </tr>
</table>    </td>
  </tr>
  <tr>
    <td width="812" height="106" align="center" valign="top" background="images/top_foot.jpg">
		<span style="border-top:#CCCCCC 1px dashed;">
            <asp:ImageButton ID="ImageButton1" ImageUrl="images/tj.JPG" runat="server" OnClick="ImageButton1_Click" />
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:ImageButton ID="ImageButton2" ImageUrl="images/ck.JPG" runat="server" OnClick="ImageButton2_Click" />
		</span>
		</td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
