using System;
using System.Collections.Generic;
using System.Text;
/*====================================================================*/
/*          @Authors : Josue Lubaki & Ismael Coulibaly & Xuyao Hu     */
/*====================================================================*/
namespace Jeu_Uno
{
    interface IObserver
    {
        void Update(ISubject subject);
    }
}
