namespace GrilleEuroMillion.Model;

internal class Ticket(double nombreGrille, Grille grille) // , Grille newGrille
{
    internal double NombreGrille { get; set; } = nombreGrille;
    internal Grille Grille { get; set; } = grille;

    //internal Grille NewGrille { get; set; } = newGrille;

    internal void FormatTicket()
    {
        double nombreTicket = NombreGrille / 5;
        DateTime dateTime = DateTime.Now;

        for (int t = 1; t <= nombreTicket; t++)
        {
            Console.WriteLine();
            Console.Write($"\r\nTicket {t:00} :  Vendredi {dateTime.Day:00} / {dateTime.Month:00} / {dateTime.Year}  {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}\n");

            for (int g = 1; g <= 5; g++)
            {
                Console.Write($"\r\nGrille {g:00} :");
                Grille grille = new();
                grille.GenererGrille();
            }
        }
    }
}