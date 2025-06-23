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
            Console.Write("\r\nVeuillez saisir votre Identifiants de connection : ");
            string saisieidentifiant = Console.ReadLine() ?? string.Empty;
            Console.Write("Veuillez saisir votre Mot de passe : ");
            string saisieMotDePasse = Console.ReadLine() ?? string.Empty;

            if (saisieidentifiant == utilisateurMail && saisieMotDePasse == utilisateurMotDePasse)
                return true;
        }
    }
}
