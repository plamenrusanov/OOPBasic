using System;
using System.Collections.Generic;
using System.Linq;
public class Departments
{
    public string Name { get; set; }

    public string[][] Rooms { get; set; }

    public Departments()
    {
        Rooms = new string[20][];
    }
    public Departments(string[] inputArgs):this()
    {
        Name = inputArgs[0];
        AddPatient(inputArgs[3]);
    }

    public void AddPatient(string patientName)
    {
        for (int row = 0; row < Rooms.GetLength(0); row++)
        {
            if (Rooms[row] == null)
            {
                Rooms[row] = new string[3];
            }
            for (int col = 0; col < Rooms[row].Length; col++)
            {
                if (Rooms[row][col] == null)
                {
                    Rooms[row][col] = patientName;
                    return;
                }
            }
        }
    }

   public void PrintDepartment()
    {
        for (int row = 0; row < Rooms.GetLength(0); row++)
        {
            if (Rooms[row] != null)
            {
                for (int col = 0; col < Rooms[row].Length; col++)
                {
                    if (Rooms[row][col] != null)
                    {
                        Console.WriteLine(Rooms[row][col]);
                    }
                }
            }
        }
    }

    public void PrintRoom(int room)
    {
        List<string> peopleInRoom = new List<string>();

        for (int i = 0; i < Rooms[room - 1].Length; i++)
        {
            if (Rooms[room - 1][i] != null)
            {
                peopleInRoom.Add(Rooms[room -1][i]);
            }         
        }

        Console.WriteLine(string.Join(Environment.NewLine, peopleInRoom.OrderBy(p => p)));
    }
}

