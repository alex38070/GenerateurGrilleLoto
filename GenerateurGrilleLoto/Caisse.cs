namespace GenerateurGrilleLoto;

//3. ⁠On encaisse un montant donné par le joueur supérieur au prix et inférieur à 100€
//4. Et rend l’éventuelle monnaie
internal class Caisse
{
    private readonly double _montantMax = 100.00;

    internal void Encaisser(double prix)
    {
        double montant = PrendreMonnaie(prix);
        Console.WriteLine(RendreMonnaie(prix, montant));
    }

    internal double PrendreMonnaie(double prix)
        => UtilitaireConsole.DemanderNombreFlotantEntreMinMax("Merci de saisir un montant à encaisser", prix, _montantMax);

    internal string RendreMonnaie(double prix, double montant)
    {
        double monnaie = montant - prix;

        return (monnaie == 0) ? "Merci pour l' appoint" : "Voici votre monnaie : " + monnaie;
    }
}