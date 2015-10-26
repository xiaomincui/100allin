<%@ Page Language="VB" AutoEventWireup="false" CodeFile="link.aspx.vb" Inherits="intro_link" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>傲赢网 - 相关链接</title>
    <link href="../css/master.css" rel="stylesheet" type="text/css" />
    <link href="../css/list.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
<!--

-->
</style>
<script language="javascript" type="text/javascript" src="../js/function.js"></script>
</head>
<body onload="AutoTips('officetips')">
<form id="form1" runat="server" autocomplete="off" onKeydown="if(event.enterKey){return   false}">
<asp:ScriptManager ID="ScriptManager1" runat="server"> 
</asp:ScriptManager>
<script language="javascript" type="text/javascript">
    Sys.Application.add_load(function(){var form=Sys.WebForms.PageRequestManager.getInstance()._form;form._initialAction=form.action=window.location.href;});
</script>
    <div id="page">
		<div id="center">
			<usertop:usertop ID="Usertop1" runat="server" />
			<div id="menu">
			  <table width="990" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="10"><img src="../images/menu_1.gif" width="10" height="35" /></td>
                      <td width="970" background="../images/menu_2.gif">
						  <ul>
							<li><a href="/">首页</a></li>
							<li>|</li>
							<li><a href="../search/fcl.htm">整箱运价</a></li>
							<li>|</li>
							<li><a href="../search/lcl.htm">拼箱运价</a></li>
							<li>|</li>
							<li><a href="../search/air.htm">空运运价</a></li>
							<li>|</li>
							<li><a href="../search/cargo.htm">货盘信息</a></li>
							<li>|</li>
							<li><a href="/search/company.htm" target="_blank">公司库</a></li>
							<li>|</li>
							<li><a href="/home/space.php?do=home" target="_blank">社区</a> <span style="color:red;font-weight:bold;">[新]</span></li>
							<li>|</li>
							<li><a href="/bbs/" target="_blank">论坛</a></li>s</ul>
					 </td>
                      <td width="10"><img src="../images/menu_3.gif" width="10" height="35" /></td>
                    </tr>
                  </table>
			</div>
			<div id="main">
				<div id="left">
				 <userlogin:userlogin id="Userlogin1" runat="server" />
				</div>
				<div id="right">
                <div id="search">
					  <table border="0" cellspacing="0" cellpadding="0">
							<tr>
							  <td width="10" ><img src="../images/box_1.gif" width="10" height="31" /></td>
							  <td width="780" background="../images/box_2.gif" ><div class="bigBoxTitle">相关链接</div></td>
							  <td width="10" ><img src="../images/box_3.gif" width="10" height="31" /></td>
							</tr>
							<tr>
							      <td background="../images/box_4.gif" style="height: 15px"></td>
							      <td bgcolor="#FFFFFF">
							        <div class="searchbox" style=" line-height:25px; font-size:14px;">
                                        <p>
                                            <span><strong>贸易类</strong></span>
									  <table width="100%" border="0" cellpadding="0" cellspacing="0">
											  <tr>
												<td width="25%"><a href="http://www.efu.com.cn/" target="_blank">中国服装网</a></td>
												<td width="25%"><a href="http://www.eachnet.com/" target="_blank">易趣网上购物</a></td>
												<td width="25%"><a href="http://www.cn176.com/" target="_blank">外贸论坛</a></td>
												<td width="25%"><a href="http://cn.ecvv.com" target="_blank" title="全球首家按效果付费的国际贸易网站">伊西威威国际贸易网</a></td>
											  </tr>
											  <tr>
												<td><a href="http://www.yuhuan.org/" target="_blank">中国贸易网</a></td>
												<td><a href="http://www.168xiezi.com/" target="_blank">168国际鞋业网</a></td>
												<td><a href="http://www.easy128.cn" target="_blank">便易精品服饰网</a></td>
												<td><a href="http://www.import.net.cn/bbs/" target="_blank">进口交流论坛</a></td>
											  </tr>
											  <tr>
												<td><a href="http://www.yikaishi.com/" target="_blank">深圳服装网</a></td>
												<td><a href="http://www.cn-pjjck.com/" target="_blank">中国皮具进出口网</a></td>
												<td><a href="http://www.tradehr.com/" target="_blank">外贸英才网</a></td>
												<td><a href="http://www.zgyhbz.com/" target="_blank">烟花</a></td>
											  </tr>
											  <tr>
												<td><a href="http://www.hbeb.com/" target="_blank">每日商务</a></td>
												<td><a href="http://www.chinaccm.com/" target="_blank">中华商务网</a></td>
												<td><a href="http://www.lgmi.com/" target="_blank">兰格钢铁网</a></td>
												<td><a href="http://www.lgsou.com/" target="_blank">兰格搜钢网</a></td>
											  </tr>	
											  <tr>
												<td><a href="http://china.busytrade.com/" target="_blank">万国商业网</a></td>
												<td><a href="http://www.ccen.net/" target="_blank">中国化工设备网</a></td>
												<td><a href="http://china.tootoo.com/" target="_blank">合众外贸论坛</a></td>
												<td><a href="http://www.cnexpnet.com/" target="_blank">中国出口贸易网</a></td>
											  </tr>	
											  <tr>
												<td><a href="http://www.globalmarket.com/" target="_blank">GlobalMarket</a></td>
												<td><a href="http://www.oemresource.com/" target="_blank">制造资源网</a></td>
												<td><a href="http://www.ccsbw.com/" target="_blank">中国仓储设备网</a></td>
												<td></td>
											  </tr>												  												  										  
									  </table>
                                            <A href="http://www.efu.com.cn/" target=_blank></A>
                                            <p>
                                            <span><strong>物流类</strong></span>
											<table width="100%" border="0" cellpadding="0" cellspacing="0">
											  <tr>
												<td width="25%"><a href="http://www.56885.net/" target="_blank">物流天下</a></td>
												<td width="25%"><a href="http://www.3m56.com/" target="_blank">商贸物流网</a></td>
												<td width="25%"><a href="http://www.zghy.com/" target="_blank">中国货运信息网</a></td>
												<td width="25%"><a href="http://www.in56.com" target="_blank">银河物流网</a></td>
											  </tr>
											  <tr>
											    <td><a href="http://www.xd56b.com/" target="_blank">中国物流产业网</a></td>
											    <td><a href="http://www.4px.cc/" target="_blank">递四方速递</a></td>
											    <td><a href="http://56best.com/" target="_blank">物流网址大全</a><a href="http://www.zgzx56.com/" target="_blank"></a></td>
											    <td><a href="http://www.zgzx56.com/" target="_blank">重型物流行业网</a><a href="http://WWW.SZHZS.COM/" target="_blank"></a></td>
										      </tr>
											  <tr>
											    <td><a href="http://WWW.SZHZS.COM/" target="_blank">深圳船务</a><a href="http://www.siyuda.cn/" target="_blank"></a></td>
											    <td><a href="http://www.siyuda.cn/" target="_blank">代理出口</a><a href="http://www.logistics.cn/" target="_blank"></a></td>
											    <td><a href="http://www.logistics.cn/" target="_blank">物流网</a></td>
											    <td><a href="http://www.maersk.com/" target="_blank">马士基(中国)航运有限公司</a><a href="http://www.kline.com.cn/" target="_blank"></a></td>
										      </tr>
											  <tr>
											    <td><a href="http://www.kline.com.cn/" target="_blank">&quot;K&quot;Line(中国)有限公司</a><a href="http://www.evergreen.com.tw/" target="_blank"></a></td>
											    <td><a href="http://www.qcwlph.com/" target="_blank">中国全程物流配货网</a></td>
											    <td><a href="http://bbs.02156.cn/" target="_blank">02156论坛</a></td>
											    <td><a href="http://www.all56.com/" target="_blank">中国大物流网</a></td>
										      </tr>
											  <tr>
											    <td><a href="http://www.5630.cn/" target="_blank">厦门物流网</a></td>
											    <td><a href="http://www.qd56.cn/" target="_blank">青岛物流网</a></td>
											    <td><a href="http://www.tenglida.com/" target="_blank">中国西部物流</a></td>
											    <td><a href="http://www.chinawutong.com/" target="_blank">中国物通网</a></td>
										      </tr>
											  <tr>
											    <td><a href="http://www.wxp168.com/" target="_blank">化学危险品运输网</a></td>
											    <td><a href="http://www.clb.org.cn/" target="_blank">中国物流招标网</a></td>
											    <td><a href="http://www.zj56.com.cn/" target="_blank">浙江物流网</a></td>
											    <td><a href="http://www.56zp.cn/" target="_blank">中国物流招聘网</a><a href="http://www.tradehr.com/" target="_blank"></a></td>
										      </tr>
											  <tr>
											    <td><a href="http://www.csi.com.cn/" target="_blank">航运信息网</a></td>
											    <td><a href="http://www.edit56.com.cn/" target="_blank">中国物流资料中心</a></td>
											    <td><a href="http://www.honghai56.com/" target="_blank">宏海物流网</a></td>
											    <td><a href="http://www.02156.cn/" target="_blank">中国物流企业网</a></td>
										      </tr>
											  <tr>
											    <td><a href="http://www.un56.com/" target="_blank">中国物流联合网</a></td>
											    <td><a href="http://www.max56.com/" target="_blank">MAX56物流网</a></td>
											    <td><a href="http://www.cnvnlo.com/" target="_blank">中越物流网</a></td>
											    <td><a href="http://www.china5648.com/" target="_blank">中国物流设备技术网</a></td>
										      </tr>
											  <tr>
											    <td><a href="http://www.wuliujob.com/" target="_blank">物流人才网</a></td>
											    <td><a href="http://www.fgship.cn/" target="_blank">广州国际运输</a></td>
											    <td><a href="http://www.fgshipping.cn/" target="_blank">广州报关</a></td>
											    <td><a href="http://www.kdccc.com" target="_blank">快递查询网</a></td>
										      </tr>			
											  <tr>
											    <td><a href="http://www.bestscm.com/" target="_blank">中国供应链管理网</a></td>
											    <td><a href="http://www.pdacw.cn/" target="_blank">远洋运输</a></td>
											    <td><a href="http://www.xd56.net/" target="_blank">现代物流专线网</a></td>
											    <td><a href="http://www.057756.net" target="_blank">温州物流网</a></td>
										      </tr>	
											  <tr>
											    <td><a href="http://cnhaiyun.com/" target="_blank">中国海运网</a></td>
											    <td><a href="http://www.ea56.com/" target="_blank">e物流网</a></td>
											    <td><a href="http://www.pprd56.cn/" target="_blank">泛珠三角物流网</a></td>
											    <td><a href="http://www.daluqiao.org/" target="_blank">大陆桥物流平台</a></td>
										      </tr>
											  <tr>
											    <td><a href="http://www.56114.net.cn/" target="_blank">物流查询网</a></td>
											    <td></td>
											    <td></td>
											    <td></td>
										      </tr>												      											      									      											      								      									      
										  	</table>											
											
                                            <A href="http://www.56885.net/" target=_blank></A>
                                            <p>
                                            <span><strong>其他类</strong></span>
									  <table width="100%" border="0" cellpadding="0" cellspacing="0">
											  <tr>
												<td width="25%"><a href="http://www.snet.com.cn/" target="_blank">中国航贸网</a></td>
												<td width="25%"><a href="http://www.rqdw.com/" target="_blank">中国软启动网</a></td>
												
												<td width="25%"><a href="http://china.sunmen.com/" target="_blank">商盟</a></td>
                                                <td width="25%"><a href="http://www.edit56.com/news_xx.asp?acid=445" target="_blank">2008年CeMAT物流论坛</a></td>
											  </tr>
											  <tr>
											    <td><a href="http://www.linkwb.cn" target="_blank">自动友情链接</a></td>
											    <td><a href="http://www.yqlink.com/in.asp?id=qyp9928" target="_blank">友情链接网</a></td>
											    <td><a href="http://www.google.com/" target="_blank">Google谷歌</a></td>
											    <td><a href="http://www.baidu.com/" target="_blank">百度搜索</a></td>
									    </tr>
											  <tr>
											    <td><a href="http://www.jibuz.com/" target="_blank">“记不住”网址导航</a></td>
											    <td><a href="http://www.baibuu.com/in.asp?id=qyp9928" target="_blank" title="百部网址导航，欢迎站长店主加入！">百部网址导航</a></td>
											    <td><a href="http://link.265.com/gonew.php?id=94040&amp;width=468" target="_blank">265自助链</a></td>
											    <td><a href="http://www.sino-logistics.com/" target="_blank">中国物流论坛</a></td>
									    </tr>
											  <tr>
											    <td><a href="http://www.08.cn/" target="_blank">08中国商机网</a></td>
											    <td><a href="http://www.jobtransport.cn/" target="_blank">物流招聘网</a></td>
											    <td><a href="http://www.caigouyuan.cn/" target="_blank">万行采购人才网</a></td>
											    <td><a href="http://www.risejob.com" target="_blank">猎头学院</a></td>
									    </tr>
											  <tr>
											    <td><a href="http://www.32800.com/" target="_blank">城市通</a></td>
											    <td><a href="http://www.2008translation.com/" target="_blank">上海科技翻译网</a></td>
											    <td><a href="http://www.didibank.net/" target="_blank">上海租车</a></td>
											    <td><a href="http://www.56job.net/" target="_blank">中国物流人才招聘网</a></td>
									    </tr>
									    </tr>
											  <tr>
											    <td><a href="http://www.360hy.com/index.html" target="_blank">中国商业网址</a></td>
											    <td><a href="http://www.jjoobb.cn" target="_blank">郑州招聘网</a></td>
											    <td><a href="http://www.soven.biz" target="_blank">Soven翻译公司</a></td>
											    <td><a href="http://www.pekingzuche.com" target="_blank">北京汽车租赁</a></td>
									    </tr>		
											  <tr>
											    <td><a href="http://www.cnrentcar.cn" target="_blank">汽车租赁</a></td>
											    <td><a href="http://www.pdriving.cn" target="_blank">北京租车</a></td>
											    <td><a href="http://www.zhuce168.com.cn" target="_blank">注册公司</a></td>
											    <td><a href="http://www.21banchang.net" target="_blank">上海搬家公司</a></td>
									    </tr>										    							    
								  	  </table>											
                                            <br />
                                            <a href="http://www.snet.com.cn/" target="_blank"></a></div>
							      </td>
							      <td background="../images/box_6.gif" style="height: 15px"></td>
							</tr>
							<tr>
							  <td><img src="../images/box_7.gif" width="10" height="10" /></td>
							  <td background="../images/box_8.gif"></td>
							  <td><img src="../images/box_9.gif" width="10" height="10" /></td>
							</tr>
				      </table>
				</div>
				</div>
			</div>
		</div>
    </div>
	<div><img src="../images/blank.gif" width="100%" height="10" /></div>
	<div id="bottom">
		<div class="line"><img src="../images/line_blue.gif" width="100%" height="1" /></div>
		<div class="copyright"><a href="/intro/about.aspx">关于傲赢</a>|<a href="/intro/service.aspx">服务条款</a>|<a href="/intro/law.aspx">法律声明</a>|<a href="/intro/contact.aspx">联系我们</a><br />Copyright 2007 100Allin.com All Rights Reserved<br />沪ICP备07510944号</div>
	</div>
</form>		
<script language="javascript" src="http://count48.51yes.com/click.aspx?id=485102224&logo=1"></script>	
</body>
</html>

