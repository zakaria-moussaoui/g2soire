namespace g2soire.Entities;

public class User
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public string Prenom { get; set; } = null!;
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public ICollection<Session> Sessions { get; set; } = new List<Session>();
}