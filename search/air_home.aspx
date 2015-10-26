<%@ Page Language="VB" AutoEventWireup="false" CodeFile="air_home.aspx.vb" Inherits="search_air_home" EnableEventValidation="false" ValidateRequest="false" EnableViewState="false"%><%@ OutputCache Duration="300" VaryByParam="*" VaryByCustom="SessionID" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 
<html xmlns="http://www.w3.org/1999/xhtl">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>空运运费发布,空运价格,空运代理报价及订舱服务-环球运费网</title>
<meta name="description" content="空运价格专栏,空运最新空运运费,空运运价查询,环球运费网" />
<meta name="keywords" content="空运 运费 运价" />
<meta name="viewport" content="width=1280, initial-scale=0.2"/>
<link href="/css2015/master.css" rel="stylesheet" type="text/css" />
<link href="/css2015/index.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js2015/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="/js2015/unslider.min.js"></script>
<script type="text/javascript" src="/js2015/base.js"></script>
<script type="text/javascript" src="/js2015/index.js"></script>
<script type="text/javascript">
</script>
<script type="text/javascript" language="javascript" src="/js2015/auto/ac_zd.js"></script>
<script type="text/javascript" language="javascript" src="/js2015/auto/airprot_ch.js"></script>
<script type="text/javascript" language="javascript" src="/js2015/auto/ac_zd_head_home.js"></script>
<link href="/js2015/auto/port.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server" autocomplete="off">
    <div id="messages"></div>
	<div class="header">
		<headtop20150520:headtop20150520 ID="headtop201505201" runat="server" />
		<headmid120150520:headmid120150520 ID="headmid1201505201" runat="server" />
        <headnav20150520:headnav20150520 ID="headnav201505201" runat="server" />
	</div>
	<div class="container bigpage">
        <div class="freight-left lcl-home-left">
            <div class="i-r-box f-menu">
                <dl>
                    <dt><span></span><h1>空运运价</h1></dt>
                    <dd>
                        <dl>
                            <dt>起运港</dt>
                            <dd>
                                <a href = "/air/list-shanghai---0-0-0-----1.html">上海</a><a href = "/air/list-shenzhen---0-0-0-----1.html">深圳</a><a href = "/air/list-guangzhou---0-0-0-----1.html">广州</a><a href = "/air/list-beijing---0-0-0-----1.html">北京</a><br/><a href = "/air/list-hongkong---0-0-0-----1.html">香港</a><a href = "/air/list-hangzhou---0-0-0-----1.html">杭州</a><a href = "/air/list-nanjing---0-0-0-----1.html">南京</a><a href = "/air/list-xiamen---0-0-0-----1.html">厦门</a><a href="/air/list----0-0-0-----1.html">更多...</a>
                            </dd>
                        </dl>
                        <dl>
                            <dt>航线</dt>
                            <dd><a href = "/air/list----1-0-0-----1.html">北美线</a><a href = "/air/list----2-0-0-----1.html">欧洲线</a><a href = "/air/list----3-0-0-----1.html">南美线</a><br/><a href = "/air/list----4-0-0-----1.html">亚洲线</a><a href = "/air/list----5-0-0-----1.html">非洲线</a><a href = "/air/list----6-0-0-----1.html">澳洲线</a><br/><a href = "/air/list----7-0-0-----1.html">国内航线</a></dd>
                        </dl>
                    </dd>
                </dl>
            </div>
