<%@ Page Language="C#" AutoEventWireup="true" CodeFile="static1.aspx.cs" Inherits="message_Default" validateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>傲赢网 - 论坛</title>
    <link href="css/fcl_css.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
<!--
#pp td{nowrap=true;}

.divexcees {
    text-overflow:ellipsis;
    overflow: hidden;
}

.divexcees a:link {
	color: #293B5E;
	text-decoration: underline;
}
.divexcees a:visited {
	text-decoration: underline;
	color: #293B5E;
}
.divexcees a:hover {
	text-decoration: underline;
	color: #FF6600;
}
.divexcees a:active {
	text-decoration: underline;
	color: #293B5E;
}
.hidden {
    display:none;
}
-->
</style>

<script language="javascript" type="text/javascript" src="../js/function.js"></script>
<script language="JavaScript">



function showerrimg(obj){
     var errorimg = "http://www.100allin.com/message/wu.gif";//替换图片地址
     obj.src = errorimg;
}

function ImgAdapter()
{
   
  var   xx=document.getElementById("right");   
  var   imgs=xx.getElementsByTagName("img");
  var g
  for   (var i=0;i<imgs.length;i++)   
  {
    
    g=imgs[i];
    if(g.width>500){g.width=500} 
  }
  
}  
</script>


</head>
<body onload="AutoTips('officetips');ImgAdapter()">
<form id="form2" runat="server" autocomplete="off" onKeydown="if(event.enterKey){return   false}">
<asp:ScriptManager ID="ScriptManager1" runat="server"> 
</asp:ScriptManager>
<script language="javascript" type="text/javascript">
    Sys.Application.add_load(function(){var form=Sys.WebForms.PageRequestManager.getInstance()._form;form._initialAction=form.action=window.location.href;});
</script>
    
    <div class="main_container"><!--页面主体开始-->	
		<usernewtop:usernewtop ID="usernewtop1" runat="server" />
		<div class="menu"><!--导航开始-->
			<h1><userwelcome:userwelcome ID="userwelcome1" runat="server" />
			您现在的位置:
			<a href="/" target="_blank">首页</a> > 
			<a href="/bbs/" target="_blank">论坛</a> > 
			<a href="/bbs/" target="_blank">论坛</a> > 
			<div id="divtitle"></div></h1>
			<%--<asp:Label ID="Label10" runat="server" Text="Label"></asp:Label> > 
			<asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></h1>--%>
			<userservice:userservice ID="userservice1" runat="server" />
		</div><!--导航结束-->
		<div class="main_content"><!--中部开始-->
			<div id="right" class="main_left"><!--左边开始-->
			  <table width="100%" border="1" cellspacing="0" 
