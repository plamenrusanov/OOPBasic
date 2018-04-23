using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        TimeSpan playlistLength = new TimeSpan(0, 0, 0);
        List<Song> data = new List<Song>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            try
            {
                string[] songTokens = Console.ReadLine().Split(';');
                if (songTokens.Length != 3)
                {
                    throw new ArgumentException("Invalid song.");
                }
                string artist = songTokens[0];
                string songName = songTokens[1];
                string songLength = songTokens[2];
                Song song = new Song(artist, songName, songLength);
                playlistLength = playlistLength.Add(song.SongLength);
                data.Add(song);
                Console.WriteLine("Song added.");
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }

        }

        Console.WriteLine($"Songs added: {data.Count}");
        Console.WriteLine($"Playlist length: {playlistLength.Hours}h {playlistLength.Minutes}m {playlistLength.Seconds}s");
    }
}

