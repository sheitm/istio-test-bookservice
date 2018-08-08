FROM microsoft/dotnet:2.1-sdk AS build
LABEL maintainer="hafslundnett@hafslundnett.no"
WORKDIR /app
COPY . .
RUN dotnet restore ./Bookservice.csproj \
    && dotnet publish ./Bookservice.csproj -o ./out -c Release

FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Bookservice.dll"]