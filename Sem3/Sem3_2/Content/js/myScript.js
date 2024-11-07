//back top
$(function () {

    if ((typeof window.sessionStorage) !== 'undefined') { reload() }

    $("body").on("click","[mydata-hide]", function () {
        //$("." + $(this).attr("data-hide")).hide();
        // -or-, see below
        $(this).parent().closest("." + $(this).attr("mydata-hide")).remove();
        addNum();
    });

    // sap xep 
    $("body").on("change", ".homeSelect", function () {
        var selector = $(this).nextAll("div");
        $.ajax({
            url: '/Home/productPartialView?sortString=' + $(this).val() + '&logo=' + $(this).attr('logo') + '&bidanh=' + $(this).attr('bidanh'),
            type: 'GET',
            success: function (resp) {
                selector.empty();
                selector.append(resp);
                //SetDataProduct(resp, $(this).nextAll("div"));
            }
        });
    });


    // xem them tin tuc
    $("#xemBtn").click(function () {

            $.ajax({
                url: '/Home/newsPartialView?offset=' + $('#newsHome > .col-sm-12').length,
                type: 'GET',
                success: function (resp) {
                    SetDataNews(resp);
                    if ($.trim(resp).length == 0) {
                        $('#xemBtn').hide();
                    }
                },
                complete: 
                    $.ajax({
                        url: '/Home/isMore?offset=' + $('#newsHome > .col-sm-12').length,
                        type: 'GET',
                        success: function (resp) {
                            if (resp) {
                                $('#xemBtn').hide();
                            }
                        },
                        })
            });

    })

    function SetDataNews(data) {
        $("#newsHome").append(data); // HTML DOM replace
    }

    $("#search").keyup(function () {
        if ($(this).val().length >= 3)
        {
            $.ajax({
                url: '/Home/searchPartialView?searchString=' + $(this).val(),
                type: 'GET',
                success: function (resp) {
                    SetDataSearch(resp);
                }
            });
            $('#divtimkiem').slideDown('slow');
        }
        else {
            $("#divtimkiem > ul").remove();
            $('#divtimkiem').slideUp('slow');
        }
    })

    function SetDataSearch(data) {
        $("#divtimkiem > ul").remove();
        $("#divtimkiem").html(data); // HTML DOM replace
    }

    $("input:not(.slmua):not([type=submit]):not([id=SearchString]):not([id=RememberMe]):not([type=radio])").addClass("form-control");
    $("textArea").addClass("form-control");
    $("select:not([class=homeSelect])").addClass("form-control");

    $('#account').click(function () {
        $('#myModal2').modal();
    });

    $(window).scroll(function () {
        // lấy giá trị scrollTop liển tục để kiểm tra
        var a = $(window).scrollTop();
        if (a < 1000) {
            $('#myBtn').fadeOut('slow');
        } else { $('#myBtn').fadeIn('slow'); };

    });

    // gán giá trị scrollTop = 0 => trở về đầu trang với animate 1,5s để di chuyển về
    $('#myBtn').click(function () {
        $('html,body').animate({ scrollTop: 0 }, 500);
    });
});

// check email
function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

