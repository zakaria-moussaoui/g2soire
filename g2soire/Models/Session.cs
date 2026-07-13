namespace g2soire.Entities;

public class Session
{
    public int Id { get; set; }
    public DateTime DateDebut { get; set; }

    public DateTime DateFin { get; set; }   

    public int FormationId { get; set; }
    public Formation? Formation { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
}