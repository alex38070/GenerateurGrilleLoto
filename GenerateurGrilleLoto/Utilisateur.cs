namespace GenerateurGrilleEuroMillion;

internal class Utilisateur(string prenom, string nom, string mail, string motDePasse)
{
    internal string Prenom { get; set; } = prenom;
    internal string Nom { get; set; } = nom;
    internal string Mail { get; set; } = mail;
    internal string MotDePasse { get; set; } = motDePasse;

    internal Utilisateur CreerNouvelleUtilisateur()
    {
        Console.Write("Veuillez saisir votre Prénom : ");
        string prenom = Console.ReadLine() ?? string.Empty;
        Console.Write("Veuillez saisir votre Nom : ");
        string nom = Console.ReadLine() ?? string.Empty;
        Console.Write("Veuillez saisir votre Mail : ");
        string mail = Console.ReadLine() ?? string.Empty;
        Console.Write("Veuillez saisir votre mot De Passe : ");
        string motDePasse = Console.ReadLine() ?? string.Empty;

        return new(prenom, nom, mail, motDePasse);
    }

}
