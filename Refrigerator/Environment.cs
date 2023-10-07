using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator
{
    /// <summary>
    /// Temperature class defines an hypothetical environment with 
    /// temperature for the sensor
    /// </summary>
    public class Environment
    {
        double incrementer;
        double value;

        public double Value { get {
                return value;
            }}
        
        public Environment() {
            incrementer = 0;
            value = 30;
            new Thread(()=> { value += incrementer; Thread.Sleep(1); }).Start();
        }

        private void changeIncrement(double val)
        {
            lock (this)
            {
                incrementer += val;
            }
            Console.WriteLine(incrementer);
        }
        /// <summary>
        /// To be execueted whent the door open or closes.
        /// </summary>
        /// <param name="e"></param>
        public void DoorEvent(object sender,DoorSensorEventArgs e) {
            if (e.DoorStatus == Status.ON)
            {
                changeIncrement(0.2);
            }
            else if (e.DoorStatus == Status.OFF) { 
                changeIncrement(-0.2);
            }
        }

        public void CompressorEvent(object sender, CompressorStateChangeEventArgs e) {
            if (e.status == Status.ON)
            {
                Console.WriteLine("Compressor is on");
                changeIncrement(-0.1);
            }
            else if (e.status == Status.OFF) { 
            
                changeIncrement(+0.1); 
            }
        }

    }

}
