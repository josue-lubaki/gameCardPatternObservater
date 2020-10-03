using System;
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

        public static void initialisationCarte()
        {
            // Creation de 52 Cartes du Jeu
            for (int i = 1; i <= 13; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    Carte modele = new Carte(i, j);
                    Carte.paquet.Add(modele);
                }
            }
        }
public void ToString()
        {
            var output = "\t\tNotre Partie de Jeu comprend " + Nbre_Joueur + " Joueurs\n" +
                "Bienvenues à nos Joueurs :\n";
            Console.WriteLine("==================================================================================");
            Console.Write(output);
            Index.Affichage_liste_Joueur(Liste_Joueur);
            Console.WriteLine("==================================================================================");

        }
    }
}
