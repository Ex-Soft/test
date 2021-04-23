cd c:\kafka
bin\windows\zookeeper-server-start.bat config\zookeeper.properties
bin\windows\kafka-server-start.bat config/server.properties
bin\windows\kafka-topics.bat --create --bootstrap-server localhost:9092 --replication-factor 1 --partitions 1 --topic Simple
bin\windows\kafka-topics.bat --list --bootstrap-server localhost:9092
bin\windows\kafka-topics.bat --describe --bootstrap-server localhost:9092 --topic Simple
