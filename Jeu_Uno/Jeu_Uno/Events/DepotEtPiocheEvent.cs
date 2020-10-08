using System;
using System.Collections.Generic;
/*========================================================================== */
/*          @Authors : Josue Lubaki & Ismael Coulibaly & Xuyao Hu           */
/*==========================================================================*/
namespace Jeu_Uno
{
    class DepotEtPiocheEvent : EventArgs
    {
        private LinkedListNode<Joueur> joueur;
        public DepotEtPiocheEvent(LinkedListNode<Joueur> joueur)
        {
            this.joueur = joueur;
        }
        public LinkedListNode<Joueur> Joueur
        {
            get { return joueur; }
        }
    }
}