using System;

// Class representing a YouTube comment
class Comment
{
    public string Name { get; set; }    // Commenter's name
    public string Text { get; set; }    // Comment text

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

// Class representing a YouTube video
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; }  // Video length in seconds
    private List<Comment> comments;          // List to store comments

    public Video(string title, string author, int lengthSeconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthSeconds;
        comments = new List<Comment>();
    }

    // Add a comment to the video
    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    // Get the number of comments
    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    // Get all comments
    public List<Comment> GetComments()
    {
        return comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== YouTube Video Tracker Program ===\n");

        // Create videos with "Ifeoluwa" as author
        Video video1 = new Video("C# Basics Tutorial", "Ifeoluwa", 600);
        Video video2 = new Video("Funny Cats Compilation", "Ifeoluwa", 420);
        Video video3 = new Video("Top 10 Travel Destinations", "Ifeoluwa", 900);
        Video video4 = new Video("Healthy Cooking Tips", "Ifeoluwa", 480);

        // Add comments to video1 (mix of names)
        video1.AddComment(new Comment("Moses", "Great tutorial, very clear!"));
        video1.AddComment(new Comment("Alice", "Helped me a lot, thanks!"));
        video1.AddComment(new Comment("Charlie", "Could you make one about loops?"));

        // Add comments to video2
        video2.AddComment(new Comment("Moses", "These cats are hilarious!"));
        video2.AddComment(new Comment("Eve", "I love the part at 2:30!"));
        video2.AddComment(new Comment("Frank", "So cute!!"));

        // Add comments to video3
        video3.AddComment(new Comment("Grace", "Adding these to my bucket list."));
        video3.AddComment(new Comment("Hannah", "I went to Bali, it was amazing!"));
        video3.AddComment(new Comment("Moses", "Great video, very informative."));

        // Add comments to video4
        video4.AddComment(new Comment("Jack", "I tried the smoothie recipe, loved it!"));
        video4.AddComment(new Comment("Moses", "This was super helpful, thank you."));
        video4.AddComment(new Comment("Leo", "Can you do a video on vegan desserts?"));

        // Put all videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Display video info and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"--- Video Title: {video.Title} ---");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"\t{comment.Name}: {comment.Text}");
            }

            Console.WriteLine("\n-------------------------\n");
        }

        Console.WriteLine("=== End of Video Tracker Program ===");
    }
}
