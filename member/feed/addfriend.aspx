<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addfriend.aspx.cs" Inherits="member_feed_addfriend" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>添加好友</title>
<link href="/member/css/offices.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
	<div class="main_container">
    <memberheader:memberheader ID="memberheader1" runat="server" />
		<div class="center">
            <memberleft:memberleft ID="memberleft1" runat="server" />
	        <div class="main">
                <memberwelcome:memberwelcome ID="memberwelcome1" runat="server" />
				
			  <div class="fcl_tit"><table width="100%" border="0" cellspacing="1" cellpadding="0">
  <tr>
    <td width="6%" align="center"><img src="/member/images/ad_f.gif" width="44" height="27" /></td>
    <td width="44%"><strong>您要添加以下好友吗？</strong></td>
    <td width="50%" align="right"><a href="#"></a></td>
  </tr>
</table>
</div>
<div class="fcl">
                <div class="message_box_left">
                  <div class="message_pic"><img id="imghead" src="/images/fcl/people.GIF" runat="server" width="76" height="76" /></div>
                  <div class="message_tx" style='font-size:14px; font-weight:bold; '><asp:Label ID="Label4" runat="server" Text=""></asp:Label><br />
                      <asp:Literal ID="Literal25" runat="server"></asp:Literal></div>
                </div>
			    <div class="message_box_right" style="font-size:12px;">
                  <table width="100%" border="0" cellspacing="1" cellpadding="0">
                    <tr>
                      <td colspan="2" height="22">公司：<asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                      <td colspan="2" height="22">电话：<span class="yt"><asp:ImageButton ID="ImageButton1" runat="server" Enabled="false" CssClass="get" /></span></td>
                    </tr>
                    <tr>
                      <td colspan="2" height="22">手机：<span class="yt"><asp:ImageButton ID="ImageButton4" runat="server" Enabled="false" CssClass="get" /></span></td>
                    </tr>
                    <tr>
                      <td colspan="2" height="22">email：<span class="yt"><asp:ImageButton ID="ImageButton3" runat="server" Enabled="false" CssClass="get" /></span></td>
                    </tr>
                    <tr>
                      <td colspan="2" height="22">地址：<asp:Label ID="Label11" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                      <td colspan="2" height="22">邮编：<asp:Label ID="Label9" runat="server" Text=""></asp:Label></td>
                    </tr>
					<tr>
                      <td height="12" colspan="2"><table width="100%" height="1" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                          <td bgcolor="#CCCCCC"></td>
                        </tr>
                      </table></td>
                    </tr>
                    <tr>
                      <td width="18%" height="22">安运通等级：</td>
                      <td width="82%"><asp:Literal ID="LtrStars1" runat="server"></asp:Literal></td>
                    </tr>
                    <tr>
                      <td height="22">信誉等级：</td>
                      <td><asp:Literal ID="LtrStars2" runat="server"></asp:Literal></td>
                    </tr>
                    <tr>
                      <td height="22">在线联系：</td>
                      <td>&nbsp;</td>
                    </tr>
                    <tr>
                      <td height="52" colspan="2"><a href="#"><img src="/member/images/ms_bt6.gif" border="0" /></a></td>
                    </tr>
                  </table>
		        </div>
		      </div>
		    </div>

		</div>
<memberfooter:memberfooter ID="memberfooter1" runat="server" />
	</div>

</form>
</body>
</html>
