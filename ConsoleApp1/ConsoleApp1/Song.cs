using System;
using System.Collections.Generic;

public class Song
{
    private string name;
    public Song NextSong { get; set; }

    public Song(string name)
    {
        this.name = name;
    }

    public bool IsRepeatingPlaylist()
    {
        HashSet<Song> list = new HashSet<Song>() { this };
        Song currentSong = this;
        while(currentSong.NextSong != null) {
            if (list.Contains(currentSong.NextSong)) return true;

            list.Add(currentSong.NextSong);
            currentSong = currentSong.NextSong;
        }
        return false;
    }

    public static void Main1(string[] args)
    {
        Song first = new Song("Hello");
        Song second = new Song("Eye of the tiger");

        first.NextSong = second;
        second.NextSong = first;

        Console.WriteLine(first.IsRepeatingPlaylist());
    }
}