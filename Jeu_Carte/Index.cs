/*==================================================================================================
 *                          @Authors : Josue Lubaki & Ismael Coulibaly
 *==================================================================================================*/
using System;
using System.Collections.Generic;
namespace Jeu_Carte
{

    class Index
    {
        public enum Color { Trefle, Carreau, Coeur, Pique };
        private static int nbre_participant = 2;
        private static bool arret = false;
        private static int chf;
        private static Joueur jr_debut;
        private static Carte trouvee;
        private static int idx;
        // Liste vide de Joueur qui nous servira d'initialisation lors de la création d'une instance Partie
        private static List<Joueur> list_jr_ = new List<Joueur>();
        private static Partie jeu;
        private static Random aleatoire = new System.Random();
        static void Main(string[] args)
        {
            Random aleatoire = new System.Random();

            /* Liste contenant les cartes randomisées, et faire, pour user_1 prendre les cartes de 0 à 7
            * et Pour User_2 prendre les cartes allant de 8 à 15 ainsi de suite.
            * Utilisation : retirer les 8 premières cartes pour le joueur 1 ; les 8 cartes suivantes pour le joueur 2
            * ainsi de suite... 
            * 
            * ===> (code P1) <=== ci-bas
            */
            List<Carte> liste_u = new List<Carte>();
            Partie.initialisationCarte();

            // première Carte posée sur la table de Jeu
            int number = aleatoire.Next(0, Carte.paquet.Count);
            Carte firstCarte = Carte.paquet[number];
            // retirer la carte selectionnée de la liste paquet pour éviter d'avoir des doublons
            Carte.paquet.RemoveAt(number);
            // on pose la première carte sur la table de jeu
            Deroulement.cartesJouees.Add(firstCarte);



            int p_index = 1;
            while (p_index <= nbre_participant)
            {
                do
                {
                    Console.Write("Entrer le nombre de Joueur Participant (entre 2 et 4) : ");
                    nbre_participant = Convert.ToInt32(Console.ReadLine());
                } while (nbre_participant < 2 || nbre_participant > 4);

            /* La Boucle While() est censée créer 8 Cartes d'une manière aléatoire associées 
             * à chaque Joueur(nbre_participant).
             * Ainsi donc si nous avons 2 joueurs, alors liste_u.Count = 16 Cartes puisque le while() s'éxécutera deux fois
             * Ainsi donc si nous avons 3 joueurs, alors liste_u.Count = 24 Cartes puisque le while() s'éxécutera trois fois
             * Ainsi de suite...
             * 
             *  ===> (code P2) <=== ci-bas
             */
                int cpt = 1;
                while (cpt <= nbre_participant)
                {
                    for (int t = 0; t < 8; t++)
                    {
                        Carte hasard = poiche();
                        //Console.WriteLine(hasard);

                        /* ===> (code P1) <=== ci-haut */
                        liste_u.Add(hasard);
                    }
                    cpt++;
                }

                Joueur p;
                for (p_index = 1; p_index <= nbre_participant; p_index++)
                {
                    Console.Write("Entrer le Nom du Joueur " + p_index + " : ");
                    string nom_joueur = Console.ReadLine();
                    Console.Write("Entrer le Prenom du Joueur " + p_index + " : ");
                    string prenom_joueur = Console.ReadLine();

                    List<Carte> list_contener = new List<Carte>();

                    // Condition if-else : ===> (code P2) <=== ci-haut
                    if (liste_u.Count == 8)
                    { // Pour 1 Joueur
                        for (int i = 0; i < (liste_u.Count); i++)
                        {
                            list_contener.Add(liste_u[i]);
                        }
                    }
                    else if (liste_u.Count == 16) // Pour 2 Joueurs
                    {
                        for (int i = 0; i < (liste_u.Count - 8); i++)
                        {
                            list_contener.Add(liste_u[i]);
                        }
                    }
                    else if (liste_u.Count == 24) // Pour 3 joueurs
                    {
                        for (int i = 0; i < (liste_u.Count - 16); i++)
                        {
                            list_contener.Add(liste_u[i]);
                        }
                    }
                    else if (liste_u.Count == 32) // Pour 4 Joueurs
                    {
                        for (int i = 0; i < (liste_u.Count - 24); i++)
                        {
                            list_contener.Add(liste_u[i]);
                        }
                    }
                    else // Pour Autres valeurs
                    {
                        Console.WriteLine("Désolé, le nombre des joueurs est incorrect, nous n'acceptons qu'un maximun" +
                        "de 4 Joueurs");
                        break;
                    }
                    // Initialisation de la Partie
                    jeu = new Partie(nbre_participant, list_jr_);

                    // Ajout du nouveau Joueur p dans la liste static des Joueurs (Liste_Joueur) de la classe Partie
                    p = new Joueur(nom_joueur, prenom_joueur, list_contener);
                    jeu.Liste_Joueur.Add(p);

                    /* Supprimer les 8 cartes du Joueur récemment crée avant d'en créer un nouveau (Joueur).
                     * Une Suppression qui sera toujours vraie
                     */
                    int debut = 0;
                    if (debut == 0)
                    {
                        //Console.WriteLine("suppression de 8 Cartes");
                        liste_u.RemoveRange(0, 8);
                    }
                }
                p_index++;
            }





            /* APPEL DE LA FONCTION AFFICHAGE */
            //Affichage_liste_Joueur(jeu.Liste_Joueur);

            // LANCEMENT DU JEU
            jeu.ToString();
            Deroulement desk = new Deroulement(jeu);
            Console.WriteLine("Première Carte sur le terrain : " + cartePeek());
            // Deroulement de la partie
            // Joueur Aleatoire
            chf = aleatoire.Next(0, jeu.Liste_Joueur.Count);
            jr_debut = jeu.Liste_Joueur[chf];
            idx = 0;
            trouvee = cartePeek();
            while (!arret)
            {
                findCarte(cartePeek());
            }


        }

