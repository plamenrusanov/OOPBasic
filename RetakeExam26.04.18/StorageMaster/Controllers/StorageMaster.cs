using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storagies;
using StorageMaster.Entities.Vehicles;
using StorageMaster.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Controllers
{
    public class StorageMaster
    {
        private ProductFactory productFactory;
        private StorageFactory storageFactory;
        private VehicleFactory vehicleFactory;
        private List<Product> products;
        private List<Storage> storages;
        private Vehicle currentVechicle;

        public StorageMaster()
        {
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
            this.vehicleFactory = new VehicleFactory();
            this.products = new List<Product>();
            this.storages = new List<Storage>();
            this.currentVechicle = null;
        }

        public string AddProduct(string type, double price)
        {
           Product product = productFactory.CreateProduct(type, price);
            products.Add(product);
            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = storageFactory.CreateStorage(type, name);
            storages.Add(storage);
            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = storages.FirstOrDefault(s => s.Name == storageName);
            Vehicle vehicle = storage.Garage.ToList()[garageSlot];
            this.currentVechicle = vehicle;
            return $"Selected {vehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;
            foreach (string productName in productNames)
            {
                if (currentVechicle.IsFull) break;
                Product product = products.LastOrDefault(p => p.GetType().Name == productName);
                if (product == null)
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }
                if (currentVechicle.Capacity < currentVechicle.Trunk.Select(p => p.Weight).Sum() + product.Weight)
                {
                    continue;
                }
                int index = products.LastIndexOf(product);
                currentVechicle.LoadProduct(product);
                products.RemoveAt(index);
                loadedProductsCount++;
            }
            return $"Loaded {loadedProductsCount}/{productNames.Count()} products into {currentVechicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            Storage courceStorage = storages.FirstOrDefault(s => s.Name == sourceName);
            if (courceStorage == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            Storage destStorage = storages.FirstOrDefault(s => s.Name == destinationName);
            if (destStorage == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }
            Vehicle vehicle = courceStorage.Garage.ToArray()[sourceGarageSlot];
            int destinationGarageSlot = courceStorage.SendVehicleTo(sourceGarageSlot, destStorage);
            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = storages.FirstOrDefault(s => s.Name == storageName);
            Vehicle vehicle = storage.Garage.ToList()[garageSlot];
            int c = vehicle.Trunk.Count;
            int unloadedProductsCount= storage.UnloadVehicle(garageSlot);
           


            return $"Unloaded { unloadedProductsCount}/{c} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            StringBuilder sb = new StringBuilder();
            Storage storage = storages.FirstOrDefault(s => s.Name == storageName);
            double sumWeght = storage.Products.Select(p => p.Weight).Sum();
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (var item in storage.Products)
            {
                if (!dictionary.ContainsKey(item.GetType().Name))
                {
                    dictionary.Add(item.GetType().Name, 0);
                }
                dictionary[item.GetType().Name]++;
            }

            sb.Append($"Stock ({sumWeght}/{storage.Capacity}): [");
            foreach (var item in dictionary.OrderByDescending(d => d.Value).ThenBy(d => d.Key))
            {
                sb.Append($"{item.Key} ({item.Value}), ");
            }
            if (dictionary.Count != 0)
            {
                sb = sb.Remove(sb.Length - 2, 2);
            }
            
            sb.AppendLine("]");
            List<string> cars = new List<string>();
            foreach (var item in storage.Garage)
            {
                if (item == null)
                {
                    cars.Add("empty");
                }
                else
                {
                    cars.Add(item.GetType().Name);
                }
            }

            sb.AppendLine($"Garage: [{string.Join("|", cars)}]");
            return sb.ToString().Trim();
        }

        public string GetSummary()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in storages.OrderByDescending(s => s.Products.Sum(p => p.Price)))
            {
                sb.AppendLine($"{item.Name}:");
                double sum = item.Products.Sum(p => p.Price);
                sb.AppendLine($"Storage worth: ${sum:f2}");
            }
            return sb.ToString().Trim();
        }

    }
}
