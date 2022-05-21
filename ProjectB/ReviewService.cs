using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

static class ReviewService
{
    public static List<Review> Reviews = new();
    private static readonly string file = "Reviews.json";

    public static void SaveReviews()
    {
        var indent = new JsonSerializerOptions { WriteIndented = true };
        string reviewString = JsonSerializer.Serialize(Reviews, indent);
        File.WriteAllText(file, reviewString);
    }
    public static void LoadReviews()
    {
        string jsonString = File.ReadAllText(file);
        Reviews = JsonSerializer.Deserialize<List<Review>>(jsonString);
    }

    public static void AddReview(Customer user, string reviewtext, int rating)
    {
        var newReview = new Review(user.FullName, user.Username, reviewtext, rating, DateTime.Now);
        Reviews.Add(newReview);
        user.Reviews.Add(newReview);
    }

    public static void ReviewFile()
    {
        string fileText = File.ReadAllText(file);
        Console.WriteLine(fileText);
    }

    public static void ListReviews()
    {
        if (Reviews.Count == 0)
        {
            Console.WriteLine("No reviews have been written yet.");
            Console.WriteLine("Press 'Enter' to continue.");
            Console.ReadLine();
            return;
        }
        foreach (var item in Reviews)
                Console.WriteLine($"{item.Date.ToShortDateString()} at {item.Date.ToShortTimeString()} - {item.ReviewText}");
    }

    public static void RemoveReview(int index, Customer user)
    {
        var review = user.Reviews[index];
        user.Reviews.Remove(review);
        ReviewService.Reviews.Remove(review);
    }
}
