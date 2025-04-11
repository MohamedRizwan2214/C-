using BookApi.models;
using BookApi.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookContext>(options =>
       options.UseSqlite("Data Source=books.db"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BookContext>();
    db.Database.Migrate();

    // Optional seed
    // if (!db.Books.Any())
    // {
    //     db.Books.AddRange(
    //         new Book { Title = "The Pragmatic Programmer", Author = "Andrew Hunt", Price = 29 },
    //         new Book { Title = "Clean Code", Author = "Robert C. Martin", Price = 25 }
    //     );
    //     db.SaveChanges();
    // }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
