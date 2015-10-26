<%@ Page Language="C#" AutoEventWireup="true" CodeFile="links.aspx.cs" Inherits="links" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>友情链接-环球运费网</title>

    <link href="/css/fcl_css.css" rel="stylesheet" type="text/css" />

    <style type="text/css">


.divexcees {
    text-overflow:clip;
    overflow: hidden;
}

.pm a:link {
	color: #666666;
	text-decoration: none;
}
.pm a:visited {
	text-decoration: none;
	color: #666666;
}
.pm a:hover {
	text-decoration: none;
	color: #FF6600;
}
.pm a:active {
	text-decoration: none;
	color: #666666;
}

.divexcees a:link {
	color: #333333;
	text-decoration: underline;
}
.divexcees a:visited {
	text-decoration: underline;
	color: #333333;
}
.divexcees a:hover {
	text-decoration: underline;
	color: #FF6600;
}
.divexcees a:active {
	text-decoration: underline;
	color: #333333;
}
.hidden {
    display:none;
}
</style>
<script language="javascript" type="text/javascript" src="../js/function.js"></script>
<script type="text/javascript" language="javascript">
function PageJump()
{
if(event.keyCode==13){
event.keyCode=9
document.getElementById("btnPageJump").click();
};
}

function testlink()
{
    var yids = document.getElementById('delList').value;
    if (yids == "")
    {
        alert("请选择运价后进行讨价还价")
        document.getElementById('testlink').target = "_self";
        document.getElementById('testlink').href = "javascript:;";
    }
    else
    {   
        document.getElementById('testlink').target = "_blank";
        document.getElementById('testlink').href = "/search/dicker.aspx?type=fcl&yid=" + yids;
    }
    
}

</script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="main_container"><!--页面主体开始-->	
		<usernewtop:usernewtop ID="usernewtop1" runat="server" />
		<div class="menu"><!--导航开始-->
			<h1><userwelcome:userwelcome ID="userwelcome1" runat="server" />您现在的位置:<a href="/" target="_blank">首页</a> > 友情链接</h1>
			<userservice:userservice ID="userservice1" runat="server" />
		</div><!--导航结束-->
		<div class="main_content"><!--中部开始-->
			<div class="main_left"><!--左边开始-->
                <div class="news_bar">
					<div class="bar_box">
						<div class="artibody">
						  <div style="line-height:28px; border-bottom:1px solid #C8D8F2; color:#28385A;"><strong>
					      相关链接</strong></div>
						  <br />
						  <strong>贸易类</strong>
                            <asp:DataList ID="DataList1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" CellPadding="3" CellSpacing="1">
                                <ItemTemplate>
                                    <a href="<%#Eval("link") %>" target="_blank"><%#Eval("linkname") %></a>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:DataList>
                          <br />
						  <strong>物流类</strong>
                            <asp:DataList ID="DataList2" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" CellPadding="3" CellSpacing="1">
                                <ItemTemplate>
                                    <a href="<%#Eval("link") %>" target="_blank"><%#Eval("linkname") %></a>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:DataList>                          
                          <br />
						  <strong>其他类</strong>
                            <asp:DataList ID="DataList3" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" CellPadding="3" CellSpacing="1">
                                <ItemTemplate>
                                    <a href="<%#Eval("link") %>" target="_blank"><%#Eval("linkname") %></a>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:DataList>
						</div>
					</div>
		      </div>
									  				
			</div><!--左边结束-->	
			<div class="main_right"><!--右边开始-->

				<userrate2:userrate2 ID="userrate22" runat="server" />
				<usertranslate2:usertranslate2 ID="usertranslate22" runat="server" />
			</div><!--右边结束-->		
  		</div>
	  <userbottomline:userbottomline ID="userbottomline1" runat="server" />
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
	<asp:Panel ID="dropdown1" Height="150px" ScrollBars=Vertical runat=server ></asp:Panel>
	<asp:Panel ID="dropdown2" Height="150px" ScrollBars=Vertical runat=server ></asp:Panel>
	<asp:Panel ID="dropdown3" Height="150px" ScrollBars=Vertical runat=server ></asp:Panel>
    </form>
<script type="text/javascript">
document.getElementById('dropdown1').style.display='none';   
document.getElementById('dropdown2').style.display='none';      
document.getElementById('dropdown3').style.display='none';     
</script>    

</body>
</html>