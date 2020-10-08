using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_Uno.Enumeration
{
    class GestionEnum
    {
        /* Cette Classe est censé Convertir le Integer en String pour La valeur de la Carte(A,1,2,...,10,J,Q,K)
         * Et gèrer l'enum Color de la classe Carte.cs
         */
        public static string GestionValeurCarte(int chiffreCarte, string value)
        {
            switch (chiffreCarte.ToString())
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
            return value;
        }
        public static Color GestionCouleurCarte(int spin,Color couleur)
        {
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
            return couleur;
        }
    }
}
