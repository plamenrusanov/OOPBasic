using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities.Vehicles;
using StorageMaster.Factories;

namespace StorageMaster.Entities.Storagies
{
    public class Warehouse : Storage
    {
       
        private const int capacity = 10;
        private const int garageSlots = 10;
       
        public Warehouse(string name) 
            : base(name, capacity, garageSlots, InitializeVehicles())
        {
           
        }

        private static IEnumerable<Vehicle> InitializeVehicles()
        {
            VehicleFactory vehicleFactory = new VehicleFactory();
            List<Vehicle> ve = new List<Vehicle>();
            for (int i = 0; i < 3; i++)
            {

                Semi semi = (Semi)vehicleFactory.CreateVehicle("Semi");
                ve.Add(semi);
            }
            return ve;
        }
    }
}
