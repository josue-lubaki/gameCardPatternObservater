using System;
using System.Collections.Generic;
using System.Threading;

namespace Jeu_Uno
{
    class Joueur : IObserver
    {
        private List<Carte> listeCarte;
        private string nom;
        private string prenom;
        public static Carte topCarte;
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
        public string GetList_Carte_s()
        {
            string output = "";
            foreach (Carte e in listeCarte)
                output += e + " * ";
            return output;
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
       
        public bool Update(ISubject subject)
        {
            
            List<Carte> echantillon = new List<Carte>();
            topCarte = (subject as Partie).TopCarte;
            for (int t = 0; t < this.ListeCarte.Count; t++)
            {
                Carte r;
                r = this.ListeCarte[t];
                //verifier la Couleur et La Valeur
                if (r.Color == Partie.topCarte.Color || r.Valeur_string == Partie.topCarte.Valeur_string)
                {
                    echantillon.Add(r);
                }
            }
            /* echantillon : liste possédant les cartes possibles d'être joué par le Joueur
            * Si la liste echantillon contien au moins une carte, le joueur peut jouer
            */
            if (echantillon.Count >= 1)
            {
                Carte cartePossible = DeroulementPartie.JouerCartePossible(echantillon, topCarte, Partie.desk);
                Thread.Sleep(new Random().Next(400, 1000));
                this.ListeCarte.Remove(cartePossible);
                Console.WriteLine(this.Nom + " a joué " + cartePossible
                    + "\tNbre Carte en main : " + this.ListeCarte.Count + "\tPile de jeu : " + topCarte);
                topCarte = cartePossible;
                // Verifier si le joueur a gagné ou pas. | C'est-à-dire nombre_de_carte_en_main == 0 | @see IsWinner()
                if (this.IsWinner())
                {
                    Console.WriteLine("*======================================================*\n*======>"
                        + this.Nom + "* " + this.Prenom + " a remporté la Partie " +
                        "<======*\n*======================================================*");
                }
                return true;
            }
            else
            {
                Carte cartePoichee = DeroulementPartie.piochee();
                Thread.Sleep(new Random().Next(400, 1000));
                this.ListeCarte.Add(cartePoichee);
                Console.WriteLine(this.Nom + " a Poiché la carte " + cartePoichee
                   + "\tNbre Carte en main : " + this.ListeCarte.Count);
            }
            Thread.Sleep(new Random().Next(400, 1000));
            return false;
        }

        public override string ToString()
        {
            //return base.ToString();
            string output =
          "\n\tNom : " + Nom
          + "\n\tPrenom : " + Prenom + "Cartes : " + ListeCarte;
            return output;
        }
    }
}