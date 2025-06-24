using GrilleEuroMillion.Interaction;

namespace GrilleEuroMillion.Reglement;

internal class Caisse
{
    internal IInteractionUtilisateur _ui = new InteractionUtilisateurConsole();
    private readonly double _montantMax = 100.00;

    internal void Encaisser(double prix)
    {
        _ui.AfficherStringLine("");
        double montant = PrendreMonnaie(prix);
        string monnaie = RendreMonnaie(prix, montant);
        _ui.AfficherStringLine(monnaie);
    }

    internal double PrendreMonnaie(double prix)
        => _ui.DemanderDoubleEntreMinMax("\n\rMerci de saisir un montant à encaisser", prix, _montantMax);

    internal string RendreMonnaie(double prix, double montant)
    {
        double monnaie = montant - prix;

        return monnaie == 0 ? "Merci pour l' appoint" : "Voici votre monnaie : " + monnaie;
    }
}