using Jeu_Uno.Enumeration;
using System;

namespace Jeu_Uno
/*==========================================================================*/
/*          @Authors : Josue Lubaki & Ismael Coulibaly & Xuyao Hu           */
/*==========================================================================*/
{
    //enumeration des Cartes
    public enum Color { Trefle, Carreau, Coeur, Pique, field };
    class Carte
    {
        private Color color;
        private readonly string value;
        private string valeurCarte;
        private readonly Color couleur;
        /* CONSTRUCTORS */
        public Carte(int chiffre, int spin)
        {
            // TRANSFORMATION DE *INTEGER EN *STRING
            this.valeurCarte = GestionEnum.GestionValeurCarte(chiffre, value);

            // TRANSFORMATION DE *INTEGER EN *ENUMERATION COLOR
            this.color = GestionEnum.GestionCouleurCarte(spin, couleur);
        }
        public string ValeurCarte
        {
            get { return valeurCarte; }
            set { valeurCarte = value.ToString(); }
        }
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        // Définir les Opérations possible sur une carte
        public static bool operator ==(Carte a,Carte b)
        {
            if (a.valeurCarte == b.valeurCarte || a.color == b.color)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Carte a, Carte b)
        {
            if (a.valeurCarte != b.valeurCarte && a.color != b.color)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            return obj is Carte carte && (couleur == carte.couleur && valeurCarte == carte.valeurCarte);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(couleur);
        }
        public override string ToString()
        {

            string output = "[" + ValeurCarte + "|" + Color + "]";
            return output;
        }
    }
}