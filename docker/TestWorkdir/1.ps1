docker images
docker images --no-trunc
docker images testworkdir
docker images testworkdir:latest
docker images -q
docker images -q testworkdir
docker images -q testworkdir:latest

docker rmi $(docker images -q)
docker rmi $(docker images -q testworkdir)
docker rmi testworkdir

docker build --tag testworkdir .
docker run -it --rm -v ${pwd}:/mnt --name testworkdir testworkdir

docker ps -a
docker ps -a -f "name=testworkdir"
docker ps -aq
docker ps -aq -f "name=testworkdir"

docker stop $(docker ps -aq)
docker stop $(docker ps -aq -f "name=testworkdir")
