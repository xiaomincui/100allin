<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userrate1.ascx.cs" Inherits="usercontrols_userrate1" %>
<div class="left_mid_box">
	<div class="left_mid_title"><img src="images/index/md_icon.png" />&nbsp;<span class="bold tit"><a  href="/intro/rate.aspx" target="_blank">最新汇率</a></span></div>
		<p id="nowtime"></p>
        <script language="javascript">
            function nowtime(){   
                var now=new Date();
                var Y = FormatDigit(now.getYear());     //得到年 
                var M = FormatDigit(now.getMonth()+1);     //得到月   
                var D = FormatDigit(now.getDate());     //得到日 
                var h = FormatDigit(now.getHours());     //得到小时 
                var m = FormatDigit(now.getMinutes());     //得到分钟
                var s = FormatDigit(now.getSeconds());     //得到秒
                document.all["nowtime"].innerHTML= Y + "年" + M + "月" + D +"日 " + h + ":" + m + ":" + s;
            }                             
            setInterval('nowtime()',1000); 
        </script>							
		<p>1美元 = <asp:Label ID="Label8" runat="server" Text=""></asp:Label>人民币</p>
	    <p>1欧元 = <asp:Label ID="Label9" runat="server" Text=""></asp:Label>人民币</p>
	    <p>100日元 = <asp:Label ID="Label10" runat="server" Text=""></asp:Label>人民币</p>
	    <p>100港币 = <asp:Label ID="Label11" runat="server" Text=""></asp:Label>人民币</p>
		 <p style="text-align:right;"><a class="orange" href="/intro/rate.aspx" target="_blank">更多汇率资讯>></a>&nbsp;&nbsp;</p>
</div>