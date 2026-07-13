namespace g2soire.Entities;

public class Module
{
    public int Id { get; set; }
    public string Titre { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Ordre { get; set; }   // pour ordonner les modules dans la formation

    // Lien vers la Formation
    public int FormationId { get; set; }
    public Formation? Formation { get; set; }

    // Un module contient plusieurs contenus
    public ICollection<Contenu> Contenus { get; set; } = new List<Contenu>();
}