var
    smthEnum,
    smthEnumStr;

$(document).ready(function () {
    $.getJSON("api/anytest/getsmthenum")
        .done(function (data) {
            if (data && Array.isArray(data.SmthEnum))
                smthEnum = data.SmthEnum;
        });

    $.getJSON("api/anytest/getsmthenumstr")
        .done(function (data) {
            if (data && Array.isArray(data.SmthEnumStr))
                smthEnumStr = data.SmthEnumStr;
        });
});

function testArrayByGet(useStr) {
    var values = (useStr ? smthEnumStr : smthEnum).reduce((accumulator, currentValue, currentIndex, array) => {
        if ((useStr && currentIndex % 2 === 0) || (!useStr && currentIndex % 2 !== 0))
            return accumulator;

        if (accumulator.length)
            accumulator += "&";

        return accumulator + `Values=${currentValue}`;
    }, "");

    $.getJSON(`api/anytest/testarraybyget?${values}`)
        .done(function (data) {
            if (window.console && console.log)
                console.log(data);
        });
}
