<%@ Page Language="C#" AutoEventWireup="true" CodeFile="regnew.aspx.cs" Inherits="accounts_reg" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="最新运费 海运运费 空运运费  整箱运价 拼箱运价 运价排行 货运代理 货主 运价查询" />
<meta name="description" content="环球运费网是全球最大的专业运价查询平台，主要提供全面、高效、简捷的海空运运价的发布和查询服务。拥有海量货主会员进行运价的查询和对比，更多运价查询信息请点击进入。" />
<title>免费注册初级会员</title>
<link href="css/login.css" rel="stylesheet" type="text/css" />
<style type="text/css">
<%--.usename{
onfocus: expression(onfocus=function(){this.className="input01"})
}
.input01{
onblur: expression(onblur=function(){this.className="usename"})
}--%>



</style>

<script type="text/javascript">
function a()
{
    document.getElementById("Username223").className="";
}



function isEmail(s) 
{ 

} 


function txtonfocus(s)
{
    //s.className="input01";
    document.getElementById("div"+s.id).style.display = "";
    
    if(s.id=="UserName")
    {
        divchange("UserName",1,"请输入用户名");
    }
    else if(s.id == "UserPassword")
    {
        divchange("UserPassword",1,"请输入密码");
    }
    else if(s.id == "UserPassword2")
    {
        divchange("UserPassword2",1,"请再输入一遍您上面填写的密码");
    }
    else if(s.id == "UserEmail")
    {
        divchange("UserEmail",1,"请输入邮箱");
    }
    else if(s.id == "RealName")
    {
        divchange("RealName",1,"请输入真实姓名");
    }
    else if(s.id == "Company")
    {
        divchange("Company",1,"请输入公司名称");
    }
    else if(s.id == "Phone")
    {
        divchange("Phone",1,"请输入电话号码");
    }
    
}

function txtonblur(s,type)
{
    
    if(s.value.length!=0)
    {
       
        if(s.id=="UserName")
        {
            CallServer1();
        }
        else if(s.id=="UserPassword")
        {
            if(s.value.length>=6 && s.value.length<=15)
            {
                divchange("UserPassword",2,"正确");
                if(s.value==document.getElementById("UserPassword2").value)
                {
                    divchange("UserPassword2",2,"正确");
                }
            }
            else
            {
                divchange("UserPassword",3,"密码长度错误");
            }
        }
        else if(s.id=="UserPassword2")
        {
            if(document.getElementById("UserPassword").className=="input02")
            {
                divchange("UserPassword2",3,"密码错误");
            }
            else if(s.value==document.getElementById("UserPassword").value)
            {
                divchange("UserPassword2",2,"正确");
            }
            else
            {
                divchange("UserPassword2",3,"2次密码不同");
            }
        }
        else if(s.id=="UserEmail")
        {
            
            var patrn=/(\S)+[@]{1}(\S)+[.]{1}(\w)+/; 
            if (patrn.exec(s.value)) 
            {
                divchange("UserEmail",2,"正确");
            }
            else 
            {
                divchange("UserEmail",3,"邮件地址格式错误");
            }
        }
        else if(s.id=="RealName")
        {
            divchange("RealName",2,"正确");
        }
        else if(s.id=="Company")
        {
            divchange("Company",2,"正确");
        }
        else if(s.id=="Phone")
        {
            divchange("Phone",2,"正确");
        }
    }
    else
    {
        if(type==1)
        {
            document.getElementById("div"+s.id).style.display = "";
            divchange(s.id,3,"必填");
        }
        else
        {
            document.getElementById("div"+s.id).className="standard";
            document.getElementById("div"+s.id).style.display = "none";
        }
         
    }
    
}

//改变文字和样式,s为控件id，c为状态，t为替换文本
//c:1为提示，2为正确，3为错误
function divchange(s,c,t)
{
    if(document.getElementById("div"+s).tagName=="DIV")
    {
        if(c==1)
        {
            document.getElementById(s).className="usename";
            document.getElementById("div"+s).className="common";
            
        }
        else if (c==2)
        {
            document.getElementById(s).className="input01";
            document.getElementById("div"+s).className="standard";
        }
        else
        {
            document.getElementById(s).className="input02";
            document.getElementById("div"+s).className="notices";
            
        }
        document.getElementById("div"+s).innerHTML=t;
    }
    else
    {
        alert(document.getElementById(s).tagName);
    }
    
}

