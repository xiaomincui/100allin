<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" EnableEventValidation="false" EnableViewState="false"%><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" content="环球运费网是全球最大的运费查询与订舱平台,提供海运运价与空运运价查询和订舱服务,拥有海量货主与货代会员进行运费查询和在线订舱,更多运费查询订舱服务请点击进入" />
<meta name="keywords" content="运费,运价,订舱" /> 
<meta name="viewport" content="width=1280, initial-scale=0.2"/>
<link href="/css2015/master.css" rel="stylesheet" type="text/css" />
<link href="/css2015/doc.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://api.map.baidu.com/api?v=1.4"></script>

<style type="text/css">
#container {
height: 300px;
width: 704px;
margin-bottom:50px;
}
</style>
<title>环球运费网-联系我们</title>
</head>
<body>
    <div class="header">
		<headtop20150520:headtop20150520 ID="headtop201505201" runat="server" />
		<headmid220150520:headmid220150520 ID="headmid2201505201" runat="server" />
		<div class="header-line"></div>
	</div>

    <div class="container">
        <div class="container-hd breadcrumbs">
            <a href="/">首页</a><span class="sep">-</span><span>联系我们</span>
        </div>
        <div class="container-bd">
            <div class="doc-left">
                <h1 class="hd-title">联系我们</h1>
                <p><img src="/images2015/contact.jpg" /></p>
                <h1 class="hd-title">地址</h1>
                <p class="nospace">
                    上海市延安东路700号港泰广场903室<br/>
                </p>
                <div id="container"></div>
                    <script type="text/javascript">
                        //var map = new BMap.Map("container"); // 创建地图实例

                        //map.addControl(new BMap.NavigationControl());  
                        //map.addControl(new BMap.ScaleControl());  
                        //map.addControl(new BMap.OverviewMapControl());  
                        //map.addControl(new BMap.MapTypeControl());  
                        //map.setCurrentCity("上海市"); // 仅当设置城市信息时，MapTypeControl的切换功能才能可用
                        //map.enableScrollWheelZoom();
                        //var local = new BMap.LocalSearch("上海市", {  
                        //renderOptions: { map: map },  
                        //pageCapacity: 1 
                        //});  
                        //local.search("延安东路700号903室");  
                        var map = new BMap.Map("container"); // 创建地图实例
                        map.addControl(new BMap.NavigationControl());
                        map.addControl(new BMap.ScaleControl());
                        map.addControl(new BMap.OverviewMapControl());
                        map.addControl(new BMap.MapTypeControl());
                        var myGeo = new BMap.Geocoder();
                        // 将地址解析结果显示在地图上，并调整地图视野     
                        myGeo.getPoint("上海市延安东路700号", function (point) {
                            if (point) {
                                map.centerAndZoom(point, 18);
                                var opts = {
                                    //width : 250,     // 信息窗口宽度     
                                    //height: 100,     // 信息窗口高度     
                                    title: "<b style=\"font-size:15px;\">上海傲赢信息技术有限公司<b>"  // 信息窗口标题     
                                }
                                var infoWindow = new BMap.InfoWindow("<div style=\"margin-top:5px;\">上海市延安东路700号港泰广场903室<div>", opts);  // 创建信息窗口对象     
                                map.openInfoWindow(infoWindow, map.getCenter());
                            }
                        }, "上海市");  						
                    </script>
                <h1 class="hd-title">创始人</h1>
                <p class="nospace">
                    谈国樑<br />
                    直线：021-53853188<br />
                    手机：13901666085<br />
                </p>
            </div>
            <div class="doc-right">
                <div class="uc-nav-box">
                <div class="box-hd">
                    <h3 class="title">环球运费网</h3>
                </div>
                <div class="box-bd">
                    <ul class="uc-nav-list">
                        <li><a href="/about.html">关于我们</a></li>
                        <li><a href="/service.html">服务条款</a></li>
                        <li><a href="/law.html">法律声明</a></li>
                        <li><a href="/sitemap.html">网站地图</a></li>
                        <li class="current"><a href="/contact.html">联系我们</a></li>
                    </ul>
                </div>
            </div>
            </div>
        </div>
    </div>
    
        <footer20150520:footer20150520 ID="footer201505201" runat="server" />

</body>
</html>

