FROM mcr.microsoft.com/dotnet/core/runtime:3.1

COPY bin/Release/netcoreapp3.1/publish/ /app/
COPY application.json /app/
COPY Static /app/Static
COPY Templates /app/Templates

WORKDIR "/app"

ENTRYPOINT ["dotnet", "ODataApiGen.dll"]