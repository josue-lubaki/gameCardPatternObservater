using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_Uno
{
    interface ISubject
    {
        void Participer(IObserver observer);
        void Notify();
    }
}
