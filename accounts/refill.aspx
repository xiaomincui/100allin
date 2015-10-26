<%@ Page Language="C#" AutoEventWireup="true" CodeFile="refill.aspx.cs" Inherits="accounts_refill" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">









<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
<script type="text/javascript">
function showDiv(){
document.getElementById('popDiv').style.display='block';
document.getElementById('bg').style.display='block';
}
function closeDiv(){
document.getElementById('popDiv').style.display='none';
document.getElementById('bg').style.display='none';
}
function clickbutton()
{
    document.getElementById('Button1').click();
}
</script>
    
    
    <style type="text/css">
body {
    font: 13px Verdana;
    margin: 0 auto;
    padding: 0;
}

.main {
    margin: 0 auto;
    padding: 0;
    width: 950px;
}

.mydiv {
background-color: #ffffff;
border: 1px solid black;
text-align: center;
line-height: 20px;
font-size: 12px;
/*font-weight: bold;*/
z-index:99;
width: 405px;
height: 220px;
left:50%;/*FF IE7*/
top:50%;/*FF IE7*/
margin-left:-200px!important;/*FF IE7 该值为本身宽的一半 */
margin-top:-120px!important;/*FF IE7 该值为本身高的一半*/
margin-top:0px;
position:fixed!important;/*FF IE7*/
position:absolute;/*IE6*/

_top:       expression(eval(document.compatMode &&
            document.compatMode=='CSS1Compat') ?
            documentElement.scrollTop + (document.documentElement.clientHeight-this.offsetHeight)/2 :/*IE6*/
            document.body.scrollTop + (document.body.clientHeight - this.clientHeight)/2);/*IE5 IE5.5*/

}


.bg {
background-color: #666;
width: 100%;
height: 100%;
left:0;
top:0;/*FF IE7*/
filter:alpha(opacity=50);/*IE*/
opacity:0.5;/*FF*/
z-index:1;
position:fixed!important;/*FF IE7*/
position:absolute;/*IE6*/

_top:       expression(eval(document.compatMode &&
            document.compatMode=='CSS1Compat') ?
            documentElement.scrollTop + (document.documentElement.clientHeight-this.offsetHeight)/2 :/*IE6*/
            document.body.scrollTop + (document.body.clientHeight - this.clientHeight)/2);/*IE5 IE5.5*/

}
</style>
</head>
<body>
    <form id="form1" runat="server"  autocomplete="off" onKeydown="if(event.enterKey){return   false}">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="ShopConfirmLayer" style="position:absolute;top:300px;left:100px;z-index:900;border:1px red solid;width:500px;display:none;">
<input name="button1" value="关闭" type="button" onclick="CloseShopConfirm()"/>
</div>
<!--覆盖层-->
<div id="webBgLayer" style="position:absolute;top:0px;left:0px;z-index:899;background-color:#ccc;height:100%;width:100%;display:none;-moz-opacity:0.5;filter:alpha(opacity=50);"></div>
    
    
    
    <div style="margin: 0 auto;padding: 0;width:750px" >
<div style="width:750px;height:83px;background:url(images/4_top.jpg)"></div>
<div style=" padding:30px 25px 20px 25px">
<span style="font-size:13px"><strong>
尊敬的环球运费网会员：<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;环球运费网为所有普通会员提供了邮件订阅服务。如果您是货代会员，可获得公司库内展示推广资格；如果您<br />
是货主企业，我们将为您的资料保密，根据您的航线需求为您提供运价服务。<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;您现在是初级会员，花一分钟完善一下资料即可成为普通会员，立即获得上述服务：
</strong></span>
</div>
<div  style=" padding:0px 0 0 130px">
<table cellspacing="10">
<tr>
<td align="right"><strong><span style="color:#FF0000">*</span>&nbsp;公司类型：</strong></td>
<td>
<select name="CompanyType"  id="CompanyType" runat="server" style="width:100px">
					  <option value="">请选择</option>
                      <option value="1">货主</option>
                      <option value="2">货代</option>
                      <option value="3">船东</option>
                      <option value="5">船代</option>
                      <option value="6">快递</option>
                      <option value="7">场站</option>
                      <option value="8">仓储</option>
                      <option value="9">集卡</option>
                      <option value="10">报关</option>
                      <option value="4">其他</option>
                  </select>
</td>

</tr>
<tr><td align="right"><strong><span style="color:#FF0000">*</span>&nbsp;公司所在地：</strong></td><td><asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                        <div style="float:left;">
                        <asp:DropDownList ID="ddlcity1" runat="server" AutoPostBack="True" Width="100px" OnSelectedIndexChanged="ddlcity1_SelectedIndexChanged"  >
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlcity2" runat="server" AutoPostBack="True" Width="100px" OnSelectedIndexChanged="ddlcity2_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlcity3" runat="server" AutoPostBack="True" Width="100px" Visible="False">
                        </asp:DropDownList>
                        </div>
                        </ContentTemplate>
                    </asp:UpdatePanel></td></tr>
