#https://github.com/dotnet/dotnet-docker/tree/master/samples/aspnetapp

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

COPY . .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet [THE NAME OF YOUR FILE].dll