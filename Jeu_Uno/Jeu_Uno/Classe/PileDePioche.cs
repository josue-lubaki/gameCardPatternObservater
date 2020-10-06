using System;
using System.Collections.Generic;
using System.Text;
/*====================================================================*/
/*          @Authors : Josue Lubaki & Ismael Coulibaly                */
/*====================================================================*/
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
            if (Taille() == 0)
            {
                BrasserCarte();
            }
            return pioche.Peek();
        }

        public void BrasserCarte()
        {

            Console.WriteLine("\n\t--> !!! La pile de Pioche est vide !!! <--\n");
            List<Carte> brasserCarte = new List<Carte>();
            /* Prendre un chiffre au hasard et le faire correspondre à une carte 
            * sur toutes les cartes existantes dans la pile de jeu (Desk) sur la table de jeu */
            for (int i = 0; i < Partie.tableDeJeu.Taille(); i++)
            {
                brasserCarte = new List<Carte>();
                int numberRandom = new Random().Next(0, Partie.tableDeJeu.Taille());
                // Envoyer toutes les cartes de la tableu vers une liste
                List<Carte> transition = new List<Carte>();
                while (!Partie.tableDeJeu.IsNull())
                { // Recuperer la carte du sommet puis le supprimer pour avoir accès au suivant
                    transition.Add(Partie.tableDeJeu.Peek());
                    Partie.tableDeJeu.Pop();
                }
                Carte carteRandom = transition[numberRandom];
                brasserCarte.Add(carteRandom);
                // Verifier si la carte existe déjà dans la liste ou pas
                for (int a = 0; a < brasserCarte.Count; a++)
                {
                    while (carteRandom == brasserCarte[a])
                    {
                        numberRandom = new Random().Next(0, Partie.tableDeJeu.Taille());
                        carteRandom = transition[numberRandom];
                    }
                    // Ajouter dans la Pile de Pioche du jeu et Supprimer dans la Pile de jeu
                    Partie.pileDePioche.Push(carteRandom);
                    Partie.tableDeJeu.Pop();
                }
            }
            Console.WriteLine("\n\t--> La Pile de Pioche a été Brasser <--\n");

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
