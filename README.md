Origin Backend Take-Home Assignment
=====================
## The architecture:
The solution basically has two layers, **RiskProfile.Web** and **RiskProfile.Domain**.
- **RiskProfile.Web** this layer is kept thin. It does not contain business rules or knowledge, but only coordinates tasks and delegates work to collaborations of domain objects in the next layer down. 
- **RiskProfile.Domain** is responsible for representing concepts of the business, information about the business situation, and business rules.

I used the **Chain of Responsibility** design pattern as the basis for creating the project core.
I don't implement the pattern exactly as some literature says, I just used it as a base and adapted the reality I needed.

 The **Chain of Responsibility** is based on transforming certain behaviors into solitary objects called handlers.
 The pattern suggests that the handler has a method to do the processing that receives an object and that you connect those handlers to a chain,
 each handler has a field to store a reference to the next handler in the chain.
 In addition to processing the object, handlers pass it on in the chain.
 The object travels through the chain until all the handlers have had a chance to process it.
 a handler may decide not to forward the request to the chain and effectively stop any further processing.
  
 I extract each risk score calculation rule for a class that inherits `IRule`, 
 the `IRule` requires implementing the `CalculateRiskScore(Customer customer, LineInsure lineInsure)` that receives a `Customer` and `LineInsure` as a parameter for calculating the score.
 `RulesHandler` is responsible for handling the processing and chaining of Rules, if `LineInsure` becomes **ineligible** `RulesHandler` will break the chain.

## How to use (locally):
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
