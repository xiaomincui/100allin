<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tab.aspx.cs" Inherits="member_tab" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>jQuery UI Example Page</title>
<style type="text/css">
.ui-tabs-nav
{
    /*导航容器定义*/
}
.ui-tabs-nav li
{
    /*默认标签样式*/
}
.ui-tabs-nav li.ui-tabs-selected
{
    /*激活的标签样式*/
}
.ui-tabs-panel
{
    /*默认的显示区域样式*/
}
.ui-tabs-hide
{
    display: none;
}
</style>

<script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>

<script type="text/javascript">
//<![CDATA[
$(function(){
      $(".ui-tabs-nav > li > a").mouseover(function(e){
          if(this == e.target){
            var container = $(this).parent().parent().parent();
            var arrNav = $(this).parent().parent().find("li");
            var index = $.inArray(this, $(this).parent().parent().find("a"));
            var panels = $(this).parent().parent().parent().find(".ui-tabs-panel");
            if (panels.eq(index).is(".ui-tabs-panel")){
              arrNav.removeClass("ui-tabs-selected").eq(index).addClass("ui-tabs-selected");
              panels.addClass("ui-tabs-hide").eq(index).removeClass("ui-tabs-hide");
            }
          }
      });//tab切换
    });//jquery的onready
//]]>
</script>

</head>
<body>
<div>
    <ul class="ui-tabs-nav">
        <li class="ui-tabs-selected"><a href="/bbs">论坛新帖</a></li>
        <li><a href="/blog">最新博文</a></li>
        <li><a href="/fcl">最新运价</a></li>        
    </ul>
    <div class="ui-tabs-panel">
      这里调用最新论坛文章
    </div>
    <div class="ui-tabs-panel ui-tabs-hide">
      这里调用最新博客文章
    </div>
    <div class="ui-tabs-panel ui-tabs-hide">
      这里调用最新运价
    </div>    
</div>		
</body>
</html>
