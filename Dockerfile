FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish real-time-chat.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/runtime:10.0 AS final

RUN apt-get update && apt-get install -y wget && \
    wget -q https://github.com/tsl0922/ttyd/releases/latest/download/ttyd.x86_64 -O /usr/local/bin/ttyd && \
    chmod +x /usr/local/bin/ttyd && \
    apt-get clean

WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 7681

ENTRYPOINT ["ttyd", "--writable", "dotnet", "real-time-chat.dll"]