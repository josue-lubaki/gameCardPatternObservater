using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Jeu_Uno
{
    class DeroulementPartie : EventArgs
    {
        private string annonce;
        public static Carte topCarte;
        private static bool arret = false;
        private static Random aleatoire = new Random();
        public static LinkedList<Joueur> listeJoueur = new LinkedList<Joueur>();

        public DeroulementPartie(string annonce)
        {
            this.annonce = annonce;
        }
        public string Annonce
        {
            get { return annonce; }
            set { annonce = value; }
        }
        public static void ActionPlayers()
        {
            //passage d'une liste en un tableau
            Joueur[] sArray = new Joueur[listeJoueur.Count];
            listeJoueur.CopyTo(sArray, 0);
            //choisir un joueur au hasard pour debuter le jeu
            int chfPlayer = aleatoire.Next(0, listeJoueur.Count);
            Joueur firstPlayer = sArray[chfPlayer];
            var current = listeJoueur.Find(firstPlayer);
            for (int index = 0; index < Program.nbreJoueurUser; index++)
            {
                List<Carte> echantillon = new List<Carte>();
                if (index == 0)
                {
                    //Parcourir toutes ces Cartes afin de selectionner une carte aleatoire
                    var totalCartePlayer = firstPlayer.ListeCarte.Count;
                    int chfCarte = aleatoire.Next(0, totalCartePlayer);
                    Carte carteDebutJeu = firstPlayer.ListeCarte[chfCarte];
                    Console.Write("\nC'est " + current.Value.Nom + " qui commence le jeu (choisit aléatoirement)\n");
                    //Le Joueur joue sa carte
                    Partie.Desk.Add(carteDebutJeu);
                    firstPlayer.ListeCarte.Remove(carteDebutJeu);
                    Thread.Sleep(new Random().Next(600, 1200));
                    Console.WriteLine(firstPlayer.Nom + " a joué " + carteDebutJeu + "\tNbre Carte en main : " + firstPlayer.ListeCarte.Count);
                    topCarte = carteDebutJeu;
                    index++;
                }
                if (index == 1)
                {
                    // Revenir sur le LinkedList
                    LinkedList<Joueur> listeJoueurs = new LinkedList<Joueur>(sArray);
                    current = listeJoueur.Find(firstPlayer);
                    LinkedListNode<Joueur> currentNext = null;
                    if (current == listeJoueur.Last)
                    {
                        currentNext = listeJoueur.First;
                    }
                    else
                    {
                        currentNext = current.Next;
                    }
                    if (currentNext.Value.IsWinner())
                    {
                        Console.WriteLine(currentNext.Value.Nom + " " + currentNext.Value.Prenom
                            + " a remporté la Partie");
                        break; // on sort de la boucle for
                    }
                    //Parcourir toutes les cartes du joueur pour voir lesquelles correspondent au Desk
                    for (int t = 0; t < currentNext.Value.ListeCarte.Count; t++)
                    {
                        Carte r = currentNext.Value.ListeCarte[t];
                        //verifier la correspondance de Couleur ou de Valeur
                        if (r.Color == cartePeek().Color || r.Valeur_string == cartePeek().Valeur_string)
                        {
                            echantillon.Add(r);
                        }
                    }
                    /* echantillon : liste possédant les cartes possibles d'être joué par le Joueur
                     * Si la liste echantillon contien au moins une carte, le joueur peut jouer
                     */
                    if (echantillon.Count >= 1)
                    {
                        Carte cartePossible = JouerCartePossible(echantillon, topCarte, Partie.Desk);
                        Thread.Sleep(new Random().Next(600, 1200));
                        currentNext.Value.ListeCarte.Remove(cartePossible);
                        Console.WriteLine(currentNext.Value.Nom + " a joué " + cartePossible
                            + "\tNbre Carte en main : " + currentNext.Value.ListeCarte.Count);
                        topCarte = cartePossible;
                        // Verifier si le Joueur a gagné ou pas
                        if (currentNext.Value.IsWinner())
                        {
                            Console.WriteLine(currentNext.Value.Nom + " " + currentNext.Value.Prenom
                                + " a remporté la Partie");
                            break; // on sort de la boucle for
                        }
                    }
                    else
                    {
                        Carte cartePoichee = Partie.piochee();
                        Thread.Sleep(new Random().Next(600, 1200));
                        Console.WriteLine(currentNext.Value.Nom + " a Poiché la carte " + cartePoichee
                            + "\tNbre Carte en main : " + currentNext.Value.ListeCarte.Count);
                        currentNext.Value.ListeCarte.Add(cartePoichee);
                    }
                    //Faire correspondre la reference du Current au Joueur qui vient de jouer
                    current = currentNext;
                    index++;
                }
                while (!arret)
                {
                    if (index > 1)
                    {
                        // Le Joueur qui vient après le precedent
                        LinkedListNode<Joueur> currentNext = null;
                        if (current == listeJoueur.Last)
                        {
                            currentNext = listeJoueur.First;
                        }
                        else
                        {
                            currentNext = current.Next;
                        }
                        for (int t = 0; t < currentNext.Value.ListeCarte.Count; t++)
                        {
                            Carte r;
                            r = currentNext.Value.ListeCarte[t];
                            //verifier la Couleur et La Valeur
                            if (r.Color == cartePeek().Color || r.Valeur_string == cartePeek().Valeur_string)
                            {
                                echantillon.Add(r);
                            }
                        }
                        /* echantillon : liste possédant les cartes possibles d'être joué par le Joueur
                        * Si la liste echantillon contien au moins une carte, le joueur peut jouer
                        */
                        if (echantillon.Count >= 1)
                        {
                            Carte cartePossible = JouerCartePossible(echantillon, topCarte, Partie.Desk);
                            Thread.Sleep(new Random().Next(600, 1200));
                            currentNext.Value.ListeCarte.Remove(cartePossible);
                            Console.WriteLine(currentNext.Value.Nom + " a joué " + cartePossible
                                + "\tNbre Carte en main : " + currentNext.Value.ListeCarte.Count);
                            topCarte = cartePossible;
                            // Verifier si le joueur a gagné ou pas
                            if (currentNext.Value.IsWinner())
                            {
                                Console.WriteLine("*=====================================================*");
                                Console.WriteLine("*======>" + currentNext.Value.Nom + " " + currentNext.Value.Prenom
                                    + " a remporté la Partie <======*");
                                Console.WriteLine("*=====================================================*");

                                break; // on sort de la boucle for
                            }
                        }
                        else
                        {
                            Carte cartePoichee = Partie.piochee();
                            Thread.Sleep(new Random().Next(600, 1200));
                            currentNext.Value.ListeCarte.Add(cartePoichee);
                            Console.WriteLine(currentNext.Value.Nom + " a Poiché la carte " + cartePoichee
                               + "\tNbre Carte en main : " + currentNext.Value.ListeCarte.Count);
                        }
                        //Faire correspondre la reference du Current au Joueur qui vient de jouer
                        current = currentNext;
                        echantillon = new List<Carte>();
                        index++;
                    }
                }
            }
        }
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
        /* La Boucle While() est censée créer 8 Cartes d'une manière aléatoire associées 
        * à chaque Joueur(nbre_participant). Et les conserver dans la liste_contener
        */
        public static Carte cartePeek()
        {
            int derniereCarte = Partie.Desk.Count;
            Carte c = Partie.Desk[derniereCarte - 1];
            return c;
        }
    }
}