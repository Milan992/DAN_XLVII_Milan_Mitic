using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppVehicle
{
    class Vehicle
    {
        public string Direction { get; set; }
        public bool Crossing = false;
        public List<Vehicle> vehicles = new List<Vehicle>();

        public delegate void VehicleCreatedEventHandler(object source, EventArgs args);

        public event VehicleCreatedEventHandler VehicleCreated;

        protected virtual void OnVehicleCreated()
        {
            VehicleCreated?.Invoke(this, EventArgs.Empty);
        }

        public void CrossBridge(Vehicle vehicle)
        {
            ManualResetEvent are = new ManualResetEvent(false);

            Console.WriteLine("{0} started in {1} direction", Thread.CurrentThread.Name, vehicle.Direction);
            while (vehicle.Direction != Direction && Crossing == true)
            {
                are.WaitOne();
            }
            Console.WriteLine("{0} waiting", Thread.CurrentThread.Name);
            Crossing = true;
            Direction = vehicle.Direction;
            Console.WriteLine("{0} crossing the bridge", Thread.CurrentThread.Name);
            Thread.Sleep(500);
            Crossing = false;
            Console.WriteLine("{0} crossed the bridge", Thread.CurrentThread.Name);
        }
    }
}
