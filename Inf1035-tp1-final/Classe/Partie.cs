using Jeu_Uno.Classe;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
/*==========================================================================*/
/*          @Authors : Josue Lubaki & Ismael Coulibaly & Xuyao Hu           */
/*==========================================================================*/
namespace Jeu_Uno
{
    /** PARTIE.cs : Cette classe comporte 4 methodes essentielles pour gérer une partie, des methodes telles que : 
     * @see Participer() : Qui fait participer (inscrit) un joueur dans la Partie et reçoit en paramètre une instance de l'interface IObserver
     * @see Notify() : methode qui notifie à tous les observeurs inscrits dans la liste _obsevers, toutes modifications (varable, methode,...) de  la classe Partie.cs
     * @see JoueurCommence() : methone Asynchrone du type LinkedListNoeud qui la lance la partie avec le premier joueur [Choisie Aléatoirement]
     * @see DebutPartie() : methode qui reçoit en param une instance de l'interface IObserver et qui fait jouer tous les joueurs jusqu'au Gagnant. Et Lance la partie...
     */
    class Partie
    {
        private static readonly Random aleatoire = new Random();
        public static Carte topCarte;
        public static LinkedList<Joueur> listeJoueur = new LinkedList<Joueur>();
        private Activity jeu_Uno;
        public Partie(LinkedList<Joueur> listeJoueur)
        {
            jeu_Uno = new Activity();
            Partie.listeJoueur = listeJoueur;
            choixAlea();
        }
        public static LinkedList<Joueur> ListeJoueur
        {
            get { return listeJoueur; }
        }
       
        public Carte TopCarte
        {
            get { return topCarte; }
            set { topCarte = value; }
        }
        public static void choixAlea()
        {
            LinkedList<Joueur> meilleurListeJoueur = new LinkedList<Joueur>();
            List<Joueur> participant = new List<Joueur>();
            foreach (var item in listeJoueur)
            {
                participant.Add(item);
            }
            while (participant.Count>0)
            {
                int rand = new Random().Next(0, participant.Count);
                Joueur s = participant[rand];
                meilleurListeJoueur.AddLast(s);
                participant.Remove(s);
            }
            listeJoueur = meilleurListeJoueur;
        }

        public async void LancerPartie()
        {
            int count = 0;
            Console.WriteLine("\t\t---> !!! La partie est Lancée !!! <---");
            Console.WriteLine("*******************************************************");
            foreach (Joueur joueur in listeJoueur)
            {
                Thread.Sleep(500);
                jeu_Uno.ParticiperPartie(joueur);
                joueur.CartesEnMain = jeu_Uno.DistributionCarte();
                Console.WriteLine(joueur.ToString() + " s'est inscrit à la partie !");
                count++;
                await Task.Delay(1200);
            }
            Console.WriteLine("*******************************************************");
            
            while (true)
            {
                foreach (Joueur joueur1 in listeJoueur)
                {
                    joueur1.Play();
                    await Task.Delay(800);
                }
            }
        }

    }
}