<%@ Page Language="C#" AutoEventWireup="true" CodeFile="regnormal.aspx.cs" Inherits="accounts_regnormal" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="最新运费 海运运费 空运运费  整箱运价 拼箱运价 运价排行 货运代理 货主 运价查询" />
<meta name="description" content="环球运费网是全球最大的专业运价查询平台，主要提供全面、高效、简捷的海空运运价的发布和查询服务。拥有海量货主会员进行运价的查询和对比，更多运价查询信息请点击进入。" />
<title>免费注册普通会员</title>
<link href="css/login.css" rel="stylesheet" type="text/css" />
<script src="js/jquery-1.2.1.pack.js" type="text/javascript"></script>
<script src="js/regnormal.js" type="text/javascript"></script>
<script type="text/javascript">
function checkToList(form,check1)
{
    var count=0;
    for (var i=0;i<form.elements.length;i++)
    {
        var e = form.elements[i];
        if(e.id.split("_")[0]=="chk" && e.checked == 1)
        {
            count = count + 1;
        }
        if(count>2)
        {
            check1.checked = 0;
            alert("选项不能超过2个");
            break;
        }

    }
}

function a()
{
    document.getElementById("Username223").className="";
}

function displaytable(n)
{
    if(document.getElementById("CompanyType").value==2)
    {
          document.getElementById("table1").style.display = "";
    }
    else
    {
          document.getElementById("table1").style.display = "none";
    }
}


function showTip(s,h1,h2){
document.getElementById(s).style.display = "";
document.getElementById(h1).style.display = "none";
document.getElementById(h2).style.display = "none";
}

//性别选择
function radioonblur()
{
    if(document.getElementById("sex_1").checked || document.getElementById("sex_2").checked)
    {
        document.getElementById("divsex").className="standard";
        document.getElementById("divsex").innerHTML="正确";
    }
    else
    {
        document.getElementById("divsex").className="notices";
        document.getElementById("divsex").innerHTML="性别为必填项";
    }
    document.getElementById("divsex").style.display = "";
}

//检查公司所在地
function checkLocus(n,t,f)
{
    var obj1=document.getElementById('ddlcity1');
    var obj2=document.getElementById('ddlcity2');
    if(obj1.options[obj1.selectedIndex].value!=0 && obj2.options[obj2.selectedIndex].value!=0 )
    {
        //alert("对")
        showTip(t,n,f);
    }
    else
    {
        //alert("错")
        showTip(f,n,t);
    }

}

function txtonfocus(s)
{
    //s.className="input01"; 
    //alert(document.getElementById("div"+s.id));
    if(s.id !=="sex_1" && s.id !="sex_2")
    {
        document.getElementById("div"+s.id).style.display = "";
    }
    else
    {
        document.getElementById("divsex").style.display = "";
    }

    
     
    
    if(s.id=="Position")
    {
        divchange("Position",1,"请输入职位名称");
    }
//    else if(s.id == "Phone")
//    {
//        divchange("Phone",1,"请输入电话");
//    }
//    else if(s.id == "Phone2")
//    {
//        divchange("Phone2",1,"请输入您的其他电话");
//    }    
    else if(s.id == "Fax")
    {
        divchange("Fax",1,"请输入传真");
    }
    else if(s.id == "MovePhone")
    {
        divchange("MovePhone",1,"请输入手机号码");
    }
    else if(s.id == "Msn")
    {
        divchange("Msn",1,"请输入MSN");
    }
    else if(s.id == "QQ")
    {
        divchange("QQ",1,"请输入QQ");
    }
    else if(s.id == "sign")
    {
        divchange("sign",1,"请输入弄的个性签名，签名将会显示在论坛中");
    }
    else if(s.id == "Portrait")
    {
        divchange("Portrait",1,"可以为您论坛中的头像上传一张图片(JPG或GIF格式)");
    }
    else if(s.id == "Company")
    {
        divchange("Company",1,"请输入公司名");
    }
    else if(s.id == "Address")
    {
        divchange("Address",1,"请输入公司地址");
    }
    else if(s.id == "PostNumber")
    {
        divchange("PostNumber",1,"请输入邮编");
    }
    else if(s.id == "introduction")
    {
        divchange("introduction",1,"请输入公司简介");
    }
    else if(s.id == "CoPortrait")
    {
        divchange("CoPortrait",1,"上传公司图片");
    }
    else if(s.id == "CompanyType")
    {
        
        divchange("CompanyType",1,"选择公司类型");
    }

}


function txtonblur(s,type)
{
    
    if(s.value.length!=0)
    {
        document.getElementById("div"+s.id).style.display = "";
        s.className="usename";
        if(s.id=="Position")
        {
            if(s.value.length<=20)
            {
                divchange("Position",2,"正确");
            }
            else
            {
                divchange("Position",3,"您填写的信息字数太多");
            }
        }
        //else if(s.id == "Phone" || s.id == "Phone2" || s.id == "Fax" || s.id == "MovePhone" || s.id == "Msn" || s.id == "QQ" || s.id == "Company" || s.id == "Address" || s.id == "PostNumber")
        else if(s.id == "Fax" || s.id == "MovePhone" || s.id == "Msn" || s.id == "QQ" || s.id == "Company" || s.id == "Address" || s.id == "PostNumber")
        {
            if(s.value.length<=50)
            {
                divchange(s.id,2,"正确");
            }
            else
            {
                divchange(s.id,3,"您填写的信息字数太多");
            }
        }
        else if(s.id == "sign")
        {
            if(s.value.length<=200)
            {
                divchange(s.id,2,"正确");
            }
            else
            {
                divchange(s.id,3,"您填写的信息字数太多");
            }
        }
        else if(s.id == "introduction")
        {
            if(s.value.length<=800)
            {
                divchange(s.id,2,"正确");
            }
            else
            {
                divchange(s.id,3,"您填写的信息字数太多");
            }
        }
        else if(s.id == "Portrait" || s.id == "CoPortrait")
        {
            var value = s.value;
            var word = value.substring(value.length-3,value.length);
            if(word == "jpg" || word=="gif")
            {
                divchange(s.id,2,"正确");
            }
            else
            {
                divchange(s.id,3,"图片格式错误");
            }
        }
        else if(s.id=="CompanyType")
        {
            if(s.value==0)
            {
                document.getElementById("div"+s.id).style.display = "none";
            }
            else
            {
                document.getElementById("divCompanyType").className="standard";
                document.getElementById("divCompanyType").innerHTML="正确";
                //divchange(s.id,2,"正确");
            }
        }
    }
    else
    {
        
        if(type==1)
        {
            document.getElementById("div"+s.id).style.display = "";
            divchange(s.id,3,"必填");
        }
        else
        {
            document.getElementById("div"+s.id).className="standard";
            document.getElementById("div"+s.id).style.display = "none";
        }
    }
    
}

