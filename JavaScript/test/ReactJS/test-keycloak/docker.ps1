/* https://www.keycloak.org/getting-started/getting-started-docker */
/* https://blog.logrocket.com/implement-keycloak-authentication-react/ */
/* https://trigodev.com/blog/how-to-customize-keycloak-themes */
docker run -it --rm --name keycloak -p 8080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:latest start-dev
docker run -it --rm --name keycloak -v /d/temp:/mnt -p 8080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:latest start-dev
/* https://www.keycloak.org/server/features */
docker run -it --rm --name keycloak -v /d/temp:/mnt -p 8080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:latest start-dev --features="preview"

docker run -it --rm --name keycloak -v /d/temp:/mnt -p 8080:8080 -e KEYCLOAK_USER=admin -e KEYCLOAK_PASSWORD=admin -e JAVA_OPTS_APPEND="-Dkeycloak.profile=preview -Dkeycloak.profile.feature.token_exchange=enabled" quay.io/keycloak/keycloak:15.1.0

docker exec -it -u root keycloak /bin/bash

cp -a /mnt/keycloak/. /opt/keycloak/
docker cp -a /d/temp/keycloak/. keycloak:/opt/keycloak/

docker ps -a
docker stop $(docker ps -aq)
