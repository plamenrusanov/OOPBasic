using System;
using System.Collections.Generic;
using System.Text;

public class StackOfStrings
{
    private List<string> data = new List<string>();

    public bool IsEmpty()
    {
        if (data.Count == 0)
        {
            return true;
        }
        return false;
    }

    public void Push(string v)
    {
        data.Add(v);
    }

    public string Peek()
    {
        string result = string.Empty;
        if (!IsEmpty())
        {
            result = data[data.Count - 1];
        }
        return result;
    }

    public string Pop()
    {
        string result = string.Empty;
        if (!IsEmpty())
        {
            result = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);
        }
        return result;
    }
}

