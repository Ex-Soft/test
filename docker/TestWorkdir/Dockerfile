# https://docs.docker.com/develop/develop-images/dockerfile_best-practices/
from fedora:latest
run dnf install -y mc
run mkdir victim
copy --chown=root:root *.txt /root/victim/
workdir /root/victim
