<%@ Control Language="C#" AutoEventWireup="true" CodeFile="usertoptop20100711.ascx.cs" Inherits="usercontrols_usertoptop20100711" %>
<div class="head"><!--顶部开始-->
<div class="head_top" style="position:relative;">
<h2><asp:Label ID="Label8" runat="server" Text=""></asp:Label> <a href="/accounts/reg.aspx">[免费注册]</a> <asp:Literal ID="Literal1" runat="server"></asp:Literal></h2>
<ul>
<li><a href="/member/">我的办公室</a>&nbsp;|&nbsp;</li>
<li><a href="#" onmouseover="javascript:document.getElementById('menu_base').style.display = '';" onmouseout="javascript:document.getElementById('menu_base').style.display = 'none';">免费会员服务</a>&nbsp;|&nbsp;</li>
<li><a href="#" onmouseover="javascript:document.getElementById('menu_pro').style.display = '';" onmouseout="javascript:document.getElementById('menu_pro').style.display = 'none';">付费服务</a>&nbsp;|&nbsp;</li>
<li><a href="/help/help_23.aspx" target="_blank">帮助</a>&nbsp;&nbsp;</li>
</ul>
<div style="border:1px solid #E69B9B;background:#FDFDFD;padding:8px;line-height:20px;position:absolute;top:20px; left:773px; display:none;" id="menu_base" onmouseover="javascript:document.getElementById('menu_base').style.display = '';" onmouseout="javascript:document.getElementById('menu_base').style.display = 'none';">
<a href="/accounts/reg.aspx" target="_blank">会员注册</a> <br/>
<a href="/member/releaseselect.aspx" target="_blank">发布运价</a> <br/>
<a href="#" target="_blank">发布货盘</a> <br/>
<a href="/fcl/" target="_blank">查询运价</a> <br/>
<a href="#" target="_blank">发布帖子</a> <br/>
</div>
<div style="border:1px solid #E69B9B;background:#FDFDFD;padding:8px;line-height:20px;position:absolute;top:20px; left:813px; display:none;" id="menu_pro" onmouseover="javascript:document.getElementById('menu_pro').style.display = '';" onmouseout="javascript:document.getElementById('menu_pro').style.display = 'none';">
<a href="/products/" target="_blank">海空运精准营销</a> <br/>
<a href="/products/products2.aspx" target="_blank">邮件/短信群发</a> <br/>
<a href="/products/products3.aspx" target="_blank">航线优势代理</a> <br/>
<a href="/products/products4.aspx" target="_blank">广告</a> <br/>
</div>
</div>




<%--<div style="width:950px; height:70px;">
<table width="950" height="70" border="0" cellpadding="0" cellspacing="0">
<tr>
<td width="183"><a href="/topic/newyear20110107/"><img src="/images2/newyear/nw12.jpg" width="183" height="70" border="0" /></a></td>
<td width="571" background="/images2/newyear/nw14.jpg">
<table style="font-size:12px; color:#FFCC33; line-height:20px;" width="571" border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="40">
<div id="textnomouse2" style="width:550px;height:40px;overflow:hidden;">
<asp:Repeater ID="Rptzhufu" runat="server">
<ItemTemplate>
<a href="/topic/newyear20110107/"><b><%#(Eval("companyname").ToString())%></b> 发来拜年贺电： <%#(Eval("zhufu").ToString())%></a><br />
</ItemTemplate>
</asp:Repeater>

</div>                     
<script>    
var marquee2=new Marquee("textnomouse2")
marquee2.Timer = 50;
marquee2.ScrollStep=-1;
marquee2.Start();
</script>              
</td>
</tr>

</table></td>
<td width="10"><img src="/images2/newyear/nw15.jpg" width="10" height="70" /></td>
<td width="66"><img src="/images2/newyear/bt.gif" width="66" height="70" /></td>
<td width="121"><img src="/images2/newyear/nw13.jpg" width="120" height="70" /></td>
</tr>
</table>
</div>--%>
</div>