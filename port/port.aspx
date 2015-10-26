<%@ Page Language="C#" AutoEventWireup="true" CodeFile="port.aspx.cs" Inherits="port_port" EnableViewState="false" EnableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<asp:Literal id="ltrKey" runat="server"><meta name="keywords" content="深圳港" /></asp:Literal>
<asp:Literal id="ltrDesc" runat="server"><meta name="description" content="深圳港资源整理集合,包含最新最全的深圳港最新的海运整拼箱报价,查询深圳港各航线优势货运代理,深圳港各船公司优势运价" /></asp:Literal>
<asp:Literal id="ltrTitle" runat="server"><title>深圳港-深圳港海运信息,深圳港整拼箱报价,深圳港航线查询,深圳港船公司优势-环球运费网</title></asp:Literal>
<link href="/port/css/port.css" rel="stylesheet" type="text/css" />

<script language="javascript" type="text/javascript">
   
function changepic1()
{
    if(document.getElementById("tianjian1").src = document.getElementById("wgpic").src){

    document.getElementById("tianjian1").style.display='block';
    document.getElementById("tianjian2").style.display='none';
    document.getElementById("tianjian3").style.display='none';
    biglink.href = "/port/images/city/<asp:Literal ID="ltrPicBig1" runat="server">shenzhen</asp:Literal>1.jpg"


    }else{

    document.getElementById("tianjian1").style.display='none';
    document.getElementById("tianjian2").style.display='block';
    document.getElementById("tianjian3").style.display='block';

    }

}

function changepic2()
{
    if(document.getElementById("tianjian2").src = document.getElementById("pmpic").src){

    document.getElementById("tianjian2").style.display='block';
    document.getElementById("tianjian1").style.display='none';
    document.getElementById("tianjian3").style.display='none';
    biglink.href = "/port/images/city/<asp:Literal ID="ltrPicBig2" runat="server">shenzhen</asp:Literal>2.jpg"


    }else{

    document.getElementById("tianjian2").style.display='none';
    document.getElementById("tianjian1").style.display='block';
    document.getElementById("tianjian3").style.display='block';

    }
}

function changepic3()
{
      if(document.getElementById("tianjian3").src = document.getElementById("jtpic").src)
         {
          document.getElementById("tianjian3").style.display='block';
          document.getElementById("tianjian1").style.display='none';
          document.getElementById("tianjian2").style.display='none';
          biglink.href = "/port/images/city/<asp:Literal ID="ltrPicBig3" runat="server">shenzhen</asp:Literal>3.jpg"

    	 
        }else{
    	
          document.getElementById("tianjian3").style.display='none';
          document.getElementById("tianjian1").style.display='block';
          document.getElementById("tianjian2").style.display='block';
    	
        }
}


</script>


</head>
<body>
    <form id="form1" runat="server">
