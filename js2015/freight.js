$(document).ready(function () {

    var w;
    w = 705 - $("#port-box-pol").width() - $("#port-box-pod").width() - 112
    $("#arrow-carrier").animate({
        width: w + 'px'
    }, 800
        );

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


//    $('#filter').readmore({
//        speed: 75,
//        maxHeight: 20,
//        moreLink: '<a href="#">更多</a>',
//        lessLink: '<a href="#">收起</a>'
//    });

    $("#limit-title").attr("title", $("#limit-title").text());
});

//$('#limit').limit();  