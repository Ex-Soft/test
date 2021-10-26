docker build --tag testconfigmapserver .

kubectl apply -f config-map.yaml
kubectl describe configmaps
kubectl describe configmap/example-configmap

kubectl create configmap example-configmap-env --from-file=./env.js -o yaml
kubectl describe configmap/example-configmap-env

kubectl apply -f main.yaml

kubectl describe deployments
kubectl describe deployment/testconfigmap

kubectl get services
kubectl describe service/testconfigmap-entrypoint

kubectl get pods
kubectl exec --stdin --tty testconfigmap-7c5b96dbff-52mmk -- /bin/bash

kubectl delete -f main.yaml

docker rmi testconfigmapserver

kubectl delete configmap/example-configmap
kubectl delete configmap/example-configmap-env
