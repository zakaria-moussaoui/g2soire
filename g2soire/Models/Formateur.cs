namespace g2soire.Entities;

public class Formateur
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public string Prenom { get; set; } = null!;
    public string Specialite { get; set; } = null!;

    // Une formation peut être donnée par ce formateur
    public ICollection<Formation> Formations { get; set; } = new List<Formation>();
}