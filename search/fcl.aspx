<%@ Page Language="VB" AutoEventWireup="false" CodeFile="fcl.aspx.vb" Inherits="search_fcl" EnableEventValidation="false" ValidateRequest="false" EnableViewState="false"%><%--<%@ OutputCache Duration="300" VaryByParam="*" VaryByCustom="SessionID" %>--%><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<asp:Literal id="Literal1" runat="server"><title>整箱运费查询订舱,查询海运整箱运价,提供全球海运整箱在线订舱-环球运费网</title></asp:Literal>
<asp:Literal id="Literal3" runat="server"><meta name="description" content="海运整箱运费查询与订舱频道,查询国际海运整箱运价,海运整箱在线订舱,整箱运费查询整箱运价查询整箱在线订舱,尽在环球运费网" /></asp:Literal>
<asp:Literal id="Literal2" runat="server"><meta name="keywords" content="整箱,整箱运费,整箱运价,整箱订舱" /></asp:Literal>
<meta name="viewport" content="width=1280, initial-scale=0.2"/>
<link href="/css2015/master.css" rel="stylesheet" type="text/css" />
<link href="/css2015/freight.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js2015/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="/js2015/base.js"></script>
<script type="text/javascript" src="/js2015/freight.js"></script>

<script type="text/javascript" language="javascript" src="/js2015/auto/ac_zd.js"></script>
<script type="text/javascript" language="javascript" src="/js2015/auto/airprot_ch.js"></script>
<script type="text/javascript" language="javascript" src="/js2015/auto/ac_zd_head_home.js"></script>
<link href="/js2015/auto/port.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    $(document).ready(function () {


        $(".freight-row").mouseenter(function () {
            $(this).css("border", "1px #B0CBE2 solid");
        });

        $(".freight-row").mouseleave(function () {
            $(this).css("border-top", "1px #E6E6E6 solid");
            $(this).css("border-bottom", "1px #E6E6E6 solid");
            $(this).css("border-left", "1px #FFFFFF solid");
            $(this).css("border-right", "1px #FFFFFF solid");
        });

    });
</script>

<style type="text/css">

