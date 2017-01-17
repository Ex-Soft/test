$(document).ready(function () {

    $.ajaxSetup({
        username: "login",
        password: "1",
        statusCode: {
            401: function (jqXHR, textStatus, errorThrown) {
                if (window.console && console.log)
                    console.log("statusCode 401: %o", arguments);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (window.console && window.console.log)
                console.log("error (global): xhr.status=%i xhr.statusText=\"%s\" textStatus=\"%s\" errorThrown=\"%s\"", jqXHR.status, jqXHR.statusText, textStatus, errorThrown);
        },
        beforeSend: function (jqXHR, settings) {
            var 
                username = "login",
                password = "1";
            
            jqXHR.setRequestHeader("Authorization", "Basic " + btoa(username + ":" + password));
        }
    });

    $("#btnDoIt").click(function () {
        $.ajax({
            url: "data.aspx",
            type: "post",
            dataType: "json",
            data: {
                param1: "param1",
                param2: "param2"
            },
            success: function (data, textStatus, jqXHR) {
                if (window.console && window.console.log)
                    console.log("success: %s", textStatus);
            },
            complete: function (jqXHR, textStatus) {
                if (window.console && window.console.log)
                    console.log("complete: %s", textStatus);
            }
            , error: function (jqXHR, textStatus, errorThrown) {
                if (window.console && window.console.log)
                    console.log("error (local): xhr.status=%i xhr.statusText=\"%s\" textStatus=\"%s\" errorThrown=\"%s\"", jqXHR.status, jqXHR.statusText, textStatus, errorThrown);
            }
        });
    });
});
