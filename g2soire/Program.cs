using g2soire.Data;
using g2soire.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- Port Railway (utilise le port imposé par Railway, sinon 8080 en local) ---
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

// --- Chaîne de connexion : Railway en ligne, sinon appsettings en local ---
var railwayUrl = Environment.GetEnvironmentVariable("MYSQL_URL");
var cnx = !string.IsNullOrEmpty(railwayUrl)
    ? ConvertMysqlUrl(railwayUrl)
    : builder.Configuration.GetConnectionString("cnx");

builder.Services.AddDbContext<AppContex>(options =>
    options.UseMySql(cnx, ServerVersion.AutoDetect(cnx)));

builder.Services.AddScoped<IDao, DaoImpl>();
builder.Services.AddScoped<IServices, VService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

var app = builder.Build();

// --- Crée les tables dans la base Railway automatiquement au démarrage ---
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppContex>();
    db.Database.Migrate();
}

app.UseStaticFiles();

// Swagger activé tout le temps (pratique pour tester en ligne)
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();

// --- Convertit l'URL Railway (mysql://user:pass@host:port/db) en chaîne EF Core ---
static string ConvertMysqlUrl(string url)
{
    var uri = new Uri(url);
    var userInfo = uri.UserInfo.Split(':');
    return $"server={uri.Host};port={uri.Port};database={uri.AbsolutePath.TrimStart('/')};user={userInfo[0]};password={Uri.UnescapeDataString(userInfo[1])}";
}