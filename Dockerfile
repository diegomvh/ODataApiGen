FROM mcr.microsoft.com/dotnet/runtime:3.1 as base
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ODataApiGen.csproj", "."]
RUN dotnet restore "ODataApiGen.csproj"
COPY ["application.json", "."]
COPY ["Program.cs", "."]
COPY ["Renderer.cs", "."]
COPY ["DirectoryManager.cs", "."]
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

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ODataApiGen.dll"]