//改变文字和样式,s为控件id，c为状态，t为替换文本
//c:1为提示，2为正确，3为错误
function divchange(s,c,t)
{
    if(document.getElementById("div"+s).tagName=="DIV")
    {
        if(c==1)
        {
            document.getElementById(s).className="usename";
            document.getElementById("div"+s).className="common";
            
        }
        else if (c==2)
        {
            if(s!="introduction")
            {
            document.getElementById(s).className="input01";
            }
            document.getElementById("div"+s).className="standard";
        }
        else
        {
            if(s!="introduction")
            {
            document.getElementById(s).className="input02";
            }
            document.getElementById("div"+s).className="notices";
            
        }
        document.getElementById("div"+s).innerHTML=t;
    }
    else
    {
        alert(document.getElementById(s).tagName);
    }
    
}



function checkAll()
{
    radioonblur();
    txtonblur(document.getElementById("CompanyType"),1);
    txtonblur(document.getElementById("Position"));
    //txtonblur(document.getElementById("Phone"),1);
    txtonblur(document.getElementById("Fax"));
    txtonblur(document.getElementById("MovePhone"));
    txtonblur(document.getElementById("Msn"));
    txtonblur(document.getElementById("QQ"));
    txtonblur(document.getElementById("sign"));
    //txtonblur(document.getElementById("Company"),1);
    
    txtonblur(document.getElementById("Address"));
    txtonblur(document.getElementById("PostNumber"));
    txtonblur(document.getElementById("introduction"));
    //txtonblur(document.getElementById("CoPortrait"));
    checkLocus('tipLocusNormal','tipLocusTrue','tipLocusFalse');
    
    if(document.getElementById("divCompanyType").className!="standard")
    {
        document.getElementById("CompanyType").focus();
    }
    else if(document.getElementById("divCompanyType").style.display!="")
    {
        document.getElementById("CompanyType").focus();
    }
    else if(document.getElementById("tipLocusTrue").style.display!="")
    {
        document.getElementById("ddlcity1").focus();
    }
    else if(document.getElementById("divsex").className!="standard")
    {
        document.getElementById("sex_1").focus();
    }
    else if(document.getElementById("divsex").style.display!="")
    {
        document.getElementById("divsex").className="notices";
        document.getElementById("divsex").innerHTML="必填";
        document.getElementById("sex_1").focus();
    }
    else if(document.getElementById("divPosition").className!="standard")
    {
        document.getElementById("Position").focus();
    }
//    else if(document.getElementById("divPosition").style.display!="")
//    {
//        document.getElementById("Position").focus();
//        document.getElementById("divPosition").style.display="";
//        divchange("Position",3,"必填");
//    }
//    else if(document.getElementById("divPhone").className!="standard")
//    {
//        document.getElementById("Phone").focus();
//    }
    
    else if(document.getElementById("divFax").className!="standard")
    {
        document.getElementById("Fax").focus();
    }
    else if(document.getElementById("divMovePhone").className!="standard")
    {
        document.getElementById("MovePhone").focus();
    }
    else if(document.getElementById("divMsn").className!="standard")
    {
        document.getElementById("Msn").focus();
    }
    else if(document.getElementById("divQQ").className!="standard")
    {
        document.getElementById("QQ").focus();
    }
    else if(document.getElementById("divsign").className!="standard")
    {
        document.getElementById("sign").focus();
    }
    else if(document.getElementById("divPortrait").className!="standard")
    {
        document.getElementById("Portrait").focus();
    }
//    else if(document.getElementById("divCompany").className!="standard")
//    {
//        document.getElementById("Company").focus();
//    }
//    else if(document.getElementById("divCompany").style.display!="")
//    {
//        document.getElementById("Company").focus();
//    }
    
    
    else if(document.getElementById("divAddress").className!="standard")
    {
        document.getElementById("Address").focus();
    }
    else if(document.getElementById("divPostNumber").className!="standard")
    {
        document.getElementById("PostNumber").focus();
    }
    else if(document.getElementById("divintroduction").className!="standard")
    {
        document.getElementById("introduction").focus();
    }
//    else if(document.getElementById("divCoPortrait").className!="standard")
//    {
//        document.getElementById("CoPortrait").focus();
//    }
    else
    {
    //alert("asdf");
        document.getElementById("Button12").click();
    }
       
}



function selectAdd()
{



	if(document.getElementById("ListBox1").selectedIndex!=-1)
	{
		//alert(document.getElementById("ListBox1").options[document.getElementById("ListBox1").selectedIndex].value);
		var varItem = new Option(document.getElementById("ListBox1").options[document.getElementById("ListBox1").selectedIndex].text, document.getElementById("ListBox1").options[document.getElementById("ListBox1").selectedIndex].value);
		
		
		document.getElementById("selshiper").options.add(varItem);
		document.getElementById("ListBox1").options.remove(document.getElementById("ListBox1").selectedIndex);        
		
	}
	Hidtypes()
}

function selectDelete()
{
	if(document.getElementById("selshiper").selectedIndex!=-1)
	{
		//alert(document.getElementById("ListBox1").options[document.getElementById("ListBox1").selectedIndex].value);
		var varItem = new Option(document.getElementById("selshiper").options[document.getElementById("selshiper").selectedIndex].text, document.getElementById("ListBox1").options[document.getElementById("selshiper").selectedIndex].value);
		
		
		document.getElementById("ListBox1").options.add(varItem);
		document.getElementById("selshiper").options.remove(document.getElementById("selshiper").selectedIndex);        
		
	}
	Hidtypes()
}

