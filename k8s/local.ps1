minikube version
kubectl version
kubectl version --client

minikube start
minikube start --cpus=2 --memory=2gb --disk-size=50gb
minikube start -p MYSUPERCLUSTER

minikube ssh

kubectl get componentstatuses
kubectl cluster-info
kubectl get nodes

minikube stop
minikube delete

%userprofile%\.kube
%userprofile%\.minikube

eksctl version
eksctl create cluster --name MYSUPERCLUSTER
