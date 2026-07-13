using Microsoft.EntityFrameworkCore;
using g2soire.Entities;

namespace g2soire.Data;

public class DaoImpl : IDao
{
    private readonly AppContex _context;
    public DaoImpl(AppContex context) => _context = context;

    // ===== Inscription =====
    public bool UserExists(int userId)
        => _context.Users.Any(u => u.Id == userId);

    public bool SessionExists(int sessionId)
        => _context.Sessions.Any(s => s.Id == sessionId);

    public bool DejaInscrit(int userId, int sessionId)
        => _context.Users
            .Where(u => u.Id == userId)
            .SelectMany(u => u.Sessions)
            .Any(s => s.Id == sessionId);

    public void Inscrire(int userId, int sessionId)
    {
        var user = _context.Users
            .Include(u => u.Sessions)
            .First(u => u.Id == userId);

        var session = _context.Sessions.Find(sessionId);

        user.Sessions.Add(session!);
        _context.SaveChanges();
    }

    public List<Session> GetSessionsByUser(int userId)
    {
        var user = _context.Users
            .Include(u => u.Sessions).ThenInclude(s => s.Formation)
            .FirstOrDefault(u => u.Id == userId);

        return user?.Sessions.ToList() ?? new List<Session>();
    }

    // ===== CRUD Formateur =====
    public List<Formateur> GetAllFormateurs()
        => _context.Formateurs.ToList();

    public Formateur? GetFormateurById(int id)
        => _context.Formateurs.Find(id);

    public void AddFormateur(Formateur formateur)
    {
        _context.Formateurs.Add(formateur);
        _context.SaveChanges();
    }

    public void UpdateFormateur(int id, Formateur formateur)
    {
        var existant = _context.Formateurs.Find(id);
        if (existant == null) return;

        existant.Nom = formateur.Nom;
        existant.Prenom = formateur.Prenom;
        existant.Specialite = formateur.Specialite;

        _context.SaveChanges();
    }

    public void DeleteFormateur(int id)
    {
        var existant = _context.Formateurs.Find(id);
        if (existant == null) return;

        _context.Formateurs.Remove(existant);
        _context.SaveChanges();
    }

    // ===== CRUD Formation =====
    public List<Formation> GetAllFormations()
        => _context.Formations
            .Include(f => f.Formateur)
            .Include(f => f.Categorie)
            .ToList();

    public Formation? GetFormationById(int id)
        => _context.Formations
            .Include(f => f.Formateur)
            .Include(f => f.Categorie)
            .Include(f => f.Sessions)
            .FirstOrDefault(f => f.Id == id);

    public void AddFormation(Formation formation)
    {
        _context.Formations.Add(formation);
        _context.SaveChanges();
    }

    public void UpdateFormation(int id, Formation formation)
    {
        var existant = _context.Formations.Find(id);
        if (existant == null) return;

        existant.Nom = formation.Nom;
        existant.Description = formation.Description;
        existant.FormateurId = formation.FormateurId;
        existant.CategorieId = formation.CategorieId;

        _context.SaveChanges();
    }

    public void DeleteFormation(int id)
    {
        var existant = _context.Formations.Find(id);
        if (existant == null) return;

        _context.Formations.Remove(existant);
        _context.SaveChanges();
    }

    // ===== CRUD Session =====
    public List<Session> GetAllSessions()
        => _context.Sessions
            .Include(s => s.Formation)
            .ToList();

    public Session? GetSessionById(int id)
        => _context.Sessions
            .Include(s => s.Formation)
            .FirstOrDefault(s => s.Id == id);

    public void AddSession(Session session)
    {
        _context.Sessions.Add(session);
        _context.SaveChanges();
    }

    public void UpdateSession(int id, Session session)
    {
        var existant = _context.Sessions.Find(id);
        if (existant == null) return;

        existant.DateDebut = session.DateDebut;
        existant.DateFin = session.DateFin;
        existant.FormationId = session.FormationId;

        _context.SaveChanges();
    }

    public void DeleteSession(int id)
    {
        var existant = _context.Sessions.Find(id);
        if (existant == null) return;

        _context.Sessions.Remove(existant);
        _context.SaveChanges();
    }

    // ===== CRUD User + Auth =====
    public List<User> GetAllUsers()
        => _context.Users.ToList();

    public User? GetUserById(int id)
        => _context.Users.Find(id);

    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void UpdateUser(int id, User user)
    {
        var existant = _context.Users.Find(id);
        if (existant == null) return;

        existant.Nom = user.Nom;
        existant.Prenom = user.Prenom;
        existant.Login = user.Login;
        existant.Password = user.Password;

        _context.SaveChanges();
    }

    public void DeleteUser(int id)
    {
        var existant = _context.Users.Find(id);
        if (existant == null) return;

        _context.Users.Remove(existant);
        _context.SaveChanges();
    }

    // ===== CRUD Module =====
    public List<Module> GetAllModules()
        => _context.Modules
            .Include(m => m.Contenus)
            .ToList();

    public Module? GetModuleById(int id)
        => _context.Modules
            .Include(m => m.Contenus)
            .FirstOrDefault(m => m.Id == id);

    public void AddModule(Module module)
    {
        _context.Modules.Add(module);
        _context.SaveChanges();
    }

    public void UpdateModule(int id, Module module)
    {
        var existant = _context.Modules.Find(id);
        if (existant == null) return;

        existant.Titre = module.Titre;
        existant.Description = module.Description;
        existant.Ordre = module.Ordre;
        existant.FormationId = module.FormationId;

        _context.SaveChanges();
    }

    public void DeleteModule(int id)
    {
        var existant = _context.Modules.Find(id);
        if (existant == null) return;

        _context.Modules.Remove(existant);
        _context.SaveChanges();
    }

    // ===== CRUD Contenu =====
    public List<Contenu> GetAllContenus()
        => _context.Contenus.ToList();

    public Contenu? GetContenuById(int id)
        => _context.Contenus.Find(id);

    public void AddContenu(Contenu contenu)
    {
        _context.Contenus.Add(contenu);
        _context.SaveChanges();
    }

    public void UpdateContenu(int id, Contenu contenu)
    {
        var existant = _context.Contenus.Find(id);
        if (existant == null) return;

        existant.Titre = contenu.Titre;
        existant.Texte = contenu.Texte;
        existant.Type = contenu.Type;
        existant.ModuleId = contenu.ModuleId;

        _context.SaveChanges();
    }

    public void DeleteContenu(int id)
    {
        var existant = _context.Contenus.Find(id);
        if (existant == null) return;

        _context.Contenus.Remove(existant);
        _context.SaveChanges();
    }

    public User? Authentifier(string login, string password)
        => _context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

}