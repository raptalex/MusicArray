// Alexander Raptis, Feb 7th 2023

using System;

namespace MovieFun
{
    class Program
    {
        enum Genre
        {
            Country,
            Classic,
            Pop,
            Rock,
            Jazz,
            HipHop
        }
        static void Main(string[] args)
        {
            // Collect all genre types into one comma separated string
            string genres = string.Join(", ", Enum.GetNames(typeof(Genre)));

            Console.WriteLine("How many songs would you like to enter?");
            int size = int.Parse(Console.ReadLine());

            Music[] collection = new Music[size];

            try { 
                for(uint i=0;i<collection.Length;i++)
                {
                    Console.Write("Please enter the song title: ");
                    collection[i].setTitle(Console.ReadLine());
                    Console.Write("Enter the artist's name for this song: ");
                    collection[i].setArtist(Console.ReadLine());
                    Console.Write("Enter the album the song is from: ");
                    collection[i].setAlbum(Console.ReadLine());
                    Console.Write("Please enter the length of the song in this format (hh:mm:ss): ");
                    collection[i].setLength(TimeSpan.Parse(Console.ReadLine()));
                    Console.Write($"Please enter the genre of the song from this list ({genres}): ");
                    collection[i].setGenre((Genre)Enum.Parse(typeof(Genre), Console.ReadLine(), true));
                }
            } catch(ArgumentException except)
            {
                Console.WriteLine(except.Message);
            } catch(FormatException except)
            {
                Console.WriteLine(except.Message);
            } catch(Exception except)
            {
                Console.WriteLine(except.Message);
            } finally
            {
                foreach(Music song in collection)
                    Console.WriteLine(song.Display());
            }
        }
        struct Music
        {
            private string Title;
            private string Artist;
            private string Album;
            private TimeSpan Length;
            private Genre Genre;

            public string Display()
            {
                return $"Title: {Title}\nArtst: {Artist}\nAlbum: {Album}\nLength: {Length:c}\nGenre: {Genre}";
            }
            public void setTitle(string _title)
            {
                Title = _title;
            }
            public void setArtist(string _artist)
            {
                Artist = _artist;
            }
            public void setAlbum(string _album)
            {
                Album = _album;
            }
            public void setLength(TimeSpan _length)
            {
                Length = _length;
            }
            public void setGenre(Genre _genre)
            {
                Genre = _genre;
            }
        }
    }
}