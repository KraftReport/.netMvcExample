using Microsoft.EntityFrameworkCore;
using MVCExample.Web.EFDbContext;
using MVCExample.Web.Features.Blog;
using MVCExample.Web.Features.Book;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(
    opt =>
        opt.UseSqlServer(
            builder
                .Configuration
                .GetConnectionString("DbConnection")
        )
);
builder.Services.AddScoped<IBlogService,BlogService>(); 
builder.Services.AddScoped<IBookService,BookService>();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("todoApi", x =>
{
    x.BaseAddress = new Uri("https://localhost:7071/");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=Index}/{id?}");

app.Run();