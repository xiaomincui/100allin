<%@ Page Language="C#" AutoEventWireup="true" CodeFile="usermemo.aspx.cs" Inherits="admin_userlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="css/master.css" rel="stylesheet" type="text/css" />
    <link href="css/userlist.css" rel="stylesheet" type="text/css" />
    <script language=javascript src=js/function.js></script>    
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
<!--

-->
</style>
<script type="text/javascript">
function txtsubmit()
{   
    context = tmain;
    arg = "submit|" + document.getElementById('TextBox1').value;
    
    document.getElementById('TextBox1').value = "";

    <%= ClientScript.GetCallbackEventReference(this, "arg", "ReceiveServerData", "context")%>;
}

function CheckBox1_CheckedChanged(a)
{
    context = ckb1;
    arg = "check|" + a;
    
    <%= ClientScript.GetCallbackEventReference(this, "arg", "ReceiveServerData2", "context")%>;
}

function ReceiveServerData(result, context)
{
    alert("成功");
    var resultArray = result.split("")
    if(resultArray[1]!="")
    {
        document.getElementById('TextBox2').value = resultArray[0];
    }
    else
    {
    
    }
    context.innerHTML = resultArray[1];
}

function ReceiveServerData2(result, context)
{
    
    alert("成功");
    context.innerHTML = result;
}
</script>
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
		  	    <div style="border:1px solid #D9D9D9;background:#F0F0F0;padding:  6px 5px 5px 10px;margin:0px 0px 7px 0px;">
		  	          <table>
		  	            <tr>
		  	                <td style="width: 280px" align="center"><strong>反馈记录</strong></td>
		  	                <td style="width: 421px"><asp:TextBox ID="TextBox1" runat="server" Width="500px" Height="72px"></asp:TextBox></td>
		  	                <td style="width: 182px"><div style=" padding:0px 0px 0px 40px">
		  	                    <%--<input type="button"  value="确定1" style=" height:24px;width:65px" onclick="submit()" />--%>
                                  
                                  <asp:Button ID="Button1" runat="server" Text="保存反馈记录" Height="24px" Width="65px" />
                                  <asp:Button ID="Button2" runat="server" Text="返回列表" Width="65px" OnClick="Button2_Click" /></div></td>
		  	            </tr>
                            <tr>
                                <td style="width: 280px" align="center">
                                    <strong>是否核实</strong></td>
                                <td style="width: 421px;float:left">
                                    <div id="ckb1">
                                    <input runat='server' type='radio' id='radio0' onclick='CheckBox1_CheckedChanged(0)' value = 'a' />待定<input runat='server' type='radio' id='radio1' onclick='CheckBox1_CheckedChanged(1)' value = 'b' />正确<input runat='server' type='radio' id='radio2' onclick='CheckBox1_CheckedChanged(2)' value = 'c' />错误
                                    </div>
                                </td>
                                <td style="width: 182px">
                                </td>
                            </tr>
                            
                            <tr>
                                <td style="width: 280px" align="center">
                                    <strong>跟进人</strong></td>
                                <td style="width: 421px;float:left">
                                    <div id="Div1">
                                    <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </td>
                                <td style="width: 182px">
                                <div style=" padding:0px 0px 0px 40px">
		  	                    <%--<input type="button"  value="确定1" style=" height:24px;width:65px" onclick="submit()" />--%>
                                    &nbsp;</div>
                                </td>
                            </tr>
		  	          
		  	          </table>
                      
                </div>
                
                <div id="tmain">
                <table cellspacing="0" cellpadding="3" rules="rows" bordercolor ="#D9D9D9" border="1" id="GridView1" style="border-width:1px;border-style:Solid;border-collapse:collapse; width:780px">
                    
                    
                    
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr style="height:35px">
                                <td width="210"><div style=" margin:0px 10px 0px 10px; width:120px"><%#Eval("Postdate").ToString()%></div></td>
                                <td><div style=" margin:0px 10px 0px 10px; width:500px;word-break:break-all;"><%#Eval("detail")%></div></td>
                            </tr>
                        
                        </ItemTemplate>
                    </asp:Repeater>
                    
                
                </table>
                
                </div>
                
                
                <input id="bntsub" runat="server" type="button" name="Submit" value="导出"  style="height:25px; padding-top:2px" /> 
		  	</div>		
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>
