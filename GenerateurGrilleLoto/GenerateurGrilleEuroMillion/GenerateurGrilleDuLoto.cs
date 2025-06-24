using GenerateurGrilleLoto.Payement;
using System.Collections.ObjectModel;

namespace GenerateurGrilleLoto.GenerateurGrilleEuroMillion;

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
    internal void Lancer()
    {
        string choix = "2";
        do
        {
            if (choix == "2")
            {
                Collection<Utilisateur> utilisateurs = []; // Collection des Utilisateurs
                Utilisateur utilisateur = CreerNouvelleUtilisateur(); // Nouvelle objet pour nouveau utilisateur
                utilisateurs.Add(utilisateur); // Ajout Utilisateur dans la Collection parente
                UtilitaireConsole.VerifierConnection(utilisateur.Mail, utilisateur.MotDePasse);
            }

            double nombreGrille = UtilitaireConsole.DemanderNombreFlotantEntreMinMax("\nVeuillez saisir le nombre de grille voulue", 1.00, 100.00);
            Ticket ticket = new(nombreGrille);
            ticket.FormatTicket();

            Prix newPrix = new();
            double prix = newPrix.RetournerPrix(ticket.NombreGrille);

            Caisse caisse = new();
            caisse.Encaisser(prix);

            UtilitaireConsole.AffichageTexte("\r\nTappez 1 pour nouvelle commande");
            UtilitaireConsole.AffichageTexte("Tappez 2 pour creer nouvelle utilisateur");
            UtilitaireConsole.AffichageTexte("Tapper 3 pour quitter");
            choix = Console.ReadLine() ?? string.Empty;

            if (choix == "3")
                break;

        } while (choix == "1" || choix == "2");
    }

    internal Utilisateur CreerNouvelleUtilisateur()
    {
        UtilitaireConsole.AffichageTexte("Veuillez saisir votre Prénom : ");
        string prenom = Console.ReadLine() ?? string.Empty;
        UtilitaireConsole.AffichageTexte("Veuillez saisir votre Nom : ");
        string nom = Console.ReadLine() ?? string.Empty;
        UtilitaireConsole.AffichageTexte("Veuillez saisir votre Mail : ");
        string mail = Console.ReadLine() ?? string.Empty;
        UtilitaireConsole.AffichageTexte("Veuillez saisir votre mot De Passe : ");
        string motDePasse = Console.ReadLine() ?? string.Empty;

        return new(prenom, nom, mail, motDePasse);
    }
}