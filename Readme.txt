#1> dotnet new webapp

#2> instalar dependencias

# :: Packages ::
dotnet add package Dapper 
dotnet add package System.Data.SqlClient
dotnet add package Dapper.Contrib
dotnet add package Swashbuckle.AspNetCore

#3> Adicionar pastas/arquivos
-Data 
------Person"
------BaseData"

Interfaces
------IPersonRepository
------IBaseRepository

Repository
------PersonRepository
------BaseRepository

Endpoints
------MapPersonEndpoint

ExtensionProgram > "Adicionar no Program"
------SwaggerExtension 
------EndpointExtension 
------DependencyInjectionExtension 

#4 > Banco de dados SQL
- Criar Database
- Adicionar connectionString no appsettings.json

/********** script  ************************/
CREATE TABLE Person (
    Id int IDENTITY(1,1) PRIMARY KEY,
    LastName varchar(255),
    FirstName varchar(255),
    Email varchar(255)
);
