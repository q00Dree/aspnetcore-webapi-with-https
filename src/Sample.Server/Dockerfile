FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY ./ ./

RUN dotnet publish Sample.Server/Sample.Server.csproj -c Release -o out 

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

COPY --from=build /app/out .

# By default, ASPNETCORE uses port 80, but if you need to expose an other port, like 5000, 
# you should use line below or use method webBuilder.UseUrls(urls: "http://0.0.0.0:5000") in Program.cs, while configuring IHostBuilder or configure Kestrel in appsettings.json

# ENV ASPNETCORE_URLS=http://0.0.0.0:5000

ENTRYPOINT ["dotnet", "Sample.Server.dll"]

# No need to expose port 5000, because we do this in docker-compose.yml file. 
# If you run 'docker build' with this file so you can uncomment line below or use -p flag instead. 

# EXPOSE 5000