<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="message_default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>论坛--环球运费网</title>
    <link href="css/fcl_css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">


.divexcees {
    text-overflow:ellipsis;
    overflow: hidden;
}

.divexcees a:link {
	color: #293B5E;
	text-decoration: underline;
}
.divexcees a:visited {
	text-decoration: underline;
	color: #293B5E;
}
.divexcees a:hover {
	text-decoration: underline;
	color: #FF6600;
}
.divexcees a:active {
	text-decoration: underline;
	color: #293B5E;
}
.hidden {
    display:none;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main_container"><!--页面主体开始-->	
		<usernewtop:usernewtop ID="usernewtop1" runat="server" />
		<div class="menu"><!--导航开始-->
			<h1><userwelcome:userwelcome ID="userwelcome1" runat="server" />
			您现在的位置:<a href="/" target="_blank">首页</a> > <a href="/bbs/" target="_blank">论坛</a></h1>
			<userservice:userservice ID="userservice1" runat="server" />
		</div><!--导航结束-->
		<div class="main_content"><!--中部开始-->
			<div class="main_left"><!--左边开始-->
			  <table width="100%" border="1" cellspacing="0" 
bordercolor="#9EBCDE" rules="rows" id="GridView1" style="WIDTH:742px; BORDER-COLLAPSE: collapse">
                <tbody>
				<tr>
                    <td height="28" colspan="3" align="left" background="images/bbs/bbs_bg.gif">&nbsp;&nbsp;<a href="#" class="blue bold">发布主题</a></td>
                  </tr>
					<tr style="HEIGHT: 35px">
                    <td height="35" align="left" valign="middle">&nbsp;&nbsp;<a href="BBSList.aspx"><asp:Image ImageUrl="~/message/images/release.gif" ID="Image2" runat="server" /></a>&nbsp;<a href="#"></a></td>
                    <td width="186" align="center">&nbsp;</td>
                    <td width="186" align="center">&nbsp;</td>
					</tr>
				  <tr style="HEIGHT: 35px">
                    <td colspan="3" align="right" valign="middle"><table width="735" border="0" cellspacing="1" cellpadding="0">
                      <tr>
                        <td width="103" height="35" align="right">主题：</td>
                        <td width="388" align="left"><asp:TextBox ID="TextBox2" runat="server" Width="347px"></asp:TextBox></td>
                        <td colspan="2" align="left">板块：
                          <asp:DropDownList ID="DropDownList1" runat="server" Width="104px">
                                                    <asp:ListItem Value="1">新手上路</asp:ListItem>
                                                    <asp:ListItem Value="2">经验交流</asp:ListItem>
                                                    <asp:ListItem Value="3">谈天说地</asp:ListItem>
                                                </asp:DropDownList>                       </td>
                      </tr>
                      <tr>
                        <td width="103" height="35" align="right" valign="top">正文：</td>
                        <td width="388"><asp:TextBox ID="TextBox1" runat="server" Height="324px" TextMode="MultiLine" Width="440px"></asp:TextBox></td>
                        <td width="115" align="left" valign="top">&nbsp;<img src="images/login/wh.gif" />&nbsp;<a href="#" class="blue">如何发图片</a></td>
                        <td width="124">&nbsp;</td>
                      </tr>
                      <tr>
                        <td height="10" colspan="4"></td>
                      </tr>
                      <tr>
                        <td width="103" height="35">&nbsp;</td>
                        <td align="left"><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="发表帖子"  /></td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                      </tr>
                      <tr>
                        <td width="103" height="35">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                      </tr>
                    </table></td>
                  </tr>
			    </tbody>
		      </table>
			</div>
			<!--左边结束-->	
			<div class="main_right"><!--右边开始-->
			  <uservisited:uservisited ID="uservisited1" runat="server" />
				
				<userrate2:userrate2 ID="userrate22" runat="server" />
				<usertranslate2:usertranslate2 ID="usertranslate22" runat="server" />
			</div><!--右边结束-->	
  		</div>
	  <userbottomline:userbottomline ID="userbottomline1" runat="server" />
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
    </form>
</body>
</html>
