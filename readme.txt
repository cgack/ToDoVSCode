to create an EF core app with sqlite

> dotnet new console


// could use inMemoryDB
> dotnet add package Microsoft.EntityFrameworkCore.InMemory

// Install EF core Sqlite provider
> dotnet add package Microsoft.EnitityFrameworkCore.Sqlite

// Then we'll make our model and context
TodoContext.cs  
TodoItem.cs

// Then we need to migrate the database if we use sqlite

> dotnet tool install --global dotnet-ef
> dotnet add package Microsoft.EntityFrameworkCore.Design
> dotnet ef migrations add InitialCreate
> dotnet ef database update


// run it  
dotnet run