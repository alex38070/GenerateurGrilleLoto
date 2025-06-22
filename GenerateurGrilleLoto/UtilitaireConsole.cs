namespace GenerateurGrilleLoto;
internal static class UtilitaireConsole
{
    internal static double DemanderNombreFlotantEntreMinMax(string message, double min, double max)
    {
        while (true)
        {
            Console.Write($"{message} entre {min} et {max} : ");
            string saisie = Console.ReadLine() ?? string.Empty;

            if (double.TryParse(saisie, out double montant) && montant >= min && montant <= max)
                return montant;
        }
    }
}
