const debug = require("debug")("http");
const http = require("node:http");
const fs = require("fs");
const url = require("url");
const os = require("os");

const port = 3000;

function getHostIp(os, interfaceName) {
  const ifaces = os.networkInterfaces();
  const ifacesNames = Object.keys(ifaces);

  for (let i = 0, l = ifacesNames.length; i < l; ++i) {
    const ifname = ifacesNames[i];

    if (!!interfaceName && ifname !== interfaceName) continue;

    for (let _i_ = 0, _l_ = ifaces[ifname].length; _i_ < _l_; ++_i_) {
      const iface = ifaces[ifname][_i_];

      if ("IPv4" !== iface.family || iface.internal !== false) {
        continue;
      }

      if (!!interfaceName && ifname === interfaceName) return iface.address;
    }
  }

  return undefined;
}

const server = http
  .createServer((req, res) => {
    debug(`${req.method} ${req.url}`);
    console.log("%s %s", req.method, req.url);
    let urlParsed = url.parse(req.url, true);
    debug(urlParsed);
    let value;

    if (urlParsed.pathname == "/echo" && urlParsed.query.message) {
      //res.writeHead(200, "OK", {"Cache-Control":"no-cache"}); // immediately
      res.setHeader(
        "Cache-Control",
        "no-cache, no-store, must-revalidate, max-age=0"
      );
      res.statusCode = 200;
      res.end(urlParsed.query.message);
    } else if (urlParsed.pathname == "/get" && urlParsed.query.variable) {
      try {
        value = fs.readFileSync("./config/" + urlParsed.query.variable);
        res.end(value);
      } catch {
        res.statusCode = 404;
        res.end(urlParsed.query.variable + " not found");
      }
    } else if (urlParsed.pathname == "/env") {
      try {
        res.write(`DEBUG=${process.env.DEBUG}\n`);
        value = fs.readFileSync("./env/env.js", "utf-8");
        //console.log(value);
        res.end(value);
      } catch {
        res.statusCode = 404;
        res.end("env not found");
      }
    } else {
      res.statusCode = 404;
      res.end("Page not found");
    }
  })
  .listen(port, () => {
    console.log(
      `Server running at http://${
        getHostIp(os, "Wi-Fi") || getHostIp(os, "eth0") || "unknown"
      }::${port}/`
    );
  });
