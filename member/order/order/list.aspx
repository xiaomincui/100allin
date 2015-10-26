<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="pro_order_list" EnableEventValidation="false" EnableViewState="false" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>我的订舱单</title>
<link href="css/master.css" rel="stylesheet" type="text/css" />
<link href="css/userlist.css" rel="stylesheet" type="text/css" />
<script src="js/list.js" type="text/javascript"></script>

</head>
<body>
<form id="form1" runat="server">
<div id="page">
<div id="center">
<protop:protop ID="protop1" runat="server" />
<div id="main">
<proleft:proleft ID="proleft1" runat="server" />							
<div id="right">
<div class="tt18 bd rightTitle">
<div class="text"><asp:Literal ID="ltrHeadTitle" runat="server"></asp:Literal></div>
</div>
<div class="rightArea txth22">
<div id="tipBoxSearch" class="tipBox">
<table border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="20">
<asp:Literal ID="ltrOrderAll" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;
<asp:Literal ID="ltrOrderWait" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;
<asp:Literal ID="ltrOrderBusy" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;
<asp:Literal ID="ltrOrderFinish" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;
<asp:Literal ID="ltrOrderInvalid" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;
<asp:Literal ID="ltrOrderCheck" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;
<asp:PlaceHolder ID="plhOrderSave" runat="server"><asp:Literal ID="ltrOrderSave" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;</asp:PlaceHolder>
<a href="bill.aspx">账单</a>
</td>
</tr> 
</table>
</div>

<div class="listTable">
<div style="position:relative;">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>						
<table cellspacing="0" cellpadding="3" rules="rows" bordercolor ="#D9D9D9" border="1" id="GridView1" style="border-width:1px;border-style:Solid;border-collapse:collapse;">
<tr style="background-color:#F0F0F0;">
<th scope="col" style="width:3px;"></th>
<th scope="col" style="width:130px;">订单编号</th>
<th scope="col" style="width:110px;">下单时间</th>
<th scope="col" style="width:200px;">交易方</th>
<th scope="col" style="width:130px;">交易状态</th>
<th scope="col" style="width:125px;">操作</th>
<th scope="col" style="width:40px;">详情</th>
</tr>
<asp:Repeater ID="RptOrder" runat="server">
<ItemTemplate>
<tr onmouseover="this.style.backgroundColor='#F4F7FB';" onmouseout="this.style.backgroundColor='#ffffff';" style="font-weight:<%#Eval("status_font_weight") %>;">
<td style="width:3px; height:40px;"></td>
<td style="width:130px;"><a href="view.aspx?orderid=<%#Eval("order_code")%>" target="_blank"><%#Eval("order_code")%></a></td>
<td style="width:110px;"><%#Convert.ToDateTime(Eval("date_create")).ToString("yyyy-MM-dd")%> <%#Convert.ToDateTime(Eval("date_create")).ToString("HH:mm")%>　</td>
<td style="width:200px;"><div style="width:180px; overflow: hidden; text-overflow:ellipsis;"><nobr><a href="/company/<%#setkey(Eval("userid").ToString())%>/" target="_blank"><%#Eval("CompanyName")%></a></nobr></div></td>
<td style="width:130px;"><%#Eval("status_name")%></td>
<td style="width:125px;"><%#Eval("op").ToString().Replace("{1}",Eval("order_code").ToString())%>&nbsp;</td>
<td style="width:40px;"><a href="detail.aspx?orderid=<%#Eval("order_code")%>" target="_blank">详情</a></td>
</tr>
</ItemTemplate>
</asp:Repeater>		

</table>

<div style="display:none;">

<asp:TextBox ID="txtCode" runat="server"></asp:TextBox>

<asp:Button ID="btnSendOrder1" runat="server" Text="提交保存的订单" OnClick="btnSendOrder1_Click" />
<asp:Button ID="btnDelOrder1" runat="server" Text="删除保存的订单" OnClick="btnDelOrder1_Click" />
<asp:Button ID="btnRecoverOrder1" runat="server" Text="恢复订单10" OnClick="btnRecoverOrder1_Click" />
<asp:Button ID="btnAcceptOrder1" runat="server" Text="接受订单" OnClick="btnAcceptOrder1_Click" />
<asp:Button ID="btnFinishOrderShipper1" runat="server" Text="货主完成订单1" OnClick="btnFinishOrderShipper1_Click" />
<asp:Button ID="btnFinishOrderForward1" runat="server" Text="货代完成订单1" OnClick="btnFinishOrderForward1_Click" />
<asp:Button ID="btnFinishOrderForward2" runat="server" Text="货代完成订单2" OnClick="btnFinishOrderForward2_Click" />

<asp:Button ID="btnRejectOrderForward" runat="server" Text="货代不接受订单" OnClick="btnRejectOrderForward_Click" />
<asp:Button ID="btnRerejectOrderForward" runat="server" Text="货代重新接受订单" OnClick="btnRerejectOrderForward_Click" />
<asp:Button ID="btnRecoverOrderForward" runat="server" Text="货代恢复不接受的订单" OnClick="btnRecoverOrderForward_Click" />

<asp:Button ID="btnCancelOrder2" runat="server" Text="撤销订单2" OnClick="btnCancelOrder2_Click" />
<asp:Button ID="btnCancelOrder3" runat="server" Text="撤销订单3" OnClick="btnCancelOrder3_Click" />
<asp:Button ID="btnCancelOrder4" runat="server" Text="撤销订单4" OnClick="btnCancelOrder4_Click" />
<asp:Button ID="btnCancelCancelOrder7" runat="server" Text="取消撤销订单7" OnClick="btnCancelCancelOrder7_Click" />
<asp:Button ID="btnCancelCancelOrder8" runat="server" Text="取消撤销订单8" OnClick="btnCancelCancelOrder8_Click" />
<asp:Button ID="btnCancelCancelOrder9" runat="server" Text="取消撤销订单9" OnClick="btnCancelCancelOrder9_Click" />

<asp:Button ID="btnRecoverOrder11" runat="server" Text="恢复订单11" OnClick="btnRecoverOrder11_Click" />
<asp:Button ID="btnRecoverOrder12" runat="server" Text="恢复订单12" OnClick="btnRecoverOrder12_Click" />
<asp:Button ID="btnRecoverOrder13" runat="server" Text="恢复订单13" OnClick="btnRecoverOrder13_Click" />
<asp:Button ID="btnRecoverOrder14" runat="server" Text="恢复订单14" OnClick="btnRecoverOrder14_Click" />

</div>
</ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress ID="UpdateProgress1" runat="server">
<ProgressTemplate>
<div style="position:absolute; top:100px; left:200px; border:1px solid #999999; background:#FFFFFF; text-align:center; padding:10px;">
正在处理，请稍候...<br/>
<img src="images/loading5.gif" alt=""/>
</div>
</ProgressTemplate>
</asp:UpdateProgress>	
</div>
</div>
</div>
</div>			
</div>
<probottom:probottom ID="probottom1" runat="server" />
</div>
</div>
</form>
</body>
</html>
