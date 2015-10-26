<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="map_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
<script type="text/javascript" src="http://api.mapabc.com/fmp/v1.0/js/fmp.js?key=5cb0597c8b494b0aeec7492c4a4c61fb57b8cdf121d92e0808e3f1a024a3d44f97bda90327bb15e8"></script>
</head>
<body>


	<div style="width:600px; text-align:left; font-size:16px; font-weight:bold; margin:0 auto 8px auto; height:30px; line-height:30px;">地图</div>
	<div style="font-size:small; width:760px; margin:0 auto; text-align:center;">
		<div style="width:900px; height:600px; overflow-y:auto;border:1px solid #666666; margin:0 auto;" id="mapObj"></div>

		<SCRIPT LANGUAGE="JavaScript">
	//////////flash引擎///////////////
	var city_center_index="JJJMTRPRRNHLHL,LIGQRTHULLHL";
	//创建地图对象
	var mapOptions = new MMapOptions();
	mapOptions.mapId = "fmptest";
	mapOptions.zoomLevel = 17;
	mapOptions.center = new MLatLng(city_center_index);
	//创建地图对象
	var mapObj = new MMap("mapObj", mapOptions);

//注册导出地图数据事件 后执行 onexportMapData 方法
mapObj.addEventListener(MMap.EVENT_EXPORT_MAP_DATA, onexportMapData);


function editMode(){
//设置地图为编辑模式
mapObj.setMapMode(MMapMode.EDIT);
}

//编辑模式下 添加点
function createPoint(){
var defaultPointStyle = new MStyle();
defaultPointStyle.canBeTop = true;
mapObj.addGeometry(MGeometry.TYPE_POINT, defaultPointStyle);
}


//编辑模式添加折线
function createPolyline(){
//定义缺省的多折线样式
var polylineStyle = new MStyle();
polylineStyle.lineColor = 0x00ff00;
polylineStyle.lineSize = 5;
polylineStyle.lineOpacity = 60;
polylineStyle.showTip = true;

mapObj.addGeometry(MGeometry.TYPE_POLYLINE, polylineStyle);
}

//导出地图数据事件处理函数
function onexportMapData(event){
alert(event.args);
/**
event.type=”onExportMapData”
event.args=mapId,jsonString
args 的值是一个以“,”分隔的字符串，其中：
mapId：地图的Id
jsonString：整个地图的几何对象的JSON 字符串。
**/
}

function createPolygon(){
//定义缺省的多边形样式
var polygonStyle = new MStyle();
polygonStyle.lineColor = 0x00ff99;
polygonStyle.lineSize = 5;
polygonStyle.lineOpacity = 60;
polygonStyle.fillOpacity = 50;
polygonStyle.fillColor = 0x999900;

mapObj.addGeometry(MGeometry.TYPE_POLYGON, polygonStyle);
}
　
//导出点的数据方法
function exportMapData(){
mapObj.exportMapData();
}

//导出地图数据事件处理函数
function onexportMapData(event){
alert(event.args);
/**
event.type=”onExportMapData”
event.args=mapId,jsonString
args 的值是一个以“,”分隔的字符串，其中：
mapId：地图的Id
jsonString：整个地图的几何对象的JSON 字符串。
**/
}


	</SCRIPT> 

操作方法: 先在 地图上左键标点 并填入标题 内容点击确定. 然后点击导出数据<br /><br />


<input type="button" onClick="javascript:editMode();" value="进入编辑模式" /> 
<input type="button" onClick="javascript:createPoint();" value="添加点" /> 
<input type="button" onClick="javascript:createPolygon();" value="添多边形" /> 
<input type="button" onClick="javascript:createPolyline();" value="添折线" /> 
<input type="button" onClick="javascript:exportMapData();" value="导出数据" /> 
</body>
</html>