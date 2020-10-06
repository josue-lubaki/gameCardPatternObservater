using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_Uno
{
    interface IObserver
    {
        bool Update(ISubject subject);
    }
}
