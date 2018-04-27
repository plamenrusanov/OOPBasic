using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities.Vehicles
{
    public abstract class Vehicle
    {
        private Stack<Product> trunk;

        public int Capacity { get; }

        public IReadOnlyCollection<Product> Trunk => this.trunk;

        public bool IsFull => trunk.Select(t => t.Weight).Sum() >= Capacity;

        public bool IsEmpty => trunk.Count == 0;

        protected Vehicle(int capacity)
        {
            this.trunk = new Stack<Product>();
            Capacity = capacity;
        }

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }
            this.trunk.Push(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }
            return this.trunk.Pop();
        }

    }
}