function selectClear()
{
	document.getElementById("selshiper").options.length = 0;
	document.getElementById("ListBox1").options.length = 0;
	var selectText = new Array("马士基(MSK)","长荣(EMC)","中海(CSCL)","达飞(CMA)","韩进(HANJIN)","万海(WANHAI)","地中海(MSC)","太平(PIL)","东方海外(OOCL)","中远(COSCO)","以星(ZIM)","阳明(YML)");
	var selectValue = new Array("马士基(MSK)","长荣(EMC)","中海(CSCL)","达飞(CMA)","韩进(HANJIN)","万海(WANHAI)","地中海(MSC)","太平(PIL)","东方海外(OOCL)","中远(COSCO)","以星(ZIM)","阳明(YML)");
	for(var i=0;i<selectText.length;i++)
	{
		var varItem = new Option(selectText[i],selectValue[i]);
		document.getElementById("ListBox1").options.add(varItem);
	}
	Hidtypes()
}

function Hidtypes()
{
    document.getElementById("Hidtypes").value="";
    for(var i=0;i<document.getElementById("selshiper").options.length;i++)
    {
        document.getElementById("Hidtypes").value+=document.getElementById("selshiper").options(i).value+"|";
    }
}

</script>



</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div class="main_container"><!--页面主体开始-->
  <!--顶部登陆结束-->
<div class="header"><!--头部LOGO开始-->	
			<div id="logo">
				<a href="/" target="_blank"><img src="images/logo.gif" alt="环球运费网" border="0" width="340" height="75" /></a>			</div>
			<ul><li><a title="欢迎使用在线客服" href="#" onclick="document.getElementById('aliserv').click();">在线客服</a> | <a href="/" target="_blank">返回首页</a><br />
			  如遇注册问题请拨打：<span class="red">400-888-9256</span></li>
			</ul>
  </div><!--头部LOGO结束-->
  <div class="menu"><!--导航开始-->
			<h1><span style="color:#29395b;">注册步骤</span>：<span><img src="images/1_1.jpg" width="12" height="12" />注册初级会员</span> >    <img src="images/2.JPG" width="12" height="12" /><span class="orange"><strong>注册普通会员</strong></span> >    <img src="images/3_3.JPG" width="12" height="12" />审核注册资料 </h1>
  <span class="right_tn"><a>*</a> 为必填项</span></div>
		<!--导航结束-->
		<div class="main_content"><!--中部开始-->
		  <div class="login_box">
		  	<div class="lg">
				<%--<div class="zc2" style="display:inherit;" id="cong">
					<div class="zc2_top"><p><span class="tt">恭喜您:<b style="color:#3399FF;"><asp:Literal ID="ltrName" runat="server">尊敬的网站访客</asp:Literal></b>,您已注册成为初级会员!</span>
                      <br />
                  现在您已是初级会员，您可以无限制浏览环球运费网信息、在论坛发帖回帖！<br />
				<a href="/">>> 不想申请普通会员，立即去体验环球运费网的无障碍浏览</a></p>
				  </div>
				  	<div class="zc2_bt">
				  	  <p><span class="tt"><b style="color:red;">继续免费申请普通会员,享有更多服务!&nbsp;--&nbsp;<a style="color:#FF0000;" href="javascript:;" id="getnormal">马上申请</a></b></span>
                      <br />
                      ·拥有公司独立商铺页面，获得更多宣传机会；<br />
                      ·无限制发布各类信息（运价、货盘、论坛帖子等）；<br />
                      ·初级会员的所有服务；<br />
				  	  </p>
			  	  </div>
				</div>--%>
				<div class="zc2">
					<div class="zc2_top" style="height:150px;"><p><span class="tt" style="line-height:25px;">您好！<b style="color:#3399FF;"><asp:Literal ID="ltrName" runat="server"></asp:Literal></b>,系统正在审核您的账户</span>
                      <br /> 
			若注册资料中包含色情, 淫秽, 反动和其它违法内容，注册将不予通过！
			<br />
					</p>
				  </div>
				  	<div class="zc2_bt">
				  	  <p><span class="tt"><b style="color:red;">继续填写完整公司信息，若审核通过，您将升级成为普通会员！<br />普通会员可以：</b></span>
                      <br />
                      ·&nbsp;拥有公司独立商铺网页，更多宣传机会<br />
·&nbsp;初级会员的所有服务<br />
                      
