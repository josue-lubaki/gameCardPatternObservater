using Jeu_Uno;
using System;
using System.Collections.Generic;

namespace Jeu_Uno
{
    class Program
    {
        public static int nbreJoueurUser = 0;
        public static List<Carte> liste_contener = new List<Carte>();
        static void Main(string[] args)
        {
            nbreJoueurUser = 2;
            do
            {
                Console.Write("Entrer le nombre de Joueur : ");
                nbreJoueurUser = Convert.ToInt32(Console.ReadLine());
            } while (nbreJoueurUser < 2 || nbreJoueurUser > 4);

            // Création des Joueurs int cpt = 0;
            Joueur jr = null;
            List<Carte> unused = new List<Carte>();
            // Initialisation de la Partie et Chargement des cartes
            Partie partie = new Partie();
            partie.initialisationCarte();
            Partie.PreDistribution();
            List<Carte> listCardPlayer = new List<Carte>();
            for (int a = 0; a < nbreJoueurUser; a++)
            {
                listCardPlayer = new List<Carte>();
                if (liste_contener.Count == 8)
                { // Lorsqu'on a qu'un seul Joueur
                    for (int i = 0; i < (liste_contener.Count); i++)
                    {
                        listCardPlayer.Add(liste_contener[i]);
                    }
                }
                else if (liste_contener.Count == 16) // Pour 2 Joueurs
                {
                    for (int i = 0; i < (liste_contener.Count - 8); i++)
                    {
                        listCardPlayer.Add(liste_contener[i]);
                    }
                }
                else if (liste_contener.Count == 24) // Pour 3 joueurs
                {
                    for (int i = 0; i < (liste_contener.Count - 16); i++)
                    {
                        listCardPlayer.Add(liste_contener[i]);
                    }
                }
                else if (liste_contener.Count == 32) // Pour 4 Joueurs
                {
                    for (int i = 0; i < (liste_contener.Count - 24); i++)
                    {
                        listCardPlayer.Add(liste_contener[i]);
                    }
                }
                else // Pour Autres valeurs
                {
                    Console.WriteLine("Désolé, le nombre des joueurs est incorrect, nous n'acceptons qu'un maximun" +
                    "de 4 Joueurs");
                }
                jr = new Joueur("Joueur_" + (a + 1), "Prenom_" + (a + 1), listCardPlayer);
                DeroulementPartie.listeJoueur.AddLast(jr);
                // le Joueur s'inscrit à la Partie
                jr.participer(partie);
                liste_contener.RemoveRange(0, 8);
            }
            // Lancement de la Partie
            partie.DebutPartie();

            // Garder le Console Ouvert
            Console.ReadLine();
        }
    }
}
