docker-compose -f docker-compose.yml build
docker compose up -d
docker compose down --volumes

docker ps -a
docker exec -it -u root 44f6bf0370f4 /bin/bash

apt-get update && apt-get -y install curl/stable-security
curl -f http://localhost:54816/healthz
