<%@ Page Language="C#" AutoEventWireup="true" CodeFile="date2.aspx.cs" Inherits="test_date2" %>

<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<link rel="stylesheet" type="text/css" href="/js/date/css/w.css"></link>
<title>
	无标题页
</title></head>
<body>
    <form id="form1" runat="server">

    
<div id="BasicDatePicker1" class="basicdatepicker" style="display:inline;">
<!-- ClientID: BasicDatePicker1, Version: 1.4.1.41500 -->

<input name="BasicDatePicker1$TextBox" type="text" value="2010-1-19" readonly="readonly" id="BasicDatePicker1_TextBox" />
<img id="BasicDatePicker1_Image" class="bdpButton" alt="" border="10" src="/js/date/images/button.gif" style="height:22px;width:28px;border-width:0px;" />
<script type="text/javascript" src="/js/date/js/w.js"></script>
<script type="text/javascript" src="/js/date/js/w1.js"></script>
<script type="text/javascript" src="/js/date/js/w2.js"></script>

<script type="text/javascript">
//<![CDATA[
var d = new Date();
var BasicDatePicker1 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker1",dateFormat:"yyyy-M-d",showCalendarOnTextBoxFocus:true,minimumDate:d.getFullYear()+"/"+(d.getMonth()+1)+"/"+d.getDate(),todayButtonText:"今日",noneButtonText:"清空",northImage:"/js/date/images/arrow_down.gif",southImage:"/js/date/images/arrow_up.gif",eastImage:"/js/date/images/arrow_right.gif",westImage:"/js/date/images/arrow_left.gif"}).applyTo({inputID:"BasicDatePicker1_TextBox",buttonID:"BasicDatePicker1_Image"}) : alert("无法载入日期控件，请联系网站客服！");
//]]>
</script>

    &nbsp;<br />
    <br />
    <br />
    <br />
</div>
        <br />
        <br />


    </form>
</body>
</html>

