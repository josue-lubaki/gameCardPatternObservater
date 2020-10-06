using System.Collections.Generic;
/*====================================================================*/
/*          @Authors : Josue Lubaki & Ismael Coulibaly                */
/*====================================================================*/
namespace Jeu_Uno.Classe
{
    /** PILEDEJEU.cs : implementer à partir du stack, donc ayant acces à toutes les methodes de la pile Stack [LIFO] */
    class PileDeJeu
    {
        private readonly Stack<Carte> Desk = new Stack<Carte>();
        private readonly int Size = 0;

        // Constructor
        public PileDeJeu(int taille) : base()
        {
            Size = taille;
        }

        // Inserer une carte
        public void Push(Carte item)
        {
            Desk.Push(item);
        }

        // Enlever une Carte
        public void Pop()
        {
            Desk.Pop();
        }

        // Nombre de carte de la pile de jeu
        public int Taille()
        {
            return Desk.Count;
        }

        // La Carte au sommet de la pile
        public Carte Peek()
        {
            return Desk.Peek();
        }

        // Verifier si La Desk est vide
        public bool IsNull()
        {
            if (Desk.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
