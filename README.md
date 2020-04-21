Origin Backend Take-Home Assignment
=====================

## How to use:
- You will need the latest Visual Studio 2019 and the latest .NET Core SDK.
- The latest SDK and tools can be downloaded from https://dot.net/core.

Also you can run the project in Visual Studio Code (Windows, Linux or MacOS).

To know more about how to setup your enviroment visit the [Microsoft .NET Download Guide](https://www.microsoft.com/net/download)

## Technologies implemented:

- ASP.NET Core 3.1 (with .NET Core 3.1) 
- Swagger UI

## It is online:
- The API be available at <a href="https://originbackendtakehomeassignmen.azurewebsites.net" target="_blank">Azure</a>.

- The documentation be available at <a href="https://originbackendtakehomeassignmen.azurewebsites.net/api/swagger/index.html" target="_blank">Swagger</a>.

### Running the API on Docker
`docker-compose up web`

- The API will be available at: [http://localhost:9090/](http://localhost:9090/) 

- The documentation will be available at : [http://localhost:9090/api/swagger/index.html](http://localhost:9090/api/swagger/index.html)

### Running the unit tests on Docker

`docker-compose build test-domain`

### Running the integration tests on Docker

`docker-compose build test-web`
