# BackEndChallengeTest

## Description
BackEndChallengeTest is a backend project developed using Visual Studio with .NET 6 and ASP.NET Core. The project follows the CQRS architecture with the Mediator pattern, using Dapper as the ORM.

## Project Structure
The project is organized into the following folders:

1. **Services**:
    - Contains the `Controller`, `Program`, and `Startup` of the project.

2. **Domain**:
    - Contains the `Commands` and `Queries` representing the business rules.
    - `Commons`: Common entities that can be used in other files.
    - `Entities`: Contains the project's entities.
    - Validation to check if a subject exists or not, based on the ID (different from "0").

3. **Infrastructure**:
    - **Crosscutting**:
        - Contains the `IoC` file for dependency injection.
    - **Data**:
        - Contains the repositories and the connection configuration to get the connection string from the machine's environment variable.

4. **Tests**:
    - Contains the unit tests, using `xUnit` and `Moq`.

## Technologies Used
- .NET 6
- ASP.NET Core
- CQRS with MediatR
- Dapper (ORM)
- xUnit (for testing)
- Moq (for mocking in tests)


This is the Sql Script -
CREATE TABLE TaskManagement (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(100) NOT NULL,
    Date DATE NOT NULL,
    StartTime NVARCHAR(10) NOT NULL,
    EndTime NVARCHAR(10) NOT NULL,
    Subject NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    RegistrationDate DATETIME NOT NULL,
    LastModifiedDate DATETIME NULL,
    RemovalDate DATETIME NULL,
    RegisteredByUserId INT NOT NULL,
    ModifiedByUserId INT NULL,
    RemovedByUserId INT NULL
);