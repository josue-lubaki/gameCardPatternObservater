using System;
using System.Collections.Generic;

namespace Jeu_Carte
{
    class Index
    {
        public enum Color { Trefle, Carreau, Coeur, Pique };
        private static List<Carte> liste_u = new List<Carte>();
        public static int p_index = 1;
        private static Carte item;
        public static List<Joueur> liste_Joueur = new List<Joueur>();
        static void Main(string[] args)
        {
            Random aleatoire = new Random();
            // Creation de 52 Cartes du Jeu
            for (int i = 1; i <= 13; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    Carte modele = new Carte(i, j);
                    Carte.Paquet.Add(modele);
                }
            }

            /*  CREATION DU JOUEUR */
            Console.Write("Entrer le nombre de Joueur Participant :");
            int nbre_partipant = Convert.ToInt32(Console.ReadLine());

            /**
             * Créer une boucle pour recuperer le nom, prenom, les cartes des participants
             * 
             */

            /* CREATION DE 8 CARTES ITEM ET L'AJOUT DANS LA LISTE DU JOUEUR */
           

            for (int i = 0; i < nbre_partipant; i++) {
                Console.Write("Entrer le Nom du Joueur " + i + " : ");
                string nom_joueur = Console.ReadLine();
                Console.Write("Entrer le Prenom du Joueur " + i + " : ");
                string prenom_joueur = Console.ReadLine();

                for (int t = 0; t < 8; t++)
                {
                    //liste_u.Clear();
                    /* Prendre un chiffre au hasard et le faire correspondre à une carte 
                     * sur les 52 cartes existantes
                     */
                    int chiffre_hasard = aleatoire.Next(0, Carte.Paquet.Count);
                    Carte carte_hasard = Carte.Paquet[chiffre_hasard];
                    //TODO retirer carte selectionner de la liste paquet
                    Carte.Paquet.RemoveAt(chiffre_hasard);
                    Console.WriteLine(carte_hasard);

                    liste_u.Add(carte_hasard);
                    //liste_u.Add(carte_hasard);
                }

                liste_Joueur.Add(new Joueur(nom_joueur, prenom_joueur, liste_u));
            }
         /*  
            while (p_index <= nbre_partipant)
            {
                //Joueur.liste.Clear();
                //liste_u.Clear();

                Console.Write("Entrer le Nom du Joueur " + p_index + " : ");
                string nom_joueur = Console.ReadLine();
                Console.Write("Entrer le Prenom du Joueur " + p_index + " : ");
                string prenom_joueur = Console.ReadLine();
               

                
                Joueur jr = new Joueur(nom_joueur, prenom_joueur,liste_u);
                //Joueur p = new Joueur(nom_joueur, prenom_joueur, Joueur.liste);
                liste_Joueur.Insert(p_index - 1, new Joueur(nom_joueur, prenom_joueur, Joueur.liste));
                //jr = new Joueur(nom_joueur, prenom_joueur, Joueur.liste);
                //jr = new Joueur(nom_joueur, prenom_joueur, liste_u);
               // liste_Joueur.Add(jr);
                
                
                Console.WriteLine("---------------------------------------------------");
                p_index++;
            } */

            /* APPEL DE LA FONCTION AFFICHAGE */
            affichage_liste_Joueur(liste_Joueur);
        }

        /** FONCTION affichage_liste_carte : Affiche une liste contenant toutes les cartes dont possedent un Joueur */
        public static void affichage_liste_carte(List<Carte> list)
        {
            //Console.WriteLine("\nAffichage de la liste des cartes du Joueur : ");
            for (int i = 0; i < list.Count; i++)
                Console.Write(list[i] + " * ");
            Console.WriteLine(); //Aérer le code
        }

        /** FONCTION affichage_liste_Joueur : Affiche une liste contenant tous les joueurs dont possedent une Partie du jeu */
        public static void affichage_Caracteristique_Joueur(Joueur player)
        {
            Console.WriteLine("\nAffichage des Caracteristiques de la liste de Joueur : ");
            Console.WriteLine("\tNom : " + player.GetNom()
                + "\n\tPrenom : " + player.GetPrenom()
                + "\n\tCartes : ");
            affichage_liste_carte(player.GetList_Carte());
            Console.WriteLine(); //Aérer le code
        }

        public static void affichage_liste_Joueur(List<Joueur> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                affichage_Caracteristique_Joueur(list[i]);
                Console.WriteLine(); //Aérer le code

            }
        }

    }
}
