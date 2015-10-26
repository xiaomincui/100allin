<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Storage.aspx.cs" Inherits="admin_userlist" %>

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
  		<table width="100%" height="661" border="0" align="center" cellpadding="0" cellspacing="1">
         
          <tr>
            <td width="30%" height="38" align="right"><span class="red">*</span>&nbsp;仓库名称</td>
            <td colspan="2" align="left"><input name="Username22" type="text" id="txtStorage" size="30" runat="server" />
            &nbsp;&nbsp;<span class="gray">用户名由1-15个字符组成，支持中文，注册成功后用户名将不可修</span></td>
          </tr>
          <tr>
            <td height="38" align="right" bgcolor="#FAFAFA"><span class="red">*</span>&nbsp;所在城市</td>
            <td colspan="2" align="left" bgcolor="#FAFAFA"><input name="Username2" type="text" id="txtCity" size="30" runat="server" /></td>
          </tr>
          <tr>
            <td height="38" align="right"><span class="red">*</span>&nbsp;仓库类型</td>
            <td width="28%" align="left">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="99px">
                    <asp:ListItem>普通</asp:ListItem>
                    <asp:ListItem>保税</asp:ListItem>
                    <asp:ListItem>立体</asp:ListItem>
                    <asp:ListItem>冷库</asp:ListItem>
                    <asp:ListItem>危品</asp:ListItem>
                    <asp:ListItem>其他</asp:ListItem>
                </asp:DropDownList>
            <%--<input name="text" type="text" id="txtStorageType" size="30" runat="server" />--%></td>
            <td width="44%" align="left">&nbsp;</td>
          </tr>
          <tr>
            <td height="38" align="right" bgcolor="#FAFAFA"><span class="red"></span>仓库照片</td>
            <td colspan="2" align="left" bgcolor="#FAFAFA">
                <asp:FileUpload ID="FileUpload1" runat="server"  />
            &nbsp;&nbsp;<span class="gray">您最多可以上传5张照片<img id="IMG1" runat="server" src="" onerror="this.style.display = 'none'" /></span></td>
          </tr>
          <tr>
            <td height="38" align="right" ><span class="red"></span>&nbsp;仓库照片</td>
            <td colspan="2" align="left" >
                <asp:FileUpload ID="FileUpload2" runat="server" />
            &nbsp;&nbsp;<span class="gray">您最多可以上传5张照片<img id="IMG2" runat="server" src="" onerror="this.style.display = 'none'" /></span></td>
          </tr>
          <tr>
            <td height="38" align="right" bgcolor="#FAFAFA"><span class="red"></span>&nbsp;仓库照片</td>
            <td colspan="2" align="left" bgcolor="#FAFAFA">
                <asp:FileUpload ID="FileUpload3" runat="server" />
            &nbsp;&nbsp;<span class="gray">您最多可以上传5张照片<img id="IMG3" runat="server" src="" onerror="this.style.display = 'none'" /></span></td>
          </tr>
          <tr>
            <td height="38" align="right" ><span class="red"></span>&nbsp;仓库照片</td>
            <td colspan="2" align="left" >
                <asp:FileUpload ID="FileUpload4" runat="server" />
            &nbsp;&nbsp;<span class="gray">您最多可以上传5张照片<img id="IMG4" runat="server" src="" onerror="this.style.display = 'none'" /></span></td>
          </tr>
          <tr>
            <td height="38" align="right" bgcolor="#FAFAFA"><span class="red"></span>&nbsp;仓库照片</td>
            <td colspan="2" align="left" bgcolor="#FAFAFA">
                <asp:FileUpload ID="FileUpload5" runat="server" />
            &nbsp;&nbsp;<span class="gray">您最多可以上传5张照片<img id="IMG5" runat="server" src="" onerror="this.style.display = 'none'" /></span></td>
          </tr>
          <tr>
            <td height="38" align="right"><span class="red">*</span>&nbsp;仓库面积</td>
            <td colspan="2" align="left">&nbsp;仓储面积
              <input name="Username423" type="text" id="txtStoragearea" size="10" runat="server" />
              平方米&nbsp;&nbsp;&nbsp;&nbsp;场地面积
              <input name="Username4232" type="text" id="txtFieldarea" size="10" runat="server" />
              平方米</td>
          </tr>
          <tr>
            <td height="38" align="right" bgcolor="#FAFAFA">
                <span class="red"></span>仓库价格</td>
            <td align="left" bgcolor="#FAFAFA"><input name="Username6" type="text" id="txtValue" size="30" runat="server"  /></td>
            <td align="left" bgcolor="#FAFAFA">&nbsp;</td>
          </tr>
          <tr>
            <td height="38" align="right"><span class="red">*</span>&nbsp;详细地址</td>
            <td align="left"><input name="Username7" type="text" id="txtAddress" runat="server" style="width: 350px" /></td>
            <td align="left">&nbsp;</td>
          </tr>
          <tr>
            <td height="38" align="right" bgcolor="#FAFAFA">上传地图</td>
            <td colspan="2" align="left" bgcolor="#FAFAFA"><input name="Username424" type="text" id="Username424" size="10" />
                <input type="submit" name="Submit3" value="浏览.." /></td>
          </tr>
          <tr>
            <td height="38" align="right"><span class="red">*</span>&nbsp;仓库简介</td>
            <td colspan="2" align="left"><textarea name="textarea" cols="30" rows="5" id="txtIntro" runat="server"　style="width: 350px" ></textarea><span class="gray">业务描述的字数要求不超过360个汉字<br />
              </span></td>
          </tr>
          <tr>
            <td height="38" align="right" bgcolor="#FAFAFA"><span class="red">*<span style="color: #000000"> 公司名称</span></span></td>
            <td colspan="2" align="left" bgcolor="#FAFAFA"><input name="Username82" type="text" id="txtCompany" size="30" runat="server" /></td>
          </tr>
          <tr>
            <td height="38" align="right">
                <span style="color: #ff0000"></span><span style="color: #ff0000">*</span> 联系人&nbsp;</td>
            <td align="left"><input name="Username8" type="text" id="txtlinkmen" size="30" runat="server" /></td>
            <td align="left">&nbsp;</td>
          </tr>
          <tr>
            <td height="38" align="right" bgcolor="#FAFAFA">
                <span style="color: #ff0000">*</span> 联系电话&nbsp;</td>
            <td align="left" bgcolor="#FAFAFA"><input name="Username9" type="text" id="txtPhone" size="30" runat="server" /></td>
            <td align="left" bgcolor="#FAFAFA">&nbsp;</td>
          </tr>
          <tr>
            <td height="38" align="right">
                上传营业执照副本</td>
            <td colspan="2" align="left"><input name="Username4242" type="text" id="Username4242" size="10" />
                <input type="submit" name="Submit32" value="浏览.." />
            &nbsp;&nbsp;<span class="gray">您也可以选择将营业执照副本发传真至021-53853022</span></td>
          </tr>
              <tr>
                  <td align="right" height="38">
                      是否通过</td>
                  <td align="left" colspan="2">
                      <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" /></td>
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
