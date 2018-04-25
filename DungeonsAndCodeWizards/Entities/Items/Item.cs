﻿using System;
using System.Collections.Generic;
using System.Text;

public abstract class Item
{
    protected Item(int weight)
    {
        Weight = weight;
    }

    public int Weight { get;}

    public virtual void AffectCharacter(Character character)
    {
        if (!character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
    }
}
