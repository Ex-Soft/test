FROM node:23-alpine AS builder
WORKDIR /app
RUN apk --no-cache add curl
COPY package.json ./package.json
RUN npm install
COPY ./*.js ./.env ./
COPY ./config ./config
COPY ./env ./env
EXPOSE 3000
ENTRYPOINT [ "node", "--env-file=.env", "./server.js" ]
