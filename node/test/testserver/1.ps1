docker build --tag testserver .
docker run -it --rm -p 3000:3000 --name testserver testserver
docker rmi testserver

docker-compose -f docker-compose.yml build
docker compose up -d
docker compose down --volumes
docker rmi testserver-app
docker rmi testserver-nginx
docker images testserver*
docker images -q testserver*
docker rmi $(docker images -q testserver*)