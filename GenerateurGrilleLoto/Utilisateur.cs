namespace GrilleEuroMillion;

internal class Utilisateur(string prenom, string nom, string mail, string motDePasse, double montantCaisse)
{
    internal string Prenom { get; set; } = prenom;
    internal string Nom { get; set; } = nom;
    internal string Mail { get; set; } = mail;
    internal string MotDePasse { get; set; } = motDePasse;
    internal double MontantCaisse { get; set; } = montantCaisse;

    //internal Utilisateur()
    //{
    //    _ui.AfficherString("Veuillez saisir votre Prénom : ");
    //    Prenom = _ui.DemanderString();
    //    _ui.AfficherString("Veuillez saisir votre Nom : ");
    //    Nom = _ui.DemanderString();
    //    _ui.AfficherString("Veuillez saisir votre Mail : ");
    //    Mail = _ui.DemanderString();
    //    _ui.AfficherString("Veuillez saisir votre mot De Passe : ");
    //    MotDePasse = _ui.DemanderString();

    //    MontantCaisse = 500;
    //}



}
