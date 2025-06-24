namespace GrilleEuroMillion.Interaction;

internal class InteractionUtilisateurConsole : IInteractionUtilisateur
{
    public double DemanderDoubleEntreMinMax(string message, double min, double max)
    {
        while (true)
        {
            Console.Write($"{message} entre {min} et {max} : ");
            string saisie = Console.ReadLine() ?? string.Empty;

            if (double.TryParse(saisie, out double montant) && montant >= min && montant <= max)
                return montant;
        }
    }

    public void AfficherString(string message)
    {
        Console.Write(message);
    }

    public void AfficherStringLine(string message)
    {
        Console.WriteLine(message);
    }

    public string DemanderString()
    {
        return Console.ReadLine() ?? string.Empty;
    }
}
