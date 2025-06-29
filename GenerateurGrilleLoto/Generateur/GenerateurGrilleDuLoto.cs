using GrilleEuroMillion.Interaction;
using GrilleEuroMillion.Interface;
using GrilleEuroMillion.Model;
using GrilleEuroMillion.Reglement;

namespace GrilleEuroMillion.Generateur;

/*
Expérience utilisateur :

1. On demande combien de grille le joueur souhaite entre 1 et 10
2. ⁠On indique le prix à l’utilisateur : 7.50€ la grille les 2 premières grilles, puis 6€ la grille les 2 suivantes, et ainsi de suite jusqu’à 1€ les 2 dernières grilles
    7.50€   Grilles 1 et 2
    6.00€   Grilles 3 et 4
    4.50€   Grilles 5 et 6
    3.00€   Grilles 7 et 8
    1.50€   Grilles 9 et 10
3. ⁠On encaisse un montant donné par le joueur supérieur au prix et inférieur à 100€
4. Et rend l’éventuelle monnaie et on affiche les grilles sous le format :

Grille 1 : 1 2 3 4 5 - 6 7
Grille 2 : …

Une grille EuroMillions se compose de 50 numéros (de 1 à 50) et 12 étoiles (de 1 à 12).

Aucun chiffre ne peut être en double entre les numéros et les étoiles 

L’affichage des numéros est ordonné en ordre croissant, et idem pour les étoiles 

On ne doit pas générer de grilles identiques lors d’une même génération de plusieurs grilles
*/

internal class GenerateurGrilleDuLoto
{
    private readonly IInteractionUtilisateur _ui = new InteractionUtilisateurConsole();

    private readonly CompteUtilisateur _compteUtilisateur = new(); // Collection des Utilisateurs
    private readonly List<Utilisateur> _utilisateurs = []; // Collection des Utilisateurs
    private readonly Commande _commande = new();

    internal void Lancer()
    {
        double nombreGrille = 0;
        string motDePasse;
        string mail;
        string choix;

        while (true)
        {
            Utilisateur utilisateur = _compteUtilisateur.CreerUtilisateur();//Nouvelle objet pour nouveau utilisateur
            _utilisateurs.Add(utilisateur); // Ajout Utilisateur dans la Collection parente
            mail = utilisateur.Mail;
            motDePasse = utilisateur.MotDePasse;

            _commande.VerifierConnexion(mail, motDePasse); // verifier connection vaalid

            _ui.AfficherStringLine($"\r\nBonjour {utilisateur.Prenom} {utilisateur.Nom} ravi de vous compter parmit nos utilisateurs");

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

                _ui.AfficherStringLine($"\r\nTappez 1 : Pour ajouter d'autres Grilles ?");
                _ui.AfficherStringLine("Tappez 2 : Pour règler la commande ?");
                choix = _ui.DemanderChoix("Votre choix est : ");

                if (choix == "2")
                    break;
            }

            double montantCaisse = utilisateur.MontantCaisse;
            Caisse caisse = new(montantCaisse, nombreGrille);
            _ui.AfficherStringLine($"\r\nVotre compte est a : {montantCaisse} euro!");

            caisse.Encaisser();

            _commande.AffichageTicket(nombreGrille);

            _ui.AfficherStringLine("\r\nTappez 1 pour refaire une commande?");
            _ui.AfficherStringLine("Tapper 2 pour quitter ?");
            choix = _ui.DemanderString("Votre choix est : ");

            if (choix == "2")
                break;
        }
    }
}
