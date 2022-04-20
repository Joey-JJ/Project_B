using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

class ReviewList
{
	public static List<ReviewData> Reviews = new();
    private static readonly string ReviewFile = "./Reviews.json";

    public static void SaveReviews()
    {
        var indent = new JsonSerializerOptions { WriteIndented = true };
        string reviewString = JsonSerializer.Serialize(Reviews, indent);
        File.WriteAllText(ReviewFile, reviewString);
    }

    public static void AddReviews(
        string name, 
        string email, 
        string reviewtext, 
        int rating)
    {
        var newReview = new ReviewData(name, email, reviewtext, rating);
        Reviews.Add(newReview);
        Console.WriteLine("Added Review");
    }

    public static void ListReviews()
    {
        if (Reviews.Count > 0)
        {
            foreach (var item in Reviews)
            {
                Console.WriteLine($"{item.Name} gave a rating of {item.Rating}\n{item.ReviewText}");
            }
        }
        else
        {
            Console.WriteLine("There are no reviews written at the moment");
        }
    }
}
