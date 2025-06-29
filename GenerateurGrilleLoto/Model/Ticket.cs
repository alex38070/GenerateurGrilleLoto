using GrilleEuroMillion.Interaction;
using GrilleEuroMillion.Interface;

namespace GrilleEuroMillion.Model;

internal class Ticket(double nombreGrille)
{
    internal double NombreGrille { get; set; } = nombreGrille;

    internal IInteractionUtilisateur _ui = new InteractionUtilisateurConsole();
    internal void FormaterTicket()
    {
        double nombreGrilleMax = 5;
        double NombreTickets = NombreGrille / nombreGrilleMax;
        double AffichageResteTicket = NombreGrille % nombreGrilleMax;

        DateTime dateTime = DateTime.Now;

        for (int i = 1; i <= NombreTickets; i++)
        {
            _ui.AfficherString($"\r\nTicket {i} :  {dateTime:dddd} {dateTime.Day:00} / {dateTime.Month:00} / {dateTime.Year}  {dateTime.Hour:00}:{dateTime.Minute:00}:{dateTime.Second:00}");
            AffichageGrille(nombreGrilleMax);
        }

        if (AffichageResteTicket > 0)
        {
            _ui.AfficherString($"\r\nTicket {(int)NombreTickets + 1} :  {dateTime:dddd} {dateTime.Day:00} / {dateTime.Month:00} / {dateTime.Year}  {dateTime.Hour:00}:{dateTime.Minute:00}:{dateTime.Second:00}");
            AffichageGrille(AffichageResteTicket);
        }
    }

    internal void AffichageGrille(double nombreGrilleMax)
    {
        for (int i = 1; i <= nombreGrilleMax; i++)
        {
            _ui.AfficherString($"\r\nGrille {i:00} :");
            Grille grille = new();
        }
    }
}