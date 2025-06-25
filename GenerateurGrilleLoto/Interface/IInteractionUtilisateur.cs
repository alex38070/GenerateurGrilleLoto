namespace GrilleEuroMillion.Interface;

internal interface IInteractionUtilisateur  // Pour Changer de Console a WinForm ou Blazor en ce connectant direct a linterface prise 220.....
{
    double DemanderDoubleEntreMinMax(string message, double min, double max);

    void AfficherString(string message);

    void AfficherStringLine(string message);

    string DemanderString();
}
