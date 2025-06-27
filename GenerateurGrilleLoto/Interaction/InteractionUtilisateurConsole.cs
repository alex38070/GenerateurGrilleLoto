using GrilleEuroMillion.Interface;

namespace GrilleEuroMillion.Interaction;

internal class InteractionUtilisateurConsole : IInteractionUtilisateur
{
    public double DemanderDoubleEntreMinMax(string message, double min, double max)
    {
        while (true)
        {
            AfficherString($"{message} entre {min} et {max} : ");
            string saisie = DemanderString("");

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

    public string DemanderString(string message)
    {
        while (true)
        {
            Console.Write(message);
            string reponse = Console.ReadLine() ?? string.Empty;
            if (reponse.Length > 0)
                return reponse;
        }
    }

    public string DemanderChoix(string message)
    {
        while (true)
        {
            Console.Write(message);
            string reponse = Console.ReadLine() ?? string.Empty;
            if (reponse == "1" || reponse == "2")
                return reponse;
        }

    }


    public string DemanderMail(string message)
    {
        while (true)
        {
            Console.Write(message);
            string reponse = Console.ReadLine() ?? string.Empty;
            if (reponse.Length > 1 && reponse.Contains("@"))
                return reponse;
        }

    }

    public double NombreGrille(double choixTotalDeGrille, double nombreGrille)
    {
        return (choixTotalDeGrille + nombreGrille);
    }

}
