namespace GrilleEuroMillion.Interaction;

internal interface IInteractionUtilisateur
{
    double DemanderNombreFlotantEntreMinMax(string message, double min, double max);

    void AffichageTexte(string message);

    void AffichageTexteRetourLigne(string message);

    string DemanderTexteRetourLigne();
}
