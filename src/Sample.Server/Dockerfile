FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY ./ ./

RUN dotnet publish Sample.Server/Sample.Server.csproj -c Release -o out 

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

COPY --from=build /app/out .

# ENV ASPNETCORE_URLS=http://*:5000
# What, if I expose 5000:80 and 5001:80 for 2 services?

ENTRYPOINT ["dotnet", "Sample.Server.dll"]