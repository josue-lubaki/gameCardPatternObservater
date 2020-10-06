using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Jeu_Uno
{
    class Partie : ISubject
    {
        public static List<Carte> PilePioche = new List<Carte>();
        public static List<Carte> desk = new List<Carte>();
        private static Random aleatoire = new Random();
        private static List<IObserver> _observers = new List<IObserver>();
        private static bool arret = false;
        public static Carte topCarte;
        // initialisation du Delegate
        public delegate void DeroulementPartieJoueur(object sender, DeroulementPartie d);
        private event DeroulementPartieJoueur players;
        public static List<Joueur> listeJoueur = new List<Joueur>();
        // Declaration de L'évenement
        public DeroulementPartieJoueur Players
        {
            get { return players; }
            set
            {
                players = value;
                Console.WriteLine("Un Joueur s'est ajouté !");
            }
        }
        public List<Carte> Desk
        {
            get { return desk; }
            set { desk = value; }
        }
        public Carte TopCarte
        {
            get { return topCarte; }
            set { topCarte = value; }
        }
        public void Participer(IObserver observer)
        {
            Console.WriteLine("Un Joueur s'est inscrit à la Partie ! --> Bienvenue " + (observer as Joueur).Nom);
            Partie._observers.Add(observer);
        }
        public void Notify()
        {
            Console.WriteLine("Notifying observers...");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
       
        public void JoueurCommence()
        {
            Joueur firstPlayer = null;
            //Parcourir toutes ces Cartes afin de selectionner une carte aleatoire
            firstPlayer = listeJoueur[0];
            var totalCartePlayer = firstPlayer.ListeCarte.Count;
            int chfCarte = aleatoire.Next(0, totalCartePlayer);
            Carte carteDebutJeu = firstPlayer.ListeCarte[chfCarte];
            Console.Write("\nC'est " + firstPlayer.Nom + " qui commence le jeu (choisit aléatoirement)\n");
            //Le Joueur joue sa carte
            Partie.desk.Add(carteDebutJeu);
            topCarte = carteDebutJeu;
            firstPlayer.ListeCarte.Remove(carteDebutJeu);
            Thread.Sleep(new Random().Next(400,1000));
            Console.WriteLine(firstPlayer.Nom + " a joué " + carteDebutJeu + "\tNbre Carte en main : "
                + firstPlayer.ListeCarte.Count + "\tPile de jeu : " + TopCarte);
            if (firstPlayer.IsWinner())
            {
                Console.WriteLine("*======================================================*\n*======>"
                    + firstPlayer.Nom + "* " + firstPlayer.Prenom + " a remporté la Partie " +
                    "<======*\n*======================================================*");
                arret = true;
            }
        }
        /*public void SomeBusinessLogic(IObserver observer)
        {
            LinkedListNode<Joueur> currentNext = null;
            LinkedListNode<Joueur> current = JoueurCommence();
            //Console.WriteLine("\nSubject: I'm doing something important. Desk : " + Desk);
            List<Carte> echantillon = new List<Carte>();
            topCarte = TopCarte;
            do
            {
                // Le Joueur qui vient après le precedent
                
                    if (current == listeJoueur.Last)
                    {
                        currentNext = listeJoueur.First;
                    }
                    else
                    {
                        currentNext = current.Next;
                    }
                    for (int t = 0; t < currentNext.Value.ListeCarte.Count; t++)
                    {
                        Carte r;
                        r = currentNext.Value.ListeCarte[t];
                        //verifier la Couleur et La Valeur
                        if (r.Color == TopCarte.Color || r.Valeur_string == TopCarte.Valeur_string)
                        {
                            echantillon.Add(r);
                        }
                    }
                    /* echantillon : liste possédant les cartes possibles d'être joué par le Joueur
                    * Si la liste echantillon contien au moins une carte, le joueur peut jouer
                    */
                  /*  if (echantillon.Count >= 1)
                    {
                        Carte cartePossible = DeroulementPartie.JouerCartePossible(echantillon, topCarte, Partie.desk);
                        Thread.Sleep(new Random().Next(400,1000));
                        currentNext.Value.ListeCarte.Remove(cartePossible);
                        Console.WriteLine(currentNext.Value.Nom + " a joué " + cartePossible
                            + "\tNbre Carte en main : " + currentNext.Value.ListeCarte.Count + "\tPile de jeu : " + TopCarte);
                        topCarte = cartePossible;
                        // Verifier si le joueur a gagné ou pas. | C'est-à-dire nombre_de_carte_en_main == 0 | @see IsWinner()
                        if (currentNext.Value.IsWinner())
                        {
                            Console.WriteLine("*======================================================*\n*======>"
                                + currentNext.Value.Nom + "* " + currentNext.Value.Prenom + " a remporté la Partie " +
                                "<======*\n*======================================================*");
                            arret = true;
                        }
                    }
                    else
                    {
                        Carte cartePoichee = DeroulementPartie.piochee();
                        Thread.Sleep(new Random().Next(400,1000));
                        currentNext.Value.ListeCarte.Add(cartePoichee);
                        Console.WriteLine(currentNext.Value.Nom + " a Poiché la carte " + cartePoichee
                           + "\tNbre Carte en main : " + currentNext.Value.ListeCarte.Count);
                    }
                    //Faire correspondre la reference du Current au Joueur qui vient de jouer
                    current = currentNext;
                    echantillon = new List<Carte>();
                
                Thread.Sleep(new Random().Next(400, 1000));
                // Notifier à L'interface le changement produit
                this.Notify();
            } while (!arret);
        }*/
        
    }
}