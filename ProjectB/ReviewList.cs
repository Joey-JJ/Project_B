using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

class ReviewList
{
    public static List<ReviewData> Reviews = new();
    private static readonly string file = "Reviews.json";

    public static void WriteReview(string name, string email, string reviewtext, string rating)
    {
        var newReview = new ReviewData(name, email, reviewtext, rating);
        Reviews.Add(newReview);
    }
    public static void SaveReviews()
    {
        var indent = new JsonSerializerOptions { WriteIndented = true };
        string reviewString = JsonSerializer.Serialize(Reviews, indent);
        File.WriteAllText(file, reviewString);
    }
    public static void LoadReviews()
    {
        string jsonString = File.ReadAllText(file);
        Reviews = JsonSerializer.Deserialize<List<ReviewData>>(jsonString);
    }

    public static void ReviewFile()
    {
        string fileText = File.ReadAllText(file);
        Console.WriteLine(fileText);
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

    //public static void DeleteReviews(string ReviewName)
    //{
    //    int index = -1;
    //    for (int a = 0; a < Reviews.Count; a++)
    //    {
    //        if (Review[a].Name.ToLower() == ReviewName.ToLower())
    //            index = a;
    //    }

    //    if (index != -1)
    //    {
    //        Reviews.RemoveAt(index);
    //        Console.WriteLine("Review removed!");
    //        ReviewList.ReviewFile();
    //    }
    //    else
    //    {
    //        Console.WriteLine("Could not find review");
    //    }
    //}
}
