using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizardi
{
    public class Bus : IBus
    {

        public event BusEventHandler BusEvent;

        public void SetParameter(string name, int value)
        {
            BusEvent?.Invoke(this, new MessageEventArgs(name, value));
        }

    }

    public class MessageEventArgs : EventArgs
    {
        public string ParamName { get; private set; }
        public int ParamValue { get; private set; }
        public MessageEventArgs(string paramName, int paramValue)
        {
            ParamName = paramName;
            ParamValue = paramValue;
        }
    }
}
