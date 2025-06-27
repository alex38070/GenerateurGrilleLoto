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
            string saisieidentifiant = _ui.DemanderString("\r\nVeuillez saisir votre Identifiant de connexion : ");
            string saisieMotDePasse = _ui.DemanderString("Veuillez saisir votre Mot de passe : ");

            if (saisieidentifiant == utilisateurMail && saisieMotDePasse == utilisateurMotDePasse)
                return true;
        }
    }
    internal void AffichageTicket(List<Grille> grilles)
    {
        DateTime dateTime = DateTime.Now;

        _ui.AfficherString($"\r\nTicket 1 :  Vendredi {dateTime.Day:00} / {dateTime.Month:00} / {dateTime.Year}  {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}\n");
        _ui.AfficherStringLine("");

        for (int g = 1; g <= grilles.Count; g++)
        {
            _ui.AfficherString($"\r\nGrille {g:00} :");
            Grille grille = new();
            grilles.Add(grille);
        }
    }



}
