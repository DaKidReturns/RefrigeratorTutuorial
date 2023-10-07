using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator
{
   

    public  class DoorSensor
    {
        public event EventHandler<DoorSensorEventArgs> DoorStatusChanged;

        private Status doorStatus;
        public Status DoorStatus
        {
            get { return doorStatus; }
            set
            {
                doorStatus = value;

                DoorSensorEventArgs args = new DoorSensorEventArgs();
                args.DoorStatus = doorStatus;
                DoorStatusChanged(this,args);
            }
        }


        /// <summary>
        /// Door Opened function will set the door status to Status.ON if the door is opened
        /// This will alert all the listeners lisening to DoorStatusChanged
        /// </summary>
        public void DoorOpened() {
            DoorStatus = Status.ON;
        }
        /// <summary>
        ///  Door Closed function will set the door status to Status.ON if the door is Closed
        ///  This will alert all the listeners lisening to DoorStatusChanged
        /// </summary>
        public void DoorClosed() {
            DoorStatus = Status.OFF;
        }

        

    }

    public class DoorSensorEventArgs : EventArgs { 
        public Status DoorStatus { get; set; }
    }
}
