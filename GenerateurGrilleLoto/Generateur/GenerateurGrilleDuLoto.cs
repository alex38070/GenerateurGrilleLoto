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
    List<Utilisateur> utilisateurs = []; // Collection des Utilisateurs
    List<Grille> grilles = []; // Collection des Utilisateurs

    private double montantCaisse;

    internal void Lancer()
    {
        string motDePasse = "";
        string mail = "";
        Prix newPrix = new();
        string choix = "2";
        do
        {
            double nombreGrille;
            Utilisateur utilisateur;
            Commande commande = new();
            if (utilisateurs.Count == 0)
            {
                // Nouvelle objet pour nouveau utilisateur
                utilisateur = new();
                _ui.AfficherString("Veuillez saisir votre Prénom : ");
                utilisateur.Prenom = _ui.DemanderString();
                _ui.AfficherString("Veuillez saisir votre Nom : ");
                utilisateur.Nom = _ui.DemanderString();
                _ui.AfficherString("Veuillez saisir votre Mail : ");
                utilisateur.Mail = _ui.DemanderString();
                _ui.AfficherString("Veuillez saisir votre mot De Passe : ");
                utilisateur.MotDePasse = _ui.DemanderString();
                utilisateur.MontantCaisse = 500;
                // Ajout Utilisateur dans la Collection parente
                utilisateurs.Add(utilisateur);
                motDePasse = utilisateur.MotDePasse;
                mail = utilisateur.Mail;
            }
            if (commande.VerifierConnexion(mail, motDePasse))
            {
                while (true)
                {
                    _ui.AfficherStringLine("Ravi de vous revoir");

                    _ui.AfficherStringLine("Tappez 1 : Commander Grille??");
                    _ui.AfficherStringLine("Tappez 2 : Regler la commande");
                    _ui.AfficherStringLine("Votre choix est : ");
                    choix = _ui.DemanderString();

                    if (choix == "1")
                    {
                        Ticket ticket = new();
                        nombreGrille = _ui.DemanderDoubleEntreMinMax("\nVeuillez saisir le nombre de grille voulue", 1.00, 100.00);


                        ticket.FormatTicket(nombreGrille);
                        for (int g = 1; g <= nombreGrille; g++)
                        {
                            _ui.AfficherString($"\r\nGrille {g:00} :");
                            Grille grille = new();
                            grilles.Add(grille);
                        }
                    }
                    else if (choix == "2")
                    {

                        Console.WriteLine(grilles.Count);
                        double prix = newPrix.RetournerPrix(44); // une fois payer retunr true pour sortir de la boucle

                    }
                }

            }




            //Console.WriteLine(montantCaisse);
            ////caisse.Encaisser(prix);
            ////caisse.MontCaisse();
            //Console.WriteLine(montantCaisse);

            //_ui.AfficherStringLine("Tappez 1 pour creer un compte");
            //_ui.AfficherStringLine("Tappez 2 pour vous connecter");
            //_ui.AfficherStringLine("Tapper 3 pour quitter");

            //_ui.AfficherString("Saisissez votre choix est : ");
            //choix = _ui.DemanderString();

            //_ui.AfficherStringLine("\r\nTappez 1 pour nouvelle commande");
            //_ui.AfficherStringLine("Tappez 2 pour creer nouvelle utilisateur");
            //_ui.AfficherStringLine("Tapper 3 pour quitter");
            //_ui.AfficherString("Votre choix est : ");
            //choix = _ui.DemanderString();

            if (choix == "3")
                break;

        } while (true);
    }
}