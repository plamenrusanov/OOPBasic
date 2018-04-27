using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities.Vehicles;
using StorageMaster.Factories;

namespace StorageMaster.Entities.Storagies
{
    public class AutomatedWarehouse : Storage
    {
        private const int capacity = 1;
        private const int garageSlots = 2;
        public AutomatedWarehouse(string name)
            : base(name, capacity, garageSlots, InitializeVehicles())
        {
        }

        private static IEnumerable<Vehicle> InitializeVehicles()
        {
            VehicleFactory vehicleFactory = new VehicleFactory();
            return new List<Vehicle>() { vehicleFactory.CreateVehicle("Truck") };
        }
    }
}
