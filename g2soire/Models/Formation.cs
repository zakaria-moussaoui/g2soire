namespace g2soire.Entities;

public class Formation
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public string Description { get; set; } = null!;

    // Lien vers le Formateur
    public int? FormateurId { get; set; }
    public Formateur? Formateur { get; set; }

    // Lien vers la Categorie
    public int? CategorieId { get; set; }
    public Categorie? Categorie { get; set; }

    public ICollection<Session> Sessions { get; set; } = new List<Session>();
}