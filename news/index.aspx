<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="news_index" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>物流聚焦-环球运费网</title>
<meta name="keywords" content="物流聚焦-环球运费网" />
<meta name="description" content="环球运费网是全球最大的专业运价查询平台，提供最新航运动态" />
<meta name="viewport" content="width=1280, initial-scale=0.2"/>
<link href="/css2015/master.css" rel="stylesheet" type="text/css" />
<link href="/css2015/news.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js2015/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="/js2015/base.js"></script>

<script src="http://js.jrj.com.cn/hq/co/swfobject.js" type="text/javascript"></script>

<script type="text/javascript">
    $(function () {
        var winH = $(window).height(); //页面可视区域高度 
        var i = 2; //设置当前页数 
        //alert("11");
        var flag = 1;
        $(window).scroll(function () {
            var pageH = $(document.body).height();
            var scrollT = $(window).scrollTop(); //滚动条top 
            var aa = (pageH - winH - scrollT) / winH;
            

            if (aa < 0.02 & flag == 1) {
                $(".nodata").show().html("<img src=\"/images2015/loading.gif\"> 正在加载中，请稍候……");
                flag = 0;

                
                $.getJSON("newsjson.aspx", { page: i }, function (json) {
                    setTimeout(function () {
                        if (json) {
                            var str = "";
                            $.each(json, function (index, array) {
                                var str = "<div class=\"entry\">";
                                str += "<div class=\"entry-title\"><h2><a href=\"/news/1/2/" + array['id'] + ".html\" target=\"_blank\" title=\"" + array['title'] + "\">" + array['title'] + "</a></h2></div>";
                                str += "<div class=\"entry-meta\"><span>" + array['postdate'] + "</span> <span>来自：<a href=\"http://www.100allin.com/\">环球运费网</a></span></div>";
                                str += "<div class=\"entry-content\">";
                                str += array['content'];
                                str += "</div>";
                                str += "</div>";
                                $("#freshbox").append(str);
                            });
                            i++;
                        } else {
                            $(".nodata").show().html("没有更多了资讯了……");
                            return false;
                        }
                        //alert(flag);
                        flag = 1;
                    }, 1000);
                });


            }
        });
    });

//    $(function () {
//        //为按钮绑定事件  
//        $("#TestGetJson").bind("click", GetJsonWithCallback);

//    });


//    //测试getJSON，使用回调函数  
//    //注意：get()方法提供了回调函数（callback），  
//    //该函数有三个参数，分别代表请求返回的内容、请求状态和XMLHttpRequest对象  
//    function GetJsonWithCallback(event) {

//        $.getJSON("GetCity.aspx", { "resultType": "json" }, function (responseText, textStatus, XMLHttpRequest) {
//            $("#result").html("responseText.length:" + responseText.length + "<br/>" + "responseText[0].CityName:" + responseText[0].CityName);

//        });
//    }  
</script>

<style type="text/css">

</style>
</head>
<body>
<%--<input id="TestGetJson" type="button" value="测试jquery.getJSON" />  
             
        <div id="result">  
        </div>  --%>
