from node:latest
workdir /usr/src/app
copy package*.json ./
run npm install
copy server.js ./
run mkdir /usr/src/app/config && mkdir /usr/src/app/env
cmd ["node", "server.js"]
