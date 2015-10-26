<%@ Page Language="C#" AutoEventWireup="true" CodeFile="title.aspx.cs" Inherits="admin_userlist"  ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="css/master.css" rel="stylesheet" type="text/css" />
    <link href="css/userlist.css" rel="stylesheet" type="text/css" />
    <script language=javascript src=../js/function.js></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
<!--

-->
</style>

</head>
<body>
<form id="form1" runat="server">
    <div id="page">
		<div id="center">
			<admintop:admintop id="admintop1" runat="server" />
			<adminmenu:adminmenu id="adminmenu1" runat="server" />
		  <div id="main">
			<adminleft:adminleft id="adminleft1" runat="server" />												
		  	<div id="right">
				<div class="tt18 bd rightTitle">
					<div class="icon"><img src="images/home_title.gif" /></div>
					<div class="text">商务服务</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">仓库</div>
				</div>
				
				<div class="rightArea txth22">
	                <div class="login_box" style="margin-top:8px; border:3px solid #d7e0ef; text-align:center;">
  		<fieldset style="border: 1px solid rgb(204, 204, 204); padding-bottom: 5px;">
  		<table width="100%" height="661" border="0" align="center" cellpadding="0" cellspacing="1">
         
          <tr>
            <td width="30%" height="38" align="right"><span class="red">*</span>&nbsp;标题</td>
            <td colspan="2" align="left"><input name="Username22" type="text" id="txttitle" size="30" runat="server" maxlength="50" /></td>
          </tr>
          <tr>
            <td height="38" align="right" bgcolor="#FAFAFA"><span class="red">*</span>&nbsp;标题颜色</td>
            <td colspan="2" align="left" bgcolor="#FAFAFA"><input name="Username2" type="text" id="txtcolor" size="30" runat="server" maxlength="50" /></td>
          </tr>
          <tr>
            <td height="38" align="right"><span class="red">*</span>&nbsp;图片</td>
            <td width="28%" align="left">
                <asp:FileUpload ID="FileUpload1" runat="server"  /><%--<input name="text" type="text" id="txtStorageType" size="30" runat="server" />--%></td>
            <td width="44%" align="left">&nbsp;<img id="IMG1" runat="server" src="" onerror="this.style.display = 'none'" width="204" height="174" /></td>
          <tr>
            <td height="38" align="right" bgcolor="#FAFAFA"><span class="red">图片链接</span></td>
            <td colspan="2" align="left" bgcolor="#FAFAFA"><input name="Username2" type="text" id="txtimagelink" size="30" runat="server" maxlength="50"  /></td>
          </tr>
          <tr>
            <td height="38" align="right" ><span class="red">主题1文字</span></td>
            <td colspan="2" align="left" ><input name="Username2" type="text" id="txtrow1" size="30" runat="server" maxlength="15" /></td>
          </tr>
          <tr>
            <td height="38" align="right" bgcolor="#FAFAFA"><span class="red"></span>&nbsp;主题1链接</td>
            <td colspan="2" align="left" bgcolor="#FAFAFA"><input name="Username2" type="text" id="txtlink1" size="30" runat="server" /></td>
          </tr>
          <tr>
            <td height="38" align="right" ><span class="red"></span>内容1文字&nbsp;</td>
            <td colspan="2" align="left" ><input name="Username2" type="text" id="txtrow2" size="30" runat="server" maxlength="18" /></td>
          </tr>
          <tr>
            <td height="38" align="right" bgcolor="#FAFAFA"><span class="red"></span>&nbsp;主题2文字1</td>
            <td colspan="2" align="left" bgcolor="#FAFAFA"><input name="Username2" type="text" id="txtrow3_1" size="30" runat="server" maxlength="16" /></td>
          </tr>
          <tr>
            <td height="38" align="right" ><span class="red"></span>&nbsp;内容2文字2</td>
            <td colspan="2" align="left" ><input name="Username2" type="text" id="txtrow3_2" size="30" runat="server" maxlength="18" /></td>
          </tr>
          <tr>
            <td height="38" align="right" bgcolor="#FAFAFA"><span class="red">主题2链接</span></td>
            <td colspan="2" align="left" bgcolor="#FAFAFA"><input name="Username2" type="text" id="txtlink3" size="30" runat="server" /></td>
          </tr>
          <tr>
            <td height="38" align="right" >
                <span class="red"></span>主题3文字1</td>
            <td align="left" ><input name="Username2" type="text" id="txtrow4_1" size="30" runat="server" maxlength="16" /></td>
            <td align="left" >&nbsp;</td>
          </tr>
          <tr>
            <td height="38" align="right" bgcolor="#FAFAFA"><span class="red">内容3文字2</span></td>
            <td align="left" bgcolor="#FAFAFA"><input name="Username2" type="text" id="txtrow4_2" size="30" runat="server" maxlength="18" /></td>
            <td align="left" bgcolor="#FAFAFA">&nbsp;</td>
          </tr>
          <tr>
            <td height="38" align="right" >
                主题3链接</td>
            <td colspan="2" align="left"><input name="Username2" type="text" id="txtlink4" size="30" runat="server" /></td>
          </tr>
          <tr>
            <td height="10" colspan="3" align="center" bgcolor="#FAFAFA"></td>
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
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="提交" />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="返回" /></td>
          </tr>
          <tr>
            <td height="32" align="right">&nbsp;</td>
            <td colspan="2" align="left">&nbsp;</td>
          </tr>
        </table>
  		</fieldset>
  </div>                
			    </div>			
			</div>			
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>
