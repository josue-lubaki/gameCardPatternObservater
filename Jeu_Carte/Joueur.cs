using System.Collections.Generic;

namespace Jeu_Carte
{
    class Joueur : Personne
    {
        private List<Carte> liste;
        /* Constructor */
        public Joueur(string nom, string prenom, List<Carte> maListe) : base(nom, prenom)
        {
            liste = maListe; // <---- Problème lors de la creation d'un deuxième joueur (reference ou copie)
        }

        public string GetList_Carte_s()
        {
            string output = "";
            for (int i = 0; i < liste.Count; i++)
               output += liste[i] + " * ";
            return output;
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
