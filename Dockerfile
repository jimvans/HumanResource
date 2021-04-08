FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app
COPY HumanResource.WebApi/. ./HumanResource.WebApi/
COPY HumanResource.DataAccess/. ./HumanResource.DataAccess/
COPY HumanResource.Core/. ./HumanResource.Core/
RUN dotnet tool install --global dotnet-ef
WORKDIR "/app/HumanResource.WebApi"
RUN dotnet restore
RUN dotnet build
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh