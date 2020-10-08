using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
/*==========================================================================*/
/*          @Authors : Josue Lubaki & Ismael Coulibaly & Xuyao Hu           */
/*==========================================================================*/
namespace Jeu_Uno
{
    /** JOUEUR.cs : La Classe implemente L'Objet Joueur. cette classe comporte essentiellement 2 methodes telles que :
     * @see Play() : Evenement du type asynchrone qui censé faire jouer chacun de joueur lorsque c'est à son tour
     * @see ToString() : qui renvoi le nom et prenom du Joueur
     */
    class Joueur
    {
        private List<Carte> carteEnMain;
        private string nom;
        private string prenom;
        /* Création un delegate du type LinkList<Joueur> pour gérer le fait que seul un Joueur faisant partit de la liste, 
         * qui possède le droit d'effectuer L'Evenement de deposer et piocher une carte
         * */
        public delegate void EventHandler(object sender, DepotEtPiocheEvent e);
        public event EventHandler Handlers;
        /* Constructor */
        public Joueur(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
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
        public List<Carte> CartesEnMain
        {
            get { return carteEnMain; }
            set { carteEnMain = value; }
        }
        // Evenement du type asynchrone qui censé faire jouer chacun de joueur
        public async void Play()
        {
            LinkedList<Joueur> cam = new LinkedList<Joueur>();
            cam.AddLast(this);
            DepotEtPiocheEvent e = new DepotEtPiocheEvent(cam.First);
            Handlers(this, e);
            await Task.Delay(800); 
        }
        public override string ToString()
        {
            string output = Prenom + " " +  Nom;
            return output;
        }
    }
}