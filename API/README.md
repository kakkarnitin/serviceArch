# serviceArch
The attached project is written using clean architecture principles.

The key principles used are as follows:

- Domain driven design
- IOC using DI
- Service layer aka repository pattern
- Code first database design
- SRP


## API Documentation
This project uses swagger and hence all api's are self documenting. The list of API, request and response can be accessed in development mode
on https://localhost:5001/swagger/index.html

Consider all aspects of good software engineering and show us how you'll make it #beautiful and make it a production ready code.

## Docker & K8s

Docker support has been added to the project for ease of containerization.


## Prerequisite

- .NetCore5.0 SDK
- Visual studio/VS code or similar IDE
- Mac specific: dotnet cli, dotnet ef tools ( dotnet tool add --global dotnet-ef )

## Testing steps (Mac with kestrel)
- Clone project from https://github.com/kakkarnitin/serviceArch
- Run dotnet restore
- All pending migrations will be programmatically applied to the database
- Run the app in development page and navigate to https://localhost:5001/swagger/index.html
- The APIs have been documented on the swagger page.

## Migrations
- Change in domain classes will need the new migration
- AddMigration: dotnet ef migrations add -p Persistence -s API InitialSchema  


## TODO
- Authentication/Authorization: JWT or similar middleware to be added in the service container.Alternatively dotnet entity can be used. 
- Introduce global error handling. This will make controller lean as exception can be thrown from service.
- MediatR pattern can also be considered as an alternative for CQRS pattern. 
- Use Fluent validation in DI.
- Make the domain class auditable (createdBy, updatedBy, createdAt, updatedAt)
- Seed data for developers if new database is created.
- Unit tests
- Custom API responses for consistent client experience. 

## Design decisions
- EF Core: EF core offers abstraction over sql queries. Fluent statically typed queries improves development experience. EFCore also
offers smart caching by tracking entities in memory. 
- DDD: Domain driven design helps to get loosely coupled layers for extensibility and maintenance.
- Inversion of control: Out of box support for DI with .NetCore improves coupling. IOC also helps with testability of the code.
- Interface/ Service layer: Makes it easy to swap the service at run time
- ViewModels: Controlling the data over wire and validations
- GET /products & GET /products?name={name} merged into one API 
