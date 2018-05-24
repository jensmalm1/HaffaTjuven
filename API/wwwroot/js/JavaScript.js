


$("#addInformation").click(function () {

    $.ajax({

        url: "/api/AddInformation",
        method: 'POST',
        data: {
            UserId: $('#userId').val(),
            Content: $('#content').val()
        }

        //success: function (result) {

        //    $("#returnStatus").html(" ✔️ Informationen tillagd");
        //    $("#userId").val("1");
        //    $("#content").val("");

        //},

        //error: function (xhr, status, error) {

        //    $("#returnStatus").html(" ❌ Ett fel har uppstått och information blev ej tillagd");
        //    //console.log("xhr", xhr);
        //    //console.log("status", status);
        //    //console.log("error", error);

        //}
    });
});

$("#addUser").click(function () {

    $.ajax({

        url: "/api/AddUser",
        method: 'POST',
        data: {
            UserName: $('#userName').val(),
            Password: $('#password').val()
        }

        //success: function(result) {
           
        //    alert(result);
        //}
        

        
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