</style>
</head>
<body>
<form runat="server">
    <div id="messages"></div>
	<div class="header">
		<headtop20150520:headtop20150520 ID="headtop201505201" runat="server" />
		<headmid120150520:headmid120150520 ID="headmid1201505201" runat="server" />
        <headnav20150520:headnav20150520 ID="headnav201505201" runat="server" />
	</div>

    <div class="container breadcrumbs">
        <a href="/">首页</a><span class="sep">-</span><span>整箱海运价</span>
    </div>

    <div class="container">
        <div class="filter-box">
            <div class="box-hd">
                <h3 class="title">整箱海运价</h3>
            </div>
            <div class="box-bd">
                <dl>
                    <dt>起运港：</dt>
                    <dd>
                        <ul>
                            <asp:Literal ID="lblStartportHot" runat="server"></asp:Literal>
                        </ul>
                    </dd>
                </dl>
                <dl>
                    <dt><label class="w2">航线</label>：</dt>
                    <dd>
                        <ul>
                            <asp:Literal ID="lblLineHot" runat="server"></asp:Literal><asp:TextBox ID="TextBox1" CssClass="hide"
                                runat="server"></asp:TextBox>
                        </ul>
                    </dd>
                </dl>
                <dl>
                    <dt>目的港：</dt>
                    <dd>
                        <ul>
                            <asp:Literal ID="lblDesportHot" runat="server"></asp:Literal>
                        </ul>
                    </dd>
                </dl>
                <dl class="filter">
                    <dt>船公司：</dt>
                    <dd>
                        <ul>
                            <asp:Literal ID="lblCarrierHot" runat="server"></asp:Literal>
                        </ul>
                    </dd>
                </dl>
            </div>
        </div>
    </div>
    <div class="container keywords">
        <asp:Literal ID="ltrYouSearch" runat="server"></asp:Literal> 
    <asp:Label ID="hidTxtCarrier" runat="server"  CssClass="hide"></asp:Label>
    <asp:Label ID="hidTxtStartport" runat="server"  CssClass="hide"></asp:Label>
    <asp:Label ID="hidTxtDestport" runat="server"  CssClass="hide"></asp:Label>
    <asp:Label ID="hidTxtLine" runat="server"  CssClass="hide"></asp:Label>
    </div>

    <div class="container result">
        <div class="result-left">
            <div class="box-hd" id="table-hd">
                <dl>
                    <dd>
                        <ul>
                            <asp:Literal ID="lblOrder" runat="server"></asp:Literal>
                        </ul>
                    </dd>
                </dl>
            </div>
            <div class="box-bd">
                <ul>
                    <asp:Repeater ID="Rptfcladv" runat="server">
                    <ItemTemplate>
                    <li class="freight-row">
                        <div class="freight-show">
                            <div class="freight-hd">
                                <div class="valid">有效期至  <%#Format(CDate(Eval("enddate")), "yyyy").ToString%>-<%#Format(CDate(Eval("enddate")), "MM").ToString%>-<%#Format(CDate(Eval("enddate")), "dd").ToString%> </div>
                                <div class="date hide">
                                     <span class="sel">出发</span>   一、六            
                                </div>
                                <div class="range hide">
                                    <span class="sel">航程</span>  20天
                                </div>
                            </div>
                            <div class="freight-bd">
                                <div class="title"><h3><a href="/fcl/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank"><%#Eval("title").ToString%></a></h3></div>
                                <div class="content">
                                    <div class="port">
                                        <div><img src="/images2015/0213iconopol.gif"><%#Eval("startport").ToString.ToUpper %></div>
                                        <div><img src="/images2015/0213iconpod.gif"><%#Eval("destport").ToString.ToUpper%> </div>
                                    </div>
                                    <div class="freight">
                                        <dl>
                                            <dt>20GP</dt>
                                            <dd><%#Eval("price20gp").ToString%></dd>
                                        </dl>
                                        <div class="sep">|</div>
                                        <dl>
                                            <dt>40GP</dt>
                                            <dd><%#Eval("price40gp").ToString%></dd>
                                        </dl>
                                        <div class="sep">|</div>
                                        <dl>
                                            <dt>40HQ</dt>
                                            <dd><%#Eval("price40hq").ToString%></dd>
                                        </dl>
                                        <div class="sep">|</div>
                                        <dl>
                                            <dt>45HQ</dt>
                                            <dd><%#Eval("price45hq").ToString%></dd>
                                        </dl>
                                    </div>
                                    <div class="carrier">
                                        <%#Eval("shipcompany").ToString%>
                                    </div>
                                    <div class="op">
                                        <div class="order-desc"><a href="/fcl/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank"><%#IIf(Eval("order_advx") = "1", "<img src=""http://img02.100allin.com/pm/p/images/p2.gif"" border=""0"" title=""点击查看"" />", "")%><%#IIf(Eval("order_advx") > "1", "<img src=""http://img02.100allin.com/pm/p/images/" & IIf(Eval("userid") = "8352", "e3", "e2") & ".gif"" border=""0"" title=""点击查看"" />", "")%></a></div>
                                    </div>
                                </div>
                                <div class="company"><a href="/company/<%# key(eval("userid")) %>" target="_blank"><%#Eval("companyname").ToString%></a></div>
                            </div>
                        </div>
                    </li>
                    </ItemTemplate>
                    </asp:Repeater>

            <asp:PlaceHolder ID="PlaceHolder6" runat="server">
            <!--安运通测试代码-->
                <li class="freight-row" style="border-width: 1px; border-color: rgb(230, 230, 230) rgb(255, 255, 255); border-style: solid;">
                        <div class="freight-show">
                            <div class="freight-hd">
                                <div class="valid">有效期至  2015-05-31 </div>
                                <div class="date hide">
                                     <span class="sel">出发</span>   一、六            
                                </div>
                                <div class="range hide">
                                    <span class="sel">航程</span>  20天
                                </div>
                            </div>
                            <div class="freight-bd">
                                <div class="title"><h3><a href="/fcl/M1c3RnVIWUlBWTVjQWJRdjlxUCs3UT09_8128975.html" target="_blank">中南美桑托斯最新价格</a></h3></div>
                                <div class="content">
                                    <div class="port">
                                        <div><img src="/images2015/0213iconopol.gif">SHANGHAI</div>
                                        <div><img src="/images2015/0213iconpod.gif">SANTOS </div>
                                    </div>
                                    <div class="freight">
                                        <dl>
                                            <dt>20GP</dt>
                                            <dd>1050</dd>
                                        </dl>
                                        <div class="sep">|</div>
                                        <dl>
                                            <dt>40GP</dt>
                                            <dd>2100</dd>
                                        </dl>
                                        <div class="sep">|</div>
                                        <dl>
                                            <dt>40HQ</dt>
                                            <dd>2100</dd>
                                        </dl>
                                        <div class="sep">|</div>
                                        <dl>
                                            <dt>45HQ</dt>
                                            <dd></dd>
                                        </dl>
                                    </div>
                                    <div class="carrier">
                                        电询
                                    </div>
                                    <div class="op">
                                        <div class="order"><a href="/search/order_temp.aspx?type=fcl&filter=new&yid=290099&ydid=0&f=8299" target="_blank">订舱</a></div>
                                        <div class="order-desc"></div>
                                    </div>
                                </div>
                                <div class="company"><a href="/company/cnRhQWFFT2U4TTNFS0szVjdaQWRPZz09" target="_blank">上海汉万国际货物运输代理有限公司</a></div>
                            </div>
                        </div>
                    </li>