<img src="images/jt3.gif" width="8" height="8" />&nbsp;<span class="orange"><strong><asp:Literal
    ID="Literal2" runat="server"></asp:Literal></strong></span><span style=" background-image:none;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="orange"><strong><asp:Literal
    ID="Literal1" runat="server"></asp:Literal></strong></span></span><br />
				  	  </p>
			  	  </div>
				</div>
				
				
				<h3><img src="images/jt.gif" />需补充信息</h3>
				
				<div class="zc1">
					<div class="zc1_left"><table width="100%" height="820" border="0" align="left" cellpadding="0" cellspacing="1">
	  <tr>
		<td height="38" colspan="3" align="left" style="background:url(images/login/lx.GIF) no-repeat center;">&nbsp;</td>
		</tr>
	  <tr>
		<td width="100" height="38" align="right"><span class="red">*</span>&nbsp;<span class="zc_tn">公司类型</span>：</td>
		<td width="250">
		<select name="CompanyType"  id="CompanyType" runat="server" style="width:100px" onfocus="txtonfocus(this)" onblur="txtonblur(this)" onchange="displaytable()">
					  <option value="">请选择</option>
                      <option value="1">货主</option>
                      <option value="2">货代</option>
                      <option value="3">船东</option>
                      <option value="5">船代</option>
                      <option value="6">快递</option>
                      <option value="7">场站</option>
                      <option value="8">仓储</option>
                      <option value="9">集卡</option>
                      <option value="10">报关</option>
                      <option value="4">其他</option>
                  </select></td>
		<td><div id="divCompanyType" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
		</tr>
	  <tr>
		<td height="38" align="right"><span class="red">*</span>&nbsp;<span class="zc_tn">公司所在地</span>：</td>
		<td><asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                        <div style="float:left;">
                        <asp:DropDownList ID="ddlcity1" runat="server" AutoPostBack="True" Width="100px" OnSelectedIndexChanged="ddlcity1_SelectedIndexChanged"  >
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlcity2" runat="server" AutoPostBack="True" Width="100px" OnSelectedIndexChanged="ddlcity2_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlcity3" runat="server" AutoPostBack="True" Width="100px" Visible="False">
                        </asp:DropDownList>
                        </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>    
                    </td>
		<td>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
		    <div class="common" id="tipLocusNormal" style="display:none;" runat="server">请填写正确有效的公司所在地。</div>
            <div class="standard" id="tipLocusTrue"  style="display:none;" runat="server">
                正确</div>
            <div class="notices" id="tipLocusFalse" style="display:none;" runat="server">必须填写完整的公司所在地。</div> 
                        
                        </ContentTemplate>
                
             </asp:UpdatePanel>
		</td>
		</tr>
	  <tr>
		<td height="38" align="right"><span class="zc_tn">联系地址</span>：</td>
		<td><input id="Address" name="Address" type="text" class="usename" size="34" runat="server"  onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
		<td><div id="divAddress" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
		</tr>
	  <tr>
		<td height="38" align="right"><span class="zc_tn">邮政编码</span>：</td>
		<td><input id="PostNumber" name="PostNumber" type="text" class="usename" size="34" runat="server"  onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
		<td><div id="divPostNumber" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
		</tr>
	  <tr>
		<td height="38" align="right"><span class="red">*</span>&nbsp;<span class="zc_tn">性别</span>：</td>
		<td class="14n">
		&nbsp;<input id="sex_1" type="radio" name="radiobutton" value="radiobutton" onfocus="txtonfocus(this)" onblur="radioonblur()" runat="server" />
            男士
			<input id="sex_2" type="radio" name="radiobutton" value="radiobutton" onfocus="txtonfocus(this)" onblur="radioonblur()" runat="server" />
	女士
		</td>
		<td><div id="divsex" style=" display:none" class="standard">正确 </div></td>
		</tr>
	  <tr>
		<td height="38" align="right">&nbsp;<span class="zc_tn">您的职位</span>：</td>
		<td><input id="Position" name="Position" type="text" class="usename" value="" size="34" runat="server" onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
		<td><div id="divPosition" style=" display:none" class="standard">请输入职位名称</div></td>
		</tr>
	  <tr>
        <td height="38" align="right">&nbsp;<span class="zc_tn">传真</span>：</td>
	    <td><input id="Fax" name="Fax" type="text" class="usename" size="34" runat="server" onfocus="txtonfocus(this)" onblur="txtonblur(this)"  /></td>
	    <td><div id="divFax" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
	    </tr>
		<tr>
        <td height="38" align="right">&nbsp;<span class="zc_tn">手机</span>：</td>
	    <td><input id="MovePhone" name="MovePhone" type="text" class="usename" size="34" runat="server" onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
	    <td><div id="divMovePhone" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
	    </tr><tr>
        <td height="38" align="right">&nbsp;<span class="zc_tn">MSN</span>：</td>
	    <td><input id="Msn" name="Msn" type="text" class="usename" size="34" runat="server" onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
	    <td><div id="divMsn" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
	    </tr>
		<tr>
        <td height="38" align="right">&nbsp;<span class="zc_tn">QQ</span>：</td>
	    <td><input id="QQ" name="QQ" type="text" class="usename" size="34" runat="server" onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
	    <td><div id="divQQ" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
	    </tr>
	  <tr>
		<td height="38" align="right"><span class="zc_tn">个性签名</span>：</td>
		<td><input id="sign" name="sign" type="text" class="usename" size="34" runat="server"  onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
		<td class="gray"><div id="divsign" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
		</tr>
		<tr>
		<td height="38" align="right">&nbsp;</td>
		<td colspan="2" class="gray">例：上海至黑海，欧地，非洲“庄家”黄小姐电话：021-51086987</td>
		</tr>
		  <tr>
		<td height="38" align="right"><span class="zc_tn">头像</span>：</td>
		<td height="38" align="left"><asp:FileUpload ID="Portrait" runat="server" onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
		<td height="38" align="left" class="gray"><div id="divPortrait" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
		  </tr>
		  <tr>
		<td height="38" align="right">&nbsp;</td>
		<td colspan="2"><span class="gray">尺寸：130*130,大小400K以下 <%--<a href="#">去头像库里挑一个</a>--%></span></td>
		</tr>
		  <tr>
		    <td height="38" align="right"><span class="zc_tn"><span class="red">*</span>&nbsp;公司简介</span>：</td>
		    <td height="38" colspan="2" align="left">
		    <%--<textarea id="introduction" name="introduction" cols="27" rows="5" runat="server"  onfocus="txtonfocus(this)" onblur="txtonblur(this)"></textarea>--%>
		    <textarea name="Username2253" cols="50" rows="8" class="usename" id="introduction" runat="server" onfocus="txtonfocus(this)" onblur="txtonblur(this)"></textarea></td>
		    </tr>
			<tr>
		    <td height="38" align="right">&nbsp;</td>
		    <td height="38" align="left"><div id="divintroduction" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
		    <td height="38" align="center"></td>
		    </tr>
		  <tr>
		    <td height="38" colspan="3" align="right" style="background:url(images/login/gs.GIF) no-repeat center;">&nbsp;</td>
		    </tr>
		    <tr>
		    <td height="38" colspan="3" align="right" style="background:url(images/login/gs.GIF) no-repeat center;">
		  <table id="table1" width="100%" height="" border="0" align="left" cellpadding="0" cellspacing="1" style="display:none">
		    <tr>
    <td height="38" align="right"  width="22%"><span class="zc_tn">主要服务</span>：</td>
    <td height="38" colspan="2" align="left">
    <asp:CheckBox ID="checkall" runat="server" />全部
      <asp:CheckBox ID="checkfcl" runat="server" />整箱
      <asp:CheckBox ID="checklcl" runat="server" />拼箱
      <asp:CheckBox ID="checkair" runat="server" />空运
      
      
      </td>
    </tr>
              <tr>
                  <td align="right" height="28" style="width: 133px">
                      <span class="zc_tn">特种优势</span>：</td>
                  <td align="left" colspan="2">
                  <asp:CheckBox ID="checkcold" runat="server" />冷冻冷藏
                  <asp:CheckBox ID="checkdangerous" runat="server" />危险品
                  <asp:CheckBox ID="checktank" runat="server" />罐箱
                  <asp:CheckBox ID="checkparticular" runat="server" />其他特种柜
                  <asp:CheckBox ID="checkBULK" runat="server" />散杂货船
                  <asp:CheckBox ID="checkinput" runat="server" />进口
                  </td>
              </tr>
		    
		    
		  <tr>
    <td height="28" align="right" style="width: 133px"><span class="zc_tn">优势航线</span>：</td>
    
    
    <td width="43%" align="left">海运：
    
    </td>
    <td width="43%" align="left">空运：
    
    </td>
  </tr>
  
  
  <tr>
    <td height="28" align="left" style="width: 133px">&nbsp;</td> 
    <td align="left"><input id="chk_ship_Europe" type="checkbox" name="checkbox52" value="欧地" runat="server" ReadOnly="true" onclick="checkToList(this.form,this)"  />欧地
      <input id="chk_ship_SOUTH_AMERICA" type="checkbox" name="checkbox53" value="中南美" runat="server" ReadOnly="true" onclick="checkToList(this.form,this)" />中南美
