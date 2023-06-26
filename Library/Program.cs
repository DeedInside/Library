using Library.DALL;
using Library.DALL.Interfaces;
using Library.DALL.Repositories;
using Library.Service.Implementations;
using Library.Service.Interfasec;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

builder.Services.AddScoped<IReaderRepository, ReaderRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<IReaderService, ReaderService>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddDbContext<ApplicationContext>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hello World!");
    });

});

app.Run();

