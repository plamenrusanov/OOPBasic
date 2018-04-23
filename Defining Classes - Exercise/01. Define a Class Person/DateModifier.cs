using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

public class DateModifier
{
    public int CalcDifferenceDate(string first, string second)
    {
        DateTime firstDate = DateTime.Parse(first);
        DateTime secondDate = DateTime.Parse(second);

        TimeSpan timeSpan = firstDate - secondDate;
      
        return Math.Abs(timeSpan.Days);
    }
}

