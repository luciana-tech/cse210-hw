using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video
        {
            _title = "C# Programming Tutorial",
            _author = "Coder of Helaman",
            _length = 600
        };
        
        Video video2 = new Video
        {
            _title = "Cooking Pasta",
            _author = "Chef Jenny",
            _length = 480
        };
        
        Video video3 = new Video
        {
            _title = "Garden Tour",
            _author = "Nature Lover",
            _length = 720
        };

        // Add comments to video1 using Comment constructor
        video1._comments.Add(new Comment("John", "Great tutorial!"));
        video1._comments.Add(new Comment("Sarah", "Very helpful, thanks!"));
        video1._comments.Add(new Comment("Mike", "Can you make a part 2?"));

        // Add comments to video2
        video2._comments.Add(new Comment("Emma", "Looks delicious!"));
        video2._comments.Add(new Comment("David", "I tried this recipe, it was amazing!"));
        video2._comments.Add(new Comment("Lisa", "What kind of pasta do you recommend?"));
        video2._comments.Add(new Comment("Tom", "Simple and tasty!"));

        // Add comments to video3
        video3._comments.Add(new Comment("Anna", "Beautiful garden!"));
        video3._comments.Add(new Comment("Robert", "What fertilizer do you use?"));
        video3._comments.Add(new Comment("Maria", "I love your flower arrangement!"));

        // Create a list of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display all videos with their comments
        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}