using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator
{
    public class TemperatureSensor 
    {
        private Environment environment;

        //public event EventHandler<SetpointChangedEventArgs> SetpointChanged;
        public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged; //publisher for temperature

        private Timer timer;

        double setPoint;
        double temperature;

        public TemperatureSensor(Environment environment) { 
            setPoint = 5;
            temperature = 30;
            this.environment = environment;
            timer = new Timer(new TimerCallback(getTemperature),this, dueTime: 0, period:500);
        }

        public double SetPoint { get 
            { 
                return setPoint; 
            }
            set {
                setPoint = value;
                TemperatureChangedEventArgs e = new TemperatureChangedEventArgs();
                e.SetPoint = SetPoint;
                e.Temperature = Temperature;
                TemperatureChanged(this, e);
            }
        }
        public double Temperature { 
            get { 
                return temperature;
            }
            set {
                temperature = value;
                TemperatureChangedEventArgs e = new TemperatureChangedEventArgs();
                e.SetPoint = SetPoint;
                e.Temperature = Temperature;
                TemperatureChanged(this, e);
                Console.WriteLine($"Temperature changed: {value}");
            }
        }

        /// <summary>
        /// //This function gets the tempeature from the environment.
        /// </summary>
        public void getData() {
            Temperature = environment.Value;
        }

        /// <summary>
        /// This function should run every 500ms getting the Temperature
        /// from the surroundings
        /// </summary>
        public void getTemperature(object obj) { 
            TemperatureSensor sensor = (TemperatureSensor)obj;
            sensor.getData();
        }

    }
    public class TemperatureChangedEventArgs : EventArgs
    {
        public double SetPoint { get; set; }
        public double Temperature { get; set; }
    }
}