<div class="main_container">
		<div class="top">
			<div class="l_left"></div>
			<div class="m_left">
				<div class="top_nav">
					<div class="topnav_l"><a href="/" target="_blank"><strong>环球运费网</strong></a></div>					<div class="topnav_r"><a href="/" target="_blank">首页</a> | <a href="/fcl/" target="_blank">整箱运价</a> | <a href="/lcl/" target="_blank">拼箱运价</a> | <a href="/air/" target="_blank">空运运价</a> | <a href="/company/" target="_blank">公司库</a> | <a href="/bbs/" target="_blank">论坛</a>  |  <a href="/member/" target="_blank">办公室</a> |  <a href="/accounts/reg.aspx" target="_blank">注册</a> | <a href="/accounts/login.aspx" target="_blank">登录</a>&nbsp;&nbsp;</div>
				</div>
				<div class="top_tit" style=" background:url(/port/images/bg/<asp:Literal ID="ltrBg" runat="server"></asp:Literal>.jpg) no-repeat right;"><strong><asp:Literal ID="ltrPort1" runat="server"></asp:Literal>港</strong></div>
				<div class="top_list"><strong>港口切换</strong>：<a href="/port/shenzhen/">深圳港</a>  <a href="/port/shanghai/">上海港</a>  <a href="/port/qingdao/">青岛港</a>  <a href="/port/tianjin/">天津港</a>  <a href="/port/ningbo/">宁波港</a>  <a href="/port/dalian/">大连港</a>  <a href="/port/guangzhou/">广州港</a>  <a href="/port/xiamen/">厦门港</a></div>
			</div>
			<div class="r_left"></div>
		</div>
		<div class="main">
			<div class="present">
				<div class="present_text">
					<h1>
					 
					  <strong><asp:Literal ID="ltrPort2" runat="server"></asp:Literal>港介绍</strong>:</h1>
					<p><asp:Literal ID="ltrIntro" runat="server"></asp:Literal>...<span class="r1"><a href="/port/<asp:Literal ID="ltrDetailLink" runat="server"></asp:Literal>/detail/" target="_blank">[详细]</a></span></p>
				</div>
				<div class="present_pic">
					<div class="big_pic"><a href="/port/images/city/<asp:Literal ID="ltrPicBig" runat="server"></asp:Literal>1.jpg" id="biglink" target="_blank"><img src="/port/images/city/<asp:Literal ID="ltrPicb1" runat="server"></asp:Literal>1-md.jpg" border="0" id="tianjian1"  id="mainpiclink"  width="300" height="234"   alt=""/><img src="/port/images/city/<asp:Literal ID="ltrPicb2" runat="server"></asp:Literal>2-md.jpg"  id="tianjian2"  border="0" width="300" height="234"  style="display:none" alt=""/><img  src="/port/images/city/<asp:Literal ID="ltrPicb3" runat="server"></asp:Literal>3-md.jpg" id="tianjian3" border="0" width="300" height="234"  style="display:none" alt=""/></a></div>
					
					<div class="small_pic">
