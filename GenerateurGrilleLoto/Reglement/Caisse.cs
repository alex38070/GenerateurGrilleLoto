﻿using GrilleEuroMillion.Interface;

namespace GrilleEuroMillion.Reglement;

internal class Caisse(IInteractionUtilisateur _ui, double montantCaisse, double choixTotalDeGrille)
{
    internal IInteractionUtilisateur _ui = _ui;

    internal bool TraiterPaiement()
    {
        double montantPrix = Prix.RetournerPrix(choixTotalDeGrille);
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
            _ui.AfficherStringLine($"Votre compte après paiement est a : {montantCaisse} euro");
        }
        return paiementValid;
    }
}