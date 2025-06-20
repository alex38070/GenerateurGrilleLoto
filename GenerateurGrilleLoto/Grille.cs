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
            List<int> grille = [];

            NumeroAleatoire(grille);
            EtoileAleatoire(grille);
            Console.Write("\r\nNumero : ");
            AfficherGrille(grille);

        }
    }

    internal List<int> NumeroAleatoire(List<int> _grille)
    {
        for (int i = 1; i <= 5; i++)
        {
            int numero = _numeros[Random.Shared.Next(1, _numeros.Count)];
            _grille.Add(numero);
        }
        return _grille;

    }

    internal List<int> EtoileAleatoire(List<int> _grille)
    {
        for (int i = 1; i <= 2; i++)
        {
            int numero = _etoiles[Random.Shared.Next(1, _etoiles.Count)];
            _grille.Add(numero);
        }
        return _grille;
    }

    internal void AfficherGrille(List<int> _grille)
    {
        foreach (int item in _grille)
        {
            if (item < 10)
                Console.Write($" {item} ");
            if (item >= 10)
                Console.Write($"{item} ");
        }

    }
}