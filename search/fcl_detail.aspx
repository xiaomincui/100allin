<%@ Page Language="VB" AutoEventWireup="false" CodeFile="fcl_detail.aspx.vb" Inherits="search_fcl_detail" EnableViewState="false" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<asp:Literal id="Literal1" runat="server"><title>整箱海运运价-环球运费网</title></asp:Literal>
<asp:Literal id="Literal3" runat="server"><meta name="description" content="整箱海运运价-环球运费网" /></asp:Literal>
<asp:Literal id="Literal2" runat="server"><meta name="keywords" content="整箱海运运价-环球运费网" /></asp:Literal>
<meta name="viewport" content="width=1280, initial-scale=0.2"/>
<link href="/css2015/master.css" rel="stylesheet" type="text/css" />
<link href="/css2015/freight.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js2015/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="/js2015/base.js"></script>
<script type="text/javascript" src="/js2015/freight.js"></script>
<script type="text/javascript" src="/js2015/readmore.min.js"></script>

<script type="text/javascript" language="javascript" src="/js2015/auto/ac_zd.js"></script>
<script type="text/javascript" language="javascript" src="/js2015/auto/airprot_ch.js"></script>
<script type="text/javascript" language="javascript" src="/js2015/auto/ac_zd_head_home.js"></script>
<link href="/js2015/auto/port.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    
</script>

<style type="text/css">

</style>
</head>
<body>
<form>
    <div id="messages"></div>
	<div class="header">
		<headtop20150520:headtop20150520 ID="headtop201505201" runat="server" />
		<headmid120150520:headmid120150520 ID="headmid1201505201" runat="server" />
        <headnav20150520:headnav20150520 ID="headnav201505201" runat="server" />
	</div>
    
    <div class="container breadcrumbs">
        <a href="/">首页</a><span class="sep">-</span><a href="/">整箱海运价</a><span class="sep">-</span><span><asp:Literal ID="ltrTitleBC" runat="server"></asp:Literal></span>
    </div>

