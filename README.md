# ASP.NET Core приложение в Kubernetes

## Локальный запуск
```bash
dotnet restore
dotnet run

## Развертывание в Kubernetes
'''bash
# Применить все манифесты
kubectl apply -f k8s/namespace.yaml
kubectl apply -f k8s/mssql-pvc.yaml, k8s/db-secret.yaml, k8s/sql-server-deployment.yaml
kubectl apply -f k8s/migration-job.yaml  
kubectl apply -f k8s/app-deployment.yaml, k8s/app-service.yaml