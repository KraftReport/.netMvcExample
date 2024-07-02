
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TrainingApi.Data;
using TrainingApi.Features.Book;
using TrainingApi.Features.TodoItem;
using TrainingApi.Middlewares;
using Serilog;

namespace TrainingApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient("jokes", x => { x.BaseAddress = new Uri("http://universities.hipolabs.com/"); });
            builder.Services.AddScoped<ITodoService, TodoService>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<IBookService, BookService>(); 

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            builder.Host.UseSerilog();

 

            builder.Services.AddDbContext<TrainingApiDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
                ));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                //app.UseMiddleware<CustomMiddleware>();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<AuthMiddleware>();

            app.UseMiddleware<LoggerMiddleware>();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
