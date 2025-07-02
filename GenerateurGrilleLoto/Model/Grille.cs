namespace GrilleEuroMillion.Model;

internal class Grille
{
    public List<int> GrilleList { get; set; } = new();

    internal Grille()
    {
        GrilleList = ObtenirGrille(); // elle ne peut pas etre nul car lutilisateur doit chois 1 ou 50
    }

    internal List<int> ObtenirGrille()
    {
        List<int> _numeros = [.. Enumerable.Range(1, 50)]; // ou soit Enumerable.Range(1, 50).ToList();
        List<int> _etoiles = [.. Enumerable.Range(1, 12)];
        List<int> grilleNombre = [];
        List<int> grilleEtoile = [];
        int nombreDeNombre = 5;
        int nombreEtoile = 2;

        do
        {
            int numero = NombreAleatoire(_numeros);
            if (!grilleNombre.Contains(numero))
                grilleNombre.Add(numero);

        } while (grilleNombre.Count < nombreDeNombre);

        do
        {
            int numero = NombreAleatoire(_etoiles);
            if (!grilleEtoile.Contains(numero))
                grilleEtoile.Add(numero);

        } while (grilleEtoile.Count < nombreEtoile);

        List<int> grilleAleatoire = grilleNombre.OrderBy(item => item).ToList();
        List<int> grilleEtoileTrier = grilleEtoile.OrderBy(item => item).ToList();

        for (int i = 0; i < grilleEtoileTrier.Count; i++)
        {
            grilleAleatoire.Add(grilleEtoileTrier[i]);
        }

        return grilleAleatoire;
    }

    internal int NombreAleatoire(List<int> liste)
    {
        return liste[Random.Shared.Next(1, liste.Count)];
    }
}