        public static void findCarte(Carte terrain)
        {

            for (idx = 0; idx < jeu.Liste_Joueur.Count; idx++)
            {

                List<Carte> echantillon = new List<Carte>();
                // Si c'est le premier joueur
                //int k = 0;
                if (idx == 0)
                {
                    for (int a = 0; a < jr_debut.GetList_Carte().Count; a++)
                    {
                        Carte r = jr_debut.GetList_Carte()[a];
                        // Vérifier si la couleur ou la valeur de la carte corresponde
                        if (r.GetColor() == terrain.GetColor() || r.GetValeur_String() == terrain.GetValeur_String())
                        {
                            echantillon = new List<Carte>();
                            echantillon.Add(r);
                            trouvee = r;
                        }
                    }
                }
                else if (idx == 1 && jeu.Liste_Joueur[idx] == jr_debut)
                {
                    if (jeu.Liste_Joueur.Count == 2 || jeu.Liste_Joueur.Count == 3)
                    {
                        for (int a = 0; a < jeu.Liste_Joueur[idx - 1].GetList_Carte().Count; a++)
                        {
                            Carte r;
                            r = jeu.Liste_Joueur[idx - 1].GetList_Carte()[a];
                            // Vérifier si la couleur ou la valeur de la carte corresponde
                            if (r.GetColor() == trouvee.GetColor() || r.GetValeur_String() == trouvee.GetValeur_String())
                            {
                                echantillon = new List<Carte>();
                                echantillon.Add(r);
                                trouvee = r;
                            }
                        }
                    }
                    else
                    {
                        for (int a = 0; a < jeu.Liste_Joueur[idx + 1].GetList_Carte().Count; a++)
                        {
                            Carte r;
                            r = jeu.Liste_Joueur[idx + 1].GetList_Carte()[a];
                            // Vérifier si la couleur ou la valeur de la carte corresponde
                            if (r.GetColor() == trouvee.GetColor() || r.GetValeur_String() == trouvee.GetValeur_String())
                            {
                                echantillon = new List<Carte>();
                                echantillon.Add(r);
                                trouvee = r;
                            }
                        }
                    }
                }
                else
                {
                    for (int a = 0; a < jeu.Liste_Joueur[idx].GetList_Carte().Count; a++)
                    {
                        var r = jeu.Liste_Joueur[idx].GetList_Carte()[a];
                        // Vérifier si la couleur ou la valeur de la carte corresponde
                        if (r.GetColor() == trouvee.GetColor() || r.GetValeur_String() == trouvee.GetValeur_String())
                        {
                            echantillon = new List<Carte>();
                            echantillon.Add(r);
                            trouvee = r;
                        }

                    }
                }
                // Si au moins une Carte a été ajoutée dans la liste echantillon
                if (echantillon.Count >= 1)
                {
                    int nbre = aleatoire.Next(0, echantillon.Count);
                    trouvee = echantillon[nbre];
                    Deroulement.cartesJouees.Add(trouvee); // Pose la carte sur le terrain de jeu
                    /* TODO : Si la Carte jouee = 10 (changer le sens du jeu)
                     * TODO : 
                     */
                    if (idx == 0)
                    {
                        Console.Write(jr_debut.GetNom() + " a joué la carte --> "
                       + trouvee.ToString());
                        jr_debut.GetList_Carte().Remove(trouvee);
                        Console.WriteLine("\tTotal cartes en main: " + jr_debut.GetList_Carte().Count);
                        if (jr_debut.IsWinner())
                        {
                            Console.WriteLine(jeu.Liste_Joueur[idx].GetNom() + " a remporté la Partie !");
                            arret = true;
                            break; //On sort de la boucle for; donc on sort de la fonction
                        }
                    }
                    else if (idx == 1 && jeu.Liste_Joueur[idx] == jr_debut)
                    {
                        int total = jeu.Liste_Joueur.Count;
                        if (jeu.Liste_Joueur.Count == 2)
                        {
                            Console.Write(jeu.Liste_Joueur[total - idx].GetNom() + " a joué la carte --> "
                        + trouvee.ToString());
                            jeu.Liste_Joueur[total - idx].GetList_Carte().Remove(trouvee);
                            Console.WriteLine("\tTotal cartes en main: " + jeu.Liste_Joueur[total - idx].GetList_Carte().Count);
                            // Verifier si c'est notre gagnant : il n'a plus de carte dans sa main 
                            if (jeu.Liste_Joueur[total - idx].IsWinner())
                            {
                                Console.WriteLine(jeu.Liste_Joueur[total - idx].GetNom() + " a remporté la Partie !");
                                arret = true;
                                break; //On sort de la boucle for; donc on sort de la fonction
                            }
                        }
                        else
                        {
                            Console.Write(jeu.Liste_Joueur[idx - 1].GetNom() + " a joué la carte --> "
                      + trouvee.ToString());
                            jeu.Liste_Joueur[idx - 1].GetList_Carte().Remove(trouvee);
                            Console.WriteLine("\tTotal cartes en main: " + jeu.Liste_Joueur[idx - 1].GetList_Carte().Count);
                            // Verifier si c'est notre gagnant : il n'a plus de carte dans sa main 
                            if (jeu.Liste_Joueur[idx].IsWinner())
                            {
                                Console.WriteLine(jeu.Liste_Joueur[idx - 1].GetNom() + " a remporté la Partie !");
                                arret = true;
                                break; //On sort de la boucle for; donc on sort de la fonction
                            }
                        }

                    }
                    else
                    {
                        Console.Write(jeu.Liste_Joueur[idx].GetNom() + " a joué la carte --> "
                        + trouvee.ToString());
                        jeu.Liste_Joueur[idx].GetList_Carte().Remove(trouvee);
                        Console.WriteLine("\tTotal cartes en main: " + jeu.Liste_Joueur[idx].GetList_Carte().Count);
                        // Verifier si c'est notre gagnant : il n'a plus de carte dans sa main 
                        if (jeu.Liste_Joueur[idx].IsWinner())
                        {
                            Console.WriteLine(jeu.Liste_Joueur[idx].GetNom() + " a remporté la Partie !");
                            arret = true;
                            break; //On sort de la boucle for; donc on sort de la fonction
                        }
                    }

                }
                else
                {
                    if (idx == 0)
                    {
                        // La methode pour la poiche d'une carte et l'ajouter dans la main du joueur
                        Carte nouvelleCarte = poiche();
                        jr_debut.GetList_Carte().Add(nouvelleCarte);
                        Console.WriteLine(jr_debut.GetNom() + " a poiché une carte --> "
                            + nouvelleCarte + " Total cartes en main: " + jr_debut.GetList_Carte().Count);
                        evolution_jr(jr_debut);//affiche sa main
                    }
                    else if (idx == 1 && jeu.Liste_Joueur[idx] == jr_debut)
                    {
                        if (jeu.Liste_Joueur.Count == 2)
                        {
                            int total = jeu.Liste_Joueur.Count;
                            // La methode pour la poiche d'une carte et l'ajouter dans la main du joueur
                            Carte nouvelleCarte = poiche();
                            jeu.Liste_Joueur[total - idx].GetList_Carte().Add(nouvelleCarte);
                            Console.WriteLine(jeu.Liste_Joueur[total - idx].GetNom() + " a poiché une carte --> "
                                + nouvelleCarte + " Total cartes en main: " + jeu.Liste_Joueur[total - idx].GetList_Carte().Count);
                            evolution_jr(jeu.Liste_Joueur[total - idx]);//affiche sa main
                        }
                        else
                        {
                            // La methode pour la poiche d'une carte et l'ajouter dans la main du joueur
                            Carte nouvelleCarte = poiche();
                            jeu.Liste_Joueur[idx].GetList_Carte().Add(nouvelleCarte);
                            Console.WriteLine(jeu.Liste_Joueur[idx].GetNom() + " a poiché une carte --> "
                                + nouvelleCarte + " Total cartes en main: " + jeu.Liste_Joueur[idx].GetList_Carte().Count);
                            evolution_jr(jeu.Liste_Joueur[idx]);//affiche sa main
                        }

                    }
                    else
                    {
                        // La methode pour la poiche d'une carte et l'ajouter dans la main du joueur
                        Carte nouvelleCarte = poiche();
                        jeu.Liste_Joueur[idx].GetList_Carte().Add(nouvelleCarte);
                        Console.WriteLine(jeu.Liste_Joueur[idx].GetNom() + " a poiché une carte --> "
                            + nouvelleCarte + " Total cartes en main: " + jeu.Liste_Joueur[idx].GetList_Carte().Count);
                        evolution_jr(jeu.Liste_Joueur[idx]);//affiche sa main
                    }

                }
                // k++;
            }
        }