<a href="/port/images/city/<asp:Literal ID="ltrPicsLink1" runat="server"></asp:Literal>1.jpg" id="wgpiclink"  target="_blank"><img src="/port/images/city/<asp:Literal ID="ltrPics1" runat="server"></asp:Literal>1-md.jpg" border="0" id="wgpic"   width="94" height="71"   onmouseover="changepic1()" alt=""/></a><a href="/port/images/city/<asp:Literal ID="ltrPicsLink2" runat="server"></asp:Literal>2.jpg" id="pmpiclink" target="_blank"><img src="/port/images/city/<asp:Literal ID="ltrPics2" runat="server"></asp:Literal>2-md.jpg" border="0" class="p"   width="94" height="71"  id="pmpic" onmouseover="changepic2()" alt=""/></a><a href="/port/images/city/<asp:Literal ID="ltrPicsLink3" runat="server"></asp:Literal>3.jpg" id="jtpiclink" target="_blank"><img src="/port/images/city/<asp:Literal ID="ltrPics3" runat="server"></asp:Literal>3-md.jpg" border="0" id="jtpic"   width="94" height="71"  onmouseover="changepic3()" alt=""/></a></div>
				</div>

			</div>
			</div>
			<div class="agent">
				<h1><strong><asp:Literal ID="ltrPort3" runat="server"></asp:Literal>港各航线优势代理</strong></h1>
				<div class="agent_box">
				  <table width="786" border="0" cellspacing="1" cellpadding="0">
                    <tr>
                      <td><table width="100%" border="0" cellspacing="1" cellpadding="0">
                        <tr>
                          <td height="45" align="center"><a href="/company/list-<asp:Literal ID="ltrDaili1" runat="server"></asp:Literal>---欧地线--0-0----------1.html" target="_blank"><img src="/port/images/bt_r1_c1.gif" width="192" height="34" border="0" /></a></td>
                        </tr>
                        <tr>
                          <td height="45" align="center"><a href="/company/list-<asp:Literal ID="ltrDaili2" runat="server"></asp:Literal>---中东印巴线--0-0----------1.html" target="_blank"><img src="/port/images/bt_r3_c1.gif" width="192" height="34" border="0" /></a></td>
                        </tr>
                        <tr>
                          <td height="45" align="center"><a href="/company/list-<asp:Literal ID="ltrDaili3" runat="server"></asp:Literal>---澳洲线--0-0----------1.html" target="_blank"><img src="/port/images/bt_r5_c2.gif" width="192" height="34" border="0" /></a></td>
                        </tr>
                      </table></td>
                      <td><table width="100%" border="0" cellspacing="1" cellpadding="0" style="background:url(images/agent_bg3.jpg) no-repeat left bottom;">
                        <tr>
                          <td height="45" align="center"><a href="/company/list-<asp:Literal ID="ltrDaili4" runat="server"></asp:Literal>---美加线--0-0----------1.html" target="_blank"><img src="/port/images/bt_r1_c5.gif" width="192" height="34" border="0" /></a></td>
                        </tr>
                        <tr>
                          <td height="45" align="center"><a href="/company/list-<asp:Literal ID="ltrDaili5" runat="server"></asp:Literal>---中南美线--0-0----------1.html" target="_blank"><img src="/port/images/bt_r3_c5.gif" width="192" height="34" border="0" /></a></td>
                        </tr>
                        <tr>
                          <td height="45" align="center"><a href="/company/list-<asp:Literal ID="ltrDaili6" runat="server"></asp:Literal>---近洋线--0-0----------1.html" target="_blank"><img src="/port/images/bt_r5_c5.gif" width="192" height="34" border="0" /></a></td>
                        </tr>
                      </table></td>
                      <td><table width="100%" border="0" cellspacing="1" cellpadding="0" style="background:url(images/agent_bg3.jpg) no-repeat left bottom;">
                        <tr>
                          <td height="45" align="center"><a href="/company/list-<asp:Literal ID="ltrDaili7" runat="server"></asp:Literal>---非洲线--0-0----------1.html" target="_blank"><img src="/port/images/bt_r1_c7.gif" width="192" height="34" border="0" /></a></td>
                        </tr>
                        <tr>
                          <td height="45" align="center"><a href="/company/list-<asp:Literal ID="ltrDaili8" runat="server"></asp:Literal>---红海线--0-0----------1.html" target="_blank"><img src="/port/images/bt_r3_c7.gif" width="192" height="34" border="0" /></a></td>
                        </tr>
                        <tr>
                          <td height="45" align="center"><a href="/company/list-<asp:Literal ID="ltrDaili9" runat="server"></asp:Literal>---日韩线--0-0----------1.html" target="_blank"><img src="/port/images/bt_r5_c7.gif" width="192" height="34" border="0" /></a></td>
                        </tr>
                      </table></td>
                    </tr>
                  </table>
				</div>
			</div>
			<div class="agent">
				<h1><strong><asp:Literal ID="ltrPort4" runat="server"></asp:Literal>港各船公司优势运价</strong></h1>
				<div class="agent_box" style="background:url(images/agent_bg2.jpg) repeat-x top;">
					<p>
                        <asp:Literal ID="ltrCarrier" runat="server"></asp:Literal>
					</p>
			  </div>
		  </div>
			<div class="freight">
				<h1><strong><asp:Literal ID="ltrPort5" runat="server"></asp:Literal>港至世各港口运价查询</strong></h1>
				<div class="freight_box">
					<div class="freight_box_left">
						<div class="boxs">
							<h2><strong><asp:Literal ID="ltrPort6" runat="server"></asp:Literal>港-美加线最新运价</strong></h2>
							<div id="tabs2">
					  <div class="menu2box" style="background: url(images/ms_bg2.gif) no-repeat left top;">
								<ul id="menu2">
								  <li class="hover" style="border-left:none;"  id="label_1"><a target="_self"
								               onmouseover="this.parentNode.className='hover';
								            document.getElementById('label_2').className='null';
								            document.getElementById('div_1').style.display='block';
                                            document.getElementById('div_2').style.display='none';" href="#"><strong>整箱运价</strong></a></li>
								  <li id="label_2" ><a href="#" target="_self"
								            onmouseover="this.parentNode.className='hover';
								            document.getElementById('label_1').className='null';
								            document.getElementById('div_2').style.display='block';
                                            document.getElementById('div_1').style.display='none';">拼箱运价</a></li>
							    </ul>
				  </div>
				  <div class="main2box">
					<div id="div_1">
                        <asp:Literal ID="ltrFreight1f" runat="server"></asp:Literal>
	  		 
					</div>
					<div style="display:none" id="div_2">
					    <asp:Literal ID="ltrFreight1l" runat="server"></asp:Literal>
	
					</div>  		  </div>
			  </div>
						</div>
						<div class="boxs">
							<h2><strong><asp:Literal ID="ltrPort8" runat="server"></asp:Literal>港-中南美线最新运价</strong></h2>
							<div id="tabs2">
							<div class="menu2box" style="background: url(images/ms_bg2.gif) no-repeat left top;">
								<ul id="menu2">
								  <li class="hover" style="border-left:none;"  id="label_3"><a href="#" target="_self"
								           onmouseover="this.parentNode.className='hover';
								            document.getElementById('label_4').className='null';
								            document.getElementById('div_3').style.display='block';
                                            document.getElementById('div_4').style.display='none';
								     "><strong>整箱运价</strong></a></li>
								  <li id="label_4"><a href="#"
								  target="_self"
								            onmouseover="this.parentNode.className='hover';
								            document.getElementById('label_3').className='null';
								            document.getElementById('div_4').style.display='block';
                                            document.getElementById('div_3').style.display='none';">拼箱运价</a></li>
							    </ul>
				  </div>
				  <div class="main2box">
				   <div id="div_3">
					<asp:Literal ID="ltrFreight3f" runat="server"></asp:Literal>

					</div>
					<div id="div_4" style="display:none">
					<asp:Literal ID="ltrFreight3l" runat="server"></asp:Literal>

					</div>
					
					</div>
					
			  </div>
				</div>		
				        <div class="boxs">
							        <h2><strong><asp:Literal ID="ltrPort10" runat="server"></asp:Literal>港-近洋线最新运价</strong></h2>
							        <div id="tabs2">
					          <div class="menu2box" style="background: url(images/ms_bg2.gif) no-repeat left top;">
								        <ul id="menu2">
								          <li class="hover" style="border-left:none;" id="label_7"><a href="#"
								          target="_self"
								                   onmouseover="this.parentNode.className='hover';
								                    document.getElementById('label_8').className='null';
								                    document.getElementById('div_5').style.display='block';
                                                    document.getElementById('div_6').style.display='none';"><strong>整箱运价</strong></a></li>
								          <li id="label_8" ><a href="#"
								                          target="_self"
								                    onmouseover="this.parentNode.className='hover';
								                    document.getElementById('label_7').className='null';
								                    document.getElementById('div_6').style.display='block';
                                                    document.getElementById('div_5').style.display='none';">拼箱运价</a></li>
							            </ul>
				          </div>
				          <div class="main2box">
				           <div id="div_5">
					        <asp:Literal ID="ltrFreight5f" runat="server"></asp:Literal>

					        </div>
					        <div id="div_6" style="display:none">
					        <asp:Literal ID="ltrFreight5l" runat="server"></asp:Literal>

					        </div>
					         </div>
			          </div>
				        </div>
				        <div class="boxs">
							        <h2><strong><asp:Literal ID="ltrPort12" runat="server"></asp:Literal>港-澳洲线最新运价</strong></h2>
							        <div id="tabs2">
					          <div class="menu2box" style="background: url(images/ms_bg2.gif) no-repeat left top;">
								        <ul id="menu2">
								          <li class="hover" style="border-left:none;" id="label_9"><a
								          href="#"  target="_self"
								                             onmouseover="this.parentNode.className='hover';
								                    document.getElementById('label_10').className='null';
								                    document.getElementById('div_7').style.display='block';
                                                    document.getElementById('div_8').style.display='none';"><strong>整箱运价</strong></a></li>
								          <li id="label_10"><a
								          href="#"
								           target="_self"
								                    onmouseover="this.parentNode.className='hover';
								                    document.getElementById('label_9').className='null';
								                    document.getElementById('div_8').style.display='block';
                                                    document.getElementById('div_7').style.display='none';">拼箱运价</a></li>
							            </ul>
				          </div>
				          <div class="main2box">
				           <div id="div_7">
					        <asp:Literal ID="ltrFreight7f" runat="server"></asp:Literal>

					        </div>
					        <div id="div_8" style="display:none">
					        <asp:Literal ID="ltrFreight7l" runat="server"></asp:Literal>

					        </div>
					         </div>
			          </div>
				        </div>
						<div class="boxs">
							<h2><strong><asp:Literal ID="ltrPort14" runat="server"></asp:Literal>港-红海线最新运价</strong></h2>
							<div id="tabs2">
					  <div class="menu2box" style="background: url(images/ms_bg2.gif) no-repeat left top;">
								<ul id="menu2">
								  <li class="hover" style="border-left:none;" id="label_11"><a
								  href="#"
								  target="_self"
								                     onmouseover="this.parentNode.className='hover';
								            document.getElementById('label_12').className='null';
								            document.getElementById('div_9').style.display='block';
                                            document.getElementById('div_10').style.display='none';"><strong>整箱运价</strong></a></li>
								  <li id="label_12"><a
								  href="#"
								 target="_self"
								            onmouseover="this.parentNode.className='hover';
								            document.getElementById('label_11').className='null';
								            document.getElementById('div_10').style.display='block';
                                            document.getElementById('div_9').style.display='none';" >拼箱运价</a></li>
							    </ul>
				  </div>
				  <div class="main2box">
				     <div id="div_9">
					<asp:Literal ID="ltrFreight9f" runat="server"></asp:Literal>
					
			         </div>
				     <div id="div_10" style="display:none">
					<asp:Literal ID="ltrFreight9l" runat="server"></asp:Literal>
					
			         </div>			         
			         </div>   
			         </div>
			        
					</div>
					</div>
					<div class="freight_box_right">
						<div class="boxs">
							<h2><strong><asp:Literal ID="ltrPort7" runat="server"></asp:Literal>港-欧地线最新运价</strong></h2>
							<div id="tabs2">
					  <div class="menu2box" style="background: url(images/ms_bg2.gif) no-repeat left top;">
								<ul id="menu2">
								  <li class="hover" style="border-left:none;" id="label_13"><a 
								  href="#"
								   target="_self"
								            onmouseover="this.parentNode.className='hover';
								            document.getElementById('label_14').className='null';
								            document.getElementById('div_11').style.display='block';
                                            document.getElementById('div_12').style.display='none';"><strong>整箱运价</strong></a></li>
								  <li id="label_14"><a
								  href="#"
								   target="_self"
								            onmouseover="this.parentNode.className='hover';
								            document.getElementById('label_13').className='null';
								            document.getElementById('div_12').style.display='block';
                                            document.getElementById('div_11').style.display='none';">拼箱运价</a></li>
							    </ul>
				  </div>
				  <div class="main2box">
				  <div id="div_11">
					<asp:Literal ID="ltrFreight2f" runat="server"></asp:Literal>

			  </div>
			  <div id="div_12" style="display:none">
					<asp:Literal ID="ltrFreight2l" runat="server"></asp:Literal>
			  </div>
			  </div>
			  </div>
						</div>
						<div class="boxs">
							<h2><strong><asp:Literal ID="ltrPort9" runat="server"></asp:Literal>港-日韩线最新运价</strong></h2>
							<div id="tabs2">
					  <div class="menu2box" style="background: url(images/ms_bg2.gif) no-repeat left top;">
								<ul id="menu2">
								  <li class="hover" style="border-left:none;" id="label_15"><a
								  href="#" target="_self"
								            onmouseover="this.parentNode.className='hover';
								            document.getElementById('label_16').className='null';
								            document.getElementById('div_13').style.display='block';
                                            document.getElementById('div_14').style.display='none';"><strong>整箱运价</strong></a></li>
								  <li id="label_16"><a
								  href="#"
								   target="_self"
								            onmouseover="this.parentNode.className='hover';
								            document.getElementById('label_15').className='null';
								            document.getElementById('div_14').style.display='block';
                                            document.getElementById('div_13').style.display='none';">拼箱运价</a></li>
							    </ul>
				  </div>
				  <div class="main2box">
				
				  <div id="div_13">
					<asp:Literal ID="ltrFreight4f" runat="server"></asp:Literal>

			
			 </div>
				  <div id="div_14" style="display:none">
					<asp:Literal ID="ltrFreight4l" runat="server"></asp:Literal>

			 </div>
			 
			  </div>
						</div>
			
				</div>
						<div class="boxs">
							<h2><strong><asp:Literal ID="ltrPort11" runat="server"></asp:Literal>港-非洲线最新运价</strong></h2>
							<div id="tabs2">
					  <div class="menu2box" style="background: url(images/ms_bg2.gif) no-repeat left top;">
								<ul id="menu2">
								  <LI class="hover" style="border-left:none;" id="label_17" ><a 
								  href="#"
								  target="_self"
								            onmouseover="this.parentNode.className='hover';
								            document.getElementById('label_18').className='null';
								            document.getElementById('div_15').style.display='block';
                                            document.getElementById('div_16').style.display='none';"><strong>整箱运价</strong></a></li>
								  <li id="label_18"><a
								  href="#"
								  target="_self"
								            onmouseover="this.parentNode.className='hover';
								            document.getElementById('label_17').className='null';
								            document.getElementById('div_16').style.display='block';
                                            document.getElementById('div_15').style.display='none';">拼箱运价</a></li>
							    </ul>
				  </div>
				  <div class="main2box">
					<div id="div_15">
					<asp:Literal ID="ltrFreight6f" runat="server"></asp:Literal>

					</div>
					<div style="display:none" id="div_16">
					<asp:Literal ID="ltrFreight6l" runat="server"></asp:Literal>

					</div>  	
			  </div>
				</div>
						

					</div>
						<div class="boxs">
							<h2><strong><asp:Literal ID="ltrPort13" runat="server"></asp:Literal>港-中东印巴线最新运价</strong></h2>
							<div id="tabs2">
					  <div class="menu2box" style="background: url(images/ms_bg2.gif) no-repeat left top;">
								<ul id="menu2">
								  <li class="hover" style="border-left:none;" id="label_19"><a 
								  href="#"
								  target="_self"
								            onmouseover="this.parentNode.className='hover';
								            document.getElementById('label_20').className='null';
								            document.getElementById('div_17').style.display='block';
                                            document.getElementById('div_18').style.display='none';"><strong>整箱运价</strong></a></li>
								  <li id="label_20"><a
								  href="#"
								  target="_self"
								            onmouseover="this.parentNode.className='hover';
								            document.getElementById('label_19').className='null';
								            document.getElementById('div_18').style.display='block';
                                            document.getElementById('div_17').style.display='none';">拼箱运价</a></li>
							    </ul>
				  </div>
				  <div class="main2box">
					<div id="div_17">
					<asp:Literal ID="ltrFreight8f" runat="server"></asp:Literal>

					</div>
					<div style="display:none" id="div_18">
					<asp:Literal ID="ltrFreight8l" runat="server"></asp:Literal>

					</div>  
			  </div>
						</div>						
			</div>
			</div>
			
			</div>
			</div> 
			
