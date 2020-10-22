### https://github.com/thaJeztah/pgadmin4-docker

### --driver, -d Default: bridge Driver to manage the Network
docker network create pg

### Detached (-d)
### ENV (environment variables) (-e)
### Clean up (--rm)
docker run -d -e POSTGRES_PASSWORD=pessword --network=pg -p 5432:5432 --name postgres postgres:latest
docker run --rm -d -p 5050:5050 --name pgadmin --network=pg thajeztah/pgadmin4
