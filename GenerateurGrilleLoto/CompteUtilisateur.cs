using GrilleEuroMillion.Interaction;
using GrilleEuroMillion.Interface;
using GrilleEuroMillion.Model;

namespace GrilleEuroMillion;
internal class CompteUtilisateur
{
    private readonly IInteractionUtilisateur _ui = new InteractionUtilisateurConsole();

    internal Utilisateur CreerNouvelUtilisateur()
    {
        string prenom = _ui.DemanderString("Veuillez saisir votre Prénom : ");
        string nom = _ui.DemanderString("Veuillez saisir votre Nom : ");
        string mail = _ui.DemanderMail("Veuillez saisir votre Mail : ");
        string motDePasse = _ui.DemanderString("Veuillez saisir votre mot De Passe : ");
        double montantCaisse = 200;
        return new(prenom, nom, mail, motDePasse, montantCaisse);
    }

    internal void AuthentifierUtilisateur(string mail, string motDePasse, string prenom, string nom)
    {
        Commande _commande = new();
        _commande.VerifierConnexion(mail, motDePasse); // verifier connection vaalid
        _ui.AfficherStringLine($"\r\nBonjour {prenom} {nom} ravi de vous compter parmi nos utilisateurs");
    }
}