ARG VERSION
ARG DOTNET_HTTPS_PORT

FROM mcr.microsoft.com/dotnet/sdk:${VERSION}

RUN apt-get update && \
    apt-get install -y nodejs make

WORKDIR /app

RUN dotnet tool install --global dotnet-ef && \
    echo export PATH="$PATH:/root/.dotnet/tools" >> ~/.bashrc

CMD dotnet run --urls=https://+:${DOTNET_HTTPS_PORT} --project=MessageHub.Api

EXPOSE ${DOTNET_HTTPS_PORT}