<input id="chk_ship_Australia" type="checkbox" name="checkbox522" value="澳洲" runat="server" ReadOnly="true" onclick="checkToList(this.form,this)" />澳洲
</td>
    <td align="left"><input id="chk_air_North_America" type="checkbox" name="checkbox52" value="北美" runat="server" ReadOnly="true" onclick="checkToList(this.form,this)" />北美
      <input id="chk_air_Europe" type="checkbox" name="checkbox53" value="欧洲" runat="server" ReadOnly="true" onclick="checkToList(this.form,this)" />欧洲
<input id="chk_air_Asia" type="checkbox" name="checkbox523" value="亚洲" runat="server" ReadOnly="true" onclick="checkToList(this.form,this)" />亚洲</td>
  </tr>
  
  
  <tr>
    <td height="28" align="left" style="width: 133px">&nbsp;</td>
    <td align="left"><input id="chk_ship_Caribbean" type="checkbox" name="checkbox523" value="美加" runat="server" ReadOnly="true" onclick="checkToList(this.form,this)" />美加
  <input id="chk_ship_Red_Sea" type="checkbox" name="checkbox527" value="红海" runat="server" ReadOnly="true" onclick="checkToList(this.form,this)" />红海
<input id="chk_ship_Japan_Korea" type="checkbox" name="checkbox525" value="日韩" runat="server" ReadOnly="true" onclick="checkToList(this.form,this)" />日韩</td>
    <td align="left"><input id="chk_air_Africa" type="checkbox" name="checkbox524" value="非洲" runat="server" ReadOnly="true" onclick="checkToList(this.form,this)" />非洲
  <input id="chk_air_poncho" type="checkbox" name="checkbox522" value="南美" runat="server" ReadOnly="true" onclick="checkToList(this.form,this)" />南美
<input id="chk_air_Australia" type="checkbox" name="checkbox525" value="澳洲" runat="server" ReadOnly="true" onclick="checkToList(this.form,this)" />澳洲
</td>
  </tr>
  
  
  <tr>
    <td height="28" align="left" style="width: 133px">&nbsp;</td>
    <td align="left"><input id="chk_ship_CIMEX" type="checkbox" name="checkbox526" value="中东印巴" runat="server" ReadOnly="true" onclick="checkToList(this.form,this)" />中东印巴
  <input id="chk_ship_Africa" type="checkbox" name="checkbox528" value="非洲" runat="server" ReadOnly="true" onclick="checkToList(this.form,this)" />非洲
