using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_Carte
{
    class Deroulement
    {
        // Todo : La Table de jeu (liste des cartes posées sur le terrain)
        public static List<Carte> cartesJouees = new List<Carte>();
        private Partie partie;
        public Deroulement(Partie partie) {
            this.partie = partie;
        }
        public List<Carte> CartesJouees
        {
            get { return cartesJouees; }
        }
        public Partie Partie
        {
            get { return Partie; }
        }

       
        

    }
}
