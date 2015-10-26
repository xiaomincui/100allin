<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pm.aspx.cs" Inherits="member_pm" EnableEventValidation="false" EnableViewState="false"%><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
<body>
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
          <a href="pm.aspx?filter=new" <%=(Request.QueryString["filter"] == "new" | Request.QueryString["filter"] == null)?"style=\"font-weight:bold;\"":"" %>>未读留言</a> | 
          <a href="pm.aspx?filter=all" <%=Request.QueryString["filter"] == "all"?"style=\"font-weight:bold;\"":"" %>>所有留言</a> | 
          <a href="pm.aspx?filter=private" <%=Request.QueryString["filter"] == "private"?"style=\"font-weight:bold;\"":"" %>>私人留言</a> | 
          <a href="pm.aspx?filter=system" <%=Request.QueryString["filter"] == "system"?"style=\"font-weight:bold;\"":"" %>>系统留言</a> | 
          <a href="pm.aspx?filter=my" <%=Request.QueryString["filter"] == "my"?"style=\"font-weight:bold;\"":"" %>>发件箱</a>						
						</div>
					</div>
				</div>
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
					    <div style="height:70px; overflow:hidden;">
					    <img src="images/ico13.gif" />&nbsp;<%# NoHTML(Eval("txt").ToString())%>
					    </div>
					    <div style="margin-top:15px; font-size:12px;">
					    <a href="pm_detail.aspx?pid=<%# Eval("mid").ToString()%>&cid=<%# Eval("chater").ToString()%>">查看完整留言</a> 
					    <a href="javascript:delConfirm('<%# Eval("mid").ToString()%>');">删除</a> 
					    <%# Eval("readed").ToString() == "1" ? (Request.QueryString["filter"] == "my" ? "<span style=\"margin-left:260px;color:#666666;\">对方已读</span>" : "<span style=\"margin-left:290px;color:#666666;\">已读</span>") : (Request.QueryString["filter"] == "my" ? "<span style=\"margin-left:260px;color:#FF0000;\">对方未读</span>" : "<span style=\"margin-left:290px;color:#FF0000;\">未读</span>")%>
					    </div>
					</div>
				</div>
                </ItemTemplate>
                </asp:Repeater>
                    <div style="display:none;"><asp:Button ID="btnHidDel" runat="server" Text="Button" onclick="btnHidDel_Click"/>
                    <asp:TextBox ID="delList" runat="server"></asp:TextBox></div>
<div style="line-height:18px; padding:18px 10px 18px 10px; text-align:right;" class="manu">
<%= pagecontrol_string%>
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
