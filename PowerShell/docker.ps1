docker build --tag confluent .
docker run --rm confluent
docker run -it --rm ubuntu:latest bash
docker ps
docker ps -a
docker ps -aq
docker stop $(docker ps -aq)
docker rm 
docker rm $(docker ps -aq)
docker images
docker rmi
docker rmi $(docker images -q)
docker port control-center
docker inspect control-center
docker inspect --format='{{.Config.ExposedPorts}}' control-center
docker container ls
docker container ls --format "table {{.ID}}\t{{.Names}}\t{{.Ports}}" -a

docker-compouse build
docker-compose up
docker-compose up -d
docker-compose ps
docker-compose down