#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 54411
EXPOSE 62924
EXPOSE 44352

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY CompanyEmployee.API/CompanyEmployee.API.csproj CompanyEmployee.API/
COPY CompanyEmployee.Common/CompanyEmployee.Common.csproj CompanyEmployee.Common/
COPY CompanyEmployee.Data/CompanyEmployee.Data.csproj CompanyEmployee.Data/
COPY CompanyEmployee.Services/CompanyEmployee.Services.csproj CompanyEmployee.Services/
RUN dotnet restore CompanyEmployee.API/CompanyEmployee.API.csproj
COPY . .
WORKDIR /src/CompanyEmployee.API
RUN dotnet build CompanyEmployee.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CompanyEmployee.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CompanyEmployee.API.dll"]
