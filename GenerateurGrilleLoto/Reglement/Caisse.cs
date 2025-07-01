using GrilleEuroMillion.Interaction;
using GrilleEuroMillion.Interface;

namespace GrilleEuroMillion.Reglement;

internal class Caisse(double montantCaisse, double choixTotalDeGrille)
{
    internal IInteractionUtilisateur _ui = new InteractionUtilisateurConsole();
    private readonly Prix _prix = new();

    internal bool TraiterPaiement()
    {
        double montantPrix = _prix.RetournerPrix(choixTotalDeGrille);
        _ui.AfficherStringLine($"\r\nPrix total est : {montantPrix} euro");
        bool paiementValid = false;
        if (montantCaisse - montantPrix <= 0)
        {
            _ui.AfficherStringLine($"\r\nMontant caisse insufisante {montantCaisse} € pour un paiement de {montantPrix} euro");
            _ui.AfficherStringLine($"\r\nVeuillez reduire le nombre de grilles");
        }
        else
        {
            _ui.AfficherStringLine($"\r\nVotre compte est a : {montantCaisse} euro");
            montantCaisse = montantCaisse - montantPrix;
            paiementValid = true;
            _ui.AfficherString($"Votre compte après paiement est a : {montantCaisse} euro\r\n");
        }
        return paiementValid;
    }
}