        public static Carte cartePeek()
        {
            int derniereCarte = Deroulement.cartesJouees.Count;
            Carte c = Deroulement.cartesJouees[derniereCarte - 1];
            return c;
        }

        public static Carte poiche()
        {
            Carte carte_hasard;

            /* Prendre un chiffre au hasard et le faire correspondre à une carte 
             * sur toutes les cartes existantes dans la pile de poiche
             */
            if (Carte.paquet.Count == 1)
            {
                List<Carte> brasserCarte = new List<Carte>();
                // TODO : GERER LA MANQUE DES CARTES DANS LA PILE DE POICHE
                for (int i = 0; i < Deroulement.cartesJouees.Count; i++)
                {
                    brasserCarte = new List<Carte>();
                    int numberRandom = aleatoire.Next(0, Deroulement.cartesJouees.Count);
                    Carte brassee = Deroulement.cartesJouees[numberRandom];
                    brasserCarte.Add(brassee);
                    // Verifier si la carte existe déjà dans la liste ou pas
                    for (int a = 0; a < brasserCarte.Count; a++)
                    {
                        while (brassee == brasserCarte[a])
                        {
                            numberRandom = aleatoire.Next(0, Deroulement.cartesJouees.Count);
                            brassee = Deroulement.cartesJouees[numberRandom];
                        }
                        Carte.paquet.Add(brassee);
                        Deroulement.cartesJouees.Remove(brassee);
                    }
                }

            }

            int chiffre_hasard = aleatoire.Next(0, Carte.paquet.Count);
            carte_hasard = Carte.paquet[chiffre_hasard];



            // retirer la carte selectionnée de la liste paquet pour éviter d'avoir des doublons
            Carte.paquet.RemoveAt(chiffre_hasard);
            return carte_hasard;
        }

