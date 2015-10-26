<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cargojilu.aspx.cs" Inherits="member_temp_add_air" validateRequest=false %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    
    <title>发布紧急询价</title>
    <link href="css/WebResource.css" type="text/css" rel="stylesheet" />	
    <link href="css/offices.css" rel="stylesheet" type="text/css" />
    
    

    <link href="/member/css/dialog.css" rel="stylesheet" type="text/css" />
    
    

    <link rel="stylesheet" type="text/css" href="editor/comm.css" />
    <script language="javascript" src="editor/all.js"></script>
    <script language="javascript" src="editor/editor.js"></script>
    <script language="javascript" src="editor/editor_toolbar.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div class="main_container">
		<memberheader:memberheader ID="memberheader1" runat="server" />
		<div class="center">
			<memberleft:memberleft ID="memberleft1" runat="server" />	
		  <div class="main">
		  <memberwelcome:memberwelcome ID="memberwelcome1" runat="server" />
		  <div class="friend_title"><strong>发布紧急询价</strong></div>	   
		  <div id="cities" name="cities" style="visibility:hidden"></div>



<div class="mainbox formbox" style="width:800px;">
						
						<table width="100%" cellspacing="0" cellpadding="0">
 <%-- <tr>
    <td width="22%" height="24" bgcolor="#E8F3FD" class="gray">用户名</td>
    <td width="78%" bgcolor="#E8F3FD"><span class="gray">
        <asp:Literal ID="Litusername" runat="server"></asp:Literal></span> <span class="blue"><a href="#">[退出登录]</a></span></td>
    </tr>--%>
  <tr>
    <td height="28">标题</td>
    <td><input name="textfield" type="text" size="40" id="Text1" runat="server" />
      
    </td>
    </tr>
  <tr>
    <td height="28">内容</td>
    <td>
    <textarea id="content" name="content" style=" display:none"  runat="server"></textarea>
    <script language="javascript">
		gContentId = "content";//要载入内容的content ID
		OutputEditorLoading();
		</script>
    <iframe id="HtmlEditor" class="editor_frame" frameborder="0" marginheight="0" marginwidth="0" style="width:90%;height:300px;overflow:visible;" hideFocus></iframe>
    </td>
  </tr>
  
  <tr>
    <td height="28">&nbsp;</td>
    <td><span class="btns">
        <input type="button" value="发布" onclick="DoProcess();document.getElementById('Button1').click()" />
        <div style=" display:none"><asp:Button ID="Button1" runat="server" Text="发表帖子" Width="81px" OnClick="Button1_Click" />&nbsp;</div></span><span class="gray"></span></td>
  </tr>
</table>

				  </div>


 
 
<table width="98%"  border="0" cellspacing="0" cellpadding="0">
  <TR>
    <TD height="30" align="center" class="news_font STYLE5"> 以上信息由企业自行提供，该企业负责信息内容的真实性、准确性和合法性。我们对此不承担任何保证责任</TD>
  </TR>
  <tr>
    <td>&nbsp;</td>
  </tr>
</table>
<br>
		  </div>
		</div>
		<memberfooter:memberfooter ID="memberfooter1" runat="server" />
	</div>
    </form>
</body>
</html>
