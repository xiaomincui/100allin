<%@ Control Language="C#" AutoEventWireup="true" CodeFile="usernew.ascx.cs" Inherits="usercontrols_usernew" %>
	  <table border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="25"><img src="/images/new_light.gif" /></td>            
          <td width="130"><span class=""><strong>欢迎最新加入会员：</strong></span></td>
          <td width="600">
			<div id=demo style="OVERFLOW: hidden; HEIGHT: 20px">
			<div id=demo1>
				<asp:DataList ID="DataList1" runat="server" BorderWidth="0px" CellPadding="0" RepeatColumns="2" RepeatDirection="Horizontal">
					<ItemTemplate>
						<div class="titleUserName"><nobr><%# Eval("RealName") %> （<%# ReplaceSomeWord(Eval("CompanyName").ToString())%>）</nobr></div>
					</ItemTemplate>
					<ItemStyle Width="300px" Height="20px" />
				</asp:DataList>
			</div>
			<div id=demo2></div>
			</div>		  
		  </td>
        </tr>
      </table>
<script>
var speed=80
demo2.innerHTML=demo1.innerHTML
function Marquee(){
if(demo2.offsetTop-demo.scrollTop<=0)
demo.scrollTop-=demo1.offsetHeight
else{
demo.scrollTop++
}
}
var MyMar=setInterval(Marquee,speed)
demo.onmouseover=function() {clearInterval(MyMar)}
demo.onmouseout=function() {MyMar=setInterval(Marquee,speed)}
</script>     