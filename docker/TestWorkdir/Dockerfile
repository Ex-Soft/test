# https://docs.docker.com/develop/develop-images/dockerfile_best-practices/

from fedora:latest
run dnf install -y gcc-c++ make mc
run mkdir /root/victim
run mkdir /root/victim/cpp
copy --chown=root:root *.txt /root/victim/
copy --chown=root:root cpp /root/victim/cpp
run cd /root/victim/cpp && make && make clean
workdir /root/victim
entrypoint mc
