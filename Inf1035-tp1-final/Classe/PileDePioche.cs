using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
/*========================================================================== */
/*          @Authors : Josue Lubaki & Ismael Coulibaly & Xuyao Hu           */
/*==========================================================================*/
namespace Jeu_Uno.Classe
{   /** PILEDEPIOCHE.cs : implementer à partir du stack, donc ayant acces à toutes les methodes de la pile Stack [LIFO] */
    class PileDePioche
    {
        private Stack<Carte> pioche = new Stack<Carte>();
        private int Size = 0;

        // Constructor
        public PileDePioche(int taille) : base()
        {
            Size = taille;
        }
        public Stack<Carte> Pioche
        {
            get { return pioche; }
            set { pioche = value; }

        }

        //Pile est vide ?
        public bool IsNull()
        {
            if (Taille() == 0)
            {
                return true;
            }
            return false;
        }

        // Pile est pleine
        public bool IsFull()
        {
            if (Taille() == Size)
            {
                return true;
            }
            return false;
        }

        // Obtenir la carte du dessus
        public Carte Peek()
        {
            if (pioche.Count == 0)
                return null;
            return pioche.Peek();
        }

        // Brasser la Pile de Pioche
        public async void BrasserCarte()
        {

            List<Carte> transition = new List<Carte>();
            List<Carte> listeTemporaire = new List<Carte>();//liste temporaire qui va nous servir a randomiser les cartes
            // Envoyer toutes les cartes de la table vers une liste
            transition = new List<Carte>();
            while (Pioche.Count > 0)
            { // Recuperer la carte du sommet puis le supprimer pour avoir accès au suivant
                transition.Add(Pioche.Peek());
                Pioche.Pop();
            }
            Carte carteRandom;
            while (transition.Count > 0)
            {
                // selectionner une carte au hasard
                int numberRandom = new Random().Next(0, transition.Count);
                carteRandom = transition[numberRandom];
                listeTemporaire.Add(carteRandom);
                transition.RemoveAt(numberRandom);
            }
            for (int a = 0; a < listeTemporaire.Count; a++)
            {
                Carte uneCarte;
                uneCarte = listeTemporaire[a];
                // Ajouter dans la Pile de Pioche du jeu et Supprimer dans la Pile de jeu
                pioche.Push(uneCarte);
            }
            //BrasseurDeCarte(pioche,transition, listeTemporaire,pioche);

            Console.WriteLine("\n\t\t░░░░ Nous avons sortit les Cartes du Paquet et nous sommes entrain de le brasser pour Vous... ░░░░\n");
            await Task.Delay(2000);
        }

        /** @see BrasseurDeCarte()
         * @param_1 : La Pile à vider
         * @param_1 : est une liste de transition, celle qui contient toutes les Cartes de ta Pile (mirroir de la Pile)
         * @param_2 : est une liste temporaire, celle qui contiendra les cartes déjà brassées
         * @param_3 : designe la pile qui contiendra les cartes brassées
         */
        public static void BrasseurDeCarte(Stack<Carte> piocheVider, List<Carte> transition, List<Carte> listeTemporaire, Stack<Carte> pioche)
        {
            while (piocheVider.Count > 0)
            { // Recuperer la carte du sommet puis le supprimer pour avoir accès au suivant
                transition.Add(piocheVider.Peek());
                piocheVider.Pop();
            }

            // Selectionner une Carte pour l'ajouter dans la listeTemporaire (liste contenant des cartes randomisée)
            while (transition.Count > 0)
            {
                // selectionner une carte au hasard
                int numberRandom = new Random().Next(0, transition.Count);
                Carte carteRandom = transition[numberRandom];
                listeTemporaire.Add(carteRandom);
                transition.RemoveAt(numberRandom);
            }

            // Remettre toutes les cartes dans la pioche (pioche considerée comme étant brassée)
            for (int a = 0; a < listeTemporaire.Count; a++)
            {
                Carte uneCarte;
                uneCarte = listeTemporaire[a];
                // Ajouter dans la Pile de Pioche du jeu et Supprimer dans la Pile de jeu
                pioche.Push(uneCarte);
            }
        }

        // Inserer une Carte
        public void Push(Carte item)
        {
            pioche.Push(item);
        }

        // Supprimer un élement de ma Pile
        public void Pop()
        {
            pioche.Pop();
        }

        // Obtenir la Taille de ma Pile
        public int Taille()
        {
            return pioche.Count;
        }
    }
}
