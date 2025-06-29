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

    private readonly CompteUtilisateur compteUtilisateur = new(); // Collection des Utilisateurs
    private readonly List<Utilisateur> utilisateurs = []; // Collection des Utilisateurs
    private readonly List<Grille> grilles = []; // Collection des Utilisateurs
    private readonly Commande commande = new();

    //private double nombreGrille;

    internal void Lancer()
    {
        Prix newPrix = new();
        double nombreGrille;
        double choixTotalDeGrille = 0;
        string motDePasse = string.Empty;
        string mail = string.Empty;
        string choix = string.Empty;
        bool estValide = false;

        while (true)
        {
            Utilisateur utilisateur = compteUtilisateur.CreerUtilisateur();//Nouvelle objet pour nouveau utilisateur
            utilisateurs.Add(utilisateur); // Ajout Utilisateur dans la Collection parente
            mail = utilisateur.Mail;
            motDePasse = utilisateur.MotDePasse;
            //montantCaisse = utilisateur.MontantCaisse;
            estValide = (!(commande.VerifierConnexion(mail, motDePasse))); // verifier connection vaalid
            _ui.AfficherStringLine($"\r\nBonjour {utilisateur.Prenom} {utilisateur.Nom} ravi de vous revoir");

            do
            {
                choixTotalDeGrille += _ui.DemanderDoubleEntreMinMax("\r\nVeuillez saisir le nombre de grille voulue", 1.00, 50.00);
                if (choixTotalDeGrille >= 50)
                {
                    choixTotalDeGrille = 50;
                    _ui.AfficherStringLine("\r\nMontant maximum des grilles atteint.");
                    _ui.AfficherStringLine($"Vous avez {choixTotalDeGrille} grilles dans votre panier, ce qui correspond au nombre maximum autorisé.");
                    _ui.AfficherStringLine("Vous allez être redirigé vers le règlement de la commande.");
                    choix = "2";
                }
                else
                {
                    _ui.AfficherStringLine($"\r\nTappez 1 : Vous avez {choixTotalDeGrille} grilles dans le panier! Voulez vous ajouter d'autre Grille?");
                    _ui.AfficherStringLine("Tappez 2 : Regler la commande");
                    choix = _ui.DemanderChoix("Votre choix est : ");
                }

                if (choix == "2")
                {
                    // montant impissible si la caisse nest pas sufusante
                    double montantCaisse = utilisateur.MontantCaisse;
                    Caisse caisse = new(utilisateur.MontantCaisse, choixTotalDeGrille);
                    _ui.AfficherStringLine($"Votre compte est a : {montantCaisse}");
                    _ui.AfficherStringLine($"Votre compte apres paiement est a : {caisse.Encaisser()}");
                    double prix = newPrix.RetournerPrix(choixTotalDeGrille); // une fois payer retunr true pour sortir de la boucle
                    montantCaisse -= prix;
                    //paiementValider = false;
                }

            } while (true);
        }
    }

    //    Ticket ticket = new();

    //    ticket.FormatTicket(); // choixTotalDeGrille
    //    for (int i = 1; i <= choixTotalDeGrille; i++)
    //    {
    //        _ui.AfficherString($"\r\nGrille {i:00} :");
    //        Grille grille = new();
    //        grilles.Add(grille);
    //    }

    //    _ui.AfficherStringLine("Tappez 1 pour creer un compte");
    //    _ui.AfficherStringLine("Tappez 2 pour vous connecter");
    //    _ui.AfficherStringLine("Tapper 3 pour quitter");
    //    choix = _ui.DemanderString("Votre choix est : ");

    //    if (choix == "3")
    //        break;
    //    if (choix == "1" || choix == "2")
    //        estValid = true;


    //} while (estValid);
}
