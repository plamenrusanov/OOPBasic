using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities.Storagies
{
    public abstract class Storage
    {
        private List<Product> products;
        private Vehicle[] vehicles;

        protected Storage(string name, int capacity, int garageSlots , IEnumerable<Vehicle> vehicles)
        {
            this.products = new List<Product>();
            this.vehicles = new Vehicle[garageSlots];
            AddVehicle(vehicles);
            Name = name;
            Capacity = capacity;
            GarageSlots = garageSlots;
        }

        private void AddVehicle(IEnumerable<Vehicle> vehicles)
        {
            int count = 0;
            foreach (var item in vehicles)
            {
                this.vehicles[count] = item;
                count++;
            }
        }

        public string Name { get; }

        public int Capacity { get; }

        public int GarageSlots { get;}

        public bool IsFull => this.products.Select(p => p.Weight).Sum() >= Capacity;

        public IReadOnlyCollection<Vehicle> Garage => this.vehicles;

        public IReadOnlyCollection<Product> Products => this.products;

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            if (vehicles[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }
            Vehicle vehicle = vehicles[garageSlot];

           // vehicles[garageSlot] = null;

            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            if (garageSlot >= GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            if (vehicles[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }
            Vehicle vehicle = vehicles[garageSlot];

            int index = -1;
            for (int i = 0; i < deliveryLocation.Garage.Count; i++)
            {
                if (deliveryLocation.Garage.ToArray()[i] == null)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new InvalidOperationException("No room in garage!");
            }
            vehicles[garageSlot] = null;
            deliveryLocation.vehicles[index] = vehicle;
            return index;

        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }
            if (garageSlot >= GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            if (vehicles[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }
            Vehicle vehicle = vehicles[garageSlot];
            int countUnloadProducts = 0;
            int countProducts = vehicle.Trunk.Count;
            for (int i = 0; i < countProducts; i++)
            {
                if (this.IsFull)
                {
                    break;
                }
                this.products.Add(vehicle.Unload());
                countUnloadProducts++;
            }
            return countUnloadProducts;
        }
    }
}
