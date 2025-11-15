# ASP.NET Core приложение в Kubernetes

## Локальный запуск

```bash
dotnet restore
dotnet run
```

## Развертывание в Kubernetes

```bash
# Применить все манифесты
kubectl apply -f k8s/namespace.yaml
kubectl apply -f k8s/mssql-pvc.yaml, k8s/db-secret.yaml, k8s/sql-server-deployment.yaml
kubectl apply -f k8s/migration-job.yaml  
kubectl apply -f k8s/app-deployment.yaml, k8s/app-service.yaml
```
[![Deploy to Yandex Cloud](https://github.com/k1rer/exam-devops/actions/workflows/main.yml/badge.svg?branch=master)](https://github.com/k1rer/exam-devops/actions/workflows/main.yml)