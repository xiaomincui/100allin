<%@ Page Language="C#" AutoEventWireup="true" CodeFile="temp_order_fcl.aspx.cs" Inherits="temp_order_fcl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
<div class="main_container">
<div class="top_bar"><!--顶部登陆开始-->

</div>
<div class="menu2"><!--导航开始-->
	  
	  <span class="right_tn">&nbsp;<a style="color:#1E5995;" title="欢迎使用在线客服" href="#" onclick="document.getElementById('aliserv').click();">在线客服</a></span>	</div>

 <div class="main_content" style="position:relative;">
 <div id="table_b">
 <table width="100%" align="center" class="order_table_a" border="0" cellspacing="0" cellpadding="0">
  <tbody>
   <tr>
    <th width="46%" align="left" rowspan="9"><strong>　发货人（Shipper）</strong><span class="red">*</span><br/>
    
    <div class="hr"/><strong>　收货人（Consignee）</strong><span class="red">*</span> 
    <div class="hr"/><strong>　通知人（Notify Party）</strong><span class="red">*</span>  </th>
    <th height="24" colspan="4"><strong>　订单编号：</strong>  </th>
   </tr>
   <tr>
    <th height="110" align="center" colspan="4"><center><b><font color="red" style="LINE-HEIGHT: 28px; FONT-SIZE: 26px">订舱委托书</font></b> </center></th>
   </tr>
   <tr>
    <th align="left" style="height: 24px"><strong>　公司名称：</strong><span class="red">*</span></th>
    <th align="left" colspan="3" style="height: 24px"></th>
   </tr>
   <tr>
    <th height="24" align="left"><strong>　邮箱：</strong><span class="red">*</span></th>
    <th height="24" align="left" colspan="3"></th>
   </tr>
   <tr>
    <th width="10%" height="24" align="left"><strong>　联系人：</strong></th>
    <th width="17%" height="24"></th>
    <th width="10%" align="left"><strong>　手机：</strong><span class="red">*</span></th>
    <th width="17%"></th>
   </tr>
   <tr>
    <th height="24" align="left"><strong>　电话：</strong><span class="red">*</span></th>
    <th height="24">
</th>
    <th align="left"><strong>　传真：</strong><span class="red">*</span></th>
    <th></th>
   </tr>
   <tr>
    <th height="24" align="left" colspan="2"><strong>　起运港（PORT OF LOADING）：</strong> </th>
    <th align="left" colspan="2"><input size="25" class="normalInput" /></th>
   </tr>
   <tr>
    <th height="12" align="left" colspan="2"><strong>　中转港（PORT OF DISCHARGE）：</strong></th>
    <th align="left" colspan="2"><input size="25" class="normalInput" /></th>
   </tr>
   <tr>
    <th height="12" align="left" colspan="2"><strong>　目的港（PORT OF DELIVERY）：</strong></th>
    <th align="left" colspan="2"><input size="25" class="normalInput" /></th>
   </tr>
  </tbody>
 </table>
 <table width="100%" class="order_table_a" style="BORDER-TOP-WIDTH: 0px" border="0" cellspacing="0" cellpadding="0">
  <tbody>
   <tr>
    <th width="17%" align="center"><center><strong>唛　头<br/>
    Marks &amp; Numbers </strong>
    <div class="hr"/> </center></th><th width="17%" align="center"><center><strong>件　数<br/>
    Numbers of Packages </strong>
    <div class="hr"/> </center></th><th width="42%" align="center"><center><span class="red">*</span><strong> 品　名<br/>
    Description of Goods &amp; Packages</strong><br/>
    <div class="hr"/> </center></th><th width="12%" align="center"><center><span class="red">*</span><strong> 毛　重<br/>
    Gross Weight</strong><br/>
    <div class="hr"/></center></th><th width="12%" align="center"><center><font color="red">*</font><strong> 体　积<br/>
    Measurement</strong><br/>
    <div class="hr"/></center></th>
   </tr>
  </tbody>
 </table>
 <table width="100%" class="order_table_a" style="BORDER-TOP-WIDTH: 0px" border="0" cellspacing="0" cellpadding="0">
  <tbody>
   <tr>
    <th width="11%" height="32"><strong>　运费条款：</strong></th><th align="left" colspan="3"> 预付（Freight Prepaid) <span style="DISPLAY: none"><strong>网络服务费： </strong><input name="feeservice" type="radio" checked="checked" value="1"/> 买家承担</span></th><th align="center" colspan="2">　<strong>运费详情</strong></th>
   </tr>
   <tr>
    <th height="32"><font color="red">*</font><strong> 开航日：</strong> </th>
    <th width="21%" align="left"><span class="note"> 结束</span></th>
    <th width="10%" align="center"><strong>船公司：</strong></th>
    <th width="19%" align="left"></th>
    <th width="9%"><strong>　关联信息：</strong></th>
    <th width="30%" align="left">&nbsp;</th>
   </tr>
   <tr>
    <th style="HEIGHT: 36px"><strong>　预计装箱日：</strong> </th>
    <th align="left" style="HEIGHT: 36px"></th>
    <th align="center" style="HEIGHT: 36px"><strong>截关日：</strong></th>
    <th align="left" style="HEIGHT: 36px"></th>
    <th style="HEIGHT: 36px"><strong>　</strong><strong>运价详情：</strong> </th>
    <th align="left" style="HEIGHT: 36px">&nbsp;  </th>
   </tr>
 
   <tr>
    <th style="height: 48px"><font color="red">*</font><strong> 箱型和箱量：</strong></th>
    <th align="left" colspan="3" style="height: 48px">
    20'：  
    40'：  
    40H'： </th>
    <th style="height: 48px"><strong>　海运费：</strong></th>
    <th align="left" style="height: 48px">&nbsp;
    </th>
   </tr>
   <tr>
    <th height="32" align="left" colspan="6">
    <h4><strong>　备注及其他要求：　</strong></h4>
    <strong/></th>
   </tr>
   <tr>
    <th align="left" valign="middle" colspan="6">
    <h5>　<strong>订舱注意事项</strong>： </h5>
    <br/>

    </th>
   </tr>
   <tr>
    <th height="80" align="center" valign="middle" colspan="6">



    </th>
   </tr>
  </tbody>
 </table>
 </div>
 



 

 </div> 
 </div>
 
 
</body>
</html>
