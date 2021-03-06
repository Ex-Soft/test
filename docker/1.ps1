docker volume create my-vol
docker volume ls
docker volume inspect my-vol
docker volume rm my-vol
docker run -it --rm -v ${pwd}:/mnt --name testworkdir testworkdir

docker exec -it confluent /bin/bash

docker ps -a
docker ps -aq
docker stop $(docker ps -aq)

docker images
docker images -q
docker rmi $(docker images -q)
