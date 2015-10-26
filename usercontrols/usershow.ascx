<%@ Control Language="C#" AutoEventWireup="true" CodeFile="usershow.ascx.cs" Inherits="usercontrols_usershow" EnableViewState="false" %>

<table border="0" cellspacing="0" cellpadding="0">
<tr>
  <td width="10"><img src="/images/box_1_o.gif" width="10" height="31" /></td>
  <td width="372" background="/images/box_2_o.gif"><div class="tabTitleSelect2">我们和您一起进步 - 傲赢网最新动态</div></td>
  <td width="10"><img src="/images/box_3_o.gif" width="10" height="31" /></td>
</tr>
<tr>
  <td background="/images/box_4_o.gif"></td>
  <td>
    <div class="inLeftBox" style="line-height:25px; padding-bottom:5px;">
            <div style="padding:0px 0px 5px 0px;">
                <span class="showSelect" id="a1" onmouseover="dyts.showtab(0);dyts.clearautoshow();" onmouseout="dyts.autoshow();">全部动态</span>&nbsp;|&nbsp;
                <!--<span class="showUnselect" id="a2" onmouseover="dyts.showtab(1);dyts.clearautoshow();" onmouseout="dyts.autoshow();">傲赢网</span>&nbsp;|&nbsp;-->
                <span class="showUnselect" id="a3" onmouseover="dyts.showtab(1);dyts.clearautoshow();" onmouseout="dyts.autoshow();">运价</span>&nbsp;|&nbsp;
                <span class="showUnselect" id="a4" onmouseover="dyts.showtab(2);dyts.clearautoshow();" onmouseout="dyts.autoshow();">会员</span>&nbsp;|&nbsp;
                <!--<span class="showUnselect" id="a5" onmouseover="dyts.showtab(4);dyts.clearautoshow();" onmouseout="dyts.autoshow();">论坛</span>&nbsp;|&nbsp;-->
                <!--<span class="showUnselect" id="a6" onmouseover="dyts.showtab(5);dyts.clearautoshow();" onmouseout="dyts.autoshow();">聊天室</span>-->
            </div>
            
            <div id="nra1" class="showDetail" onmouseover="dyts.showtab(0);dyts.clearautoshow();" onmouseout="dyts.autoshow();" style="">
                <asp:DataList ID="DataList1" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <ItemTemplate>
			                     <%# Eval("TXT")%> (<%# Eval("POSTDATE")%>)
			                     <hr class="showHr" />
                    </ItemTemplate>
                </asp:DataList>
            </div>
        	
            <!--<div id="nra2" class="showDetail" style="display:none;" onmouseover="dyts.showtab(1);dyts.clearautoshow();" onmouseout="dyts.autoshow();" style="">
                <asp:DataList ID="DataList2" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <ItemTemplate>
			                     <%# Eval("TXT")%> (<%# Eval("POSTDATE")%>)
			                     <hr class="showHr" />
                    </ItemTemplate>
                </asp:DataList>	
            </div>-->
    	    
            <div id="nra3" class="showDetail" style="display:none;" onmouseover="dyts.showtab(1);dyts.clearautoshow();" onmouseout="dyts.autoshow();" style="">  
                <asp:DataList ID="DataList3" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <ItemTemplate>
			                     <%# Eval("TXT")%> (<%# Eval("POSTDATE")%>)
			                     <hr class="showHr" />
                    </ItemTemplate>
                </asp:DataList>		
            </div>
        	
            <div id="nra4" class="showDetail" style="display:none;" onmouseover="dyts.showtab(2);dyts.clearautoshow();" onmouseout="dyts.autoshow();" style=";">  
                <asp:DataList ID="DataList4" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <ItemTemplate>
			                     <%# Eval("TXT")%> (<%# Eval("POSTDATE")%>)
			                     <hr class="showHr" />
                    </ItemTemplate>
                </asp:DataList>	
            </div>
        		
            <!--<div id="nra5" class="showDetail" style="display:none;" onmouseover="dyts.showtab(4);dyts.clearautoshow();" onmouseout="dyts.autoshow();" style="">  
                <asp:DataList ID="DataList5" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <ItemTemplate>
			                     <%# Eval("TXT")%> (<%# Eval("POSTDATE")%>)
			                     <hr class="showHr" />
                    </ItemTemplate>
                </asp:DataList>	
            </div>	-->

            <!--<div id="nra6" class="showDetail" style="display:none;" onmouseover="dyts.showtab(5);dyts.clearautoshow();" onmouseout="dyts.autoshow();">  
                <asp:DataList ID="DataList6" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <ItemTemplate>
			                     <%# Eval("TXT")%> (<%# Eval("POSTDATE")%>)
			                     <hr class="showHr" />
                    </ItemTemplate>
                </asp:DataList>
            </div>	-->
    </div>
  </td>
  <td background="/images/box_6_o.gif"></td>
</tr>
<tr>
  <td><img src="/images/box_7_o.gif" width="10" height="10" /></td>
  <td background="/images/box_8_o.gif"></td>
  <td><img src="/images/box_9_o.gif" width="10" height="10" /></td>
</tr>
</table>

<script type=text/javascript>
var dyts = new dytabstrip("showSelect","showUnselect");
dyts.addtab(document.getElementById("a1"),document.getElementById("nra1"));
//dyts.addtab(document.getElementById("a2"),document.getElementById("nra2"));
dyts.addtab(document.getElementById("a3"),document.getElementById("nra3"));
dyts.addtab(document.getElementById("a4"),document.getElementById("nra4"));
//dyts.addtab(document.getElementById("a5"),document.getElementById("nra5"));
//dyts.addtab(document.getElementById("a6"),document.getElementById("nra6"));
dyts.autoshow();
</script>