<div class="top20">
<h1><strong><asp:Literal ID="ltrPort15" runat="server"></asp:Literal>港本月运价发布10强</strong></h1>
<div class="top20_box">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="10">&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td width="3%" height="30">&nbsp;</td>
    <td width="35%"><strong>公司名</strong></td>
    <td width="27%"><strong>联系人</strong></td>
    <td width="15%"><strong>运价发布量</strong></td>
    <td width="15%"><strong>排名</strong></td>
  </tr>
    <asp:Repeater ID="RptBillBoard" runat="server">
    <ItemTemplate>
      <tr>
    <td height="30" bgcolor="#f7f7f7">&nbsp;</td>
    <td bgcolor="#f7f7f7"><a href="/company/<%#setkey(Eval("Userid").ToString())%>/" target="_blank"><%#Eval("CompanyName").ToString()%></a></td>
    <td bgcolor="#f7f7f7"><a href="/company/<%#setkey(Eval("Userid").ToString())%>/" target="_blank"><%#Eval("RealName").ToString()%></a></td>
    <td bgcolor="#f7f7f7" class="gray"><%#Eval("c").ToString()%>条</td>
    <td bgcolor="#f7f7f7"><b class="<%#this.RptBillBoard.Items.Count < 3 ? (this.RptBillBoard.Items.Count == 0? "first":"second"):""%>"><%#this.RptBillBoard.Items.Count + 1%></b></td>
  </tr>
    </ItemTemplate>
    </asp:Repeater>

</table>
</div>
</div>


		<div class="foot"><a href="/about.html" target="_blank">关于我们</a> | <a href="/service.html" target="_blank">服务条款</a> | <a href="/law.html" target="_blank">法律声明</a> | <a href="/sitemap.html" target="_blank">网站地图</a> | <a href="/contact.html" target="_blank">联系我们</a>          <br />
          Copyright 2007-2009 100Allin.com All Rights Reserved
          <br />
      沪ICP备07510944号
	    </div>
	</div>
	
	

    </form>
</body>
</html>
