using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TourBy.Data.Persistent.Sql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

const string connectionString =
    "Server=tcp:tourby-db-server.database.windows.net,1433;Initial Catalog=tourby-db;Persist Security Info=False;User ID=lilter96;Password=A213dom_123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(connectionString, sqlOptions =>
    {
        sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name);
    }));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
