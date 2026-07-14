using g2soire.Data;
using g2soire.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppContex>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("cnx"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("cnx"))
    )
);

builder.Services.AddScoped<IDao, DaoImpl>();
builder.Services.AddScoped<IServices, VService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

var app = builder.Build();

app.UseStaticFiles();

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
