<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pricecount.ascx.cs" Inherits="usercontrols_pricecount" %>
<div id="count">
    <span class="countText">目前网站共有：</span>
    <span class="countText">
        整箱运价：<span class="countNumber smallBoldOrange"><asp:Label ID="lblCountZx" runat="server"></asp:Label>
        </span> 条</span>
    <span class="countText">
        拼箱运价：<span class="countNumber smallBoldOrange"><asp:Label ID="lblCountPx" runat="server"></asp:Label>
        </span> 条</span>
    <span class="countText">
        空运运价：<span class="countNumber smallBoldOrange"><asp:Label ID="lblCountHk" runat="server"></asp:Label>
        </span> 条</span>
    <span class="countText" style="display:none;">
        货盘数量：<span class="countNumber smallBoldOrange"><asp:Label ID="lblCountHp" runat="server"></asp:Label>
        </span> 条</span>
<!--<div style="color:red;font-weight:bold;">亲爱的用户：傲赢网将于12月30日下午(13点左右)进行数据维护和整理工作,届时网站将关闭<BR/>网站预计在当日下午恢复运行，给您造成不便请谅解</div>-->
</div>