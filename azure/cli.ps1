az config set extension.use_dynamic_install=yes_without_prompt

az account set --subscription [subscription]

az login

az storage account show --resource-group [resource-group] --name [account-name]
az storage account show --resource-group [resource-group] --name [account-name]

az storage account keys list --resource-group [resource-group] --account-name [account-name]
az storage account keys list -g [resource-group] -n [account-name]
az storage account keys list --resource-group [resource-group] --account-name [account-name]

az storage file list --share-name [share-name] --account-name [account-name]
az storage file list --share-name [share-name] --account-name [account-name] --account-key "account-key"
az storage file list --share-name [share-name] --account-name [account-name] --account-key "account-key"

az storage file download --path "full-file-name" --share-name [share-name] --account-name [account-name] --dest "d:\temp\azure\styles.css"
az storage file download-batch --source "path" --dest "d:\temp\azure" --account-name [account-name] --account-key "account-key"

az storage blob download --file "TestImage3.jpg" --container-name [container-name] --account-name [account-name] --name "58f1cbe1-43ce-4997-86d8-dfa72b17ae6e@TestImage3.jpg" --account-key "account-key"
az storage blob download --file "Test.pdf" --container-name [container-name] --account-name [account-name] --name "703b6279-c911-407d-9ae3-5aa95a08839a@Test.pdf" --account-key "account-key"

az servicebus topic subscription show --resource-group [resource-group] --namespace-name [namespace-name] --topic-name processorder --subscription-name processorder
az servicebus topic subscription show --resource-group [resource-group] --namespace-name [namespace-name] --topic-name processorder-stg --subscription-name processorder
az servicebus namespace authorization-rule keys list --resource-group [resource-group] --namespace-name [namespace-name] --name "RootManageSharedAccessKey" --query "primaryConnectionString" --output tsv
az servicebus namespace authorization-rule keys list --resource-group [resource-group] --namespace-name [namespace-name] --name "RootManageSharedAccessKey" --query "primaryConnectionString"

az aks command invoke --resource-group [resource-group] --name [kubernetes-service-name] --command "kubectl get pods --namespace staging"
az aks command invoke --resource-group [resource-group] --name [kubernetes-service-name] --command "kubectl describe deployment consumer-process-order --namespace staging"
az aks command invoke --resource-group [resource-group] --name [kubernetes-service-name] --command "kubectl describe pod consumer-process-order-64d9f9f887-2bz5k --namespace staging"
az aks command invoke --resource-group [resource-group] --name [kubernetes-service-name] --command "kubectl exec consumer-process-order-64d9f9f887-2bz5k --namespace staging -- printenv"