$(function () {

    $('[data-toggle="tooltip"]').tooltip();
     
    $("#sodt").keyup(function () {
        if ($(this).val().length >= 10) {
            $(this).parent().parent().removeClass('has-warning');
            $(this).parent().find('span:eq(0)').removeClass('glyphicon-warning-sign');
            $(this).parent().parent().addClass('has-success');
            $(this).parent().find('span:eq(0)').addClass('glyphicon-ok');

        } else {
            $(this).parent().parent().removeClass('has-success');
            $(this).parent().find('span:eq(0)').removeClass('glyphicon-ok');
            $(this).parent().parent().addClass('has-warning');
            $(this).parent().find('span:eq(0)').addClass('glyphicon-warning-sign');
        }

    });

    $("#hovaten").keyup(function () {
        if ($(this).val().length == "") {
            $(this).parent().parent().removeClass('has-success');
            $(this).parent().find('span:first').removeClass('glyphicon-ok');
            $(this).parent().parent().addClass('has-warning');
            $(this).parent().find('span:first').addClass('glyphicon-warning-sign');
        } else {
            $(this).parent().parent().removeClass('has-warning');
            $(this).parent().find('span:first').removeClass('glyphicon-warning-sign');
            $(this).parent().parent().addClass('has-success');
            $(this).parent().find('span:first').addClass('glyphicon-ok');
        }

    });

    $("#email").keyup(function () {
        if (!isEmail($('#email').val())) {
            $(this).parent().parent().removeClass('has-success');
            $(this).parent().find('span:first').removeClass('glyphicon-ok');
            $(this).parent().parent().addClass('has-warning');
            $(this).parent().find('span:first').addClass('glyphicon-warning-sign');
        } else {
            $(this).parent().parent().removeClass('has-warning');
            $(this).parent().find('span:first').removeClass('glyphicon-warning-sign');
            $(this).parent().parent().addClass('has-success');
            $(this).parent().find('span:first').addClass('glyphicon-ok');
        }
    });

    $('#dathang').click(function () {
        if ($('#hovaten').val() == "" || $('#hovaten').val().length < 1) {
            $('#ycTen').css('display', 'block');
        } else {
            $('#ycTen').css('display', 'none');
        }
        if ($('#sodt').val() == "") {
            $('#ycSDT').css('display', 'block');
            $('#ycSDT1').css('display', 'none');
        } else {
            $('#ycSDT').css('display', 'none');
            if ($('#sodt').val().length < 10) {
                $('#ycSDT1').css('display', 'block');
            } else {
                $('#ycSDT1').css('display', 'none');
            }
        }
        if ($('#email').val() == "") {
            $('#ycEmail').css('display', 'block');
            $('#ycEmail1').css('display', 'none');
        } else {
            $('#ycEmail').css('display', 'none');
            if (isEmail($('#email').val())) {
                $('#ycEmail1').css('display', 'none');
            } else {
                $('#ycEmail1').css('display', 'block');
            }

        }
        if (!isEmail($('#email').val()) || $('#hovaten').val() == "" || $('#sodt').val() == "" || $('#email').val() == "" || $('#sodt').val().length < 10) {
            return false;
        } else {
            alert("Đặt hàng thành công");
        }
    })

    /* affix the navbar after scroll below header */
    $(".navbar").affix({ offset: { top: $(".jumbotron").outerHeight(true) } });

    //hiển thị popover cho Top 10 sản phẩm bán chạy
    $('[data-toggle="popover"]').popover({ placement: "top" });

    // Add smooth scrolling on all links inside the navbar
    //them hieu ung di chuyen cham cho lien ket khi click cac muc trong thanh menu
    $("#myNavbar .moveSection").on('click', function (event) {

        // Prevent default anchor click behavior
        //event.preventDefault();

        // Store hash
        var hash = this.hash;

        // Using jQuery's animate() method to add smooth page scroll
        // The optional number (800) specifies the number of milliseconds it takes to scroll to the specified area
        $('html, body').animate({
            scrollTop: $(hash).offset().top
        }, 800, function () {

            // Add hash (#) to URL when done scrolling (default click behavior)
            window.location.hash = hash;
        });
    });
})


var tenProduct = [];
var soluongProduct = [];
var hinhanhProduct = [];
var dongiaProduct = [];
var muaProduct = [];

