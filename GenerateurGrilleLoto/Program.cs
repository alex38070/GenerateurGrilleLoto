using GrilleEuroMillion.Generateur;
using GrilleEuroMillion.Interaction;
using GrilleEuroMillion.Interface;

namespace GrilleEuroMillion;

internal class Program()
{
    internal static void Main()
    {
        IInteractionUtilisateur _ui = new InteractionUtilisateurConsole();
        GenerateurGrilleDuLoto generateurGrilleDuLoto = new(_ui);
        generateurGrilleDuLoto.Lancer();
    }
}