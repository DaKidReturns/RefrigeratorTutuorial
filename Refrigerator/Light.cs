using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator
{
    internal class Light : ISwitchable
    {
        Status status;
        public void DoorSensorListener(object sender, DoorSensorEventArgs e) {
            if (e.DoorStatus == Status.ON)
            {
                status = Status.ON;
               
            }
            else { 
                status = Status.OFF;
                Console.WriteLine("Light OFF");
            }
        }

        public void TurnOn() {
            Console.WriteLine("Light ON");
        }
        public void TurnOff()
        {
            Console.WriteLine("Light ON");
        }
    }
}
