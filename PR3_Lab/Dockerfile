# Этап сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Копируем все проекты
COPY PR3_Lab.sln ./
COPY PR3_Lab.Client/ PR3_Lab.Client/
COPY PR3_Lab/ PR3_Lab/


# Восстановление зависимостей
WORKDIR /app/PR3_Lab
RUN dotnet restore

# Сборка и публикация
RUN dotnet publish -c Release -o /app/publish

# Финальный образ
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Открываем порт
EXPOSE 8080
ENTRYPOINT ["dotnet", "PR3_Lab.dll"]
