using Jeu_Uno.Classe;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
/*==========================================================================*/
/*          @Authors : Josue Lubaki & Ismael Coulibaly & Xuyao Hu           */
/*==========================================================================*/
namespace Jeu_Uno
{
    /** ACTIVITY.cs : est une classe qui gère toutes les actions avant et pendant le jeu telles : 
     * Préparer les 52 Cartes du jeu [@see Constructor],
     * Piochée une carte dans la Pile reservée à la pioche [@see pioche()], Remplir la pile de pioche quans celle-ci est vide [@see RemplirPilePioche()]
     * Distribuer les cartes au joueur en debut de jeu et informer à chaque joueur qu'il s'agit de son tour
     */
    class Activity : EventArgs
    {
        private static Random aleatoire = new Random();
        public static PileDePioche pileDePioche = new PileDePioche(52);
        public static PileDeJeu tableDeJeu = new PileDeJeu(52);
        public static Carte topCarte;
        // Constructor : initialise la partie tout en apprettant toutes les cartes qui seront utilisées dans la Partie
        public Activity()
        {
            pileDePioche = new PileDePioche(52);
            tableDeJeu = new PileDeJeu(52);
            for (int i = 1; i <= 13; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    Carte modele = new Carte(i, j);
                    pileDePioche.Push(modele);
                }
            }
            //Brasser Les Cartes du jeu
            pileDePioche.BrasserCarte();
          
        }
        public PileDePioche PileDePioches
        {
            get
            {
                return pileDePioche;
            }
        }
        public PileDeJeu TableDeJeu
        {
            get { return tableDeJeu; }
            set { tableDeJeu = value; }
        }
        // Joueur peut participer à la partie
        public void ParticiperPartie(Joueur player)
        {
            player.Handlers += DebutPartie;
        }
        private void pioche(DepotEtPiocheEvent e)//la methode de pioche
        {
            Console.WriteLine("\n" + e.Joueur.Value.Prenom + " a Poiché la carte " + pileDePioche.Peek().ToString()
                       + "\tNbre Carte en main : " + e.Joueur.Value.CartesEnMain.Count + "\n");
            e.Joueur.Value.CartesEnMain.Add(pileDePioche.Peek());
            pileDePioche.Pop();
            if (pileDePioche.IsNull())
                RemplirPilePioche();
        }
        //la methode servant à remplir la pile de pioches quand celle-ci est vide, et le brasser
        private async void RemplirPilePioche()
        {
            Carte topCarte = new Carte(0,0);
            List<Carte> transition = new List<Carte>();
            List<Carte> brasserCarte = new List<Carte>();
            while (pileDePioche.Taille() < tableDeJeu.Taille())
            { // Recuperer la carte du sommet puis le supprimer pour avoir accès au suivant
                transition.Add(tableDeJeu.Peek());
                tableDeJeu.Pop();
            }
            Carte carteRandom;
            while (transition.Count > 0)
            { // selectionner une carte au hasard
               int numberRandom = new Random().Next(0, transition.Count);
                carteRandom = transition[numberRandom];
                brasserCarte.Add(carteRandom);
                transition.RemoveAt(numberRandom);
            }
            for (int a = 0; a < brasserCarte.Count; a++)
            {
                Carte uneCarte = brasserCarte[a];
                // Ajouter dans la Pile de Pioche du jeu et Supprimer dans la Pile de jeu
                pileDePioche.Push(uneCarte);
                brasserCarte.RemoveAt(a);
            }
            Console.WriteLine(" =====>>>>> La Pile vient d'être remplit, Poursuivons la partie...\n");
            await Task.Delay(1500);
        }
        // Methode Qui permet de distribuer à cahcun de Joueurs 8 Cartes au debut du jeu
        public List<Carte> DistributionCarte()
        {
            List<Carte> cartesEnMain = new List<Carte>();
            for (int i = 0; i < 8; i++)
            {
                cartesEnMain.Add(pileDePioche.Peek());
                pileDePioche.Pop();
            }
            if (pileDePioche.Taille() < 8)
                Console.WriteLine("erreur!");
            return cartesEnMain;
        }
        // Methode asychrone qui lance le jeu (la partie)
        public async void DebutPartie(object sender, DepotEtPiocheEvent e)
        {
            LinkedListNode<Joueur> current = e.Joueur;
            //LinkedListNode<Joueur> current = e.Joueur;
            if(!tableDeJeu.IsNull())
                topCarte = tableDeJeu.Peek();

            if (tableDeJeu.Taille() == 0)//la paritie vient de conmencer ,y a pas de carte sur pile de depot
            {
                Console.WriteLine("{0} a joue la carte {1}", current.Value.ToString(), current.Value.CartesEnMain[0].ToString());
                tableDeJeu.Push(current.Value.CartesEnMain[0]);
                current.Value.CartesEnMain.RemoveAt(0);
            }
            else
            {
                int count = current.Value.CartesEnMain.Count;
                foreach (Carte a in current.Value.CartesEnMain)
                {
                    if (a.Color == tableDeJeu.Peek().Color || a.ValeurCarte == tableDeJeu.Peek().ValeurCarte)// les joueur va deposer la premier carte adapté
                    {
                        tableDeJeu.Push(a);
                        e.Joueur.Value.CartesEnMain.Remove(a);
                        Console.WriteLine("------------------------------- Pile de jeu : " + topCarte + "\n" + current.Value.Prenom + " a joué " + a.ToString()
                        + "\tNbre Carte en main : " + current.Value.CartesEnMain.Count + "\n");
                        break;
                    }
                }
                if (e.Joueur.Value.CartesEnMain.Count == 0)//quand un joueur a depose sa dernier carte ,il gargne la partie
                {
                    Console.WriteLine("*==========================================================*\n*======>\t"
                            + current.Value.Prenom + "* " + current.Value.Nom + " a remporté la Partie " +
                            "<======*\n*==========================================================*");
                    Console.Read();
                    Environment.Exit(0);
                }

                if (count == e.Joueur.Value.CartesEnMain.Count)//quand un joueur n'a pas de carte,il va piocher une carte sur la pile de pioche
                {
                    pioche(e);
                }
            }
                await Task.Delay(1200); // Asynchronisation avec un delay de 1,2 seconde
        }
    }
}
