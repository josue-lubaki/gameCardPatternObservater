using System;
using System.Collections.Generic;
using System.Text;
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
            return pioche.Peek();
        }

        public void BrasserCarte()
        {
            List<Carte> listeTemporaire = new List<Carte>();//liste temporaire qui va nous servir a randomiser les cartes
            /* Prendre un chiffre au hasard et le faire correspondre à une carte 
            * sur toutes les cartes existantes dans la pile de jeu (Desk) sur la table de jeu */
             listeTemporaire = new List<Carte>();

                // Envoyer toutes les cartes de la table vers une liste
                List<Carte> transition = new List<Carte>();
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
                for(int a = 0; a < listeTemporaire.Count; a++)
                {
                    Carte uneCarte;
                    uneCarte = listeTemporaire[a];
                    // Ajouter dans la Pile de Pioche du jeu et Supprimer dans la Pile de jeu
                    pioche.Push(uneCarte);
                }
            Console.WriteLine("\n\t\t--> La Pile de Pioche a été Brasser <--\n");
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

       /* public static implicit operator PileDePioche(PileDeJeu v)
        {
            throw new NotImplementedException();
        }*/
    }
}
