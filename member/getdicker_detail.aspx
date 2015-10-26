<%@ Page Language="VB" MasterPageFile="~/member/member.master" AutoEventWireup="false" CodeFile="getdicker_detail.aspx.vb" Inherits="member_getdicker_detail" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language="javascript" src="js/function.js"></script>
<LINK href="/chatroom/css/s.css" type=text/css rel=stylesheet>

<script type="text/javascript" language="javascript">
function ctlent(eventobject)
{
		if(event.ctrlKey && event.keyCode==13)
		{
			top.document.getElementById("ctl00_ContentPlaceHolder1_Button1").click();
		}
}
</script>
    <div class="listTitle">
      <table border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td width="44" style="height: 34px"><img src="images/edit_icon.gif" width="44" height="27" /></td>
          <td width="318" style="height: 34px"><span class="bigBoxTitle">我的讨价还价</span></td>
          <td width="413"><div style="text-align:right; font-size:14px;">
          <a href="getdicker.aspx?filter=new">未读讨价还价</a> | 
          <a href="getdicker.aspx" >所有收到的讨价还价</a> | 
          <a href="getdicker.aspx?filter=my" >我发送的讨价还价</a>          
          </div></td>
        </tr>
      </table>
    </div>
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <ContentTemplate>
            <DIV style="FONT-SIZE: 14px; MARGIN: 10px 0px 10px 10px; LINE-HEIGHT: 22px"><B> <asp:Label id="Label1" runat="server" Text=""></asp:Label> 向您讨价还价：</B><BR /><BR /><TABLE cellSpacing=0 cellPadding=0 border=0><TBODY><TR style="BACKGROUND: #eeeeee"><TD colSpan=3></TD></TR>
            <asp:Repeater id="Repeater1" runat="server">
                <ItemTemplate>
                <tr height="30px"  valign=top style="padding:10px 0px 10px 0px;">
                    <td width="100px;">
                    <a><img width="70px" height="70px" src="/member/Head/<%#IIf(HeadExist((Eval("chater")))="1",Eval("chater"),"default")%>.jpg" /></a>                    
                    </td>
	                <td style="font-size:12px;" width="130px;">
	                    <%#Eval("realname")%> <br/><span style="color:#666666;"><%#Eval("chattime")%></span>
	                </td>
	                <td >
	                    您好，我看到了您在环球运费网上发布的运价。<br/>
	                    我对您的价格非常有兴趣，我有货物需要运输，但运价能否与您商榷。<br/><br/>
	                    <b>我的货物情况：</b><br/>
	                    <%#Eval("cargo")%><br/> 
	                    货物航线：<%#Eval("hangxianmiaoshu")%><br/> 
	                    货物启运地：<%#Eval("startport")%><br/> 
	                    货物目的地：<%#Eval("destport")%><br/> 
	                    希望使用的船公司：<%#Eval("carrier")%><br/> 
	                    <br/> 
	                    <b>我的理想价位：</b><br/>
	                    <%#Eval("price")%><br/> <br/> 	                    
	                    <b>这是我的联系方式：</b><br/>
	                    <%#Eval("txt")%>
	                    其他联系方式：<%#Eval("reply")%><br/><br/>
	                    如果您有兴趣，请速与我联系！谢谢！
	                    
	                </td>	            
	            </tr>
	            <tr style="background:#EEEEEE;"><td colspan="3"></td></tr>
                </ItemTemplate>
                </asp:Repeater></TBODY></TABLE></DIV>
               
        </ContentTemplate> 
            </asp:UpdatePanel>
            <DIV style="FONT-SIZE: 14px; MARGIN: 10px 0px 10px 10px; LINE-HEIGHT: 22px">
                环球运费网提示：您可以使用以上用户给您的联系方式与其联系<asp:Label ID="Label2" runat="server" Text=""></asp:Label></DIV>
            
</asp:Content>

