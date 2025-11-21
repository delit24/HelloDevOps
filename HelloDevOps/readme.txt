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

A projekt GitHub Actions-t használ a folyamatos integrációhoz és Docker image publikáláshoz.

### Pipeline működése

Minden push vagy pull request esetén automatikusan:
1. .NET alkalmazás buildelése
2. Tesztek futtatása
3. Docker image készítése
4. Image publikálása a Docker Hub-ra

### Docker image használata

A builded image-ek a Docker Hub-on érhetők el:
# Image letöltése
docker pull tamasdeli/hellodevops:main

# Futtatás
docker run -p 8080:8080 tamasdeli/hellodevops:main

Elérhető tag-ek:
- `main` - legfrissebb main branch build
- `<branch-name>` - egyéb branch-ek
- `main-<commit-sha>` - konkrét commit



HelloDevOps/
├── .github/workflows/     # CI/CD pipeline
├── HelloDevOps/           # Web API projekt
│   ├── Controllers/       # API kontrollerek
│   └── Program.cs         # Alkalmazás belépési pont
├── Dockerfile             # Docker konfiguráció
├── .dockerignore
└── README.md
