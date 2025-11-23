# Hello DevOps - .NET Web API

Ez egy egyszerű ASP.NET Core Web API alkalmazás, amelynek célja a modern DevOps folyamatok (Dockerizálás, CI/CD pipeline, Registry publikálás) gyakorlati bemutatása.

## Technológiák

- .NET 8.0 - Alkalmazás keretrendszer
- Docker - Konténerizáció
- GitLab CI/CD - Automatizált build és deploy folyamatok
- Docker Hub - Container Registry (képtároló)

## Kezdeti lépések (Nulláról indulóknak)

Ha szeretnéd a gépeden futtatni a projektet, kövesd az alábbi lépéseket.

### 1. Előfeltételek telepítése
Győződj meg róla, hogy ezek telepítve vannak a gépeden:
- Git (Verziókezelő)
- .NET 8.0 SDK (Fejlesztői környezet)
- Docker Desktop (Konténer futtató)

### 2. A kód letöltése
Nyiss egy terminált (vagy parancssort), és töltsd le a projektet:

git clone https://github.com/delit24/HelloDevOps.git
cd HelloDevOps

## Futtatás helyileg (Két lehetőség)

A projektet kétféleképpen futtathatod: fejlesztőként (.NET) vagy izolált környezetben (Docker).

### "A" opció: Futtatás fejlesztőként (.NET)
Ha módosítani szeretnéd a kódot, ezt a módot használd.

# 1. Függőségek helyreállítása
dotnet restore

# 2. Projekt buildelése
dotnet build --configuration Release

# 3. Alkalmazás indítása
dotnet run --project HelloDevOps/HelloDevOps.csproj

Elérhetőség:
- Swagger UI (Dokumentáció): http://localhost:8080/swagger
- API végpont: http://localhost:8080/api/hello

### "B" opció: Futtatás Dockerrel (Helyi teszt)
Ha azt szeretnéd tesztelni, hogyan futna az alkalmazás szerver környezetben.

# 1. Image (képfájl) elkészítése
docker build -t hello-devops:local .

# 2. Konténer indítása a háttérben (-d)
docker run -d -p 8080:8080 --name hello-devops-container hello-devops:local

Elérhetőség: http://localhost:8080/swagger

Takarítás (Leállítás és törlés):
docker stop hello-devops-container
docker rm hello-devops-container

## CI/CD - Automatizált Folyamat

Ez a projekt demonstrálja a teljesen automatizált DevOps életciklust.
Nem szükséges manuálisan buildelni vagy pusholni a Docker Hub-ra, a rendszer elvégzi helyetted.

Hogyan működik?
1. A fejlesztő módosít a kódon és pusholja a main branch-re.
2. A GitLab CI/CD érzékeli a változást és elindít egy pipeline-t.
3. A szerver automatikusan lebuildeli az új Docker image-et.
4. Sikeres build esetén feltölti azt a Docker Hub-ra.

## A kész, publikus alkalmazás kipróbálása

Bárki (akinek nincs meg a forráskód) futtathatja a kész alkalmazást az alábbi paranccsal:

# A legfrissebb verzió letöltése és indítása egy lépésben
docker run -d -p 8080:8080 --name hellodevops delit24/hellodevops:latest

Docker Hub link: https://hub.docker.com/r/delit24/hellodevops

## API Végpontok

Az alkalmazás az alábbi végpontokat nyújtja:

GET /api/hello
- Leírás: Egyszerű üdvözlő üzenetet ad vissza.

GET /api/hello/version
- Leírás: Kiírja az alkalmazás verzióját és a környezetet.

GET /api/hello/health
- Leírás: Health check (állapotellenőrzés) végpont.

## Projekt Struktúra

HelloDevOps/
├── HelloDevOps/           # A Web API forráskódja
│   ├── Controllers/       # API végpontok logikája
│   └── Program.cs         # Alkalmazás belépési pontja
├── .gitlab-ci.yml         # GitLab CI/CD konfiguráció
├── Dockerfile             # Docker image leírása
├── .dockerignore          # Fájlok, amik nem kerülnek a konténerbe
├── .gitignore             # Fájlok, amik nem kerülnek a Git-be
└── HelloDevOps.sln        # Visual Studio solution fájl

## Git Workflow

A projekt egyszerűsített Trunk-Based Development modellt követ:
- main: Ez a stabil ág, ami mindig kikerül élesbe (Docker Hub).
- development: Ideiglenes ágak fejlesztésre, melyek azonnal merge-ölésre kerülnek a main-be.

-------------Amit a PDF be is leirtam, cask itt természetesen képek nélkül:
Deli Tamás (neptun: L5JUPS) DevOps feladat
Githubon létrehoztam egy publikus repository:
https://github.com/delit24/HelloDevOps/tree/main
melyet le cloneoztam és visual studioban létre hoztam benne egy .net 8 web api projektet.
Ezt követően csináltam egy development branch-et , melyben elvégeztem pár módositást
és becommitoltam majd felpusholtam, majd mergeltem a mainre, majd vissza a dev-re ott
hozzá adtam a docker filet majd a .dockerignore filet, megirtam adocker filet, amjd
futtattam a docker buildet cmd ben ami megcsinálta az imagest, majd elinditottam
acontanert és betöltődik rendesen és fut az alkalmazás.
A részletesebb leirás az sln file-al egy mappában a readme.txt ben található
Majd docker hub ra deployoltam:
https://hub.docker.com/r/delit24/hellodevops
Ha leszedted konténerbe az imaget, akkor cmd be mehet az indótó parancs:
docker run -d -p 8080:8080 --name hellodevops delit24/hellodevops:main
majd böngésző:
http://localhost:8080/swagger/index.html
dockerhubra igy ment fel:
docker build -t delit24/hellodevops:main .
docker push delit24/hellodevops:main
friss lehúzása: docker pull delit24/hellodevops:main
------------------------------------------------------------------------------------------------------------------
Kötelezően választható feladat:
Itt gitlab-on keresztül csináltam meg ateljesen automatizált deploy-t, annyi, hogy igy, akkor
2 helyre pusholok github-ra és gitlab-ra is egyszerre. Lehetne mirrorrolni, de az cask a
fizetős gitlab verzióban elérhető, viszont lemegy a teljes folymat. Push a mainbe majd a
dockerhubomon megjelenik. Lentebb képek csatolva mindenről.
https://gitlab.com/delit24/HelloDevOps/
docker stop hellodevops
docker rm hellodevops
docker rmi delit24/hellodevops:latest
docker pull delit24/hellodevops:latest
docker run -d -p 8080:8080 --name hellodevops delit24/hellodevops:latest
