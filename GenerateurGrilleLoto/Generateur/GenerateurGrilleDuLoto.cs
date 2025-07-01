using GrilleEuroMillion.Interaction;
using GrilleEuroMillion.Interface;
using GrilleEuroMillion.Model;
using GrilleEuroMillion.Reglement;

namespace GrilleEuroMillion.Generateur;

internal class GenerateurGrilleDuLoto()
{
    private readonly IInteractionUtilisateur _ui = new InteractionUtilisateurConsole();
    private readonly CompteUtilisateur _compteUtilisateur = new(); // Collection des Utilisateurs
    private readonly List<Utilisateur> _utilisateurs = []; // Collection des Utilisateurs
    private readonly Commande _commande = new();

    internal void Lancer()
    {
        while (true)
        {
            double nombreGrille = 0;
            double montantCaisse = 100;
            _ui.AfficherStringLine("Tapez 1 : Pour creer un utilisateur");
            _ui.AfficherStringLine("Taper 2 : Pour continuer sans connexion ?");
            string choix = _ui.DemanderString("Votre choix est : ");

            if (choix == "1")
            {
                Utilisateur utilisateur = _compteUtilisateur.CreerNouvelUtilisateur();//Nouvelle objet pour nouveau utilisateur
                _utilisateurs.Add(utilisateur); // Ajout Utilisateur dans la liste parente
                _compteUtilisateur.AuthentifierUtilisateur(utilisateur.Mail, utilisateur.MotDePasse, utilisateur.Prenom, utilisateur.Nom);  // Connection utilsateur
                montantCaisse = utilisateur.MontantCaisse; // Montant caisse de l'utilisateur
            }

            nombreGrille = _commande.DemanderNombreDeGrilles(nombreGrille, choix); // return choix utilisateur du nombre de grille
            Caisse caisse = new(montantCaisse, nombreGrille);

            _ui.AfficherStringLine($"\r\nVotre compte est a : {montantCaisse} euro!");

            if (caisse.TraiterPaiement())
                _compteUtilisateur.AffichageTicket(nombreGrille);

            _ui.AfficherStringLine("\r\nTapez 1 pour refaire une commande?");
            _ui.AfficherStringLine("Taper 2 pour quitter ?");
            choix = _ui.DemanderString("Votre choix est : ");

            if (choix == "2")
                break;
        }
    }
}
