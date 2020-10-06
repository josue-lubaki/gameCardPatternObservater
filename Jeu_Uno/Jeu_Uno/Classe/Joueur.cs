using System;
using System.Collections.Generic;
/*====================================================================*/
/*          @Authors : Josue Lubaki & Ismael Coulibaly                */
/*====================================================================*/
namespace Jeu_Uno
{
    /** JOUEUR.cs : La Classe implemente l'interface IObserver ainsi que sa methode Update(). cette classe comporte essentiellement 2 methodes telles que :
     * @see IsWinner() : qui verifie le nombre de carte du Joueur, si nbreCarte == 0, c'est notre gagnant
     * @see Update() : qui renvoi en console "..." pour chacun des joueurs notifiés du changement de la Classe partie.cs
     */
    class Joueur : IObserver
    {
        private List<Carte> listeCarte;
        private string nom;
        private string prenom;
        public static int nbreJoueur = 0;
        /* Constructor */
        public Joueur(string nom, string prenom, List<Carte> maListe)
        {
            this.nom = nom;
            this.prenom = prenom;
            listeCarte = maListe;
            nbreJoueur++;
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }
        public List<Carte> ListeCarte
        {
            get { return listeCarte; }
            set { listeCarte = value; }
        }

        // Si la liste des cartes du joueur est vide, le joueur est gagnant
        public bool IsWinner()
        {
            if (listeCarte.Count == 0)
            {
                return true;
            }
            return false;
        }

        public void Update(ISubject subject)
        {
            //Pour annoncer que les joueurs ont bien pris en compte la notification (changement) envoyé par Partie.cs --> @see Notify()
            Console.Write("...\t");
        }

        public override string ToString()
        {
            string output =
          "\n\tNom : " + Nom
          + "\n\tPrenom : " + Prenom + "Cartes : " + ListeCarte;
            return output;
        }
    }
}