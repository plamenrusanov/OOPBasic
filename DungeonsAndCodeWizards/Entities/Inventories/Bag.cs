using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Bag
{
    private List<Item> items;
    protected Bag(int capacity = 100)
    {
        Capacity = capacity;
        this.items = new List<Item>();
    }

    public int Capacity { get;}

    public int Load => Items.Select(i => i.Weight).Sum();

    public IReadOnlyCollection<Item> Items => this.items;

    public void AddItem(Item item)
    {
        if (item.Weight + Load > Capacity)
        {
            throw new InvalidOperationException("Bag is full!");
        }
        this.items.Add(item);
    }

    public Item GetItem(string name)
    {
        if (this.items.Count == 0)
        {
            throw new InvalidOperationException("Bag is empty!");
        }
        Item item = this.items.FirstOrDefault(i => i.GetType().Name == name);
        if (item == null)
        {
            throw new ArgumentException($"No item with name {name} in bag!");
        }
        this.items.Remove(item);
        return item;
    }
}