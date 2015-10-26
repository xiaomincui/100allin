<%@ Page Language="C#" AutoEventWireup="true" CodeFile="detail.aspx.cs" Inherits="club_repaste_detail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd">
<HTML xmlns="http://www.w3.org/1999/xhtml"><HEAD><TITLE>转贴 - 环球运费网</TITLE>
<META http-equiv=content-type content="text/html; charset=utf-8">
<link href="css/style.css" rel="stylesheet" type="text/css">
<script type="text/javascript">
function checkRepasteForm()
{
    if (document.getElementById("HiddenField2").value == "1")
    {   
        document.getElementById("HiddenField2").value = "0";
        var testContent = document.getElementById("TEXTAREA1").value;
        testContent = testContent.trim();
        if (0 == testContent.length)
        {
        alert("评论内容不能为空！");
        document.getElementById("TEXTAREA1").focus();
        return false;
        }
        if (2 > testContent.length)
        {
        alert("评论内容多写几个字吧！");
        document.getElementById("TEXTAREA1").focus();
        return false;
        }
        return true;
    }
    else
    {
        return true;
    }
}

function setSubmitButton(b)
{
    document.getElementById("HiddenField2").value = b;
}

function clicktag(v,t)
{
    document.getElementById("HiddenField3").value = v;
    document.getElementById("HiddenField4").value = t;
    document.getElementById("Button2").click();;
}

function repasteConfirm() {//确认confirm事件
	var delQus;
	delQus=confirm('发表互动观点成功！\n同时要将此内容分享给你的好友？');
	if (delQus==true){
        setTimeout('test()',1);
	}else{
		
	}	
}
function test(){
document.getElementById("Button4").click();
}
</script>
</HEAD>
<BODY>
<form id="form1" runat="server" onsubmit="javascript:return checkRepasteForm();">
<clubheader:clubheader ID="clubheader1" runat="server" />
<DIV id=wrap>
<DIV id=main>
<clubleft:clubleft ID="clubleft1" runat="server" />

<DIV id=mainarea>
<div class="left_tit">
<div class="left_tit_text"><img src="images/icon28.gif"><strong>转帖</strong></div>
<div class="left_tit_more"><a href="javascript:history.back(-1);">返回上一页</a></div>
</div>
<DIV id="tabs2">
<DIV class="menu2box">
<UL id="menu2">
<LI><a href="index.aspx">我的转帖</a></LI>
<LI><a href="friend.aspx">好友的转帖</a></LI>
<LI><a href="repaste.aspx">我要转帖</a></LI>
<LI><a href="random.aspx">今日热门</a></LI>
</UL>
</DIV>
<DIV class="main2box">
<ul>
<li>
<table width="790" border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="34" align="center" valign="top" ><table width="580" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="30" height="32" align="center" background="images/zt_1.gif"><img src="images/sy_dt_rj1.gif" width="16" height="16"></td>
<td width="488" align="center" background="images/zt_1.gif"><STRONG style="font-size:14px">
<asp:Literal ID="Literal1" runat="server"></asp:Literal></STRONG></td>
<td width="67" background="images/zt_1.gif" align="center">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
<ContentTemplate>
<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">转贴</asp:LinkButton>
</ContentTemplate>
</asp:UpdatePanel>
<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" Visible="false">删除</asp:LinkButton>
</td>
</tr>
<tr>
<td colspan="3" align="left"><p>
<asp:Literal ID="Literal2" runat="server"></asp:Literal>
</p>
    <asp:Literal ID="Literal9" runat="server"></asp:Literal>
</td>
</tr>
<tr>
<td colspan="3" align="left">&nbsp;</td>
</tr>
<tr>
<td colspan="3" align="left"><div class="info">
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
<table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF">
<tr>
<td height="22" colspan="3"><span style="font-size:12px; padding-left:10px;color:#666666;">共有<asp:Literal ID="Literal8"
        runat="server"></asp:Literal>人发表观点</span></td>
