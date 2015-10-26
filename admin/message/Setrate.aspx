<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Setrate.aspx.cs" Inherits="admin_message_Setrate" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="../css/master.css" rel="stylesheet" type="text/css" />
    <link href="../css/userlist.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../js/function.js" type="text/javascript"></script>   
     
<link rel="stylesheet" href="kindeditor/themes/default/default.css" />
<link rel="stylesheet" href="kindeditor/plugins/code/prettify.css" />
<script charset="utf-8" src="kindeditor/kindeditor.js"></script>
<script charset="utf-8" src="kindeditor/lang/zh_CN.js"></script>
<script charset="utf-8" src="kindeditor/plugins/code/prettify.js"></script>
<script>
	KindEditor.ready(function(K) {
		var editor1 = K.create('#content1', {
			cssPath : 'kindeditor/plugins/code/prettify.css',
			uploadJson : 'kindeditor/asp.net/upload_json.ashx',
			fileManagerJson : 'kindeditor/asp.net/file_manager_json.ashx',
			allowFileManager : true,
			afterCreate : function() {
				var self = this;
				K.ctrl(document, 13, function() {
					self.sync();
					K('form[name=example]')[0].submit();
				});
				K.ctrl(self.edit.doc, 13, function() {
					self.sync();
					K('form[name=example]')[0].submit();
				});
			}
		});
		prettyPrint();
	});
</script>
    
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
                  
                  <div>

<textarea id="content1"  style="width:778px;height:600px;visibility:hidden;" runat="server"></textarea>
    			
               <span style="display:none;"><asp:Button ID="Button1" runat="server" Text="保存关于我们" OnClick="Button1_Click" /></span></div> 
			<div><input type="button" name="Button1" value="保存新闻" id="Button2" onclick="document.getElementById('Button1').click();" />   </div> 
                  
                  </div>			
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
</form>
</body>
</html>
