$(document).ready(function () {
    if (window.console && console.clear)
        console.clear();

    if (window.console && console.log)
        console.log("jquery: %s", $.fn.jquery);

    $("#btnTestGet").on("click", function () {
        var jqXHR =
        $.get({
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
        })
        .done(function (data, textStatus, jqXHR) {
            if (window.console && window.console.log)
                console.log("done(%o)", arguments);
        })
        .fail(function () {
            if (window.console && window.console.log)
                console.log("fail(%o)", arguments);
        })
        .always(function (data, textStatus, jqXHR) {
            if (window.console && window.console.log)
                console.log("always(%o)", arguments);
        })
        .then(function (data, textStatus, jqXHR) {
            if (window.console && window.console.log)
                console.log("then(%o)", arguments);
        })
        .pipe(function () {
            if (window.console && window.console.log)
                console.log("pipe(%o)", arguments);
        })
        .progress(function () {
            if (window.console && window.console.log)
                console.log("progress(%o)", arguments);
        })
        .state(function () {
            if (window.console && window.console.log)
                console.log("state(%o)", arguments);
        })
        /*.when(function () {
        if (window.console && window.console.log)
        console.log("whene(%o)", arguments);
        })
        */
        /*
        .promise(function () {
        if (window.console && window.console.log)
        console.log("promise(%o)", arguments);
        })*/;

        if (window.console && window.console.log)
            console.log("jqXHR(%o)", jqXHR);
    });

    $("#btnTestPromise").on("click", function (e) {
        $.ajax({
            url: "TestPromise.aspx",
            method: "POST",
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify({
                delay: 5000
                //, statusCode: 500
            })
        })
        .then(function (data, textStatus, jqXHR) {
            if (window.console && window.console.log)
                console.log("then(%o) #1", arguments);

            if (data.success)
                return $.ajax({
                    url: "TestPromise.aspx",
                    method: "POST",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify({
                        delay: 4000
                        //, statusCode: 501
                    })
                });
        })
        .then(function (data, textStatus, jqXHR) {
            if (window.console && window.console.log)
                console.log("then(%o) #2", arguments);

            if (data.success)
                return $.ajax({
                    url: "TestPromise.aspx",
                    method: "POST",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify({
                        delay: 3000
                        //, statusCode: 502
                    })
                });
        })
        .then(function (data, textStatus, jqXHR) {
            if (window.console && window.console.log)
                console.log("then(%o) #3", arguments);

            return jqXHR;
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            if (window.console && window.console.log)
                console.log("fail(%o)", arguments);
        })
        .always(function () {
            if (window.console && window.console.log)
                console.log("always(%o)", arguments);
        });
    });
});
