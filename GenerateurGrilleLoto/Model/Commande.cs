using GrilleEuroMillion.Interaction;
using GrilleEuroMillion.Interface;

namespace GrilleEuroMillion.Model;

internal class Commande()
{
    // Commander une ou plusieur grille qui va deduire le nombre de ticket.
    // Payer le prix.
    // Delivré

    private readonly IInteractionUtilisateur _ui = new InteractionUtilisateurConsole();

    public bool VerifierConnexion(string utilisateurMail, string utilisateurMotDePasse)
    {
        while (true)
        {
            _ui.AfficherString("\r\nVeuillez saisir votre Identifiant de connexion : ");
            string saisieidentifiant = _ui.DemanderString();
            _ui.AfficherString("Veuillez saisir votre Mot de passe : ");
            string saisieMotDePasse = _ui.DemanderString();

            if (saisieidentifiant == utilisateurMail && saisieMotDePasse == utilisateurMotDePasse)
                return true;
        }
    }


}
