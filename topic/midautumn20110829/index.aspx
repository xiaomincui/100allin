<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="topic_nuclear20110415_index" EnableEventValidation="false" EnableViewState="false" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>迎中秋，送祝福-环球运费网</title>
<meta name="description" content="迎中秋，送祝福" />
<meta name="keywords" content="中秋 祝福" />
<link href="index.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
function set_mid_to(){document.getElementById("mid_to").innerHTML = document.getElementById("TextBox2").value;}
function set_mid_main(){document.getElementById("mid_main").innerHTML = document.getElementById("DropDownList1").options[document.getElementById("DropDownList1").selectedIndex].text;}
function set_mid_from(){document.getElementById("mid_from").innerHTML = document.getElementById("TextBox1").value;}
</script>
</head>
<body>
<form id="form1" runat="server">
<div class="h_box">
	<div class="head">
		<div class="head_top">
		<div class="head_top_left"><a href="/"><img src="images/logo.gif" alt="环球运费网"></a><a href="/" target="_blank">首页</a> | <a href="/fcl/" target="_blank">整箱海运价</a> | <a href="/lcl/" target="_blank">拼箱海运价</a> | <a href="/air/" target="_blank">空运运价</a> | <a href="/company/" target="_blank">公司库</a> | <a href="/bbs/" target="_blank">论坛</a></div>
		<div class="head_top_right"></div>
		</div>
	</div>
</div>
<div class="main">
	<div class="title"><img src="images/title.gif" alt="迎中秋，送祝福" /></div>
	<div class="text_3">
		<div class="text_3_sub">
		<h4>中秋祝福大派送</h4>
		  <div>
		    <table border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="129">您的姓名</td>
                <td width="397">&nbsp;<asp:TextBox ID="TextBox1" runat="server" MaxLength="20"></asp:TextBox></td>
              </tr>
              <tr>
                <td>收件人姓名</td>
                <td>&nbsp;<asp:TextBox ID="TextBox2" runat="server" MaxLength="50"></asp:TextBox></td>
              </tr>
              <tr>
                <td style="height: 24px">收件人Email</td>
                <td style="height: 24px">&nbsp;<asp:TextBox ID="TextBox3" runat="server" MaxLength="50"></asp:TextBox></td>
              </tr>
              <tr>
                <td style="height: 23px">节日寄语</td>
                <td style="height: 23px">&nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="1">举杯仰天遥祝，月圆人圆花好！</asp:ListItem>
                        <asp:ListItem Value="1">无论月圆月缺，我的心如那恒古不变的月光，默默的为你祝福！</asp:ListItem>
                        <asp:ListItem Value="2">月缺时我想你，月圆时我念你！</asp:ListItem>
                        <asp:ListItem Value="3">千里试问平安否？且把思念遥相寄，绵绵爱意与关怀，浓浓情意与祝福！</asp:ListItem>
                        <asp:ListItem Value="4">嫦娥要我给你带个话，今年中秋给她留点月饼渣，她明年会给你大金月饼！</asp:ListItem>
                        <asp:ListItem Value="5">明月本无价，高山皆有情。愿您的生活像十五的月亮一样，圆圆满满！</asp:ListItem>
                        <asp:ListItem Value="6">月有阴晴圆缺，人有悲欢离合。希望从今天起月亮永远是圆的，你永远是快乐的！</asp:ListItem>
                        <asp:ListItem Value="7">月圆年年相似，你我岁岁相盼。那满地的清辉，遍地水银，便是我们互倾的思念！</asp:ListItem>
                        <asp:ListItem Value="8">月是中秋圆，人是我最真，爱你诚挚心，天地可为鉴。</asp:ListItem>
                        <asp:ListItem Value="9">明月清风寄相思！让月儿捎上我的祝福传递给你；让思念化作一缕清风，柔柔的问过你的脸！</asp:ListItem>
                    </asp:DropDownList></td>
              </tr>
              <tr>
                <td height="50">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/send.gif" OnClick="ImageButton1_Click" />
                </td>
                <td>&nbsp;</td>
              </tr>
            </table>
		    <p>
			<table width="505" height="216" border="0" cellpadding="0" cellspacing="0" background="http://www.100allin.com/topic/midautumn20110829/images/midautumn.jpg">
			<tr>
			<td width="187" height="60">			</td>
			<td colspan="2"></td>
			</tr>
			<tr>
			  <td height="46"></td>
			  <td colspan="2"><span id="mid_to"></span>:</td>
			  </tr>
			<tr>
			  <td height="65"></td>
			  <td width="292" valign="top"><span id="mid_main">举杯仰天遥祝，月圆人圆花好！</span></td>
			  <td width="26"></td>
			</tr>
			<tr height="45">
			  <td></td>
			  <td colspan="2"><table border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="120" height="45">&nbsp;</td>
                  <td width="153"><span id="mid_from"></span></td>
                </tr>
              </table>			    
		      </td>
			  </tr>			  			  
			</table>

			</p>
	      </div>
			<div style="margin-top:20px;">
			  <p><strong>节日送礼讲究多</strong></p>
			  <p>
			  ·送礼方法之借花献佛&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 
			  ·送礼方法之暗渡陈仓&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 
			  ·送礼方法之借马引路&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 
			  ·送礼方法之移花接木&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 
			  <br />
			  ·送礼方法之先说是借&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 
			  ·送礼方法之借机生蛋&nbsp;&nbsp;&nbsp;&nbsp;	&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 
			  ·送礼方法之借路搭桥 
			  </p>
			  <div align="right"><a href="http://www.100allin.com/bbs/thread-53283-1.html" target="_blank">[详细]</a></div>
			</div>			
	  </div>
	  <div class="text_3_sub">
		<h4>中秋之趣闻轶事</h4>
		  <div class="text_3_sub_left">
		   <strong>品牌效应>>	       </strong><br />
	       <p>特步：中秋不回家 ,死一般的感觉</p>
	       <p>百事：中秋无极限</p>
	       <p>李宁：中秋偶遇,一切皆有可能</p>
	       <p>汇仁肾宝：中秋想家，你想，我也想！</p>
	       <p>白加黑：去年一个人过中秋，不瞌睡；今年回家过<br />
	         中秋，睡的香.</p>
	       <p>钙中钙：现在的中秋啊，它月饼价格高，一块顶过<br />
	         去五块，难吃！你瞧我，吃一口吐了5天<br />
	         还止不住！</p>
	    </div>
		<div class="text_3_sub_right">
		<strong>字母们也聚在了一起过中秋，它们开始争论：</strong><br />
			<p>O：我长得最像月饼。</p>
			<p>C：我也是月饼，只是被人咬了一口。</p>
			<p>D：我也是月饼，只是被人切了一刀。</p>
			<p>Q：我其实也是月饼，嗯……只是露了点儿馅。</p>
		</div>
		<div class="text_3_sub_total">
		  <p><strong><br />
	      中秋欢乐时刻 &gt;&gt;</strong><br />
	      最近韩国整容风吹到了天庭啊，话说这日嫦娥整容回来，她的宝贝玉兔说到：“哇靠，你怎么整成了李宇春的模样？”</p>
		  <p>“没办法啊，我以前的样子落伍了，现在流行超女，不过估计这个样子玉帝会喜欢”</p>
		  <p>接着就进了宫.. 见了玉帝，嫦娥差点晕倒，因为他身旁正站着“嫦娥”！</p>
		  <p>这时旁边仙子喊到：“大胆贱人，见了玉帝和王母还不下跪。”</p>
		  <p>嫦娥这才明白，大声道：“嫦娥参见....”</p>
		  <p>王母：“嫦娥？你也整容了？不过再怎么整容玉帝也看不上你。”</p>
		  <p>“你整成老娘不要的样子，玉帝就要你了？”</p>
		  <p> 两女人怒目相视，吵了N久未果，突然两人都冲到玉帝身边，一人拉扯住他一只胳膊，让玉帝选择。</p>
		  <p>玉帝觉得身子快被扯散了，忍无可忍，一跳老高，甩开了两个女人：“别争了，我是太白金星！”</p>
		  <p>&nbsp;</p>
		</div>	
		<div class="text_3_sub_total">
	    <img src="images/midautumn_01.jpg" width="904" height="209" />		</div>							
	  </div>
