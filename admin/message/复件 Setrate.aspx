<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Setrate.aspx.cs" Inherits="admin_message_Setrate" ValidateRequest="false"%>

<%@ Register Assembly="CuteEditor.ImageEditor" Namespace="CuteEditor.ImageEditor"
    TagPrefix="iws" %>

<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="../css/master.css" rel="stylesheet" type="text/css" />
    <link href="../css/userlist.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../js/function.js" type="text/javascript"></script>   
     
    <script language="javascript" src="editor/all.js"></script>
    <script language="javascript" src="editor/editor.js"></script>
    <script language="javascript" src="editor/editor_toolbar.js"></script>
    <link rel="stylesheet" type="text/css" href="editor/comm.css" />    
    
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
					<div class="text">信息管理</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">输入汇率</div>
				</div>
				 <div style="padding-bottom:15px">注意：网站首页显示，选取表格中的“基准价”，<a href="http://www.boc.cn/sourcedb/whpj/" target="_blank">汇率表格请参考这里</a></div> 
                  <div style="padding-bottom:15px">网站首页显示： 
                  美元 <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox>
                  欧元 <asp:TextBox ID="TextBox2" runat="server" Width="100px"></asp:TextBox>
                  日元 <asp:TextBox ID="TextBox3" runat="server" Width="100px"></asp:TextBox>
                  英镑 <asp:TextBox ID="TextBox4" runat="server" Width="100px"></asp:TextBox>
                  
                  </div>
                      </div>
                  
<%--                  <CE:Editor ID="Editor1" runat="server">
                  </CE:Editor>
                  
                  <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确定" />--%>
                  
                  <div style="padding:10px 0px 10px 0px; overflow:hidden;">
<span style="display:none;"><asp:TextBox ID="TextBox5" runat="server" Width="600" TextMode="MultiLine" Rows="8"></asp:TextBox></span>
    <script language="javascript">
		gContentId = "TextBox5";//要载入内容的content ID
		OutputEditorLoading();
		</script>
    <iframe id="HtmlEditor" class="editor_frame" frameborder="0" marginheight="0" marginwidth="0" style="width:95%;height:700px;overflow:visible;" hideFocus></iframe>
    			
               <span style="display:none;"><asp:Button ID="Button1" runat="server" Text="保存关于我们" OnClick="Button1_Click" /></span></div> 
			<div><input type="button" name="Button1" value="保存新闻" id="Button2" onclick="DoProcess();document.getElementById('Button1').click();" />   </div> 
                  
                  </div>			
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>
