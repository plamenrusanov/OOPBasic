using System;
using System.Collections.Generic;
using System.Text;

public abstract class Character
{
    private string name;
    private double health;
    private double armor;

    protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
    {
        Name = name;
        BaseHealth = health;
        Health = health;
        BaseArmor = armor;
        Armor = armor;
        AbilityPoints = abilityPoints;
        Bag = bag;
        Faction = faction;
        IsAlive = true;
    }

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }
            this.name = value;
        }
    }

    public double BaseHealth { get; }

    public double Health
    {
        get { return this.health; }
        set
        {
            if (value <= 0)
            {
                value = 0;
                IsAlive = false;
            }
            if (value > BaseHealth)
            {
                value = BaseHealth;
            }
            this.health = value;
        }
    }

    public double BaseArmor { get; }

    public double Armor
    {
        get { return this.armor; }
        set
        {
            if (value < 0)
            {
                value = 0;
            }
            if (value > BaseArmor)
            {
                value = BaseArmor;
            }
            this.armor = value;
        }
    }

    public double AbilityPoints { get; }

    public Bag Bag { get; }

    public Faction Faction { get; }

    public bool IsAlive { get; private set; }

    public virtual double RestHealMultiplier => 0.2;

    public void TakeDamage(double hitPoints)
    {
        EnsureAlive();
        if (hitPoints <= Armor)
        {
            Armor -= hitPoints;
        }
        else if (hitPoints > Armor)
        {
            hitPoints -= Armor;
            Armor = 0;
            if (hitPoints < Health)
            {
                Health -= hitPoints;
            }
            else
            {
                Health = 0;
                IsAlive = false;
            }
        }
    }

    public void Rest()
    {
        EnsureAlive();
        Health += BaseHealth * RestHealMultiplier;
    }

    public void UseItem(Item item)
    {
        EnsureAlive();
        item.AffectCharacter(this);
    }

    public void UseItemOn(Item item, Character character)
    {
        EnsureAlive();
        if (!character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
        item.AffectCharacter(character);
    }

    public void GiveCharacterItem(Item item, Character character)
    {
        EnsureAlive();
        if (!character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
        character.ReceiveItem(item);
    }

    public void ReceiveItem(Item item)
    {
        EnsureAlive();
        this.Bag.AddItem(item);
    }

    protected void EnsureAlive()
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
    }

}
