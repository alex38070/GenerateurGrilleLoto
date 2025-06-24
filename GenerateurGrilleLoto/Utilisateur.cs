using GrilleEuroMillion.Interaction;

namespace GrilleEuroMillion;

internal class Utilisateur
{
    internal string Prenom { get; set; }
    internal string Nom { get; set; }
    internal string Mail { get; set; }
    internal string MotDePasse { get; set; }

    internal Utilisateur()
    {
        _ui.AfficherString("Veuillez saisir votre Prénom : ");
        Prenom = _ui.DemanderString();
        _ui.AfficherString("Veuillez saisir votre Nom : ");
        Nom = _ui.DemanderString();
        _ui.AfficherString("Veuillez saisir votre Mail : ");
        Mail = _ui.DemanderString();
        _ui.AfficherString("Veuillez saisir votre mot De Passe : ");
        MotDePasse = _ui.DemanderString();
    }

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
