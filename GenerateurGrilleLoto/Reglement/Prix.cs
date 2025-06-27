namespace GrilleEuroMillion.Reglement;

internal class Prix
{
    internal double RetournerPrix(double nombreGrille, double remise = 0.50)
    {
        double prixBase = 7.50;
        int grillesParPalier = 2;
        int maxGrilles = 100;
        int nombreGrilles = (int)Math.Min(nombreGrille, maxGrilles);
        int paliersComplets = nombreGrilles / grillesParPalier;
        int grillesRestantes = nombreGrilles % grillesParPalier;

        // Somme arithmétique des paliers complets
        double totalPaliers = grillesParPalier * paliersComplets * (2 * prixBase - (paliersComplets - 1) * remise) / 2;

        // Dernier palier incomplet (s'il y a une grille "orpheline")
        double prixDernierPalier = Math.Max(0, prixBase - paliersComplets * remise);
        double totalReste = grillesRestantes * prixDernierPalier;

        return totalPaliers + totalReste;
    }
}
