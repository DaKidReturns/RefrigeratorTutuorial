using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator
{
    internal class LED : ISwitchable
    {
        Status status;

        public void Blink() { 
            throw new NotImplementedException();
        }
        public void TurnOn() 
        {
            status = Status.ON;
        }

        public void TurnOff()
        {
            status = Status.OFF;
        }

        public void CompressorEvent(object sender,CompressorStateChangeEventArgs e) 
        {
            if (e.status == Status.ON)
            {
                Blink();
            }
            else {
                TurnOn();
            }
        }

    }
}
