using System;
using System.Collections.Generic;

namespace Foundation1
{
    public class Comment
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public Comment(string name, string text)
        {
            Name = name;
            Text = text;
        }
    }

    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Length { get; set; }
        private List<Comment> Comments { get; set; }

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return Comments.Count;
        }

        public void DisplayVideoDetails()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Length: {Length} seconds");
            Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (var comment in Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Video video1 = new Video("Introduction to C#", "John Doe", 300);
            Video video2 = new Video("Advanced C# Programming", "Jane Smith", 450);
            Video video3 = new Video("C# Tips and Tricks", "Bob Johnson", 360);

            video1.AddComment(new Comment("Alice", "Great video, very informative!"));
            video1.AddComment(new Comment("Bob", "I learned a lot from this tutorial."));
            video1.AddComment(new Comment("Charlie", "Can you make a follow-up video on this?"));

            video2.AddComment(new Comment("Dave", "This is advanced but really helpful!"));
            video2.AddComment(new Comment("Eva", "I need to watch this a few more times."));
            video2.AddComment(new Comment("Frank", "Amazing content, very clear explanations."));

            video3.AddComment(new Comment("Grace", "I never knew these tips, thanks!"));
            video3.AddComment(new Comment("Hank", "Can you explain this in more detail?"));
            video3.AddComment(new Comment("Ivy", "Great tips, I’ll definitely use them."));

            List<Video> videos = new List<Video> { video1, video2, video3 };

            foreach (var video in videos)
            {
                video.DisplayVideoDetails();
                Console.WriteLine();
            }
        }
    }
}