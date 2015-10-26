<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="manage_priceneed_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <title>主页搜索框 Ajax交互</title>
<style type="text/css">
</style>
<link href="/js/autocomplete/port.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" language="javascript" src="/js/autocomplete/prototype.js"></script>
<script type="text/javascript" language="javascript" src="/js/autocomplete/port.js"></script>
</head>
<body>
    <div style="margin: 0 auto; width: 950px; text-align: center;">
        <br />
        <br />
        <input type="text" id="loading_prot_txt" name="loading_prot_txt" style="border: 1px solid #000000;
            width: 200px"  onkeyup="autowords(this.id,event);" onkeydown="if(event.keyCode==13){return false;}"/>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <input type="text" id="destination_prot_txt" name="destination_prot_txt" style="border: 1px solid #000000;
            width: 200px" onkeyup="autowords(this.id,event);"/>
            
         <input type="submit" value="提交" onclick="alert('aaa');" />   
        <br />
        <span id="messages"></span>
    </div>
</body>
</html>