<asp:Panel ID="Panel2" runat="server"  Visible="false">
<div class="main_content"><!--中部开始-->
<div class="" style="background:url(/images/fcl/info_bg.gif) no-repeat left top;"><!--左边开始-->
<div style="clear:both;">
<table width="92%" border="0" align="center" cellpadding="0" cellspacing="1" style="background:url(/images/fcl/33.gif) no-repeat right 65px;">
<tr><td height="10" align="center"></td></tr>
<tr><td height="32" align="left" ><div class="blue" style=" font:14px '宋体'; line-height:48px; border-bottom:1px dashed #ccc;"><img src="/images2015/fcl/jt2.gif" />&nbsp;<strong>环球运费网提示</strong></div></td></tr>
<tr><td height="10" align="center" ></td></tr>
<tr><td height="10" align="center" ></td></tr>
<tr><td height="10" align="center" ></td></tr>								
<tr><td height="28" align="left" style="line-height:18px; font-size:14px;">
以下为该条运价预览效果</td></tr>
</table>
<br/><br/><br/><br/>
</div>
</div>
</div>  
</asp:Panel>
<asp:Panel ID="Panel4" runat="server" Visible="false">
<div class="main_content"><!--中部开始-->
<div class="" style="background:url(/images/fcl/info_bg.gif) no-repeat left top;"><!--左边开始-->
<div style="clear:both;">
<table width="92%" border="0" align="center" cellpadding="0" cellspacing="1" style="background:url(/images/fcl/33.gif) no-repeat right 65px;">
<tr><td height="10" align="center"></td></tr>
<tr><td height="32" align="left" ><div class="blue" style=" font:14px '宋体'; line-height:48px; border-bottom:1px dashed #ccc;"><img src="/images2015/fcl/jt2.gif" />&nbsp;<strong>环球运费网提示</strong></div></td></tr>
<tr><td height="10" align="center" ></td></tr>
<tr><td height="10" align="center" ></td></tr>
<tr><td height="10" align="center" ></td></tr>								
<tr><td height="28" align="left" style="line-height:18px; font-size:14px;">
亲爱的用户，该运价已被删除或不存在，请点击以下地址，查询更多运价<br/>
<a href="/fcl/">http://www.100allin.com/fcl/</a></td></tr>
</table>
<br/><br/><br/><br/>
</div>
</div>
</div>  
</asp:Panel>
<asp:Panel ID="Panel5" runat="server" Visible="false">
<div class="main_content"><!--中部开始-->
<div class="" style="background:url(/images2015/fcl/info_bg.gif) no-repeat left top;">
<div style="clear:both;">
<table width="92%" border="0" align="center" cellpadding="0" cellspacing="1" style="background:url(/images2015/fcl/33.gif) no-repeat right 65px;">
<tr><td height="10" align="center"></td></tr>
<tr><td height="32" align="left" ><div class="blue" style=" font:14px '宋体'; line-height:48px; border-bottom:1px dashed #ccc;"><img src="/images2015/fcl/jt2.gif" />&nbsp;<strong>环球运费网提示</strong></div></td></tr>
<tr><td height="10" align="center" ></td></tr>
<tr><td height="10" align="center" ></td></tr>
<tr><td height="10" align="center" ></td></tr>								
<tr><td height="28" align="left" style="line-height:18px; font-size:14px;">
<asp:Label ID="Label28" runat="server" Text=""></asp:Label></td></tr>
</table>
<br/><br/><br/><br/>
</div>
</div>
</div>        
</asp:Panel>

    <asp:PlaceHolder ID="PlaceHolder6" runat="server">
    <div class="container d-detail">
        <div class="detail-left">
            <div class="title"><h1 id="limit-title"><asp:Literal ID="ltrTitle" runat="server"></asp:Literal></h1></div>
            <div class="valid"><span>有效期至：<asp:Literal ID="ltrEndDate" runat="server"></asp:Literal></span> 
            <div class="bdsharebuttonbox"><a class="share-title">分享到：</a><%--<a href="#" class="bds_more" data-cmd="more"></a>--%><a href="#" class="bds_weixin" data-cmd="weixin" title="分享到微信"></a><a href="#" class="bds_tsina" data-cmd="tsina" title="分享到新浪微博"></a><a href="#" class="bds_sqq" data-cmd="sqq" title="分享到QQ好友"></a><a href="#" class="bds_qzone" data-cmd="qzone" title="分享到QQ空间"></a><a href="#" class="bds_tqq" data-cmd="tqq" title="分享到腾讯微博"></a><a href="#" class="bds_renren" data-cmd="renren" title="分享到人人网"></a><a href="#" class="bds_douban" data-cmd="douban" title="分享到豆瓣网"></a></div><script>window._bd_share_config = { "common": { "bdSnsKey": {}, "bdText": "", "bdMini": "2", "bdMiniList": false, "bdPic": "", "bdStyle": "0", "bdSize": "16" }, "share": {} }; with (document) 0[(getElementsByTagName('head')[0] || body).appendChild(createElement('script')).src = 'http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion=' + ~(-new Date() / 36e5)];</script>
            </div>
            <div class="port-box">
                <dl class="pol" id="port-box-pol">
                    <dt class="pol-en">
                        起运港
                    </dt>
                    <dd class="pol-cn">
                        <asp:Literal ID="Literal5" runat="server"></asp:Literal>
                    </dd>
                </dl>
                    <div class="arrow-b"><img src="/images2015/arrow_b.gif" /></div>
                    <div class="carrier" id="arrow-carrier"><asp:Label ID="Label2" runat="server" Text="" CssClass="span-c"></asp:Label><asp:Label ID="Label1" runat="server" Text="" CssClass="span-d"></asp:Label></div>
                    <div class="arrow-f"><img src="/images2015/arrow_f.gif" /></div>
                <dl class="pod" id="port-box-pod">
                    <dt class="pod-en">
                        目的港
                    </dt>
                    <dd class="pod-cn">
                        <asp:Literal ID="LtrDestport" runat="server"></asp:Literal>
                    </dd>
                </dl>
                
                
            </div>
            <div class="freight">
                <dl>
                    <dt>20GP</dt>
                    <dd><asp:Literal ID="Ltr20GP" runat="server"></asp:Literal></dd>
                </dl>
                <dl>
                    <dt>40GP</dt>
                    <dd><asp:Literal ID="Ltr40GP" runat="server"></asp:Literal></dd>
                </dl>
                <dl>
                    <dt>40HQ</dt>
                    <dd><asp:Literal ID="Ltr40HQ" runat="server"></asp:Literal></dd>
                </dl>
                <dl>
                    <dt>45HQ</dt>
                    <dd><asp:Literal ID="Ltr45HQ" runat="server"></asp:Literal></dd>
                </dl>
            </div>
            <div class="freight-sub">
                <dl>
                    <dt>航线</dt>
                    <dd><asp:Literal ID="Literal6" runat="server"></asp:Literal></dd>
                </dl>
                <div class="sep"></div>
                <dl>
                    <dt>出发日</dt>
                    <dd><asp:Literal ID="LtrDepartureWkd" runat="server"></asp:Literal></dd>
                </dl>
                <div class="sep"></div>
                <dl>
                    <dt>航程</dt>
                    <dd><asp:Literal ID="LtrDistance" runat="server"></asp:Literal></dd> 
                </dl>
                <div class="sep"></div>
                <dl>
                    <dt>船公司</dt>
                    <dd><asp:Literal ID="Ltrshipcompany" runat="server"></asp:Literal></dd>
                </dl>
            </div>
            <div class="freight-more">
                <asp:Literal ID="Literal20" runat="server"></asp:Literal>
            </div>
            <asp:PlaceHolder ID="PlaceHolder4" runat="server" Visible="true">
                    <div class="blue_box"><asp:Literal ID="Literal21" runat="server"></asp:Literal> </div>
            </asp:PlaceHolder>
        </div>
        <div class="detail-right">
            <div class="u-company">
                <asp:Literal ID="Literal8" runat="server"></asp:Literal>
            </div>
            <div class="u-head">
                <img id="imghead" src="/images2015/fcl/people.GIF" runat="server" />
            </div>
            <div class="u-name">
                <asp:Literal ID="LtrRealname" runat="server"></asp:Literal>
            </div>
            <div class="u-pm">
                <asp:Literal ID="Literal25" runat="server"></asp:Literal>
            </div>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
            
            <div class="u-row">
            <dl>
                <dt>电话：</dt>
                <dd><asp:Literal ID="Literal9" runat="server"></asp:Literal></dd>
            </dl> 
            <dl>
                <dt>手机：</dt>
                <dd><asp:Literal ID="Literal11" runat="server"></asp:Literal></dd>
            </dl>
            </div>
            <div class="u-row">
            <dl>
                <dt>地址：</dt>
                <dd><asp:Literal ID="Literal13" runat="server"></asp:Literal></dd>
            </dl> 
            <dl>
                <dt>Email：</dt>
                <dd><asp:Literal ID="Literal12" runat="server"></asp:Literal></dd>
            </dl>
            </div> 
            <div class="u-row">
            <dl>
                <dt>在线联系：</dt>
                <dd><asp:Literal ID="Literal29" runat="server"></asp:Literal><asp:Literal ID="Literal30" runat="server"></asp:Literal></dd>
            </dl>
            </div>  
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder2" runat="server">
                <div class="u-sign">
                想查看该用户联系方式请 <a href="/accounts/login.aspx">登录</a>
                <br />
                如您还不是环球运费网会员请 <a href="/accounts/login.aspx">注册</a>
                </div>
            </asp:PlaceHolder>
        </div>
    </div>
    <a id="detail"></a>
    <div class="container d-more">
        <div class="d-more-left">
            <div class="d-more-nav d-more-freight">
                <div class="title current">其它运价</div>
                <div class="filter" id="filter">
                    
                </div>
        <div class="result-left">
            
            <div class="box-bd">
                <ul>
                <asp:Repeater ID="RptYunjia" runat="server">
                <ItemTemplate>         
                    <li class="freight-row">
                            <div class="freight-bd">
                                <div class="title"><a href="/fcl/<%#key(Eval("yunjiaid"))%>_<%#Eval("id")%>.html"><%#Eval("startport1").ToString.ToUpper %> 至 <%#Eval("destport").ToString.ToUpper %></a><span><%#(Convert.ToDateTime(Eval("enddatex")) - DateAndTime.Now()).Days.ToString()%> 天内有效</span></div>
                                <div class="content">
                                    <div class="freight">
                                        <dl>
                                            <dt>20GP</dt>
                                            <dd><%#Eval("price20gp")%></dd>
                                        </dl>
                                        <div class="sep">|</div>
                                        <dl>
                                            <dt>40GP</dt>
                                            <dd><%#Eval("price40gp")%></dd>
                                        </dl>
                                        <div class="sep">|</div>
                                        <dl>
                                            <dt>40HQ</dt>
                                            <dd><%#Eval("price40hq")%></dd>
                                        </dl>
                                    </div>
                                    <div class="freight freight-sub">
                                        <dl>
                                            <dt>船公司</dt>
                                            <dd><%#Eval("shipcompany")%></dd>
                                        </dl>
                                        <div class="sep">|</div>
                                        <dl>
                                            <dt>出发日</dt>
                                            <dd><%#Eval("DepartureWkd")%></dd>
                                        </dl>
                                        <div class="sep">|</div>
                                        <dl>
                                            <dt>航程</dt>
                                            <dd><%#Eval("Distance")%></dd>
                                        </dl>
                                    </div>
                                    <div class="op">
                                        <div class="order"><a href="/fcl/<%#key(Eval("yunjiaid"))%>_<%#Eval("id")%>.html">查看</a> <a href="/fcl/list-<%#Eval("startport1")%>-<%#Eval("destport") %>--0-0-0-----1.html" target="_blank" class="more">更多</a></div>
                                    </div>
                                </div>
                            </div>
                    </li>
                    </ItemTemplate>
                    </asp:Repeater>
                    
                                                            
                </ul>

                <DIV class="pager" >
                <span id="fen">共 
                <asp:Literal ID="ltrTp" runat="server"></asp:Literal> 页 <asp:Literal ID="ltrTi" runat="server"></asp:Literal> 条结果
                <asp:Literal ID="ltrPage" runat="server" Visible="false"></asp:Literal></span>
                <asp:Literal ID="ltrPage2" runat="server"></asp:Literal>
                </DIV>

            </div>               
        </div>
        </div>
        </div>
        <div class="d-more-right">
        <div class="d-more-nav d-more-rmb">
                <div class="title current">附加费</div>
                <div class="detail"><asp:Literal ID="LtrPlus" runat="server"></asp:Literal></div>
        </div>
        <div class="d-more-nav d-more-remark">
                <div class="title current">运价备注</div>
                <div class="detail"><asp:Literal ID="LabMemo" runat="server"></asp:Literal></div>
        </div>
        </div>


        
        
    </div>
    </asp:PlaceHolder>
    <footer20150520:footer20150520 ID="footer201505201" runat="server" />
</form>
</body>
</html>

