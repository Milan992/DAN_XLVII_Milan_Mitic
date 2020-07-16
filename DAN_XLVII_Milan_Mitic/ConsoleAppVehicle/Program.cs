using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppVehicle
{
    class Program
    {
        static Random random = new Random();
        static Vehicle vehicle = new Vehicle();
        static Vehicle[] vehicles;

        static void Main(string[] args)
        {
            int numberOfVehicles = random.Next(1, 16);
            vehicles = new Vehicle[numberOfVehicles];
            
            for (int i = 0; i < vehicles.Length - 1; i++)
            {
                Thread.Sleep(4);
                int j = random.Next(0, 2);

                if (j == 1)
                {
                    vehicle.Direction = "North";
                }
                else
                {
                    vehicle.Direction = "South";

                }
                vehicles[i] = vehicle;
                vehicles[i].VehicleCreated += VehiclesCreated;

                Thread t = new Thread(() => vehicle.CrossBridge(vehicle));
                t.Name = "Vehicle_" + i;
                t.Start();
            }

            Console.ReadLine();
        }

        private static void VehiclesCreated(object source, EventArgs e)
        {
                Console.WriteLine("{0} started in {1} direction", Thread.CurrentThread.Name, vehicle.Direction);
        }
    }
}
