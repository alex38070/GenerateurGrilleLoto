using GrilleEuroMillion.Interaction;
using GrilleEuroMillion.Interface;

namespace GrilleEuroMillion.Reglement;

internal class Caisse(double montantCaisse, double choixTotalDeGrille)
{
    internal IInteractionUtilisateur _ui = new InteractionUtilisateurConsole();
    private readonly double _montantMax = 100.00;
    private Prix prix = new();

    internal double Encaisser()
    {
        double montantPrix = prix.RetournerPrix(choixTotalDeGrille);
        montantCaisse = montantCaisse - montantPrix;
        Console.WriteLine(montantPrix);
        return montantCaisse;
    }




    //internal void Encaisser(double montantCaisse, double prix)
    //{
    //    _ui.AfficherStringLine("");
    //    double montant = PrendreMonnaie(montantCaisse, prix);
    //    string monnaie = RendreMonnaie(prix, montant);
    //    _ui.AfficherStringLine(monnaie);
    //}

    //internal double PrendreMonnaie(double montantCaisse, double prix)
    //    => _ui.DemanderDoubleEntreMinMax("\n\rMerci de saisir un montant à encaisser", prix, _montantMax);

    //internal string RendreMonnaie(double prix, double montant)
    //{
    //    double monnaie = montant - prix;

    //    return monnaie == 0 ? "Merci pour l' appoint" : "Voici votre monnaie : " + monnaie;
    //}
}