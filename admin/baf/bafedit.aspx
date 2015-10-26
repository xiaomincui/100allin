<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bafedit.aspx.cs" Inherits="admin_baf_bafedit" validateRequest=false %>

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
<body onload="eWebEditor1.setHTML(document.getElementById('myTextArea').value);">
<form id="form1" runat="server" name="myform">
    <div id="page">
		<div id="center">
			<admintop:admintop id="admintop1" runat="server" />
			<adminmenu:adminmenu id="adminmenu1" runat="server" />
		  <div id="main">
			<adminleft:adminleft id="adminleft1" runat="server" />												
		  	<div id="right">
				<div class="tt18 bd rightTitle">
					<div class="text">其它</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">BAF/CAF等附加费编辑</div>
				</div>	
				<div class="rightArea txth22">
                    <TABLE border="0" cellpadding="2" cellspacing="1">
                        <TR>
	                        <TD>
		                        <INPUT type="hidden" name="content1" value="">
		                        <IFRAME ID="eWebEditor1" src="/eweb/ewebeditor.htm?id=content1&style=coolblue" frameborder="0" scrolling="no" width="780" height="350"></IFRAME>
	                        </TD>
                        </TR>
                        <TR>
	                        <TD colspan=2 align=right>
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
	                        <INPUT type=submit value="提交"> 
	                        <INPUT type=reset value="重填"> 
	                        </TD>
                        </TR>
                        <TR>
	                        <TD><TEXTAREA cols=50 rows=5 id=myTextArea style="width:773px" runat="server"></TEXTAREA></TD>
                        </TR>
                        <TR>
	                        <TD colspan=2 align=right>
	                        <INPUT type=button value="取值(HTML)" onclick="myTextArea.value=eWebEditor1.getHTML();">                         
	                        <INPUT type=button value="取值(纯文本)" onclick="myTextArea.value=eWebEditor1.getText();"> 
	                        </TD>
                        </TR>
                    </TABLE>
                </div>			
			</div>			
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
    </div>
 
</form>

</body>
</html>
