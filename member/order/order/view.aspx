<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view.aspx.cs" Inherits="pro_order_view" EnableEventValidation="false" EnableViewState="false" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>查看订舱单</title>
<script src="js/jquery.min.js" type="text/javascript"></script>
<script src="js/jquery.hoverIntent.js" type="text/javascript"></script>
<script src="js/jquery.bgiframe.min.js" type="text/javascript"></script>
<script src="js/jquery.cluetip.js" type="text/javascript"></script>
<script src="js/demo.js" type="text/javascript"></script>
<link rel="stylesheet" href="css/jquery.cluetip.css" type="text/css" />
<link rel="stylesheet" href="css/demo.css" type="text/css" />
<link href="css/home.css" type="text/css" rel="stylesheet">
</head>
<body>
        <form id="form1" runat="server">
    <table id="infos_main" cellspacing="0" cellpadding="0" width="932" align="center"
        border="0">

            <tbody>
                <tr>
                    <td id="order" valign="top">
                        <h4>
                            <span class="note right">提示：带“<font color="red">*</font>”为必填内容 </span>订舱委托书：
                            <!--Start write orders-->
                        <input type="checkbox" name="cb" id="cb"  /> <label for="cb">显示提示</label></h4>
                        <div id="table_b">
                            <table id="order_table_a" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tbody>
                                    <tr>
                                        <th width="50%" rowspan="8">
                                            <font color="red">*</font>&nbsp;&nbsp;&nbsp;<strong>发货人（Shipper）</strong><br>
                                            <textarea class="pr10 pl10" id="txtShipperName" rows="7" cols="60" readonly title="提示|请在这里填写发货人名称，注意名称请写全，此项必填" runat="server"></textarea>
                                            <div class="hr">
                                            </div>
                                            <strong>　收货人（Consignee）</strong>
                                            <textarea class="pr10 pl10 bbb" name="consignee" rows="7" cols="60"></textarea>
                                            <div class="hr">
                                            </div>
                                            <strong>　通知人（Notify Party）</strong>
                                            <textarea class="pr10 pl10 bbb" name="notify" rows="7" cols="60"></textarea>
                                        </th>
                                        <th colspan="4" height="24">
                                            <strong>　工作编号：</strong>
                                            <asp:Literal ID="ltrGongZuoBianHao" runat="server"></asp:Literal>
                                        </th>
                                    </tr>
                                    <tr>
                                        <th align="middle" colspan="4" height="110">
                                            <center>
                                                <b><font style="font-size: 26px; line-height: 28px" color="red">
                                                    <input id="priviewcom" type="hidden" name="priviewcom">
                                                    <input type="hidden" value="52" name="shipcom">
                                                    <br>
                                                    订舱委托书</font></b>
                                            </center>
                                        </th>
                                    </tr>
                                    <tr>
                                        <th>
                                            <strong>　邮　箱：</strong></th>
                                        <th colspan="3">
                                            　<asp:Literal ID="ltrUserEmail" runat="server"></asp:Literal></th>
                                    </tr>
                                    <tr>
                                        <th width="8%">
                                            <strong>　联系人：</strong></th>
                                        <th width="20%">
                                            　<asp:Literal ID="ltrRealName" runat="server"></asp:Literal>
                                        </th>
                                        <th width="7%">
                                            <strong>　手　机：</strong></th>
                                        <th>
                                            　<asp:Literal ID="ltrMovePhone" runat="server"></asp:Literal></th>
                                    </tr>
                                    <tr>
                                        <th>
                                            <strong>　电　话：</strong></th>
                                        <th>
                                            　<asp:Literal ID="ltrPhone" runat="server"></asp:Literal>
                                        </th>
                                        <th>
                                            <strong>　传　真：</strong></th>
                                        <th>
                                            　<asp:Literal ID="ltrFax" runat="server"></asp:Literal></th>
                                    </tr>
                                    <tr>
                                        <th colspan="2">
                                            <strong>　起运港（PORT OF LOADING）：</strong>
                                        </th>
                                        <th colspan="2">
                                            　<asp:Literal ID="ltrStartPort" runat="server"></asp:Literal>
                                        </th>
                                    </tr>
                                    <tr>
                                        <th colspan="2">
                                            <strong>　中转港（PORT OF DISCHARGE）：</strong></th>
                                        <th colspan="2">
                                            <input name="dport"></th>
                                    </tr>
                                    <tr>
                                        <th colspan="2">
                                            <strong>　目的港（PORT OF DELIVERY）：</strong></th>
                                        <th colspan="2">
                                            　<asp:Literal ID="ltrDestPort" runat="server"></asp:Literal>
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="font_center" id="order_table_a" style="border-top-width: 0px" cellspacing="0"
                                cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <th align="middle" width="17%">
                                            <center>
                                                <strong>唛 头<br>
                                                    Marks &amp; Numbers </strong>
                                                <div class="hr">
                                                </div>
                                                <textarea name="marks" rows="15"></textarea>
                                            </center>
                                        </th>
                                        <th align="middle" width="17%">
                                            <center>
                                                <strong>件 数<br>
                                                    Numbers of Packages </strong>
                                                <div class="hr">
                                                </div>
                                                <textarea name="nums" rows="15"></textarea>
                                            </center>
                                        </th>
                                        <th align="middle" width="42%">
                                            <center>
                                                <font color="red">*</font><strong> 品 名<br>
                                                    Description of Goods &amp; Packages</strong><br>
                                                <div class="hr">
                                                </div>
                                                <textarea name="description" rows="15" cols="45" readonly id="txtCargoName" runat="server"></textarea>
                                            </center>
                                        </th>
                                        <th align="middle" width="12%">
                                            <center>
                                                <strong>毛 重<br>
                                                    Gross Weight</strong><br>
                                                <div class="hr">
                                                </div>
                                                <textarea name="gwight" rows="15" cols="16"></textarea></center>
                                        </th>
                                        <th align="middle" width="12%">
                                            <center>
                                                <font color="red">*</font><strong> 体 积<br>
                                                    Measurement</strong><br>
                                                <div class="hr">
                                                </div>
                                                <textarea name="measurement" rows="15" cols="16" id="txtMeasurement" readonly runat="server"></textarea></center>
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                            <table id="order_table_a" style="border-top-width: 0px" cellspacing="0" cellpadding="0"
                                width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <th height="32">
                                            <strong>　运费条款：</strong></th>
                                        <th colspan="3">
                                            <input type="radio" checked value="1" name="prepaid">
                                            预付（Freight Prepaid) <span style="display: none"><strong>网络服务费： </strong>
                                                <input type="radio" checked value="1" name="feeservice">
                                                买家承担</span></th>
                                        <th colspan="4">
                                            其他联系资料</th>
                                    </tr>
                                    <tr>
                                        <th width="11%" height="32">
                                            <strong>　运价编号：</strong></th>
                                        <th width="23%">
                                            　<asp:Literal ID="ltrYid" runat="server"></asp:Literal>
                                            　<asp:Literal ID="ltrYid2" runat="server" Visible="false"></asp:Literal>
                                            　<asp:Literal ID="ltrUserid" runat="server" Visible="false"></asp:Literal>
                                            </th>
                                        <th width="10%">
                                            <font color="red">　*</font><strong> 船公司：</strong></th>
                                        <th width="17%">
                                            　<asp:Literal ID="ltrCarrier" runat="server"></asp:Literal></th>
                                        <th width="9%">
                                            <strong>　操作员：</strong></th>
                                        <th>
                                            <input size="14" name="pcontact"></th>
                                        <th width="6%">
                                            <strong>　手机：</strong>
                                        </th>
                                        <th>
                                            <input maxlength="16" size="14" name="pcontact_mobile"></th>
                                    </tr>
                                    <tr>
                                        <th height="32">
                                            <strong>　开航日：</strong>
                                        </th>
                                        <th>
                                            <input id="startdate" size="9" name="startdate">
                                            <img style="cursor: pointer" height="21" src="images/cal.gif" width="28" align="middle"><span
                                                class="note"> <asp:Literal ID="ltrEndDate" runat="server"></asp:Literal>结束</span></th>
                                        <th>
                                            <strong>　截关日：</strong> &nbsp;</th>
                                        <th>
                                            <input id="duedate"  size="14" name="duedate">
                                            <img style="cursor: pointer" height="21" src="images/cal.gif" width="28" align="middle">
                                            &nbsp;</th>
                                        <th>
                                            <strong>　电话：</strong></th>
                                        <th>
                                            <input maxlength="16" size="14" name="pcontact_phone"></th>
                                        <th>
                                            <strong>　传真：</strong></th>
                                        <th>
                                            <input maxlength="16" size="14" name="pcontact_fax"></th>
                                    </tr>
                                    <tr>
                                        <th height="32">
                                            <strong>　预计装箱日：</strong>
                                        </th>
                                        <th>
                                            <input size="14" name="expectdate">
                                            <img style="cursor: pointer" height="21" src="images/cal.gif" width="28" align="middle">
                                        </th>
                                        <th>
                                            <strong>　是否做L/C：</strong>
                                        </th>
                                        <th>
                                            <input type="radio" value="1" name="lc">
                                            是
                                            <input type="radio" checked value="2" name="lc">
                                            否</th>
                                        <th>
                                            <strong>　仓管员：</strong>
                                        </th>
                                        <th>
                                            <input size="14" name="shcontact"></th>
                                        <th>
                                            <strong>　电话：</strong>
                                        </th>
                                        <th>
                                            <input maxlength="16" size="14" name="shcontact_phone"></th>
                                    </tr>
                                    <tr>
                                        <th height="32">
                                            <font color="red">　*</font><strong> 箱型和箱量：</strong></th>
                                        <th colspan="3">
                                            20GP：
                                            <input size="2" name="packages" id="txtContainer_20gp" readonly runat="server">
                                            个&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 40GP：
                                            <input size="2" name="packages" id="txtContainer_40gp" readonly runat="server">
                                            个&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 40HQ：
                                            <input size="2" name="packages" id="txtContainer_40hq" readonly runat="server">
                                            个&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </th>
                                        <th>
                                            <strong>　仓库地址：</strong></th>
                                        <th colspan="3">
                                            <input size="32" name="shcontact_add"></th>
                                    </tr>
                                    <tr>
                                        <th colspan="8">
                                            <strong>　备注及其他要求：</strong>
                                            <textarea class="pl10" style="width: 99%" name="remarks" rows="6" cols="128"></textarea></th>
                                    </tr>
                                    <tr>
                                        <th valign="top" colspan="8" height="200">
                                            <strong>　订舱注意事项：</strong>
                                            <ol>
                                                <li>订舱前建议先与我们客服人员确认好价格、舱位及其他事宜；
                                                    <li>订舱委托书是委托订舱、安排运输和出具提单的依据，各项内容必须认真填写。
                                                        <li>货物的各项资料、唛头、件数、货名、数量、尺码等必须填写齐全。
                                                            <li>因订舱委托书填写错误或资料不全引起的货物不能及时出运、运错目的港，提单错误不能结汇不能提货等而产生的一切责任、风险、纠纷、费用等等由托运人承担。
                                                                <li>收到订舱委托书后，若资料不全，我司客服人员会主动和您取得联系确认相关事宜，故请务必填写有效的联系方式。
                                                                    <li>网站上价格信息以CY-CY为主，若有其他需求，可以在其他要求里面填写，也可与我司客服人员联系。 </li>
                                            </ol>
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <p class="mb20">
                            <center>
                                <asp:Button ID="Button1" runat="server" Text="关闭" OnClick="Button1_Click" />
                            </center>
                        </p>
                    </td>
                </tr>

        </TBODY></table>
        </form>        
</body>
</html>