<input id="chk_ship_offing" type="checkbox" name="checkbox524" value="近洋" runat="server" ReadOnly="true" onclick="checkToList(this.form,this)" />近洋
</td>
    <td align="left"><input id="chk_air_internal" type="checkbox" name="checkbox528" value="国内" onclick="checkToList(this.form,this)" runat="server" ReadOnly="true" />国内</td>
  </tr>
		    
		    
		    
		  <tr>
		    <td height="38" align="right" style="width: 133px"><%--<span class="red">*</span>--%>&nbsp;<span class="zc_tn">优势船公司</span>：</td>
		    <td height="38" align="left">
		    
		    <div style=" float:left">
        <select size="4" name="ListBox1" id="ListBox1" style="width:109px;" runat="server">
		<option value="马士基(MSK)">马士基(MSK)</option>
		<option value="长荣(EMC)">长荣(EMC)</option>
		<option value="中海(CSCL)">中海(CSCL)</option>
		<option value="达飞(CMA)">达飞(CMA)</option>
		<option value="韩进(HANJIN)">韩进(HANJIN)</option>
		<option value="万海(WANHAI)">万海(WANHAI)</option>
		<option value="地中海(MSC)">地中海(MSC)</option>
		<option value="太平(PIL)">太平(PIL)</option>
		<option value="东方海外(OOCL)">东方海外(OOCL)</option>
		<option value="中远(COSCO)">中远(COSCO)</option>
		<option value="以星(ZIM)">以星(ZIM)</option>
		<option value="阳明(YML)">阳明(YML)</option>

	</select>
        </div>
        <div style=" float:left; height: 55px;">
            <input type="button" name="Button1" value="添加" id="Button2" onClick="selectAdd()" /><br />
            <input type="button" name="Button2" value="删除" id="Button3" onClick="selectDelete()" /><br />
            <input type="button" name="Button3" value="清空" id="Button4" onClick="selectClear()"/>
        </div>
        <div style=" float:left; ">
        <select size="4" name="ListBox2" id="selshiper" style="width:109px;" runat="server">

	</select>
        </div>
        <input id="Hidden1" runat="server" type="hidden" value="马士基(MSK)|长荣(EMC)|中海(CSCL)|达飞(CMA)|韩进(HANJIN)|万海(WANHAI)|地中海(MSC)|太平(PIL)|东方海外(OOCL)|中远(COSCO)|以星(ZIM)|阳明(YML)" />
        <input id="Hidtypes" runat="server"  type="hidden" />
                                        
        &nbsp;
		    </td>
		    <td height="38" align="center"></td>
		    </tr>
		  <tr>
		    <td height="38" align="right" style="width: 133px"><span class="zc_tn">其他</span>：</td>
		    <td height="38" align="left"><asp:TextBox ID="othershipper" runat="server" Width="254px"></asp:TextBox></td>
		    <td height="38" align="center"></td>
		    </tr>
		              
		   </table>
		   </td>
		   </tr>
		  <tr>
		    <td height="38" align="right">&nbsp;</td>
		    <td height="38" align="left"><input onclick="checkAll();" name="Button1" id="Button11" value="提 交" type="button" />
		    <asp:Button ID="Button12" runat="server" Text="Button" style="display:none"  OnClick="Button2_Click" /></td>
		    <td height="38" align="center"></td>
		    </tr>
	</table>
					</div>
					<%--<div class="booking_mid" style="height:255px; background:url(images/login/book_top4.jpg) no-repeat center;">
						<ul>
						  <marquee direction="up" onMouseOver="this.stop()" onMouseOut="this.start()"><li style="background: url(images/login/yuan2.gif) no-repeat 12px;"><strong>1</strong>&nbsp;&nbsp;<a href="#">享受实价订舱，保证运费不被高收</a></li>
						  <li style="background: url(images/login/yuan2.gif) no-repeat 12px;"><strong>2</strong>&nbsp;&nbsp;<a href="#">享受实价订舱，保证运费不被高收</a></li>
						  <li style="background: url(images/login/yuan2.gif) no-repeat 12px;"><strong>3</strong>&nbsp;&nbsp;<a href="#">享受实价订舱，保证运费不被高收</a></li>
						  <li style="background: url(images/login/yuan2.gif) no-repeat 12px;"><strong>4</strong>&nbsp;&nbsp;<a href="#">享受实价订舱，保证运费不被高收</a></li>
						  <li style="background: url(images/login/yuan2.gif) no-repeat 12px;"><strong>5</strong>&nbsp;&nbsp;<a href="#">享受实价订舱，保证运费不被高收</a></li></marquee>
					    </ul>
						<a href="http://www.100allin.com/topic/order20091104/tryalready.aspx" target="_blank" style="margin:8px 0 0 10px; float:left;"><img src="images/book_bt.jpg" border="0" /></a><br />
						<br />
			      </div>--%>
			  </div>
				
				<%--
				
				<div class="zc1">
					<div class="zc1_left"><table width="100%" height="820" border="0" align="left" cellpadding="0" cellspacing="1">
	  <tr>
		<td height="38" colspan="3" align="left" style="background:url(images/lx.GIF) no-repeat center;">&nbsp;</td>
		</tr>
	  <tr>
		<td width="22%" height="38" align="right"><span class="red">*</span>&nbsp;<span class="zc_tn">性别</span>：</td>
		<td width="38%">
            &nbsp;<input id="sex_1" type="radio" name="radiobutton" value="radiobutton" onfocus="txtonfocus(this)" onblur="radioonblur()" runat="server" />
            男士
			<input id="sex_2" type="radio" name="radiobutton" value="radiobutton" onfocus="txtonfocus(this)" onblur="radioonblur()" runat="server" />
	女士</td>
		<td width="40%"><div id="divsex" style=" display:none" class="standard">正确 </div>
		</td>
		</tr>
	  <tr>
		<td height="38" align="right"><span class="red">*</span>&nbsp;<span class="zc_tn">您的职位</span>：</td>
		<td><input id="Position" name="Position" type="text" class="usename" value="" size="34" runat="server" onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
		<td><div id="divPosition" style=" display:none" class="standard">请输入职位名称</div></td>
		</tr>
	  <%--<tr>
		<td height="38" align="right"><span class="red">*</span>&nbsp;<span class="zc_tn">电话</span>：</td>
		<td><input id="Phone" name="Phone" type="text" class="usename" value="" size="34" runat="server" onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
		<td><div id="divPhone" style=" display:none" class="standard">请输入电话 </div></td>
		</tr>
      <tr>
		<td height="38" align="right"><span class="zc_tn">电话2</span>：</td>
		<td><input id="Phone2" name="Phone" type="text" class="usename" value="" size="34" runat="server" onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
		<td><div id="divPhone2" style=" display:none" class="standard">请输入您的其他电话 </div></td>
		</tr>
	  <tr>
		<td height="38" align="right"><span class="zc_tn">传真</span>：</td>
		<td><input id="Fax" name="Fax" type="text" class="usename" size="34" runat="server" onfocus="txtonfocus(this)" onblur="txtonblur(this)"  /></td>
		<td><div id="divFax" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
		</tr>
	  <tr>
		<td height="38" align="right"><span class="zc_tn">手机</span>：</td>
		<td><input id="MovePhone" name="MovePhone" type="text" class="usename" size="34" runat="server" onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
		<td><div id="divMovePhone" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
		</tr>
	  <tr>
		<td height="38" align="right">&nbsp;<span class="zc_tn">MSN</span>：</td>
		<td><input id="Msn" name="Msn" type="text" class="usename" size="34" runat="server" onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
		<td><div id="divMsn" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
		</tr>
	  <tr>
		<td height="38" align="right"><span class="zc_tn">QQ</span>：</td>
		<td><input id="QQ" name="QQ" type="text" class="usename" size="34" runat="server" onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
		<td><div id="divQQ" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
		</tr>
	  <tr>
		<td height="38" align="right"><span class="zc_tn">个性签名</span>：</td>
		<td><input id="sign" name="sign" type="text" class="usename" size="34" runat="server"  onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
		<td><div id="divsign" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
		</tr>
		  <tr>
		<td height="38" align="right"><span class="zc_tn">头像</span>：</td>
		<td height="38" align="left">
            <asp:FileUpload ID="Portrait" runat="server" onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
		<td height="38" align="center"><div id="divPortrait" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
		  </tr>
                        <tr>
                            <td align="right" height="38">
                            </td>
                            <td align="left" height="38">
                                <img id="imghead" runat="server" alt="展示论坛头像" height="70" onerror="this.style.display = 'none'"
                                    src="/images/shops/gs.gif" width="70" /></td>
                            <td align="center" height="38">
                            </td>
                        </tr>
		  <tr>
		    <td height="38" align="right">&nbsp;</td>
		    <td height="38" align="left">&nbsp;</td>
		    <td height="38" align="center"></td>
		    </tr>
		  <tr>
		    <td height="38" colspan="3" align="right" style="background:url(images/gs.GIF) no-repeat center;">&nbsp;</td>
		    </tr>
		  <tr>
		    <td height="38" align="right"><span class="red">*</span>&nbsp;<span class="zc_tn">公司名称</span>：</td>
		    <td height="38" align="left"><input name="Company" type="text" class="usename" id="Company" size="34" runat="server"  onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
		    <td height="38" align="center"><div id="divCompany" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
		    </tr>
		  <tr>
		    <td height="38" align="right"><span class="red">*</span>&nbsp;<span class="zc_tn">公司类型</span>：</td>
		    <td height="38" align="left">
		    
		     <select name="CompanyType"  id="CompanyType" runat="server" style="width:100px" onfocus="txtonfocus(this)" onblur="txtonblur(this)">
					  <option value="0">请选择</option>
                      <option value="1">货主</option>
                      <option value="2">货代</option>
                      <option value="3">船东</option>
                      <option value="5">船代</option>
                      <option value="6">快递</option>
                      <option value="7">场站</option>
                      <option value="8">仓储</option>
                      <option value="9">集卡</option>
                      <option value="10">报关</option>
                      <option value="4">其他</option>
                  </select>	    
		      
		      
		      </td>
		    <td height="38" align="center"><div id="divCompanyType" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
		    </tr>
		    
		    
		  <tr>
		    <td height="38" align="right"><span class="red">*</span>&nbsp;<span class="zc_tn">公司所在地</span>：</td>
		    <td height="38" align="left">
		                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                        <div style="float:left;">
                        <asp:DropDownList ID="ddlcity1" runat="server" AutoPostBack="True" Width="100px" OnSelectedIndexChanged="ddlcity1_SelectedIndexChanged"  >
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlcity2" runat="server" AutoPostBack="True" Width="100px" OnSelectedIndexChanged="ddlcity2_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlcity3" runat="server" AutoPostBack="True" Width="100px" Visible="False">
                        </asp:DropDownList>
                        </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>    
		    
		    </td>
		    <td height="38" align="center">
		    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
		    <div class="common" id="tipLocusNormal" style="display:none;" runat="server">请填写正确有效的公司所在地。</div>
            <div class="standard" id="tipLocusTrue"  style="display:none;" runat="server">
                正确</div>
            <div class="notices" id="tipLocusFalse" style="display:none;" runat="server">必须填写完整的公司所在地。</div> 
                        
                        </ContentTemplate>
                
             </asp:UpdatePanel>
		    </td>
		    
		    </tr>
		    
		    
		    
		    
		  <tr>
		    <td height="38" align="right"><span class="zc_tn">联系地址</span>：</td>
		    <td height="38" align="left"><input id="Address" name="Address" type="text" class="usename" size="34" runat="server"  onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
		    <td height="38" align="center"><div id="divAddress" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
		    </tr>
		  <tr>
		    <td height="38" align="right"><span class="zc_tn">邮政编码</span>：</td>
		    <td height="38" align="left"><input id="PostNumber" name="PostNumber" type="text" class="usename" size="34" runat="server"  onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
		    <td height="38" align="center"><div id="divPostNumber" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
		    </tr>
		  <tr>
		    <td height="38" align="right"><span class="zc_tn">公司简介</span>：</td>
		    <td height="38" align="left"><textarea id="introduction" name="introduction" cols="27" rows="5" runat="server"  onfocus="txtonfocus(this)" onblur="txtonblur(this)"></textarea></td>
		    <td height="38" align="center"><div id="divintroduction" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
		    </tr>
		  <tr>
		    <td height="38" align="right"><span class="zc_tn">公司图片</span>：</td>
		    <td height="38" align="left">
                <asp:FileUpload ID="CoPortrait" runat="server" onfocus="txtonfocus(this)" onblur="txtonblur(this)" /></td>
		    <td height="38" align="center"><div id="divCoPortrait" style=" display:none" class="standard">请再输入一遍您上面填写的密码 </div></td>
		    </tr>
                        <tr>
                            <td align="right" height="38">
                            </td>
                            <td align="left" height="38">
                            <img src="/images/shops/gs.gif" onerror="this.style.display = 'none'"  alt="展示公司图片" id="imgcompanyhead" runat="server" width="70" height="70" /> 
                            </td>
                            <td align="center" height="38">
                            </td>
                        </tr>
                        
                        
                        
                        
                        
               <tr>
    <td height="28" align="left"><strong>主要服务</strong>：</td>
    <td height="28" colspan="2" align="left">
    <asp:CheckBox ID="checkall" runat="server" />全部
      <asp:CheckBox ID="checkfcl" runat="server" />整箱
      <asp:CheckBox ID="checklcl" runat="server" />拼箱
      <asp:CheckBox ID="checkair" runat="server" />空运</td>
    </tr>
	  <tr>
    <td height="10" colspan="3" align="left">&nbsp;</td>
    </tr>
  <tr>
    <td width="14%" height="28" align="left"><strong>优势航线</strong>：</td>
    
    
    <td width="43%" align="left">海运：
    
    </td>
    <td width="43%" align="left">空运：
    
    </td>
  </tr>
  <tr>
    <td height="28" align="left">&nbsp;</td> 
    <td align="left"><input id="chk_ship_Europe" type="checkbox" name="checkbox52" value="欧地" runat="server" ReadOnly="true" />欧地
      <input id="chk_ship_SOUTH_AMERICA" type="checkbox" name="checkbox53" value="中南美" runat="server" ReadOnly="true" />中南美
