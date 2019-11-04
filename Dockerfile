FROM mcr.microsoft.com/dotnet/core/runtime:2.2

COPY bin/Release/netcoreapp2.2/publish/ /app/
COPY application.json /app/
COPY Static /app/Static
COPY Templates /app/Templates

WORKDIR "/app"

ENTRYPOINT ["dotnet", "ODataApiGen.dll"]