using Jeu_Uno.Classe;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
/*====================================================================*/
/*          @Authors : Josue Lubaki & Ismael Coulibaly & Xuyao Hu     */
/*====================================================================*/
namespace Jeu_Uno
{
    /** PARTIE.cs : Cette classe comporte 4 methodes essentielles pour gérer une partie, des methodes telles que : 
     * @see Participer() : Qui fait participer (inscrit) un joueur dans la Partie et reçoit en paramètre une instance de l'interface IObserver
     * @see Notify() : methode qui notifie à tous les observeurs inscrits dans la liste _obsevers, toutes modifications (varable, methode,...) de  la classe Partie.cs
     * @see JoueurCommence() : methone Asynchrone du type LinkedListNoeud qui la lance la partie avec le premier joueur [Choisie Aléatoirement]
     * @see DebutPartie() : methode qui reçoit en param une instance de l'interface IObserver et qui fait jouer tous les joueurs jusqu'au Gagnant. Et Lance la partie...
     */
    class Partie : ISubject
    {
        private static readonly Random aleatoire = new Random();
        private readonly List<IObserver> _observers = new List<IObserver>();
        private static bool arret = false;
        public static Carte topCarte;
        public static PileDePioche pileDePioche = new PileDePioche(52);
        public static PileDeJeu tableDeJeu = new PileDeJeu(52);
        public static LinkedList<Joueur> listeJoueur = new LinkedList<Joueur>();
        public PileDeJeu TableDeJeu
        {
            get { return tableDeJeu; }
            set { tableDeJeu = value; }
        }
        public Carte TopCarte
        {
            get { return topCarte; }
            set { topCarte = value; }
        }
        public void Participer(IObserver observer)
        {
            Console.WriteLine("\nUn Joueur s'est inscrit à la Partie ! ---> Bienvenue " + (observer as Joueur).Prenom + " " + (observer as Joueur).Nom);
            _observers.Add(observer);
            Thread.Sleep(1000);
        }
        public void Notify()
        {
            // Notifier aux Observateurs les changements effectués
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
        public async Task<LinkedListNode<Joueur>> JoueurCommence()
        {
            LinkedListNode<Joueur> firstPlayer = Activity.choixAlea(listeJoueur, listeJoueur.Count); // Noeud du Joueur courant
            var totalCartePlayer = firstPlayer.Value.ListeCarte.Count; // Total de carte du Joueur FirstPlayer
            int chfCarte = aleatoire.Next(0, totalCartePlayer); // chiffre aleatoire
            Carte carteDebutJeu = firstPlayer.Value.ListeCarte[chfCarte]; // selectionner une carte aleatoire du joueur FirstPlayer
            Console.Write("\nC'est " + firstPlayer.Value.Prenom + " " + firstPlayer.Value.Nom + " qui commence le jeu (choisit aléatoirement)\n");
            TableDeJeu.Push(carteDebutJeu); // Le Joueur joue sa carte
            topCarte = carteDebutJeu;
            firstPlayer.Value.ListeCarte.Remove(carteDebutJeu);
            Console.WriteLine("\n------------------------------- Pile de jeu : vide\n" + firstPlayer.Value.Prenom + " a joué " + carteDebutJeu + "\tNbre Carte en main : "
                + firstPlayer.Value.ListeCarte.Count + "\n");
            if (firstPlayer.Value.IsWinner())
            {
                Console.WriteLine("*==========================================================*\n*======>\t"
                    + firstPlayer.Value.Prenom + "* " + firstPlayer.Value.Nom + " a remporté la Partie " +
                    "<======*\n*==========================================================*");
                arret = true;
            }
            await Task.Delay(1200); //Asynchronisation avec un delay de 1,2 seconde
            return firstPlayer;
        }
        public async void DebutPartie(IObserver observer)
        {
            LinkedListNode<Joueur> currentNext = null;
            LinkedListNode<Joueur> current = await JoueurCommence();
            List<Carte> echantillon = new List<Carte>();
            topCarte = TopCarte;
            do
            {
                // Le Joueur qui vient après l'actuel
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
                * Si la liste echantillon contiens au moins une carte, le joueur peut jouer sinon il pioche une carte et passe son tour
                */
                if (echantillon.Count >= 1)
                {
                    Carte cartePossible = Activity.JouerCartePossible(echantillon, topCarte, TableDeJeu);
                    currentNext.Value.ListeCarte.Remove(cartePossible);
                    Console.WriteLine("\n------------------------------- Pile de jeu : " + TopCarte + "\n" + currentNext.Value.Prenom + " a joué " + cartePossible
                        + "\tNbre Carte en main : " + currentNext.Value.ListeCarte.Count + "\n");
                    topCarte = cartePossible;
                    // Verifier si le joueur a gagné ou pas. | C'est-à-dire nombre_de_carte_en_main == 0 | @see IsWinner()
                    if (currentNext.Value.IsWinner())
                    {
                        Console.WriteLine("*==========================================================*\n*======>\t"
                            + currentNext.Value.Prenom + "* " + currentNext.Value.Nom + " a remporté la Partie " +
                            "<======*\n*==========================================================*");
                        arret = true;
                    }
                }
                else
                {
                    Carte cartePoichee = Activity.Piochee();
                    currentNext.Value.ListeCarte.Add(cartePoichee);
                    Console.WriteLine("\n" + currentNext.Value.Prenom + " a Poiché la carte " + cartePoichee
                       + "\tNbre Carte en main : " + currentNext.Value.ListeCarte.Count + "\n");
                }
                //Faire correspondre la reference du Current au Joueur qui vient de jouer
                current = currentNext;
                echantillon = new List<Carte>();
                await Task.Delay(1200); // Asynchronisation avec un delay de 1,2 seconde
                Notify(); // Notifier à tous les observateurs, le changement effectué au niveau de la classe [partie.cs]
            } while (!arret);
        }
    }
}