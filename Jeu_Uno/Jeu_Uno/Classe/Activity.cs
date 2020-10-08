using Jeu_Uno.Classe;
using System;
using System.Collections.Generic;

/*====================================================================*/
/*          @Authors : Josue Lubaki & Ismael Coulibaly & Xuyao Hu     */
/*====================================================================*/
namespace Jeu_Uno
{
    /** ACTIVITY.cs : est une classe qui gère toutes les actions avant et pendant le jeu telles : 
     * Préparer les 52 Cartes du jeu [@see InitialisationCarte()],
     * Dépendant du nombre de joueur(elle pioche les cartes nécessaire dans le paquet de carte [@see PreDistribution()]),
     * Véerifier les Cartes possible d'être jouée par rapport à la main du joueur [@see joueurCartePossible()], 
     * Piochée une carte dans la Pile reservée à la pioche [@see Piochee()]
     * 
     */
    class Activity : EventArgs
    {
        private static Random aleatoire = new Random();
        /* JouerCartePossible(param 1, param 2)
         * @param 1 : Liste qui contient les Cartes possible d'être jouer
         * @parm 2 : Carte qui represente le dessus du Desk (Dernière Carte jouée)
         * @parm 3 : La Table du jeu (Pile de Jeu)
         */
        public static Carte JouerCartePossible(List<Carte> t, Carte k, PileDeJeu table)
        {
            int nbre = aleatoire.Next(0, t.Count);
            k = t[nbre];
            table.Push(k);
            t.RemoveAt(nbre);
            return k;
        }

        public static Carte Piocher()
        {
            Carte carte_dessus = Partie.pileDePioche.Peek();
            // retirer la carte selectionnée de la Pile de pioche pour éviter d'avoir des doublons
            Partie.pileDePioche.Pop();
            return carte_dessus;
        }

        
       
        public static void Distribution()
        {
            int cpt = 1;
            while (cpt <= Program.nbreJoueurUser)
            {
                for (int t = 0; t < 8; t++)
                {
                    Carte hasard = Piocher();
                    Program.liste_contener.Add(hasard);
                }
                cpt++;
            }
        }
        // Création des 52 Cartes de la Partie
        public static void InitialisationCartes()
        {
            for (int i = 1; i <= 13; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    Carte modele = new Carte(i, j);
                    Partie.pileDePioche.Push(modele);
                }
            }
        }
        public static List<Carte> NbreCarteParContext(List<Carte> t, List<Carte> s){
            if (t.Count == 8)
            { // Lorsqu'on a qu'un seul Joueur
                for (int i = 0; i < (t.Count); i++)
                {
                    s.Add(t[i]);
                }
            }
            else if (t.Count == 16) // Pour 2 Joueurs
            {
                for (int i = 0; i < (t.Count - 8); i++)
                {
                    s.Add(t[i]);
                }
            }
            else if (t.Count == 24) // Pour 3 joueurs
            {
                for (int i = 0; i < (t.Count - 16); i++)
                {
                    s.Add(t[i]);
                }
            }
            else if (t.Count == 32) // Pour 4 Joueurs
            {
                for (int i = 0; i < (t.Count - 24); i++)
                {
                    s.Add(t[i]);
                }
            }
            else // Pour Autres valeurs
            {
                Console.WriteLine("Désolé, le nombre des joueurs est incorrect, nous n'acceptons qu'un minimun de 2 Joueurs et un maximun" +
                "de 4 Joueurs");
            }
            return s;
        }
        //Choix aleatoire dans le noeud
        public static LinkedListNode<Joueur> choixAlea(LinkedList<Joueur> liste, int nbreParticipant)
        {
            LinkedListNode<Joueur> place = null;
            while (place == null)
            {
                int valeur = new Random().Next(0, nbreParticipant);
                if (valeur == 0)
                    place = liste.First.Next;
                else if (valeur == 1)
                    place = liste.Last;
                else if (valeur == 2)
                    place = liste.Last.Previous;
                else if (valeur == 3)
                    place = liste.First.Next.Next;
                else
                    place = liste.First;
            }
            return place;
        }
    }
}