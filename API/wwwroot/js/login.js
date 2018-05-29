

$("#logInButton").click(function () {

    $.ajax({
        url: "/api/SetSession",


        data: {
            UserName: $('#logInUserName').val(),
            Password: $('#logInPassword').val()
        },

        method: 'post',

        success: function (result) {

            alert(result);

        },

        error: function (xhr, status, error) {

            alert("Nu blev det fel");
        }
    });
});



    
