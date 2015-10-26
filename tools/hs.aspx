<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hs.aspx.cs" Inherits="tools_hs" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="联系我们-Type" content="text/html; charset=utf-8" />
<title>环球运费网 - 常用工具 - HS编码</title>
<link href="/css/doc20110107.css" rel="stylesheet" type="text/css" />
<link href="css/answer.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/MSClass.js"></script>
</head>

<body>
<form id="form1" runat="server">
<div class="h_box">
<usertoptop20100711:usertoptop20100711 ID="usertoptop20100711_2" runat="server" />
<usertopmid20100711:usertopmid20100711 ID="usertopmid20100711_2" runat="server" />		
<usertopmenu20100711:usertopmenu20100711 ID="usertopmenu20100711_2" runat="server" />
</div>
<div class="main_container"><!--页面主体开始-->	
		<div style="width:750px; float:left; margin-bottom:12px;"></div>
					<div class="main_left" style="float:right; width:727px;"><!--左边开始-->
<div class="company">
	<div class="company_box">
		<table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
          <tr>
            <td height="32" align="center" style="font:14px '宋体';"><strong>HS编码</strong></td>
            </tr>
          <tr>
            <td height="1" bgcolor="#DDDDDD"></td>
            </tr>
        </table>

	    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
          <tr>
            <td height="10" align="center"></td>
          </tr>
          <tr>
            <td height="32"><table width="97%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#E1E1E1">
              <tr>
                <td height="32" colspan="3" align="center" bgcolor="#F9F9F9"><br />
                    <%--<asp:DropDownList ID="DropDownList1" runat="server">
                    
                    </asp:DropDownList>&nbsp;&nbsp;--%>
                    <asp:TextBox ID="TextBox2" runat="server" Width="80"></asp:TextBox>&nbsp;<asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" />

                  <table cellspacing="1" cellpadding="0" bgcolor="#FFEFF0" border="0" width="80%"  align="center">
                      <tr bgcolor="#FFEFF0" HEIGHT="20"> 
                        <td align=center width="65">编号</td>
                        <td align=center width="168">名称</td>
                      </tr>
                      <asp:Repeater ID="Repeater1" runat="server">
                      <ItemTemplate>
                      <TR HEIGHT="20" bgcolor="#ffffff" >
	                    <TD width=65 ><%#Eval("number")%></TD>
	                    <TD width=368><%#Eval("name")%></TD>
                    </TR>
                      </ItemTemplate>
                      </asp:Repeater>
                    </table>
                  
                  <br />
                  <br />
                  </td>
              </tr>
            </table>
                <table cellspacing="1" cellpadding="0" border="0" width="100%"  align="center">
  <tr> 
    <td align=center width="65" HEIGHT="20"></td>
    <td align=right width=520>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    </td>
  </tr>
</table>
</td>
          </tr>
          <tr>
            <td height="10"></td>
          </tr>
        </table>
	</div>
  </div>
		  </div>
					<!--左边结束-->	
					<div class="main_right" style="float: left; margin:0px;"><!--右边开始-->
					  <div class="c_us_l">
					    <useranswerleft:useranswerleft ID="useranswerleft_1" runat="server" />
					  </div>
					</div>
					<!--右边结束-->			
<userbottom100414:userbottom100414 ID="userbottom100414_1" runat="server" />
</div>
    </form>
</body>
</html>
