<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="map_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
<script type="text/javascript" src="http://api.mapabc.com/fmp/v1.0/js/fmp.js?key=5cb0597c8b494b0aeec7492c4a4c61fb57b8cdf121d92e0808e3f1a024a3d44f97bda90327bb15e8"></script>
</head>
<body>


	<div style="width:600px; text-align:left; font-size:16px; font-weight:bold; margin:0 auto 8px auto; height:30px; line-height:30px;">��ͼ</div>
	<div style="font-size:small; width:760px; margin:0 auto; text-align:center;">
		<div style="width:900px; height:600px; overflow-y:auto;border:1px solid #666666; margin:0 auto;" id="mapObj"></div>

		<SCRIPT LANGUAGE="JavaScript">
	//////////flash����///////////////
	var city_center_index="JJJMTRPRRNHLHL,LIGQRTHULLHL";
	//������ͼ����
	var mapOptions = new MMapOptions();
	mapOptions.mapId = "fmptest";
	mapOptions.zoomLevel = 17;
	mapOptions.center = new MLatLng(city_center_index);
	//������ͼ����
	var mapObj = new MMap("mapObj", mapOptions);

//ע�ᵼ����ͼ�����¼� ��ִ�� onexportMapData ����
mapObj.addEventListener(MMap.EVENT_EXPORT_MAP_DATA, onexportMapData);


function editMode(){
//���õ�ͼΪ�༭ģʽ
mapObj.setMapMode(MMapMode.EDIT);
}

//�༭ģʽ�� ��ӵ�
function createPoint(){
var defaultPointStyle = new MStyle();
defaultPointStyle.canBeTop = true;
mapObj.addGeometry(MGeometry.TYPE_POINT, defaultPointStyle);
}


//�༭ģʽ�������
function createPolyline(){
//����ȱʡ�Ķ�������ʽ
var polylineStyle = new MStyle();
polylineStyle.lineColor = 0x00ff00;
polylineStyle.lineSize = 5;
polylineStyle.lineOpacity = 60;
polylineStyle.showTip = true;

mapObj.addGeometry(MGeometry.TYPE_POLYLINE, polylineStyle);
}

//������ͼ�����¼�������
function onexportMapData(event){
alert(event.args);
/**
event.type=��onExportMapData��
event.args=mapId,jsonString
args ��ֵ��һ���ԡ�,���ָ����ַ��������У�
mapId����ͼ��Id
jsonString��������ͼ�ļ��ζ����JSON �ַ�����
**/
}

function createPolygon(){
//����ȱʡ�Ķ������ʽ
var polygonStyle = new MStyle();
polygonStyle.lineColor = 0x00ff99;
polygonStyle.lineSize = 5;
polygonStyle.lineOpacity = 60;
polygonStyle.fillOpacity = 50;
polygonStyle.fillColor = 0x999900;

mapObj.addGeometry(MGeometry.TYPE_POLYGON, polygonStyle);
}
��
//����������ݷ���
function exportMapData(){
mapObj.exportMapData();
}

//������ͼ�����¼�������
function onexportMapData(event){
alert(event.args);
/**
event.type=��onExportMapData��
event.args=mapId,jsonString
args ��ֵ��һ���ԡ�,���ָ����ַ��������У�
mapId����ͼ��Id
jsonString��������ͼ�ļ��ζ����JSON �ַ�����
**/
}


	</SCRIPT> 

��������: ���� ��ͼ�������� ��������� ���ݵ��ȷ��. Ȼ������������<br /><br />


<input type="button" onClick="javascript:editMode();" value="����༭ģʽ" /> 
<input type="button" onClick="javascript:createPoint();" value="��ӵ�" /> 
<input type="button" onClick="javascript:createPolygon();" value="������" /> 
<input type="button" onClick="javascript:createPolyline();" value="������" /> 
<input type="button" onClick="javascript:exportMapData();" value="��������" /> 
</body>
</html>