<%--            <div class="i-r-box grey-box">
                <dl class="rate-wrapper">
                    <dt>当前汇率<span><a href="/intro/rate.aspx" target="_blank">MORE ></a></span></dt>
                    <dd class="flag"><img src="/images2015/0211usa.gif" /></dd>
                    <dd>
                        1 <label>美元</label> = <b><asp:Literal ID="ltrRate1" runat="server"></asp:Literal></b> 人民币 <br />
                        1 人民币 = <b><asp:Literal ID="ltrRate2" runat="server"></asp:Literal></b> <label>美元</label>
                    </dd>
                </dl>
            </div>--%>
            <div class="i-r-box grey-box">
                <dl class="srv-wrapper tools">
                    <dt>常用工具</dt>
                    <dd><a href="/tools/hs.aspx" target="_blank">HS编码</a></dd>
                    <dd class="rt"><a href="/tools/tax.aspx" target="_blank">海关税率</a></dd>
                    <dd><a href="/tools/airports.aspx" target="_blank">空港代码</a></dd>
                    <dd class="rt"><a href="#" target="_blank">危险品标志</a></dd>
                    <dd><a href="/tools/airlines.aspx" target="_blank">航空公司</a></dd>
                    <dd class="rt"><a href="/tools/flow.aspx" target="_blank">外贸单证</a></dd>
                    <dd><a href="/tools/guarantee.aspx" target="_blank">保函样本</a></dd>
                </dl>
                <dl class="srv-wrapper ports">
                    <dt>八大港口</dt>
                    <dd><a href="/port/shanghai/">上海港口</a></dd>
                    <dd class="rt"><a href="/port/shenzhen/">深圳港口</a></dd>
                    <dd><a href="/port/guangzhou/">广州港口</a></dd>
                    <dd class="rt"><a href="/port/qingdao/">青岛港口</a></dd>
                    <dd><a href="/port/tianjin/">天津港口</a></dd>
                    <dd class="rt"><a href="/port/dalian/">大连港口</a></dd>
                    <dd><a href="/port/ningbo/">宁波港口</a></dd>
                    <dd class="rt"><a href="/port/xiamen/">厦门港口</a></dd>
                </dl>
                <dl class="srv-wrapper busi">
                    <dt>商务服务</dt>
                    <dd><a href="/ports/" target="_blank">世界港口</a></dd>
                    <dd class="rt"><a href="/carrier/" target="_blank">船公司名录</a></dd>
                    <dd><a href="/bis/commodity.aspx" target="_blank">报关商检</a></dd>
                    <dd class="rt"><a href="/dangerouscargo/company/list.aspx?port=shanghai" target="_blank">危险品运输</a></dd>
                    <dd><a href="/bis/nvocc.aspx" target="_blank">NVOCC</a></dd>
                </dl>
            </div>
	    </div>
	    <div class="freight-right">
            <div class="i-l-box freight-pic">
                <img src="/images2015/fchup20150521.gif" />
            </div>
            <div class="i-l-box">
                <div class="l-box-hd">
                    <h2 class="grey">最新运价</h2><span><a href="/air/list----0-0-0-----1.html">MORE ></a></span>
                </div>
                <div class="l-box-bd">
                <asp:Repeater ID="Rptfcl2" runat="server">
                <ItemTemplate>
                    <div class="item new new-fcl-3">
                        <div class="title">
                            <a href="/air/<%#key(Eval("id").ToString())%>_0.html" target="_blank" title="<%#Eval("title").ToString()%>"><%#Eval("title").ToString()%></a>
                        </div>
                        <div class="content">
                            <div class="port">
                                <div><img src="/images2015/0213iconopol.gif" /><%#Eval("startport").ToString().ToUpper()%></div>
                                <div><img src="/images2015/0213iconpod.gif" /><%#Eval("destport").ToString().ToUpper()%></div>
                            </div>
                            <div class="freight">
                            <dl>
                                <dt>+45</dt>
                                <dd><%#setprice(Eval("price_p45").ToString())%></dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>+100</dt>
                                <dd><%#setprice(Eval("price_p100").ToString())%></dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>+300</dt>
                                <dd><%#setprice(Eval("price_p300").ToString())%></dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>+500</dt>
                                <dd><%#setprice(Eval("price_p500").ToString())%></dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>+1000</dt>
                                <dd><%#setprice(Eval("price_p1000").ToString())%></dd>
                            </dl>
                        </div>
                        </div>
                        <div class="company"><a href="/company/<%# key(Eval("userid").ToString())%>/" target="_blank" title="<%#Eval("companyname").ToString()%>"><%#Eval("companyname").ToString()%></a></div>
                    </div>
                </ItemTemplate>
                </asp:Repeater>

                <asp:Repeater ID="Rptfcl3" runat="server">
                <ItemTemplate>
                    <div class="item new new-fcl-3">
                        <div class="title">
                            <a href="/air/<%#key(Eval("id").ToString())%>_0.html" target="_blank" title="<%#Eval("title").ToString()%>"><%#Eval("title").ToString()%></a>
                        </div>
                        <div class="content">
                            <div class="port">
                                <div><img src="/images2015/0213iconpol.gif" /><%#Eval("startport").ToString().ToUpper()%></div>
                                <div><img src="/images2015/0213iconpod.gif" /><%#Eval("destport").ToString().ToUpper()%></div>
                            </div>
                            <div class="freight">
                            <dl>
                                <dt>+45</dt>
                                <dd><%#setprice(Eval("price_p45").ToString())%></dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>+100</dt>
                                <dd><%#setprice(Eval("price_p100").ToString())%></dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>+300</dt>
                                <dd><%#setprice(Eval("price_p300").ToString())%></dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>+500</dt>
                                <dd><%#setprice(Eval("price_p500").ToString())%></dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>+1000</dt>
                                <dd><%#setprice(Eval("price_p1000").ToString())%></dd>
                            </dl>
                        </div>
                        </div>
                        <div class="company"><a href="/company/<%# key(Eval("userid").ToString())%>/" target="_blank" title="<%#Eval("companyname").ToString()%>"><%#Eval("companyname").ToString()%></a></div>
                    </div>
                </ItemTemplate>
                </asp:Repeater>
                </div>
            </div>
 	    </div>
	    
	</div>
    <footer20150520:footer20150520 ID="footer201505201" runat="server" />
</form>
</body>
</html>