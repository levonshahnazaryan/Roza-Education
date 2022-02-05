function getFormDataObj(form) {
    var arr = $(form).serializeArray();
    var obj = {};
    for (var i = 0; i < arr.length; i++) {
        if (arr[i].name != "__RequestVerificationToken") {
            obj[arr[i].name] = arr[i].value;
        }
    }
    return obj;
}

jQuery(document).ready(function () {
    $(document).on('click', 'body', function () {
        $('.login_box').removeClass('activeLogin').fadeOut(300);
    })

    $(document).on('click', '.btnLogin', function (e) {
        e.stopPropagation();
        if (!$('.login_box').hasClass('activeLogin')) {
            $('.login_box').addClass('activeLogin').fadeIn(300);

        } else {
            $('.login_box').removeClass('activeLogin').fadeOut(300);
        }
    });

    $(document).on('click', '.login_box', function (e) {
        e.stopPropagation();
    });

    $('.owl-carousel').owlCarousel({
        //center: true,
        items: 1,
        loop: true,
        margin: 0,
        nav: true,
        autoplay: false,
        //autoplayTimeout:3000,
        //autoplayHoverPause:true
    });

    $("#form-login").on("submit", function (e) {
        e.preventDefault();
        let isError = false;
        const form = $(this);
        const token = form.find("[name=__RequestVerificationToken]").val();
        const data = getFormDataObj(this);

        if (!data.UserName || data.UserName == "") {
            isError = true;
            $("#UserName").css("border-color", "red");
            $("#UserName").css("color", "red");
        }
        else {
            $("#UserName").css("border-color", "transparent");
            $("#UserName").css("color", "#5a5a5a");
        }

        if (!data.PassWord || data.PassWord == "") {
            isError = true;
            $("#PassWord").css("border-color", "red");
            $("#PassWord").css("color", "red");
        }
        else {
            $("#PassWord").css("border-color", "transparent");
            $("#PassWord").css("color", "#5a5a5a");
        }
        if (!isError) {
            $.ajax({
                type: 'POST',
                url: '/Account/Login',
                data: JSON.stringify(data),
                contentType: 'application/json',
                headers: { "RequestVerificationToken": token },
                success: function (resp) {
                    if (!resp.isAuthorized) {
                        $(".login_error").show();
                        $(".login_error").text(resp.errorText);
                    }
                    else {
                        window.location.href = "/Account/Index";
                    }
                }
            });
        }
    });
});