<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pricecount.aspx.cs" Inherits="admin_pricecount" %>

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
					<div class="text">运价/货盘管理</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">运价数量统计</div>
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
				<div class="tt14" style="padding:0px 0px 10px 0px;">
				    起运港：
				    <a href="pricecount.aspx?pol1=&pol2=&ltime1=<%=ltime1 %>&ltime2=<%=ltime2 %>&star_allin=<%=star_allin %>" style="font-weight:<%=(pol1==""?"bold":"") %>">所有</a>
				    <a href="pricecount.aspx?pol1=shanghai&pol2=上海&ltime1=<%=ltime1 %>&ltime2=<%=ltime2 %>&star_allin=<%=star_allin %>" style="font-weight:<%=(pol1=="shanghai"?"bold":"") %>">上海</a>
				    <a href="pricecount.aspx?pol1=shenzhen&pol2=深圳&ltime1=<%=ltime1 %>&ltime2=<%=ltime2 %>&star_allin=<%=star_allin %>" style="font-weight:<%=(pol1=="shenzhen"?"bold":"") %>">深圳</a>
				    <a href="pricecount.aspx?pol1=qingdao&pol2=青岛&ltime1=<%=ltime1 %>&ltime2=<%=ltime2 %>&star_allin=<%=star_allin %>" style="font-weight:<%=(pol1=="qingdao"?"bold":"") %>">青岛</a>
				    <a href="pricecount.aspx?pol1=ningbo&pol2=宁波&ltime1=<%=ltime1 %>&ltime2=<%=ltime2 %>&star_allin=<%=star_allin %>" style="font-weight:<%=(pol1=="ningbo"?"bold":"") %>">宁波</a>
				    <a href="pricecount.aspx?pol1=xiamen&pol2=厦门&ltime1=<%=ltime1 %>&ltime2=<%=ltime2 %>&star_allin=<%=star_allin %>" style="font-weight:<%=(pol1=="xiamen"?"bold":"") %>">厦门</a>
				    <a href="pricecount.aspx?pol1=tianjin&pol2=天津&ltime1=<%=ltime1 %>&ltime2=<%=ltime2 %>&star_allin=<%=star_allin %>" style="font-weight:<%=(pol1=="tianjin"?"bold":"") %>">天津</a>
				    <a href="pricecount.aspx?pol1=dalian&pol2=大连&ltime1=<%=ltime1 %>&ltime2=<%=ltime2 %>&star_allin=<%=star_allin %>" style="font-weight:<%=(pol1=="dalian"?"bold":"") %>">大连</a>
				    <a href="pricecount.aspx?pol1=lianyungang&pol2=连云港&ltime1=<%=ltime1 %>&ltime2=<%=ltime2 %>&star_allin=<%=star_allin %>" style="font-weight:<%=(pol1=="lianyungang"?"bold":"") %>">连云港</a>
				    <a href="pricecount.aspx?pol1=guangzhou&pol2=广州&ltime1=<%=ltime1 %>&ltime2=<%=ltime2 %>&star_allin=<%=star_allin %>" style="font-weight:<%=(pol1=="guangzhou"?"bold":"") %>">广州</a>
				    <a href="pricecount.aspx?pol1=yantian&pol2=盐田&ltime1=<%=ltime1 %>&ltime2=<%=ltime2 %>&star_allin=<%=star_allin %>" style="font-weight:<%=(pol1=="yantian"?"bold":"") %>">盐田</a>
				    <a href="pricecount.aspx?pol1=yantai&pol2=烟台&ltime1=<%=ltime1 %>&ltime2=<%=ltime2 %>&star_allin=<%=star_allin %>" style="font-weight:<%=(pol1=="yantai"?"bold":"") %>">烟台</a>
				    <a href="pricecount.aspx?pol1=yantai&pol2=北京&ltime1=<%=ltime1 %>&ltime2=<%=ltime2 %>&star_allin=<%=star_allin %>" style="font-weight:<%=(pol1=="yantai"?"bold":"") %>">北京</a>
				    <a href="pricecount.aspx?pol1=yantai&pol2=香港&ltime1=<%=ltime1 %>&ltime2=<%=ltime2 %>&star_allin=<%=star_allin %>" style="font-weight:<%=(pol1=="yantai"?"bold":"") %>">香港</a>
				</div>
				<div class="tt14" style="padding:0px 0px 10px 0px;">
				    会员：&nbsp;&nbsp;&nbsp;&nbsp;
				    <a href="pricecount.aspx?pol1=<%=pol1 %>&pol2=<%=pol2 %>&ltime1=<%=ltime1 %>&ltime2=<%=ltime2 %>&star_allin=" style="font-weight:<%=(star_allin==""?"bold":"") %>">所有</a>
				    <a href="pricecount.aspx?pol1=<%=pol1 %>&pol2=<%=pol2 %>&ltime1=<%=ltime1 %>&ltime2=<%=ltime2 %>&star_allin=1" style="font-weight:<%=(star_allin=="1"?"bold":"") %>">安运通</a>
				    <a href="pricecount.aspx?pol1=<%=pol1 %>&pol2=<%=pol2 %>&ltime1=<%=ltime1 %>&ltime2=<%=ltime2 %>&star_allin=0" style="font-weight:<%=(star_allin=="0"?"bold":"") %>">非安运通</a>
				</div>		
				<table>
				<tr>
				<td valign="top" width="250">
                <table>
                    <tr style="font-weight:bold;">
                        <td colspan="4">整箱运价</td>
                    </tr>                
                    <tr style="font-weight:bold;">
                        <td width="40">序号</td><td width="80">航线</td><td  align=right>运价数量</td><td></td>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                    <tr>
                        <td><%#this.Repeater1.Items.Count + 1%></td>
                        <td><%#Eval("u").ToString()%></td>
                        <td  align=right><%#Eval("c").ToString()%></td>
                        <td>
                        </td>
                    </tr>
                        </ItemTemplate>
                    </asp:Repeater>  
                </table>
				</td>
				<td valign="top" width="250">
                  <table>
                    <tr style="font-weight:bold;">
                        <td colspan="4">拼箱运价</td>
                    </tr>                  
                    <tr style="font-weight:bold;">
                        <td width="40">序号</td><td width="80">航线</td><td  align=right>运价数量</td><td></td>
                    </tr>
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                    <tr>
                        <td><%#this.Repeater2.Items.Count + 1%></td>
                        <td><%#Eval("u").ToString()%></td>
                        <td  align=right><%#Eval("c").ToString()%></td>
                        <td>
                        </td>
                    </tr>
                        </ItemTemplate>
                    </asp:Repeater>  
                </table>   
				</td>
				<td valign="top">
                  <table>
                    <tr style="font-weight:bold;">
                        <td colspan="4">空运运价</td>
                    </tr>                  
                    <tr style="font-weight:bold;">
                        <td width="40">序号</td><td width="80">航线</td><td  align=right>运价数量</td><td></td>
                    </tr>
                    <asp:Repeater ID="Repeater3" runat="server">
                        <ItemTemplate>
                    <tr>
                        <td><%#this.Repeater3.Items.Count + 1%></td>
                        <td><%#Eval("u").ToString()%></td>
                        <td  align=right><%#Eval("c").ToString()%></td>
                        <td>
                        </td>
                    </tr>
                        </ItemTemplate>
                    </asp:Repeater>  
                </table>   
				</td>								
				</tr>
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
