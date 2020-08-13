docker build --tag testserver .
docker run --name testserver --rm -p 1337:1337 testserver
docker exec -it testserver /bin/bash
curl -i localhost:1337/echo?message=message

kubectl apply -f pod.yaml
