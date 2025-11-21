# Hello DevOps - .NET Web API

Egyszerű ASP.NET Core Web API alkalmazás DevOps alapok bemutatására.

## Technológiák

- .NET 8.0
- ASP.NET Core Web API
- Docker
- GitHub Actions (CI/CD)

## Követelmények

- .NET 8.0 SDK
- Docker Desktop
- Git

## Build és futtatás

# Projekt buildelése
dotnet build --configuration Release

# Alkalmazás futtatása
dotnet run --project HelloDevOps/HelloDevOps.csproj


Elérhetőség:
- HTTP: http://localhost:8080
- HTTPS: https://localhost:8081
- Swagger: http://localhost:8080

### Docker

Image készítése:

docker build -t hello-devops:v1 .

Konténer futtatása:
docker run -d -p 8080:8080 --name hello-devops hello-devops:v1

Elérhetőség: http://localhost:8080

Konténer leállítása:

docker stop hello-devops
docker rm hello-devops


## API végpontok

**GET /api/hello**
Visszaad egy üdvözlő üzenetet.

**GET /api/hello/version**
Az alkalmazás verziószámát és környezeti információkat ad vissza.

**GET /api/hello/health**
Health check végpont.

## Git workflow

A projekt trunk-based development modellt követ:
- main branch: stabil, production-ready kód
- development/* branchek: új funkciók fejlesztése
- development branchek merge után azonnal integrálódnak a main-be

## CI/CD

A projekt GitHub Actions-t használ a folyamatos integrációhoz. Minden push és pull request esetén:
1. Build a .NET alkalmazásból
2. Docker image készítése
3. Image publikálása a GitHub Container Registry-be

Image letöltése:
docker pull ghcr.io/USERNAME/hellodevops:main
docker run -p 8080:8080 ghcr.io/USERNAME/hellodevops:main



HelloDevOps/
├── .github/workflows/     # CI/CD pipeline
├── HelloDevOps/           # Web API projekt
│   ├── Controllers/       # API kontrollerek
│   └── Program.cs         # Alkalmazás belépési pont
├── Dockerfile             # Docker konfiguráció
├── .dockerignore
└── README.md