<form id="form1" runat="server" autocomplete="off">
	<div class="header">
		<headtop20150520:headtop20150520 ID="headtop201505201" runat="server" />
		<headmid220150520:headmid220150520 ID="headmid2201505201" runat="server" />
        <headnav20150520:headnav20150520 ID="headnav201505201" runat="server" />
	</div>

    <div class="container breadcrumbs">
        <a href="/">首页</a><span class="sep">-</span><span>物流资讯</span>
    </div>

    <div class="container result">
        <div class="result-left">
            <div id="freshbox">
                            <asp:Repeater ID="Repeater4" runat="server">
                                <ItemTemplate>			
            <div class="entry">
                <div class="entry-title"><h2><a href="/news/1/2/<%#Eval("id") %>.html" target="_blank" title="<%#Eval("title") %>"><%#Eval("title") %></a></h2></div>
                <div class="entry-meta"><span><%#Convert.ToDateTime(Eval("postdate").ToString()).ToString("yyyy年M月d日") %></span> <span></span></div>
                <div class="entry-content">
                    <%#GetContentSummary( Eval("data").ToString(), 500, false)%>
                </div>
            </div>
                                </ItemTemplate>
                </asp:Repeater>		
            </div>


            <div class="nodata"></div> 

            <div class="pager"><%=pagecontrol_string %></div> 
        </div>
        <div class="result-right">
            <div class="i-r-box">
                <dl class="rate-wrapper">
                    <dt>当前汇率<span><a href="/intro/rate.aspx" target="_blank">MORE &gt;</a></span></dt>
                    <dd class="flag"><img src="/images2015/0211usa.gif"></dd>
                    <dd>
                        1 <label>美元</label> = <b><asp:Literal ID="ltrRate1" runat="server"></asp:Literal></b> 人民币 <br/>
                        1 人民币 = <b><asp:Literal ID="ltrRate2" runat="server"></asp:Literal></b> <label>美元</label>
                    </dd>
                </dl>
            </div>
            <div class="i-r-box">
                <dl class="news-wrapper stock">
                    <dt>证券行情</dt>
                    <dd class="line"></dd>
                    <dd>
                    <div><div id="HQZS"></div></div>
                    <script>
                        function isReady() { return true; }
                        function thisMovie(movieName) {
                            return document.getElementById(movieName);
                        }
                        function sendToActionScript(value) {
                            try {
                                thisMovie("HQZS").sendToActionScript(value);
                            } catch (e) {

                            }
                        }
                        swfobject.embedSWF("http://f0.jrj.com.cn/hq2/hqzs.swf?" + Math.round(Math.random() * 10000, 4), "HQZS", "315", "200", "9.0.0", "", { first: "000001|I", url: 'share.jrj.com.cn' }, { wmode: "opaque", AllowScriptAccess: "always" })
                    </script>
                    </dd>
                    <dd>
                    <a href="javascript:;" onclick="sendToActionScript('000001|I')">上证指数</a>
                    <a href="javascript:;" onclick="sendToActionScript('399001|I')">深圳指数</a>
                    <a href="javascript:;" onclick="sendToActionScript('000300|I')">沪深300</a>
                    </dd>
                </dl>
            </div>
            <div class="i-r-box">
                <dl class="news-wrapper">
                    <dt>精华推荐</dt>
                    <dd class="line"></dd>
                    <asp:Repeater ID="RptaHangYunDongTai" runat="server">
                    <ItemTemplate>
                    <dd><label class="row-<%# bbsstyle(Container.ItemIndex) %>"><%# Container.ItemIndex +1 %></label><a href="/news/1/2/<%#Eval("id")%>.html" target="_blank" title="<%#Eval("title")%>"><%#Eval("title").ToString()%></a><span><%# Convert.ToDateTime(Eval("postdate")).ToString("MM/dd")%></span></dd>
                    </ItemTemplate>
                    </asp:Repeater>
                </dl>
            </div>
            <div class="i-r-box hide">
                <dl class="news-wrapper">
                    <dt>分类目录</dt>
                    <dd class="line"></dd>
                    <dd><a href="#" target="_blank">航运资讯</a></dd>
                    <dd><a href="#" target="_blank">空运资讯</a></dd>
                    <dd><a href="#" target="_blank">综合物流</a></dd>
                    <dd><a href="#" target="_blank">船公司公告</a></dd>
                </dl>
            </div>
            <div class="i-r-box hide">
                <dl class="news-wrapper grey">
                    <dt>文章归档</dt>
                    <dd class="line"></dd>
                    <dd><a href="#" target="_blank">2015年5月</a></dd>
                    <dd><a href="#" target="_blank">2015年4月</a></dd>
                    <dd><a href="#" target="_blank">2015年3月</a></dd>
                    <dd><a href="#" target="_blank">2015年2月</a></dd>
                    <dd><a href="#" target="_blank">2015年1月</a></dd>
                </dl>
            </div>
        </div>
    </div>
    	

    <footer20150520:footer20150520 ID="footer201505201" runat="server" />
</form>
</body>
</html>

