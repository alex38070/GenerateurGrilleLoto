namespace GenerateurGrilleLoto;

internal class Prix
{
    internal double RetournerPrix2(double nombreGrille)
    {
        double prix = 0;

        //for (int i = 1; i <= nombreGrille; i++)
        //{
        //    if (i <= 2)
        //        prix += 7.50; // (7.50 - (0 * 1.50)) * i

        //    else if (i <= 4)
        //        prix += 6.00; // (7.50 - (1 * 1.50)) * nb

        //    else if (i <= 6)
        //        prix += 4.50; // (7.50 - (2 * 1.50)) * nb

        //    else if (i <= 8)
        //        prix += 3.00; // (7.50 - (3 * 1.50)) * nb

        //    else if (i <= 10)
        //        prix += 1.50; // (7.50 - (4 * 1.50)) * nb
        //}

        for (int i = 1; i <= nombreGrille; i++)
        {
            int palier = (i - 1) / 2; // 0 pour les grilles 1-2, 1 pour 3-4, etc.
            double prixGrille = Math.Max(0, 7.50 - palier * 1.50);
            prix += prixGrille;
        }

        return prix;
    }

    internal double RetournerPrix(double nombreGrille, double remise = 1.50)
    {
        double prixBase = 7.50;
        int grillesParPalier = 2;
        int maxGrilles = 10;
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
