namespace GenerateurGrilleLoto;

//on affiche les grilles sous le format :

//Grille 1 : 1 2 3 4 5 - 6 7
//Grille 2 : …

//Une grille EuroMillions se compose de 50 numéros(de 1 à 50) et 12 étoiles(de 1 à 12).

//Aucun chiffre ne peut être en double entre les numéros et les étoiles

//L’affichage des numéros est ordonné en ordre croissant, et idem pour les étoiles

//On ne doit pas générer de grilles identiques lors d’une même génération de plusieurs grilles

internal class Grille
{
    private readonly List<int> _numeros = Enumerable.Range(1, 50).ToList();
    private readonly List<int> _etoiles = Enumerable.Range(1, 12).ToList();

    internal void GenererGrille()
    {
        List<int> grilleNombre = [];
        List<int> grilleEtoile = [];

        ObtenirNumeroDifferentAleatoire(grilleNombre, 5);
        List<int> grilleNombreTrier = grilleNombre.OrderBy(item => item).ToList();

        ObtenirEtoileDifferentAleatoire(grilleNombre, grilleEtoile, 2);
        List<int> grilleEtoileTrier = grilleEtoile.OrderBy(item => item).ToList();

        Affichage(grilleNombreTrier);
        Affichage(grilleEtoileTrier);
    }

    internal List<int> ObtenirNumeroDifferentAleatoire(List<int> grilleNombre, int combienNombre)
    {
        do
        {
            int numero = _numeros[Random.Shared.Next(1, _numeros.Count)];
            if (!grilleNombre.Contains(numero))
                grilleNombre.Add(numero);

        } while (grilleNombre.Count < combienNombre);

        return grilleNombre;
    }

    internal List<int> ObtenirEtoileDifferentAleatoire(List<int> grilleNombre, List<int> grilleEtoile, int combienNombre)
    {
        do
        {
            int numero = _numeros[Random.Shared.Next(1, _etoiles.Count)];
            if (!grilleNombre.Contains(numero) && !grilleEtoile.Contains(numero))
                grilleEtoile.Add(numero);

        } while (grilleEtoile.Count < combienNombre);

        return grilleEtoile;
    }

    internal void Affichage(List<int> ListAAfficher)
    {
        for (int i = 0; i < ListAAfficher.Count; i++)
        {
            int item = ListAAfficher[i];
            Console.Write($"  {item:00}"); // :00 remplace => if (item < 10) Console.Write($" {item}");

            if (i == 4)
                Console.Write("  *");
        }
    }
}