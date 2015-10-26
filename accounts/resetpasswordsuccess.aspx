<%@ Page Language="C#" AutoEventWireup="true" CodeFile="resetpasswordsuccess.aspx.cs" Inherits="accounts_sendmailpassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
        <link href="css/bbs.css" rel="stylesheet" type="text/css" />
    <link href="/css3/fcl.css" rel="stylesheet" type="text/css" />
    <script language="javascript">
 var t = 5;
 function fun1(){
  t--;
  document.getElementById("aaa").innerHTML = t;
  if(t<=0){
   location.href = "/";
   clearInterval(inter);
  }
 }
 var inter = setInterval("fun1()",1000);
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main_container"><!--页面主体开始-->	
		
		<usertoptop20100711:usertoptop20100711 ID="usertoptop20100711_1" runat="server" />
<usertopmid20100711:usertopmid20100711 ID="usertopmid20100711_1" runat="server" />		
<usertopmenu20100711:usertopmenu20100711 ID="usertopmenu20100711_1" runat="server" />
		<div class="main_content"><!--中部开始-->
			<div class="pass">
			  <p style="text-align:center;"><img src="images/bbs/dg.jpg" width="27" height="24" />重设密码成功，<span id="aaa">5</span>秒后自动跳转到首页！
			  <br />
			  <a href="/">没有反应请点击这里</a>
			  </p>
		  </div>
	
		</div>		
		
<userbottom100414:userbottom100414 ID="userbottom100414_1" runat="server" />
</div>
<!--页面主体结束-->	
    </form>
</body>
</html>