<input id="chk_ship_Australia" type="checkbox" name="checkbox522" value="澳洲" runat="server" ReadOnly="true" />澳洲
</td>
    <td align="left"><input id="chk_air_North_America" type="checkbox" name="checkbox52" value="北美" runat="server" ReadOnly="true" />北美
      <input id="chk_air_Europe" type="checkbox" name="checkbox53" value="欧洲" runat="server" ReadOnly="true" />欧洲
<input id="chk_air_Asia" type="checkbox" name="checkbox523" value="亚洲" runat="server" ReadOnly="true" />亚洲</td>
  </tr>
  <tr>
    <td height="28" align="left">&nbsp;</td>
    <td align="left"><input id="chk_ship_Caribbean" type="checkbox" name="checkbox523" value="美加" runat="server" ReadOnly="true" />美加
  <input id="chk_ship_Red_Sea" type="checkbox" name="checkbox527" value="红海" runat="server" ReadOnly="true" />红海
<input id="chk_ship_Japan_Korea" type="checkbox" name="checkbox525" value="日韩" runat="server" ReadOnly="true" />日韩</td>
    <td align="left"><input id="chk_air_Africa" type="checkbox" name="checkbox524" value="非洲" runat="server" ReadOnly="true" />非洲
  <input id="chk_air_poncho" type="checkbox" name="checkbox522" value="南美" runat="server" ReadOnly="true" />南美
