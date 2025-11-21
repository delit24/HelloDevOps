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

## CI/CD - Docker Build és Deploy

A projekt Docker image-ei manuális build és deploy folyamattal kerülnek a Docker Hub-ra.

### Build és Deploy folyamat

1. **Docker image készítése:

docker build -t delit24/hellodevops:main .

2. **Docker Hub bejelentkezés:**
docker login -u delit24

3. **Image publikálása Docker Hub-ra:**

docker push delit24/hellodevops:main


### Docker image használata

A publikus image letölthető és futtatható:
```bash
# Image letöltése Docker Hub-ról
docker pull delit24/hellodevops:main

# Konténer futtatása
docker run -d -p 8080:8080 delit24/hellodevops:main
```

Az alkalmazás elérhető: http://localhost:8080

### Docker Hub repository

Az image publikusan elérhető:
- Docker Hub: https://hub.docker.com/r/delit24/hellodevops
- Image név: `delit24/hellodevops:main`


HelloDevOps/
├── .github/workflows/     # CI/CD pipeline
├── HelloDevOps/           # Web API projekt
│   ├── Controllers/       # API kontrollerek
│   └── Program.cs         # Alkalmazás belépési pont
├── Dockerfile             # Docker konfiguráció
├── .dockerignore
└── README.md
