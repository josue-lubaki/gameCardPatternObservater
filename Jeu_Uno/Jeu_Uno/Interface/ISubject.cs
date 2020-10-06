using System;
using System.Collections.Generic;
using System.Text;
/*====================================================================*/
/*          @Authors : Josue Lubaki & Ismael Coulibaly                */
/*====================================================================*/
namespace Jeu_Uno
{
    interface ISubject
    {
        void Participer(IObserver observer);
        void Notify();
    }
}