</tr>
<tr style="display:none;">
<td width="27%" height="22" align="right"><strong>一定要转</strong>：</td>
<td width="48%" height="22" align="left"><em style="width:250px;" class="tpbg"><img src="images/tt.gif" width="29" height="10" /></em></td>
<td width="25%" height="22" align="left">&nbsp;&nbsp;11%</td>
</tr>
<tr>
<td>
<div style="padding:10px 20px;" class="tag_area">
<asp:Repeater ID="Repeater2" runat="server"><ItemTemplate><span title="共有<%#Eval("vcount").ToString() %>人赞同此观点( <%#Eval("p").ToString() %>% )" class="tag_c<%#Eval("vcount").ToString() == "0"? "12" :(Repeater2.Items.Count >= 12 ? "12" : (Repeater2.Items.Count+1).ToString())%>" onclick="clicktag('<%#Eval("vid").ToString() %>', '<%#Eval("tid").ToString() %>');"><%#Eval("txt").ToString() %></span></ItemTemplate></asp:Repeater>
    <asp:HiddenField ID="HiddenField3" runat="server" />
    <asp:HiddenField ID="HiddenField4" runat="server" />
    <span style="display:none;"><asp:Button ID="Button2" runat="server" Text="发表观点" OnClick="Button2_Click" /><asp:Button ID="Button4" runat="server" Text="转贴" OnClick="Button4_Click" /></span>

</div>
<div style="font-size:12px; padding-left:10px; color:#666666;"><span class="gray" style="display:block; float:left; margin-top:4px;">发表其他观点：</span>
<asp:TextBox ID="TextBox1" runat="server" Width="100" Height="18"></asp:TextBox> 
    <asp:Button ID="Button3" runat="server" Text="发表" OnClick="Button3_Click" /><br/>
    <div style="border-top:1px dashed #dddddd; margin-top:10px; padding-top:10px;">
        大家的观点：<br/>
        <asp:Repeater ID="Repeater3" runat="server">
        <ItemTemplate>
        <a href="/home/space.php?uid=<%#Eval("UCenterHomeUid").ToString() %>"><%#Eval("realname").ToString() %></a>： “<%#Eval("txt").ToString() %>”<br/>
        </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
  
</td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>  
</div></td>
</tr>
<tr>
<td colspan="3" align="left">&nbsp;</td>
</tr>
<tr>
<td colspan="3" align="left">&nbsp;</td>
</tr>
    
<tr>
<td height="32" colspan="3" align="left">&nbsp;&nbsp;&nbsp;&nbsp;<strong style="font-size:14px;">评论</strong><a name="comment"></a></td>
</tr>
<tr>
<td height="32" colspan="3" align="left" background="images/zt_1.gif">&nbsp;</td>
</tr>
<tr>
<td colspan="3" align="left">&nbsp;</td>
</tr>
<asp:HiddenField ID="HiddenField1" runat="server" /><asp:HiddenField ID="HiddenField2" runat="server" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
<tr>
<td colspan="3" align="center"><textarea name="textfield" cols="80" rows="6" id="TEXTAREA1" runat="server"></textarea></td>
</tr>
<tr>
<td colspan="3" align="left">&nbsp;</td>
</tr>
<tr>
<td colspan="3" align="left">
<table width="580" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="484" height="29" align="right"></td>
<td width="96" valign="middle">&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="发表" OnClick="Button1_Click" /></td>
</tr>
</table>

</td>
</tr>
</asp:PlaceHolder>
<asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible="false">

<tr>
<td colspan="3" align="left">&nbsp;</td>
</tr>
<tr>
<td colspan="3" align="left">
<table width="580" border="0" cellspacing="0" cellpadding="0">
<tr>
<td align="center">&nbsp;&nbsp;&nbsp;要评论该转贴，请先<a href="/accounts/login.aspx">登录</a></td>
</tr>
</table>
</td>
</tr>
</asp:PlaceHolder>


