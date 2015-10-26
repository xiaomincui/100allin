<%@ Page Language="C#" AutoEventWireup="true" CodeFile="date.aspx.cs" Inherits="test_date" %>

<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <BDP:BasicDatePicker ID="BasicDatePicker1" runat="server" DateFormat="yyyy-M-d" NoneButtonText="清空" TodayButtonText="今日" ReadOnly="true" MinimumDate="2010-01-01">
        </BDP:BasicDatePicker>
        
        
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
