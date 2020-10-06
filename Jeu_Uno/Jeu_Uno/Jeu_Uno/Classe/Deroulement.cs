using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Jeu_Uno
{
    class DeroulementPartie : EventArgs
    {
        private static Random aleatoire = new Random();

        /* JouerCartePossible(param 1, param 2)
         * @param 1 : Liste qui contient les Cartes possible d'être jouer
         * @parm 2 : Carte qui represente le dessus du Desk (Dernière Carte jouée)
         * @parm 3 : La Table du jeu (Pile de Jeu)
         */
        public static Carte JouerCartePossible(List<Carte> t, Carte k, List<Carte> table)
        {
            int nbre = aleatoire.Next(0, t.Count);
            k = t[nbre];
            table.Add(k);
            t.RemoveAt(nbre);
            return k;
        }
       
        public static Carte cartePeek()
        {
            int derniereCarte = Partie.desk.Count;
            Carte c = Partie.desk[derniereCarte - 1];
            return c;
        }
        public static Carte piochee()
        {
            Carte carte_hasard;
            /* Prendre un chiffre au hasard et le faire correspondre à une carte 
             * sur toutes les cartes existantes dans la pile de poiche
             */
            if (Partie.PilePioche.Count == 1)
            {
                List<Carte> brasserCarte = new List<Carte>();
                // TODO : GERER LA MANQUE DES CARTES DANS LA PILE DE POICHE
                for (int i = 0; i < Partie.desk.Count; i++)
                {
                    brasserCarte = new List<Carte>();
                    int numberRandom = aleatoire.Next(0, Partie.desk.Count);
                    Carte brassee = Partie.desk[numberRandom];
                    brasserCarte.Add(brassee);
                    // Verifier si la carte existe déjà dans la liste ou pas
                    for (int a = 0; a < brasserCarte.Count; a++)
                    {
                        while (brassee == brasserCarte[a])
                        {
                            numberRandom = aleatoire.Next(0, Partie.desk.Count);
                            brassee = Partie.desk[numberRandom];
                        }
                        Partie.PilePioche.Add(brassee);
                        Partie.desk.Remove(brassee);
                    }
                }
                Console.WriteLine("\n\t--> La Pile de Pioche a été Brasser <--\n");
            }
            int chiffre_hasard = aleatoire.Next(0, Partie.PilePioche.Count);
            carte_hasard = Partie.PilePioche[chiffre_hasard];
            // retirer la carte selectionnée de la Pile de pioche pour éviter d'avoir des doublons
            Partie.PilePioche.RemoveAt(chiffre_hasard);
            return carte_hasard;
        }
        public static void PreDistribution()
        {
            int cpt = 1;
            while (cpt <= Program.nbreJoueurUser)
            {
                for (int t = 0; t < 8; t++)
                {
                    Carte hasard = piochee();
                    Program.liste_contener.Add(hasard);
                }
                cpt++;
            }
        }
        // Création des 52 Cartes de la Partie
        public static void initialisationCarte()
        {
            // Creation de 52 Cartes du Jeu
            for (int i = 1; i <= 13; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    Carte modele = new Carte(i, j);
                    Partie.PilePioche.Add(modele);
                }
            }
        }
    }
}