docker build --tag testworkdir .
docker run -it --rm testworkdir
docker ps -a
docker ps -aq
docker stop $(docker ps -aq)
docker images
docker images -q
docker rmi $(docker images -q)
docker rmi testworkdir