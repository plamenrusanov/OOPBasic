using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

public class Song
{
    private string artistName;
    private string songName;
    private TimeSpan  songLength;

    public Song(string artistName, string songName, string songLength)
    {
        ArtistName = artistName;
        SongName = songName;
        SongLength = IsValidSongLength(songLength);
    }
   
    public string ArtistName
    {
        get { return artistName; }
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
            }
            artistName = value;
        }
    }

    public string SongName
    {
        get { return songName; }
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new ArgumentException("Song name should be between 3 and 30 symbols.");
            }
            songName = value;
        }
    }

    public TimeSpan SongLength
    {
        get { return songLength; }
        set { songLength = value;}
    }

    private TimeSpan IsValidSongLength(string value)
    {
       // TimeSpan span = new TimeSpan(0, 0, 0);
       // if (!TimeSpan.TryParse("0:" + value, out span))
       // {
       //     throw new ArgumentException("Invalid song length.");
       // }

        TimeSpan time = new TimeSpan(0, 14, 59);
        TimeSpan timeSpan;
        List<int> tokens = new List<int>();
        try
        {
            tokens = value.Split(":").Select(int.Parse).ToList();
        }
        catch (Exception)
        {

            throw new ArgumentException("Invalid song length.");
        }
       

        if ((tokens[0] >= 0 && tokens[0] <= 59) && (tokens[1] >= 0 && tokens[1] <= 59))
        {
            timeSpan = TimeSpan.Parse("00:" + value);
            int result = time.CompareTo(timeSpan);
            if (result >= 0)
            {
                return timeSpan;               
            }
        }
        if (tokens[0] < 0 || tokens[0] > 14)
        {
            throw new ArgumentException("Song minutes should be between 0 and 14.");
        }
        if (tokens[1] < 0 || tokens[1] > 59)
        {
            throw new ArgumentException("Song seconds should be between 0 and 59.");
        }
        return timeSpan;
    }
}


