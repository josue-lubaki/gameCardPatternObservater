using System;
using System.Collections.Generic;
using System.Collections;

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

        public override string ToString()
        {
            var output = "\t\tNotre Partie de Jeu comprend " + Nbre_Joueur + " Joueurs\n" +
                "Bienvenues à nos Joueurs :\n";
            Console.WriteLine("==================================================================================");
            Console.Write(output);
            Index.affichage_liste_Joueur(Liste_Joueur);
            return("==================================================================================");

        }


        //METHODE QUI VA LANCER LE JEU
        public void play()
        {
            ToString();
            //On remplit la pioche avec le reste des cartes non distribués au joueur (cartes dans le paquet)
            Console.WriteLine("Voici le contenu de la pioche ");



            ArrayList pioche = new ArrayList();// pile de pioche
            ArrayList pileDepot = new ArrayList();//pile de depotde l'arene

            for (int k = 0; k < Carte.paquet.Count; k++)
            {
                pioche.Add(Carte.paquet[k]);
                Console.WriteLine($"        *****    {pioche[k]}");

            }
            Console.WriteLine($"Il y a {pioche.Count} cartes restantes dans la pioche");


            //******** un joueur est choisi aléatoirement pour commencer la partie***********
            //
            //
            //
           

            Random aleatoire = new System.Random();
            int randomIndex = aleatoire.Next(0, liste_Joueur.Count);// on choisit un index au hasard
            Joueur randomPlayer;
            randomPlayer= liste_Joueur[randomIndex];


            pileDepot.Add(randomPlayer.GetList_Carte().Count - 1);///je voudrais acceder a la liste de carte du joueur choisi aleatoirement
            randomPlayer.GetList_Carte().RemoveAt(randomPlayer.GetList_Carte().Count -1);//pour prendre une carte de sa main et la mettre dans la pile de depot de l'arene.


            for (int i=0; i < liste_Joueur.Count; i++)
            {
                int chiffre_hasard = aleatoire.Next(0, Carte.paquet.Count);
            }

        }
    }


   /* static void Main(string[] args)
    {
    }
   */



 }
