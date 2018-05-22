$("#karta").click(function () {


    $.ajax({
        url: "/api/map",

        method: 'get',

        success: function (result) {

            alert(result);
        },

        error: function (xhr, status, error) {

            alert("Nu blev det fel");
        }
    });
});