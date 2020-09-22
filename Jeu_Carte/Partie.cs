using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_Carte
{
    
    class Partie
    {
        //public static List<Carte> paquet = new List<Carte>();
        
        public Partie(int nbre_Joueur,List<Joueur> joueur) {
            //this.nbre_Joueur = nbre_Joueur;
            liste_Joueur = joueur;
        }
        public int nbre_Joueur
        {
            get { return nbre_Joueur; }
        }

        public static List<Joueur> liste_Joueur = new List<Joueur>();
        public List<Joueur> Liste_Joueur{
            get {return liste_Joueur;}
            set { liste_Joueur = value; }
        } 

       
    }
}
