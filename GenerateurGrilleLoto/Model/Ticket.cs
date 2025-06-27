using GrilleEuroMillion.Interaction;
using GrilleEuroMillion.Interface;

namespace GrilleEuroMillion.Model;

internal class Ticket()
{
    internal double NombreGrille { get; set; }

    internal IInteractionUtilisateur _ui = new InteractionUtilisateurConsole();

    //internal void FormatTicket(double nombreGrille)
    //{
    //    double nombreTicket = NombreGrille / 5;
    //    DateTime dateTime = DateTime.Now;
    //    Grille Grille = new();

    //    for (int t = 1; t <= nombreTicket; t++)
    //    {
    //        _ui.AfficherStringLine("");
    //        _ui.AfficherString($"\r\nTicket {t:00} :  Vendredi {dateTime.Day:00} / {dateTime.Month:00} / {dateTime.Year}  {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}\n");

    //        for (int g = 1; g <= NombreGrille; g++)
    //        {
    //            _ui.AfficherString($"\r\nGrille {g:00} :");
    //            //Grille grille = new();
    //            //grille.GenererGrille();
    //        }
    //    }
    //}

    internal void FormatTicket() // double nombreGrille
    {
        DateTime dateTime = DateTime.Now;
        _ui.AfficherString($"\r\nTicket 1 :  {dateTime:dddd} {dateTime.Day:00} / {dateTime.Month:00} / {dateTime.Year}  {dateTime.Hour:00}:{dateTime.Minute:00}:{dateTime.Second:00}\n");
        //AffichageGrille(nombreGrille);
        _ui.AfficherStringLine("");

    }
    internal void AffichageGrille(double nombreGrille)
    {
        for (int g = 1; g <= nombreGrille; g++)
        {
            _ui.AfficherString($"\r\nGrille {g:00} :");
            Grille grille = new();
        }

    }
}