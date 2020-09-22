using System.Collections.Generic;

namespace Jeu_Carte
{
    class Personne
    {
        protected string nom;
        protected string prenom;
        //public static List<Joueur> liste_Joueur = new List<Joueur>();

        public Personne(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
        }

        public string GetNom()
        {
            return nom;
        }

        public void SetNom(string value)
        {
            nom = value;
        }

        public string GetPrenom()
        {
            return prenom;
        }

        public void SetPrenom(string value)
        {
            prenom = value;
        }
    }
}
