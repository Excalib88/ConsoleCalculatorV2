FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ConsoleCalculatorV2/ConsoleCalculatorV2.csproj", "ConsoleCalculatorV2/"]
RUN dotnet restore "ConsoleCalculatorV2/ConsoleCalculatorV2.csproj"
COPY . .
WORKDIR "/src/ConsoleCalculatorV2"
RUN dotnet build "ConsoleCalculatorV2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConsoleCalculatorV2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsoleCalculatorV2.dll"]