bordercolor="#9EBCDE" rules="rows" id="GridView1" style="WIDTH:742px; BORDER-COLLAPSE: collapse">
                <tbody>
				<tr>
                    <td height="28" colspan="5" align="left" background="images/bbs/bbs_bg.gif">&nbsp;&nbsp;<a href="BBSList.aspx"><asp:Label ID="Label11" runat="server" Text="论坛首页"></asp:Label></a>
                                         > &nbsp;<span class="blue"><asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
                                            &gt; &nbsp;<asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></span>
                                            
                            <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label></td>
                  </tr>
					<tr style="HEIGHT: 35px">
                    <td height="35" colspan="2" align="left" valign="middle">&nbsp;&nbsp;&nbsp;<a href="BBSList.aspx"><asp:Image ImageUrl="~/message/images/BBSdefalut.gif" ID="Image3" runat="server" /></a></td>
                    <td width="130" align="center">&nbsp;</td>
                    <td width="116" align="center">&nbsp;</td>
                    <td width="116" align="center">
                    </td>
                  </tr>
			    </tbody>
		      </table>
		      
		      
		      <TABLE style="BORDER-RIGHT: #9ebcde 1px solid; FLOAT: left; BORDER-LEFT: #9ebcde 1px solid; BORDER-bottom: #9ebcde 1px solid" height=161 width=742>
  <TBODY>
  <TR>
    <TD vAlign=top width=150><BR>
      <DIV align=center><asp:Image ID="Image1" runat="server"  width="70" height="70"   /></DIV>
      <DIV align=center><div class="divexcees" style="width:60px"><nobr><asp:Label ID="laltitlename" runat="server" Text="Label"></asp:Label></nobr></DIV></DIV></TD>
    <TD width=650>
      <TABLE style="FLOAT: left" height=144 width=650>
        <TBODY>
        <TR>
          <TD style="HEIGHT: 21px">
            <DIV style="FLOAT: left"><SPAN id=SPAN40 
            style="FONT-WEIGHT: bold">标题：</SPAN> <SPAN id=SPAN41 
            style="FONT-WEIGHT: bold"> <asp:Label ID="Label4" runat="server" Text="Label" Font-Bold="True"></asp:Label></SPAN></DIV>
            <DIV align=right><SPAN id=SPAN42>楼主<asp:Label ID="Label8" runat="server" Text="编辑于："></asp:Label><asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></SPAN></DIV></TD>
            
            </TR>
        <TR>
          <TD style="HEIGHT: 96px">
            <DIV style="word-wrap:break-word;line-height:23px;">
                &nbsp;</DIV></TD></TR>
        <TR>
          <TD style="BORDER-TOP: 1px solid; HEIGHT: 21px"><SPAN 
            id=SPAN44><asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></SPAN></TD></TR>
        <TR>
          <TD style="TEXT-ALIGN: right" height=21>
        </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
        
		      
		      
		      
		      
		      
		      
		      
		      
		      
                <TABLE id="floor1"
	style="BORDER-RIGHT: #9ebcde 1px solid; FLOAT: left; BORDER-LEFT: #9ebcde 1px solid; BORDER-bottom: #9ebcde 1px solid" 
	height=161 width=742>
	  <TBODY>
	  <TR>
		<TD vAlign=top width=150><BR>
		  <DIV align=center><IMG 
		  src="images/bbs/default.jpg" width="70" height="70" id=IMG1 
		  style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-RIGHT-WIDTH: 0px"> </DIV>
		  <DIV align=center><SPAN id=SPAN1>前突后崛</SPAN></DIV></TD>
		<TD width=650>
		  <TABLE style="FLOAT: left" height=144 width=650>
			<TBODY>
			<TR>
			  <TD style="HEIGHT: 21px">
				<DIV style="FLOAT: left"><SPAN id=Label5 
				style="FONT-WEIGHT: bold">标题：</SPAN> <SPAN id=SPAN2 
				style="FONT-WEIGHT: bold">今年货代会很难做。。。。。</SPAN></DIV>
				<DIV align=right><SPAN id=Label3>楼主</SPAN></DIV></TD></TR>
			<TR>
			  <TD style="HEIGHT: 96px">
				<DIV style="WORD-BREAK: break-all;line-height:23px;"><SPAN 
				id=Label1>今年货代会很难做。。。。。<BR><BR><BR>不管是专接FOB的货代还是专做LOCAL货。。。。。。。<BR><BR><BR>反正我知道厦门的货代“冬天”来得好早。。。。拖车倒掉一大片，货代也一样！　他港的兄弟姐妹们，你们那边状况如何？</SPAN></DIV></TD></TR>
			<TR>
			  <TD style="BORDER-TOP: 1px solid; HEIGHT: 21px"><SPAN 
				id=SPAN3>没有签名</SPAN></TD></TR>
			<TR>
			  <TD style="TEXT-ALIGN: right" height=21> 
			</TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
			

                            
                            
                            
                             
                             
                             
                             
                             
                             
				
				
				
				
				
			</div>
			<!--左边结束-->	
			<div class="main_right"><!--右边开始-->
			  <div class="right_box">
					<div class="right_box_title"><h2>您浏览过的运价有</h2>
					</div>
					<ul>
					<asp:Label ID="Label22" runat="server" Text=""></asp:Label>
					</ul>
				</div>
				<div class="right_box">
					<div class="right_box_title"><h2>您搜索过的港口有</h2>
					</div>
					
					    <ul>
                         <asp:Label ID="Label23" runat="server" Text=""></asp:Label>
                         
                         </ul>
					
				</div>
				
				<userrate2:userrate2 ID="userrate22" runat="server" />
				<usertranslate2:usertranslate2 ID="usertranslate22" runat="server" />
			</div><!--右边结束-->		
  		</div>
	  <userbottomline:userbottomline ID="userbottomline1" runat="server" />
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
    
    
    
    
    
    
</form>		
<script language="javascript" src="http://count48.51yes.com/click.aspx?id=485102224&logo=1">
function right_onclick() {

}

</script>	
</body>
</html>