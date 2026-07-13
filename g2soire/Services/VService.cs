using g2soire.Data;
using g2soire.Entities;

namespace g2soire.Services;

public class VService : IServices
{
    private readonly IDao _dao;
    public VService(IDao dao) => _dao = dao;

    // ===== Inscription =====
    public void Inscrire(int userId, int sessionId)
    {
        if (!_dao.UserExists(userId))
            throw new Exception("Utilisateur introuvable.");
        if (!_dao.SessionExists(sessionId))
            throw new Exception("Session introuvable.");
        if (_dao.DejaInscrit(userId, sessionId))
            throw new Exception("Déjà inscrit à cette session.");

        _dao.Inscrire(userId, sessionId);
    }

    public List<Session> GetSessionsByUser(int userId)
        => _dao.GetSessionsByUser(userId);

    // ===== CRUD Formateur =====
    public List<Formateur> GetAllFormateurs()
        => _dao.GetAllFormateurs();

    public Formateur? GetFormateurById(int id)
        => _dao.GetFormateurById(id);

    public void AddFormateur(Formateur formateur)
        => _dao.AddFormateur(formateur);

    public void UpdateFormateur(int id, Formateur formateur)
        => _dao.UpdateFormateur(id, formateur);

    public void DeleteFormateur(int id)
        => _dao.DeleteFormateur(id);

    // ===== CRUD Formation =====
    public List<Formation> GetAllFormations()
        => _dao.GetAllFormations();

    public Formation? GetFormationById(int id)
        => _dao.GetFormationById(id);

    public void AddFormation(Formation formation)
        => _dao.AddFormation(formation);

    public void UpdateFormation(int id, Formation formation)
        => _dao.UpdateFormation(id, formation);

    public void DeleteFormation(int id)
        => _dao.DeleteFormation(id);

    // ===== CRUD Session =====
    public List<Session> GetAllSessions()
        => _dao.GetAllSessions();

    public Session? GetSessionById(int id)
        => _dao.GetSessionById(id);

    public void AddSession(Session session)
        => _dao.AddSession(session);

    public void UpdateSession(int id, Session session)
        => _dao.UpdateSession(id, session);

    public void DeleteSession(int id)
        => _dao.DeleteSession(id);

    // ===== CRUD User + Auth =====
    public List<User> GetAllUsers()
        => _dao.GetAllUsers();

    public User? GetUserById(int id)
        => _dao.GetUserById(id);

    public void AddUser(User user)
        => _dao.AddUser(user);

    public void UpdateUser(int id, User user)
        => _dao.UpdateUser(id, user);

    public void DeleteUser(int id)
        => _dao.DeleteUser(id);

    public User? Authentifier(string login, string password)
        => _dao.Authentifier(login, password);
}