FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["ODataApiGen.csproj", "."]
RUN dotnet restore "ODataApiGen.csproj"
COPY ["application.json", "."]
COPY ["Program.cs", "."]
COPY ["Renderer.cs", "."]
COPY ["DirectoryManager.cs", "."]
COPY ["NameGenerator.cs", "."]
COPY ["Templates", "Templates/"]
COPY ["Static", "Static/"]
COPY ["Models", "Models/"]
COPY ["Angular", "Angular/"]
COPY ["Extensions", "Extensions/"]
COPY ["Abstracts", "Abstracts/"]
WORKDIR "/src"
RUN dotnet build "ODataApiGen.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ODataApiGen.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal as base
FROM base AS final
WORKDIR /app
COPY --from=publish ["/app/publish", "."]
COPY --from=publish ["/src/Templates", "Templates/"]
COPY --from=publish ["/src/Static", "Static/"]
ENTRYPOINT ["dotnet", "ODataApiGen.dll"]
