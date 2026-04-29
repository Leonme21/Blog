FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar todos los archivos de proyecto
COPY ["PersonalBlog.API/PersonalBlog.API.csproj", "PersonalBlog.API/"]
COPY ["PersonalBlog.Application/PersonalBlog.Application.csproj", "PersonalBlog.Application/"]
COPY ["PersonalBlog.Domain/PersonalBlog.Domain.csproj", "PersonalBlog.Domain/"]
COPY ["PersonalBlog.Infrastructure/PersonalBlog.Infrastructure.csproj", "PersonalBlog.Infrastructure/"]

# Restaurar dependencias
RUN dotnet restore "PersonalBlog.API/PersonalBlog.API.csproj"

# Copiar todo el código fuente
COPY . .

# Compilar y publicar
WORKDIR "/src/PersonalBlog.API"
RUN dotnet publish "PersonalBlog.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagen final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PersonalBlog.API.dll"]
