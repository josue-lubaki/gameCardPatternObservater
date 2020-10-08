using System;
using System.Collections.Generic;
/*==========================================================================*/
/*          @Authors : Josue Lubaki & Ismael Coulibaly & Xuyao Hu           */
/*==========================================================================*/
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

            LinkedList<Joueur> listeInscription = new LinkedList<Joueur>();
            Joueur jr = null;
            string nom, prenom;
            for (int a = 0; a < nbreJoueurUser; a++)
            {
                Console.Write("\nEntrer le nom du Joueur_" + (a + 1) + " : ");
                nom = Console.ReadLine();
                Console.Write("Entrer le prenom du Joueur_" + (a + 1) + " : ");
                prenom = Console.ReadLine();
                jr = new Joueur(nom, prenom);
                listeInscription.AddLast(jr);
            }
            Partie partie = new Partie(listeInscription);
            partie.LancerPartie();
            Console.ReadLine();
        }
    }
}
