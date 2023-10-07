using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator
{
    public class Fan : ISwitchable
    {
        /// <summary>
        /// Timer runs the fan periodically
        /// </summary>
        Timer timer;
        Status status;
        bool temperatureReachedFlag;
        public Fan() {
            DoorStatus = Status.OFF;
            temperatureReachedFlag = false;
            timer = new Timer(new TimerCallback(NormalStartFan),this, dueTime:0, period: 10000);

        }

        Status DoorStatus;


        void NormalStartFan(object obj) {
            if (status == Status.ON)
            {
                return;
            }
            else {
                if (DoorStatus == Status.ON && temperatureReachedFlag == false)
                {
                    TurnOn();

                }
                else {
                    return;
                }
                
                for (int i = 1; i < 6 && DoorStatus == Status.ON && temperatureReachedFlag == false; i++)
                {
                    Console.WriteLine($"Fan Running for {i} seconds");
                    Thread.Sleep(1000);
                }
                TurnOff();
            }
        }

        public void TurnOff()
        {
            lock (this)
            {
                status = Status.OFF;
            }
        }

        public void TurnOn()
        {
            lock (this)
            {
                status = Status.ON;
            }
        }


        /// <summary>
        /// listens to the door sensor and switches the fan accordingly.
        /// </summary>
        /// <param name="e"></param>
        public void DoorSensorListener(object sender, DoorSensorEventArgs e) {
            if (e.DoorStatus == Status.ON)
            {
                TurnOff();
            }
            else {
                TurnOn();
            }
        }

        public void TemperatureSensorListener(object sender, TemperatureChangedEventArgs e) {
            if ((int)e.Temperature == (int)e.SetPoint)
            {
                temperatureReachedFlag = true;
            }
            else {
                temperatureReachedFlag = true;
            }
        }
    }
}
