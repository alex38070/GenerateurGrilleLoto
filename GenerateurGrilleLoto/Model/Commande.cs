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

    internal double DemanderNombreDeGrilles(double nombreGrille, string choix)
    {
        while (true)
        {
            nombreGrille += _ui.DemanderDoubleEntreMinMax("\r\nVeuillez saisir le nombre de grille voulue", 1.00, 50.00);

            if (nombreGrille >= 50)
            {
                nombreGrille = 50;
                _ui.AfficherStringLine($"Vous avez {nombreGrille} grilles dans votre panier, ce qui correspond au nombre maximum autorisé.");
                _ui.AfficherStringLine("Vous allez être redirigé vers le règlement de la commande.");
                break;
            }

            _ui.AfficherStringLine($"\r\nVous avez {nombreGrille} grilles dans votre panier!");

            _ui.AfficherStringLine($"\r\nTapez 1 : Pour ajouter d'autres Grilles ?");
            _ui.AfficherStringLine("Tapez 2 : Pour règler la commande ?");
            choix = _ui.DemanderChoix("Votre choix est : ");

            if (choix == "2")
                break;
        }
        return nombreGrille;
    }
}
