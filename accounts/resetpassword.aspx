<%@ Page Language="C#" AutoEventWireup="true" CodeFile="resetpassword.aspx.cs"  enableEventValidation="false" Inherits="accounts_resetpassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="css/bbs.css" rel="stylesheet" type="text/css" />
    <link href="/css3/fcl.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    #ImageButton1 {margin:-5px 0px 0 0;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main_container"><!--页面主体开始-->	
		<div class="h_box">
<usertoptop20100711:usertoptop20100711 ID="usertoptop20100711_1" runat="server" />
<usertopmid20100711:usertopmid20100711 ID="usertopmid20100711_1" runat="server" />		
<usertopmenu20100711:usertopmenu20100711 ID="usertopmenu20100711_1" runat="server" />
</div>
		<div class="main_content"><!--中部开始-->
			<div class="pass"><span class="p_title"><img src="images/bbs/pass_2.jpg" />忘记了密码</span>
              <p>请在下面填入您的环球运费网会员用户名
              <br />
              <table width="300" border="1" bordercolor="#FDF6F4">
                  <tr>
                    <td bordercolor="#FDF6F4" style="width:60px">
                        新密码：</td>
                    <td bordercolor="#FDF6F4"><input name="textfield" type="password" size="30" style="float:left;" id="Text1" runat="server" /></td>
                  </tr>
                  <tr>
                    <td bordercolor="#FDF6F4">确  认：</td>
                    <td bordercolor="#FDF6F4"><input name="textfield" type="password" size="30" style="float:left;" id="Text2" runat="server" /></td>
                  </tr>

                </table>
              
              
              
              
              <br />
                  <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/bbs/pass_3.gif" OnClick="ImageButton1_Click" />
                          <br />
              如果您还不是环球运费网会员，您可以<a style="color:#FF6600;" href="#">立即注册</a> <br />
              <span style="border-bottom:1px dotted #ebd2ca; width:900px; display:block;">&nbsp;</span><br />

              还有其它问题，请联系我们
              <br />
              联系电话：
              <br />
              总机：400-888-9256
              <br />
              客户服务部：021-51086987-106<a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=332516191&site=qq&menu=yes"></a>
              <br />
              客服QQ1：<a target="_blank" href="http://wpa.qq.com/msgrd?v=3&amp;uin=332516191&amp;site=qq&amp;menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=2:744593820:41" alt="点击这里给我发消息" title="点击这里给我发消息" /></a>（点击可直接联系我） 
              <br />
              客服QQ2：<a target="_blank" href="http://wpa.qq.com/msgrd?v=3&amp;uin=332516191&amp;site=qq&amp;menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=2:914019684:41" alt="点击这里给我发消息" title="点击这里给我发消息" /></a>（点击可直接联系我） 

              <br />
              传真：021-63509508

              <br />
              E-mail：allin@100allin.com</p>
		  </div>
	
		</div>	
		
		
<userbottom100414:userbottom100414 ID="userbottom100414_1" runat="server" />

	

</div>
<!--页面主体结束-->	
    </form>
</body>
</html>
