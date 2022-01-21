#!/bin/bash
#
INI_FILE="/etc/sysconfig/iptables"
INI_FILE_BAK=$INI_FILE".bak"

IPT="/sbin/iptables"
IPTS="/sbin/iptables-save"

INTERNET_INTERFACE="eth0"
LOCALNET_INTERFACE="eth1"
LOOPBACK_INTERFACE="lo"

INTERNET_IP="62.244.14.18"
LOCALNET_IP="192.168.0.8"
LOOPBACK_IP="127.0.0.1"

LOCALNET="192.168.0.0/24"
LOCALNET_BROADCAST="192.168.0.255"

INTERNAL_MAILSERVER_IP="192.168.0.3"

if [ -f $INI_FILE ] ; then
  cp $INI_FILE $INI_FILE_BAK
fi

$IPT -F
$IPT -t nat -F
$IPT -t mangle -F

$IPT -X
$IPT -t nat -X
$IPT -t mangle -X

# Policies (default)
$IPT -P INPUT DROP
$IPT -P FORWARD DROP
$IPT -P OUTPUT DROP

# User-defined chain for ACCEPTed TCP packets
$IPT -N okay
$IPT -A okay -p TCP --syn -j ACCEPT
$IPT -A okay -p TCP -m state --state ESTABLISHED,RELATED -j ACCEPT
$IPT -A okay -p TCP -j DROP

# INPUT chain rules

#Rules for incoming packets from LAN
$IPT -A INPUT -p ALL -i $LOCALNET_INTERFACE -s $LOCALNET -j ACCEPT
$IPT -A INPUT -p ALL -i $LOOPBACK_INTERFACE -s $LOOPBACK_IP -j ACCEPT
$IPT -A INPUT -p ALL -i $LOOPBACK_INTERFACE -s $LOCALNET_IP -j ACCEPT
$IPT -A INPUT -p ALL -i $LOOPBACK_INTERFACE -s $INTERNET_IP -j ACCEPT
$IPT -A INPUT -p ALL -i $LOCALNET_INTERFACE -d $LOCALNET_BROADCAST -j ACCEPT

# Rules for incoming packets from Internet
$IPT -A INPUT -p ALL -d $INTERNET_IP -m state --state ESTABLISHED,RELATED -j ACCEPT

# TCP rules
$IPT -A INPUT -p TCP -i $INTERNET_INTERFACE -s 0/0 --destination-port 80 -j okay

# UDP rules
$IPT -A INPUT -p UDP -i $INTERNET_INTERFACE -s 0/0 --destination-port 53 -j ACCEPT
$IPT -A INPUT -p UDP -i $INTERNET_INTERFACE -s 0/0 --destination-port 2074 -j ACCEPT
$IPT -A INPUT -p UDP -i $INTERNET_INTERFACE -s 0/0 --destination-port 4000 -j ACCEPT

# ICMP rules
$IPT -A INPUT -p ICMP -i $INTERNET_INTERFACE -s 0/0 --icmp-type 8 -j ACCEPT
$IPT -A INPUT -p ICMP -i $INTERNET_INTERFACE -s 0/0 --icmp-type 11 -j ACCEPT

# FORWARD chain rules
# Accept the packets we want to forward
$IPT -A FORWARD -s $INTERNAL_MAILSERVER_IP -j ACCEPT
$IPT -A FORWARD -i $LOCALNET_INTERFACE -j ACCEPT
$IPT -A FORWARD -m state --state ESTABLISHED,RELATED -j ACCEPT

# OUTPUT chain rules
# Only output packets with local addresses (no spoofing)
$IPT -A OUTPUT -p ALL -s $LOOPBACK_IP -j ACCEPT
$IPT -A OUTPUT -p ALL -s $LOCALNET_IP -j ACCEPT
$IPT -A OUTPUT -p ALL -s $INTERNET_IP -j ACCEPT

# PREROUTING chain rules
$IPT -t nat -A PREROUTING -i $INTERNET_INTERFACE -p TCP -d $INTERNET_IP --dport smtp -j DNAT --to-destination $INTERNAL_MAILSERVER_IP

# POSTROUTING chain rules
$IPT -t nat -A POSTROUTING -o $INTERNET_INTERFACE -j SNAT --to-source $INTERNET_IP

$IPTS > $INI_FILE

case "$1" in
  restart)
    /etc/init.d/iptables restart
  ;;
esac
