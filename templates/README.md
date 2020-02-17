# pcs-dddapi-api
Backend for the dddapi module in Project Completion System (ProCoSys (PCS)).

It exposes a REST API and is an ASP.NET Core 3.1 application using Entity Framework Core 3.1.

## Notes

### Secrets
Before running the application, some settings need to be set. These are defined in appsettings.json. To avoid the possibility to commit secrets, move parts of the configuration to the secrets.json file on your computer.
Typical settings that should be moved to secrets.json are:
* AD IDs
* Keys
* Local URLs
* Other secrets

### Environment
Set the runtime environment by setting the environment variable ASPNETCORE_ENVIRONMENT on your machine to one of the following:
* Development
* Staging
* Production

If this variable is not set, it will default to Production.

### Migration
When running in development environment, the database is auto-migrated on application startup. This can be changed using the setting in appsettings.development.json.

### Seeding
The datebase can be seeded with test data. To do this, enable the feature in appsettings.development.json and start the application.
>Note: This will run every time the application starts. To avoid multiple seedings, disable the feature after the application has started.

## Visual Studio
### Set secrets
 To open secrets.json, right-click on the startup project and select 'Manage User Secrets'.
### Run

Choose to run as *Equinor.ProcoSys.DDDAPI.WebApi* in the dropdown menu and hit F5.

## Command line
### Set secrets
In folder
```
src\Equinor.Procosys.DDDAPI.WebApi
```
Set secrets using
```console
dotnet user-secrets "<key>" "<value>"
```
### Run
In folder
```
src\Equinor.Procosys.DDDAPI.WebApi
```
run
```console
dotnet run
```

## Docker
### Set secrets
Use either Visual Studio or Command line. Docker-compose is set up to mount the secrets file into the container.
### Run
In folder
```
src\
```
run
```console
docker-compose -f .\Docker-compose.yml -f .\Docker-compose.development.yml up
```
