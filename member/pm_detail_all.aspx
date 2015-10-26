<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pm_detail_all.aspx.cs" Inherits="member_pm_detail_all" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>我的留言</title>
<link href="css/offices.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
function delConfirm(id) {//确认confirm事件
	document.getElementById("delList").value = id;
	var delQus;
	delQus=confirm('真的要删除该条留言吗？');
	if (delQus==true){
		document.getElementById("btnHidDel").click();
	}else{
		document.getElementById("delList").value = "";
	}	
}


</script>
</head>
<body onload="window.scroll(0,999999);">
<form id="form1" runat="server">
	<div class="main_container">
    <memberheader:memberheader ID="memberheader1" runat="server" />
		<div class="center">
            <memberleft:memberleft ID="memberleft1" runat="server" />
	        <div class="main">
                <memberwelcome:memberwelcome ID="memberwelcome1" runat="server" />
				<div class="message">
					<div class="message_tit">
						<div class="message_nav">
          <a href="pm.aspx?filter=new">未读留言</a> | 
          <a href="pm.aspx">所有留言</a> | 
          <a href="pm.aspx?filter=private">私人留言</a> | 
          <a href="pm.aspx?filter=system">系统留言</a> | 
          <a href="pm.aspx?filter=my">发件箱</a>						
						</div>
					</div>
				</div>
                <div style="margin:15px 0px 0px 10px; font-size:14px;"><B>我与 <asp:Literal ID="Literal1" runat="server"></asp:Literal> 之间的留言：</B></div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:Repeater ID="RptPm" runat="server">
                <ItemTemplate>
				<div class="message_box">
					<div class="message_box_left">
						<div class="message_pic"><a href="/company/<%# setkey(Eval("chater").ToString()) %>/" target="_blank"><img src="/member/head/<%# Eval("chater_head").ToString() == "True"? Eval("chater").ToString():"default" %>.jpg" border="0" width="90" height="90" /></a></div>
					  <div class="message_tx"><a href="/company/<%# setkey(Eval("chater").ToString()) %>/" target="_blank"><%# Eval("chater_username").ToString() %></a><br />
						<span class="gray"><%# Eval("chattime").ToString()%></span></div>
					</div>
					<div class="message_box_right">
					    <div style=" ">
					    <img src="images/ico13.gif" />&nbsp;<%# Eval("txt").ToString()%>
					    </div>
					    <div style="margin-top:15px; font-size:12px;">
					    <a href="javascript:delConfirm('<%# Eval("mid").ToString()%>');">删除</a> 
					    </div>
					</div>
				</div>
                </ItemTemplate>
                </asp:Repeater>
                    <div style="display:none;"><asp:Button ID="btnHidDel" runat="server" Text="Button" onclick="btnHidDel_Click"/>
                    <asp:TextBox ID="delList" runat="server"></asp:TextBox></div>
<div class="company_tab"><table width="710" border="0" cellpadding="0" cellspacing="1">
<tr>
<td height="28">&nbsp;&nbsp;&nbsp;<span style="font:14px '宋体';"><strong>留言内容</strong>：</span></td>
</tr>
<tr>
<td>&nbsp;&nbsp;&nbsp;<asp:TextBox id="TextBox1" runat="server" Width="466px" Height="124px" TextMode="MultiLine"></asp:TextBox></td>
</tr>
<tr>
<td height="60">&nbsp;&nbsp;&nbsp;<asp:Button id="Button1" runat="server" Text="给Ta留言" OnClick="Button1_Click"></asp:Button> 
<asp:Label id="Label2" runat="server" Text="一次发送不能超过200字哦" ForeColor="Red" Visible="False"></asp:Label></td>
</tr>
</table>
</div>    
                </ContentTemplate>
                </asp:UpdatePanel>
            
		    </div>

		</div>
<memberfooter:memberfooter ID="memberfooter1" runat="server" />
	</div>

</form>
</body>
</html>
