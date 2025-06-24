namespace GenerateurGrilleEuroMillion;

internal class InterfaceUtilitaire
{
    internal double DemanderNombreFlotantEntreMinMax(string message, double min, double max)
    {
        while (true)
        {
            Console.Write($"{message} entre {min} et {max} : ");
            string saisie = Console.ReadLine() ?? string.Empty;

            if (double.TryParse(saisie, out double montant) && montant >= min && montant <= max)
                return montant;
        }
    }

    internal bool VerifierConnection(string utilisateurMail, string utilisateurMotDePasse, InterfaceUtilitaire utilitaireConsole)
    {
        while (true)
        {
            utilitaireConsole.AffichageTexte("\r\nVeuillez saisir votre Identifiants de connection : ");
            string saisieidentifiant = Console.ReadLine() ?? string.Empty;
            utilitaireConsole.AffichageTexte("Veuillez saisir votre Mot de passe : ");
            string saisieMotDePasse = utilitaireConsole.DemanderTexteRetourLigne();

            if (saisieidentifiant == utilisateurMail && saisieMotDePasse == utilisateurMotDePasse)
                return true;
        }
    }

    internal void AffichageTexte(string message)
    {
        Console.Write(message);
    }

    internal void AffichageTexteRetourLigne(string message)
    {
        Console.WriteLine(message);
    }

    internal string DemanderTexteRetourLigne()
    {
        return Console.ReadLine() ?? string.Empty;
    }
}
