using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var video1 = new Video("How To Cook Rice", "John Kitchen", 300);
        video1.AddComment(new Comment("Sarah", "Very helpful video!"));
        video1.AddComment(new Comment("Mike", "I learned a lot."));
        video1.AddComment(new Comment("Emma", "Thanks for sharing."));

        var video2 = new Video("Football Skills", "David Sports", 450);
        video2.AddComment(new Comment("Chris", "Amazing skills!"));
        video2.AddComment(new Comment("Anna", "Great tutorial."));
        video2.AddComment(new Comment("Peter", "I will try this."));

        var video3 = new Video("Morning Workout", "Fitness Life", 600);
        video3.AddComment(new Comment("Brian", "Nice workout."));
        video3.AddComment(new Comment("Kate", "This was hard!"));
        video3.AddComment(new Comment("Lucy", "Loved this routine."));

        var videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}