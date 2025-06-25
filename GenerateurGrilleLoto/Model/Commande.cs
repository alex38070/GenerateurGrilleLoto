using GrilleEuroMillion.Interaction;
using GrilleEuroMillion.Interface;
using GrilleEuroMillion.Reglement;

namespace GrilleEuroMillion.Model;

internal class Commande
{

    // Commander une ou plusieur grille qui va deduire le nombre de ticket.
    // Payer le prix.
    // Delivré
    private readonly IInteractionUtilisateur _ui = new InteractionUtilisateurConsole();
    private readonly Grille grille = new();

    internal void Lancer()
    {
        string choix = "2";
        do
        {
            if (choix == "2")
            {
                List<Utilisateur> utilisateurs = []; // Collection des Utilisateurs
                Utilisateur utilisateur = new(); // Nouvelle objet pour nouveau utilisateur
                utilisateurs.Add(utilisateur); // Ajout Utilisateur dans la Collection parente
                utilisateur.VerifierConnexion(utilisateur.Mail, utilisateur.MotDePasse);
            }

            double nombreGrille = _ui.DemanderDoubleEntreMinMax("\nVeuillez saisir le nombre de grille voulue", 1.00, 100.00);
            Ticket ticket = new(nombreGrille, grille);
            ticket.FormatTicket();

            Prix newPrix = new();
            double prix = newPrix.RetournerPrix(ticket.NombreGrille);

            Caisse caisse = new();
            caisse.Encaisser(prix);

            _ui.AfficherStringLine("\r\nTappez 1 pour nouvelle commande");
            _ui.AfficherStringLine("Tappez 2 pour creer nouvelle utilisateur");
            _ui.AfficherStringLine("Tapper 3 pour quitter");
            _ui.AfficherString("Votre choix est : ");
            choix = _ui.DemanderString();

            if (choix == "3")
                break;

        } while (choix == "1" || choix == "2");
    }

}
