﻿using System;
using System.Collections.Generic;

internal class Dough
{
    private const int MIN_WEIGHT = 1;
    private const int MAX_WEIGHT = 200;

    private Dictionary<string, double> validFlourType = new Dictionary<string, double>
    {
        ["white"] = 1.5,
        ["wholegrain"] = 1.0
    };
    private Dictionary<string, double> validBakingTechnique = new Dictionary<string, double>
    {
        ["crispy"] = 0.9,
        ["chewy"] = 1.1,
        ["homemade"] = 1.0
    };

    private string flourType;
    private string bakingTechnique;
    private int weight;


    public Dough(string flourType, string bakingTechnique, int weight)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }


    private int Weight
    {
        get { return weight; }
        set
        {
            if (value < MIN_WEIGHT || value > MAX_WEIGHT)
            {
                throw new ArgumentException($"Dough weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
            }
            weight = value;
        }
    }

    private string FlourType
    {
        get { return flourType; }
        set
        {
            if (!this.validFlourType.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            flourType = value.ToLower();
        }
    }

    private string BakingTechnique
    {
        get { return bakingTechnique; }
        set
        {
            if (!this.validBakingTechnique.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            bakingTechnique = value.ToLower();
        }
    }

    internal double CalcCaloriesDough()
    {
        double flourCoefficient = validFlourType.GetValueOrDefault(FlourType);
        double bakingCoefficient = validBakingTechnique.GetValueOrDefault(BakingTechnique);
        return Math.Round((2 * Weight * flourCoefficient * bakingCoefficient),2);        
    }

}

