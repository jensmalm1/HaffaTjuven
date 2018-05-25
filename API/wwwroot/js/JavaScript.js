


$("#addInformation").click(function () {

    $.ajax({

        url: "/api/AddInformation",
        method: 'POST',
        data: {
            UserId: $('#userId').val(),
            Content: $('#content').val(),
            CrimeId:$(crimeId).val()
        },

        success: function (result) {

            alert(result);

        },

        error: function (error) {

            alert("Nu blev det fel");
        }

    });
});

$("#addUser").click(function () {

    $.ajax({

        url: "/api/AddUser",
        method: 'POST',
        data: {
            UserName: $('#userName').val(),
            Password: $('#password').val()
        },

        success: function(result) {
           
            alert(result);
            
        }
        

        
    });
});


$("#showUsersButton").click(function () {

    $.ajax({
        url: "/api/ShowUsers",

        method: 'get',

        success: function (result) {

            alert(result);
        },

        error: function (xhr, status, error) {

            alert("Nu blev det fel");
        }
    });
});

