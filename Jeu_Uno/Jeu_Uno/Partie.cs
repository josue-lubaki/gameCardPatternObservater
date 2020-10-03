﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Jeu_Uno
{
    class Partie
    {
        public static List<Carte> PilePioche = new List<Carte>();
        public static List<Carte> Desk = new List<Carte>();
        private static Random aleatoire = new Random();
        // initialisation du Delegate
        public delegate void DeroulementPartieJoueur(object sender, DeroulementPartie d);
        private event DeroulementPartieJoueur players;
        // Declaration de L'évenement
        public DeroulementPartieJoueur Players
        {
            get { return players; }
            set { players = value;
                Console.WriteLine("Un Joueur s'est ajouté !");
            }
        }
        public void DebutPartie()
        {
            Console.WriteLine("La Partie peut maintenant débuter...");
            Thread.Sleep(new Random().Next(600, 1500));
            DeroulementPartie.ActionPlayers();
            Publish(new DeroulementPartie("Did something"));
        }
        public virtual void Publish(DeroulementPartie e)
        {
            // Pour éviter la condition de Concurrence entre les évenements
            DeroulementPartieJoueur k = players;
            if(players != null)
            {
                e.Annonce += String.Format(" at {0}", DateTime.Now.ToString());
                k(this, e);
            }
        }
        public static Carte piochee()
        {
            Carte carte_hasard;
            /* Prendre un chiffre au hasard et le faire correspondre à une carte 
             * sur toutes les cartes existantes dans la pile de poiche
             */
            if (PilePioche.Count == 1)
            {
                List<Carte> brasserCarte = new List<Carte>();
                // TODO : GERER LA MANQUE DES CARTES DANS LA PILE DE POICHE
                for (int i = 0; i < Desk.Count; i++)
                {
                    brasserCarte = new List<Carte>();
                    int numberRandom = aleatoire.Next(0, Desk.Count);
                    Carte brassee = Desk[numberRandom];
                    brasserCarte.Add(brassee);
                    // Verifier si la carte existe déjà dans la liste ou pas
                    for (int a = 0; a < brasserCarte.Count; a++)
                    {
                        while (brassee == brasserCarte[a])
                        {
                            numberRandom = aleatoire.Next(0, Desk.Count);
                            brassee = Desk[numberRandom];
                        }
                        PilePioche.Add(brassee);
                        Desk.Remove(brassee);
                    }
                }
                Console.WriteLine("\n\t--> La Pile de Pioche a été Brasser <--\n");
            }
            int chiffre_hasard = aleatoire.Next(0, PilePioche.Count);
            carte_hasard = PilePioche[chiffre_hasard];
            // retirer la carte selectionnée de la Pile de pioche pour éviter d'avoir des doublons
            PilePioche.RemoveAt(chiffre_hasard);
            return carte_hasard;
        }
        public static void PreDistribution()
        {
            int cpt = 1;
            while (cpt <= Program.nbreJoueurUser)
            {
                for (int t = 0; t < 8; t++)
                {
                    Carte hasard = piochee();
                    Program.liste_contener.Add(hasard);
                }
                cpt++;
            }
        }
        // Création des 52 Cartes de la Partie
        public void initialisationCarte()
        {
            // Creation de 52 Cartes du Jeu
            for (int i = 1; i <= 13; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    Carte modele = new Carte(i, j);
                    PilePioche.Add(modele);
                }
            }
        }
    }
}