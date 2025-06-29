using GrilleEuroMillion.Interaction;
using GrilleEuroMillion.Interface;

namespace GrilleEuroMillion;
internal class CompteUtilisateur
{
    private readonly IInteractionUtilisateur _ui = new InteractionUtilisateurConsole();

    internal Utilisateur CreerUtilisateur()
    {
        string prenom = _ui.DemanderString("Veuillez saisir votre Prénom : ");
        string nom = _ui.DemanderString("Veuillez saisir votre Nom : ");
        string mail = _ui.DemanderMail("Veuillez saisir votre Mail : ");
        string motDePasse = _ui.DemanderString("Veuillez saisir votre mot De Passe : ");
        double montantCaisse = 200;
        return new(prenom, nom, mail, motDePasse, montantCaisse);
    }
}