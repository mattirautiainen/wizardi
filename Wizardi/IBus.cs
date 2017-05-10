using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizardi
{
    public delegate void BusEventHandler(object sender, MessageEventArgs args);

    public interface IBus
    {
        event BusEventHandler BusEvent;
        void SetParameter(string name, int value);
       
    }
}
