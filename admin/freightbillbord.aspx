<%@ Page Language="C#" AutoEventWireup="true" CodeFile="freightbillbord.aspx.cs" Inherits="admin_freightbillbord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="css/master.css" rel="stylesheet" type="text/css" />
    <link href="css/searchwordslist.css" rel="stylesheet" type="text/css" />
    <LINK href="css/WebResource.css" type=text/css rel=stylesheet />
    <script language=javascript src=js/function.js></script>    
    <script type="text/javascript" language="javascript" src="../Web_Admin/include/calendar.js"></script>
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
					<div class="text">页面统计</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">页面数量统计</div>
				</div>	
				<div class="rightArea txth22" style="font-size:14px; line-height:25px;">
				<div>
				<div id="tipBoxSearch" class="tipBox">
				<b>筛选：</b>
				起始日期

<INPUT id=BasicDatePicker1_TextBox readOnly value="" name=BasicDatePicker1$TextBox style="width:70px;" runat="server" />
<IMG class=bdpButton id=BasicDatePicker1_Image style="BORDER: 0px; WIDTH: 28px; HEIGHT: 22px;" alt="点击日历选择日期" src="images/WebResource.gif" border=10 />
&nbsp;&nbsp;
结束日期
<INPUT id=BasicDatePicker2_TextBox readOnly value="" name=BasicDatePicker2$TextBox style="width:70px;" runat="server" />
<IMG class=bdpButton id=BasicDatePicker2_Image style="BORDER: 0px; WIDTH: 28px; HEIGHT: 22px;" alt="点击日历选择日期" src="images/WebResource.gif" border=10 />
&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" />
<SCRIPT src="js/WebResource.js" type=text/javascript></SCRIPT>
<SCRIPT src="js/coolite.js" type=text/javascript></SCRIPT>
<SCRIPT src="js/basicdatepicker.js" type=text/javascript></SCRIPT>
<SCRIPT type=text/javascript>
//<![CDATA[
var BasicDatePicker1 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker1",dateFormat:"yyyy-M-d",selectableWeekendDays:true,minimumDate:"1999/1/1",nullDateText:"",showWeekNumbers:true,showDaysInNextMonth:false,showDaysInPrevMonth:false,northImage:"images/arrow_up.gif",southImage:"images/arrow_down.gif",eastImage:"images/arrow_right.gif",westImage:"images/arrow_left.gif"}).applyTo({inputID:"BasicDatePicker1_TextBox",buttonID:"BasicDatePicker1_Image"}) : alert("日期控件出现问题，请刷新该页面");
var BasicDatePicker2 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker2",dateFormat:"yyyy-M-d",selectableWeekendDays:true,minimumDate:"1999/1/1",nullDateText:"",showWeekNumbers:true,showDaysInNextMonth:false,showDaysInPrevMonth:false,northImage:"images/arrow_up.gif",southImage:"images/arrow_down.gif",eastImage:"images/arrow_right.gif",westImage:"images/arrow_left.gif"}).applyTo({inputID:"BasicDatePicker2_TextBox",buttonID:"BasicDatePicker2_Image"}) : alert("日期控件出现问题，请刷新该页面");
//]]>
</SCRIPT>
	            </div>
				</div>
                <table>
                    <tr style="font-weight:bold;">
                        <td width="40">序号</td>
                        <td width="100">编号</td>
                        <td>用户名</td>
                        <td>真实姓名</td>
                        <td>公司</td>
                        <td>运价发布数量</td>                                                                        
                        <td></td>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                    <tr>
                        <td><%#this.Repeater1.Items.Count + 1%></td>
                        <td><%#Eval("userid").ToString()%></td>
                        <td><%#Eval("username").ToString()%></td>
                        <td><%#Eval("realname").ToString()%></td>
                        <td><%#Eval("companyname").ToString()%></td>
                        <td><%#Eval("c").ToString()%></td>
                    </tr>
                        </ItemTemplate>
                    </asp:Repeater>  
                </table>
                
 			    </div>			
			</div>			
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>
