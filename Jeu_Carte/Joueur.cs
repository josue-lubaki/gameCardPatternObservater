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

        public List<Carte> GetList_Carte()
        {
            return liste;
        }

        public void SetList_Carte(List<Carte> value)
        {
            liste = value;
        }

        // Si la liste des cartes du joueur est vide, le joueur est gagnant
        public bool IsWinner() {
            if (liste.Count == 0)
            {
                return true;
            }
            return false;
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
