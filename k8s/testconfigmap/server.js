let debug = require("debug")("server:server");
let http = require("http");
let fs = require("fs");

let server = new http.Server();
server.listen(1337, "0.0.0.0");

let url = require("url");

server.on("request", function(req, res) {
    debug(req.method, req.url);
    let urlParsed = url.parse(req.url, true);
    debug(urlParsed);

    let value;

    if (urlParsed.pathname == "/echo" && urlParsed.query.message) {
        res.setHeader("Cache-Control", "no-cache, no-store, must-revalidate, max-age=0");
        res.statusCode = 200;
        res.end(urlParsed.query.message);
    } else if (urlParsed.pathname == "/get" && urlParsed.query.variable) {
        res.setHeader("Cache-Control", "no-cache, no-store, must-revalidate, max-age=0");
        try {
			value = fs.readFileSync("./config/" + urlParsed.query.variable);
			res.end(value);
		}
		catch {
			res.statusCode = 404;
			res.end(urlParsed.query.variable + " not found");
		}
    } else if (urlParsed.pathname == "/env") {
        res.setHeader("Cache-Control", "no-cache, no-store, must-revalidate, max-age=0");
        try {
			value = fs.readFileSync("./env/env.js", "utf-8");
			res.end(value);
		}
		catch {
			res.statusCode = 404;
			res.end("env not found");
		}
    } else {
        res.statusCode = 404;
        res.end("Page not found");
    }
});
