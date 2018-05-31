

$("#logInButton").click(function () {

    $.ajax({
        url: "/api/SetSession",


        data: {
            UserName: $('#logInUserName').val(),
            Password: $('#logInPassword').val()
        },

        method: 'post',

        success: function (result) {
           
                setTimeout(function () { window.location.href = "../html/index.html"; },2000);
        },

        error: function (xhr, status, error) {

            alert(result);
        }
    });
});



    
