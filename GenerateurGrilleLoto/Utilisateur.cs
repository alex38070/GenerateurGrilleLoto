namespace GrilleEuroMillion;

internal class Utilisateur(string prenom, string nom, string mail, string motDePasse, double montantCaisse)
{
    internal string Prenom { get; set; } = prenom;
    internal string Nom { get; set; } = nom;
    internal string Mail { get; set; } = mail;
    internal string MotDePasse { get; set; } = motDePasse;
    internal double MontantCaisse { get; set; } = montantCaisse;
}
