$(document).ready(function () {
    var 
        getFStringVal = function () {
            var val = $("#fString").val();
            return val || "fString";
        },
        getFIntVal = function () {
            var val = $("#fInt").val();
            return parseInt(val || "1", 10);
        };

    $("#getInt").bind("click", function (event) {
        $.ajax({
            async: true,
            url: "home/getInt",
            data: {
                fString: getFStringVal(),
                fInt: getFIntVal()
            },
            success: function (data, textStatus, jqXHR) {
                if (window.console && console.log)
                    console.log("%s: %i", textStatus, data);

                $("#result").val(textStatus + ": " + data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (window.console && console.log)
                    console.log("%s: %i", textStatus, errorThrown);

                $("#result").val(textStatus + ": \"" + errorThrown + "\"");
            }
        });
    });

    $("#getJson").bind("click", function (event) {
        $.ajax({
            async: true,
            url: "home/getJson",
            data: {
                fString: getFStringVal(),
                fInt: getFIntVal()
            },
            success: function (data, textStatus, jqXHR) {
                if (window.console && console.log)
                    console.log("%s: %o", textStatus, data);

                $("#result").val(textStatus + ": " + JSON.stringify(data));
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (window.console && console.log)
                    console.log("%s: %i", textStatus, errorThrown);

                $("#result").val(textStatus + ": \"" + errorThrown + "\"");
            }
        });
    });

    $("#postInt").bind("click", function (event) {
        $.ajax({
            async: true,
            url: "home/postInt",
            type: "POST",
            data: {
                fString: getFStringVal(),
                fInt: getFIntVal()
            },
            success: function (data, textStatus, jqXHR) {
                if (window.console && console.log)
                    console.log("%s: %i", textStatus, data);

                $("#result").val(textStatus + ": " + data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (window.console && console.log)
                    console.log("%s: %i", textStatus, errorThrown);

                $("#result").val(textStatus + ": \"" + errorThrown + "\"");
            }
        });
    });

    $("#postJson").bind("click", function (event) {
        $.ajax({
            async: true,
            url: "home/postJson",
            type: "POST",
            data: {
                fString: getFStringVal(),
                fInt: getFIntVal()
            },
            success: function (data, textStatus, jqXHR) {
                if (window.console && console.log)
                    console.log("%s: %o", textStatus, data);

                $("#result").val(textStatus + ": " + JSON.stringify(data));
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (window.console && console.log)
                    console.log("%s: %i", textStatus, errorThrown);

                $("#result").val(textStatus + ": \"" + errorThrown + "\"");
            }
        });
    });

    $("#postJsonInt").bind("click", function (event) {
        $.ajax({
            async: true,
            url: "home/postJsonInt",
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ fString: getFStringVal(), fInt: getFIntVal() }),
            success: function (data, textStatus, jqXHR) {
                if (window.console && console.log)
                    console.log("%s: %i", textStatus, data);

                $("#result").val(textStatus + ": " + data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (window.console && console.log)
                    console.log("%s: %i", textStatus, errorThrown);

                $("#result").val(textStatus + ": \"" + errorThrown + "\"");
            }
        });
    });

    $("#postJsonJson").bind("click", function (event) {
        $.ajax({
            async: true,
            url: "home/postJsonJson",
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ fString: getFStringVal(), fInt: getFIntVal() }),
            success: function (data, textStatus, jqXHR) {
                if (window.console && console.log)
                    console.log("%s: %o", textStatus, data);

                $("#result").val(textStatus + ": " + JSON.stringify(data));
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (window.console && console.log)
                    console.log("%s: %i", textStatus, errorThrown);

                $("#result").val(textStatus + ": \"" + errorThrown + "\"");
            }
        });
    });
});