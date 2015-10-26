<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hitindex.aspx.cs" Inherits="admin_sales_hitindex" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="/admin/css/master.css" rel="stylesheet" type="text/css" />
    <link href="/admin/css/searchwordslist.css" rel="stylesheet" type="text/css" />
    <LINK href="/admin/css/WebResource.css" type=text/css rel=stylesheet />
    <script language=javascript src=/admin/js/function.js></script>    
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
					<div class="text">运价点击量统计</div>
				</div>	
				<div class="rightArea txth22" style="font-size:14px; line-height:25px;">
				<div>
				<div id="tipBoxSearch" class="tipBox">
				<b>筛选：</b>
				起始日期

<INPUT id=BasicDatePicker1_TextBox readOnly value="" name=BasicDatePicker1$TextBox style="width:70px;" runat="server" />
<IMG class=bdpButton id=BasicDatePicker1_Image style="BORDER: 0px; WIDTH: 28px; HEIGHT: 22px;" alt="点击日历选择日期" src="/admin/images/WebResource.gif" border=10 />
&nbsp;&nbsp;
结束日期
<INPUT id=BasicDatePicker2_TextBox readOnly value="" name=BasicDatePicker2$TextBox style="width:70px;" runat="server" />
<IMG class=bdpButton id=BasicDatePicker2_Image style="BORDER: 0px; WIDTH: 28px; HEIGHT: 22px;" alt="点击日历选择日期" src="/admin/images/WebResource.gif" border=10 />
&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" />
<SCRIPT src="/admin/js/WebResource.js" type=text/javascript></SCRIPT>
<SCRIPT src="/admin/js/coolite.js" type=text/javascript></SCRIPT>
<SCRIPT src="/admin/js/basicdatepicker.js" type=text/javascript></SCRIPT>
<SCRIPT type=text/javascript>
//<![CDATA[
var BasicDatePicker1 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker1",dateFormat:"yyyy-MM-dd",selectableWeekendDays:true,minimumDate:"1999/1/1",nullDateText:"",showWeekNumbers:true,showDaysInNextMonth:false,showDaysInPrevMonth:false,northImage:"/admin/images/arrow_up.gif",southImage:"/admin/images/arrow_down.gif",eastImage:"/admin/images/arrow_right.gif",westImage:"/admin/images/arrow_left.gif"}).applyTo({inputID:"BasicDatePicker1_TextBox",buttonID:"BasicDatePicker1_Image"}) : alert("日期控件出现问题，请刷新该页面");
var BasicDatePicker2 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker2",dateFormat:"yyyy-MM-dd",selectableWeekendDays:true,minimumDate:"1999/1/1",nullDateText:"",showWeekNumbers:true,showDaysInNextMonth:false,showDaysInPrevMonth:false,northImage:"/admin/images/arrow_up.gif",southImage:"/admin/images/arrow_down.gif",eastImage:"/admin/images/arrow_right.gif",westImage:"/admin/images/arrow_left.gif"}).applyTo({inputID:"BasicDatePicker2_TextBox",buttonID:"BasicDatePicker2_Image"}) : alert("日期控件出现问题，请刷新该页面");
//]]>
</SCRIPT>
	            </div>
				</div>
				<table>
				<tr>
				<td valign="top">
                <table>
                    <tr style="font-weight:bold;">
                        <td colspan="4">
                        <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
                    </tr>                
                    <tr style="font-weight:bold;">
                        <td width="40">序号</td><td width="80">日期</td><td  align=right>点击量</td><td></td>
                    </tr>
                   <tr>
                        <td width="40">合计</td><td width="80"></td><td  align=right>
                            <asp:Literal ID="Literal2" runat="server"></asp:Literal></td><td></td>
                    </tr>                    
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                    <tr>
                        <td><%#this.Repeater1.Items.Count + 1%></td>
                        <td><%#Eval("dateparts").ToString()%></td>
                        <td  align=right><%#Eval("c").ToString()%> </td>
                        <td><img src="/admin/images/search/bluedot.gif" width="<%#Convert.ToDouble(Eval("c").ToString())/hitmax*400%>" height="10" />
                        </td>
                    </tr>
                        </ItemTemplate>
                    </asp:Repeater>  
                </table>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                <table>
                    <tr style="font-weight:bold;">
                        <td colspan="4">
                        运价详情：
                        </td>
                    </tr>                
                    <tr style="font-weight:bold;">
                        <td>标题</td><td>发布日期</td><td  align=right>点击量</td><td>详细</td><td>置顶</td>
                    </tr>                   
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                    <tr>
                        <td><%#Eval("title").ToString() == "" ? "<span style=\"color:#666666;\">价格已删除</span>" : "<a href=\"/fcl/" + setkey(Eval("id").ToString()) + "_0.html\" target=\"_blank\">" + Eval("title").ToString() + "</a>"%></td>
                        <td><%#Eval("postdate").ToString()%></td>
                        <td  align=right><%#Eval("c").ToString()%> </td>
                        <td><a href="hitindex.aspx<%#Eval("qs").ToString()%>">详细</a>
                        </td>
                        <td><span style="color:red"><%#Eval("order_adv").ToString() == "0" | Eval("order_adv").ToString() == "" ? "" : "置顶"%></span></td>
                    </tr>
                        </ItemTemplate>
                    </asp:Repeater>  
                </table>                
                </asp:PlaceHolder>
                
                    <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="false">
                <table>
                    <tr style="font-weight:bold;">
                        <td colspan="4">
                        点击详情：
                        </td>
                    </tr>                
                    <tr style="font-weight:bold;">
                        <td>姓名</td><td>公司</td><td>点击日期</td><td></td><td></td>
                    </tr>                   
                    <asp:Repeater ID="Repeater3" runat="server">
                        <ItemTemplate>
                    <tr>
                        <td><%#Eval("Realname").ToString()%></td>
                        <td><%#Eval("Companyname").ToString()%></td>
                        <td><%#Eval("NowTime").ToString()%></td>
                        <td><a href=""></a>
                        </td>
                        <td></td>
                    </tr>
                        </ItemTemplate>
                    </asp:Repeater>  
                </table>                
                </asp:PlaceHolder>                
                <br/>
                
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
