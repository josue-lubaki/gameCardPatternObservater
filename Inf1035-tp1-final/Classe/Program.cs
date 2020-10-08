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
            Console.WriteLine("\t\t\t■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■\n" +
                              "\t\t\t■ ■ ■\t  BIENVENUE DANS NOTRE JEU DE CARTE\t■ ■ ■\n" +
                              "\t\t\t■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■\n");
            do
            {
                Console.Write("▓▒░▒▓ ENTRER LE NOMBRE DE JOUEUR (Entre 2 et 4) : ");
                nbreJoueurUser = Convert.ToInt32(Console.ReadLine());
            } while (nbreJoueurUser < 2 || nbreJoueurUser > 4);
            LinkedList<Joueur> listeInscription = new LinkedList<Joueur>();
            Joueur jr = null;
            string nom, prenom;
            for (int a = 0; a < nbreJoueurUser; a++)
            {
                Console.Write("\n▓▒░ ENTRER LE NOM DU JOUEUR_" + (a + 1) + " ░▒▓ ==> ");
                nom = Console.ReadLine();
                Console.Write("\n░▒▓ ENTRER LE PRENOM DU JOUEUR_" + (a + 1) + " ▓▒░ ==> ");
                prenom = Console.ReadLine();
                Console.WriteLine();
                jr = new Joueur(nom, prenom);
                listeInscription.AddLast(jr);
            }
            Partie partie = new Partie(listeInscription);
            partie.LancerPartie();
            Console.ReadLine();
        }
    }
}
