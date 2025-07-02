namespace GrilleEuroMillion.Reglement;

internal static class Prix
{
    internal static double RetournerPrix(double nombreGrille, double remise = 1.50) // static appeler une seul fois
    {
        double prixBase = 7.50;
        int grillesParPalier = 10;
        int maxGrilles = 50;
        int nombreGrilles = (int)Math.Min(nombreGrille, maxGrilles); // On s'assure de ne pas dépasser la limite de 10
        int paliersComplets = nombreGrilles / grillesParPalier;
        int grillesRestantes = nombreGrilles % grillesParPalier;
        double totalPaliers = grillesParPalier * paliersComplets * (2 * prixBase - (paliersComplets - 1) * remise) / 2; // Somme arithmétique des paliers complets
        double prixDernierPalier = Math.Max(0, prixBase - paliersComplets * remise); // Dernier palier incomplet (s'il y a une grille "orpheline")
        double totalReste = grillesRestantes * prixDernierPalier;

        return totalPaliers + totalReste;
    }
}
