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

## Prerequisite

- .NetCore5.0 SDK
- Visual studio/VS code or similar IDE
- Mac specific: dotnet cli, dotnet ef tools

## Testing steps


## TODO
- Authentication/Authorization: JWT or similar middleware to be added in the service container.Alternatively dotnet entity can be used. 
- Introduce global error handling. This will make controller lean as exception can be thrown from service.
- MediatR pattern can also be considered as an alternative.
- Use Fluent validation in DI.
- Make the domain class auditable (createdBy, updatedBy, createdAt, updatedAt)
- Seed data for developers if new database is created.
- Unit tests