//Hiển thị số lượng và Tính tổng tiền cho đơn đặt hàng
function addNum() {
    var index = $('#cartItems input').length;
    var tongsl = 0;
    var sl = [];
    var k = 0;
    var chiso = 0;
    
    $('#cartItems input').each(function () {
        if (sessionStorage.soluong !== undefined) {
            muaProduct[chiso] = $(this).val();
            chiso++;
        }
        tongsl += parseInt($(this).val());
        sl[k] = parseInt($(this).val());
        var a = sl[k];
        k++;
    })

    sessionStorage["mua"] = JSON.stringify(muaProduct);
    chiso = 0;
    $('#soluong').text(tongsl);

    var dongia = [];
    var j = 0;
    $('#cartItems b').each(function () {
        dongia[j] = parseFloat($(this).text().replace(/\./g,''));
        j++;
    })

    var i1 = 0;
    var thanhtien;
    $('#cartItems strong').each(function () {
        thanhtien = (sl[i1] * dongia[i1]);
        if (thanhtien > 0) { $(this).text(thanhtien.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, "$1.").slice(0, -3).toString()); }
        else { $(this).text('0 VNĐ'); }

        i1++;
    })

    var tongtien = 0;
    for (var i = 0; i < index; i++) {
        tongtien += (sl[i] * dongia[i]);
    }
    if (tongtien > 0) { $('#tongtien').text(tongtien.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, "$1.").slice(0, -3).toString() + " VNĐ"); }
    else { $('#tongtien').text('0 VNĐ'); }

    tongsl = 0;
}

//Kiem tra hang ton
function checkTk(obj) {
    if (Number($(obj).val()) >= Number($(obj).attr('max'))) {
        $(obj).val(Number($(obj).attr('max')) - 1);
        alert('Trong kho chỉ còn ' + (Number($(obj).attr('max')) - 1) + ' sản phẩm này');
    } else {
        if (Number($(obj).val()) <= 0) {
            $(obj).val(1);
        }

    }
    addNum();
}

if ((typeof window.sessionStorage) !== 'undefined') {

    function xoa(obj) {
        tenProduct = JSON.parse(sessionStorage["ten"]);
        soluongProduct = JSON.parse(sessionStorage["soluong"]);
        hinhanhProduct = JSON.parse(sessionStorage["anh"]);
        dongiaProduct = JSON.parse(sessionStorage["dongia"]);
        muaProduct = JSON.parse(sessionStorage["mua"]);
        var tenSp = $(obj).parent().parent().find("td:nth-of-type(2)");
        for (var i = 0; i < tenProduct.length; i++) {
            if (tenProduct[i] == tenSp.text()) {
                tenProduct.splice(i, 1);
                soluongProduct.splice(i, 1);
                hinhanhProduct.splice(i, 1);
                dongiaProduct.splice(i, 1);
                muaProduct.splice(i, 1);
                sessionStorage["ten"] = JSON.stringify(tenProduct);
                sessionStorage["soluong"] = JSON.stringify(soluongProduct);
                sessionStorage["anh"] = JSON.stringify(hinhanhProduct);
                sessionStorage["dongia"] = JSON.stringify(dongiaProduct);
                sessionStorage["mua"] = JSON.stringify(muaProduct);
            }

        }

        
        //addNum();
        //setTimeout(addNum, 100);
    }
}

function reload() {
    if ((typeof window.sessionStorage) !== 'undefined' && sessionStorage["soluong"] !== undefined) {

        tenProduct = JSON.parse(sessionStorage["ten"]);
        soluongProduct = JSON.parse(sessionStorage["soluong"]);
        hinhanhProduct = JSON.parse(sessionStorage["anh"]);
        dongiaProduct = JSON.parse(sessionStorage["dongia"]);
        muaProduct = JSON.parse(sessionStorage["mua"]);

        for (var i = 0; i < tenProduct.length; i++) {
            if (tenProduct[i] == null) { continue }
            $('#cartItems').append('<tr class="alert alert-success"><td><img style="max-width: 120px; width: 100%" src="' + hinhanhProduct[i] + '">' + '</td>' +
            '<td class="tensp">' + tenProduct[i] + '</td>' +
            '<td class="dongia"><b>' + dongiaProduct[i] + '</b></td>' +
            '<td><input class="slmua" onclick="checkTk(this)" onchange="checkTk(this)" onkeyup="checkTk(this)" type="number" min="1" value="' + muaProduct[i] + '" max="' + soluongProduct[i] + '" style="width: 40px">' + '</td>' +
            '<td><strong>' + dongiaProduct[i] + '</strong></td>' +
            '<td><button type="button" class="btn btn-danger" mydata-hide="alert-success" aria-label="close" onclick="xoa(this)" ><span class="glyphicon glyphicon-remove"></span></button></td>' +
            '</tr>');
        }
        addNum();
    }
}

