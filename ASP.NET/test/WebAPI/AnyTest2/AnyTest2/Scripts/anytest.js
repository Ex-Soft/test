function testArrayByGetIHttpActionResult() {
    $.getJSON("api/anytest/testarraybygetihttpactionresult")
        .done(function (data) {
            if (window.console && console.log)
                console.log(data);
        });
}
