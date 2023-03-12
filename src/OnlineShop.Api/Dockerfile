#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/OnlineShop.Api/OnlineShop.Api.csproj", "src/OnlineShop.Api/"]
COPY ["src/Service/Service.csproj", "src/Service/"]
COPY ["src/Domain/Domain.csproj", "src/Domain/"]
COPY ["src/DatabaseProject/DatabaseProject.csproj", "src/DatabaseProject/"]
COPY ["src/Entities/Entities.csproj", "src/Entities/"]
COPY ["src/Mappers/Mappers.csproj", "src/Mappers/"]
COPY ["src/ViewModels/ViewModels.csproj", "src/ViewModels/"]
RUN dotnet restore "src/OnlineShop.Api/OnlineShop.Api.csproj"
COPY . .
WORKDIR "/src/src/OnlineShop.Api"
RUN dotnet build "OnlineShop.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineShop.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineShop.Api.dll"]