using System;
using System.Collections.Generic;
using System.Text;

public class RandomList:List<string>
{

    Random random = new Random();

    public string RandomString()
    {
        int index = random.Next(0, this.Count - 1);
        string result = this[index];
        this.RemoveAt(index);
        return result;

    }
}
