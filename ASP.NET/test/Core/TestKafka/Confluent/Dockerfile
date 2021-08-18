#https://docs.confluent.io/platform/current/quickstart/ce-quickstart.html#ce-quickstart

### !!!
### Doesn't work!!! Use confluent\cp-all-in-one\docker-compose.yml (https://github.com/confluentinc/cp-all-in-one) instead
### !!!

from ubuntu:latest
env CONFLUENT_HOME=/opt/confluent
env PATH=$PATH:$CONFLUENT_HOME/bin:/opt/confluentcli
run apt-get update && apt-get install -y apt-utils mc && apt-get install -y curl wget openjdk-8-jdk
run curl -o /opt/confluent.tar.gz https://packages.confluent.io/archive/6.1/confluent-6.1.1.tar.gz
run tar -xzf /opt/confluent.tar.gz -C /opt
run rm /opt/confluent.tar.gz
run mv /opt/confluent-6.1.1 /opt/confluent
run mkdir /opt/confluentcli
run curl -L --http1.1 https://cnfl.io/cli | sh -s -- -b /opt/confluentcli
run $CONFLUENT_HOME/bin/confluent-hub install --no-prompt confluentinc/kafka-connect-datagen:latest
entrypoint confluent local services start
