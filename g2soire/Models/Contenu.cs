namespace g2soire.Entities;

public class Contenu
{
    public int Id { get; set; }
    public string Titre { get; set; } = null!;
    public string Texte { get; set; } = null!;   // le contenu du cours / énoncé exercice / questions quiz

    // Type de modalité : "Cours", "Exercice" ou "Quiz"
    public string Type { get; set; } = "Cours";

    // Lien vers le Module
    public int ModuleId { get; set; }
    public Module? Module { get; set; }
}