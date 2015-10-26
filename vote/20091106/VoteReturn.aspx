<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VoteReturn.aspx.cs" Inherits="poll_VoteReturn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>新版用户体验调查结果 - 环球运费网</title>
    <style type="text/css">
<!--
.STYLE1 {font-size: 12px; line-height:22px; color:#FF6600;}
.STYLE3 {font-size: 12px; line-height: 18px; color: #000000; }
.tpbg{display:block;font:12px "宋体";margin:0px;padding:0px;height:10px;background:#EAEAEA;}
.STYLE4 {font-size: 12px; line-height: 24px; color: #000000; }
-->
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="812" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="812" height="124" background="images/top_bg2.jpg">&nbsp;</td>
  </tr>
  <tr>
    <td background="images/bg.jpg">
		<table width="90%" border="0" align="center" cellpadding="0" cellspacing="12">
  <tr>
    <td class="STYLE3"><span class="STYLE3"></span>
      <table width="100%" border="0" cellspacing="3" cellpadding="0">
        <tr>
          <td width="50%"><strong>1.对网站的整体设计风格和色彩是否满意？</strong><br /></td>
          <td width="50%"><strong>2. 您对网站导航栏分类和显示方式是否满意？</strong></td>
        </tr>
      </table>
      <table width="100%" border="0" cellspacing="3" cellpadding="0">
        <tr>
          <td width="50%"><table width="100%" border="0" cellspacing="3" cellpadding="0">
            <tr>
              <td width="30%">很满意<em style="width:200px;" class="tpbg"><asp:Literal ID="choice_1_image0" Text="0%" runat="server"></asp:Literal></em></td>
              <td width="20%"><br />
                  <asp:Literal ID="choice_1_0" Text="0%" runat="server"></asp:Literal></td>
            </tr>
            <tr>
              <td width="30%">还可以<em style="width:200px;" class="tpbg"><asp:Literal ID="choice_1_image1" Text="0%" runat="server"></asp:Literal></em></td>
              <td width="20%"><br />
                 <asp:Literal ID="choice_1_1" Text="0%" runat="server"></asp:Literal></td>
            </tr>
            <tr>
              <td width="30%">一般<em style="width:200px;" class="tpbg"><asp:Literal ID="choice_1_image2" Text="0%" runat="server"></asp:Literal></em></td>
              <td width="20%"><br />
                 <asp:Literal ID="choice_1_2" Text="0%" runat="server"></asp:Literal></td>
            </tr>
            <tr>
              <td width="30%">不好看<br /><em style="width:200px;" class="tpbg"><asp:Literal ID="choice_1_image3" Text="0%" runat="server"></asp:Literal></em></td>
              <td width="20%"><br />
                 <asp:Literal ID="choice_1_3" Text="0%" runat="server"></asp:Literal></td>
            </tr>
          </table></td>
          <td width="50%"><table width="100%" border="0" cellspacing="3" cellpadding="0">
            <tr>
              <td width="30%">很满意<em style="width:200px;" class="tpbg"><asp:Literal ID="choice_2_image0" Text="0%" runat="server"></asp:Literal></em></td>
              <td width="20%"><br />
                <asp:Literal ID="choice_2_0" Text="0%" runat="server"></asp:Literal></td>
            </tr>
            <tr>
              <td width="30%">还可以<em style="width:200px;" class="tpbg"><asp:Literal ID="choice_2_image1" Text="0%" runat="server"></asp:Literal></em></td>
              <td width="20%"><br />
                <asp:Literal ID="choice_2_1" Text="0%" runat="server"></asp:Literal></td>
            </tr>
            <tr>
              <td width="30%">一般<em style="width:200px;" class="tpbg"><asp:Literal ID="choice_2_image2" Text="0%" runat="server"></asp:Literal></em></td>
              <td width="20%"><br />
                <asp:Literal ID="choice_2_2" Text="0%" runat="server"></asp:Literal></td>
            </tr>
            <tr>
              <td width="30%">不好看<br />
                  <em style="width:200px;" class="tpbg"><asp:Literal ID="choice_2_image3" Text="0%" runat="server"></asp:Literal></em></td>
              <td width="20%"><br />
                <asp:Literal ID="choice_2_3" Text="0%" runat="server"></asp:Literal></td>
            </tr>
          </table></td>
          </tr>
      </table>
      <br />
      <table width="100%" border="0" cellspacing="3" cellpadding="0">
        <tr>
          <td width="50%"><strong>3. 您觉得目前网站的内容更新？</strong><br /></td>
          <td width="50%"><strong>4. 您觉得网站内容的实用性如何？</strong></td>
        </tr>
      </table>
      <table width="100%" border="0" cellspacing="3" cellpadding="0">
        <tr>
          <td width="50%"><table width="100%" border="0" cellspacing="3" cellpadding="0">
            <tr>
              <td width="30%">很及时，数量也够多<em style="width:200px;" class="tpbg"><asp:Literal ID="choice_3_image0" Text="0%" runat="server"></asp:Literal></em></td>
              <td width="20%"><br />
                <asp:Literal ID="choice_3_0" Text="0%" runat="server"></asp:Literal></td>
            </tr>
            <tr>
              <td width="30%">很及时，每天更新的量少了些<em style="width:200px;" class="tpbg"><asp:Literal ID="choice_3_image1" Text="0%" runat="server"></asp:Literal></em></td>
              <td width="20%"><br />
                <asp:Literal ID="choice_3_1" Text="0%" runat="server"></asp:Literal></td>
            </tr>
            <tr>
              <td width="30%">不够及时，更新量还行<em style="width:200px;" class="tpbg"><asp:Literal ID="choice_3_image2" Text="0%" runat="server"></asp:Literal></em></td>
              <td width="20%"><br />
                <asp:Literal ID="choice_3_2" Text="0%" runat="server"></asp:Literal></td>
            </tr>
            <tr>
              <td width="30%">不够及时，数量也比较少 <br />
                  <em style="width:200px;" class="tpbg"><asp:Literal ID="choice_3_image3" Text="0%" runat="server"></asp:Literal></em></td>
              <td width="20%"><br />
                <asp:Literal ID="choice_3_3" Text="0%" runat="server"></asp:Literal></td>
            </tr>
          </table></td>
          <td width="50%"><table width="100%" border="0" cellspacing="3" cellpadding="0">
            <tr>
              <td width="30%">内容都很实用<em style="width:200px;" class="tpbg"><asp:Literal ID="choice_4_image0" Text="0%" runat="server"></asp:Literal></em></td>
              <td width="20%"><br />
                <asp:Literal ID="choice_4_0" Text="0%" runat="server"></asp:Literal></td>
            </tr>
            <tr>
              <td width="30%">大部分内容比较实用<em style="width:200px;" class="tpbg"><asp:Literal ID="choice_4_image1" Text="0%" runat="server"></asp:Literal></em></td>
              <td width="20%"><br />
                <asp:Literal ID="choice_4_1" Text="0%" runat="server"></asp:Literal></td>
            </tr>
            <tr>
              <td width="30%">实用的内容比较少<em style="width:200px;" class="tpbg"><asp:Literal ID="choice_4_image2" Text="0%" runat="server"></asp:Literal></em></td>
              <td width="20%"><br />
                <asp:Literal ID="choice_4_2" Text="0%" runat="server"></asp:Literal></td>
            </tr>
            <tr>
              <td width="30%">基本没什么实用的内容<em style="width:200px;" class="tpbg"><asp:Literal ID="choice_4_image3" Text="0%" runat="server"></asp:Literal></em></td>
              <td width="20%"><br />
                <asp:Literal ID="choice_4_3" Text="0%" runat="server"></asp:Literal></td>
            </tr>
          </table></td>
        </tr>
      </table>
      <br />
      <table width="100%" border="0" cellspacing="3" cellpadding="0">
        <tr>
          <td width="50%"><strong>5. 您觉得网站的浏览速度？</strong><br /></td>
          <td width="50%">&nbsp;</td>
        </tr>
      </table>
      <table width="100%" border="0" cellspacing="3" cellpadding="0">
        <tr>
          <td width="30%">很快<em style="width:200px;" class="tpbg"><asp:Literal ID="choice_5_image0" Text="0%" runat="server"></asp:Literal></em></td>
          <td width="20%"><br />
            <asp:Literal ID="choice_5_0" Text="0%" runat="server"></asp:Literal></td>
          <td width="30%">&nbsp;</td>
          <td width="20%">&nbsp;</td>
        </tr>
        <tr>
          <td width="30%"><span class="STYLE4">还行</span><em style="width:200px;" class="tpbg"><asp:Literal ID="choice_5_image1" Text="0%" runat="server"></asp:Literal></em></td>
          <td width="20%"><br />
            <asp:Literal ID="choice_5_1" Text="0%" runat="server"></asp:Literal></td>
          <td width="30%">&nbsp;</td>
          <td width="20%">&nbsp;</td>
        </tr>
        <tr>
          <td width="30%"><span class="STYLE4">比较慢，但还可以接受</span><em style="width:200px;" class="tpbg"><asp:Literal ID="choice_5_image2" Text="0%" runat="server"></asp:Literal></em></td>
          <td width="20%"><br />
            <asp:Literal ID="choice_5_2" Text="0%" runat="server"></asp:Literal></td>
          <td width="30%">&nbsp;</td>
          <td width="20%">&nbsp;</td>
        </tr>
        <tr>
          <td width="30%"><span class="STYLE4">非常慢，难以忍受</span><em style="width:200px;" class="tpbg"><asp:Literal ID="choice_5_image3" Text="0%" runat="server"></asp:Literal></em></td>
          <td width="20%"><br />
            <asp:Literal ID="choice_5_3" Text="0%" runat="server"></asp:Literal></td>
          <td width="30%">&nbsp;</td>
          <td width="20%">&nbsp;</td>
        </tr>
      </table>
      </td>
  </tr>
</table>    </td>
  </tr>
  <tr>
    <td width="812" height="106" align="center" valign="top" background="images/top_foot.jpg"><a href="javascript:window.close()"><br />
    <img src="images/gb.jpg" width="97" height="27" border="0" /></a></td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