function CallServer1()
{   
    context = ""
    //showTip('tipUserNameNormal','tipUserNameTrue','tipUserNameFalse')
    //context.innerHTML = "<table style='width:700px;height:220px;text-align:center'><tr><td>正在更新订单数据...</td></tr></table>";
    document.getElementById("divUserName").innerHTML="正在检测用户名......";
    arg = "username" + "|" + document.getElementById("UserName").value;
    <%= ClientScript.GetCallbackEventReference(this, "arg", "ReceiveServerData1", "context")%>;
}

//接受callback从服务器传来的数据
function ReceiveServerData1(result, context)
{
    if (result == "success"){
        divchange("UserName",2,"正确");
        //document.getElementById("divUserName")
        //showTip('tipUserNameTrue','tipUserNameNormal','tipUserNameFalse')
    }
    else {
        divchange("UserName",3,"您的用户名已被注册，请换一个");
        //showTip('tipUserNameFalse','tipUserNameNormal','tipUserNameTrue')
    }
}

function checkAll()
{
    //txtonblur(document.getElementById("UserName"),1);
    txtonblur(document.getElementById("UserPassword"),1);
    txtonblur(document.getElementById("UserPassword2"),1);
    txtonblur(document.getElementById("UserEmail"),1);
    txtonblur(document.getElementById("RealName"),1);
    txtonblur(document.getElementById("Company"),1);
    txtonblur(document.getElementById("Phone"),1);
    
    if(document.getElementById("divUserName").className!="standard")
    {
        document.getElementById("UserName").focus();
    }
    else if(document.getElementById("divUserName").style.display!="")
    {
        document.getElementById("UserName").focus();
    }
    else if(document.getElementById("divUserPassword").className!="standard" || document.getElementById("divUserPassword").style.display!="")
    {
        document.getElementById("UserPassword").focus();
    }
    else if(document.getElementById("divUserPassword2").className!="standard" || document.getElementById("divUserPassword2").style.display!="")
    {
        document.getElementById("UserPassword2").focus();
    }
    else if(document.getElementById("divUserEmail").className!="standard" || document.getElementById("divUserEmail").style.display!="")
    {
        document.getElementById("UserEmail").focus();
    }
    else if(document.getElementById("divRealName").className!="standard" || document.getElementById("divRealName").style.display!="")
    {
        document.getElementById("RealName").focus();
    }
    else if(document.getElementById("divCompany").className!="standard" || document.getElementById("divCompany").style.display!="")
    {
        document.getElementById("Company").focus();
    }
    else if(document.getElementById("divPhone").className!="standard" || document.getElementById("divPhone").style.display!="")
    {
        document.getElementById("Phone").focus();
    }
    else
    {
        
        document.getElementById("Button1").disabled=true;
        document.getElementById("Button1").value="正在提交，请稍候";
        document.getElementById("Button2").click();
    }
    
}

</script>
</head>
<body>
<form id="form1" runat="server">
<div class="main_container"><!--页面主体开始-->
  <!--顶部登陆结束-->
