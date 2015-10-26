<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adduser.aspx.cs" Inherits="manage_user_adduser" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>编辑用户账户</title>
    <link href="/manage/css/master.css" type="text/css" rel="stylesheet" />
    <link href="/js/date/css/w.css" type="text/css" rel="stylesheet" />	
	<script type="text/javascript" src="/js/date/w.js"></script>
	<script type="text/javascript" src="/js/date/w1.js"></script>
	<script type="text/javascript" src="/js/date/w2.js"></script>
<script language="javascript" src="/manage/js/function.js"></script>
<link href="/js/autocomplete/port.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" language="javascript" src="/js/autocomplete/prototype.js"></script>
<script type="text/javascript" language="javascript" src="/js/autocomplete/startport.js"></script>
<script type="text/javascript" language="javascript">
function selectftype(){

var obj = document.getElementsByName("rbl_lftype");
var obj1 = document.getElementById("rbl_line1");
var obj2 = document.getElementById("rbl_line2");
var valuel; // 选中值
for(var i=0; i<obj.length; i++)
{
    if(obj[i].checked)
    {
        value = obj[i].value;
    }
}
    
if (value == "8")
{
    obj1.style.display = "";
    obj2.style.display = "none";
}
else if (value == "9")
{
    obj1.style.display = "";
    obj2.style.display = "none";
}
else if (value == "10")
{
    obj1.style.display = "none";
    obj2.style.display = "";
}
}
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
			<managertop:managertop id="managertop1" runat="server" />
			<managermenu:managermenu id="managermenu1" runat="server" />
		  <div id="main">
			<managerleft:managerleft id="managerleft1" runat="server" />												
		  	<div id=right>
<div class="tt18 bd rightTitle">
<div class=icon><img src="/manage/images/home_title.gif"></div>
<div class=text>用户</div></div>
<div class="tt14 bd rightSubTitle">
<div class=text>编辑用户账户</div></div>
<div class="rightArea txth22">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
<div style="border:1px solid #D9D9D9;background:#F0F0F0;padding:  6px 5px 5px 10px;margin:0px 0px 7px 0px;">
		  	          <table>
		  	            <tr>
		  	                <td><strong>姓名</strong></td>
		  	                <td><div style=" padding:0px 0px 0px 20px">
                                  <asp:Literal ID="ltrRealname" runat="server"></asp:Literal></div>
		  	                </td>
		  	            </tr>	
		  	            <tr>
		  	                <td><strong>公司名称</strong></td>
		  	                <td><div style=" padding:0px 0px 0px 20px">
		  	                    <asp:Literal ID="ltrCompanyName" runat="server"></asp:Literal></div>
		  	                </td>
		  	            </tr>	
		  	            <tr>
		  	                <td><strong>电话</strong></td>
		  	                <td><div style=" padding:0px 0px 0px 20px">
		  	                <asp:Literal ID="ltrPhone" runat="server"></asp:Literal></div>
		  	                </td>
		  	            </tr>	
		  	            <tr>
		  	                <td><strong>手机</strong></td>
		  	                <td><div style=" padding:0px 0px 0px 20px">
		  	                <asp:Literal ID="ltrMovephone" runat="server"></asp:Literal></div>
		  	                </td>
		  	            </tr>			  	            		  	            		  	            
		  	            <tr>
		  	                <td><strong>安运通级别</strong></td>
		  	                <td><div style=" padding:0px 0px 0px 20px">
<asp:RadioButtonList ID="rbl_star_allin" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radiolist">
  <asp:ListItem Value="0" Selected="True">非安运通</asp:ListItem>
  <asp:ListItem Value="1">1级</asp:ListItem>
  <asp:ListItem Value="2">2级</asp:ListItem>
  <asp:ListItem Value="3">3级</asp:ListItem>
  <asp:ListItem Value="4">4级</asp:ListItem>
  <asp:ListItem Value="5">5级</asp:ListItem>
</asp:RadioButtonList>
 		  	                </div></td>
		  	            </tr>	
		  	            <tr>
		  	                <td><strong>证件</strong></td>
		  	                <td><div style=" padding:0px 0px 0px 20px">
                                  <asp:CheckBox ID="cb_z_yingyezhizhao" runat="server" Text="营业执照" />
                                  <asp:CheckBox ID="cb_z_shenfenzheng" runat="server" Text="身份证" />
                                  <asp:CheckBox ID="cb_z_nvocc" runat="server" Text="NVOCC" />
                                  <asp:CheckBox ID="cb_z_kongyuntongpai" runat="server" Text="空运铜牌" />
 		  	                </div></td>
		  	            </tr>	 		  	            	  	             	            	  	          
		  	          </table>
               </div>



<div class="buttons">
    <asp:Button ID="Button1" runat="server" Text="保存" OnClick="Button1_Click" Width="100" Height="30" />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</div>

                </ContentTemplate>
                </asp:UpdatePanel>
<asp:UpdateProgress ID="UpdateProgress1" runat="server">
<ProgressTemplate>
<div style="position:absolute; top:300px; left:600px; border:1px solid #999999; background:#FFFFFF; text-align:center; padding:10px;">
正在处理，请稍候...<br/>
<img src="/member/images/loading5.gif" alt=""/>
</div>
</ProgressTemplate>
</asp:UpdateProgress>	
                    </div></div>			
		  </div>
		<managerbottom:managerbottom id="managerbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>
