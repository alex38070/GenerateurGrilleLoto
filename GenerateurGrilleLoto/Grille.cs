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

    internal void GenererGrille(double nombreGrille)
    {

        for (int i = 1; i <= nombreGrille; i++)
        {

            Console.Write($"\r\nGrille {i} : ");
            AfficherGrille();

        }
    }

    internal void AfficherGrille()
    {
        List<int> grille = [];

        ObtenirNumeroAleatoire(grille);

        ObtenirEtoileAleatoire(grille);

        List<int> grilleTriee = grille.OrderBy(item => item).ToList();

        for (int i = 0; i < grilleTriee.Count; i++)
        {
            int item = grilleTriee[i];

            if (item < 10)
                Console.Write($"  {item}");
            else
                Console.Write($" {item}");

            if (i == 4)
                Console.Write("  * ");
        }
    }

    internal List<int> ObtenirNumeroAleatoire(List<int> grille)
    {
        for (int i = 1; i <= 5; i++)
        {
            int numero = _numeros[Random.Shared.Next(1, _numeros.Count)];
            grille.Add(numero);

        }

        return grille;
    }

    internal List<int> ObtenirEtoileAleatoire(List<int> grille)
    {
        for (int i = 1; i <= 2; i++)
        {
            int numero = _etoiles[Random.Shared.Next(1, _etoiles.Count)];
            grille.Add(numero);
        }

        return grille;
    }
}