rem http://electron.atom.io/
rem git clone https://github.com/electron/electron-quick-start
rem npm install

rem https://github.com/nodejs/node-gyp
rem npm install -g node-gyp

node-gyp configure

rem https://github.com/bugparty/electron/blob/66e706721e03b44889e3565072307be12e315b62/docs/tutorial/using-native-node-modules.md
node-gyp rebuild --target=1.2.1 --arch=x64 --dist-url=https://atom.io/download/atom-shell

rem npm install

npm start
rem or
rem node_modules\electron-prebuilt\dist\electron.exe .