</table></td>
<td width="210" align="right" valign="top"><table width="180" border="0" cellpadding="0" cellspacing="1" bgcolor="#D2D2D2">
<tr>
<td valign="top" bgcolor="#FFFFFF"><table width="180" border="0" cellpadding="0" cellspacing="4" class="gray">
<tr>
<td height="22" align="right">来自：</td>
<td width="97" align="left">
    <asp:Literal ID="Literal3" runat="server"></asp:Literal> 的转帖</td>
</tr>
<tr>
<td width="70" height="22" align="right">时间：</td>
<td align="left"><asp:Literal ID="Literal4" runat="server"></asp:Literal></td>
</tr>
<tr>
<td height="22" align="right"> 累计转帖：</td>
<td align="left"><asp:Literal ID="Literal5" runat="server"></asp:Literal></td>
</tr>
<tr>
<td height="22" align="right"> 累计浏览：</td>
<td align="left"><asp:Literal ID="Literal6" runat="server"></asp:Literal></td>
</tr>
</table></td>
</tr>

</table>
<br>
<table width="180" border="0" cellpadding="0" cellspacing="1" bgcolor="#D2D2D2">
<tr>
<td valign="top" bgcolor="#FFFFFF"><table width="180" border="0" cellpadding="0" cellspacing="4">
<tr>
  <td height="22" align="left">&nbsp;&nbsp;&nbsp;&nbsp;查看：</td>
</tr>
<tr>
  <td height="22" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/jt1.gif">&nbsp;<a href="index.aspx">我的转帖</a></td>
</tr>
<tr>
  <td height="22" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/jt1.gif">&nbsp;<asp:Literal ID="Literal7" runat="server"></asp:Literal></td>
</tr>
<tr>
  <td height="22" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/jt1.gif">&nbsp;<a href="random.aspx">今日热门转贴</a></td>
</tr>

</table></td>
</tr>
</table></td>
</tr>
<tr>
<td height="20" colspan="2"></td>
</tr>

<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate>
<tr>
<td height="20" colspan="3">
<table width="580" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="80" height="34" align="center" valign="middle" ><div class="picSmall"><a href="/home/space.php?uid=<%#Eval("UCenterHomeUid").ToString() %>"><img src="/uc/avatar.php?uid=<%#Eval("UCenterHomeUid").ToString() %>&size=small&type=virtual" width="50" height="50" border="0"></a>
    <a href="#"></a></div></td>
<td width="500" valign="top"><table width="500" border="0" cellspacing="0" cellpadding="0">

    <tr>
      <td width="505"><table width="500" border="0" cellspacing="0" cellpadding="0">

          <tr>
            <td width="368" height="22" class="gray"><a href="/home/space.php?uid=<%#Eval("UCenterHomeUid").ToString() %>" name="comment<%#Eval("cid").ToString() %>"><%#Eval("realname").ToString() %></a>说道：</td>
            <td width="135" align="right" class="gray"><%#Eval("ctime").ToString() %></td>
          </tr>
          <tr>
            <td height="22" colspan="2"> <%#Eval("txt").ToString() %></td>
          </tr>
      </table></td>
    </tr>
</table></td>
</tr>

<tr>
<td height="20"></td>
<td height="20">&nbsp;</td>
</tr>
<tr>
<td height="1" colspan="2" bgcolor="#DEDFE1"></td>
</tr>
</table><br>
</td>
</tr>                                          
</ItemTemplate>
</asp:Repeater>
                                  
                              
</table>
</li>
</ul>
</DIV>
</DIV>
</DIV><!--/mainarea-->
<DIV id=bottom></DIV>
</DIV><!--/main-->
<clubfooter:clubfooter ID="clubfooter1" runat="server" />
</DIV>

</form>
</BODY></HTML>
