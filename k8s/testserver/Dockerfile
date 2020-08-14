from node:latest
workdir /usr/src/app
copy package*.json ./
run npm install
copy . .
cmd ["node", "server.js"]
