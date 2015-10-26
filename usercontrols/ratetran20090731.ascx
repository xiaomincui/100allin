<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ratetran20090731.ascx.cs" Inherits="usercontrols_ratetran20090731" %>
        <div class="right_boxs">
			<div class="right_boxs_title"><h2><img src="/images/fcl/b3.gif" width="14" height="14" /><a href="#">最新汇率</a></h2>
			</div>
<p id="nowtime" style="padding-top:12px;"></p>
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
<p>1美元 = <asp:Label ID="Label3" runat="server" Text=""></asp:Label>人民币</p>
<p>1欧元 = <asp:Label ID="Label4" runat="server" Text=""></asp:Label>人民币</p>
<p>100日元 = <asp:Label ID="Label5" runat="server" Text=""></asp:Label>人民币</p>
<p>100港币 = <asp:Label ID="Label6" runat="server" Text=""></asp:Label>人民币</p>
 <p style="text-align:right; padding-bottom:12px;"><a class="orange" href="/intro/rate.aspx" target="_blank">更多汇率资讯>></a>&nbsp;&nbsp;</p>
			<div class="right_boxs_title"><h2><img src="/images/fcl/b4.gif" width="14" height="14" /><a href="#">在线翻译</a></h2>
			</div>
			<p style="padding-top:12px;">
			    <iframe src="/intro/translate.htm" width="155px" height="130px" frameborder="0" scrolling="no"></iframe>
		  </p>
		</div>		