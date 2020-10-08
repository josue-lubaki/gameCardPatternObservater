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
    /** PARTIE.cs : Cette classe comporte 2 methodes hors du commun pour gérer une partie, des methodes telles que : 
     * @see choixAlea() qui rendomiser la liste de Joueur pour trouver celui qui commencera la partie
     * @see LancerPartie() qui essentiellement distribue 8 cartes à chaque Joueur inscrit
     */
    class Partie
    {
        public static Carte topCarte;
        private Activity jeu_Uno;
        public Partie(LinkedList<Joueur> listeJoueur)
        {
            jeu_Uno = new Activity();
            Partie.ListeJoueur = listeJoueur;
            choixAlea();
        }
        public static LinkedList<Joueur> ListeJoueur { get; private set; } = new LinkedList<Joueur>();

        public Carte TopCarte
        {
            get { return topCarte; }
            set { topCarte = value; }
        }
        public static async void choixAlea()
        {
            LinkedList<Joueur> meilleurListeJoueur = new LinkedList<Joueur>();
            List<Joueur> participant = new List<Joueur>();
            foreach (var item in ListeJoueur)
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
            ListeJoueur = meilleurListeJoueur;
            await Task.Delay(1200);
        }

        public async void LancerPartie()
        {
            int count = 0;
            Console.WriteLine("\t\t\t\t\t▒▒▒▒▒ LA PARTIE EST LANCÉE ▒▒▒▒\n\n");
            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
            foreach (Joueur joueur in ListeJoueur)
            {
                Thread.Sleep(500);
                jeu_Uno.ParticiperPartie(joueur);
                joueur.CartesEnMain = jeu_Uno.DistributionCarte();
                Console.WriteLine("====>\t" + joueur.ToString() + " s'est inscrit à la partie !");
                count++;
                await Task.Delay(1200);
            }
            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
            
            while (true)
            {
                foreach (Joueur joueur1 in ListeJoueur)
                {
                    joueur1.Play();
                    await Task.Delay(800);
                }
            }
        }

    }
}