<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNew.aspx.cs" Inherits="admin_message_Default" ValidateRequest="false" %>

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
  
  
    <LINK href="../css/WebResource.css" type=text/css rel=stylesheet />	
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
					<div class="text">新闻管理</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">添加新闻</div>
				</div>
				  
                  <div style="margin-bottom:10px">标题：<asp:TextBox ID="txtTitle" runat="server" Width="572px"></asp:TextBox></div>
                  <div style="margin-bottom:10px">
                      类型：<asp:DropDownList ID="DropDownList1" runat="server" Width="86px">
                                  <asp:ListItem  Value="5">新闻</asp:ListItem>
                                  <asp:ListItem  Value="11">船公司公告</asp:ListItem>
                  </asp:DropDownList></div>
                                 
                  <div style="margin-bottom:10px">
                  时间：<INPUT id=BasicDatePicker1_TextBox readOnly value="" name=BasicDatePicker1$TextBox style="width:70px;" runat="server" />
<IMG class=bdpButton id=BasicDatePicker1_Image style="BORDER: 0px; WIDTH: 28px; HEIGHT: 22px;" alt="点击日历选择日期" src="../images/WebResource.gif" border=10 />
<SCRIPT src="../js/WebResource.js" type=text/javascript></SCRIPT>
<SCRIPT src="../js/coolite.js" type=text/javascript></SCRIPT>
<SCRIPT src="../js/basicdatepicker.js" type=text/javascript></SCRIPT>
<SCRIPT type=text/javascript>
//<![CDATA[
var BasicDatePicker1 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker1",dateFormat:"yyyy-MM-dd",selectableWeekendDays:true,minimumDate:"1999/1/1",nullDateText:"",showWeekNumbers:true,showDaysInNextMonth:false,showDaysInPrevMonth:false,northImage:"images/arrow_up.gif",southImage:"images/arrow_down.gif",eastImage:"images/arrow_right.gif",westImage:"images/arrow_left.gif"}).applyTo({inputID:"BasicDatePicker1_TextBox",buttonID:"BasicDatePicker1_Image"}) : alert("日期控件出现问题，请刷新该页面");
//]]>
</SCRIPT>
                  </div></asp:TextBox>
                  
<%--                  <CE:Editor ID="Editor1" runat="server">
                  </CE:Editor>--%>
                  <div style="padding:10px 0px 10px 0px; overflow:hidden;">
<span style="display:none;"><asp:TextBox ID="TextBox3" runat="server" Width="600" TextMode="MultiLine" Rows="8"></asp:TextBox></span>
    <script language="javascript">
		gContentId = "TextBox3";//要载入内容的content ID
		OutputEditorLoading();
		</script>
    <iframe id="HtmlEditor" class="editor_frame" frameborder="0" marginheight="0" marginwidth="0" style="width:95%;height:700px;overflow:visible;" hideFocus></iframe>
    			
               <span style="display:none;"><asp:Button ID="Button1" runat="server" Text="保存关于我们" OnClick="Button1_Click" /></span></div> 
			<div><input type="button" name="Button1" value="保存新闻" id="Button2" onclick="DoProcess();document.getElementById('Button1').click();" />   </div> 
			
  <%--                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确定" />--%>
                  </div>			
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>
