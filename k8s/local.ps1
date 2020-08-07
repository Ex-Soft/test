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

kubectl create deployment kubernetes-bootcamp --image=gcr.io/google-samples/kubernetes-bootcamp:v1
kubectl get deployments

kubectl proxy
curl http://localhost:8001/version

kubectl get pods -o go-template --template '{{range .items}}{{.meadata.name}}{{"\n"}}{{end}}'

kubectl describe pods

curl http://localhost:8001/api/v1/namespaces/default/pods/kubernetes-bootcamp-6f6656d949-cnmbt/proxy/

minikube stop
minikube delete

%userprofile%\.kube
%userprofile%\.minikube

eksctl version
eksctl create cluster --name MYSUPERCLUSTER
