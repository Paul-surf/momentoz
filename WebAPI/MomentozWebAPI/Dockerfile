FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Kopier l�sningsfilen og projektfilerne
COPY ./*.sln .
COPY CustomerData/*.csproj ./CustomerData/
COPY CustomerRestService/*.csproj ./CustomerRestService/
# Kopier andre projektfiler, hvis det er n�dvendigt

# Gendan NuGet-pakker
RUN dotnet restore

# Kopier kildekoden for projekterne
COPY CustomerData/ ./CustomerData/
COPY CustomerRestService/ ./CustomerRestService/
# Kopier andre projektmappe, hvis det er n�dvendigt

# Byg og publicer hovedprojektet
RUN dotnet publish ./CustomerRestService/CustomerRestService.csproj -c Release -o out

# K�r appen i det nye stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "CustomerRestService.dll"]
