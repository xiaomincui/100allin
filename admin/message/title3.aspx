<%@ Page Language="C#" AutoEventWireup="true" CodeFile="title3.aspx.cs" Inherits="admin_userlist"  ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="../css/master.css" rel="stylesheet" type="text/css" />
    <link href="../css/userlist.css" rel="stylesheet" type="text/css" />
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
					<div class="icon"><img src="../images/home_title.gif" /></div>
					<div class="text">商务服务</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">仓库</div>
				</div>
				
				<div class="rightArea txth22">
	                <div class="login_box" style="margin-top:8px; border:3px solid #d7e0ef; text-align:center;">
  		<fieldset style="border: 1px solid rgb(204, 204, 204); padding-bottom: 5px;">
  		<table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" >
         
          <tr>
            <td width="30%" height="38" align="right"><span class="red">*</span>&nbsp;标题</td>
            <td colspan="2" align="left"><input name="Username22" type="text" id="txttitle" size="30" runat="server" maxlength="50" /></td>
          </tr>
          <tr>
            <td height="38" align="right" bgcolor="#FAFAFA"><span class="red">* 链接</span></td>
            <td colspan="2" align="left" bgcolor="#FAFAFA">
                      <input name="Username2" type="text" id="txtimagelink" size="30" runat="server" maxlength="50"  /></td>
          </tr>
              <tr>
                  <td align="right"  height="38">
                      * 正文</td>
                  <td align="left" colspan="2">
                      <input name="Username2" type="text" id="txtindex" size="30" runat="server" maxlength="50"  />&nbsp;
                      
                      </td>
              </tr>
              <tr>
                  <td align="right" bgcolor="#fafafa" height="38">
                      * 图片&nbsp;</td>
                  <td align="left" bgcolor="#fafafa" colspan="2">
                      <asp:FileUpload ID="FileUpload1" runat="server" />
                      <img src="../../images/bbs/showpic1.jpg" width="82px" height="62px" /></td>
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
