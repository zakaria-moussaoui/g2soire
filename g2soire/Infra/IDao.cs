using g2soire.Entities;

namespace g2soire.Data;

public interface IDao
{
    // ===== Inscription =====
    bool UserExists(int userId);
    bool SessionExists(int sessionId);
    bool DejaInscrit(int userId, int sessionId);
    void Inscrire(int userId, int sessionId);
    List<Session> GetSessionsByUser(int userId);

    // ===== CRUD Formateur =====
    List<Formateur> GetAllFormateurs();
    Formateur? GetFormateurById(int id);
    void AddFormateur(Formateur formateur);
    void UpdateFormateur(int id, Formateur formateur);
    void DeleteFormateur(int id);

    // ===== CRUD Formation =====
    List<Formation> GetAllFormations();
    Formation? GetFormationById(int id);
    void AddFormation(Formation formation);
    void UpdateFormation(int id, Formation formation);
    void DeleteFormation(int id);

    // ===== CRUD Session =====
    List<Session> GetAllSessions();
    Session? GetSessionById(int id);
    void AddSession(Session session);
    void UpdateSession(int id, Session session);
    void DeleteSession(int id);

    // ===== CRUD User + Auth =====
    List<User> GetAllUsers();
    User? GetUserById(int id);
    void AddUser(User user);
    void UpdateUser(int id, User user);
    void DeleteUser(int id);
    User? Authentifier(string login, string password);
}