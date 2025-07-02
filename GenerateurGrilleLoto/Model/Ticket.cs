using GrilleEuroMillion.Interface;

namespace GrilleEuroMillion.Model;

internal class Ticket(IInteractionUtilisateur _ui, double nombreGrille)
{
    internal double NombreGrille { get; set; } = nombreGrille;
    internal IInteractionUtilisateur _ui = _ui;

    internal void ImprimerTicket()
    {
        double nombreGrilleMax = 5;
        double NombreTickets = NombreGrille / nombreGrilleMax;
        double AffichageResteTicket = NombreGrille % nombreGrilleMax;

        DateTime dateTime = DateTime.Now;

        for (int i = 1; i <= NombreTickets; i++)
        {
            _ui.AfficherStringLine("");
            _ui.AfficherString($"\r\nTicket {i:00} :  {dateTime:dddd} {dateTime.Day:00} / {dateTime.Month:00} / {dateTime.Year}  {dateTime.Hour:00}:{dateTime.Minute:00}:{dateTime.Second:00}");
            AfficherGrille(nombreGrilleMax);
        }

        if (AffichageResteTicket > 0)
        {
            _ui.AfficherStringLine("");
            _ui.AfficherString($"\r\nTicket {(int)NombreTickets + 1:00} :  {dateTime:dddd} {dateTime.Day:00} / {dateTime.Month:00} / {dateTime.Year}  {dateTime.Hour:00}:{dateTime.Minute:00}:{dateTime.Second:00}");
            AfficherGrille(AffichageResteTicket);
        }
    }

    internal void AfficherGrille(double nombreGrilleMax)
    {
        for (int i = 1; i <= nombreGrilleMax; i++)
        {
            _ui.AfficherString($"\r\nGrille {i:00} :");
            Grille grille = new();
            AffichagerNombreEtoileGrille(grille);
            List<Grille> grilles = new();
            grilles.Add(grille);
        }
    }

    internal void AffichagerNombreEtoileGrille(Grille grille)
    {
        for (int i = 0; i < grille.GrilleList.Count; i++)
        {
            int item = grille.GrilleList[i];
            _ui.AfficherString($"  {item:00}");

            if (i == 4)
                _ui.AfficherString("  *");
        }
    }
}