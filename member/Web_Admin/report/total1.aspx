<%@ Page Language="VB" AutoEventWireup="false" CodeFile="total1.aspx.vb" Inherits="Web_Admin_report_total1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-color: #ffffff;
}
body,td,th {
	font-size: 12px;
}
-->
</style>

<script language="javascript">
function   showpos(){   
  document.all.divpos.scrollTop = 99999;   
} 

function CallServer1()
{   
    context = divpos;
    //context.innerHTML = "<table style='width:700px;height:220px;text-align:center'><tr><td>正在更新订单数据...</td></tr></table>";
    arg = "";
    <%= ClientScript.GetCallbackEventReference(me, "arg", "ReceiveServerData1", "context")%>;
}

//接受callback从服务器传来的数据
function ReceiveServerData1(result, context)
{
    context.innerHTML = result;
    
}


</script>


</head>
<body>
    <form id="form1" runat="server">
    <div id="divpos">
        <asp:Panel ID="Panel1" runat="server" >        
            <asp:Label ID="Label1" runat="server" Text="当前共有：" Font-Names="宋体" Font-Size="12px"></asp:Label>
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="宋体" Font-Size="12px" ForeColor="#FF8000"></asp:Label>
            <asp:Label ID="Label3" runat="server" Font-Names="宋体" Font-Size="12px" Text="条海运运价"></asp:Label>
            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="宋体" Font-Size="12px"
                ForeColor="#FF8000"></asp:Label>
            <asp:Label ID="Label4" runat="server" Font-Names="宋体" Font-Size="12px" Text="条空运运价"></asp:Label>
        </asp:Panel>
    </div>
    </form>
    
    
<script>
//这里是自动刷新页面的javascript函数
function ClientTimer()
{
    CallServer1();
    setTimeout("ClientTimer()",2000)
}
ClientTimer();
</script> 
</body>
</html>