<div class="text_3_sub">
		<h4>100allin用户们的中秋祝福</h4>
			<div>
			  <strong>工作繁忙，未能赶上与家人团圆的你，赶快送上一份祝福：<br />
			  </strong>
             晓零：中秋节快到了，外出工作奔波的我也希望能快点与家人团聚。在这里，我要送家人一个特别的月饼：第一层体贴，第二层关怀，第三层浪漫！同样祝所有的同行朋友中秋节快乐！事业发展顺顺利利！大家赶紧给亲人送一份真诚的祝福吧~<br />
                <asp:Repeater ID="Rptfcl" runat="server">
                    <ItemTemplate>
                         <%#Eval("Realname").ToString()%>：<%#Eval("Data").ToString()%><br />
                    </ItemTemplate>
                </asp:Repeater>
			    <br />
			    <br />
			    <div>
			      <div align="right"><a href="http://www.100allin.com/bbs/thread-57116-1.html" target="_blank">我要发祝福 送问候 &gt;&gt;</a></div>
			    </div>
	  </div>
	  </div>	  
  </div>
	<userbottom100414:userbottom100414 ID="userbottom100414_1" runat="server" />
</div>
<script language="javascript" type="text/javascript">
document.getElementById("mid_to").innerHTML = document.getElementById("TextBox2").value;
document.getElementById("mid_main").innerHTML = document.getElementById("DropDownList1").options[document.getElementById("DropDownList1").selectedIndex].text;
document.getElementById("mid_from").innerHTML = document.getElementById("TextBox1").value;
</script>
</form>
</body>
</html>
