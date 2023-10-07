using Refrigerator;

public class Program {
    public static void Main(String[] args)
    {
        string input = Console.ReadLine();
        //fridge.doorSensor = new DoorSensor();
        Refrigerator.Environment environment = new Refrigerator.Environment();

        IOTRefridgerator fridge = new IOTRefridgerator(environment);

        fridge.doorSensor.DoorStatusChanged += fridge.Door;
        

       

        if (input == "1")
        {
            //open door event
            fridge.doorSensor.DoorOpened();

        }
        input = Console.ReadLine();
        if (input == "1")
        {
            //open door event
            fridge.doorSensor.DoorClosed();

        }
        input = Console.ReadLine();
        if (input == "1")
        {
            //open door event
            fridge.doorSensor.DoorOpened();

        }
        input = Console.ReadLine();
        Thread.Sleep(4000);
    }

}
public class IOTRefridgerator {

    
    public DoorSensor doorSensor;
    Beeper beeper;
    Light light;
    TemperatureSensor temperatureSensor;
    Fan fan;
    Compressor compressor;
    XMLLogger xmlLogger = new XMLLogger("./TemperatureLogs.xml");
    public IOTRefridgerator(Refrigerator.Environment environment)
    {
        beeper = new Beeper();
        doorSensor = new DoorSensor();
        light = new Light();
        fan = new Fan();
        temperatureSensor = new TemperatureSensor(environment);
        compressor = new Compressor();



        //doorSensor
        doorSensor.DoorStatusChanged += beeper.DoorSensorListener;
        doorSensor.DoorStatusChanged += light.DoorSensorListener;
        doorSensor.DoorStatusChanged += fan.DoorSensorListener;
        doorSensor.DoorStatusChanged += environment.DoorEvent;

        //temperature Sensor
        temperatureSensor.TemperatureChanged += compressor.HandleTemperatureEvents;
        temperatureSensor.TemperatureChanged += xmlLogger.LogTemperature;
        
        //Compressor
        compressor.CompressorStateChangeEvent += environment.CompressorEvent;
        //temperatureSensor.TemperatureChanged += fan.

        compressor.TurnOn();
    }
    public void Door(object sender,DoorSensorEventArgs e){
        if (e.DoorStatus == Status.ON)
        {
            Console.WriteLine("Opened Door");
        }
        else
        {
            Console.WriteLine("Closed Door");
        }
    }

}
