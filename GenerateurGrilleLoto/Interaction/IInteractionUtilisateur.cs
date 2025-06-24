namespace GrilleEuroMillion.Interaction;

internal interface IInteractionUtilisateur
{
    double DemanderDoubleEntreMinMax(string message, double min, double max);

    void AfficherString(string message);

    void AfficherStringLine(string message);

    string DemanderString();
}
