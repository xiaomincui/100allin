<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addline.aspx.cs" Inherits="manage_priceneed_addline" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>缺失航线列表</title>
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
<div class=text>缺失运价</div></div>
<div class="tt14 bd rightSubTitle">
<div class=text>添加缺失航线</div></div>
<div class="rightArea txth22">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
<div style="border:1px solid #D9D9D9;background:#F0F0F0;padding:  6px 5px 5px 10px;margin:0px 0px 7px 0px;">
		  	          <table>
		  	            <tr>
		  	                <td><strong>方式</strong></td>
		  	                <td><div style=" padding:0px 0px 0px 20px">
<asp:RadioButtonList ID="rbl_ltype" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radiolist">
  <asp:ListItem Value="0" Selected="True">手工</asp:ListItem>
  <asp:ListItem Value="1">自动</asp:ListItem>
</asp:RadioButtonList>
 		  	                </div></td>
		  	            </tr>
		  	            
		  	            <tr>
		  	                <td><strong>类型</strong></td>
		  	                <td><div style=" padding:0px 0px 0px 20px">
                                  <asp:RadioButtonList ID="rbl_lftype" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radiolist">
                                      <asp:ListItem Value="8" Selected="True">整箱</asp:ListItem>
                                      <asp:ListItem Value="9">拼箱</asp:ListItem>
                                      <asp:ListItem Value="10">空运</asp:ListItem>
                                  </asp:RadioButtonList>
 		  	                </div></td>
		  	            </tr>
                       <tr>
		  	                <td><strong>起运港</strong></td>
		  	                <td><div style=" padding:0px 0px 0px 20px"><asp:TextBox ID="txt_lstartport" runat="server" Width="80"></asp:TextBox></div></td>
		  	                
		  	            </tr>    	
		  	            <tr>
		  	                <td><strong>航线</strong></td>
		  	                <td><div style=" padding:0px 0px 0px 20px">
                              <asp:RadioButtonList ID="rbl_line1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radiolist">
                                   <asp:ListItem Selected="True" Value="美加线">美加线</asp:ListItem>
                                  <asp:ListItem Value="欧地线">欧地线</asp:ListItem>
                                  <asp:ListItem Value="中南美线">中南美线</asp:ListItem>
                                  <asp:ListItem Value="日韩线">日韩线</asp:ListItem>
                                  <asp:ListItem Value="近洋线">近洋线</asp:ListItem>
                                  <asp:ListItem Value="非洲线">非洲线</asp:ListItem>
                                  <asp:ListItem Value="澳洲线">澳洲线</asp:ListItem>
                                  <asp:ListItem Value="中东印巴线">中东印巴线</asp:ListItem>
                                  <asp:ListItem Value="红海线">红海线</asp:ListItem>
                              </asp:RadioButtonList>
                              <asp:RadioButtonList ID="rbl_line2" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radiolist">
                                  <asp:ListItem Selected="True" Value="北美线">北美线</asp:ListItem>
                                  <asp:ListItem Value="欧地线">欧洲线</asp:ListItem>
                                  <asp:ListItem Value="南美线">南美线</asp:ListItem>
                                  <asp:ListItem Value="亚洲线">亚洲线</asp:ListItem>
                                  <asp:ListItem Value="非洲线">非洲线</asp:ListItem>
                                  <asp:ListItem Value="澳洲线">澳洲线</asp:ListItem>
                                  <asp:ListItem Value="国内航线">国内航线</asp:ListItem>
                              </asp:RadioButtonList>                              
                                  </div></td>
		  	                
		  	            </tr>
		  	            <tr>
		  	                <td><strong>优先级别</strong></td>
		  	                <td><div style=" padding:0px 0px 0px 20px">
                              <asp:RadioButtonList ID="rbl_order" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radiolist">
                                  <asp:ListItem>5</asp:ListItem>
                                  <asp:ListItem>4</asp:ListItem>
                                  <asp:ListItem Selected="True">3</asp:ListItem>
                                  <asp:ListItem>2</asp:ListItem>
                                  <asp:ListItem>1</asp:ListItem>
                                  <asp:ListItem>0</asp:ListItem>
                              </asp:RadioButtonList>
		  	                </div> </td>
		  	                
		  	            </tr>	
		  	            <tr>
		  	                <td><strong>热度</strong></td>
		  	                <td><div style=" padding:0px 0px 0px 20px"><asp:TextBox ID="txt_hot" runat="server" Text="0" Width="50"></asp:TextBox>
                                 </div> </td>
		  	                
		  	            </tr>	
		  	            <tr>
		  	                <td><strong>显示</strong></td>
		  	                <td><div style=" padding:0px 0px 0px 20px">
<asp:RadioButtonList ID="rbl_hidden" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radiolist">
  <asp:ListItem Value="0" Selected="True">是</asp:ListItem>
  <asp:ListItem Value="1">否</asp:ListItem>
</asp:RadioButtonList>
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
