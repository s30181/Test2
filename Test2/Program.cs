using Microsoft.EntityFrameworkCore;
using Tutorial11.Data;
using Tutorial11.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddScoped<PlayerService>();

var app = builder.Build();

app.UseAuthorization();
 
app.MapControllers();

app.Run();