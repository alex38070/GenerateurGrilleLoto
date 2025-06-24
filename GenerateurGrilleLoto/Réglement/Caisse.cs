namespace GenerateurGrilleEuroMillion.Réglement;

internal class Caisse
{
    private readonly InterfaceUtilitaire _utilitaireConsole = new();
    private readonly double _montantMax = 100.00;
    internal void Encaisser(double prix)
    {
        Console.WriteLine();
        double montant = PrendreMonnaie(prix);
        string monnaie = RendreMonnaie(prix, montant);
        Console.WriteLine(monnaie);
    }

    internal double PrendreMonnaie(double prix)
        => _utilitaireConsole.DemanderNombreFlotantEntreMinMax("\n\rMerci de saisir un montant à encaisser", prix, _montantMax);

    internal string RendreMonnaie(double prix, double montant)
    {
        double monnaie = montant - prix;

        return monnaie == 0 ? "Merci pour l' appoint" : "Voici votre monnaie : " + monnaie;
    }
}