//Thêm đơn hàng vào giỏ hàng
function myClickmua(anh, ten, gia, soluong) {

    // kiểm tra số sản phẩm có trong giỏ hàng
    var index = $('#cartItems .tensp').length;
    var tensp = [];
    var dem = 0;
    var k1 = 0;
    //Kiểm tra số lượng hàng tồn
    if (soluong < 1) {
        alert('Sản phẩm này đã hết hàng! Xin vui lòng chọn sản phẩm khác');
        return;
    }
    //Lưu danh sách tên sản phẩm tại giỏ hàng vào mảng tensp
    $('#cartItems .tensp').each(function () {
        tensp[k1] = $(this).text();
        k1++;
    })

    //Kiểm tra tên sản phẩm vừa nhận từ nút mua có trùng với danh sách ở trên ko
    //Nếu giỏ hàng trống thì biến dem = 0 => lệnh else ở dưới đc thực thi là thêm sản phẩm vào giỏ hàng
    for (var i = 0; i < index; i++) {
        if (ten == tensp[i]) {
            dem++;
        }
    }
    if (dem > 0) {
        alert('bạn đã chọn sản phẩm này rồi!\nXin kiểm tra lại giỏ hàng của bạn');
    } else {

        if (sessionStorage["soluong"] !== undefined) {
            tenProduct = JSON.parse(sessionStorage["ten"]);
            soluongProduct = JSON.parse(sessionStorage["soluong"]);
            hinhanhProduct = JSON.parse(sessionStorage["anh"]);
            dongiaProduct = JSON.parse(sessionStorage["dongia"]);
            muaProduct = JSON.parse(sessionStorage["mua"]);
        }
        soluong++;
        tenProduct[index] = ten;
        sessionStorage["ten"] = JSON.stringify(tenProduct);
        //            var tenSp = JSON.parse(sessionStorage["ten"]);

        soluongProduct[index] = soluong;
        sessionStorage["soluong"] = JSON.stringify(soluongProduct);
        //            var soluongSp = JSON.parse(sessionStorage["soluong"]);

        hinhanhProduct[index] = anh;
        sessionStorage["anh"] = JSON.stringify(hinhanhProduct);
        //            var anhSp = JSON.parse(sessionStorage["anh"]);

        dongiaProduct[index] = gia;
        sessionStorage["dongia"] = JSON.stringify(dongiaProduct);
        //            var dongiaSp = JSON.parse(sessionStorage["dongia"]);

        muaProduct[index] = 1;
        sessionStorage["mua"] = JSON.stringify(muaProduct);

        $('#cartItems').append('<tr class="alert alert-success"><td><img style="max-width: 120px; width: 100%" src="' + anh + '" >' + '</td>' +
        '<td class="tensp">' + ten + '</td>' +
        '<td class="dongia"><b>' + gia + '</b></td>' +
        '<td><input class="slmua" onclick="checkTk(this)" onchange="checkTk(this)" onkeyup="checkTk(this)" type="number" min="1" value="1" style="width: 40px" max="' + soluong + '" >' + '</td>' +
        '<td><strong>' + gia + '</strong></td>' +
        '<td><button type="button" class="btn btn-danger" mydata-hide="alert-success" aria-label="close" onclick="xoa(this)" ><span class="glyphicon glyphicon-remove"></span></button></td>' +
        '</tr>');

        index++;
        addNum();
    }
    dem = 0;
}