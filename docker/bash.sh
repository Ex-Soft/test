hostname -i
hostname -i | awk '{print $1}'
ip a show eth0
ip -4 -o address
ip a show eth0 | grep -Po 'inet \K[\d.]+'