        /** FONCTION Affichage_liste_carte : Affiche une liste contenant toutes les cartes dont possedent un Joueur */
        public static void Affichage_liste_carte(List<Carte> list)
        {
            //Console.WriteLine("\nAffichage de la liste des cartes du Joueur : ");
            for (int i = 0; i < list.Count; i++)
                Console.Write(list[i] + " * ");
            Console.WriteLine(); //Aérer le code
        }

        /** FONCTION Affichage_liste_Joueur : Affiche une liste contenant tous les joueurs dont possedent une Partie du jeu */
        public static void Affichage_Caracteristique_Joueur(Joueur player)
        {

            Console.WriteLine("\nAffichage des Caracteristiques du Joueur : ");
            Console.WriteLine("\tNom : " + player.GetNom()
                + "\n\tPrenom : " + player.GetPrenom()
                + "\n\tCartes : "); // + jeu.Liste_Joueur[position].GetList_Carte_s());
            Affichage_liste_carte(player.GetList_Carte());
            Console.WriteLine(); //Aérer le code
        }

        public static void Affichage_liste_Joueur(List<Joueur> list)
        {
            foreach (Joueur jr in list)
            {
                Affichage_Caracteristique_Joueur(jr);
                Console.WriteLine(); //Aérer le code
            }
        }
        public static void evolution_jr(Joueur player)
        {
            Console.WriteLine("===========================================================");
            int position = jeu.Liste_Joueur.IndexOf(player);
            Console.WriteLine("\t\t\tNom : " + player.GetNom()
               + "\n\t\t\tPrenom : " + player.GetPrenom()
               + "\nCartes : " + jeu.Liste_Joueur[position].GetList_Carte_s());
            Console.WriteLine("===========================================================");
        }

    }
}
