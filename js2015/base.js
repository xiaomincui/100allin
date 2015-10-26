


$(document).ready(function () {
    var $tab_li = $('#tab ul li');
    $tab_li.click(function () {
        $(this).addClass('selected').siblings().removeClass('selected');
        var index = $tab_li.index(this);
        $('div.tab-box > div').eq(index).show().siblings().hide();
    });

    $(".tab-box-input .input-txt").each(function () {
        var thisVal = $(this).val();
        //判断文本框的值是否为空，有值的情况就隐藏提示语，没有值就显示
        if (thisVal != "") {
            $(this).siblings("span").hide();
        } else {
            $(this).siblings("span").show();
        }
        //聚焦型输入框验证	
        $(this).focus(function () {
            $(this).siblings("span").hide();
        }).blur(function () {
            var val = $(this).val();
            if (val != "") {
                $(this).siblings("span").hide();
            } else {
                $(this).siblings("span").show();
            }
        });
    })

    $(".tab-box-input label span").each(function () {
        $(this).click(function () {
            $(this).hide();
            $(this).siblings("input").focus();
        });
    })

    jQuery.fn.limit = function () {
        var self = $("[limit]");
        self.each(function () {
            var objString = $(this).text();
            var objLength = $(this).text().length;
            var num = $(this).attr("limit");
            if (objLength > num) {
                $(this).attr("title", objString);
                objString = $(this).text(objString.substring(0, num) + "...");
            }
        })
    }

    $(function () {
        $("[limit]").limit();
    })  
});


