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

    internal static bool VerifierConnection(string utilisateurMail, string utilisateurMotDePasse)
    {
        while (true)
        {
            UtilitaireConsole.AffichageTexte("\r\nVeuillez saisir votre Identifiants de connection : ");
            string saisieidentifiant = Console.ReadLine() ?? string.Empty;
            UtilitaireConsole.AffichageTexte("Veuillez saisir votre Mot de passe : ");
            string saisieMotDePasse = UtilitaireConsole.DemanderTexteRetourLigne();

            if (saisieidentifiant == utilisateurMail && saisieMotDePasse == utilisateurMotDePasse)
                return true;
        }
    }

    internal static void AffichageTexte(string message)
    {
        Console.Write(message);
    }

    internal static void AffichageTexteRetourLigne(string message)
    {
        Console.WriteLine(message);
    }

    internal static string DemanderTexteRetourLigne()
    {
        return Console.ReadLine() ?? string.Empty;
    }
}
