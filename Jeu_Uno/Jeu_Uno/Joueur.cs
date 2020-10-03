using System;
using System.Collections.Generic;
using System.Threading;

namespace Jeu_Uno
{
    class Joueur
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
        public void participer(Partie s)
        {
            Thread.Sleep(new Random().Next(600, 1500));
            s.Players += MomDeroulementPartieJoueur;
        }
        //Définition de l'action du Joueur
        void MomDeroulementPartieJoueur(object sender, DeroulementPartie e)
        {
            Thread.Sleep(new Random().Next(600, 1500));
            // TODO : implementer le code qui affiche le nom du joueur, sa carte jouée
            // et le nombre de carte restée en main
            //Console.WriteLine(nom + " : je joue la carte ");
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