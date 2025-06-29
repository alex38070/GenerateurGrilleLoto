using GrilleEuroMillion.Interaction;
using GrilleEuroMillion.Interface;

namespace GrilleEuroMillion.Model;

internal class Grille
{
    private readonly List<int> _numeros = Enumerable.Range(1, 50).ToList();
    private readonly List<int> _etoiles = Enumerable.Range(1, 12).ToList();
    internal IInteractionUtilisateur _ui = new InteractionUtilisateurConsole();

    internal Grille()
    {
        List<int> grilleNombre = [];
        List<int> grilleEtoile = [];
        int nombreGrilleNumeros = 5;
        int nombreEtoileNumeros = 2;

        ObtenirNumeroDifferentAleatoire(grilleNombre, nombreGrilleNumeros);
        List<int> grilleNombreTrier = grilleNombre.OrderBy(item => item).ToList();

        ObtenirEtoileDifferentAleatoire(grilleNombre, grilleEtoile, nombreEtoileNumeros);
        List<int> grilleEtoileTrier = grilleEtoile.OrderBy(item => item).ToList();

        Affichage(grilleNombreTrier);
        Affichage(grilleEtoileTrier);
    }

    internal List<int> ObtenirNumeroDifferentAleatoire(List<int> grilleNumeros, int combienNombre)
    {
        do
        {
            int numero = _numeros[Random.Shared.Next(1, _numeros.Count)];
            if (!grilleNumeros.Contains(numero))
                grilleNumeros.Add(numero);

        } while (grilleNumeros.Count < combienNombre);

        return grilleNumeros;
    }

    internal List<int> ObtenirEtoileDifferentAleatoire(List<int> grilleNumeros, List<int> grilleEtoile, int combienNombre)
    {
        do
        {
            int numero = _numeros[Random.Shared.Next(1, _etoiles.Count)];
            if (!grilleNumeros.Contains(numero) && !grilleEtoile.Contains(numero))
                grilleEtoile.Add(numero);

        } while (grilleEtoile.Count < combienNombre);

        return grilleEtoile;
    }

    internal void Affichage(List<int> ListAAfficher)
    {
        for (int i = 0; i < ListAAfficher.Count; i++)
        {
            int item = ListAAfficher[i];
            _ui.AfficherString($"  {item:00}");

            if (i == 4)
                _ui.AfficherString("  *");
        }
    }
}