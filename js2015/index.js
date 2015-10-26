$(document).ready(function(){
	$(".login-box-input .input-txt").each(function(){
		var thisVal=$(this).val();
		//判断文本框的值是否为空，有值的情况就隐藏提示语，没有值就显示
		if(thisVal!=""){
				$(this).siblings("span").hide();
			}else{
				$(this).siblings("span").show();
			}
		//聚焦型输入框验证	
		$(this).focus(function(){
				$(this).siblings("span").hide();
			}).blur(function(){
					var val=$(this).val();
					if(val!=""){
						$(this).siblings("span").hide();
					}else{
						$(this).siblings("span").show();
					}	
			});
	})	



	
	$(".login-box-input label span").each(function(){
	    $(this).click(function(){
	        $(this).hide();
	        $(this).siblings("input").focus();
	    });
	})

	$(function () {
	    $('.index-slide').unslider({
	        speed: 500,               //  The speed to animate each slide (in milliseconds)
	        delay: 8000,              //  The delay between slide animations (in milliseconds)
	        //complete: function () { },  //  A function that gets called after every slide animation
	        keys: false,               //  Enable keyboard (left, right) arrow shortcuts
	        dots: true               //  Display dot navigation
	        //fluid: false              //  Support responsive design. May break non-responsive designs
	    });
	});

	$("#fcl-submit").click(function () {
	    location.href = "/fcl/" + "list" + "-" + $('#txtStartport').val() + "-" + $('#txtDestport').val() + "-" + $('#txtCarrier').val() + "-0-0-0-----1.html";
	});

	$("#lcl-submit").click(function () {
	    location.href = "/lcl/" + "list" + "-" + $('#txtStartport2').val() + "-" + $('#txtDestport2').val() + "--0-0-0-----1.html";
	});

	$("#air-submit").click(function () {
	    location.href = "/air/" + "list" + "-" + $('#txtStartport3').val() + "-" + $('#txtDestport3').val() + "--0-0-0-----1.html";
	});

	$("#company-submit").click(function () {
	    location.href = "/company/list----" + $('#txtCompanyName').val() + "---0-0----------1.html";
	});
});

