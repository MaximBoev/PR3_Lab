# ���� ������
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# �������� ��� �������
COPY PR3_Lab.sln ./
COPY PR3_Lab.Client/ PR3_Lab.Client/
COPY PR3_Lab/ PR3_Lab/


# �������������� ������������
WORKDIR /app/PR3_Lab
RUN dotnet restore

# ������ � ����������
RUN dotnet publish -c Release -o /app/publish

# ��������� �����
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# ��������� ����
EXPOSE 8080
ENTRYPOINT ["dotnet", "PR3_Lab.dll"]