<tr><td align="right"><strong>联系地址：</strong></td><td><input id="Address" name="Address" type="text" class="usename" size="34" runat="server"  /></td></tr>
<tr><td align="right"><strong>邮政编码：</strong></td><td><input id="PostNumber" name="PostNumber" type="text" class="usename" size="34" runat="server"  /></td></tr>
<tr><td align="right"><strong>性别：</strong></td><td>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="0">男</asp:ListItem>
        <asp:ListItem Value="1">女</asp:ListItem>
    </asp:RadioButtonList>
</td></tr>
<tr><td align="right"><strong>您的职位：</strong></td><td><input id="Position" name="Position" type="text" class="usename" value="" size="34" runat="server" /></td></tr>
<tr><td align="right"><strong>传真：</strong></td><td><input id="Fax" name="Fax" type="text" class="usename" size="34" runat="server"  /></td></tr>
<tr><td align="right"><strong>手机：</strong></td><td><input id="MovePhone" name="MovePhone" type="text" class="usename" size="34" runat="server"  /></td></tr>
<tr><td align="right"><strong>MSN：</strong></td><td><input id="Msn" name="Msn" type="text" class="usename" size="34" runat="server" /></td></tr>
<tr><td align="right"><strong>QQ：</strong></td><td><input id="QQ" name="QQ" type="text" class="usename" size="34" runat="server"  /></td></tr>
<tr><td align="right"><strong>个性签名：</strong></td><td><input id="sign" name="sign" type="text" class="usename" size="34" runat="server"  /></td></tr>
<tr><td align="right"></td><td><span style="color:#CCCCCC"><strong>例：上海至黑海，欧地，非洲“庄家”黄小姐 电话021-8565XXXX</strong></span></td></tr>
<tr><td align="right"><strong>上传头像：</strong></td><td>
<asp:FileUpload ID="Portrait" runat="server"  />
</td></tr>
<tr><td align="right"></td><td><span style="color:#CCCCCC"><strong>尺寸：130*130，大小400KB以下</strong></span></td></tr>
<tr><td align="right"><strong><span style="color:#FF0000">*</span>&nbsp;公司介绍：</strong></td><td><textarea name="Username2253" cols="50" rows="8" class="usename" id="introduction" runat="server" ></textarea></td></tr>
<tr><td ></td><td>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/4_button.gif" OnClick="ImageButton1_Click1" />
    
    </td></tr>
</table>
</div>

<div style="float:left;height:45px;padding:0;width:100%;color:#AC0202;background-color:#AC0202"></div>
</div>



<div id="popDiv" class="mydiv" style="display:none;">
<table width="400" border="0" align="center" cellpadding="2" cellspacing="1">
                <tr>
                  <td height="40" colspan="2"><img src="/images/login/bg.gif" width="400" height="40" /></td>
                </tr>
                <tr>
                  <td width="112" height="10" align="right" class="grey"></td>
                  <td width="283" height="10" class="blue"></td>
                </tr>
                <tr>
                  <td width="112" height="32" align="right" class="title">用户名:</td>
                  <td width="283" height="32"><input name="Username" type="text" id="username" size="30" runat="server" /></td>
                </tr>
                <tr>
                  <td width="112" height="32" align="right" class="title">密码:</td>
                  <td height="32"><input name="Password" type="password" id="password" size="30" runat="server" /></td>
                </tr>
                <tr>
                  <td width="112" height="22" align="left" >&nbsp;</td>
                  <td align="left" ><asp:CheckBox ID="chkAutoLogin" runat="server" Checked="True" />
下次自动登录</td>
                </tr>
                <tr>
                  <%--<td width="112" height="44" align="center">&nbsp;</td>--%>
                  <td height="44" align="left" colspan="2">
                      <div style="width:70px; float:left"></div>
                      <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="/images/login/bt.gif" OnClick="ImageButton2_Click" />
                      <a href="javascript:closeDiv()"><img src="/images/login/bt1.gif" border="0"/></a>
                      </td>
                </tr>
              </table>


</div>
<div id="bg" class="bg" style="display:none;">
<iframe  style="position:absolute; visibility:inherit; top:0px; left:0px; width:100%; height:100%; z-index:-1; filter='progid:DXImageTransform.Microsoft.Alpha(style=0,opacity=0)';"></iframe>
</div>





    </form>
</body>
</html>


