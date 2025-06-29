using GrilleEuroMillion.Interaction;
using GrilleEuroMillion.Interface;
using GrilleEuroMillion.Model;
using GrilleEuroMillion.Reglement;

namespace GrilleEuroMillion.Generateur;

internal class GenerateurGrilleDuLoto
{
    private readonly IInteractionUtilisateur _ui = new InteractionUtilisateurConsole();
    private readonly CompteUtilisateur _compteUtilisateur = new(); // Collection des Utilisateurs
    private readonly List<Utilisateur> _utilisateurs = []; // Collection des Utilisateurs
    private readonly Commande _commande = new();

    internal void Lancer()
    {
        double nombreGrille = 0;
        string choix = "";

        while (true)
        {
            Utilisateur utilisateur = _compteUtilisateur.CreerNouvelUtilisateur();//Nouvelle objet pour nouveau utilisateur
            _utilisateurs.Add(utilisateur); // Ajout Utilisateur dans la Collection parente

            _compteUtilisateur.AuthentifierUtilisateur(utilisateur.Mail, utilisateur.MotDePasse, utilisateur.Prenom, utilisateur.Nom);  // Connection utilsateur

            nombreGrille = _commande.DemanderNombreDeGrilles(nombreGrille, choix); // return choix utilisateur du nombre de grille
            double montantCaisse = utilisateur.MontantCaisse; // Montant caisse de l'utilisateur
            Caisse caisse = new(montantCaisse, nombreGrille);

            _ui.AfficherStringLine($"\r\nVotre compte est a : {montantCaisse} euro!");

            caisse.TraiterPaiement();

            _commande.AffichageTicket(nombreGrille); // erreur a bloquer si paiement a echouer

            _ui.AfficherStringLine("\r\nTapez 1 pour refaire une commande?");
            _ui.AfficherStringLine("Taper 2 pour quitter ?");
            choix = _ui.DemanderString("Votre choix est : ");

            if (choix == "2")
                break;
        }
    }
}
