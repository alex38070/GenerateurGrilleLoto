namespace GenerateurGrilleLoto.Interface_UIilisateur;
internal interface IUtilitaireConsole
{
    double DemanderNombreFlotantEntreMinMax(string message, double min, double max);

    bool VerifierConnection(string utilisateurMail, string utilisateurMotDePasse);

    void AffichageTexte(string message);

    void AffichageTexteRetourLigne(string message);

    string DemanderTexteRetourLigne();

}
