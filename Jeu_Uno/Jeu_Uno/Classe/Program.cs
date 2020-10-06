using System;
using System.Collections.Generic;
/*====================================================================*/
/*          @Authors : Josue Lubaki & Ismael Coulibaly                */
/*====================================================================*/
namespace Jeu_Uno
{
    class Program
    {
        public static int nbreJoueurUser = 0;
        public static List<Carte> liste_contener = new List<Carte>();
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Entrer le nombre de Joueur : ");
                nbreJoueurUser = Convert.ToInt32(Console.ReadLine());
            } while (nbreJoueurUser < 2 || nbreJoueurUser > 4);

            // Initialisation de la Partie et Chargement des cartes
            Partie partie = new Partie();
            Activity.InitialisationCarte();
            Activity.PreDistribution();
            List<Carte> listCardPlayer = new List<Carte>();
            List<Joueur> listeInscription = new List<Joueur>();
            Joueur jr = null;
            string nom, prenom;
            for (int a = 0; a < nbreJoueurUser; a++)
            {
                Console.Write("\nEntrer le nom du Joueur_" + (a + 1) + " : ");
                nom = Console.ReadLine();
                Console.Write("Entrer le prenom du Joueur_" + (a + 1) + " : ");
                prenom = Console.ReadLine();
                listCardPlayer = new List<Carte>();
                Activity.NbreCarteParContext(liste_contener, listCardPlayer);
                jr = new Joueur(nom, prenom, listCardPlayer);
                Partie.listeJoueur.AddLast(jr);
                listeInscription.Add(jr);
                liste_contener.RemoveRange(0, 8);
            }
            for (int s = 0; s < listeInscription.Count; s++)
            {
                // les Joueurs s'inscrivent à la Partie
                partie.Participer(listeInscription[s]);
            }
            partie.DebutPartie(jr);
            Console.ReadLine();
        }
    }
}
