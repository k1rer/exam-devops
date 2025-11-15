FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем файл проекта и восстанавливаем зависимости
COPY ExamAspNet-WebMarket.csproj .
RUN dotnet restore

# Копируем весь исходный код
COPY . .

# Собираем и публикуем приложение
RUN dotnet publish -c Release -o /app/publish

# Финальный образ
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app

RUN dotnet tool install --global dotnet-ef --version 8.0.0
ENV PATH="$PATH:/root/.dotnet/tools"

COPY --from=build /app/publish .
COPY --from=build /src ./

EXPOSE 8080
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:5000

# Запускаем приложение
ENTRYPOINT ["dotnet", "ExamAspNet-WebMarket.dll"]