

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


$("#testButton").click(function () {

    $.ajax({
        url: "/api/TestSession",


        method: 'get',

        success: function (result) {

            alert(result);

        },

        error: function (xhr, status, error) {

            alert("Fel i sessionusername");
        }
    });
});

    
//if (isset($_POST['username']) && isset($_POST['password')) {

//    if (($_POST['username'] == $user) && ($_POST['password'] == $pass)) {

//            setcookie('username', $_POST['username'], false, '/account', 'www.example.com');
//            setcookie('password', md5($_POST['password']), false, '/account', 'www.example.com');
//    }
//        header('Location: index.php');

//    } else {
//        echo 'Username/Password Invalid';
//    }

//} else {
//    echo 'You must supply a username and password.';
//}
//?>