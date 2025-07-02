using GrilleEuroMillion.Interface;

namespace GrilleEuroMillion.Model;

internal class Commande(IInteractionUtilisateur _ui) // jaimerais sauvegarder les commande avec id utilisateur
{
    private readonly IInteractionUtilisateur _ui = _ui;

    public bool VerifierConnexion(string utilisateurMail, string utilisateurMotDePasse)
    {
        int chance = 2;
        while (true)
        {
            for (int i = 0; i <= 2; i++)
            {
                string saisieidentifiant = _ui.DemanderMail("\r\nVeuillez saisir votre Identifiant de connexion : ");
                string saisieMotDePasse = _ui.DemanderString("Veuillez saisir votre Mot de passe : ");

                if (saisieidentifiant == utilisateurMail && saisieMotDePasse == utilisateurMotDePasse)
                    return true;
                _ui.AfficherStringLine($"Vous avez encore {chance - i} chance avant blocoge");
                if (i == 0)
                    break;
            }
        }
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