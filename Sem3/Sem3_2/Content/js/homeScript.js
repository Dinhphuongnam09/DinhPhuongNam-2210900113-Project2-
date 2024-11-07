$(function () {

    // hiệu ứng cho nút mua
    $(".btn").click(function () {
        $(this).button("loading").delay(500).queue(function () {
            $(this).button("reset");
            $(this).dequeue();
        });
    });

    $(".xemthem").click(function () {
        $(this).fadeOut();
        $(this).nextAll().fadeIn();
    })

    // di chuyển banner quảng cáo
    $(window).scroll(function () {

        var x = $(document).height();
        var y = $(window).scrollTop();
        var f = $("footer").height();
        if ($(window).width() > 1035) {
            if (y < 1450) {
                $("#myScrollspy").css('top', '');
                $("#myScrollspy").css('position', 'relative');
            } else {
                if (y < (x - (770 + f))) {
                    $("#myScrollspy").css('position', 'fixed');
                    $("#myScrollspy").css('top', '60px');
                } else {
                    $("#myScrollspy").css('position', 'relative');
                    $("#myScrollspy").css('top', (x - (2230 + f)) + 'px');
                }
            }
        } else {
            $("#myScrollspy").css('top', '');
            $("#myScrollspy").css('position', 'relative');
        }

    });
});

// slide chay ngang
var speed = 15;
var tab = document.getElementById("slideB");
var tab1 = document.getElementById("inslideB1");
var tab2 = document.getElementById("inslideB2");
if (tab != null && tab1 != null && tab2 != null) {
    tab2.innerHTML = tab1 != null ? tab1.innerHTML : 0;
    function Marquee() {
        if (tab2.offsetWidth - tab.scrollLeft <= 0)
            tab.scrollLeft -= tab1.offsetWidth
        else { tab.scrollLeft++; }
    }
    var MyMar = setInterval(Marquee, speed);
    tab.onmouseover = function () { clearInterval(MyMar) };
    tab.onmouseout = function () { MyMar = setInterval(Marquee, speed) };
}

function thanhToan() {
    var userName = $('#hovaten').val();
    var address = $('#address').val();
    var phone = $('#sodt').val();
    var email = $('#email').val();
    var deliveryType = "";
    if ($('#rad1').checked) {
        deliveryType = "At home";
    } else {
        deliveryType = "At shop";
    }
    m_ShoppingCart.HoTen = userName;
    m_ShoppingCart.DiaChi = address;
    m_ShoppingCart.Email = email;
    m_ShoppingCart.DienThoai = phone;
    m_ShoppingCart.CachGiao = deliveryType;
    var table = document.getElementById('cartItems');
    var rowLength = table.rows.length;
    for (var i = 1; i < rowLength; i += 1) {
        var row = table.rows[i];
        var cell, val1, val2, val3;
        //Get Product name
        val1 = cell = row.cells[1].innerHTML;
        //Get Price
        cell = row.cells[2].innerHTML;
        var thenum = cell.match(/\d+/)[0];
        val2 = thenum;
        //Get Quantity
        var inputs = row.getElementsByTagName('input');
        val3 = inputs[0].value;
        AddToCart(i, val1, val2, val3);
        /*
        var cellLength = row.cells.length;
        for (var y = 1; y < cellLength - 1; y += 1) {
        var cell;
        if (y == 2 || y==4)
        {
        cell = row.cells[y].innerHTML;
        var thenum = cell.match(/\d+/)[0];
        cell = thenum;
        }
        else if (y == 3) {
        var inputs = row.getElementsByTagName('input');
        cell = inputs[0].value;
        }
        else {
        cell = row.cells[y].innerHTML;
        }
        alert(cell);
        //do something with every cell here
        }
        */
    }
    //Post data to server
    PostData();
}
// Initialize the Shopping Cart object
var m_ShoppingCart = {
    HoTen: "",
    DiaChi: "",
    DienThoai: "",
    Email: "",
    NgayDat: "",
    CachGiao: "At home",
    TrangThai: "",
    CartItems: []
};
function AddToCart(id, itemName, price, quantity) {
    // Add the item to the shopping cart object
    m_ShoppingCart.CartItems.push({
        "Id": id,
        "ItemName": itemName,
        "Price": parseFloat(price).toFixed(2), // Issue here if you don't specify the decimal place
        "Quantity": quantity
    });

    // Render the shopping cart object
    // RenderShoppingCart();
}
function RenderShoppingCart() {
    $("#CartItemList").html("");
    var totalAmount = 0;
    $.each(m_ShoppingCart.CartItems, function (index, cartItem) {
        var itemTotal = Number(cartItem.Price) * Number(cartItem.Quantity);
        totalAmount += itemTotal;
        $("#CartItemList").append("<li>" + cartItem.ItemName + " - $" + itemTotal.toFixed(2) + "</li>");
    });
    $("#TotalAmount").html("$" + totalAmount.toFixed(2));
}
function PostData() {
    $.ajax({
        url: '/Home/Checkout',
        async: false,
        type: "POST",
        data: JSON.stringify(m_ShoppingCart),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR + "-" + textStatus + "-" + errorThrown);
        },
        success: function (data, textStatus, jqXHR) {
            //$("#Results").show();
            //$("#ResultMessage").html(data.Message);
            alert(data.Message);
        }
    });
}
function ResetForm() {
    // Reset the ui elements
    $("#CartItemList").html("");
    $("#TotalAmount").html("$0.00");
    $("#ResultMessage").html("");
    // Hide the results
    $("#Results").hide();
    // Enable all the 'Add to Cart' buttons
    $("input").removeAttr("disabled");
    // Reset the Shopping Cart object
    m_ShoppingCart.CartItems = [];
}