using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator
{
    public class Beeper : ISwitchable
    {
        private Timer beepTimer;
        private TimerState state;

        public Beeper()
        {
            state = new TimerState();
            beepTimer = new Timer(callback: new TimerCallback(beeper),
                state: state,
                dueTime: Timeout.Infinite,
                period: 2000
                );
        }
        /// <summary>
        /// Listens to the DoorSensor's change of status and starts or stops the beeper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The status of the door</param>
        public void DoorSensorListener(object sender,DoorSensorEventArgs e) {
            if (e.DoorStatus == Status.OFF)
            {
                TurnOff();
            }
            else {
                TurnOn();
            }
        }
        /// <summary>
        /// The beeper function is called by the timer at the required interval 
        /// and after a specified timeinterval changes the frequency of the Timer that calls beeper
        /// </summary>
        /// <param name="TimerState">The timer state used to keep track of how much time has passed</param>
        private void beeper(object TimerState) {
            Console.Write("Beep.. ");
            var state = TimerState as TimerState;
            Interlocked.Increment(ref state.counter);
            if (state.counter > 10) {
                beepTimer.Change(dueTime: 0,period:500) ;
            }
            
            
        }

        public void TurnOn() {
            beepTimer.Change(dueTime: 2000, 2000);
        }

        public void TurnOff() {
            beepTimer.Change(dueTime: Timeout.Infinite, period: 2000);
            state.counter = 0;
        }
    }
    public class TimerState {

        public int counter = 0;
    }

}
