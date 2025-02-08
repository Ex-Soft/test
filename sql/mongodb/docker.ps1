docker images mongo
docker rmi mongo

docker compose up -d
docker compose down --volumes

docker logs mongo

# cd "%ProgramFiles%\mongosh"
cd "$env:ProgramFiles\mongosh"; mongosh "mongodb://root:password@localhost:27017/"
