using GrilleEuroMillion.Interaction;
using GrilleEuroMillion.Interface;

namespace GrilleEuroMillion.Model;

internal class Commande()
{
    private readonly IInteractionUtilisateur _ui = new InteractionUtilisateurConsole();

    public bool VerifierConnexion(string utilisateurMail, string utilisateurMotDePasse)
    {
        while (true)
        {
            string saisieidentifiant = _ui.DemanderString("\r\nVeuillez saisir votre Identifiant de connexion : ");
            string saisieMotDePasse = _ui.DemanderString("Veuillez saisir votre Mot de passe : ");

            if (saisieidentifiant == utilisateurMail && saisieMotDePasse == utilisateurMotDePasse)
                return true;
        }
    }

    internal void AffichageTicket(double nombreTicket)
    {
        Ticket ticket = new(nombreTicket);
        ticket.FormaterTicket();
    }
}
