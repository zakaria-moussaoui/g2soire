using Microsoft.EntityFrameworkCore;
using g2soire.Entities;          

namespace g2soire.Data;

public class AppContex : DbContext
{
    public AppContex(DbContextOptions<AppContex> options) : base(options) { }

    public DbSet<Categorie> Categories { get; set; }
    public DbSet<User> Users { get; set; }          
    public DbSet<Session> Sessions { get; set; }    
    public DbSet<Formation> Formations { get; set; }

    public DbSet<Formateur> Formateurs { get; set; }

    public DbSet<Module> Modules { get; set; }
    public DbSet<Contenu> Contenus { get; set; }

}
