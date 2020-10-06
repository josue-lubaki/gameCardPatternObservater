namespace Jeu_Uno
/*====================================================================*/
/*          @Authors : Josue Lubaki & Ismael Coulibaly                */
/*====================================================================*/
{
    //enumeration des Cartes
    public enum Color { Trefle, Carreau, Coeur, Pique };
    class Carte
    {
        private Color color;
        private string value;
        private string valeur_String;
        private Color couleur;
        /* CONSTRUCTORS */
        public Carte(int chiffre, int spin)
        {
            // TRANSFORMATION DE *INTEGER EN *STRING
            switch (chiffre.ToString())
            {
                case "1":
                    value = "A";
                    break;
                case "2":
                    value = "2";
                    break;
                case "3":
                    value = "3";
                    break;
                case "4":
                    value = "4";
                    break;
                case "5":
                    value = "5";
                    break;
                case "6":
                    value = "6";
                    break;
                case "7":
                    value = "7";
                    break;
                case "8":
                    value = "8";
                    break;
                case "9":
                    value = "9";
                    break;
                case "10":
                    value = "10";
                    break;
                case "11":
                    value = "J";
                    break;
                case "12":
                    value = "Q";
                    break;
                case "13":
                    value = "K";
                    break;
            }

            // TRANSFORMATION DE *INTEGER EN *ENUMERATION
            switch (spin)
            {
                case 1:
                    {
                        couleur = Color.Trefle;
                        break;
                    }
                case 2:
                    {
                        couleur = Color.Carreau;
                        break;
                    }
                case 3:
                    {
                        couleur = Color.Coeur;
                        break;
                    }
                case 4:
                    {
                        couleur = Color.Pique;
                        break;
                    }
            }
            valeur_String = value;
            this.color = couleur;
        }
        public string Valeur_string
        {
            get { return valeur_String; }
            set { valeur_String = value.ToString(); }
        }
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        public override string ToString()
        {

            string output = "[" + Valeur_string + "|" + Color + "]";
            return output;
        }
    }
}