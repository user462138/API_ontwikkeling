
using Microsoft.Extensions.Hosting;
using RestaurantMinimalAPI.Models;
using RestaurantPersonDI.Services;

namespace RestaurantMinimalAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IRestaurantService, RestaurantService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

            //app.Run();

            ///////////////////////////////////////////////



            app.MapGet("/posts", async (IRestaurantService restaurantService) =>
            {
                var posts = await restaurantService.GetAllRestaurants();
                return posts;
            }).WithName("GetPosts").WithOpenApi().WithTags("Posts");
            app.MapGet("/posts/{id}", async (IRestaurantService restaurantService, int id) =>
            {
                var post = await restaurantService.GetRestaurantById(id);
                return post == null ? Results.NotFound() : Results.Ok(post);
            }).WithName("GetPost").WithOpenApi().WithTags("Posts");
            app.MapPost("/posts", async (IRestaurantService restaurantService, Restaurant restaurant) =>
            {
                var createdPost =  restaurantService.CreateRestaurant(restaurant);
                return Results.Created($"/posts/{createdPost.Id}", createdPost);
            }).WithName("CreatePost").WithOpenApi().WithTags("Posts");
            app.MapPut("/posts/{id}", async (IRestaurantService restaurantService, int id, Restaurant restaurant) =>
            {
                try
                {
                    var updatedRestaurant = await restaurantService.UpdateRestaurant(id, restaurant);
                    return Results.Ok(updatedRestaurant);
                }
                catch (KeyNotFoundException)
                {
                    return Results.NotFound();
                }
            }).WithName("UpdatePost").WithOpenApi().WithTags("Posts");
            app.MapDelete("/posts/{id}", async (IRestaurantService restaurantService, int id) =>
            {
                try
                {
                    await restaurantService.DeleteRestaurant(id);
                    return Results.NoContent();
                }
                catch (KeyNotFoundException)
                {
                    return Results.NotFound();
                }
            }).WithName("DeletePost").WithOpenApi().WithTags("Posts");

            app.Run();




        }
    }
}
