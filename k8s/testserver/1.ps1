### https://medium.com/faun/hello-world-of-kubernetes-part-1-d1153fc2fc37

### eval $(minikube docker-env) https://stackoverflow.com/questions/38979231/imagepullbackoff-local-repository-with-minikube
docker build --tag testserver .
docker save node | (eval $(minikube docker-env) && docker load)
docker save testserver | (eval $(minikube docker-env) && docker load)

docker run --name testserver --rm -p 1337:1337 testserver
docker ps
docker logs pid
docker exec -it testserver /bin/bash
curl -i localhost:1337/echo?message=message

minikube start
kubectl config get-contexts
kubectl config use-context minikube

kubectl apply -f together.yaml
kubectl get pods
kubectl describe pod/testserver-7c5b96dbff-fwc5b
kubectl get services
kubectl describe service/testserver-entrypoint
kubectl exec --stdin --tty testserver-7c5b96dbff-52mmk -- /bin/bash
kubectl delete -f together.yaml

kubectl apply -f pod.yaml
kubectl apply -f service.yaml
kubectl port-forward -n default service/testserver-service 1337:1337
kubectl describe service/testserver-service
kubectl get ep testserver-service
docker inspect pid
