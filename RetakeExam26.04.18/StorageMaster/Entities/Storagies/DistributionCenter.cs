using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities.Vehicles;
using StorageMaster.Factories;

namespace StorageMaster.Entities.Storagies
{
    public class DistributionCenter : Storage
    {
        private const int capacity = 2;
        private const int garageSlots = 5;
        public DistributionCenter(string name)
            : base(name, capacity, garageSlots, InitializeVehicles())
        {
        }

        private static IEnumerable<Vehicle> InitializeVehicles()
        {
            VehicleFactory vehicleFactory = new VehicleFactory();
            List<Vehicle> ve = new List<Vehicle>();
            for (int i = 0; i < 3; i++)
            {
               Van van = (Van) vehicleFactory.CreateVehicle("Van");
                ve.Add(van);
            }
            return ve;
        }
    }
}
