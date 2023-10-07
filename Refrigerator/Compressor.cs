using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator
{
    internal class Compressor : ISwitchable
    {
        public event EventHandler<CompressorStateChangeEventArgs> CompressorStateChangeEvent;

        Status status;

        public void TurnOff()
        {
            status = Status.OFF;
            CompressorStateChangeEvent(this, new CompressorStateChangeEventArgs(status));
        }

        public void TurnOn()
        {
            status = Status.ON;
            CompressorStateChangeEvent(this, new CompressorStateChangeEventArgs(status));
        }

        public void HandleTemperatureEvents(object sender, TemperatureChangedEventArgs e) {
            if (e.Temperature < 1.1 * e.SetPoint)
            {
                TurnOff();
            }
            else if (e.Temperature > 1.1 * e.SetPoint) {
                TurnOn();
            }
        }
    }
    public class CompressorStateChangeEventArgs : EventArgs{
        public Status status { get; set; }
        public CompressorStateChangeEventArgs(Status state) {
            status = state;
        }
    }
}
