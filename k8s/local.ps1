minikube version
kubectl version
kubectl version --client

kubectl config view
kubectl config get-contexts
kubectl config use-context docker-desktop

minikube start
minikube start --cpus=2 --memory=2gb --disk-size=50gb
minikube start -p MYSUPERCLUSTER
minikube start --vm=true ## ingress

minikube addons list
minikube addons enable dashboard

minikube dashboard

minikube ssh

kubectl get componentstatuses
kubectl cluster-info
kubectl get nodes
kubectl api-resources
kubectl get pods -n kube-system

kubectl create deployment kubernetes-bootcamp --image=gcr.io/google-samples/kubernetes-bootcamp:v1
kubectl get deployments

kubectl proxy
curl http://localhost:8001/version

kubectl get pods -o go-template --template '{{range .items}}{{.meadata.name}}{{"\n"}}{{end}}'

kubectl describe pods
kubectl describe pod/adjustments-5314-5b4d6b9f6d-cqzw7

kubectl auth can-i --list --namespace=ccapps

curl http://localhost:8001/api/v1/namespaces/default/pods/kubernetes-bootcamp-6f6656d949-cnmbt/proxy/

kubectl exec --stdin --tty adjustments-5314-5b4d6b9f6d-cqzw7 -- /bin/bash

minikube stop
minikube delete

%userprofile%\.kube
%userprofile%\.minikube

eksctl version
eksctl create cluster --name MYSUPERCLUSTER
