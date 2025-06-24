using GrilleEuroMillion.Interaction;
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
    private readonly Grille grille = new();

    internal void Lancer()
    {
        string choix = "2";
        do
        {
            if (choix == "2")
            {
                List<Utilisateur> utilisateurs = []; // Collection des Utilisateurs
                Utilisateur utilisateur = new(); // Nouvelle objet pour nouveau utilisateur
                utilisateurs.Add(utilisateur); // Ajout Utilisateur dans la Collection parente
                utilisateur.VerifierConnexion(utilisateur.Mail, utilisateur.MotDePasse);
            }

            double nombreGrille = _ui.DemanderDoubleEntreMinMax("\nVeuillez saisir le nombre de grille voulue", 1.00, 100.00);
            Ticket ticket = new(nombreGrille, grille);
            ticket.FormatTicket();

            Prix newPrix = new();
            double prix = newPrix.RetournerPrix(ticket.NombreGrille);

            Caisse caisse = new();
            caisse.Encaisser(prix);

            _ui.AfficherStringLine("\r\nTappez 1 pour nouvelle commande");
            _ui.AfficherStringLine("Tappez 2 pour creer nouvelle utilisateur");
            _ui.AfficherStringLine("Tapper 3 pour quitter");
            _ui.AfficherString("Votre choix est : ");
            choix = _ui.DemanderString();

            if (choix == "3")
                break;

        } while (choix == "1" || choix == "2");
    }
}