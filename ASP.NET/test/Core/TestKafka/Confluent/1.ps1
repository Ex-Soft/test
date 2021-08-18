# https://docs.confluent.io/platform/current/quickstart/ce-docker-quickstart.html#ce-docker-quickstart

docker compose up -d
docker compose stop
docker system prune -a --volumes --filter "label=io.confluent.docker"