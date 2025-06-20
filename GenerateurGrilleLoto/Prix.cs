namespace GenerateurGrilleLoto;

internal class Prix
{
    internal double RetournerPrix(double nombreGrille)
    {
        double prix = 0;

        for (int i = 1; i <= nombreGrille; i++)
        {
            if (i <= 2)
                prix += 7.50;

            else if (i <= 4)
                prix += 6.00;

            else if (i <= 6)
                prix += 4.50;

            else if (i <= 8)
                prix += 3.00;

            else if (i <= 10)
                prix += 1.50;
        }

        return prix;
    }
}
