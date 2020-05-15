let util = require("util");

let phrases = {
    "Hello": "Привіт",
    "world": "світ"
};

function PhraseError(message) {
    this.message = message;
    Error.captureStackTrace(this, PhraseError);
}
util.inherits(PhraseError, Error);
PhraseError.prototype.name = "PhraseError";

function HttpError(status, message) {
    this.status = status;
    this.message = message;
    Error.captureStackTrace(this, HttpError);
}
util.inherits(HttpError, Error);
HttpError.prototype.name = "HttpError";

function getPhrase(key) {
    if (!phrases[key]) {
        throw new PhraseError(`\"${key}\" doesn't exist`);
    }
    return phrases[key];
}

function makePage(url) {
    if (url != "index.html") {
        throw new HttpError(404, `\"${url}\" doesn't exist`);
    }
    return util.format("%s, %s!", getPhrase("Hell"), getPhrase("world"));
}

try
{
    let page = makePage("index.html");
    console.log(page);
}
catch (e) {
    if (e instanceof HttpError) {
        console.log(e.status, e.message);
    //} else if (e instanceof PhraseError) {
    //    console.log(e.message);
    } else {
        console.log(`Error: ${e.name} Message: ${e.message} Stack: ${e.stack}`);
    }
}