using System;
using System.Collections.Generic;
using System.Text;

public class CharacterFactory
{
    public Character CreateCharacter(string[] args)
    {
        object faction = "";
        bool isCorect = Enum.TryParse(typeof(Faction), args[0], out faction);
        
        if (!isCorect)
        {
            throw new ArgumentException($"Invalid faction \"{args[0]}\"!");
        }
        Type type = Type.GetType(args[1]);
        if (type == null)
        {
            throw new ArgumentException($"Invalid character type \"{args[1]}\"!");
        }
        Character character = (Character)Activator.CreateInstance(type, new object[] { args[2], faction});
        return character;
    }
}
