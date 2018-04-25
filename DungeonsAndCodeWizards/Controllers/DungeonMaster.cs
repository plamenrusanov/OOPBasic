using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DungeonMaster
{
    private Stack<Item> itemsOnPool;
    private List<Character> characters;
    private CharacterFactory characterFactory;
    private ItemFactory itemFactory;
    private int lastSurvivorRounds;

    public DungeonMaster()
    {
        this.itemsOnPool = new Stack<Item>();
        this.characters = new List<Character>();
        this.characterFactory = new CharacterFactory();
        this.itemFactory = new ItemFactory();
        this.lastSurvivorRounds = 0;
    }

    public string JoinParty(string[] args)
    {
        Character character = characterFactory.CreateCharacter(args);
        characters.Add(character);
        return $"{args[2]} joined the party!";
    }

    public string AddItemToPool(string[] args)
    {
        Item item = this.itemFactory.CreateItem(args);
        itemsOnPool.Push(item);
        return $"{args[0]} added to pool.";
    }

    public string PickUpItem(string[] args)
    {
        Character character = characters.FirstOrDefault(c => c.Name == args[0]);
        if (character == null)
        {
            throw new ArgumentException($"Character {args[0]} not found!");
        }
        if (itemsOnPool.Count == 0)
        {
            throw new InvalidOperationException("No items left in pool!");
        }
        Item item = itemsOnPool.Pop();
        character.ReceiveItem(item);
        return $"{args[0]} picked up {item.GetType().Name}!";
    }

    public string UseItem(string[] args)
    {
        string charName = args[0];
        string itemName = args[1];

        Character character = characters.FirstOrDefault(c => c.Name == charName);
        if (character == null)
        {
            throw new ArgumentException($"Character {charName} not found!");
        }
        Item item = character.Bag.GetItem(itemName);
        item.AffectCharacter(character);
        return $"{charName} used {itemName}.";
    }

    public string UseItemOn(string[] args)
    {
        string giverName = args[0];
        string receiverName = args[1];
        string itemName = args[2];
        Character giver = characters.FirstOrDefault(c => c.Name == giverName);
        if (giver == null)
        {
            throw new ArgumentException($"Character {giverName} not found!");
        }
        Character receiver = characters.FirstOrDefault(c => c.Name == receiverName);
        if (receiver == null)
        {
            throw new ArgumentException($"Character {receiverName} not found!");
        }
        Item item = giver.Bag.GetItem(itemName);
        item.AffectCharacter(receiver);
        return $"{giverName} used {itemName} on {receiverName}.";
    }

    public string GiveCharacterItem(string[] args)
    {
        string giverName = args[0];
        string receiverName = args[1];
        string itemName = args[2];
        Character giver = characters.FirstOrDefault(c => c.Name == giverName);
        if (giver == null)
        {
            throw new ArgumentException($"Character {giverName} not found!");
        }
        Character receiver = characters.FirstOrDefault(c => c.Name == receiverName);
        if (receiver == null)
        {
            throw new ArgumentException($"Character {receiverName} not found!");
        }
        Item item = giver.Bag.GetItem(itemName);
        receiver.Bag.AddItem(item);
        return $"{giverName} gave {receiverName} {itemName}.";
    }

    public string GetStats()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in characters.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
        {
            string alive = "Alive";
            if (!item.IsAlive)
            {
                alive = "Dead";
            }
            sb.AppendLine($"{item.Name} - HP: {item.Health}/{item.BaseHealth}, AP: {item.Armor}/{item.BaseArmor}, Status: {alive}");
        }
        return sb.ToString().Trim();
    }

    public string Attack(string[] args)
    {
        string ataker = args[0];
        string reciver = args[1];
        Character attacker = characters.FirstOrDefault(c => c.Name == ataker);
        if (attacker == null)
        {
            throw new ArgumentException($"Character {ataker} not found!");
        }
        Character receiver = characters.FirstOrDefault(c => c.Name == reciver);
        if (receiver == null)
        {
            throw new ArgumentException($"Character {reciver} not found!");
        }
        if (!(attacker is IAttackable attackAt))
        {
            throw new ArgumentException($"{attacker.Name} cannot attack!");
        }
        attackAt.Attack(receiver);
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
        if (!receiver.IsAlive)
        {
            sb.AppendLine($"{receiver.Name} is dead!");
        }
        return sb.ToString().Trim();
    }

    public string Heal(string[] args)
    {
        string heler = args[0];
        string reciver = args[1];
        var healer = characters.FirstOrDefault(c => c.Name == heler);
        if (healer == null)
        {
            throw new ArgumentException($"Character {heler} not found!");
        }
        Character receiver = characters.FirstOrDefault(c => c.Name == reciver);
        if (receiver == null)
        {
            throw new ArgumentException($"Character {reciver} not found!");
        }
        if (!(healer is IHealable healableCharacter))
        {
            throw new ArgumentException($"{healer.Name} cannot heal!");
        }
        healableCharacter.Heal(receiver);
        return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
    }

    public string EndTurn(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in characters.Where(c => c.IsAlive == true))
        {
            double healthBeforeRest = item.Health;
            item.Rest();
            double currentHealth = item.Health;
            sb.AppendLine($"{item.Name} rests ({healthBeforeRest} => {currentHealth})");
        }
        if (characters.Where(c => c.IsAlive == true).Count() < 2)
        {
            this.lastSurvivorRounds++;
        }
        return sb.ToString().Trim();
    }

    public bool IsGameOver()
    {
        return this.lastSurvivorRounds > 1;
    }

}