<!--安运通测试代码结束-->
</asp:PlaceHolder>
                    <asp:Repeater ID="Rptfcl" runat="server">
                    <ItemTemplate>
                    <li class="freight-row">
                        <div class="freight-show">
                            <div class="freight-hd">
                                <div class="valid">有效期至  <%#Format(CDate(Eval("enddate")), "yyyy").ToString%>-<%#Format(CDate(Eval("enddate")), "MM").ToString%>-<%#Format(CDate(Eval("enddate")), "dd").ToString%> </div>
                                <div class="date hide">
                                     <span class="sel">出发</span>一、六
                                </div>
                                <div class="range hide">
                                    <span class="sel">航程</span>  20天
                                </div>
                            </div>
                            <div class="freight-bd">
                                <div class="title"><h3><a href="/fcl/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank"><%#Eval("title").ToString%></a></h3></div>
                                <div class="content">
                                    <div class="port">
                                        <div><img src="/images2015/0213iconopol.gif"><%#Eval("startport").ToString.ToUpper%></div>
                                        <div><img src="/images2015/0213iconpod.gif"><%#Eval("destport").ToString.ToUpper%> </div>
                                    </div>
                                    <div class="freight">
                                        <dl>
                                            <dt>20GP</dt>
                                            <dd><%#Eval("price20gp").ToString%></dd>
                                        </dl>
                                        <div class="sep">|</div>
                                        <dl>
                                            <dt>40GP</dt>
                                            <dd><%#Eval("price40gp").ToString%></dd>
                                        </dl>
                                        <div class="sep">|</div>
                                        <dl>
                                            <dt>40HQ</dt>
                                            <dd><%#Eval("price40hq").ToString%></dd>
                                        </dl>
                                        <div class="sep">|</div>
                                        <dl>
                                            <dt>45HQ</dt>
                                            <dd><%#Eval("price45hq").ToString%></dd>
                                        </dl>
                                    </div>
                                    <div class="carrier">
                                        <%#Eval("shipcompany").ToString%>
                                    </div>
                                    <div class="op">
                                        <div class="order"><a href="/fcl/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank">查看</a></div>
                                        <div class="order-desc"></div>
                                    </div>
                                </div>
                                <div class="company"><a href="/company/<%# key(eval("userid")) %>" target="_blank"><%#Eval("companyname").ToString%></a></div>
                            </div>
                        </div>
                    </li>
                    </ItemTemplate>
                    </asp:Repeater>


                </ul>

                <DIV class="pager" >
                <span id="fen">
                <asp:Literal ID="ltrPage" runat="server" Visible="false"></asp:Literal></span>
                <asp:Literal ID="ltrPage2" runat="server"></asp:Literal>
                </DIV>

            </div>               
        </div>
        <div class="result-right" id="result-right">
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
            <div class="i-r-box">
                <asp:Literal ID="ltrBanner" runat="server"></asp:Literal>
                <asp:Literal ID="ltrBanner1" runat="server"></asp:Literal>
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
        </div>
    </div>

        <footer20150520:footer20150520 ID="footer201505201" runat="server" />
        <userblankbottom:userblankbottom ID="userblankbottom1" runat="server" />
</form>
</body>
</html>

