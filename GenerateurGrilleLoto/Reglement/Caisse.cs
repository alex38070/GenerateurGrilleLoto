using GrilleEuroMillion.Interaction;

namespace GrilleEuroMillion.Reglement;

internal class Caisse
{
    private readonly InteractionUtilisateurConsole _utilitaireConsole = new();
    private readonly double _montantMax = 100.00;
    internal void Encaisser(double prix)
    {
        Console.WriteLine();
        double montant = PrendreMonnaie(prix);
        string monnaie = RendreMonnaie(prix, montant);
        Console.WriteLine(monnaie);
    }

    internal double PrendreMonnaie(double prix)
        => _utilitaireConsole.DemanderDoubleEntreMinMax("\n\rMerci de saisir un montant à encaisser", prix, _montantMax);

    internal string RendreMonnaie(double prix, double montant)
    {
        double monnaie = montant - prix;

        return monnaie == 0 ? "Merci pour l' appoint" : "Voici votre monnaie : " + monnaie;
    }
}