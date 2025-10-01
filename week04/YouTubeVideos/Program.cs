using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create video list
        List<Video> videos = new List<Video>();

        // Video 1
        Video v1 = new Video("Intro to C#", "Alice Johnson", 300);
        v1.AddComment(new Comment("Sam", "Great explanation!"));
        v1.AddComment(new Comment("Lila", "Really helped me understand."));
        v1.AddComment(new Comment("Tom", "Awesome video, thanks!"));
        videos.Add(v1);

        // Video 2
        Video v2 = new Video("Advanced Python", "Bob Smith", 600);
        v2.AddComment(new Comment("Eve", "Clear and concise."));
        v2.AddComment(new Comment("Jake", "Please make a part 2!"));
        v2.AddComment(new Comment("Maya", "Loved the real-world examples."));
        videos.Add(v2);

        // Video 3
        Video v3 = new Video("Data Structures Explained", "Clara Lee", 450);
        v3.AddComment(new Comment("Raj", "Super helpful for my class."));
        v3.AddComment(new Comment("Anna", "The diagrams were amazing."));
        v3.AddComment(new Comment("Luis", "Best tutorial I’ve seen."));
        videos.Add(v3);

        // Display each video info
        foreach (Video video in videos)
        {
            video.DisplayInfo();
        }
    }
}
