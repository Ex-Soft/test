let EventEmitter = require("events").EventEmitter;

let server = new EventEmitter;

server.on("request", function(request) {
    request.approved = true;
});

server.on("request", function(request) {
    console.log(request);
});

server.emit("request", {from: "client"});
server.emit("request", {from: "another client"});

server.on("error", function() {
    console.log(arguments);
});

//server.emit("error");
server.emit("error", new Error("SmthError"));