FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY Tests/ ./Tests/
RUN dotnet restore Tests/Tests.csproj
ENTRYPOINT ["dotnet", "test", "Tests/Tests.csproj", "--no-restore"]
