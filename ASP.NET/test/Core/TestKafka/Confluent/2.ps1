### !!!
### Doesn't work!!! Use confluent\cp-all-in-one\docker-compose.yml (https://github.com/confluentinc/cp-all-in-one) instead
### !!!

docker build --tag confluent .
docker run -it --rm -p 9092:9092 -p 9101:9101 --name confluent confluent
docker exec -it confluent /bin/bash
