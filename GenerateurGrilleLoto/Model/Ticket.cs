using GrilleEuroMillion.Interaction;

namespace GrilleEuroMillion.Model;

internal class Ticket(double nombreGrille, Grille grille)
{
    internal double NombreGrille { get; set; } = nombreGrille;
    internal Grille Grille { get; set; } = grille;

    internal IInteractionUtilisateur _ui = new InteractionUtilisateurConsole();

    internal void FormatTicket()
    {
        double nombreTicket = NombreGrille / 5;
        DateTime dateTime = DateTime.Now;

        for (int t = 1; t <= nombreTicket; t++)
        {
            _ui.AfficherStringLine("");
            _ui.AfficherString($"\r\nTicket {t:00} :  Vendredi {dateTime.Day:00} / {dateTime.Month:00} / {dateTime.Year}  {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}\n");

            for (int g = 1; g <= 5; g++)
            {
                _ui.AfficherString($"\r\nGrille {g:00} :");
                Grille grille = new();
                grille.GenererGrille();
            }
        }
    }
}