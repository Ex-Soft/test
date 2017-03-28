call ..\..\..\emsdk\emsdk_env
emcc hello_world.c -Os -s WASM=1 -s SIDE_MODULE=1 -o hello_world.wasm