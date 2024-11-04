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

kubectl config use-context aws_nonprod_west_hydrogen
kubelogin login aws-nonprod

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

kubectl rollout restart deployment
kubectl scale deployment purchasehistory-staging --replicas=0
kubectl scale deployment purchasehistory-staging --replicas=2

kubectl delete pod xxx --now

az login
az account set --subscription [subscription-id]
az aks get-credentials --resource-group [resource-group-name] --name [aks-cluster-name] --admin
az aks command invoke --resource-group [resource-group-name] --name [aks-cluster-name] --command "kubectl get pods --all-namespaces"
az aks command invoke --resource-group [resource-group-name] --name [aks-cluster-name] --command "kubectl get pods --namespace=production"
az aks command invoke --resource-group [resource-group-name] --name [aks-cluster-name] --command "kubectl get pod user-svc-85b67c6c77-shlpk --namespace development --output=yaml"
az aks command invoke --resource-group [resource-group-name] --name [aks-cluster-name] --command "kubectl logs user-svc-85b67c6c77-shlpk --namespace development"
az aks command invoke --resource-group [resource-group-name] --name [aks-cluster-name] --command "kubectl rollout restart deployment keycloak --namespace=production"
az aks command invoke --resource-group [resource-group-name] --name [aks-cluster-name] --command "kubectl exec --stdin --tty keycloak-b64f778d7-m78hs --namespace=production -- /bin/bash"
az aks command invoke --resource-group [resource-group-name] --name [aks-cluster-name] --command "kubectl exec keycloak-7cfcfc6494-28zlc --namespace=production -- env"
az aks command invoke --resource-group [resource-group-name] --name [aks-cluster-name] --command "kubectl exec keycloak-7cfcfc6494-28zlc --namespace=production -- ls -lrta /opt/jboss/keycloak/standalone/log"
az aks command invoke --resource-group [resource-group-name] --name [aks-cluster-name] --command "kubectl cp production/keycloak-7cfcfc6494-28zlc:/opt/jboss/keycloak/standalone/log/server.log keycloakserver.log" --file .
