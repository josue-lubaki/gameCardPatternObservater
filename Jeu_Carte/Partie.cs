﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_Carte
{
    
    class Partie
    {
        private int nbre_Joueur;
        public Partie(int nbre_Joueur,List<Joueur> joueur) {
            Nbre_Joueur = nbre_Joueur;
            liste_Joueur = joueur;
        }
        public int Nbre_Joueur
        {
            get { return nbre_Joueur; }
            set { nbre_Joueur = value; }
        }

        public static List<Joueur> liste_Joueur = new List<Joueur>();
      

        public List<Joueur> Liste_Joueur{
            get {return liste_Joueur;}
            set { liste_Joueur = value; }
        }

        public void ToString()
        {
            var output = "\t\tNotre Partie de Jeu comprend " + Nbre_Joueur + " Joueurs\n" +
                "Bienvenues à nos Joueurs :\n";
            Console.WriteLine("==================================================================================");
            Console.Write(output);
            Index.affichage_liste_Joueur(Liste_Joueur);
            Console.WriteLine("==================================================================================");

        }
    }
}
