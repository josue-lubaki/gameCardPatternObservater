using System;
using System.Collections;
using System.Collections.Generic;
/*==================================================================================================
 *                          @Authors : Josue Lubaki & Ismael Coulibaly 
 *==================================================================================================*/
namespace Jeu_Carte
{
    class Index
    {
        public enum Color { Trefle, Carreau, Coeur, Pique };
        private static int nbre_participant = 1;

        // Liste vide de Joueur qui nous servira d'initialisation lors de la création d'une instance Partie
        private static List<Joueur> list_jr_ = new List<Joueur>();
        private static Partie jeu;
        


        
        static void Main(string[] args)
        {
            /* Liste contenant les cartes randomisées, et faire, pour user_1 prendre les cartes de 0 à 7
            * et Pour User_2 prendre les cartes allant de 8 à 15 ainsi de suite.
            * Utilisation : retirer les 8 premières cartes pour le joueur 1 ; les 8 cartes suivantes pour le joueur 2
            * ainsi de suite... 
            * 
            * ===> (code P1) <=== ci-bas
            */
            List<Carte> liste_u = new List<Carte>();
            
            Console.Write("Entrer le nombre de Joueur Participant :");
            nbre_participant = Convert.ToInt32(Console.ReadLine());
           
            // Creation de 52 Cartes du Jeu
            for (int i = 1; i <= 13; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    Carte modele = new Carte(i, j);
                    Carte.paquet.Add(modele);
                }
            }

            /* La Boucle While() est censée créer 8 Cartes d'une manière aléatoire associées 
             * à chaque Joueur(nbre_participant).
             * Ainsi donc si nous avons 2 joueurs, alors liste_u.Count = 16 Cartes puisque le while() s'éxécutera deux fois
             * Ainsi donc si nous avons 3 joueurs, alors liste_u.Count = 24 Cartes puisque le while() s'éxécutera trois fois
             * Ainsi de suite...
             * 
             *  ===> (code P2) <=== ci-bas
             */
            int cpt = 1;//compteur permettant d'executer la boucle while le nombre de fois qu'il faut. càd autant que le nombre de participant
            while (cpt <= nbre_participant)
            {
                for (int t = 0; t < 8; t++)
                {
                    Random aleatoire = new System.Random();
                    Carte carte_hasard;

                    /* Prendre un chiffre au hasard et le faire correspondre à une carte 
                     * sur les 52 cartes existantes
                     */
                    int chiffre_hasard = aleatoire.Next(0, Carte.paquet.Count);
                    carte_hasard = Carte.paquet[chiffre_hasard];
                    // retirer la carte selectionnée de la liste paquet pour éviter d'avoir des doublons
                    Carte.paquet.RemoveAt(chiffre_hasard);
                    Console.WriteLine(carte_hasard);

                    /* ===> (code P1) <=== ci-haut */
                    liste_u.Add(carte_hasard);
                }
                cpt++;
            }

            // Initialisation de la Partie
            jeu = new Partie(nbre_participant, list_jr_);

            int p_index = 1;
            while (p_index <= nbre_participant)
            {
                Joueur p;

                for (p_index = 1; p_index <= nbre_participant; p_index++) {

                    Console.Write("Entrer le Nom du Joueur " + p_index + " : ");
                    string nom_joueur = Console.ReadLine();
                    Console.Write("Entrer le Prenom du Joueur " + p_index + " : ");
                    string prenom_joueur = Console.ReadLine();

                    List<Carte> list_contener = new List<Carte>();

                    // Condition if-else : ===> (code P2) <=== ci-haut
                    if (liste_u.Count == 8) { // Pour 1 Joueur
                        for (int i = 0; i < (liste_u.Count); i++)
                        {
                            list_contener.Add(liste_u[i]);
                        }
                    }
                    else if (liste_u.Count == 16) // Pour 2 Joueurs
                    {
                        for (int i = 0; i < (liste_u.Count - 8); i++)
                        {
                            list_contener.Add(liste_u[i]);
                        }
                    }
                    else if (liste_u.Count == 24) // Pour 3 joueurs
                    {
                        for (int i = 0; i < (liste_u.Count - 16 ); i++)
                        {
                            list_contener.Add(liste_u[i]);
                        }
                    }
                    else if (liste_u.Count == 32) // Pour 4 Joueurs
                    {
                        for (int i = 0; i < (liste_u.Count - 24 ); i++)
                        {
                            list_contener.Add(liste_u[i]);
                        }
                    }
                    else // Pour Autres valeurs
                    {
                       Console.WriteLine("Désolé, le nombre des joueurs est incorrect, nous n'acceptons qu'un maximun" +
                       "de 4 Joueurs");
                        break;
                    }

                    // Ajout du nouveau Joueur p dans la liste static des Joueurs (Liste_Joueur) de la classe Partie
                    p = new Joueur(nom_joueur, prenom_joueur, list_contener);
                    jeu.Liste_Joueur.Add(p);

                    /* Supprimer les 8 cartes du Joueur récemment crée avant d'en créer un nouveau (Joueur).
                     * Une Suppression qui sera toujours vraie
                     */
                    int debut = 0;
                    if (debut == 0)
                    {
                       Console.WriteLine("suppression de 8 Cartes");
                       liste_u.RemoveRange(0, 8);
                    }
                }
                p_index++;
            }
    
            /* APPEL DE LA FONCTION AFFICHAGE */
            //affichage_liste_Joueur(jeu.Liste_Joueur);

            // LANCEMENT DU JEU
            jeu.ToString();


            

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
            int position = jeu.Liste_Joueur.IndexOf(player);
            Console.WriteLine("\nAffichage des Caracteristiques du Joueur : " + (position+1));
            Console.WriteLine("\tNom : " + player.GetNom()
                + "\n\tPrenom : " + player.GetPrenom()
                + "\n\tCartes : "); // + jeu.Liste_Joueur[position].GetList_Carte_s());
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
