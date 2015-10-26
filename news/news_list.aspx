<%@ Page Language="C#" AutoEventWireup="true" CodeFile="news_list.aspx.cs" Inherits="news_news_list" EnableViewState="false" EnableEventValidation="false" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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