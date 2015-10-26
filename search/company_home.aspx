<%@ Page Language="VB" AutoEventWireup="false" CodeFile="company_home.aspx.vb" Inherits="search_company_home" EnableEventValidation="false" ValidateRequest="false" %><%@ OutputCache Duration="300" VaryByParam="*" VaryByCustom="SessionID" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="zh">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta name="keywords" content="货代,货代公司,货运代理,公司库,环球运费网" />
        <meta name="description" content="货代名录(环球运费网公司库)拥有大量货代公司的注册信息,货代名录的会员资料齐全,每日有大量的新注册公司,加入成为货代公司库中的一员,货运代理公司尽在环球运费网货代名录" />
        <title>货代名录-公司库,货运代理公司黄页,货代公司查询-环球运费网</title>
        <link type="text/css" rel="stylesheet" href="/css2015/master.css">
        <link type="text/css" rel="stylesheet" href="/css2015/company.css">
        
    </head>

 <body>
 <form id="form1" runat="server" autocomplete="off">
    <div id="messages"></div>
	<div class="header">
		<headtop20150520:headtop20150520 ID="headtop201505201" runat="server" />
		<headmid120150520:headmid120150520 ID="headmid1201505201" runat="server" />
        <headnav20150520:headnav20150520 ID="headnav201505201" runat="server" />
	</div>