<input id="chk_air_Australia" type="checkbox" name="checkbox525" value="澳洲" runat="server" ReadOnly="true" />澳洲
</td>
  </tr>
  <tr>
    <td height="28" align="left">&nbsp;</td>
    <td align="left"><input id="chk_ship_CIMEX" type="checkbox" name="checkbox526" value="中东印巴" runat="server" ReadOnly="true" />中东印巴
  <input id="chk_ship_Africa" type="checkbox" name="checkbox528" value="非洲" runat="server" ReadOnly="true" />非洲
<input id="chk_ship_offing" type="checkbox" name="checkbox524" value="近洋" runat="server" ReadOnly="true" />近洋
</td>
    <td align="left"><input id="chk_air_internal" type="checkbox" name="checkbox528" value="国内" runat="server" ReadOnly="true" />国内</td>
  </tr>
  <tr>
    <td height="10" colspan="3" align="left"></td>
    </tr>

    
    <tr>
    <td height="10" colspan="3" align="left"></td>
    </tr>
  <tr>
    <td height="30" align="left"><strong>优势船公司</strong>：</td>
    <td align="left" colspan="2">
        
        <div style=" float:left">
        <select size="4" name="ListBox1" id="ListBox1" style="width:109px;" runat="server">
		<option value="马士基(MSK)">马士基(MSK)</option>
		<option value="长荣(EMC)">长荣(EMC)</option>
		<option value="中海(CSCL)">中海(CSCL)</option>
		<option value="达飞(CMA)">达飞(CMA)</option>
		<option value="韩进(HANJIN)">韩进(HANJIN)</option>
		<option value="万海(WANHAI)">万海(WANHAI)</option>
		<option value="地中海(MSC)">地中海(MSC)</option>
		<option value="太平(PIL)">太平(PIL)</option>
		<option value="东方海外(OOCL)">东方海外(OOCL)</option>
		<option value="中远(COSCO)">中远(COSCO)</option>
		<option value="以星(ZIM)">以星(ZIM)</option>
		<option value="阳明(YML)">阳明(YML)</option>

	</select>
        </div>
        <div style=" float:left; height: 55px;">
            <input type="button" name="Button1" value="添加" id="Button1" onClick="selectAdd()" /><br />
            <input type="button" name="Button2" value="删除" id="Button2" onClick="selectDelete()" /><br />
            <input type="button" name="Button3" value="清空" id="Button3" onClick="selectClear()"/>
        </div>
        <div style=" float:left; ">
        <select size="4" name="ListBox2" id="selshiper" style="width:109px;" runat="server">

	</select>
        </div>
        <input id="Hidden1" runat="server" type="hidden" value="马士基(MSK)|长荣(EMC)|中海(CSCL)|达飞(CMA)|韩进(HANJIN)|万海(WANHAI)|地中海(MSC)|太平(PIL)|东方海外(OOCL)|中远(COSCO)|以星(ZIM)|阳明(YML)" />
        <input id="Hidtypes" runat="server"  type="hidden" />
                                        
        &nbsp;</td>
  </tr>
  <tr>
    <td height="28" align="left">
        <strong>其他：</strong></td>
      <td align="left" colspan="2">
    <asp:TextBox ID="othershipper" runat="server" Width="254px"></asp:TextBox>
      </td>
  </tr>
  
  
  
  
          
                        
		  <tr>
		    <td height="38" align="right">&nbsp;</td>
		    <td height="38" align="left"><input onclick="checkAll();" name="Button1" id="Button11" value="提 交" type="button" />
		    <asp:Button ID="Button12" runat="server" Text="Button" style="display:none"  OnClick="Button2_Click" />
		    </td>
		    <td height="38" align="center">
                </td>
		    </tr>
	</table>
					</div>
					<div class="zc1_rg">
					  <div class="zc1_rg_box">
							<h2>免费注册普通会员<br />您将享受以下专享服务! </h2>
							<a><img src="images/diqiu.gif" />拥有独立网页,更多宣传机会<br />
							<span class="gray">&nbsp;&nbsp;&nbsp;&nbsp;增加公司知名度和商业机会</span></a>
							<a><img src="images/benb.gif" width="18" height="18" />无限制发布各类信息<br />
							<span class="gray">&nbsp;&nbsp;&nbsp;&nbsp;初级会员的所有服务</span></a>
							  <a><img src="images/dunp.gif" width="18" height="18" />初级会员的所有服务<br />
							  <span class="gray">&nbsp;&nbsp;&nbsp;&nbsp;无限制浏览环球运费网<br />
							  &nbsp;&nbsp;&nbsp;&nbsp;论坛发帖与客户交流增加信任感</span></a></div>
					</div>
				</div>
				
				
				--%>
			</div>
		  </div>
		</div>
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
</form>
</body>
</html>
