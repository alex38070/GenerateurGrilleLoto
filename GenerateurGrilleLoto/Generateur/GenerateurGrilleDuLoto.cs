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
    private readonly List<Utilisateur> utilisateurs = []; // Collection des Utilisateurs
    private readonly List<Grille> grilles = []; // Collection des Utilisateurs
    private double montantCaisse;
    //private double nombreGrille;

    internal void Lancer()
    {
        Prix newPrix = new();
        string choix = "2";
        bool estValid = false;
        do
        {
            double nombreGrille;
            Commande commande = new();
            double choixTotalDeGrille = 0;
            string motDePasse = string.Empty;
            string mail = string.Empty;
            if (utilisateurs.Count == 0 || choix == "1")
            {
                // Nouvelle objet pour nouveau utilisateur
                _ui.AfficherString("Veuillez saisir votre Prénom : ");
                string prenom = _ui.DemanderString();
                _ui.AfficherString("Veuillez saisir votre Nom : ");
                string nom = _ui.DemanderString();
                _ui.AfficherString("Veuillez saisir votre Mail : ");
                mail = _ui.DemanderString();
                _ui.AfficherString("Veuillez saisir votre mot De Passe : ");
                motDePasse = _ui.DemanderString();
                montantCaisse = 500;
                Utilisateur utilisateur = new(prenom, nom, mail, motDePasse, montantCaisse);
                // Ajout Utilisateur dans la Collection parente
                utilisateurs.Add(utilisateur);
                motDePasse = utilisateur.MotDePasse;
                mail = utilisateur.Mail;


            }
            if (commande.VerifierConnexion(mail, motDePasse)) // verifier connection vaalid
            {
                _ui.AfficherStringLine("\r\nRavi de vous revoir");
                bool paiementValider = true;
                nombreGrille = _ui.DemanderDoubleEntreMinMax("\nVeuillez saisir le nombre de grille voulue", 1.00, 100.00);
                choixTotalDeGrille = nombreGrille;
                Console.WriteLine(choixTotalDeGrille);
                do
                {
                    _ui.AfficherStringLine($"Tappez 1 : Vous avez {choixTotalDeGrille} grilles dans le panier! Voulez vous ajouter d'autre Grille?");
                    _ui.AfficherStringLine("Tappez 2 : Regler la commande");
                    _ui.AfficherString("Votre choix est : ");
                    choix = _ui.DemanderString();

                    // si choix 1 alors choix nombre grille
                    if (choix == "1")
                    {
                        Console.WriteLine(choixTotalDeGrille);
                        choixTotalDeGrille += _ui.DemanderDoubleEntreMinMax("\r\nVeuillez saisir le nombre de grille voulue", 1.00, 100.00);
                        Console.WriteLine(choixTotalDeGrille);

                    }
                    if (choix == "2")
                    {
                        double prix = newPrix.RetournerPrix(nombreGrille); // une fois payer retunr true pour sortir de la boucle
                        _ui.AfficherStringLine($"Votre compte est a : {montantCaisse}");
                        montantCaisse -= prix;
                        _ui.AfficherStringLine($"Votre compte apres paiement est a : {montantCaisse}");
                        paiementValider = false;
                    }

                } while (paiementValider);

                Ticket ticket = new();

                ticket.FormatTicket(); // choixTotalDeGrille
                for (int i = 1; i <= choixTotalDeGrille; i++)
                {
                    _ui.AfficherString($"\r\nGrille {i:00} :");
                    Grille grille = new();
                    grilles.Add(grille);
                }
            }

            _ui.AfficherStringLine("Tappez 1 pour creer un compte");
            _ui.AfficherStringLine("Tappez 2 pour vous connecter");
            _ui.AfficherStringLine("Tapper 3 pour quitter");
            choix = _ui.DemanderString();

            if (choix == "3")
                break;
            if (choix == "1" || choix == "2")
                estValid = true;


        } while (estValid);
    }
}