# https://docs.docker.com/docker-for-windows/kubernetes/
docker stack deploy --compose-file ./docker-compose.yml mystack
docker stack deploy --namespace my-app --compose-file ./docker-compose.yml mystack
docker stack rm mystack

# https://docs.docker.com/get-started/kube-deploy/
# https://kubernetes.io/docs/reference/kubectl/kubectl/
kubectl apply -f bb.yaml
kubectl delete -f bb.yaml

kubectl cluster-info

kubectl api-resources
kubectl get deployments
kubectl get componentstatuses
kubectl get nodes
kubectl get services
kubectl get pods
kubectl get pods -o wide

