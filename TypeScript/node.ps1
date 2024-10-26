/*
https://khalilstemmler.com/blogs/typescript/node-starter-project/
https://www.digitalocean.com/community/tutorials/typescript-new-project
https://www.digitalocean.com/community/tutorials/setting-up-a-node-project-with-typescript
*/

npm init -y
npm install typescript --save-dev
npx tsc --init
npx tsc --init --rootDir src --outDir out --target es6 --sourceMap
