<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tax.aspx.cs" Inherits="tools_hs" %>
<%@ OutputCache Duration="3600" Location="Any" VaryByCustom="browser" VaryByParam="none" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>环球运费网 - 常用工具 - 海关税率</title>
<link href="/css2/nav.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/MSClass.js"></script>
</head>

<body>
<form id="form2" runat="server">
<div class="h_box">
<usertoptop20100711:usertoptop20100711 ID="usertoptop20100711_2" runat="server" />
<usertopmid20100711:usertopmid20100711 ID="usertopmid20100711_2" runat="server" />		
<usertopmenu20100711:usertopmenu20100711 ID="usertopmenu20100711_2" runat="server" />
</div>
<div class="main_container"><!--页面主体开始-->	
		<div style="width:750px; float:left; margin-bottom:6px;"><a href="/">首页</a> > 海关税率</div>
					<div class="main_left" style="float:right; width:727px;"><!--左边开始-->
<div class="company">
	<div class="company_box">
			  <div class="news_bar">
				<div class="bar_box" >
						<h1>海关税率</h1>
	    <div style="margin:5px 0px 10px 0px; border-top:1px #DDDDDD solid; width:100%; height:1px;overflow:hidden;" ></div>		
						<table width="97%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#E1E1E1">
              <tr>
                <td height="32" colspan="3" align="center" bgcolor="#F9F9F9"><br />
                    <%--<asp:DropDownList ID="DropDownList1" runat="server">
                    
                    </asp:DropDownList>&nbsp;&nbsp;--%>
                    <asp:TextBox ID="TextBox2" runat="server" Width="80"></asp:TextBox>&nbsp;<asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" />
                <table cellspacing="1" cellpadding="0" border="0" width="80%"  align="center">
  <tr> 
    <td align=center width="65" HEIGHT="20"></td>
    <td align=right width=520>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    </td>
  </tr>
</TABLE>



<table cellspacing="1" cellpadding="0" bgcolor="#014c8b" border="1" width="95%"  align="center">
  <tr bgcolor="#c1dcea" HEIGHT="20"> 
    <td rowspan="2" align=center width="65">编号</td>
    <td rowspan="2" align=center width="168">名称</td>
    <td colspan="2" align=center>进口税率</td>
    <td rowspan="2" align=center width="56">出口税率</td>
    <td rowspan="2" align=center width="55">增值税率</td>
    <td rowspan="2" align=center width="52">消费税</td>
    <td rowspan="2" align=center width="53">计量单位</td>
    <td rowspan="2" align=center width="53">监管条件</td>
  </tr>
  <tr bgcolor="#c1dcea" HEIGHT="20"> 
    <td align=center width="52">优惠</td>
    <td align=center width="48">普通</td>
  </tr>



<asp:Repeater ID="Repeater1" runat="server">
                      <ItemTemplate>
                      
                    <TR HEIGHT="20" bgcolor="#ffffff" >
	<TD width=65 ><%#Eval("编号")%></TD>
	<TD width=168><%#Eval("名称")%></TD>
	<TD width=52 align=center ><%#Eval("优惠")%>&nbsp;</TD>
	<TD width=48 align=center><%#Eval("普通")%>&nbsp;</TD>
	<TD width=56 align=center><%#Eval("出口税率")%>&nbsp;</TD>
	<TD width=55 align=center><%#Eval("增值税率")%>&nbsp;</TD>
	<TD width=52 align=center><%#Eval("消费税")%>&nbsp;</TD>
	<TD width=53 align=center><%#Eval("计量单位")%>&nbsp;</TD>
	<TD width=53 align=center><%#Eval("监管条件")%>&nbsp;</TD>
</TR>
                      </ItemTemplate>
                      </asp:Repeater>


</TABLE>


                  
                  
                  <br />
                  <br />
                  </td>
              </tr>
            </table>
		      </div>
				 
		  </div><!--左边结束-->	
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