<div class="header"><!--头部LOGO开始-->	
			<div id="logo">
				<a href="/" target="_blank"><img src="images/logo.gif" alt="环球运费网" border="0" width="340" height="75" /></a>			</div>
			<ul><li><a title="欢迎使用在线客服" href="#" onclick="document.getElementById('aliserv').click();">在线客服</a> | <a href="/" target="_blank">返回首页</a><br />
			  如遇注册问题请拨打：<span class="red">400-888-9256</span></li>
			</ul>
  </div><!--头部LOGO结束-->
  <div class="menu"><!--导航开始-->
			<h1><span style="color:#29395b;">注册步骤</span>：<span class="orange"><img src="images/1.jpg" width="12" height="12" /><strong>注册初级会员</strong></span> >    <img src="images/2_2.JPG" width="12" height="12" />注册普通会员 >    <img src="images/3_3.JPG" width="12" height="12" />审核注册资料 </h1>
  <span class="right_tn"><a>*</a> 为必填项</span></div>
		<!--导航结束-->
		<div class="main_content"><!--中部开始-->
		  <div class="login_box">
		  	<div class="lg">
				<h3><img src="images/jt.gif" />免费注册初级会员</h3>
								<span class="right_tn" style="padding:18px 10px 0 0;">环球运费为注册会员提供免费运价宣传</span>
				<div class="zc1">
				<table width="90%" height="289" border="0" align="center" cellpadding="0" cellspacing="1">
  <tr>
    <td height="38" colspan="3" align="left"><p><span style="font-size:14px;"><strong>注册有惊喜</strong></span><br />
      如果您是货代公司，在您注册成功后，只要一次性发布有效运价达到<strong>100</strong>条或以上，就可免费获得环球运费网站内短信群发推广一次<br />
      发送对象：网站直客和同行会员<strong>500</strong>位 <br />
      申请方法：请于注册成功后根据提示进行申请</p></td>
    </tr>
  <tr>
    <td height="38" colspan="3" align="left"><span class="red" style="font-size:14px;"><strong>以下为必填项</strong></span></td>
    </tr>				
  <tr>
    <td width="35%" height="38" align="right"><span class="red"></span>&nbsp;<span class="zc_tn">用户名</span>：</td>
    <td width="30%"><input name="UserName" type="text" class="usename" id="UserName" size="34" onfocus="txtonfocus(this)" onblur="txtonblur(this)"  runat="server" /></td>
    <td width="40%"><div id="divUserName" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
  </tr>
  <tr>
    <td height="38" align="right">&nbsp;</td>
    <td colspan="2" class="gray">用户名由1-15个字符组成，支持中文，注册成功后用户名将不可修</td>
    </tr>
  <tr>
    <td height="38" align="right"><span class="red"></span>&nbsp;<span class="zc_tn">密码</span>：</td>
    <td><input name="UserPassword" type="password" class="usename" id="UserPassword" value="" onfocus="txtonfocus(this)" onblur="txtonblur(this)" runat="server" maxlength="15" style="width: 233px"  /></td>
    <td><div id="divUserPassword" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
  </tr>
  <tr>
    <td height="38" align="right"><span class="red"></span>&nbsp;<span class="zc_tn">确认密码</span>：</td>
    <td><input name="UserPassword2" id="UserPassword2" type="password" class="usename" value="" size="35" onfocus="txtonfocus(this)" onblur="txtonblur(this)" runat="server" maxlength="15" style="width: 233px"   /></td>
    <td><div id="divUserPassword2" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
  </tr>
  <tr>
    <td height="38" align="right"><span class="red"></span>&nbsp;<span class="zc_tn">电子邮箱</span>：</td>
    <td><input name="UserEmail" type="text" class="usename" id="UserEmail" size="34" onfocus="txtonfocus(this)" onblur="txtonblur(this)" runat="server"   /></td>
    <td><div id="divUserEmail" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
  </tr>
  <tr>
    <td height="38" align="right"><span class="red"></span>&nbsp;<span class="zc_tn">公司名称</span>：</td>
    <td><input name="Company" type="text" class="usename" id="Company" size="34" onfocus="txtonfocus(this)" onblur="txtonblur(this)"  runat="server"  /></td>
    <td><div id="divCompany" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
  </tr>
  <tr>
    <td height="38" align="right"><span class="red"></span>&nbsp;<span class="zc_tn">真实姓名</span>：</td>
    <td><input name="RealName" type="text" class="usename" id="RealName" size="34" onfocus="txtonfocus(this)" onblur="txtonblur(this)"  runat="server"  /></td>
    <td><div id="divRealName" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
  </tr>
  <tr>
    <td height="38" align="right"><span class="red"></span>&nbsp;<span class="zc_tn">电话号码</span>：</td>
    <td><input name="Phone" type="text" class="usename" id="Phone" size="34" onfocus="txtonfocus(this)" onblur="txtonblur(this)"  runat="server"  /></td>
    <td><div id="divPhone" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
  </tr>
  	  <tr>
    <td height="1" colspan="3" align="center"></td>
    </tr>
  <tr>
    <td height="10" colspan="3" align="right"></td>
    </tr>
  <tr>
    <td height="32" align="right">&nbsp;</td>
    <td align="center"><a href="/service.html" target="_blank">点击此处，阅读环球运费网服务条款</a><br /></td>
    <td>&nbsp;</td>
  </tr>
  
  <tr>
    <td height="32" align="right">&nbsp;</td>
    <td align="center"><input onclick="checkAll();" name="Button1" id="Button1" value="同意服务条款,提交注册" type="button" />
        <asp:Button ID="Button2" runat="server" Text="Button" style="display:none"  OnClick="Button2_Click" />
        
    </td>
    <td>&nbsp;</td>
  </tr>
</table>
				</div>
			</div>
		  </div>
		</div>
	  
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
</form>
</body>
</html>