<div class="container">
    <!-- 广告位 -->
    <div id="intro-slide" class="slide_com">
    </div>
    <!-- 热门货代公司 -->
    <div class="hot_logistics  all-wrap">
        <div class="sec-t">
            <h3 class="title">
              <img src="/images2015/company/hot_logistics.png" alt="">
            </h3>
        </div>
        <div class="sec-c">
            <table class="member-grid">
                <thead>
                    <tr>
                      <th></th>
                      <th>公司名</th>
                      <th>联系人</th>
                      <th>地址 </th>
                      <th>服务</th>
                      <th>联系方式</th>
                   
                    </tr>
                </thead>
                <tbody class="first">
                    <tr class="info">
                         <td><a href="/company/VUR6THhyMUpMU292VFRvbGFid1B0QT09/" target="_blank"><img src="/member/Head/127584.jpg" width="50" height="50" border="0" /></a></td>
                         <td><a href="/company/VUR6THhyMUpMU292VFRvbGFid1B0QT09/" target="_blank">上海康铁国际物流有限公司</a></td>
                         <td class="center">方小姐/路先生</td>
                         <td class="center">上海市-上海市</td>
                         <td class="center">全铁运输</td>
                         <td class="center">
                            <a href="/company/VUR6THhyMUpMU292VFRvbGFid1B0QT09/" target="_blank" style="color:#666666;"><img src="/pm/p/images/e2.gif" border="0" title="点击查看联系方式" /></a>
                        </td>
                    </tr>
                    <asp:Repeater ID="RptNewUser" runat="server">
                      <ItemTemplate>
                    <tr class="info <%# IIf((Container.ItemIndex mod 2=0),"grey","") %>">
                         <td><a href="/company/<%#key(eval("userid")) %>/" target="_blank"><img src="/member/Head/<%#eval("userid") %>.jpg" width="50" height="50" border="0" /></a></td>
                         <td><a href="<%#IIf(Eval("userid")="73066","http://www.100allin.com/waysglobal/",IIf(Eval("userid")="74973","http://www.100allin.com/wsa/","/company/"& key(eval("userid")) & "/"))%>" target="_blank"><%#Eval("CompanyName").ToString()%></a></td>
                         <td class="center"><%#Eval("Realname").ToString()%></td>
                         <td class="center"><%#Eval("Login2_Locus1").ToString()%>-<%#Eval("Login2_Locus2").ToString()%></td>
                         <td class="center"><%#IIf(Eval("Login2_Adventage_Type_fcl").ToString() = "1", "整箱海运", "")%><br/> <%#IIf(Eval("Login2_Adventage_Type_lcl").ToString() = "1", "拼箱海运", "")%> <br/><%#IIf(Eval("Login2_Adventage_Type_air").ToString() = "1", "空运", "")%></td>
                         <td class="center"><a target="_blank" href="/company/<%#key(eval("userid"))%>/" class="red">联系方式</a></td>
                    </tr>
                    </ItemTemplate>
                      </asp:Repeater>
                </tbody>
            </table>
        </div>
        <div class="explain clearfix">
             <p class="help l"><i class="star"></i> <a class="title" href="http://www.100allin.com/help/help_fcl.html#tips" target="_blank"> 相关帮助</a></p> 
             <div class="pageview r">
                <a href="/company/list-------0-0----------2.html" class="flip active">1</a>
				<a href="/company/list-------0-0----------2.html" class="flip">2</a>
				<a href="/company/list-------0-0----------3.html" class="flip">3</a>
				<a href="/company/list-------0-0----------4.html" class="flip">4</a>
				<a href="/company/list-------0-0----------5.html" class="flip">5</a>
				<a href="/company/list-------0-0----------6.html" class="flip">6</a>
				<a href="/company/list-------0-0----------7.html" class="flip">7</a>
				<a href="/company/list-------0-0----------8.html" class="flip">8</a>
				<a href="/company/list-------0-0----------9.html" class="flip">9</a>
				<a href="/company/list-------0-0----------10.html" class="flip">10</a>
                <a class="flip next" href="/company/list-------0-0----------2.html">
                   下一页
                </a>
            </div>
        </div>
             
    </div> 
    <!-- 查找公司 -->  
    <div class="search_com">
           <div class="sec-t">
                <div class="all-wrap">
                   <h3 class="title">
                      <img src="/images2015/company/com_title.png" alt="">
                    </h3> 
                </div>
                
            </div>
            <div class="all-wrap">
            <div class="sec-c">
                  <table class="member-grid">
                <thead>
                    <tr>
                      <th class="mid">整箱公司分类</th>
                      <th class="deep">拼箱公司分类</th>         
                    </tr>
                </thead>
                <tbody class="first">
                    <tr class="grey info">
                         <td> 按起运港分类</td>
                         <td> 按起运港分类</td>                    
                    </tr>
                    <tr class="info">
                         <td>
                            <ul class="clearfix">
                                <li class="list"><a href="/company/list-上海市-上海市-整箱海运----0-0----------1.html">上海港货代公司</a></li>
                                <li class="list"><a href="/company/list-广东省-深圳市-整箱海运----0-0----------1.html">深圳港货代公司</a></li>
                                <li class="list"><a href="/company/list-天津市-天津市-整箱海运----0-0----------1.html">天津港</a></li>
                                <li class="list"><a href="/company/list-浙江省-宁波市-整箱海运----0-0----------1.html">宁波港</a></li>
                                <li class="list"><a href="/company/list-山东省-青岛市-整箱海运----0-0----------1.html">青岛港</a></li>
                                <li class="list"><a href="/company/list-福建省-厦门市-整箱海运----0-0----------1.html">厦门港</a></li>
                                <li class="list"><a href="/company/list-辽宁省-大连市-整箱海运----0-0----------1.html">大连港</a></li>
                                <li class="list"><a href="/company/list-广东省-广州市-整箱海运----0-0----------1.html">广州港</a></li>
                                <li class="list"><a href="/company/list-江苏省-连云港市-整箱海运----0-0----------1.html">连云港</a></li>
                                <li class="list"><a href="/company/list-河北省-秦皇岛市-整箱海运----0-0----------1.html">秦皇岛</a></li>
                                <li class="list"><a href="/company/list-辽宁省-营口市-整箱海运----0-0----------1.html">营口</a></li>
                                <li class="list"><a href="/company/list-山东省-日照市-整箱海运----0-0----------1.html">日照港</a></li>
                                <li class="list"><a href="/company/list-辽宁省-唐山市-整箱海运----0-0----------1.html">唐山港</a></li>
                                <li class="list"><a href="/company/list-山东省-烟台市-整箱海运----0-0----------1.html">烟台港</a></li>
                                <li class="list"><a href="/company/list-江苏省-南通市-整箱海运----0-0----------1.html">南通港</a></li>
                                <li class="list"><a href="/company/list-江苏省-南京市-整箱海运----0-0----------1.html">南京港</a></li>
                                <li class="list"><a href="/company/list-广东省-佛山市-整箱海运----0-0----------1.html">佛山港</a></li>
                                 <li class="list"><a href="/company/list-广东省-珠海市-整箱海运----0-0----------1.html">珠海港</a></li>
                                 <li class="list"><a href="/company/list-广东省-中山市-整箱海运----0-0----------1.html">中山港</a></li>
                                 <li class="list"><a href="/company/list-广东省-湛江市-整箱海运----0-0----------1.html">湛江港</a></li>
                                 <li class="list"><a href="/company/list-广东省-汕头市-整箱海运----0-0----------1.html">汕头港</a></li>
                                 <li class="list"><a href="/company/list-福建省-泉州市-整箱海运----0-0----------1.html">泉州港</a></li>
                                 <li class="list"><a href="/company/list-福建省-福州市-整箱海运----0-0----------1.html">福州港</a></li>
                                 <li class="list"><a href="/company/list-广西省-防城港市-整箱海运----0-0----------1.html">防城港</a></li>
                                <li class="list more"><a href="/company/list---整箱海运----0-0----------1.html">更多...</a></li>
                            </ul>                                          
                         </td>
                         <td>
                             <ul class="clearfix">
                                <li class="list"><a href="/company/list-上海市-上海市-拼箱海运----0-0----------1.html">上海港货代公司</a></li>
                                <li class="list"><a href="/company/list-广东省-深圳市-拼箱海运----0-0----------1.html">深圳港货代公司</a></li>
                                <li class="list"><a href="/company/list-天津市-天津市-拼箱海运----0-0----------1.html">天津港</a></li>
                                <li class="list"><a href="/company/list-浙江省-宁波市-拼箱海运----0-0----------1.html">宁波港</a></li>
                                <li class="list"><a href="/company/list-山东省-青岛市-拼箱海运----0-0----------1.html">青岛港</a></li>
                                <li class="list"><a href="/company/list-福建省-厦门市-拼箱海运----0-0----------1.html">厦门港</a></li>
                                <li class="list"><a href="/company/list-辽宁省-大连市-拼箱海运----0-0----------1.html">大连港</a></li>
                                <li class="list"><a href="/company/list-广东省-广州市-拼箱海运----0-0----------1.html">广州港</a></li>
                                <li class="list"><a href="/company/list-江苏省-连云港市-拼箱海运----0-0----------1.html">连云港</a></li>
                                <li class="list"><a href="/company/list-河北省-秦皇岛市-拼箱海运----0-0----------1.html">秦皇岛</a></li>
                                <li class="list"><a href="/company/list-辽宁省-营口市-拼箱海运----0-0----------1.html">营口</a></li>
                                <li class="list"><a href="/company/list-山东省-日照市-拼箱海运----0-0----------1.html">日照港</a></li>
                                <li class="list"><a href="/company/list-辽宁省-唐山市-拼箱海运----0-0----------1.html">唐山港</a></li>
                                <li class="list"><a href="/company/list-山东省-烟台市-拼箱海运----0-0----------1.html">烟台港</a></li>
                                <li class="list"><a href="/company/list-江苏省-南通市-拼箱海运----0-0----------1.html">南通港</a></li>
                                <li class="list"><a href="/company/list-江苏省-南京市-拼箱海运----0-0----------1.html">南京港</a></li>
                                <li class="list"><a href="/company/list-广东省-佛山市-拼箱海运----0-0----------1.html">佛山港</a></li>
                                 <li class="list"><a href="/company/list-广东省-珠海市-拼箱海运----0-0----------1.html">珠海港</a></li>
                                 <li class="list"><a href="/company/list-广东省-中山市-拼箱海运----0-0----------1.html">中山港</a></li>
                                 <li class="list"><a href="/company/list-广东省-湛江市-拼箱海运----0-0----------1.html">湛江港</a></li>
                                 <li class="list"><a href="/company/list-广东省-汕头市-拼箱海运----0-0----------1.html">汕头港</a></li>
                                 <li class="list"><a href="/company/list-福建省-泉州市-拼箱海运----0-0----------1.html">泉州港</a></li>
                                 <li class="list"><a href="/company/list-福建省-福州市-拼箱海运----0-0----------1.html">福州港</a></li>
                                 <li class="list"><a href="/company/list-广西省-防城港市-拼箱海运----0-0----------1.html">防城港</a></li>
                                <li class="list more"><a href="/company/list---拼箱海运----0-0----------1.html">更多...</a></li>
                            </ul> 
                         </td>        
                    </tr>
                    <tr class="grey info">
                         <td>按航线分类</td>
                         <td>按航线分类</td>                    
                    </tr>
                    <tr class="info">
                         <td>
                             <ul class="clearfix">
                                <li class="list"><a href="/company/list---整箱海运--美加--0-0----------1.html">美加线</a></li>
                                <li class="list"><a href="/company/list---整箱海运--非洲--0-0----------1.html">非洲线</a></li>
                                <li class="list"><a href="/company/list---整箱海运--中东印巴--0-0----------1.html">中东印巴线</a></li>
                                <li class="list"><a href="/company/list---整箱海运--中南美--0-0----------1.html">中南美线</a></li>
                                <li class="list"><a href="/company/list---整箱海运--欧地--0-0----------1.html">欧地线</a></li>
                                <li class="list"><a href="/company/list---整箱海运--日韩--0-0----------1.html">日韩线</a></li>
                                <li class="list"><a href="/company/list---整箱海运--近洋--0-0----------1.html">近洋线</a></li>
                                <li class="list"><a href="/company/list---整箱海运--澳洲--0-0----------1.html">澳洲线</a></li>
                                <li class="list"><a href="/company/list---整箱海运--红海--0-0----------1.html">红海线</a></li>
                            </ul> 
                         </td>                                 
                         <td>
                            <ul class="clearfix">
                                <li class="list"><a href="/company/list---拼箱海运--美加--0-0----------1.html">美加线</a></li>
                                <li class="list"><a href="/company/list---拼箱海运--非洲--0-0----------1.html">非洲线</a></li>
                                <li class="list"><a href="/company/list---拼箱海运--中东印巴--0-0----------1.html">中东印巴线</a></li>
                                <li class="list"><a href="/company/list---拼箱海运--中南美--0-0----------1.html">中南美线</a></li>
                                <li class="list"><a href="/company/list---拼箱海运--欧地--0-0----------1.html">欧地线</a></li>
                                <li class="list"><a href="/company/list---拼箱海运--日韩--0-0----------1.html">日韩线</a></li>
                                <li class="list"><a href="/company/list---拼箱海运--近洋--0-0----------1.html">近洋线</a></li>
                                <li class="list"><a href="/company/list---拼箱海运--澳洲--0-0----------1.html">澳洲线</a></li>
                                <li class="list"><a href="/company/list---拼箱海运--红海--0-0----------1.html">红海线</a></li>
                            </ul>  
                         </td>        
                    </tr>
                    <tr class="grey info">
                         <td>按船公司分类</td>                 
                         <td> &nbsp; &nbsp; </td>
                    </tr>
                    <tr class="info"> 
                         <td>
                              <ul class="clearfix">
                                <li class="list"><a href="/company/list---整箱海运----0-0-马士基---------1.html">马士基</a></li>
                                <li class="list"><a href="/company/list---整箱海运----0-0-地中海---------1.html">地中海</a></li>
                                <li class="list"><a href="/company/list---整箱海运----0-0-川崎---------1.html">川崎</a></li>
                                <li class="list"><a href="/company/list---整箱海运----0-0-长荣---------1.html">长荣</a></li>
                                <li class="list"><a href="/company/list---整箱海运----0-0-太平---------1.html">太平</a></li>
                                <li class="list"><a href="/company/list---整箱海运----0-0-中海---------1.html">中海</a></li>
                                <li class="list"><a href="/company/list---整箱海运----0-0-东方海外---------1.html">东方海外</a></li>
                                <li class="list"><a href="/company/list---整箱海运----0-0-达飞---------1.html">达飞</a></li>
                                <li class="list"><a href="/company/list---整箱海运----0-0-中远---------1.html">中远</a></li>
                                <li class="list"><a href="/company/list---整箱海运----0-0-以星---------1.html">以星</a></li>
                                <li class="list"><a href="/company/list---整箱海运----0-0-阳明---------1.html">阳明</a></li>
                                <li class="list"><a href="/company/list---整箱海运----0-0-美国总统---------1.html">美国总统</a></li>
                                <li class="list"><a href="/company/list---整箱海运----0-0-南美邮船---------1.html">南美邮船</a></li>
                                <li class="list"><a href="/company/list---整箱海运----0-0-现代---------1.html">现代</a></li>
                                <li class="list"><a href="/company/list---整箱海运----0-0-韩进---------1.html">韩进</a></li>
                                <li class="list"><a href="/company/list---整箱海运----0-0-万海---------1.html">万海</a></li>
                                <li class="list more"><a href="/company/list---整箱海运----0-0----------1.html">更多...</a></li>
                            </ul> 

                         </td>   
                         <td> &nbsp;  </td>     
                    </tr>
                 
                </tbody>
            </table>
            </div>
        </div>
    </div>
    <!-- 按钮 -->
    <div class="seachnav">
       <div class="all-wrap">
          <ul class="clearfix">
              <li class="item item01"><a href="/company/list-------0-0--进口--------1.html"></a></li>
              <li class="item item02"><a href="/company/list-------0-0--冷冻冷藏--------1.html"></a></li>
              <li class="item item03"><a href="/company/list-------0-0--其他特种柜--------1.html"></a></li>
              <li class="item item04"><a href="http://www.100allin.com/dangerouscargo/company/list.aspx?port=shanghai"></a></li>
              <li class="item item05"><a href="/company/list-------0-0--私人物品--------1.html"></a></li>
              <li class="item item06"><a href="/company/list-------0-0--散杂货船--------1.html"></a></li>
          </ul>
       </div>        
    </div>
    <!-- 空运公司分类 -->
    <div class="airlift">
       <div class="all-wrap">
            <div class="sec-t">
                <h3 class="title">
                  <img alt="" src="/images2015/company/hot_logistics1.png">
                </h3>
            </div>
            <div class="sec-c">
                <table class="member-grid">
                    <thead>
                        <tr>
                          <th>按起运地分类</th>
                          <th>按航线分类</th>
                        </tr>
                    </thead>
                    <tbody class="first">
                        <tr class="info">
                            <td>
                                <ul class="clearfix">
                                  <li class="list"><a href="/company/list-上海市-上海市-空运----0-0----------1.html">上海</a></li>
                                  <li class="list"><a href="/company/list-广东省-深圳市-空运----0-0----------1.html">深圳</a></li>
                                  <li class="list"><a href="/company/list-广东省-广州市-空运----0-0----------1.html">广州</a></li>
                                  <li class="list"><a href="/company/list-北京市-北京市-空运----0-0----------1.html">北京</a></li>
                                  <li class="list"><a href="/company/list-香港特别行政区-香港特别行政区-空运----0-0----------1.html">香港</a></li>
                                  <li class="list"><a href="/company/list-浙江省-杭州市-空运----0-0----------1.html">杭州</a></li>
                                  <li class="list"><a href="/company/list-江苏省-南京市-空运----0-0----------1.html">南京</a></li>
                                  <li class="list"><a href="/company/list-福建省-厦门市-空运----0-0----------1.html">厦门</a></li>
                                  <li class="list"><a href="/company/list-山东省-青岛市-空运----0-0----------1.html">青岛</a></li>
                                  <li class="list"><a href="/company/list-广东省-珠海市-空运----0-0----------1.html">珠海</a></li>
                                  <li class="list"><a href="/company/list-湖南省-长沙市-空运----0-0----------1.html">长沙</a></li>
                                  <li class="list"><a href="/company/list-湖北省-武汉市-空运----0-0----------1.html">武汉</a></li>
                                  <li class="list"><a href="/company/list-四川省-成都市-空运----0-0----------1.html">成都</a></li>
                                  <li class="list"><a href="/company/list-重庆市-重庆市-空运---北美-0-0----------1.html">重庆</a></li>
                                  <li class="list"><a href="/company/list-浙江省-宁波市-空运----0-0----------1.html">宁波</a></li>
                                  <li class="list"><a href="/company/list-辽宁省-大连市-空运----0-0----------1.html">大连</a></li>
                                </ul>
                            </td>                                                                                                  
                             <td>
                                 <ul class="clearfix">
                                    <li class="list"><a href="/company/list---空运---北美-0-0----------1.html">北美线</a></li>
                                    <li class="list"><a href="/company/list---空运---欧洲-0-0----------1.html">欧洲线</a></li>
                                    <li class="list"><a href="/company/list---空运---南美-0-0----------1.html">南美线</a></li>
                                    <li class="list"><a href="/company/list---空运---亚洲-0-0----------1.html">亚洲线</a></li>
                                    <li class="list"><a href="/company/list---空运---非洲-0-0----------1.html">非洲线</a></li>
                                    <li class="list"><a href="/company/list---空运---澳洲-0-0----------1.html">澳洲线</a></li>
                                    <li class="list"><a href="/company/list---空运---近洋-0-0----------1.html">近洋线</a></li>
                                    <li class="list"><a href="/company/list---空运---国内-0-0----------1.html">国内航线</a></li>
                                  </ul>
 
                          </td>
                        </tr>
                    </tbody>
                </table>
            </div>

         </div>
    </div>
                            
</div> 
    <footer20150520:footer20150520 ID="footer201505201" runat="server" />
</form>
</body>

</html>

