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



       public static List<Carte> pioche = new List<Carte>();// pile de pioche
       public static List<Carte> pileDepot = new List<Carte>();//pile de depot de l'arene


        //METHODE QUI VA LANCER LE JEU
        public void Play()
        {
            
            //On remplit la pioche avec le reste des cartes non distribués au joueur (cartes dans le paquet)
            Console.WriteLine("Voici le contenu de la pioche ");



             for (int k = 0; k < Carte.paquet.Count; k++)
               {
                   pioche.Add(Carte.paquet[k]);
                   Console.WriteLine($"           {pioche[k]}");

               }
            Console.WriteLine($"Il y a {pioche.Count} cartes restantes dans la pioche");
           // pioche = Carte.paquet;

            //******** un joueur est choisi aléatoirement pour commencer la partie***********
            //
            //
            //


            Random aleatoire = new System.Random();
            int randomIndex = aleatoire.Next(0, liste_Joueur.Count);// on choisit un index au hasard
            Joueur randomPlayer;
            randomPlayer = liste_Joueur[randomIndex];


            pileDepot.Add(randomPlayer.GetList_Carte()[randomPlayer.GetList_Carte().Count - 1]);///je voudrais acceder a la liste de carte du joueur choisi aleatoirement
            randomPlayer.GetList_Carte().RemoveAt(randomPlayer.GetList_Carte().Count - 1);//pour prendre une carte de sa main et la mettre dans la pile de depot de l'arene.


            Boolean carteValide = false; //carte de meme couleur ou de meme valeur sur la pile de dépot
            Boolean tourComplet = false;//variable permettant de detecter lorsque tous les joueurs ont joue (un tour complet)
            
            
            for (int i= liste_Joueur.IndexOf(randomPlayer); i < liste_Joueur.Count; i++)
            {
                List<Carte> echantillon = new List<Carte>();//liste de carte qui permettra de conserver les cartes possibles d'etre jouees

                for(int j=0; i< liste_Joueur[i].GetList_Carte().Count; j++)
                {
                    Carte uneCarte = liste_Joueur[i].GetList_Carte()[j];

                    if(uneCarte.GetColor() == pileDepot[pileDepot.Count - 1].GetColor()
                        || uneCarte.GetValeur_String() == pileDepot[pileDepot.Count-1].GetValeur_String())// on verifie que les conditions sont respectees

                     {
                        echantillon = new List<Carte>();
                        echantillon.Add(uneCarte);
                        pileDepot.Add(uneCarte);
                    }
                }

                /*if (i == liste_Joueur.Count)
                {

                }
                */
                tourComplet = true;

                if(i == liste_Joueur.Count - 1) { i = -1; }
                
            }

            

        }


        public override string ToString()
        {
            var output = "\t\tNotre Partie de Jeu comprend " + Nbre_Joueur + " Joueurs\n" +
                "Bienvenues à nos Joueurs :\n";
            Console.WriteLine("==================================================================================");
            Console.Write(output);
            Index.affichage_liste_Joueur(Liste_Joueur);
            Play();

            return ("==================================================================================");

        }
    }



 }
