$(function () {
    $("#myScrollspy .moveSection").on('click', function (event) {

        // Prevent default anchor click behavior
        event.preventDefault();

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

    // di chuyển leftBar
    $(window).scroll(function () {

        var x = $(document).height();
        var y = $(window).scrollTop();
        var f = $("footer").height();



        if (y < 400) {
            $("#myScrollspy > ul").css('top', '');
            $("#myScrollspy > ul").css('position', 'relative');
        } else {
            if (y < (x - (470 + f))) {
                $("#myScrollspy > ul").css('position', 'fixed');
                $("#myScrollspy > ul").css('top', '60px');
            } else {
                $("#myScrollspy > ul").css('position', 'relative');
                $("#myScrollspy > ul").css('top', (x - (820 + f)) + 'px');
            }
        }


    });
})

$(function () {
    $('#bac').click(function () {
        $('#imgsp').attr('src', 'images/iphone-6s-plus-silver.jpg');
        $('button').removeClass('activeClick');
        $(this).addClass('activeClick');
    })

    $('#xam').click(function () {
        $('#imgsp').attr('src', 'images/iphone6s-plus-gray.jpg');
        $('button').removeClass('activeClick');
        $(this).addClass('activeClick');
    })

    $('#vangdong').click(function () {
        $('#imgsp').attr('src', 'images/iphone-6s-plus-gold1.jpg');
        $('button').removeClass('activeClick');
        $(this).addClass('activeClick');
    })

    $('#hong').click(function () {
        $('#imgsp').attr('src', 'images/iphone-6s-plus-rosegold-400x450.png');
        $('button').removeClass('activeClick');
        $(this).addClass('activeClick');
    })
})