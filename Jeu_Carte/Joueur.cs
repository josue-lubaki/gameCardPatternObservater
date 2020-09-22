using System.Collections.Generic;

namespace Jeu_Carte
{
    class Joueur : Personne
    {
        public static int nbre_joueur = 0;
        public List<Carte> liste = new List<Carte>();
        //public static List<Carte> global = new List<Carte>();
        public List<Joueur> liste_Joueur = new List<Joueur>();
        /* Constructor */
        public Joueur(string nom, string prenom, List<Carte> maListe) : base(nom, prenom)
        {
            liste = maListe;
            nbre_joueur++;
        }
        public Joueur(string nom, string prenom) : base(nom, prenom)
        {

        }

        public List<Carte> GetList_Carte()
        {
            return liste;
        }


        public void SetList_Carte(List<Carte> value)
        {
            liste = value;
        }

        public override string ToString()
        {
            //return base.ToString();
            string output =
          "\n\tNom : " + GetNom()
          + "\n\tPrenom : " + GetPrenom()+ "Cartes : " + GetList_Carte() ;
            return output;
        }

    }
}
