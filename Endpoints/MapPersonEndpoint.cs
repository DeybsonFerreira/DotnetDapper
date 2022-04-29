using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
public static class MapPersonEndpoint
{
    public static void AddPersonEndpoint(this WebApplication app)
    {
        app.MapGet("/person", async ([FromServices] IPersonRepository personRepository) =>
          {
              return await personRepository.GetAllAsync();
          });

        app.MapGet("/person/{id}", async ([FromServices] IPersonRepository personRepository, int id) =>
          {
              return await personRepository.GetAsync(id);
          });

        app.MapDelete("/person/{id}", async ([FromServices] IPersonRepository personRepository, int id) =>
        {
            await personRepository.DeleteAsync(id);
            return Results.Ok();
        });

        app.MapPost("/person", async ([FromServices] IPersonRepository personRepository, Person person) =>
         {
             int? id = await personRepository.AddAsync(person);
             return Results.Created($"/person/{id}", person);
         });

        app.MapPut("/person", async ([FromServices] IPersonRepository personRepository, int Id, Person person) =>
        {
            Person personDb = await personRepository.GetAsync(Id);
            if (personDb is null)
                return Results.NotFound();

            //change model
            personDb.FirstName = person.FirstName;
            personDb.LastName = person.LastName;

            var modelUpdated = await personRepository.UpdateAsync(personDb);
            return Results.Ok();
        });
    }
}
