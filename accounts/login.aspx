<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="accounts_login" EnableEventValidation="false" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" content="环球运费网是全球最大的运费查询与订舱平台,提供海运运价与空运运价查询和订舱服务,拥有海量货主与货代会员进行运费查询和在线订舱,更多运费查询订舱服务请点击进入" />
<meta name="keywords" content="运费,运价,订舱" /> 
<meta name="viewport" content="width=1280, initial-scale=0.2"/>
<link href="/css2015/master.css" rel="stylesheet" type="text/css" />
<link href="/css2015/accounts.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js2015/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="/js2015/index.js"></script>
<style type="text/css">

</style>
<title>环球运费网-登录</title>
</head>
<body>
<form id="form1" runat="server" autocomplete="off" onKeydown="if(event.enterKey){return   false}">
	<div class="header">
		<headtop20150520:headtop20150520 ID="headtop201505201" runat="server" />
	</div>

    <div class="container">
        
        <div class="login-box">
            <form action="login.aspx">
            <div class="login-logo"><a href="/"><img src="/images2015/logo_grey.gif" /></a></div>
            <h1 class="login-title">用户登录</h1>
            <div class="login-subtitle">登录后可发布运价，并无限制查看运价联系方式</div>
            <div class="username-field login-box-input"><label><span>用户名</span><input type="text" id="username" class="input-txt" runat="server"/></label></div>
            <div class="pwd-field login-box-input"><label><span>密码</span><input type="password" id="password" class="input-txt" runat="server"/></label></div>
            <div class="btn-field"><input type="submit" value="登录" class="login-btn" runat="server" id="ImageButton1" OnServerClick="ImageButton1_Click"/></div>
            <div class="forgot-link"><a href="/accounts/retrievepassword.aspx">忘记密码</a></div>
            <div class="reg-link"><a href="/accounts/reg.aspx">免费注册</a></div>
            <div class="tel-link"><img src="/images2015/login_tel.gif" /></div>
            </form>
        </div>
    </div>
    

    <footer20150520:footer20150520 ID="footer201505201" runat="server" />
</form>
</body>
</html>

