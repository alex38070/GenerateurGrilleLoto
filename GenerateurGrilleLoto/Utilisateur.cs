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
        Console.Write("Veuillez saisir votre Prénom : ");
        Prenom = Console.ReadLine() ?? string.Empty;
        Console.Write("Veuillez saisir votre Nom : ");
        Nom = Console.ReadLine() ?? string.Empty;
        Console.Write("Veuillez saisir votre Mail : ");
        Mail = Console.ReadLine() ?? string.Empty;
        Console.Write("Veuillez saisir votre mot De Passe : ");
        MotDePasse = Console.ReadLine() ?? string.Empty;
    }

    private IInteractionUtilisateur _ui = new InteractionUtilisateurConsole();

    //internal Utilisateur CreerNouvelleUtilisateur()
    //{
    //    Console.Write("Veuillez saisir votre Prénom : ");
    //    string prenom = Console.ReadLine() ?? string.Empty;
    //    Console.Write("Veuillez saisir votre Nom : ");
    //    string nom = Console.ReadLine() ?? string.Empty;
    //    Console.Write("Veuillez saisir votre Mail : ");
    //    string mail = Console.ReadLine() ?? string.Empty;
    //    Console.Write("Veuillez saisir votre mot De Passe : ");
    //    string motDePasse = Console.ReadLine() ?? string.Empty;

    //    return new(prenom, nom, mail, motDePasse);
    //}

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
