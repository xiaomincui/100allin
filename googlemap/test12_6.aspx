<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test12_6.aspx.cs" Inherits="googlemap_test12_6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <%--<script src="http://ditu.google.cn/maps?file=api&amp;v=2&amp;key=abcdefg&sensor=true_or_false"             type="text/javascript"></script>--%>
    <script src=" http://maps.google.com/?file=api&amp;v=2.x&amp;key=ABQIAAAAt19WLP8L24LqGVw0JmF1RBRmHRpCTImxobDKrbvkMo7mYKNrNxQrexK3xQmGTCME5OOHP8RjbKUdgw"
      type="text/javascript"></script>
    <script type="text/javascript">
          var map = null;
            var geocoder = null;
            var gdir;
          function initialize() 
          {
            
            if (GBrowserIsCompatible())
            {
                map = new GMap2(document.getElementById("map_canvas"));
                map.setCenter(new GLatLng(39.9493, 116.3975), 4);//坐标和缩放级别
                //gdir = new GDirections(map, document.getElementById("Div1"));
                gdir = new GDirections(map);
                GEvent.addListener(gdir, "load", onGDirectionsLoad);
                GEvent.addListener(gdir, "error", handleErrors);
                geocoder = new GClientGeocoder();
                
            }
            /*
            //增加10个地图当前区域中的随机点
            var bounds = map.getBounds();//返回当前视口
            var southWest = bounds.getSouthWest();
            var northEast = bounds.getNorthEast();
            var lngSpan = northEast.lng() - southWest.lng();
            var latSpan = northEast.lat() - southWest.lat();
            for (var i = 0; i < 10; i++)
            {
                var point = new GLatLng(southWest.lat() + latSpan * Math.random(),southWest.lng() + lngSpan * Math.random());
                map.addOverlay(new GMarker(point,{draggable:true})); //增加一个标记,设置为可拖动，默认为不可拖动
            }
            */
            
         }  
         
         function handleErrors(){alert("出错")}
         function onGDirectionsLoad()
         {
            document.getElementById("directions").innerHTML=gdir.getDistance().meters+"m";
            
         }
         
         function showAddress(address) {
          if (geocoder) {
            geocoder.getLatLng(
              address,
              function(point) {
                
                if (!point) {
                  alert("不能解析: " + address);
                } else {
                  searchPoint(point.lat() + "|" + point.lng() + "|" + address);
                  
                  
                  
                  
                  
                  
//                  var marker = new GMarker(point);
//                  map.addOverlay(marker);
//                  marker.openInfoWindowHtml(address);//弹出气泡
                  
                }
              }
            );
          }
        }
        
        
        
        function AddPort(address) {
          if (geocoder) {
            geocoder.getLatLng(
              address,
              function(point) {
                
                if (!point) {
                  alert("不能解析: " + address);
                } else {
                    document.getElementById('hidaddPort').value=point.lat() + "|" + point.lng() + "|" + address
                    document.getElementById('Button2').click();
                  
                  
                }
              }
            );
          }
        }
         
        function setDirections(fromAddress, toAddress, locale) 
        {
            gdir.load("from: " + fromAddress + " to: " + toAddress,{ "preserveViewport": "false" },{ "locale": locale });
        }
        

         
        function searchPoint(point)
        {
            arg = "search^" + point;
            
            <%= ClientScript.GetCallbackEventReference(this, "arg", "ReceiveServerData","")%>;
        }

        function ReceiveServerData(result, context)
        {
            var tempArray = result.split("$")
            setDirections(document.getElementById('address').value,tempArray[0].split("|")[2],"cn");
            var PosrList="";
            for (var i=0;i<tempArray.length;i++)
            {
                PosrList += "<a href=\"javascript:setDirections('" + document.getElementById('address').value + "','"+tempArray[i].split("|")[2]+"','cn')\">"+tempArray[i].split("|")[2]+"</a><br />";
            }

            document.getElementById("otherPort").innerHTML=PosrList;
            
        }  
    </script>
</head>
<body onload="initialize()" onunload="GUnload()">
    <form id="form1" runat="server">
        <input id="address" name="address" type="text" />
        <input id="Button1" type="button" value="查询" onclick="showAddress(document.getElementById('address').value)" />
        
        
        
        
        <div id="directions"></div>
        
                  <div id="map_canvas" style="width: 700px; height: 600px"></div>
                  <div id="otherPort"></div>
                 <div id="Div1"></div> 
                 
                  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 增加一个港口<input id="addAddresss" name="address" type="text" runat="server" />&nbsp;
        <input id="Button3" type="button" value="增加" onclick="AddPort(document.getElementById('addAddresss').value)" />
        <div style="display:none"><asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="增加" /><input id="hidaddPort" type="Hidden" runat="server" /></div>
        
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <%# Eval("toPort")%>&nbsp; &nbsp; &nbsp; &nbsp;
        </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
