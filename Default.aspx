<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" EnableViewState="false" enableEventValidation="false" ValidateRequest="false"%><%@ OutputCache Duration="300" VaryByParam="*" VaryByCustom="SessionID" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 
<html xmlns="http://www.w3.org/1999/xhtl">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="baidu-site-verification" content="l0eWGUptKDwJfxZ8" />
<asp:Literal id="Literal1" runat="server"><title>环球运费网是全球最大的空运运价与海运运价查询与订舱平台,空运费与海运费查询与订舱平台</title></asp:Literal>
<meta name="description" content="环球运费网是全球最大的运费查询与订舱平台,提供海运运价与空运运价查询和订舱服务,拥有海量货主与货代会员进行运费查询和在线订舱,更多运费查询订舱服务请点击进入" />
<meta name="keywords" content="运费,运价,订舱" /> 
<meta name="google-site-verification" content="Tkd5hCwEyv9Qr3uq0ajP_PCHqFkuQu3i7Un7G5Ql91c" />
<link rel="apple-touch-icon-precomposed" sizes="114x114" href="http://www.100allin.com/100allin.png">  
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
	    <div class="index-left">
            <div class="i-l-box">
                <div class="index-slide">
                     <ul>
                        <li><a href="/products/one/" target="_blank"><img src="/products/one/images/banner.jpg" /></a></li>
                        <li><img src="/images2015/dyj6863401.jpg" /></li>
                        <li><img src="/images2015/home-1.jpg" /></li>
                        <li><img src="/images2015/home-6.jpg" /></li>
                    </ul>
                </div>
                <div class="index-at">
                    <a href="/accounts/reg.aspx"><img src="/images2015/home-2-2.jpg" /></a>
                    <a href="/fcl/"><img src="/images2015/home-2-1.jpg" /></a>
                </div>
            </div>
            <div class="i-l-box">
                <div class="l-box-hd">
                    <h2>热门运价</h2><span class="hide">换一批<img src="/images2015/0213random.gif"></span>
                </div>
                <div class="l-box-bd">
                    <div class="item hot fcl">
                        <div class="pic">
                            <img src="/images2015/0213hotf.gif">
                        </div>
                        <div class="port">
                            <a href="/fcl/eVZ6Z3RMdUI0WU12MzJkWlkyMVY0UT09_11479887.html" target="_blank">SHANGHAI<span>至</span>KARACHI</a></div>
                        <div class="freight">
                            <dl>
                                <dt>20GP</dt>
                                <dd>710</dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>40GP</dt>
                                <dd>860</dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>40HQ</dt>
                                <dd>860</dd>
                            </dl>
                        </div>
                    </div>
                    <div class="item hot air">
                        <div class="pic">
                            <img src="/images2015/0213hota.gif">    
                        </div>  
                        <div class="port">
                            <a href="/air/dlF2WGlDanloZ1dPcUNCaDN2MXR4QT09_0.html" target="_blank">PVG<span>至</span>DXB</a></div>   
                        <div class="freight">
                            <dl>
                                <dt>+45</dt>
                                <dd></dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>+100</dt>
                                <dd>15</dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>+300</dt>
                                <dd>15</dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>+500</dt>
                                <dd>14.5</dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>+1000</dt>
                                <dd>14</dd>
                            </dl>
                        </div>                                                               
                    </div>
                
                </div>
                <%--<div class="l-box-bd">
                <asp:Repeater ID="RptFclHot" runat="server">
                <ItemTemplate>
                    <div class="item hot fcl">
                        <div class="pic">
                            <img src="/images2015/0213hotf.gif" />
                        </div>
                        <div class="port">
                            <a href="/fcl/<%#setkey(Eval("yunjiaid").ToString())%>_0.html" target="_blank"><%#GetFirstString(Eval("startport").ToString().ToUpper(),10)%><span>至</span><%#GetFirstString(Eval("destport1").ToString().ToUpper(),12)%></a></div>
                        <div class="freight">
                            <dl>
                                <dt>20GP</dt>
                                <dd><%#setprice(Eval("price20gp1").ToString())%></dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>40GP</dt>
                                <dd><%#setprice(Eval("price40gp1").ToString())%></dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>40HQ</dt>
                                <dd><%#setprice(Eval("price40hq1").ToString())%></dd>
                            </dl>
                        </div>
                    </div>
                </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="RptAirHot" runat="server">
                <ItemTemplate>
                    <div class="item hot air">
                        <div class="pic">
                            <img src="/images2015/0213hota.gif" />    
                        </div>  
                        <div class="port">
                            <a href="/air/<%#setkey(Eval("AIRID").ToString())%>_0.html" target="_blank"><%#Eval("startport").ToString().ToUpper()%><span>至</span><%#Eval("destport1").ToString().ToUpper()%></a></div>   
                        <div class="freight">
                            <dl>
                                <dt>+45</dt>
                                <dd><%#setprice(Eval("price_p451").ToString())%></dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>+100</dt>
                                <dd><%#setprice(Eval("price_p1001").ToString())%></dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>+300</dt>
                                <dd><%#setprice(Eval("price_p3001").ToString())%></dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>+500</dt>
                                <dd><%#setprice(Eval("price_p5001").ToString())%></dd>
                            </dl>
                            <div class="sep">|</div>
                            <dl>
                                <dt>+1000</dt>
                                <dd><%#setprice(Eval("price_p10001").ToString())%></dd>
                            </dl>
                        </div>                                                               
                    </div>
                </ItemTemplate>
                </asp:Repeater>
                </div>--%>
            </div>
            <div class="i-l-box">
                <div class="l-box-hd">
                    <h2><span>1F</span>新 · 整箱海运价</h2><span><a href="/fcl/">MORE ></a></span>
                </div>
                <div class="l-box-bd">
                    <%--<div class="item new new-fcl-2">
                        <div class="title">
                            <a href="/fcl/S2xBdGkxandhU2kyU1lxK2FYbFBiUT09_0.html" target="_blank" title="上海至ONNE">上海至ONNE</a>
                        </div>
                        <div class="content">
                            <div class="port">
                                <div><img src="/images2015/0213iconopol.gif">SHANGHAI</div>
                                <div><img src="/images2015/0213iconpod.gif">ONNE</div>
                            </div>
                            <div class="freight">
                                <dl>
                                    <dt><span>20GP</span></dt>
                                    <dd>2050</dd>
                                </dl>
                                <dl>
                                    <dt><span>40GP</span></dt>
                                    <dd>3000</dd>
                                </dl>
                                 <dl>
                                    <dt><span>40HQ</span></dt>
                                    <dd>3000</dd>
                                </dl>
                            </div>
                        </div>
                        <div class="company"><a href="/company/OGN2bENvTE1wOEsyYy9WeUtXT2JOZz09/" target="_blank" title="上海硕联国际物流有限公司">上海硕联国际物流有限公司</a></div>
                    </div>--%>
                <asp:Repeater ID="Rptfcl2" runat="server">
                <ItemTemplate>
                    <div class="item new new-fcl-2">
                        <div class="title">
                            <a href="/fcl/<%#setkey(Eval("id").ToString())%>_0.html" target="_blank" title="<%#Eval("title").ToString()%>"><%#Eval("title").ToString()%></a>
                        </div>
                        <div class="content">
                            <div class="port">
                                <div><img src="/images2015/0213iconopol.gif" /><%#Eval("startport").ToString().ToUpper()%></div>
                                <div><img src="/images2015/0213iconpod.gif" /><%#Eval("destport").ToString().ToUpper()%></div>
                            </div>
                            <div class="freight">
                                <dl>
                                    <dt><span>20GP</span></dt>
                                    <dd><%#setprice(Eval("price20gp").ToString())%></dd>
                                </dl>
                                <dl>
                                    <dt><span>40GP</span></dt>
                                    <dd><%#setprice(Eval("price40gp").ToString())%></dd>
                                </dl>
                                 <dl>
                                    <dt><span>40HQ</span></dt>
                                    <dd><%#setprice(Eval("price40hq").ToString())%></dd>
                                </dl>
                            </div>
                        </div>
                        <div class="company"><a href="/company/<%# setkey(Eval("userid").ToString())%>/" target="_blank" title="<%#Eval("companyname").ToString()%>"><%#Eval("companyname").ToString()%></a></div>
                    </div>
                </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="Rptfcl3" runat="server">
                <ItemTemplate>
                    <div class="item new new-fcl-3">
                        <div class="title">
                            <a href="/fcl/<%#setkey(Eval("id").ToString())%>_0.html" target="_blank" title="<%#Eval("title").ToString()%>"><%#Eval("title").ToString()%></a>
                        </div>
                        <div class="content">
                            <div class="port">
                                <div><img src="/images2015/0213iconpol.gif" /><%#Eval("startport").ToString().ToUpper()%></div>
                                <div><img src="/images2015/0213iconpod.gif" /><%#Eval("destport").ToString().ToUpper()%></div>
                            </div>
                            <div class="freight">
                                <dl>
                                    <dt>20GP</dt>
                                    <dd><%#setprice(Eval("price20gp").ToString())%></dd>
                                </dl>
                                <div class="sep">|</div>
                                <dl>
                                    <dt>40GP</dt>
                                    <dd><%#setprice(Eval("price40gp").ToString())%></dd>
                                </dl>
                                <div class="sep">|</div>
                                <dl>
                                    <dt>40HQ</dt>
                                    <dd><%#setprice(Eval("price40hq").ToString())%></dd>
                                </dl>
                            </div>
                        </div>
                        <div class="company"><a href="/company/<%# setkey(Eval("userid").ToString())%>/" target="_blank" title="<%#Eval("companyname").ToString()%>"><%#Eval("companyname").ToString()%></a></div>
                    </div>
                </ItemTemplate>
                </asp:Repeater>
                </div>
            </div>
            <div class="i-l-box">
                <div class="l-box-hd">
                    <h2><span>2F</span>新 · 拼箱海运价</h2><span><a href="/lcl/">MORE ></a></span>
                </div>
                <div class="l-box-bd">
                <asp:Repeater ID="Rptlcl" runat="server">
                <ItemTemplate>		
                    <div class="item new new-fcl-3">
                        <div class="title">
                            <a href="/lcl/<%#setkey(Eval("id").ToString())%>_0.html" target="_blank" title="<%#Eval("title").ToString()%>"><%#Eval("title").ToString()%></a>
                        </div>
                        <div class="content">
                            <div class="port">
                                <div><img src="/images2015/0213iconpol.gif" /><%#Eval("startport").ToString().ToUpper()%></div>
                                <div><img src="/images2015/0213iconpod.gif" /><%#Eval("destport").ToString().ToUpper()%></div>
                            </div>
                            <div class="freight">
                                <dl>
                                    <dt>KGS</dt>
                                    <dd><%#Eval("pricegp").ToString()%></dd>
                                </dl>
                                <div class="sep">|</div>
                                <dl>
                                    <dt>CBM</dt>
                                    <dd><%#Eval("pricegpv").ToString()%></dd>
                                </dl>
                            </div>
                        </div>
                        <div class="company"><a href="/company/<%# setkey(Eval("userid").ToString())%>/" target="_blank" title="<%#Eval("companyname").ToString()%>"><%#Eval("companyname").ToString()%></a></div>
                    </div>
                </ItemTemplate>
                </asp:Repeater>
                </div>
            </div>
            <div class="i-l-box">
                <div class="l-box-hd">
                    <h2><span>3F</span>新 · 空运运价</h2><span><a href="/air/">MORE ></a></span>
                </div>
                <div class="l-box-bd">
                <asp:Repeater ID="Rptair" runat="server">
                <ItemTemplate>
                    <div class="item new new-fcl-3">
                        <div class="title">
                            <a href="/air/<%#setkey(Eval("id").ToString())%>_0.html" target="_blank" title="<%#Eval("title").ToString()%>"><%#Eval("title").ToString()%></a>
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
                        <div class="company"><a href="/company/<%# setkey(Eval("userid").ToString())%>/" target="_blank" title="<%#Eval("companyname").ToString()%>"><%#Eval("companyname").ToString()%></a></div>
                    </div>
                </ItemTemplate>
                </asp:Repeater>
                </div>
            </div>
            <div class="i-l-box banner">
                <a href="/ports/"><img src="/images2015/0213port.gif" width="877" height="85" /></a>
            </div>
	    </div>
	    <div class="index-right">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
	        <div class="i-r-box login-box">
                <div class="username-field login-box-input"><label><span>用户名</span><input type="text" id="txtUsername" class="input-txt" runat="server"/></label></div>
                <div class="btn-field"><input type="button" value="登录" class="login-btn"  runat="server" id="ImageButton1"  OnServerClick="ImageButton1_Click"/></div>
                <div class="pwd-field login-box-input"><label><span>密码</span><input type="password" id="txtPassword" class="input-txt"  runat="server"/></label></div>
                <div class="chk-field">
                    <asp:CheckBox ID="chkAutoLogin" runat="server" Checked="True" Text="下次自动登录"  CssClass="login-box-chk"/>
                </div>
                <div class="reg-field">
                    <a href="/accounts/retrievepassword.aspx">忘记密码</a><a href="/accounts/reg.aspx" class="box-reg">免费注册</a>
                </div>
	        </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder2" runat="server">
            <div class="i-r-box login-box">
                <div class="user-head"><img src="/member/head/<asp:Literal ID="Literal7" runat="server"></asp:Literal>.jpg"></div>
                <div class="user-name"><asp:Literal ID="Literal2" runat="server"></asp:Literal></div>
                <div class="user-level"><asp:Literal ID="Literal3" runat="server"></asp:Literal> <span><a href="/accounts/logout.aspx">退出登录</a></span></div>
                <div class="user-count">
                    <dl>
                        <dt><a href="/member/Release.aspx"><asp:Literal ID="Literal4" runat="server"></asp:Literal></a></dt>
                        <dd>整箱</dd>
                    </dl>
                    <div class="sep"></div>
                    <dl>
                        <dt><a href="/member/SpellRelease.aspx"><asp:Literal ID="Literal5" runat="server"></asp:Literal></a></dt>
                        <dd>拼箱</dd>
                    </dl>
                    <div class="sep"></div>
                    <dl>
                        <dt><a href="/member/AirRelease.aspx"><asp:Literal ID="Literal6" runat="server"></asp:Literal></a></dt>
                        <dd>空运</dd>
                    </dl>
                    <div class="sep"></div>
                    <div class="user-office">
                        <a href="/member/">我的办公室</a>
                    </div>
                </div>
	        </div>
            </asp:PlaceHolder>
 	        <div class="i-r-box">
	            <img src="/images2015/wx1.jpg">
	        </div>
            <div class="i-r-box grey-box">
                <dl class="chance-wrapper">
                    <dt>实时商机<span><a href="/search/fcl_need.aspx" target="_blank">MORE ></a></span></dt>
                    <asp:Repeater ID="RptPriceNeed" runat="server">
                    <ItemTemplate>
                    <dd><img src="/images2015/0212icon<%# Eval("Y").ToString() == "8" ? "f" : "l"%>.gif" /><a href="/member/<%# Eval("Y").ToString() == "8" ? "Release":"SpellRelease" %>.aspx?DestPort=<%# Eval("destport") %>&StartPort=<%# Eval("startport") %>" target="_blank"><%# GetFirstString(Eval("startport").ToString().ToUpper(),10)%> <label>至</label> <%# GetFirstString(Eval("destport").ToString().ToUpper(), 10)%></a></dd>
                    </ItemTemplate>
                    </asp:Repeater>
                </dl>
            </div>  
            <div class="i-r-box">
                <dl class="news-wrapper">
                    <dt>航运动态<span><a href="/news/" target="_blank">MORE ></a></span></dt>
                    <dd class="line">
                    </dd>
                    <asp:Repeater ID="RptaHangYunDongTai" runat="server">
                    <ItemTemplate>
                    <dd><label class="row-<%# bbsstyle(Container.ItemIndex) %>"><%# Container.ItemIndex +1 %></label><a href="/news/1/2/<%#Eval("id")%>.html" target="_blank" title="<%#Eval("title")%>"><%#Eval("title").ToString()%></a><span><%# Convert.ToDateTime(Eval("postdate")).ToString("MM/dd")%></span></dd>
                    </ItemTemplate>
                    </asp:Repeater>
                </dl>
            </div>

            <div class="i-r-box grey-box">
                <dl class="rate-wrapper">
                    <dt>当前汇率<span><a href="/intro/rate.aspx" target="_blank">MORE ></a></span></dt>
                    <dd class="flag"><img src="/images2015/0211usa.gif" /></dd>
                    <dd>
                        1 <label>美元</label> = <b><asp:Literal ID="ltrRate1" runat="server"></asp:Literal></b> 人民币 <br />
                        1 人民币 = <b><asp:Literal ID="ltrRate2" runat="server"></asp:Literal></b> <label>美元</label>
                    </dd>
                </dl>
            </div>
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
                <dl class="srv-wrapper baf">
                    <dt>运费快报</dt>
                    <dd><a href="/baf/" target="_blank">最新BAF</a></dd>
                    <dd class="rt"><a href="/baf/" target="_blank">最新CAF</a></dd>
                    <dd><a href="/thc" target="_blank">最新THC</a></dd>
                    <dd class="rt"><a href="/orc/" target="_blank">最新ORC</a></dd>
                </dl>
            </div>
	    </div>
	</div>
    <div class="link">
        <div class="link-container">
            <div class="title">友情链接：</div>
            <div class="detail">
                <a href="http://www.kjds.com/" target="_blank">越域网</a>
                <a href="http://www.chinaports.com/containerTracker/" target="_blank">集装箱查询</a>
                <a href="http://www.56135.com/" target="_blank">中国物流交易中心</a>
                <a href="http://www.sol.com.cn/" target="_blank">航运在线</a>
                <a href="http://www.chinaports.com/" target="_blank">中国港口网</a>
                <a href="http://www.yunfei89.com/" target="_blank">海运费查询</a>
                <a href="http://www.valuefix.com/ " target="_blank">我来运</a>
                <a href="http://www.yicang.com/ " target="_blank">易舱网</a>
                <a href="http://www.21098.com" target="_blank">广交会展信息网</a>
                <a href="http://www.jctrans.com" target="_blank" title="锦程物流网">锦程物流网</a>
                <a href="http://www.cnhangyun.com" target="_blank">中国航运网</a>
                <a href="http://www.qd56.cn/" target="_blank">青岛物流网</a>
                <a href="http://www.eachtrans.com/" target="_blank">易网通物流网</a>
                <a href="http://www.56qss.com/" target="_blank">物流全搜索</a>
                <a href="http://www.9956.cn/" target="_blank">九九物流网</a>
                <a href="http://www.scmcn.net/ " target="_blank">供应链中国网</a>
                <a href="http://www.8ems.com/" target="_blank">8速快查</a>
                <a href="http://www.365wuliu.com/otherdown/100allin/" target="_blank">货代助手</a>
                <a href="http://wl.job1001.com/" target="_blank">物流英才网</a>
                <a href="http://www.igenzong.com/" target="_blank">集装箱跟踪网</a>
                <a href="http://www.56885.net/" target="_blank">物流天下</a>
                <a href="http://www.jobtrans.cn/" target="_blank">物流招聘</a>
                <a href="http://www.sofreight.com/" target="_blank">国际海运费查询</a>
                <a href="/links.aspx" target="_blank">更多...</a>
            </div>
        </div>
    </div>	
    <footer20150520:footer20150520 ID="footer201505201" runat="server" />
</form>
</body>
</html>